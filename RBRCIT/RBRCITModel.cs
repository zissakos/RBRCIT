using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace RBRCIT
{
    /// <summary>
    /// Contains the business logic of the tool (reading/writing files, applying the changes, download stuff etc.)
    /// </summary>
    public class RBRCITModel
    {
        //All cars from carList.ini
        public List<Car> AllCars;

        //The currently installed cars. Only changed when APPLY is clicked.
        public List<Car> CurrentCarList;

        //The "working" list of cars in the right panel. On loading, it is an exact copy of CurrentCarList.
        //Any change (add/remove car) is only applied to this list. This way we know what is to be changed from the current car installation
        //(DesiredCarList != CurrentCarList) and we can mark it e.g. in a different color.
        //When APPLY is clicked, this list is written into all the ini files. 
        //Then the currently installed cars are re-read again in LoadCurrentCars() which populates CurrentCarList and DesiredCarList.
        public List<Car> DesiredCarList;

        //The saved car lists of the user under RBRCIT\savedlists
        public List<string> SavedCarLists;

        //How many car models were found in Cars\ folder? For the status bar.
        public int ModelsFound;

        //How many NGP physics were found in RBRCIT\\physics folder? For the status bar.
        public int PhysicsFound;

        //Is audio.dat extracted into Audio\ subfolder and non-existent?
        public bool UseAudio;

        private INIFile carlist_ini;
        private INIFile carlistuser_ini;
        private INIFile rbrcit_ini;
        private string[] PhysicsFolders;
        private string[] BackupFiles;
        
        //we save a reference to the mainform so we can call its update methods when the models (lists) have changed
        private Form1 mainForm;


        public RBRCITModel(Form1 form)
        {
            mainForm = form;
        }

        public void Load()
        {
            rbrcit_ini = new INIFile("RBRCIT.ini");

            AllCars = new List<Car>();
            CurrentCarList = new List<Car>();
            DesiredCarList = new List<Car>();
            SavedCarLists = new List<string>();

            PhysicsFolders = new string[] { "c_xsara", "h_accent", "mg_zr", "m_lancer", "p_206", "s_i2003", "t_coroll", "s_i2000" };

            BackupFiles = new string[] {
                "physics.rbz",
                "Cars/Cars.ini",
                "Audio/Cars/Cars.ini"
            };

            UseAudio = Directory.Exists("Audio") && !File.Exists("audio.dat");

            SetProxy();
        }

        private void SetProxy()
        {
            /*
            //works
            WebRequest.DefaultWebProxy = WebRequest.GetSystemWebProxy();
            WebRequest.DefaultWebProxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
            */

            //works!
            WebRequest.DefaultWebProxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;

            /*
            //works, but deprecated
            WebProxy wp = (WebProxy)GlobalProxySelection.Select;
            wp.UseDefaultCredentials = true;
            WebRequest.DefaultWebProxy = wp;
            */
        }

        public void checkFirstStartUp()
        {
            if (!Directory.Exists("RBRCIT\\backup"))
            {
                DialogResult dr = MessageBox.Show("A backup was not found. It is recommended to backup the files affected by this tool " +
                    "before any activity. Do you want to backup now?", "Backup?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    Backup();
            }

            ExtractPhysicsRBZ(false);

            if (!File.Exists("RBRCIT\\carlist\\carList.ini"))
            {
                DialogResult dr = MessageBox.Show("There is no carList.ini file. It will now be downloaded.", "Download carList.ini?", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                    DownloadCarListINI();
            }

            if (!UseAudio)
            {
                DialogResult dr = MessageBox.Show("Audio subfolder not found.\nIn order to use different engine sounds, the " +
                    "file audio.dat needs to be extracted.\nDo this now (takes 10-20s)?\n\n(You can do " +
                    "this later anytime via 'Tools' -> 'Extract audio.dat'.)", "Extract audio.dat?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                    ExtractAudioDAT();
            }
        }

        public void LoadAll()
        {
            UseAudio = Directory.Exists("Audio") && !File.Exists("audio.dat");
            LoadAllCars();
            LoadCurrentCars();
            LoadSavedLists();
            mainForm.UpdatePlugins();
            mainForm.UpdateApplyButton();
        }

        public void LoadAllCars()
        {
            carlist_ini = new INIFile("RBRCIT\\carlist\\carList.ini");
            if (File.Exists("RBRCIT\\carListUser.ini")) carlistuser_ini = new INIFile("RBRCIT\\carListUser.ini");
            AllCars.Clear();
            ModelsFound = 0;
            PhysicsFound = 0;
            foreach (string section in carlist_ini.GetSections())
            {
                if (!section.StartsWith("Car_")) continue;
                Car c = new Car();
                c.nr = section.Substring(4);
                c.name = carlist_ini.GetParameterValue("name", section);
                c.manufacturer = c.name.Substring(0, c.name.IndexOf(' '));
                c.name = c.name.Substring(c.name.IndexOf(' ') + 1);  //remove the manufacturer in the beginning
                c.physics = carlist_ini.GetParameterValue("physics", section);
                c.cat = carlist_ini.GetParameterValue("cat", section);
                c.iniFile = carlist_ini.GetParameterValue("iniFile", section);
                c.folder = carlist_ini.GetParameterValue("folder", section);
                c.trans = carlist_ini.GetParameterValue("trans", section);
                c.link_physics = carlist_ini.GetParameterValue("link_physics", section);
                c.link_model = carlist_ini.GetParameterValue("link_model", section);

                c.year = carlist_ini.GetParameterValue("year", section);
                string power = carlist_ini.GetParameterValue("power", section);
                if (power != null) int.TryParse(power.Substring(0, power.IndexOf("@")), out c.power);
                string weight = carlist_ini.GetParameterValue("weight", section);
                if (weight != null) int.TryParse(weight, out c.weight);

                c.model_exists = Directory.Exists("Cars\\" + c.folder);
                if (c.model_exists) ModelsFound++;
                c.physics_exists = Directory.Exists("RBRCIT\\physics\\" + c.physics);
                if (c.physics_exists) PhysicsFound++;

                //are there user settings? if yes set them. Default Engine sound = subaru!
                c.userSettings.engineSound = "subaru";
                if (carlistuser_ini != null)
                {
                    string sound = carlistuser_ini.GetParameterValue("engineSound", "Car_" + c.nr);
                    if (sound != null) c.userSettings.engineSound = sound;
                    c.userSettings.hideSteeringWheel = carlistuser_ini.GetParameterValueBool("hideSteeringWheel", "Car_" + c.nr);
                    c.userSettings.hideWipers = carlistuser_ini.GetParameterValueBool("hideWipers", "Car_" + c.nr);
                    c.userSettings.hideWindShield = carlistuser_ini.GetParameterValueBool("hideWindShield", "Car_" + c.nr);
                }

                AllCars.Add(c);
            }
            mainForm.UpdateAllCars();
        }

        public void LoadCurrentCars()
        {
            CurrentCarList.Clear();
            DesiredCarList.Clear();
            string pathToCarsINI = "Cars\\Cars.ini";
            if (!File.Exists(pathToCarsINI))
            {
                MessageBox.Show(pathToCarsINI + " could not be found. Please make sure you start this tool " +
                    "from your RBR installation folder and that there is a Cars.ini file in \\Cars. Exiting.");
                Environment.Exit(-1);
                return;
            }
            INIFile CarsINI = new INIFile(pathToCarsINI);
            foreach (string section in CarsINI.GetSections())
            {
                string CarName = CarsINI.GetParameterValue("CarName", section);
                Car c;
                if (CarName == null)
                {
                    string FileName = CarsINI.GetParameterValue("FileName", section);
                    string carNr = "";
                    if (FileName.Contains("\\xsara\\")) carNr = "1";
                    if (FileName.Contains("\\accent\\")) carNr = "2";
                    if (FileName.Contains("\\zr\\")) carNr = "3";
                    if (FileName.Contains("\\Lancer_EVO_VII\\")) carNr = "4";
                    if (FileName.Contains("\\Peugeot_206\\")) carNr = "5";
                    if (FileName.Contains("\\impreza03\\")) carNr = "6";
                    if (FileName.Contains("\\Corolla\\")) carNr = "7";
                    if (FileName.Contains("\\impreza00\\")) carNr = "8";
                    c = AllCars.Find(x => x.nr == carNr);
                }
                else
                {
                    c = AllCars.Find(x => (x.manufacturer + " " + x.name) == CarName);
                    if (c.name == null) c.name = CarName;
                }

                //read user settings (hide parts etc.)
                string file = "Cars\\" + c.folder + "\\" + c.iniFile + ".ini";
                if (File.Exists(file))
                {
                    INIFile carini = new INIFile("Cars\\" + c.folder + "\\" + c.iniFile + ".ini");
                    c.userSettings.hideSteeringWheel = carini.GetParameterValueBool("Switch", "i_steeringwheel");
                    c.userSettings.hideWipers = carini.GetParameterValueBool("Switch", "i_wiper_l") && carini.GetParameterValueBool("Switch", "i_wiper_r");
                    c.userSettings.hideWindShield = carini.GetParameterValueBool("Switch", "i_window_f");
                }

                CurrentCarList.Add(c);
            }

            //read current engine sounds
            if (UseAudio)
            {
                INIFile AudioCarsINI = new INIFile("Audio\\Cars\\Cars.ini");
                for (int i = 0; i < 8; i++)
                {
                    string sound = AudioCarsINI.GetParameterValue("Car" + i, "CARS");
                    Car c = CurrentCarList[i];
                    c.userSettings.engineSound = sound;
                    CurrentCarList[i] = c;
                }
            }

            DesiredCarList = new List<Car>(CurrentCarList.ToArray());
            mainForm.UpdateCurrentCars();
        }

        public void LoadSavedLists()
        {
            DirectoryInfo di = new DirectoryInfo("RBRCIT\\savedlists");
            FileInfo[] lists = di.GetFiles();
            SavedCarLists.Clear();
            foreach (FileInfo fi in lists)
            {
                SavedCarLists.Add(fi.Name.Replace(fi.Extension, ""));
            }
            mainForm.UpdateSavedLists();
        }

        public bool AddCar(Car c, int slot)
        {
            if (DesiredCarList[slot].nr == c.nr)
            {
                MessageBox.Show("This car is already at the desired car slot.");
                return false;
            }
            if (!c.model_exists || !c.physics_exists)
            {
                MessageBox.Show("You can only add cars to the slots that have both model and physics.");
                return false;
            }
            DesiredCarList[slot] = c;
            return true;
        }

        public void RemoveCar(int slot)
        {
            DesiredCarList[slot] = CurrentCarList[slot];
        }

        public bool ChangesPending()
        {
            for (int i = 0; i < 8; i++)
                if (!DesiredCarList[i].Equals(CurrentCarList[i])) return true;
            return false;
        }

        public void ApplyChanges(bool replaceSchoolFiles, bool force)
        {
            WriteCarsINI();
            CopyNGPPhysics(replaceSchoolFiles, force);
            WriteAudioCarsINI();
            ApplyUserSettings();
            WriteCarListUserINI();
            PatchEXE();
            LoadAllCars();
            LoadCurrentCars();
        }

        public void Backup()
        {
            string backupDir = "RBRCIT\\backup";
            if (Directory.Exists(backupDir)) Directory.Delete(backupDir, true);

            foreach (string file in BackupFiles)
            {
                if (!File.Exists(file)) continue;
                string destination = backupDir + "\\" + file;
                Directory.CreateDirectory(Path.GetDirectoryName(destination));
                File.Copy(file, destination);
            }
            MessageBox.Show("Backup created.");
        }

        public void Restore()
        {
            string backupDir = "RBRCIT\\backup";
            if (!Directory.Exists(backupDir)) return;
            HelperFunctions.DirectoryCopy(backupDir, ".");

            LoadAll();
            MessageBox.Show("Backup restored.");
        }

        private void WriteCarsINI()
        {
            FileInfo fi = new FileInfo("Cars\\cars.ini");
            fi.IsReadOnly = false;
            INIFile carsINI = new INIFile("Cars\\cars.ini");
            for (int i = 0; i < 8; i++)
            {
                if (DesiredCarList[i].Equals(CurrentCarList[i])) continue;
                Car c = DesiredCarList[i];
                string section = "Car0" + i;
                carsINI.SetParameter("FileName", string.Format("Cars\\{0}\\{1}.sgc", c.folder, c.iniFile), section);
                carsINI.SetParameter("IniFile", string.Format("Cars\\{0}\\{1}.ini", c.folder, c.iniFile), section);
                carsINI.SetParameter("ShaderFile", string.Format("Cars\\{0}\\{1}_shaders.ini", c.folder, c.iniFile), section);
                carsINI.SetParameter("ShaderSettings", string.Format("Cars\\{0}\\{1}_shader_settings", c.folder, c.iniFile), section);
                carsINI.SetParameter("TexturePath", string.Format("Cars\\{0}\\Textures", c.folder), section);
                carsINI.SetParameter("CarName", c.manufacturer + " " + c.name, section);
            }
            carsINI.Save();
        }

        //force=true: do it even if there is no desired change, required for updating physics.rbz after an NGP plugin download/update
        private void CopyNGPPhysics(bool replaceSchoolFiles, bool force)
        {
            for (int i = 0; i < 8; i++)
            {
                if (!force && DesiredCarList[i].Equals(CurrentCarList[i])) continue;
                Car c = DesiredCarList[i];

                //if it is a car unknown in carList.ini skip it
                if (c.physics == null) continue;

                //copy NGP physics if it exists
                string sourceFolder = "RBRCIT\\physics\\" + c.physics;
                string destFolder = "Physics\\" + PhysicsFolders[i];

                if (Directory.Exists(sourceFolder))
                {
                    if (Directory.Exists(destFolder))
                    {
                        HelperFunctions.DirectoryDeleteAllFilesRecursively(destFolder);
                    }
                    HelperFunctions.DirectoryCopy(sourceFolder, destFolder);
                }
            }


            //special handling for school car
            if (replaceSchoolFiles)
            {
                File.Copy("RBRCIT\\physics\\" + DesiredCarList[5].physics + "\\setups\\d_gravel.lsp", "Physics\\school\\gravel.lsp", true);
                File.Copy("RBRCIT\\physics\\" + DesiredCarList[5].physics + "\\setups\\d_gravel.lsp", "Physics\\school\\sfgravel.lsp", true);
                File.Copy("RBRCIT\\physics\\" + DesiredCarList[5].physics + "\\setups\\d_tarmac.lsp", "Physics\\school\\tarmac.lsp", true);

                string[] lines = File.ReadAllLines("Physics\\school\\sfgravel.lsp");
                int j = 0;
                foreach (string line in lines)
                {
                    if (line.Contains("FrontRollBarStiffness")) lines[j] = "   FrontRollBarStiffness\t\t\t0";
                    if (line.Contains("RearRollBarStiffness")) lines[j] = "   RearRollBarStiffness\t\t\t\t0";
                    j++;
                }
                File.WriteAllLines("Physics\\school\\sfgravel.lsp", lines);
            }
            else
            {
                HelperFunctions.DirectoryCopy("RBRCIT\\physics\\school", "Physics\\school");
            }

            //create physics.rbz from subfolder
            ZipManager.CreateFromDirectory("Physics", "physics.rbz", true);
        }

        private void WriteAudioCarsINI()
        {
            if (!UseAudio) return;
            INIFile audiocars_ini = new INIFile("Audio\\Cars\\Cars.ini");
            for (int i = 0; i < 8; i++)
            {
                if (DesiredCarList[i].userSettings.Equals(CurrentCarList[i].userSettings)) continue;
                if (DesiredCarList[i].userSettings.engineSound != null)
                    if (File.Exists("Audio\\Cars\\" + DesiredCarList[i].userSettings.engineSound + ".eng"))
                        audiocars_ini.SetParameter("Car" + i, DesiredCarList[i].userSettings.engineSound, "CARS");
            }
            audiocars_ini.SetParameter("Car1_LowShelfAmp", "2.0", "CARS");
            audiocars_ini.SpaceBeforeAndAfterEquals = false;
            audiocars_ini.Save();
        }

        private void ApplyUserSettings()
        {
            for (int i = 0; i < 8; i++)
            {
                //if (DesiredCarList[i].userSettings.Equals(CurrentCarList[i].userSettings)) continue;
                Car c = DesiredCarList[i];
                FileInfo fi = new FileInfo("Cars\\" + c.folder + "\\" + c.iniFile + ".ini");
                fi.IsReadOnly = false;
                
                IniFileHelper.WriteValue("i_steeringwheel", "Switch", c.userSettings.hideSteeringWheel.ToString(), fi.FullName);
                IniFileHelper.WriteValue("i_wiper_l", "Switch", c.userSettings.hideWipers.ToString(), fi.FullName);
                IniFileHelper.WriteValue("i_wiper_r", "Switch", c.userSettings.hideWipers.ToString(), fi.FullName);
                IniFileHelper.WriteValue("i_window_f", "Switch", c.userSettings.hideWindShield.ToString(), fi.FullName);

                //apply the overrides defined in RBRCIT.ini (AlwaysHideXXX...)
                if (rbrcit_ini.GetParameterValueBool("AlwaysHideSteeringWheel", "RBRCIT"))
                    IniFileHelper.WriteValue("i_steeringwheel", "Switch", true.ToString(), fi.FullName);
                if (rbrcit_ini.GetParameterValueBool("AlwaysHideWipers", "RBRCIT"))
                {
                    IniFileHelper.WriteValue("i_wiper_l", "Switch", true.ToString(), fi.FullName);
                    IniFileHelper.WriteValue("i_wiper_r", "Switch", true.ToString(), fi.FullName);
                }
                if (rbrcit_ini.GetParameterValueBool("AlwaysHideWindShield", "RBRCIT"))
                    IniFileHelper.WriteValue("i_window_f", "Switch", true.ToString(), fi.FullName);
            }
        }

        private void WriteCarListUserINI()
        {
            //copy back to Cars
            foreach (Car d in DesiredCarList)
            {
                int i = AllCars.FindIndex(x => x.nr == d.nr);
                if (i == -1) continue;
                AllCars[i] = d;
            }
            //write carListUser.ini for all cars in carList.ini
            INIFile carListUserINI = new INIFile();
            foreach (Car c in AllCars)
            {
                carListUserINI.SetParameter("engineSound", c.userSettings.engineSound, "Car_" + c.nr);
                carListUserINI.SetParameter("hideSteeringWheel", c.userSettings.hideSteeringWheel.ToString(), "Car_" + c.nr);
                carListUserINI.SetParameter("hideWipers", c.userSettings.hideWipers.ToString(), "Car_" + c.nr);
                carListUserINI.SetParameter("hideWindShield", c.userSettings.hideWindShield.ToString(), "Car_" + c.nr);
            }
            carListUserINI.SaveAs("RBRCIT\\carListUser.ini");
        }

        private void PatchEXE()
        {
            if (!rbrcit_ini.GetParameterValueBool("patchEXE", "RBRCIT")) return;

            List<Tuple<int, int>> locations = new List<Tuple<int, int>>(); //offset, length
            locations.Add(new Tuple<int, int>(0x330E50, 0xF));
            locations.Add(new Tuple<int, int>(0x330E40, 0xF));
            locations.Add(new Tuple<int, int>(0x330E2C, 0x13));
            locations.Add(new Tuple<int, int>(0x330E10, 0x1B));
            locations.Add(new Tuple<int, int>(0x330E04, 0xB));
            locations.Add(new Tuple<int, int>(0x330DF0, 0x13));
            locations.Add(new Tuple<int, int>(0x330DE0, 0xF));
            locations.Add(new Tuple<int, int>(0x330DCC, 0x13));

            new FileInfo("RichardBurnsRally_SSE.exe").IsReadOnly = false;
            FilePatcher patcher = new FilePatcher("RichardBurnsRally_SSE.exe");
            for (int i = 0; i < 8; i++)
            {
                patcher.WriteAt(locations[i].Item1, locations[i].Item2, DesiredCarList[i].manufacturer + " " + DesiredCarList[i].name);
            }
            patcher.Save();
        }

        public void LoadCarList(string name)
        {
            string pathToFile = "RBRCIT\\savedlists\\" + name + ".txt";
            if (!File.Exists(pathToFile))
            {
                MessageBox.Show("List file could not be found.");
                return;
            }
            StreamReader sr = new StreamReader(pathToFile);
            string line;
            while (!sr.EndOfStream)
            {
                line = sr.ReadLine();
                string[] chunks = line.Split(';');
                int slot = int.Parse(chunks[0]);
                string car_nr = chunks[1];

                Car c = AllCars.Find(x => x.nr == car_nr);
                if (c.nr != null)
                    DesiredCarList[slot] = c;
            }
            sr.Close();
            mainForm.UpdateCurrentCars();
            mainForm.UpdateApplyButton();
        }

        public void SaveCarList(string name)
        {
            StreamWriter sw = new StreamWriter("RBRCIT\\savedlists\\" + name + ".txt");

            for (int i = 0; i < 8; i++)
            {
                Car c = DesiredCarList[i];
                if (c.nr == null) continue;
                sw.WriteLine(i + ";" + c.nr + ";" + c.manufacturer + " " + c.name);
            }
            sw.Close();
            LoadSavedLists();
        }

        public void DownloadCarListINI()
        {
            using (var client = new WebClient())
            {
                client.DownloadFile(rbrcit_ini.GetParameterValue("carlist_ini_url", "RBRCIT"), "RBRCIT\\carlist\\carList.ini");
            }
            LoadAll();
        }

        public void DownloadCarModel(Car c)
        {
            if (c.link_model != null)
            {
                DownloadJob job = new DownloadJob();
                job.title = c.manufacturer + " " + c.name;
                job.URL = c.link_model;
                job.path = "Cars\\";
                FormDownload fd = new FormDownload(job);
                fd.FormClosed += FormDownloadClosedAllCars;
                fd.ShowAtCenterParent(mainForm);
            }
            else
            {
                Process.Start("http://www.ly-racing.de/viewtopic.php?t=7878");
            }
        }

        public void DownloadCarPhysics(Car c)
        {
            DownloadJob job = new DownloadJob();
            job.title = c.manufacturer + " " + c.name;
            job.URL = c.link_physics;
            job.path = "RBRCIT\\physics\\";
            FormDownload fd = new FormDownload(job);
            fd.FormClosed += FormDownloadClosedAllCars;
            fd.ShowAtCenterParent(mainForm);
        }

        public void DownloadMissingPhysics()
        {
            List<DownloadJob> jobs = new List<DownloadJob>();
            foreach (Car c in AllCars)
            {
                if (!c.physics_exists)
                {
                    DownloadJob job;
                    job.title = c.manufacturer + " " + c.name;
                    job.URL = c.link_physics;
                    job.path = "RBRCIT\\physics\\";
                    jobs.Add(job);
                }
            }
            if (jobs.Count == 0)
            {
                MessageBox.Show("No missing physics. All physics are there.");
                return;
            }
            FormDownload fd = new FormDownload(jobs);
            fd.FormClosed += FormDownloadClosedAllCars;
            fd.ShowAtCenterParent(mainForm);
        }

        public void UpdateAllExistingPhysics()
        {
            List<DownloadJob> jobs = new List<DownloadJob>();
            foreach (Car c in AllCars)
            {
                if (c.physics_exists)
                {
                    DownloadJob job;
                    job.title = c.manufacturer + " " + c.name;
                    job.URL = c.link_physics;
                    job.path = "RBRCIT\\physics\\";
                    jobs.Add(job);
                }
            }
            if (jobs.Count == 0)
            {
                MessageBox.Show("No existing physics. Download Physics first.");
                return;
            }
            FormDownload fd = new FormDownload(jobs);
            fd.FormClosed += FormDownloadClosedAllCars;
            fd.ShowAtCenterParent(mainForm);
        }

        public bool PluginExistsNGP()
        {
            string pluginFileName = "Plugins\\PhysicsNG.dll";
            return (File.Exists(pluginFileName));
        }

        public string GetPluginVersionNGP()
        {
            string pluginFileName = "Plugins\\PhysicsNG.dll";
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(pluginFileName);
            return fvi.ProductVersion;
        }

        public void DownloadPluginNGP()
        {
            DownloadJob dj = new DownloadJob();
            dj.path = ".";
            dj.title = "NGP Plugin";
            //dj.URL = rbrcit_ini.GetParameterValue("plugin_physics_url");
            dj.URL = carlist_ini.GetParameterValue("plugin_physics_url", "Plugins");
            FormDownload fd = new FormDownload(dj);
            fd.FormClosed += FormDownloadClosedNGP;
            fd.ShowAtCenterParent(mainForm);
        }

        public bool PluginExistsFixUp()
        {
            string pluginFileName = "Plugins\\FixUp.dll";
            return (File.Exists(pluginFileName));
        }

        public string GetPluginVersionFixUp()
        {
            string pluginFileName = "Plugins\\FixUp.dll";
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(pluginFileName);
            return fvi.ProductVersion;
        }

        public void DownloadPluginFixUp()
        {
            DownloadJob dj = new DownloadJob();
            dj.path = "Plugins\\";
            dj.title = "FixUp Plugin";
            //dj.URL = rbrcit_ini.GetParameterValue("plugin_fixup_url");
            dj.URL = carlist_ini.GetParameterValue("plugin_fixup_url", "Plugins");
            FormDownload fd = new FormDownload(dj);
            fd.FormClosed += FormDownloadClosedPlugin;
            fd.ShowAtCenterParent(mainForm);
        }

        private void FormDownloadClosedAllCars(object sender, FormClosedEventArgs e)
        {
            LoadAllCars();
        }

        private void FormDownloadClosedNGP(object sender, FormClosedEventArgs e)
        {
            HelperFunctions.RemoveReadOnlyFlagInFolder("Physics\\school");
            ExtractPhysicsRBZ(true);
            HelperFunctions.RemoveReadOnlyFlagInFolder("Physics\\school");
            CopyNGPPhysics(false, true);
            FormDownloadClosedPlugin(null, null);
        }

        private void FormDownloadClosedPlugin(object sender, FormClosedEventArgs e)
        {
            mainForm.UpdatePlugins();
        }

        public void ExtractAudioDAT()
        {
            if (!File.Exists("audio.dat"))
            {
                MessageBox.Show("The file audio.dat was not found. Aborting.");
                return;
            }

            if (Directory.Exists("Audio")) Directory.Delete("Audio", true);
            if (Directory.Exists("audio.dat.extracted")) Directory.Delete("audio.dat.extracted", true);

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "RBRCIT\\bin\\dattool.exe";
            psi.Arguments = "-e audio.dat audio.dat.extracted";
            Process myProcess = Process.Start(psi);
            myProcess.WaitForExit();

            Directory.Move("audio.dat.extracted\\C#\\Projects\\Rally_7\\TargetMedia_Develop\\Pc\\Debug\\World\\Audio", "Audio");
            Directory.Delete("audio.dat.extracted", true);
            File.Move("audio.dat", "audio.dat.old");

            MessageBox.Show("The file 'audio.dat' has been extracted into the new subfolder 'Audio' and renamed to 'audio.dat.old'. Now you can change engine sounds!");

            UseAudio = Directory.Exists("Audio") && !File.Exists("audio.dat");
        }

        public void ExtractPhysicsRBZ(bool overwriteSubFolder)
        {
            if (!Directory.Exists("Physics") && !File.Exists("physics.rbz"))
            {
                DialogResult dr = MessageBox.Show("Neither the file 'physics.rbz' nor the subfolder 'Physics' could be found." +
                    "\nPlease start this tool from inside an RBR folder." +
                    "\nIf this is already the case, please restore 'physics.rbz'." +
                    "\n\nAlternatively, the NGP plugin could be downloaded now to rectify the situation. Download now?", "", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                    DownloadPluginNGP();
                else
                    Environment.Exit(-1);
            }

            if (Directory.Exists("Physics"))
            {
                if (overwriteSubFolder)
                {
                    //Directory.Delete("Physics", true);
                    //while (Directory.Exists("Physics")) System.Threading.Thread.Sleep(10);
                    HelperFunctions.DirectoryDeleteAllFilesRecursively("Physics");
                }
                else return;
            }
            if (File.Exists("physics.rbz")) ZipManager.ExtractToDirectory("physics.rbz", ".");
        }

        public void RestoreOriginalRBRCars()
        {
            DesiredCarList[0] = AllCars.Find(x => x.nr == "1");
            DesiredCarList[1] = AllCars.Find(x => x.nr == "2");
            DesiredCarList[2] = AllCars.Find(x => x.nr == "3");
            DesiredCarList[3] = AllCars.Find(x => x.nr == "4");
            DesiredCarList[4] = AllCars.Find(x => x.nr == "5");
            DesiredCarList[5] = AllCars.Find(x => x.nr == "6");
            DesiredCarList[6] = AllCars.Find(x => x.nr == "7");
            DesiredCarList[7] = AllCars.Find(x => x.nr == "8");
            ApplyChanges(false, true);
        }

        public string GetCarListVersion()
        {
            string comment = carlist_ini.GetCommentAtLine(1);
            if (comment != null && comment.Contains("Version")) comment = comment.Remove(0, 2);
            return comment;
        }

        public string GetRBRCITVersion()
        {
            return Application.ProductVersion.Substring(0, Application.ProductVersion.Length - 2);
        }
    }
}
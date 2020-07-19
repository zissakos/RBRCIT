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
        const string FILEPATH_RBRCIT_INI = "";
        const string FILEPATH_CARS_INI = "";
        const string FILEPATH_AUDIO_CARS_INI = "";
        const string FILEPATH_CARLIST_INI = "RBRCIT\\carlist\\carlist.ini";
        const string FILEPATH_CARLIST_INI_TEMP = "RBRCIT\\carlist\\carlist_new.ini";
        const string FILEPATH_AUDIO_FMOD_INI = "AudioFMOD\\AudioFMOD.ini";
        const string FILEPATH_VERSIONS_INI = "RBRCIT\\versions.ini";





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

        //is FMOD generally available, i.e. is Fixup version >= 4 and does subfolder AudioFMOD exist
        public bool FMODAvailable;

        //is FMOD enabled, i.e. the parameter EnableFMOD in AudioFMOD.ini is set to true?
        public bool FMODEnabled;

        public bool UseExternalUnzipper;
        public string PathToExternalUnzipper;
        public string ExternalUnzipperArguments;

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

            UseExternalUnzipper = false;
            PathToExternalUnzipper = rbrcit_ini.GetParameterValue("external_unzipper", "ArchiveHandling");
            ExternalUnzipperArguments = rbrcit_ini.GetParameterValue("arguments_extract", "ArchiveHandling");
            UseExternalUnzipper = (PathToExternalUnzipper != null) && (File.Exists(PathToExternalUnzipper));

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

            UpdateAudio();
            UpdateFMOD();

            SetProxy();
        }

        public void UpdateAudio()
        {
            UseAudio = Directory.Exists("Audio") && !File.Exists("audio.dat");
        }

        public void UpdateFMOD()
        {
            //include ((rbrcit.GetPluginVersionNGP().CompareTo("6.3.758.431") >= 0)  ?
            FMODAvailable = Directory.Exists("AudioFMOD") && PluginExistsFixUp() && GetPluginVersionFixUp().CompareTo("4.0") >= 0;
            FMODEnabled = GetFMODStatusEnabled();
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
            UpdateAudio();
            LoadAllCars();
            LoadCurrentCars();
            LoadSavedLists();
            mainForm.UpdatePluginsPanel();
            mainForm.UpdateFMODPanel();
            mainForm.UpdateApplyButton();
        }

        public void LoadAllCars()
        {
            if (!File.Exists(FILEPATH_CARLIST_INI))
            {
                MessageBox.Show("carlist.ini cannot be found. RBRCIT will close now.");
                Application.Exit();
                System.Environment.Exit(1);
            }

            carlist_ini = new INIFile(FILEPATH_CARLIST_INI);
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
                c.link_banks = carlist_ini.GetParameterValue("link_banks", section);

                c.year = carlist_ini.GetParameterValue("year", section);
                string power = carlist_ini.GetParameterValue("power", section);
                if (power != null) int.TryParse(power.Substring(0, power.IndexOf("@")), out c.power);
                string weight = carlist_ini.GetParameterValue("weight", section);
                if (weight != null) int.TryParse(weight, out c.weight);

                c.model_exists = Directory.Exists("Cars\\" + c.folder);
                if (c.model_exists) ModelsFound++;
                c.physics_exists = Directory.Exists("RBRCIT\\physics\\" + c.physics);
                if (c.physics_exists) PhysicsFound++;

                c.banks = carlist_ini.GetParameterValue("banks", section);
                if (c.banks!=null && c.banks.Contains(",")) c.banks = c.banks.Substring(0, c.banks.IndexOf(','));
                c.banks_exist = (c.banks != null) && Directory.Exists("AudioFMOD\\") && Directory.GetFiles("AudioFMOD\\", c.banks + "*").Length > 0;

                //are there user settings? if yes set them. Default Engine sound = subaru!
                    c.userSettings.engineSound = "subaru";
                if (carlistuser_ini != null)
                {
                    string sound = carlistuser_ini.GetParameterValue("engineSound", "Car_" + c.nr);
                    if (sound != null) c.userSettings.engineSound = sound;
                    string FMODSoundBank = carlistuser_ini.GetParameterValue("FMODSoundBank", "Car_" + c.nr);
                    if (FMODSoundBank != null) c.userSettings.FMODSoundBank = FMODSoundBank;
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
                if (!section.StartsWith("Car")) continue;
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

            
            //read current FMOD Sound Banks
            if (FMODAvailable)
            {
                for (int i = 0; i < 8; i++)
                {
                    string FMODSoundBank = IniFileHelper.ReadValue("Car" + i.ToString("00"), "bankName", "AudioFMOD\\AudioFMOD.ini");
                    Car c = CurrentCarList[i];
                    c.userSettings.FMODSoundBank = FMODSoundBank;
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
            WriteAudioFMODINI();
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

        private void WriteAudioFMODINI()
        {
            if (!FMODAvailable) return;
            for (int i = 0; i < 8; i++)
            {
                if (DesiredCarList[i].userSettings.Equals(CurrentCarList[i].userSettings)) continue;
                if (DesiredCarList[i].userSettings.FMODSoundBank != null)
                    //if (File.Exists("AudioFMOD\\" + DesiredCarList[i].userSettings.FMODSoundBank + ".bank"))
                        IniFileHelper.WriteValue("Car" + i.ToString("00"), "bankName", DesiredCarList[i].userSettings.FMODSoundBank, "AudioFMOD\\AudioFMOD.ini");
            }
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
                carListUserINI.SetParameter("FMODSoundBank", c.userSettings.FMODSoundBank, "Car_" + c.nr);
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
                client.DownloadFileCompleted += Client_DownloadFileCompleted;

                if (File.Exists(FILEPATH_CARLIST_INI_TEMP)) File.Delete(FILEPATH_CARLIST_INI_TEMP);
                string url = rbrcit_ini.GetParameterValue("carlist_ini_url", "RBRCIT");
                Uri uri = new Uri(url);
                try
                {
                    client.DownloadFileAsync(uri, FILEPATH_CARLIST_INI_TEMP);
                }
                catch (Exception e)
                {
                    MessageBox.Show("URL: " + url + "\n\nFile download not successful:\n" + e.Message);
                    if (File.Exists(FILEPATH_CARLIST_INI_TEMP)) File.Delete(FILEPATH_CARLIST_INI_TEMP);
                    return;
                }
            }
        }

        private void Client_DownloadFileCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (File.Exists(FILEPATH_CARLIST_INI)) File.Delete(FILEPATH_CARLIST_INI);
            File.Move(FILEPATH_CARLIST_INI_TEMP, FILEPATH_CARLIST_INI);
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
                FormDownload fd = new FormDownload(job, this);
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
            FormDownload fd = new FormDownload(job, this);
            fd.FormClosed += FormDownloadClosedAllCars;
            fd.ShowAtCenterParent(mainForm);
        }

        public void DownloadCarSoundBank(Car c)
        {
            DownloadJob job = new DownloadJob();
            job.title = c.manufacturer + " " + c.name;
            job.URL = c.link_banks;
            job.path = ".";
            FormDownload fd = new FormDownload(job, this);
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
            FormDownload fd = new FormDownload(jobs, this);
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
            FormDownload fd = new FormDownload(jobs, this);
            fd.FormClosed += FormDownloadClosedAllCars;
            fd.ShowAtCenterParent(mainForm);
        }


        public void DownloadMissingSoundBanks()
        {
            List<DownloadJob> jobs = new List<DownloadJob>();
            foreach (Car c in AllCars)
            {
                if (!c.banks_exist && c.link_banks!=null)
                {
                    DownloadJob job;
                    job.title = c.manufacturer + " " + c.name;
                    job.URL = c.link_banks;
                    job.path = ".";
                    jobs.Add(job);
                }
            }
            if (jobs.Count == 0)
            {
                MessageBox.Show("No missing SoundBanks. All available SoundBanks are there.");
                return;
            }
            FormDownload fd = new FormDownload(jobs, this);
            fd.FormClosed += FormDownloadClosedAllCars;
            fd.ShowAtCenterParent(mainForm);
        }


        public void UpdateAllExistingSoundBanks()
        {
            List<DownloadJob> jobs = new List<DownloadJob>();
            foreach (Car c in AllCars)
            {
                if (c.banks_exist)
                {
                    DownloadJob job;
                    job.title = c.manufacturer + " " + c.name;
                    job.URL = c.link_banks;
                    job.path = ".";
                    jobs.Add(job);
                }
            }
            if (jobs.Count == 0)
            {
                MessageBox.Show("No existing SoundBanks. Download SoundBanks first.");
                return;
            }
            FormDownload fd = new FormDownload(jobs, this);
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
            FormDownload fd = new FormDownload(dj, this);
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
            dj.title = "FixUp Plugin";
            dj.path = ".";
            dj.URL = carlist_ini.GetParameterValue("plugin_fixup4_url", "Plugins");

            //legacy support for FixUp < v4
            if (dj.URL == null)
            {
                dj.URL = carlist_ini.GetParameterValue("plugin_fixup_url", "Plugins");
                dj.path = "Plugins\\";
            }

            FormDownload fd = new FormDownload(dj, this);
            fd.FormClosed += FormDownloadClosedFixup;
            fd.ShowAtCenterParent(mainForm);
        }

        public void DownloadAudioFMOD()
        {
            DownloadJob dj = new DownloadJob();
            dj.title = "AudioFMOD";
            dj.path = ".";
            dj.URL = GetAudioFMOD_URL();
            FormDownload fd = new FormDownload(dj, this);
            fd.FormClosed += FormDownloadClosedAudioFMOD;
            fd.ShowAtCenterParent(mainForm);

        }
        public bool GetFMODStatusEnabled()
        {
            string value = IniFileHelper.ReadValue("Settings", "enableFMOD", FILEPATH_AUDIO_FMOD_INI, "false");
            if (value == "0") return false;
            if (value == "1") return true;
            return bool.Parse(value);
        }

        public void SetFMODEnabled(bool status)
        {
            IniFileHelper.WriteValue("Settings", "enableFMOD", status.ToString(), FILEPATH_AUDIO_FMOD_INI);
            FMODEnabled = status;
            mainForm.UpdateFMODPanel();
        }

        public string GetAudioFMODVersion()
        {
            string result = IniFileHelper.ReadValue("Versions", "AudioFMOD", FILEPATH_VERSIONS_INI);
            return result;
        }

        public bool AudioFMODiniExists()
        {
            return File.Exists(FILEPATH_AUDIO_FMOD_INI);
        }

        public bool AudioFMODExists()
        {
            bool result = Directory.Exists("AudioFMOD") && (GetAudioFMODVersion() != "");
            return result;
        }

        public string GetAudioFMOD_URL()
        {
            string result = IniFileHelper.ReadValue("Misc", "audio_fmod_url", FILEPATH_CARLIST_INI);
            return result;
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

            mainForm.UpdatePluginsPanel();
            mainForm.UpdateFMODPanel();
        }

        private void FormDownloadClosedFixup(object sender, FormClosedEventArgs e)
        {
            UpdateFMOD();
            mainForm.UpdatePluginsPanel();
            mainForm.UpdateFMODPanel();
        }

        private void FormDownloadClosedAudioFMOD(object sender, FormClosedEventArgs e)
        {
            FormDownload fd = (FormDownload)sender;
            string version = fd.filename.Replace(".7z", "").Split('-')[1];
            IniFileHelper.WriteValue("Versions", "AudioFMOD", version, FILEPATH_VERSIONS_INI);
            UpdateFMOD();
            mainForm.UpdateFMODPanel();
        }

        public void ExtractFile(string path, string outputdir)
        {
            if (UseExternalUnzipper)
            {
                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = PathToExternalUnzipper;
                psi.Arguments = ExternalUnzipperArguments.Replace("%1%", path).Replace("%2%", outputdir);
                Process myProcess = Process.Start(psi);
                myProcess.WaitForExit();
            }
            else
            {
                ZipManager.ExtractToDirectory(path, outputdir);
            }
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

            UpdateAudio();
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

        public void UpdateRBRCIT()
        {
            string url = IniFileHelper.ReadValue("Misc", "rbrcit_url", FILEPATH_CARLIST_INI);
            if (String.IsNullOrEmpty(url))
            {
                MessageBox.Show("There is no RBRCIT Download URL in carList.ini (Misc section).\nPlease update carList.ini first.");
                return;
            }

            //prepare update
            string runningfilename = "RBRCIT.exe";
            string backupfilename = "RBRCIT.bak";
            if (File.Exists(backupfilename)) File.Delete(backupfilename);
            File.Move(runningfilename, backupfilename);

            //start download&extract
            DownloadRBRCIT();
        }

        void DownloadRBRCIT()
        {
            DownloadJob dj = new DownloadJob();
            dj.path = ".";
            dj.title = "RBRCIT";
            //dj.URL = rbrcit_ini.GetParameterValue("plugin_physics_url");
            dj.URL = IniFileHelper.ReadValue("Misc", "rbrcit_url", FILEPATH_CARLIST_INI);
            FormDownload fd = new FormDownload(dj, this);
            fd.FormClosed += FormDownloadClosedRBRCIT;
            fd.ShowAtCenterParent(mainForm);
        }

        private void FormDownloadClosedRBRCIT(object sender, FormClosedEventArgs e)
        {
            string runningfilename = "RBRCIT.exe";
            string backupfilename = "RBRCIT.bak";

            if (File.Exists(runningfilename))  //if download&extract has been sucessful
            {
                Application.Restart();
            }
            else
            {
                File.Move(backupfilename, runningfilename);  //revert back to make sure an exe exists
            }

        }
    }
}
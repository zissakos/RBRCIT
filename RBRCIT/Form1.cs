using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BrightIdeasSoftware;

namespace RBRCIT
{
    public partial class Form1 : Form
    {
        //used for compatibility check in LoadWindowState
        const int WindowStateFileVersion = 1;

        private Font RegularFont, BoldFont;
        private Color Red, Green, Gray;
        private RBRCITModel rbrcit;

        public Form1()
        {
            InitializeComponent();
            SetSchoolToolTip();
            rbrcit = new RBRCITModel(this);
        }

        void SetSchoolToolTip()
        {
            ToolTip tt = new ToolTip();
            tt.AutomaticDelay = 0;
            tt.AutoPopDelay = 30000;
            tt.InitialDelay = 0;
            tt.ReshowDelay = 0;
            tt.ToolTipIcon = ToolTipIcon.Warning;
            //tt.ToolTipTitle = "HELP";
            string tooltiptext = "Copies the setups of the vehicle in Slot 5 to the 'school' subfolder of physics.rbz." + Environment.NewLine;
            tooltiptext += "Enables to use Car #5 in the rally school." + Environment.NewLine;
            tooltiptext += "" + Environment.NewLine;
            tooltiptext += "However, this breaks compatibility with the Czech (RBRTM) plugin!" + Environment.NewLine;
            tt.SetToolTip(cbReplaceShoolFiles, tooltiptext);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Text += " (v" + rbrcit.GetRBRCITVersion() + ")";

            InitializeFields();

            rbrcit.Load();
            rbrcit.checkFirstStartUp();
            rbrcit.LoadAll();

            LoadWindowState();

            col2Sound.IsVisible = rbrcit.UseAudio;
            olvInstalledCars.RebuildColumns();

            //this is for sorting in ungrouped state. When grouped, see event handler olvAllCars_BeforeCreatingGroups
            //make sure it is being sorted by Manufacturer and Name additionally
            olvAllCars.CustomSorter = delegate(OLVColumn column, SortOrder order)
            {
                if (column != colName)
                {
                    olvAllCars.ListViewItemSorter = new ColumnComparer3(column, order, colManufacturer, SortOrder.Ascending, colName, SortOrder.Ascending);
                }
            };
        }

        private void InitializeFields()
        {
            RegularFont = olvAllCars.Font;
            BoldFont = new Font(RegularFont, FontStyle.Regular);
            Red = Color.MediumVioletRed;
            Green = Color.MediumSeaGreen;
            Gray = Color.FromArgb(0xaaaaaa);
        }

        public void UpdateAllCars()
        {
            toolStripStatusLabel1.Text = "Total Cars: " + rbrcit.AllCars.Count;
            toolStripStatusLabel2.Text = "Models: " + rbrcit.ModelsFound;
            toolStripStatusLabel3.Text = "Physics: " + rbrcit.PhysicsFound;
            toolStripStatusLabel4.Text = rbrcit.GetCarListVersion();

            //save collapsed state of groups to restore later
            List<string> groups = new List<string>();
            foreach (OLVGroup group in olvAllCars.CollapsedGroups) groups.Add(group.Key.ToString());

            //we only want to autoresize the columns on startup, not everytime we update
            if (olvAllCars.Objects == null)
            {
                olvAllCars.SetObjects(rbrcit.AllCars, true);
                HelperFunctions.AutoResizeByHeaderAndContent(olvAllCars);
            }
            else
            {
                olvAllCars.SetObjects(rbrcit.AllCars, true);
            }

            //restore collapsed state of groups
            foreach (OLVGroup group in olvAllCars.OLVGroups) if (groups.Contains(group.Key.ToString())) group.Collapsed = true;
        }

        public void UpdateCurrentCars()
        {
            //we only want to autoresize the columns on startup, not everytime we update
            if (olvAllCars.Objects == null)
            {
                olvInstalledCars.SetObjects(rbrcit.DesiredCarList);
                HelperFunctions.AutoResizeByHeaderAndContent(olvInstalledCars);
            }
            else
            {
                olvInstalledCars.SetObjects(rbrcit.DesiredCarList);
            }
            olvInstalledCars.SelectedIndex = 0;
        }

        public void UpdatePlugins()
        {
            if (rbrcit.PluginExistsNGP())
            {
                string version = rbrcit.GetPluginVersionNGP();
                lblNGP.Text = version.Substring(0, version.IndexOf(' '));
                lblNGPDate.Text = version.Substring(version.IndexOf(' '));
                btNGP.Text = "Update";
                btNGPConfigure.Enabled = true;
            }
            else
            {
                lblNGP.Text = "(not found)";
                lblNGPDate.Text = "";
                btNGP.Text = "Download";
                btNGPConfigure.Enabled = false;
            }
            if (rbrcit.PluginExistsFixUp())
            {
                string version = rbrcit.GetPluginVersionFixUp();
                lblFixup.Text = version.Substring(0, version.IndexOf(' '));
                lblFixUpDate.Text = version.Substring(version.IndexOf(' '));
                btFixup.Text = "Update";
                btFixupConfigure.Enabled = true;
            }
            else
            {
                lblFixup.Text = "(not found)";
                lblFixUpDate.Text = "";
                btFixup.Text = "Download";
                btFixupConfigure.Enabled = false;
            }
            
            //enable plugin buttons
            btNGP.Enabled = true;
            btFixup.Enabled = true;

        }

        public void UpdateSavedLists()
        {
            if (contextLoadList.Items.Count > 0)
            {
                contextLoadList.Items[contextLoadList.Items.Count - 2].Owner = contextLoadListManage;
                contextLoadList.Items[contextLoadList.Items.Count - 1].Owner = contextLoadListManage;
                contextLoadList.Items.Clear();

            }
            foreach (string carlist in rbrcit.SavedCarLists)
            {
                ToolStripItem tsi = contextLoadList.Items.Add(carlist);
                tsi.Click += LoadCarList_Click;
            }

            contextLoadListManage.Items[0].Owner = contextLoadList;
            contextLoadListManage.Items[0].Owner = contextLoadList;  //again 0, because this action removes the item from the source list!
        }

        private void AddCar(Car c, int slot)
        {
            if (!rbrcit.AddCar(c, slot)) return;
            olvInstalledCars.BuildList();
            if (slot < 7) slot++;
            olvInstalledCars.SelectedIndex = slot;
            UpdateApplyButton();
        }

        private void RemoveCar(int slot)
        {
            rbrcit.RemoveCar(slot);
            int oldSelected = olvInstalledCars.SelectedIndex;
            olvInstalledCars.BuildList();
            olvInstalledCars.SelectedIndex = oldSelected;
            //olvInstalledCars.SelectedIndex = slot;
            UpdateApplyButton();
        }

        public void UpdateApplyButton()
        {
            btApply.Enabled = rbrcit.ChangesPending();
        }

        private void olvAllCars_FormatRow(object sender, FormatRowEventArgs e)
        {
            Car c = (Car)e.Model;
            if (c.model_exists && c.physics_exists)
            {
                e.Item.ForeColor = Color.Black;
                e.Item.Font = BoldFont;
            }
            else
            {
                e.Item.ForeColor = Gray;
                e.Item.Font = RegularFont;
            }
        }

        private void olvAllCars_FormatCell(object sender, FormatCellEventArgs e)
        {
            Car c = (Car)e.Model;
            if ((e.Column == colModel) || (e.Column == colPhysics))
            {
                if ((bool)e.CellValue)
                {
                    e.SubItem.Font = BoldFont;
                    e.SubItem.ForeColor = Green;
                    e.SubItem.Text = "found";
                    e.SubItem.Url = null;
                }
                else
                {
                    e.SubItem.Text = "download";
                    if (e.Column == colModel)
                        if (c.link_model != null) e.SubItem.Url = c.link_model;
                        else e.SubItem.Url = "http://www.ly-racing.de/viewtopic.php?t=7878";
                    if (e.Column == colPhysics)
                        e.SubItem.Url = c.link_physics;
                }
            }
            if (e.Column == colAction)
            {
                if (c.model_exists && c.physics_exists) e.SubItem.Text = " "; //enable the button
                else e.SubItem.Text = null; //disable the button
            }
        }

        private void olvAllCars_DoubleClick(object sender, EventArgs e)
        {
            Car c = (Car)olvAllCars.SelectedObject;
            int slot = olvInstalledCars.SelectedIndex;
            AddCar(c, slot);
        }

        private void olvAllCars_ButtonClick(object sender, CellClickEventArgs e)
        {
            if (e.Column == colAction)
            {
                if (e.SubItem.Text == "")
                {
                    olvAllCars.SelectedIndex = e.RowIndex;
                    return;
                }
                Car c = (Car)e.Model;
                int slot = olvInstalledCars.SelectedIndex;
                AddCar(c, slot);
            }
        }

        private void olvAllCars_HyperlinkClicked(object sender, HyperlinkClickedEventArgs e)
        {
            Car c = (Car)e.Model;
            if (e.Column == colModel)
            {
                rbrcit.DownloadCarModel(c);
            }
            else if (e.Column == colPhysics)
            {
                rbrcit.DownloadCarPhysics(c);
            }
            e.Handled = true;
        }

        private void olvAllCars_BeforeCreatingGroups(object sender, CreateGroupsEventArgs e)
        {
            if (e.Parameters.PrimarySort != colName)
            {
                e.Parameters.ItemComparer = new ColumnComparer(colManufacturer, SortOrder.Ascending, colName, SortOrder.Ascending);
            }
        }

        private void olvAllCars_CellToolTipShowing(object sender, ToolTipShowingEventArgs e)
        {
            if (e.Column == colModel || e.Column == colPhysics) return;
            Car c = (Car)e.Model;
            e.Title = c.manufacturer + " " + c.name;
            e.Text = "Category: " + c.cat;
            e.Text += "\nTrans: " + c.trans;
            e.Text += "\nYear: " + c.year;
            e.Text += "\nPower: " + c.power + " HP";
            e.Text += "\nWeight: " + c.weight + " kg";
            e.Text += "\n\nModel Folder: " + c.folder;
            e.Text += "\nPhysics Folder: " + c.physics;
        }

        private void olvAllCars_CellRightClick(object sender, CellRightClickEventArgs e)
        {
            if (e.Model == null)
            {
                e.MenuStrip = contextMenuStrip1;
            }
            else
            {
                contextMenuStrip2.Tag = (Car)e.Model;
                e.MenuStrip = contextMenuStrip2;
            }
        }

        private void olvInstalledCars_FormatRow(object sender, FormatRowEventArgs e)
        {
            if (!rbrcit.DesiredCarList[e.RowIndex].Equals(rbrcit.CurrentCarList[e.RowIndex]))
            {
                e.Item.ForeColor = Color.Black;
                e.Item.Font = BoldFont;
            }
            else
            {
                e.Item.ForeColor = Gray;
                e.Item.Font = RegularFont;
            }
        }

        private void olvInstalledCars_FormatCell(object sender, FormatCellEventArgs e)
        {
            if (e.Column == col2Remove)
            {
                if (rbrcit.DesiredCarList[e.RowIndex].nr != rbrcit.CurrentCarList[e.RowIndex].nr) e.SubItem.Text = " "; //enable the remove button
                else e.SubItem.Text = null; //disable the remove button
            }
            if (e.Column == col2Settings)
            {
                e.SubItem.Text = " ";
            }
        }

        private void olvInstalledCars_DoubleClick(object sender, EventArgs e)
        {
            int i = olvInstalledCars.SelectedIndex;
            RemoveCar(i);
        }

        private void olvInstalledCars_ButtonClick(object sender, CellClickEventArgs e)
        {
            if (e.Column == col2Remove)
            {
                if (e.SubItem.Text == "")
                {
                    olvInstalledCars.SelectedIndex = e.RowIndex;
                    return;
                }
                RemoveCar(e.RowIndex);
            }
            if (e.Column == col2Settings)
            {
                Car c = (Car)e.Model;

                if (c.nr == null)
                {
                    MessageBox.Show("This car is not known in the carList.ini.\nTherefore you cannot change anything on it.");
                    return;
                }

                FormCarSettings fcs = new FormCarSettings();
                fcs.CurrentCar = c;
                fcs.UseAudio = rbrcit.UseAudio;
                if (fcs.ShowDialog(this) == DialogResult.OK)
                {
                    rbrcit.DesiredCarList[e.RowIndex] = fcs.CurrentCar;
                    olvInstalledCars.SetObjects(rbrcit.DesiredCarList);
                    UpdateApplyButton();
                }
            }
        }

        private void olvInstalledCars_CellOver(object sender, CellOverEventArgs e)
        {
            if (e.RowIndex < 0) return; //disable on header
            if (e.Column == col2Sound) olvInstalledCars.Cursor = Cursors.Hand;
            else olvInstalledCars.Cursor = Cursors.Default;
        }

        private void olvInstalledCars_CellClick(object sender, CellClickEventArgs e)
        {
            if (e.Column == col2Sound)
            {
                if (!rbrcit.UseAudio)
                {
                    MessageBox.Show("Changing engine sounds is disabled. Please extract the " +
                        "audio.dat file using the menu 'Tools' -> 'Extract audio.dat'.");
                    return;
                }
                Car c = (Car)e.Model;
                if (c.nr == null)
                {
                    MessageBox.Show("This car is not known in the carList.ini." +
                        "\nTherefore you cannot change anything on it.");
                    return;
                }
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Title = "Choose engine sound for: " + c.manufacturer + " " + c.name;
                ofd.Filter = "Engine files(*.eng) | *.eng";
                ofd.InitialDirectory = Application.StartupPath + "\\Audio\\Cars";
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    FileInfo fi = new FileInfo(ofd.FileName);
                    c.userSettings.engineSound = fi.Name.Replace(fi.Extension, "");
                    rbrcit.DesiredCarList[e.RowIndex] = c;
                    olvInstalledCars.SetObjects(rbrcit.DesiredCarList);
                    UpdateApplyButton();
                }
            }
        }
        private void btSaveList_Click(object sender, EventArgs e)
        {
            FormSaveList fsl = new FormSaveList();
            if (fsl.ShowDialog(this) == DialogResult.OK)
            {
                rbrcit.SaveCarList(fsl.ListName);
            }
        }

        private void LoadCarList_Click(object sender, EventArgs e)
        {
            ToolStripItem tsi = sender as ToolStripItem;
            rbrcit.LoadCarList(tsi.Text);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            showGroupsToolStripMenuItem.Checked = olvAllCars.ShowGroups;
        }

        private void collapseAllGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            olvAllCars.CollapsedGroups = olvAllCars.OLVGroups;
        }

        private void uncollapseAllGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            olvAllCars.CollapsedGroups = null;
        }

        private void showGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showGroupsToolStripMenuItem.Checked = !showGroupsToolStripMenuItem.Checked;
            olvAllCars.ShowGroups = showGroupsToolStripMenuItem.Checked;
            if (olvAllCars.ShowGroups) olvAllCars.BuildGroups(olvAllCars.LastSortColumn, olvAllCars.LastSortOrder);
            else olvAllCars.Sort(olvAllCars.LastSortColumn, olvAllCars.LastSortOrder);
        }

        private void btApply_Click(object sender, EventArgs e)
        {
            btApply.Enabled = false;
            rbrcit.ApplyChanges(cbReplaceShoolFiles.Checked, false);
            UpdateApplyButton();
            MessageBox.Show("Cars have been installed.");
        }
        private void btStartGame(object sender, EventArgs e)
        {
            if (btApply.Enabled)
            {
                DialogResult dr = MessageBox.Show("There are changed cars that have not been applied to the game yet. " +
                    "Are you sure you want to start the game?", "Sure to start?", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) return;
            }

            ProcessStartInfo psi = new ProcessStartInfo();
            //psi.WorkingDirectory = fi.DirectoryName;
            psi.FileName = "RichardBurnsRally_SSE.exe";
            psi.CreateNoWindow = true;
            Process myProcess = Process.Start(psi);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWindowState();
        }

        private void SaveWindowState()
        {
            string filename = Path.Combine(Directory.GetParent(Application.LocalUserAppDataPath).FullName, "windowstate.txt");
            StreamWriter sw = new StreamWriter(filename);
            sw.WriteLine(WindowStateFileVersion);
            sw.WriteLine(Location.X + ";" + Location.Y);
            sw.WriteLine(Size.Width + ";" + Size.Height);
            sw.WriteLine(mySplitContainer1.SplitterDistance);
            sw.WriteLine(Convert.ToBase64String(olvAllCars.SaveState()));
            sw.WriteLine(Convert.ToBase64String(olvInstalledCars.SaveState()));
            sw.Close();
        }

        private void LoadWindowState()
        {
            try
            {
                string filename = Path.Combine(Directory.GetParent(Application.LocalUserAppDataPath).FullName, "windowstate.txt");
                if (!File.Exists(filename)) return;
                StreamReader sr = new StreamReader(filename);
                int version = int.Parse(sr.ReadLine());
                if (version != WindowStateFileVersion) return;
                string[] coords = sr.ReadLine().Split(';');
                Location = new Point(int.Parse(coords[0]), int.Parse(coords[1]));
                coords = sr.ReadLine().Split(';');
                Size = new Size(int.Parse(coords[0]), int.Parse(coords[1]));
                mySplitContainer1.SplitterDistance = int.Parse(sr.ReadLine());
                olvAllCars.RestoreState(Convert.FromBase64String(sr.ReadLine()));
                olvAllCars.RebuildColumns();
                olvInstalledCars.RestoreState(Convert.FromBase64String(sr.ReadLine()));
                olvInstalledCars.RebuildColumns();
                sr.Close();
            }
            catch (Exception e)
            {
            }
        }
        private void btNGPDownload_Click(object sender, EventArgs e)
        {
            btNGP.Enabled = false;
            rbrcit.DownloadPluginNGP();
        }

        private void btNGPConfigure_Click(object sender, EventArgs e)
        {
            Process.Start("RichardBurnsRally.ini");
        }

        private void btFixupDownload_Click(object sender, EventArgs e)
        {
            btFixup.Enabled = false;
            rbrcit.DownloadPluginFixUp();
        }

        private void btFixupConfigure_Click(object sender, EventArgs e)
        {
            string filename = "Plugins\\FixUP.ini";
            if (File.Exists(filename)) Process.Start(filename);
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void MenuReload_Click(object sender, EventArgs e)
        {
            rbrcit.LoadAll();
        }

        private void toolsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            MenuExtractAudioDat.Enabled = !rbrcit.UseAudio;
            MenuRestore.Enabled = Directory.Exists("RBRCIT\\backup");
        }

        private void MenuUpdateCarList_Click(object sender, EventArgs e)
        {
            rbrcit.DownloadCarListINI();
        }

        private void MenuDownloadMissingPhysics_Click(object sender, EventArgs e)
        {
            rbrcit.DownloadMissingPhysics();
        }

        private void MenuUpdateAllExistingPhysics_Click(object sender, EventArgs e)
        {
            rbrcit.UpdateAllExistingPhysics();
        }

        private void MenuExtractAudioDat_Click(object sender, EventArgs e)
        {
            rbrcit.ExtractAudioDAT();
        }

        private void MenuRestoreOriginalRBRCars_Click(object sender, EventArgs e)
        {
            rbrcit.RestoreOriginalRBRCars();
            MessageBox.Show("Original cars restored.");
        }

        private void MenuManageSavedCarLists_Click(object sender, EventArgs e)
        {
            Process.Start("RBRCIT\\savedlists");
        }

        private void updateModelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Car c = (Car)contextMenuStrip2.Tag;
            rbrcit.DownloadCarModel(c);
        }

        private void updatePhysicsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Car c = (Car)contextMenuStrip2.Tag;
            rbrcit.DownloadCarPhysics(c);
        }
        private void MenuBackup_Click(object sender, EventArgs e)
        {
            rbrcit.Backup();
            MessageBox.Show("Backup created.");
        }

        private void MenuRestore_Click(object sender, EventArgs e)
        {
            rbrcit.Restore();
            MessageBox.Show("Backup resttored.");
        }

        private void MenuAbout_Click(object sender, EventArgs e)
        {
            FormAbout fa = new FormAbout(rbrcit.GetRBRCITVersion());
            fa.ShowAtCenterParent(this);
        }
    }
}
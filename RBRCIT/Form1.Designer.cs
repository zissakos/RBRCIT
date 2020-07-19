namespace RBRCIT
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            BrightIdeasSoftware.CellStyle cellStyle1 = new BrightIdeasSoftware.CellStyle();
            BrightIdeasSoftware.CellStyle cellStyle2 = new BrightIdeasSoftware.CellStyle();
            BrightIdeasSoftware.CellStyle cellStyle3 = new BrightIdeasSoftware.CellStyle();
            this.contextMenuStripGroups = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.collapseAllGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uncollapseAllGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuReload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExtractAudioDat = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuRestoreOriginalRBRCars = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuRestore = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUpdateCarList = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuDownloadMissingPhysics = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuUpdateAllExistingPhysics = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.downloadMissingSoundBanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateExistingSoundBanksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.updateRBRCITToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList24 = new System.Windows.Forms.ImageList(this.components);
            this.hyperlinkStyle1 = new BrightIdeasSoftware.HyperlinkStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.contextLoadList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.contextLoadListManage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuManageSavedCarLists = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripCar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.updateModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updatePhysicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateSoundBankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuFMODSoundBank = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSoundBankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mySplitContainer1 = new ZissisControls.MySplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.olvAllCars = new BrightIdeasSoftware.ObjectListView();
            this.colCategory = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colManufacturer = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colName = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colTrans = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colYear = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colHP = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colWeight = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colModel = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colPhysics = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colFMODSoundBank = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.colAction = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.myButtonRendererAdd = new RBRCIT.MyButtonRenderer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btFMOD = new System.Windows.Forms.Button();
            this.lblFMODVersion = new System.Windows.Forms.Label();
            this.btFMODConfigure = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.btFmodEnable = new System.Windows.Forms.Button();
            this.btFmodDisable = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.lblFMODStatus = new System.Windows.Forms.Label();
            this.cbReplaceShoolFiles = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btLoadList = new RBRCIT.MenuButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btFixupConfigure = new System.Windows.Forms.Button();
            this.btFixup = new System.Windows.Forms.Button();
            this.btNGPConfigure = new System.Windows.Forms.Button();
            this.btNGP = new System.Windows.Forms.Button();
            this.lblFixup = new System.Windows.Forms.Label();
            this.lblFixUpDate = new System.Windows.Forms.Label();
            this.lblNGPDate = new System.Windows.Forms.Label();
            this.lblNGP = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btSaveList = new System.Windows.Forms.Button();
            this.olvInstalledCars = new BrightIdeasSoftware.ObjectListView();
            this.col2Remove = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.myButtonRendererRemove = new RBRCIT.MyButtonRenderer();
            this.col2Category = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.col2Manufacturer = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.col2Name = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.col2Trans = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.col2Sound = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.col2FMODSoundBank = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.col2Settings = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.myButtonRendererSettings = new RBRCIT.MyButtonRenderer();
            this.button1 = new System.Windows.Forms.Button();
            this.btApply = new System.Windows.Forms.Button();
            this.contextMenuStripGroups.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.contextLoadListManage.SuspendLayout();
            this.contextMenuStripCar.SuspendLayout();
            this.contextMenuFMODSoundBank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mySplitContainer1)).BeginInit();
            this.mySplitContainer1.Panel1.SuspendLayout();
            this.mySplitContainer1.Panel2.SuspendLayout();
            this.mySplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvAllCars)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvInstalledCars)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStripGroups
            // 
            this.contextMenuStripGroups.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.collapseAllGroupsToolStripMenuItem,
            this.uncollapseAllGroupsToolStripMenuItem,
            this.toolStripSeparator1,
            this.showGroupsToolStripMenuItem});
            this.contextMenuStripGroups.Name = "contextMenuStrip1";
            this.contextMenuStripGroups.Size = new System.Drawing.Size(191, 76);
            this.contextMenuStripGroups.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // collapseAllGroupsToolStripMenuItem
            // 
            this.collapseAllGroupsToolStripMenuItem.Name = "collapseAllGroupsToolStripMenuItem";
            this.collapseAllGroupsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.collapseAllGroupsToolStripMenuItem.Text = "Collapse All Groups";
            this.collapseAllGroupsToolStripMenuItem.Click += new System.EventHandler(this.collapseAllGroupsToolStripMenuItem_Click);
            // 
            // uncollapseAllGroupsToolStripMenuItem
            // 
            this.uncollapseAllGroupsToolStripMenuItem.Name = "uncollapseAllGroupsToolStripMenuItem";
            this.uncollapseAllGroupsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.uncollapseAllGroupsToolStripMenuItem.Text = "Uncollapse All Groups";
            this.uncollapseAllGroupsToolStripMenuItem.Click += new System.EventHandler(this.uncollapseAllGroupsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // showGroupsToolStripMenuItem
            // 
            this.showGroupsToolStripMenuItem.Checked = true;
            this.showGroupsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.showGroupsToolStripMenuItem.Name = "showGroupsToolStripMenuItem";
            this.showGroupsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.showGroupsToolStripMenuItem.Text = "Show Groups";
            this.showGroupsToolStripMenuItem.Click += new System.EventHandler(this.showGroupsToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1284, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(93, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuReload});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // MenuReload
            // 
            this.MenuReload.Name = "MenuReload";
            this.MenuReload.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.MenuReload.Size = new System.Drawing.Size(129, 22);
            this.MenuReload.Text = "Reload";
            this.MenuReload.Click += new System.EventHandler(this.MenuReload_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuExtractAudioDat,
            this.toolStripSeparator4,
            this.MenuRestoreOriginalRBRCars,
            this.toolStripSeparator2,
            this.MenuBackup,
            this.MenuRestore});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            this.toolsToolStripMenuItem.DropDownOpening += new System.EventHandler(this.toolsToolStripMenuItem_DropDownOpening);
            // 
            // MenuExtractAudioDat
            // 
            this.MenuExtractAudioDat.Name = "MenuExtractAudioDat";
            this.MenuExtractAudioDat.Size = new System.Drawing.Size(208, 22);
            this.MenuExtractAudioDat.Text = "Extract audio.dat";
            this.MenuExtractAudioDat.Click += new System.EventHandler(this.MenuExtractAudioDat_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(205, 6);
            // 
            // MenuRestoreOriginalRBRCars
            // 
            this.MenuRestoreOriginalRBRCars.Name = "MenuRestoreOriginalRBRCars";
            this.MenuRestoreOriginalRBRCars.Size = new System.Drawing.Size(208, 22);
            this.MenuRestoreOriginalRBRCars.Text = "Restore Original RBR Cars";
            this.MenuRestoreOriginalRBRCars.Click += new System.EventHandler(this.MenuRestoreOriginalRBRCars_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(205, 6);
            // 
            // MenuBackup
            // 
            this.MenuBackup.Name = "MenuBackup";
            this.MenuBackup.Size = new System.Drawing.Size(208, 22);
            this.MenuBackup.Text = "Backup";
            this.MenuBackup.Click += new System.EventHandler(this.MenuBackup_Click);
            // 
            // MenuRestore
            // 
            this.MenuRestore.Name = "MenuRestore";
            this.MenuRestore.Size = new System.Drawing.Size(208, 22);
            this.MenuRestore.Text = "Restore";
            this.MenuRestore.Click += new System.EventHandler(this.MenuRestore_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuUpdateCarList,
            this.toolStripSeparator6,
            this.MenuDownloadMissingPhysics,
            this.MenuUpdateAllExistingPhysics,
            this.toolStripSeparator3,
            this.downloadMissingSoundBanksToolStripMenuItem,
            this.updateExistingSoundBanksToolStripMenuItem,
            this.toolStripSeparator7,
            this.updateRBRCITToolStripMenuItem});
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.downloadToolStripMenuItem.Text = "Download";
            // 
            // MenuUpdateCarList
            // 
            this.MenuUpdateCarList.Name = "MenuUpdateCarList";
            this.MenuUpdateCarList.Size = new System.Drawing.Size(240, 22);
            this.MenuUpdateCarList.Text = "Update carList.ini";
            this.MenuUpdateCarList.Click += new System.EventHandler(this.MenuUpdateCarList_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(237, 6);
            // 
            // MenuDownloadMissingPhysics
            // 
            this.MenuDownloadMissingPhysics.Name = "MenuDownloadMissingPhysics";
            this.MenuDownloadMissingPhysics.Size = new System.Drawing.Size(240, 22);
            this.MenuDownloadMissingPhysics.Text = "Download Missing Physics";
            this.MenuDownloadMissingPhysics.Click += new System.EventHandler(this.MenuDownloadMissingPhysics_Click);
            // 
            // MenuUpdateAllExistingPhysics
            // 
            this.MenuUpdateAllExistingPhysics.Name = "MenuUpdateAllExistingPhysics";
            this.MenuUpdateAllExistingPhysics.Size = new System.Drawing.Size(240, 22);
            this.MenuUpdateAllExistingPhysics.Text = "Update All Existing Physics";
            this.MenuUpdateAllExistingPhysics.Click += new System.EventHandler(this.MenuUpdateAllExistingPhysics_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(237, 6);
            // 
            // downloadMissingSoundBanksToolStripMenuItem
            // 
            this.downloadMissingSoundBanksToolStripMenuItem.Name = "downloadMissingSoundBanksToolStripMenuItem";
            this.downloadMissingSoundBanksToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.downloadMissingSoundBanksToolStripMenuItem.Text = "Download Missing SoundBanks";
            this.downloadMissingSoundBanksToolStripMenuItem.Click += new System.EventHandler(this.MenuDownloadMissingSoundBanks_Click);
            // 
            // updateExistingSoundBanksToolStripMenuItem
            // 
            this.updateExistingSoundBanksToolStripMenuItem.Name = "updateExistingSoundBanksToolStripMenuItem";
            this.updateExistingSoundBanksToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.updateExistingSoundBanksToolStripMenuItem.Text = "Update Existing SoundBanks";
            this.updateExistingSoundBanksToolStripMenuItem.Click += new System.EventHandler(this.UpdateExistingSoundBanksToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(237, 6);
            // 
            // updateRBRCITToolStripMenuItem
            // 
            this.updateRBRCITToolStripMenuItem.Name = "updateRBRCITToolStripMenuItem";
            this.updateRBRCITToolStripMenuItem.Size = new System.Drawing.Size(240, 22);
            this.updateRBRCITToolStripMenuItem.Text = "Update RBRCIT";
            this.updateRBRCITToolStripMenuItem.Click += new System.EventHandler(this.UpdateRBRCITToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.MenuAbout_Click);
            // 
            // imageList24
            // 
            this.imageList24.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList24.ImageStream")));
            this.imageList24.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList24.Images.SetKeyName(0, "tool.png");
            // 
            // hyperlinkStyle1
            // 
            cellStyle1.Font = null;
            cellStyle1.FontStyle = System.Drawing.FontStyle.Underline;
            cellStyle1.ForeColor = System.Drawing.Color.Blue;
            this.hyperlinkStyle1.Normal = cellStyle1;
            cellStyle2.Font = null;
            cellStyle2.FontStyle = System.Drawing.FontStyle.Underline;
            this.hyperlinkStyle1.Over = cellStyle2;
            this.hyperlinkStyle1.OverCursor = System.Windows.Forms.Cursors.Hand;
            cellStyle3.Font = null;
            cellStyle3.ForeColor = System.Drawing.Color.Blue;
            this.hyperlinkStyle1.Visited = cellStyle3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.AllowMerge = false;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabel4});
            this.statusStrip1.Location = new System.Drawing.Point(0, 684);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1284, 27);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(128, 21);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel2.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(128, 21);
            this.toolStripStatusLabel2.Text = "toolStripStatusLabel2";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel3.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel3.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(128, 21);
            this.toolStripStatusLabel3.Text = "toolStripStatusLabel3";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabel4.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabel4.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Padding = new System.Windows.Forms.Padding(3, 1, 3, 1);
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(128, 21);
            this.toolStripStatusLabel4.Text = "toolStripStatusLabel4";
            // 
            // imageList16
            // 
            this.imageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16.ImageStream")));
            this.imageList16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16.Images.SetKeyName(0, "left-arrow.png");
            this.imageList16.Images.SetKeyName(1, "right-arrow.png");
            // 
            // contextLoadList
            // 
            this.contextLoadList.Name = "contextLoadList";
            this.contextLoadList.Size = new System.Drawing.Size(61, 4);
            // 
            // contextLoadListManage
            // 
            this.contextLoadListManage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator5,
            this.MenuManageSavedCarLists});
            this.contextLoadListManage.Name = "contextLoadListManage";
            this.contextLoadListManage.Size = new System.Drawing.Size(199, 32);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(195, 6);
            // 
            // MenuManageSavedCarLists
            // 
            this.MenuManageSavedCarLists.Name = "MenuManageSavedCarLists";
            this.MenuManageSavedCarLists.Size = new System.Drawing.Size(198, 22);
            this.MenuManageSavedCarLists.Text = "Manage Saved Car Lists";
            this.MenuManageSavedCarLists.Click += new System.EventHandler(this.MenuManageSavedCarLists_Click);
            // 
            // contextMenuStripCar
            // 
            this.contextMenuStripCar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateModelToolStripMenuItem,
            this.updatePhysicsToolStripMenuItem,
            this.updateSoundBankToolStripMenuItem});
            this.contextMenuStripCar.Name = "contextMenuStrip2";
            this.contextMenuStripCar.Size = new System.Drawing.Size(176, 70);
            this.contextMenuStripCar.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStripCar_Opening);
            // 
            // updateModelToolStripMenuItem
            // 
            this.updateModelToolStripMenuItem.Name = "updateModelToolStripMenuItem";
            this.updateModelToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.updateModelToolStripMenuItem.Text = "Update Model";
            this.updateModelToolStripMenuItem.Click += new System.EventHandler(this.updateModelToolStripMenuItem_Click);
            // 
            // updatePhysicsToolStripMenuItem
            // 
            this.updatePhysicsToolStripMenuItem.Name = "updatePhysicsToolStripMenuItem";
            this.updatePhysicsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.updatePhysicsToolStripMenuItem.Text = "Update Physics";
            this.updatePhysicsToolStripMenuItem.Click += new System.EventHandler(this.updatePhysicsToolStripMenuItem_Click);
            // 
            // updateSoundBankToolStripMenuItem
            // 
            this.updateSoundBankToolStripMenuItem.Name = "updateSoundBankToolStripMenuItem";
            this.updateSoundBankToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.updateSoundBankToolStripMenuItem.Text = "Update SoundBank";
            this.updateSoundBankToolStripMenuItem.Click += new System.EventHandler(this.UpdateSoundBankToolStripMenuItem_Click);
            // 
            // contextMenuFMODSoundBank
            // 
            this.contextMenuFMODSoundBank.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSoundBankToolStripMenuItem});
            this.contextMenuFMODSoundBank.Name = "contextMenuFMODSoundBank";
            this.contextMenuFMODSoundBank.Size = new System.Drawing.Size(184, 26);
            // 
            // removeSoundBankToolStripMenuItem
            // 
            this.removeSoundBankToolStripMenuItem.Name = "removeSoundBankToolStripMenuItem";
            this.removeSoundBankToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.removeSoundBankToolStripMenuItem.Text = "Remove Sound Bank";
            this.removeSoundBankToolStripMenuItem.Click += new System.EventHandler(this.RemoveSoundBankToolStripMenuItem_Click);
            // 
            // mySplitContainer1
            // 
            this.mySplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mySplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.mySplitContainer1.Location = new System.Drawing.Point(0, 24);
            this.mySplitContainer1.Name = "mySplitContainer1";
            // 
            // mySplitContainer1.Panel1
            // 
            this.mySplitContainer1.Panel1.Controls.Add(this.label1);
            this.mySplitContainer1.Panel1.Controls.Add(this.olvAllCars);
            this.mySplitContainer1.Panel1MinSize = 300;
            // 
            // mySplitContainer1.Panel2
            // 
            this.mySplitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.mySplitContainer1.Panel2.Controls.Add(this.cbReplaceShoolFiles);
            this.mySplitContainer1.Panel2.Controls.Add(this.label12);
            this.mySplitContainer1.Panel2.Controls.Add(this.label11);
            this.mySplitContainer1.Panel2.Controls.Add(this.label10);
            this.mySplitContainer1.Panel2.Controls.Add(this.label9);
            this.mySplitContainer1.Panel2.Controls.Add(this.label8);
            this.mySplitContainer1.Panel2.Controls.Add(this.label7);
            this.mySplitContainer1.Panel2.Controls.Add(this.label5);
            this.mySplitContainer1.Panel2.Controls.Add(this.label3);
            this.mySplitContainer1.Panel2.Controls.Add(this.btLoadList);
            this.mySplitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.mySplitContainer1.Panel2.Controls.Add(this.label2);
            this.mySplitContainer1.Panel2.Controls.Add(this.btSaveList);
            this.mySplitContainer1.Panel2.Controls.Add(this.olvInstalledCars);
            this.mySplitContainer1.Panel2.Controls.Add(this.button1);
            this.mySplitContainer1.Panel2.Controls.Add(this.btApply);
            this.mySplitContainer1.Panel2MinSize = 650;
            this.mySplitContainer1.Size = new System.Drawing.Size(1284, 660);
            this.mySplitContainer1.SplitterDistance = 522;
            this.mySplitContainer1.SplitterWidth = 8;
            this.mySplitContainer1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "All Cars:";
            // 
            // olvAllCars
            // 
            this.olvAllCars.AllColumns.Add(this.colCategory);
            this.olvAllCars.AllColumns.Add(this.colManufacturer);
            this.olvAllCars.AllColumns.Add(this.colName);
            this.olvAllCars.AllColumns.Add(this.colTrans);
            this.olvAllCars.AllColumns.Add(this.colYear);
            this.olvAllCars.AllColumns.Add(this.colHP);
            this.olvAllCars.AllColumns.Add(this.colWeight);
            this.olvAllCars.AllColumns.Add(this.colModel);
            this.olvAllCars.AllColumns.Add(this.colPhysics);
            this.olvAllCars.AllColumns.Add(this.colFMODSoundBank);
            this.olvAllCars.AllColumns.Add(this.colAction);
            this.olvAllCars.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvAllCars.CellEditUseWholeCell = false;
            this.olvAllCars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCategory,
            this.colManufacturer,
            this.colName,
            this.colTrans,
            this.colYear,
            this.colHP,
            this.colWeight,
            this.colModel,
            this.colPhysics,
            this.colFMODSoundBank,
            this.colAction});
            this.olvAllCars.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvAllCars.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvAllCars.FullRowSelect = true;
            this.olvAllCars.GridLines = true;
            this.olvAllCars.GroupWithItemCountFormat = "{0} [{1} cars]";
            this.olvAllCars.GroupWithItemCountSingularFormat = "{0} [{1} car]";
            this.olvAllCars.HeaderMinimumHeight = 30;
            this.olvAllCars.HideSelection = false;
            this.olvAllCars.HyperlinkStyle = this.hyperlinkStyle1;
            this.olvAllCars.Location = new System.Drawing.Point(15, 25);
            this.olvAllCars.MultiSelect = false;
            this.olvAllCars.Name = "olvAllCars";
            this.olvAllCars.RowHeight = 21;
            this.olvAllCars.ShowCommandMenuOnRightClick = true;
            this.olvAllCars.ShowFilterMenuOnRightClick = false;
            this.olvAllCars.ShowItemCountOnGroups = true;
            this.olvAllCars.Size = new System.Drawing.Size(504, 622);
            this.olvAllCars.SpaceBetweenGroups = 16;
            this.olvAllCars.TabIndex = 0;
            this.olvAllCars.UseCellFormatEvents = true;
            this.olvAllCars.UseCompatibleStateImageBehavior = false;
            this.olvAllCars.UseHotItem = true;
            this.olvAllCars.UseHyperlinks = true;
            this.olvAllCars.View = System.Windows.Forms.View.Details;
            this.olvAllCars.BeforeCreatingGroups += new System.EventHandler<BrightIdeasSoftware.CreateGroupsEventArgs>(this.olvAllCars_BeforeCreatingGroups);
            this.olvAllCars.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvAllCars_ButtonClick);
            this.olvAllCars.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.olvAllCars_CellRightClick);
            this.olvAllCars.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.olvAllCars_CellToolTipShowing);
            this.olvAllCars.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.olvAllCars_FormatCell);
            this.olvAllCars.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvAllCars_FormatRow);
            this.olvAllCars.HyperlinkClicked += new System.EventHandler<BrightIdeasSoftware.HyperlinkClickedEventArgs>(this.olvAllCars_HyperlinkClicked);
            this.olvAllCars.DoubleClick += new System.EventHandler(this.olvAllCars_DoubleClick);
            // 
            // colCategory
            // 
            this.colCategory.AspectName = "cat";
            this.colCategory.Text = "Category";
            this.colCategory.Width = 80;
            // 
            // colManufacturer
            // 
            this.colManufacturer.AspectName = "manufacturer";
            this.colManufacturer.Text = "Manufacturer";
            this.colManufacturer.Width = 109;
            // 
            // colName
            // 
            this.colName.AspectName = "name";
            this.colName.Text = "Name";
            this.colName.Width = 25;
            // 
            // colTrans
            // 
            this.colTrans.AspectName = "trans";
            this.colTrans.Text = "Trans";
            this.colTrans.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colYear
            // 
            this.colYear.AspectName = "year";
            this.colYear.Text = "Year";
            this.colYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // colHP
            // 
            this.colHP.AspectName = "power";
            this.colHP.AspectToStringFormat = "{0} HP";
            this.colHP.Text = "Power";
            this.colHP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colWeight
            // 
            this.colWeight.AspectName = "weight";
            this.colWeight.AspectToStringFormat = "{0} kg";
            this.colWeight.MinimumWidth = 60;
            this.colWeight.Text = "Weight";
            this.colWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colModel
            // 
            this.colModel.AspectName = "model_exists";
            this.colModel.Hyperlink = true;
            this.colModel.Text = "Model";
            this.colModel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colModel.Width = 65;
            // 
            // colPhysics
            // 
            this.colPhysics.AspectName = "physics_exists";
            this.colPhysics.Hyperlink = true;
            this.colPhysics.Text = "Physics";
            this.colPhysics.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colPhysics.Width = 65;
            // 
            // colFMODSoundBank
            // 
            this.colFMODSoundBank.AspectName = "banks_exist";
            this.colFMODSoundBank.Hyperlink = true;
            this.colFMODSoundBank.Text = "SoundBank";
            this.colFMODSoundBank.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colFMODSoundBank.Width = 65;
            // 
            // colAction
            // 
            this.colAction.AspectName = "cat";
            this.colAction.AspectToStringFormat = "";
            this.colAction.ButtonPadding = new System.Drawing.Size(0, 0);
            this.colAction.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            this.colAction.Hideable = false;
            this.colAction.IsButton = true;
            this.colAction.IsEditable = false;
            this.colAction.MaximumWidth = 40;
            this.colAction.MinimumWidth = 40;
            this.colAction.Renderer = this.myButtonRendererAdd;
            this.colAction.Text = "";
            this.colAction.Width = 40;
            // 
            // myButtonRendererAdd
            // 
            this.myButtonRendererAdd.ButtonPadding = new System.Drawing.Size(0, 0);
            this.myButtonRendererAdd.ImageIndex = 1;
            this.myButtonRendererAdd.ImageList = this.imageList16;
            this.myButtonRendererAdd.SizingMode = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btFMOD);
            this.groupBox2.Controls.Add(this.lblFMODVersion);
            this.groupBox2.Controls.Add(this.btFMODConfigure);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.btFmodEnable);
            this.groupBox2.Controls.Add(this.btFmodDisable);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblFMODStatus);
            this.groupBox2.Location = new System.Drawing.Point(18, 464);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(708, 100);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "FMOD Sound System";
            // 
            // btFMOD
            // 
            this.btFMOD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFMOD.Enabled = false;
            this.btFMOD.Location = new System.Drawing.Point(617, 58);
            this.btFMOD.Name = "btFMOD";
            this.btFMOD.Size = new System.Drawing.Size(80, 23);
            this.btFMOD.TabIndex = 2;
            this.btFMOD.Text = "Update";
            this.btFMOD.UseVisualStyleBackColor = true;
            this.btFMOD.Click += new System.EventHandler(this.BtFMOD_Click);
            // 
            // lblFMODVersion
            // 
            this.lblFMODVersion.Location = new System.Drawing.Point(126, 63);
            this.lblFMODVersion.Name = "lblFMODVersion";
            this.lblFMODVersion.Size = new System.Drawing.Size(372, 31);
            this.lblFMODVersion.TabIndex = 0;
            this.lblFMODVersion.Text = "xxx";
            // 
            // btFMODConfigure
            // 
            this.btFMODConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFMODConfigure.Enabled = false;
            this.btFMODConfigure.Location = new System.Drawing.Point(617, 26);
            this.btFMODConfigure.Name = "btFMODConfigure";
            this.btFMODConfigure.Size = new System.Drawing.Size(80, 23);
            this.btFMODConfigure.TabIndex = 2;
            this.btFMODConfigure.Text = "Configure";
            this.btFMODConfigure.UseVisualStyleBackColor = true;
            this.btFMODConfigure.Click += new System.EventHandler(this.BtFMODConfigure_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 63);
            this.label13.MaximumSize = new System.Drawing.Size(260, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(114, 13);
            this.label13.TabIndex = 0;
            this.label13.Text = "AudioFMOD (optional):";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btFmodEnable
            // 
            this.btFmodEnable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFmodEnable.Enabled = false;
            this.btFmodEnable.Location = new System.Drawing.Point(444, 26);
            this.btFmodEnable.Name = "btFmodEnable";
            this.btFmodEnable.Size = new System.Drawing.Size(80, 23);
            this.btFmodEnable.TabIndex = 2;
            this.btFmodEnable.Text = "Enable";
            this.btFmodEnable.UseVisualStyleBackColor = true;
            this.btFmodEnable.Click += new System.EventHandler(this.BtFmodEnable_Click);
            // 
            // btFmodDisable
            // 
            this.btFmodDisable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFmodDisable.Enabled = false;
            this.btFmodDisable.Location = new System.Drawing.Point(530, 26);
            this.btFmodDisable.Name = "btFmodDisable";
            this.btFmodDisable.Size = new System.Drawing.Size(80, 23);
            this.btFmodDisable.TabIndex = 2;
            this.btFmodDisable.Text = "Disable";
            this.btFmodDisable.UseVisualStyleBackColor = true;
            this.btFmodDisable.Click += new System.EventHandler(this.BtFmodDisable_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(80, 31);
            this.label14.MaximumSize = new System.Drawing.Size(260, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 13);
            this.label14.TabIndex = 0;
            this.label14.Text = "Status:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblFMODStatus
            // 
            this.lblFMODStatus.AutoSize = true;
            this.lblFMODStatus.Location = new System.Drawing.Point(126, 31);
            this.lblFMODStatus.MaximumSize = new System.Drawing.Size(260, 0);
            this.lblFMODStatus.Name = "lblFMODStatus";
            this.lblFMODStatus.Size = new System.Drawing.Size(24, 13);
            this.lblFMODStatus.TabIndex = 0;
            this.lblFMODStatus.Text = "text";
            this.lblFMODStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbReplaceShoolFiles
            // 
            this.cbReplaceShoolFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbReplaceShoolFiles.AutoSize = true;
            this.cbReplaceShoolFiles.Location = new System.Drawing.Point(547, 313);
            this.cbReplaceShoolFiles.Name = "cbReplaceShoolFiles";
            this.cbReplaceShoolFiles.Size = new System.Drawing.Size(178, 17);
            this.cbReplaceShoolFiles.TabIndex = 13;
            this.cbReplaceShoolFiles.Text = "Replace School Car files (Slot 5)";
            this.cbReplaceShoolFiles.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 283);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "7";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 252);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 13);
            this.label11.TabIndex = 12;
            this.label11.Text = "6";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 221);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(13, 13);
            this.label10.TabIndex = 12;
            this.label10.Text = "5";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "4";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 159);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(13, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "3";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(13, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(13, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "0";
            // 
            // btLoadList
            // 
            this.btLoadList.Location = new System.Drawing.Point(103, 315);
            this.btLoadList.Menu = this.contextLoadList;
            this.btLoadList.Name = "btLoadList";
            this.btLoadList.Size = new System.Drawing.Size(80, 23);
            this.btLoadList.TabIndex = 11;
            this.btLoadList.Text = "Load List";
            this.btLoadList.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btFixupConfigure);
            this.groupBox1.Controls.Add(this.btFixup);
            this.groupBox1.Controls.Add(this.btNGPConfigure);
            this.groupBox1.Controls.Add(this.btNGP);
            this.groupBox1.Controls.Add(this.lblFixup);
            this.groupBox1.Controls.Add(this.lblFixUpDate);
            this.groupBox1.Controls.Add(this.lblNGPDate);
            this.groupBox1.Controls.Add(this.lblNGP);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(18, 360);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(707, 94);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Plugins";
            // 
            // btFixupConfigure
            // 
            this.btFixupConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFixupConfigure.Location = new System.Drawing.Point(616, 59);
            this.btFixupConfigure.Name = "btFixupConfigure";
            this.btFixupConfigure.Size = new System.Drawing.Size(80, 23);
            this.btFixupConfigure.TabIndex = 3;
            this.btFixupConfigure.Text = "Configure";
            this.btFixupConfigure.UseVisualStyleBackColor = true;
            this.btFixupConfigure.Click += new System.EventHandler(this.btFixupConfigure_Click);
            // 
            // btFixup
            // 
            this.btFixup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btFixup.Location = new System.Drawing.Point(529, 59);
            this.btFixup.Name = "btFixup";
            this.btFixup.Size = new System.Drawing.Size(80, 23);
            this.btFixup.TabIndex = 3;
            this.btFixup.Text = "Update";
            this.btFixup.UseVisualStyleBackColor = true;
            this.btFixup.Click += new System.EventHandler(this.btFixupDownload_Click);
            // 
            // btNGPConfigure
            // 
            this.btNGPConfigure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNGPConfigure.Location = new System.Drawing.Point(616, 28);
            this.btNGPConfigure.Name = "btNGPConfigure";
            this.btNGPConfigure.Size = new System.Drawing.Size(80, 23);
            this.btNGPConfigure.TabIndex = 2;
            this.btNGPConfigure.Text = "Configure";
            this.btNGPConfigure.UseVisualStyleBackColor = true;
            this.btNGPConfigure.Click += new System.EventHandler(this.btNGPConfigure_Click);
            // 
            // btNGP
            // 
            this.btNGP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btNGP.Location = new System.Drawing.Point(529, 28);
            this.btNGP.Name = "btNGP";
            this.btNGP.Size = new System.Drawing.Size(80, 23);
            this.btNGP.TabIndex = 2;
            this.btNGP.Text = "Update";
            this.btNGP.UseVisualStyleBackColor = true;
            this.btNGP.Click += new System.EventHandler(this.btNGPDownload_Click);
            // 
            // lblFixup
            // 
            this.lblFixup.AutoSize = true;
            this.lblFixup.Location = new System.Drawing.Point(61, 64);
            this.lblFixup.Name = "lblFixup";
            this.lblFixup.Size = new System.Drawing.Size(88, 13);
            this.lblFixup.TabIndex = 1;
            this.lblFixup.Text = "999.999.999.999";
            // 
            // lblFixUpDate
            // 
            this.lblFixUpDate.AutoSize = true;
            this.lblFixUpDate.Location = new System.Drawing.Point(148, 64);
            this.lblFixUpDate.Name = "lblFixUpDate";
            this.lblFixUpDate.Size = new System.Drawing.Size(34, 13);
            this.lblFixUpDate.TabIndex = 1;
            this.lblFixUpDate.Text = "(date)";
            // 
            // lblNGPDate
            // 
            this.lblNGPDate.AutoSize = true;
            this.lblNGPDate.Location = new System.Drawing.Point(148, 33);
            this.lblNGPDate.Name = "lblNGPDate";
            this.lblNGPDate.Size = new System.Drawing.Size(34, 13);
            this.lblNGPDate.TabIndex = 1;
            this.lblNGPDate.Text = "(date)";
            // 
            // lblNGP
            // 
            this.lblNGP.AutoSize = true;
            this.lblNGP.Location = new System.Drawing.Point(61, 33);
            this.lblNGP.Name = "lblNGP";
            this.lblNGP.Size = new System.Drawing.Size(88, 13);
            this.lblNGP.TabIndex = 1;
            this.lblNGP.Text = "999.999.999.999";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "FixUp:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "NGP:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Installed Cars:";
            // 
            // btSaveList
            // 
            this.btSaveList.Location = new System.Drawing.Point(18, 315);
            this.btSaveList.Name = "btSaveList";
            this.btSaveList.Size = new System.Drawing.Size(80, 23);
            this.btSaveList.TabIndex = 7;
            this.btSaveList.Text = "Save List";
            this.btSaveList.UseVisualStyleBackColor = true;
            this.btSaveList.Click += new System.EventHandler(this.btSaveList_Click);
            // 
            // olvInstalledCars
            // 
            this.olvInstalledCars.AllColumns.Add(this.col2Remove);
            this.olvInstalledCars.AllColumns.Add(this.col2Category);
            this.olvInstalledCars.AllColumns.Add(this.col2Manufacturer);
            this.olvInstalledCars.AllColumns.Add(this.col2Name);
            this.olvInstalledCars.AllColumns.Add(this.col2Trans);
            this.olvInstalledCars.AllColumns.Add(this.col2Sound);
            this.olvInstalledCars.AllColumns.Add(this.col2FMODSoundBank);
            this.olvInstalledCars.AllColumns.Add(this.col2Settings);
            this.olvInstalledCars.AllowColumnReorder = true;
            this.olvInstalledCars.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.olvInstalledCars.CellEditUseWholeCell = false;
            this.olvInstalledCars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col2Remove,
            this.col2Category,
            this.col2Manufacturer,
            this.col2Name,
            this.col2Trans,
            this.col2Sound,
            this.col2FMODSoundBank,
            this.col2Settings});
            this.olvInstalledCars.Cursor = System.Windows.Forms.Cursors.Default;
            this.olvInstalledCars.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.olvInstalledCars.FullRowSelect = true;
            this.olvInstalledCars.GridLines = true;
            this.olvInstalledCars.HeaderMinimumHeight = 30;
            this.olvInstalledCars.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.olvInstalledCars.HideSelection = false;
            this.olvInstalledCars.Location = new System.Drawing.Point(18, 25);
            this.olvInstalledCars.MultiSelect = false;
            this.olvInstalledCars.Name = "olvInstalledCars";
            this.olvInstalledCars.RowHeight = 30;
            this.olvInstalledCars.ShowGroups = false;
            this.olvInstalledCars.ShowImagesOnSubItems = true;
            this.olvInstalledCars.Size = new System.Drawing.Size(708, 282);
            this.olvInstalledCars.TabIndex = 1;
            this.olvInstalledCars.UnfocusedSelectedBackColor = System.Drawing.SystemColors.Highlight;
            this.olvInstalledCars.UnfocusedSelectedForeColor = System.Drawing.SystemColors.HighlightText;
            this.olvInstalledCars.UseCellFormatEvents = true;
            this.olvInstalledCars.UseCompatibleStateImageBehavior = false;
            this.olvInstalledCars.UseHotItem = true;
            this.olvInstalledCars.View = System.Windows.Forms.View.Details;
            this.olvInstalledCars.ButtonClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvInstalledCars_ButtonClick);
            this.olvInstalledCars.CellClick += new System.EventHandler<BrightIdeasSoftware.CellClickEventArgs>(this.olvInstalledCars_CellClick);
            this.olvInstalledCars.CellOver += new System.EventHandler<BrightIdeasSoftware.CellOverEventArgs>(this.olvInstalledCars_CellOver);
            this.olvInstalledCars.CellRightClick += new System.EventHandler<BrightIdeasSoftware.CellRightClickEventArgs>(this.OlvInstalledCars_CellRightClick);
            this.olvInstalledCars.CellToolTipShowing += new System.EventHandler<BrightIdeasSoftware.ToolTipShowingEventArgs>(this.olvAllCars_CellToolTipShowing);
            this.olvInstalledCars.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.olvInstalledCars_FormatCell);
            this.olvInstalledCars.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.olvInstalledCars_FormatRow);
            this.olvInstalledCars.DoubleClick += new System.EventHandler(this.olvInstalledCars_DoubleClick);
            // 
            // col2Remove
            // 
            this.col2Remove.AspectName = "cat";
            this.col2Remove.ButtonSize = new System.Drawing.Size(34, 28);
            this.col2Remove.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.FixedBounds;
            this.col2Remove.EnableButtonWhenItemIsDisabled = true;
            this.col2Remove.IsButton = true;
            this.col2Remove.MaximumWidth = 40;
            this.col2Remove.MinimumWidth = 40;
            this.col2Remove.Renderer = this.myButtonRendererRemove;
            this.col2Remove.Text = "";
            this.col2Remove.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col2Remove.Width = 40;
            // 
            // myButtonRendererRemove
            // 
            this.myButtonRendererRemove.ButtonPadding = new System.Drawing.Size(0, 0);
            this.myButtonRendererRemove.CellPadding = new System.Drawing.Rectangle(0, 0, 0, 1);
            this.myButtonRendererRemove.ImageIndex = 0;
            this.myButtonRendererRemove.ImageList = this.imageList16;
            this.myButtonRendererRemove.SizingMode = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.CellBounds;
            // 
            // col2Category
            // 
            this.col2Category.AspectName = "cat";
            this.col2Category.Text = "Category";
            // 
            // col2Manufacturer
            // 
            this.col2Manufacturer.AspectName = "manufacturer";
            this.col2Manufacturer.Text = "Manufacturer";
            // 
            // col2Name
            // 
            this.col2Name.AspectName = "name";
            this.col2Name.Text = "Name";
            // 
            // col2Trans
            // 
            this.col2Trans.AspectName = "trans";
            this.col2Trans.Text = "Trans";
            // 
            // col2Sound
            // 
            this.col2Sound.AspectName = "userSettings.engineSound";
            this.col2Sound.Text = "Sound";
            // 
            // col2FMODSoundBank
            // 
            this.col2FMODSoundBank.AspectName = "userSettings.FMODSoundBank";
            this.col2FMODSoundBank.Text = "FMOD Sound Bank";
            this.col2FMODSoundBank.Width = 114;
            // 
            // col2Settings
            // 
            this.col2Settings.AspectName = "name";
            this.col2Settings.ButtonSize = new System.Drawing.Size(30, 30);
            this.col2Settings.ButtonSizing = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.FixedBounds;
            this.col2Settings.IsButton = true;
            this.col2Settings.MaximumWidth = 31;
            this.col2Settings.MinimumWidth = 31;
            this.col2Settings.Renderer = this.myButtonRendererSettings;
            this.col2Settings.Text = "";
            this.col2Settings.Width = 31;
            // 
            // myButtonRendererSettings
            // 
            this.myButtonRendererSettings.ButtonPadding = null;
            this.myButtonRendererSettings.ButtonSize = new System.Drawing.Size(30, 30);
            this.myButtonRendererSettings.ImageIndex = 0;
            this.myButtonRendererSettings.ImageList = this.imageList24;
            this.myButtonRendererSettings.SizingMode = BrightIdeasSoftware.OLVColumn.ButtonSizingMode.FixedBounds;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(635, 610);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 37);
            this.button1.TabIndex = 3;
            this.button1.Text = "Start Game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btStartGame);
            // 
            // btApply
            // 
            this.btApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btApply.Location = new System.Drawing.Point(548, 610);
            this.btApply.Name = "btApply";
            this.btApply.Size = new System.Drawing.Size(80, 37);
            this.btApply.TabIndex = 3;
            this.btApply.Text = "Apply";
            this.btApply.UseVisualStyleBackColor = true;
            this.btApply.Click += new System.EventHandler(this.btApply_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 711);
            this.Controls.Add(this.mySplitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1300, 750);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "RBRCIT - RBR Car Installation Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStripGroups.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.contextLoadListManage.ResumeLayout(false);
            this.contextMenuStripCar.ResumeLayout(false);
            this.contextMenuFMODSoundBank.ResumeLayout(false);
            this.mySplitContainer1.Panel1.ResumeLayout(false);
            this.mySplitContainer1.Panel1.PerformLayout();
            this.mySplitContainer1.Panel2.ResumeLayout(false);
            this.mySplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mySplitContainer1)).EndInit();
            this.mySplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.olvAllCars)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.olvInstalledCars)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private BrightIdeasSoftware.ObjectListView olvAllCars;
        private BrightIdeasSoftware.OLVColumn colCategory;
        private BrightIdeasSoftware.OLVColumn colName;
        private BrightIdeasSoftware.OLVColumn colManufacturer;
        private BrightIdeasSoftware.OLVColumn colTrans;
        private BrightIdeasSoftware.OLVColumn colYear;
        private BrightIdeasSoftware.ObjectListView olvInstalledCars;
        private BrightIdeasSoftware.OLVColumn colModel;
        private BrightIdeasSoftware.OLVColumn colPhysics;
        private BrightIdeasSoftware.OLVColumn colAction;
        private BrightIdeasSoftware.OLVColumn col2Category;
        private BrightIdeasSoftware.OLVColumn col2Name;
        private BrightIdeasSoftware.OLVColumn col2Trans;
        private BrightIdeasSoftware.OLVColumn col2Remove;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGroups;
        private System.Windows.Forms.ToolStripMenuItem collapseAllGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uncollapseAllGroupsToolStripMenuItem;
        private BrightIdeasSoftware.HyperlinkStyle hyperlinkStyle1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showGroupsToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn col2Manufacturer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private BrightIdeasSoftware.OLVColumn colHP;
        private BrightIdeasSoftware.OLVColumn colWeight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btApply;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.Button btSaveList;
        private BrightIdeasSoftware.OLVColumn col2Sound;
        private BrightIdeasSoftware.OLVColumn col2Settings;
        public System.Windows.Forms.ImageList imageList24;
        private System.Windows.Forms.ToolStripMenuItem MenuBackup;
        private System.Windows.Forms.ToolStripMenuItem MenuRestore;
        private ZissisControls.MySplitContainer mySplitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuExtractAudioDat;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ImageList imageList16;
        private MyButtonRenderer myButtonRendererAdd;
        private MyButtonRenderer myButtonRendererSettings;
        private MyButtonRenderer myButtonRendererRemove;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblNGP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblFixup;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btFixup;
        private System.Windows.Forms.Button btNGP;
        private System.Windows.Forms.Button btFixupConfigure;
        private System.Windows.Forms.Button btNGPConfigure;
        private MenuButton btLoadList;
        private System.Windows.Forms.ContextMenuStrip contextLoadList;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuReload;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuUpdateCarList;
        private System.Windows.Forms.ToolStripMenuItem MenuDownloadMissingPhysics;
        private System.Windows.Forms.ToolStripMenuItem MenuRestoreOriginalRBRCars;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label lblFixUpDate;
        private System.Windows.Forms.Label lblNGPDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ContextMenuStrip contextLoadListManage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem MenuManageSavedCarLists;
        private System.Windows.Forms.CheckBox cbReplaceShoolFiles;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripCar;
        private System.Windows.Forms.ToolStripMenuItem updateModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updatePhysicsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuUpdateAllExistingPhysics;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btFmodEnable;
        private System.Windows.Forms.Button btFmodDisable;
        private System.Windows.Forms.Label lblFMODStatus;
        private BrightIdeasSoftware.OLVColumn col2FMODSoundBank;
        private BrightIdeasSoftware.OLVColumn colFMODSoundBank;
        private System.Windows.Forms.Button btFMOD;
        private System.Windows.Forms.Button btFMODConfigure;
        private System.Windows.Forms.Label lblFMODVersion;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem updateRBRCITToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuFMODSoundBank;
        private System.Windows.Forms.ToolStripMenuItem removeSoundBankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateSoundBankToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem downloadMissingSoundBanksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateExistingSoundBanksToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
    }
}


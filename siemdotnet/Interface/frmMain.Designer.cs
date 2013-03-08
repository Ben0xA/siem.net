namespace siemdotnet
{
    partial class frmMain
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Local Network");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Networks", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.stsMain = new System.Windows.Forms.StatusStrip();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tbMain = new System.Windows.Forms.ToolStrip();
            this.pnlMain = new System.Windows.Forms.SplitContainer();
            this.scanActiveDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scanByIPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlSystems = new System.Windows.Forms.SplitContainer();
            this.lvwSystems = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chIP = new System.Windows.Forms.ColumnHeader();
            this.chStatus = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tvwNetworks = new System.Windows.Forms.TreeView();
            this.imgList16 = new System.Windows.Forms.ImageList(this.components);
            this.tcSystem = new System.Windows.Forms.TabControl();
            this.tbpAlerts = new System.Windows.Forms.TabPage();
            this.chClientInstalled = new System.Windows.Forms.ColumnHeader();
            this.chAlerts = new System.Windows.Forms.ColumnHeader();
            this.chLastScan = new System.Windows.Forms.ColumnHeader();
            this.chMAC = new System.Windows.Forms.ColumnHeader();
            this.tbpGeneral = new System.Windows.Forms.TabPage();
            this.pbServer = new System.Windows.Forms.PictureBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.mnuMain.SuspendLayout();
            this.stsMain.SuspendLayout();
            this.tbMain.SuspendLayout();
            this.pnlMain.Panel1.SuspendLayout();
            this.pnlMain.Panel2.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSystems.Panel1.SuspendLayout();
            this.pnlSystems.Panel2.SuspendLayout();
            this.pnlSystems.SuspendLayout();
            this.tcSystem.SuspendLayout();
            this.tbpGeneral.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbServer)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(1205, 24);
            this.mnuMain.TabIndex = 0;
            // 
            // stsMain
            // 
            this.stsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.stsMain.Location = new System.Drawing.Point(0, 623);
            this.stsMain.Name = "stsMain";
            this.stsMain.Size = new System.Drawing.Size(1205, 22);
            this.stsMain.TabIndex = 1;
            this.stsMain.Text = "statusStrip1";
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanActiveDirectoryToolStripMenuItem,
            this.scanByIPToolStripMenuItem,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(37, 20);
            this.mnuFile.Text = "&File";
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(186, 22);
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(39, 17);
            this.lblStatus.Text = "Ready";
            // 
            // tbMain
            // 
            this.tbMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2});
            this.tbMain.Location = new System.Drawing.Point(0, 24);
            this.tbMain.Name = "tbMain";
            this.tbMain.Size = new System.Drawing.Size(1205, 25);
            this.tbMain.TabIndex = 2;
            // 
            // pnlMain
            // 
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 49);
            this.pnlMain.Name = "pnlMain";
            // 
            // pnlMain.Panel1
            // 
            this.pnlMain.Panel1.Controls.Add(this.tvwNetworks);
            this.pnlMain.Panel1.Controls.Add(this.toolStrip1);
            // 
            // pnlMain.Panel2
            // 
            this.pnlMain.Panel2.Controls.Add(this.pnlSystems);
            this.pnlMain.Size = new System.Drawing.Size(1205, 574);
            this.pnlMain.SplitterDistance = 226;
            this.pnlMain.TabIndex = 3;
            // 
            // scanActiveDirectoryToolStripMenuItem
            // 
            this.scanActiveDirectoryToolStripMenuItem.Name = "scanActiveDirectoryToolStripMenuItem";
            this.scanActiveDirectoryToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.scanActiveDirectoryToolStripMenuItem.Text = "Scan Active Directory";
            this.scanActiveDirectoryToolStripMenuItem.Click += new System.EventHandler(this.scanActiveDirectoryToolStripMenuItem_Click);
            // 
            // scanByIPToolStripMenuItem
            // 
            this.scanByIPToolStripMenuItem.Name = "scanByIPToolStripMenuItem";
            this.scanByIPToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.scanByIPToolStripMenuItem.Text = "Scan by IP";
            this.scanByIPToolStripMenuItem.Click += new System.EventHandler(this.scanByIPToolStripMenuItem_Click);
            // 
            // pnlSystems
            // 
            this.pnlSystems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSystems.Location = new System.Drawing.Point(0, 0);
            this.pnlSystems.Name = "pnlSystems";
            this.pnlSystems.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // pnlSystems.Panel1
            // 
            this.pnlSystems.Panel1.Controls.Add(this.lvwSystems);
            // 
            // pnlSystems.Panel2
            // 
            this.pnlSystems.Panel2.Controls.Add(this.tcSystem);
            this.pnlSystems.Size = new System.Drawing.Size(975, 574);
            this.pnlSystems.SplitterDistance = 357;
            this.pnlSystems.TabIndex = 0;
            // 
            // lvwSystems
            // 
            this.lvwSystems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwSystems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chIP,
            this.chMAC,
            this.chStatus,
            this.chClientInstalled,
            this.chAlerts,
            this.chLastScan});
            this.lvwSystems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwSystems.FullRowSelect = true;
            this.lvwSystems.Location = new System.Drawing.Point(0, 0);
            this.lvwSystems.Name = "lvwSystems";
            this.lvwSystems.Size = new System.Drawing.Size(975, 357);
            this.lvwSystems.SmallImageList = this.imgList16;
            this.lvwSystems.TabIndex = 0;
            this.lvwSystems.UseCompatibleStateImageBehavior = false;
            this.lvwSystems.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 182;
            // 
            // chIP
            // 
            this.chIP.Text = "IP Address";
            this.chIP.Width = 105;
            // 
            // chStatus
            // 
            this.chStatus.Text = "Status";
            this.chStatus.Width = 101;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(226, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tvwNetworks
            // 
            this.tvwNetworks.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tvwNetworks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwNetworks.FullRowSelect = true;
            this.tvwNetworks.HideSelection = false;
            this.tvwNetworks.ImageIndex = 0;
            this.tvwNetworks.ImageList = this.imgList16;
            this.tvwNetworks.Location = new System.Drawing.Point(0, 25);
            this.tvwNetworks.Name = "tvwNetworks";
            treeNode1.ImageKey = "Diagram.png";
            treeNode1.Name = "ndNone";
            treeNode1.SelectedImageKey = "Server.png";
            treeNode1.Text = "Local Network";
            treeNode2.Name = "ndNetwork";
            treeNode2.Text = "Networks";
            this.tvwNetworks.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.tvwNetworks.SelectedImageIndex = 1;
            this.tvwNetworks.ShowPlusMinus = false;
            this.tvwNetworks.ShowRootLines = false;
            this.tvwNetworks.Size = new System.Drawing.Size(226, 549);
            this.tvwNetworks.TabIndex = 1;
            // 
            // imgList16
            // 
            this.imgList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList16.ImageStream")));
            this.imgList16.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList16.Images.SetKeyName(0, "FolderClosed.png");
            this.imgList16.Images.SetKeyName(1, "FolderOpen.png");
            this.imgList16.Images.SetKeyName(2, "Server.png");
            this.imgList16.Images.SetKeyName(3, "Diagram.png");
            // 
            // tcSystem
            // 
            this.tcSystem.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tcSystem.Controls.Add(this.tbpGeneral);
            this.tcSystem.Controls.Add(this.tbpAlerts);
            this.tcSystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcSystem.Location = new System.Drawing.Point(0, 0);
            this.tcSystem.Name = "tcSystem";
            this.tcSystem.SelectedIndex = 0;
            this.tcSystem.Size = new System.Drawing.Size(975, 213);
            this.tcSystem.TabIndex = 0;
            // 
            // tbpAlerts
            // 
            this.tbpAlerts.Location = new System.Drawing.Point(4, 4);
            this.tbpAlerts.Name = "tbpAlerts";
            this.tbpAlerts.Padding = new System.Windows.Forms.Padding(3);
            this.tbpAlerts.Size = new System.Drawing.Size(967, 187);
            this.tbpAlerts.TabIndex = 1;
            this.tbpAlerts.Text = "Alerts (0)";
            this.tbpAlerts.UseVisualStyleBackColor = true;
            // 
            // chClientInstalled
            // 
            this.chClientInstalled.Text = "SIEM.NET Client";
            this.chClientInstalled.Width = 101;
            // 
            // chAlerts
            // 
            this.chAlerts.Text = "Alerts";
            // 
            // chLastScan
            // 
            this.chLastScan.Text = "Last Scan";
            this.chLastScan.Width = 173;
            // 
            // chMAC
            // 
            this.chMAC.Text = "MAC Address";
            this.chMAC.Width = 117;
            // 
            // tbpGeneral
            // 
            this.tbpGeneral.Controls.Add(this.pbServer);
            this.tbpGeneral.Location = new System.Drawing.Point(4, 4);
            this.tbpGeneral.Name = "tbpGeneral";
            this.tbpGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tbpGeneral.Size = new System.Drawing.Size(967, 187);
            this.tbpGeneral.TabIndex = 0;
            this.tbpGeneral.Text = "General";
            this.tbpGeneral.UseVisualStyleBackColor = true;
            // 
            // pbServer
            // 
            this.pbServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pbServer.Image = global::siemdotnet.Properties.Resources.Server1;
            this.pbServer.Location = new System.Drawing.Point(849, 63);
            this.pbServer.Name = "pbServer";
            this.pbServer.Size = new System.Drawing.Size(118, 124);
            this.pbServer.TabIndex = 0;
            this.pbServer.TabStop = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::siemdotnet.Properties.Resources.Diagram;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::siemdotnet.Properties.Resources.ServerExecute;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 645);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tbMain);
            this.Controls.Add(this.stsMain);
            this.Controls.Add(this.mnuMain);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIEM.NET";
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.stsMain.ResumeLayout(false);
            this.stsMain.PerformLayout();
            this.tbMain.ResumeLayout(false);
            this.tbMain.PerformLayout();
            this.pnlMain.Panel1.ResumeLayout(false);
            this.pnlMain.Panel1.PerformLayout();
            this.pnlMain.Panel2.ResumeLayout(false);
            this.pnlMain.ResumeLayout(false);
            this.pnlSystems.Panel1.ResumeLayout(false);
            this.pnlSystems.Panel2.ResumeLayout(false);
            this.pnlSystems.ResumeLayout(false);
            this.tcSystem.ResumeLayout(false);
            this.tbpGeneral.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbServer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.StatusStrip stsMain;
        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStrip tbMain;
        private System.Windows.Forms.SplitContainer pnlMain;
        private System.Windows.Forms.ToolStripMenuItem scanActiveDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scanByIPToolStripMenuItem;
        private System.Windows.Forms.SplitContainer pnlSystems;
        private System.Windows.Forms.TreeView tvwNetworks;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListView lvwSystems;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chIP;
        private System.Windows.Forms.ColumnHeader chStatus;
        private System.Windows.Forms.ImageList imgList16;
        private System.Windows.Forms.TabControl tcSystem;
        private System.Windows.Forms.TabPage tbpGeneral;
        private System.Windows.Forms.TabPage tbpAlerts;
        private System.Windows.Forms.ColumnHeader chMAC;
        private System.Windows.Forms.ColumnHeader chClientInstalled;
        private System.Windows.Forms.ColumnHeader chAlerts;
        private System.Windows.Forms.ColumnHeader chLastScan;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.PictureBox pbServer;
    }
}


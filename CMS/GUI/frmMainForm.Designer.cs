namespace CMS
{
    partial class frmMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.tsmiFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiLogout = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManagement = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManagePatient = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageDoctors = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageAppointments = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageMedicineInventory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPatientExamination = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageExaminationHistory = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManagePrescriptions = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReports = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPatientListReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAppointmentScheduleReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiInventoryAndMedicineRevenueReport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiManageUserAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiViewActivityLog = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBackupandRestoreDatabase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiAboutSoftware = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiUserGuide = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiContactSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.lblHello = new System.Windows.Forms.Label();
            this.btnLang = new Guna.UI2.WinForms.Guna2Button();
            this.btnScreenMode = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.lblLogan = new System.Windows.Forms.Label();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabPagePatients = new System.Windows.Forms.TabPage();
            this.tabPageDoctors = new System.Windows.Forms.TabPage();
            this.tabPageManageAppointments = new System.Windows.Forms.TabPage();
            this.tabPageManageMedicineInventory = new System.Windows.Forms.TabPage();
            this.menuStripMain.SuspendLayout();
            this.pnlHead.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripMain
            // 
            this.menuStripMain.AutoSize = false;
            this.menuStripMain.BackColor = System.Drawing.Color.Transparent;
            this.menuStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripMain.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiFile,
            this.tsmiManagement,
            this.tsmiPatientExamination,
            this.tsmiReports,
            this.tsmiSystem,
            this.tsmiHelp});
            this.menuStripMain.Location = new System.Drawing.Point(54, 4);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1106, 40);
            this.menuStripMain.TabIndex = 0;
            // 
            // tsmiFile
            // 
            this.tsmiFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLogin,
            this.tsmiLogout,
            this.tsmiChangePassword,
            this.tsmiExit});
            this.tsmiFile.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiFile.Name = "tsmiFile";
            this.tsmiFile.Size = new System.Drawing.Size(55, 36);
            this.tsmiFile.Text = "File";
            // 
            // tsmiLogin
            // 
            this.tsmiLogin.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiLogin.Name = "tsmiLogin";
            this.tsmiLogin.Size = new System.Drawing.Size(243, 28);
            this.tsmiLogin.Text = "Log In";
            this.tsmiLogin.Click += new System.EventHandler(this.tsmiLogin_Click);
            // 
            // tsmiLogout
            // 
            this.tsmiLogout.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiLogout.Name = "tsmiLogout";
            this.tsmiLogout.Size = new System.Drawing.Size(243, 28);
            this.tsmiLogout.Text = "Log Out";
            this.tsmiLogout.Click += new System.EventHandler(this.tsmiLogout_Click);
            // 
            // tsmiChangePassword
            // 
            this.tsmiChangePassword.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiChangePassword.Name = "tsmiChangePassword";
            this.tsmiChangePassword.Size = new System.Drawing.Size(243, 28);
            this.tsmiChangePassword.Text = "Change Password";
            this.tsmiChangePassword.Click += new System.EventHandler(this.tsmiChangePassword_Click);
            // 
            // tsmiExit
            // 
            this.tsmiExit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(243, 28);
            this.tsmiExit.Text = "Exit";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // tsmiManagement
            // 
            this.tsmiManagement.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiManagePatient,
            this.tsmiManageDoctors,
            this.tsmiManageAppointments,
            this.tsmiManageMedicineInventory});
            this.tsmiManagement.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiManagement.Name = "tsmiManagement";
            this.tsmiManagement.Size = new System.Drawing.Size(134, 36);
            this.tsmiManagement.Text = "Management";
            // 
            // tsmiManagePatient
            // 
            this.tsmiManagePatient.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiManagePatient.Name = "tsmiManagePatient";
            this.tsmiManagePatient.Size = new System.Drawing.Size(331, 28);
            this.tsmiManagePatient.Text = "Manage Patients";
            this.tsmiManagePatient.Click += new System.EventHandler(this.tsmiManagePatient_Click);
            // 
            // tsmiManageDoctors
            // 
            this.tsmiManageDoctors.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiManageDoctors.Name = "tsmiManageDoctors";
            this.tsmiManageDoctors.Size = new System.Drawing.Size(331, 28);
            this.tsmiManageDoctors.Text = "Manage Doctors";
            // 
            // tsmiManageAppointments
            // 
            this.tsmiManageAppointments.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiManageAppointments.Name = "tsmiManageAppointments";
            this.tsmiManageAppointments.Size = new System.Drawing.Size(331, 28);
            this.tsmiManageAppointments.Text = "Manage Appointments";
            // 
            // tsmiManageMedicineInventory
            // 
            this.tsmiManageMedicineInventory.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiManageMedicineInventory.Name = "tsmiManageMedicineInventory";
            this.tsmiManageMedicineInventory.Size = new System.Drawing.Size(331, 28);
            this.tsmiManageMedicineInventory.Text = "Manage Medicine Inventory";
            // 
            // tsmiPatientExamination
            // 
            this.tsmiPatientExamination.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiManageExaminationHistory,
            this.tsmiManagePrescriptions});
            this.tsmiPatientExamination.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiPatientExamination.Name = "tsmiPatientExamination";
            this.tsmiPatientExamination.Size = new System.Drawing.Size(195, 36);
            this.tsmiPatientExamination.Text = "Patient Examination";
            // 
            // tsmiManageExaminationHistory
            // 
            this.tsmiManageExaminationHistory.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiManageExaminationHistory.Name = "tsmiManageExaminationHistory";
            this.tsmiManageExaminationHistory.Size = new System.Drawing.Size(340, 28);
            this.tsmiManageExaminationHistory.Text = "Manage Examination History";
            // 
            // tsmiManagePrescriptions
            // 
            this.tsmiManagePrescriptions.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiManagePrescriptions.Name = "tsmiManagePrescriptions";
            this.tsmiManagePrescriptions.Size = new System.Drawing.Size(340, 28);
            this.tsmiManagePrescriptions.Text = "Manage Prescriptions";
            // 
            // tsmiReports
            // 
            this.tsmiReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPatientListReport,
            this.tsmiAppointmentScheduleReport,
            this.tsmiInventoryAndMedicineRevenueReport});
            this.tsmiReports.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiReports.Name = "tsmiReports";
            this.tsmiReports.Size = new System.Drawing.Size(91, 36);
            this.tsmiReports.Text = "Reports";
            // 
            // tsmiPatientListReport
            // 
            this.tsmiPatientListReport.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiPatientListReport.Name = "tsmiPatientListReport";
            this.tsmiPatientListReport.Size = new System.Drawing.Size(436, 28);
            this.tsmiPatientListReport.Text = "Patient List Report";
            // 
            // tsmiAppointmentScheduleReport
            // 
            this.tsmiAppointmentScheduleReport.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiAppointmentScheduleReport.Name = "tsmiAppointmentScheduleReport";
            this.tsmiAppointmentScheduleReport.Size = new System.Drawing.Size(436, 28);
            this.tsmiAppointmentScheduleReport.Text = "Appointment Schedule Report";
            // 
            // tsmiInventoryAndMedicineRevenueReport
            // 
            this.tsmiInventoryAndMedicineRevenueReport.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiInventoryAndMedicineRevenueReport.Name = "tsmiInventoryAndMedicineRevenueReport";
            this.tsmiInventoryAndMedicineRevenueReport.Size = new System.Drawing.Size(436, 28);
            this.tsmiInventoryAndMedicineRevenueReport.Text = "Inventory and Medicine Revenue Report";
            // 
            // tsmiSystem
            // 
            this.tsmiSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiManageUserAccounts,
            this.tsmiViewActivityLog,
            this.tsmiBackupandRestoreDatabase});
            this.tsmiSystem.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiSystem.Name = "tsmiSystem";
            this.tsmiSystem.Size = new System.Drawing.Size(85, 36);
            this.tsmiSystem.Text = "System";
            // 
            // tsmiManageUserAccounts
            // 
            this.tsmiManageUserAccounts.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiManageUserAccounts.Name = "tsmiManageUserAccounts";
            this.tsmiManageUserAccounts.Size = new System.Drawing.Size(348, 28);
            this.tsmiManageUserAccounts.Text = "Manage User Accounts";
            // 
            // tsmiViewActivityLog
            // 
            this.tsmiViewActivityLog.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiViewActivityLog.Name = "tsmiViewActivityLog";
            this.tsmiViewActivityLog.Size = new System.Drawing.Size(348, 28);
            this.tsmiViewActivityLog.Text = "View Activity Log";
            // 
            // tsmiBackupandRestoreDatabase
            // 
            this.tsmiBackupandRestoreDatabase.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiBackupandRestoreDatabase.Name = "tsmiBackupandRestoreDatabase";
            this.tsmiBackupandRestoreDatabase.Size = new System.Drawing.Size(348, 28);
            this.tsmiBackupandRestoreDatabase.Text = "Backup and Restore Database";
            // 
            // tsmiHelp
            // 
            this.tsmiHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiAboutSoftware,
            this.tsmiUserGuide,
            this.tsmiContactSupport});
            this.tsmiHelp.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiHelp.Name = "tsmiHelp";
            this.tsmiHelp.Size = new System.Drawing.Size(64, 36);
            this.tsmiHelp.Text = "Help";
            // 
            // tsmiAboutSoftware
            // 
            this.tsmiAboutSoftware.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiAboutSoftware.Name = "tsmiAboutSoftware";
            this.tsmiAboutSoftware.Size = new System.Drawing.Size(232, 28);
            this.tsmiAboutSoftware.Text = "About Software";
            // 
            // tsmiUserGuide
            // 
            this.tsmiUserGuide.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiUserGuide.Name = "tsmiUserGuide";
            this.tsmiUserGuide.Size = new System.Drawing.Size(232, 28);
            this.tsmiUserGuide.Text = "User Guide";
            // 
            // tsmiContactSupport
            // 
            this.tsmiContactSupport.ForeColor = System.Drawing.Color.RoyalBlue;
            this.tsmiContactSupport.Name = "tsmiContactSupport";
            this.tsmiContactSupport.Size = new System.Drawing.Size(232, 28);
            this.tsmiContactSupport.Text = "Contact Support";
            // 
            // pnlHead
            // 
            this.pnlHead.BackColor = System.Drawing.Color.Transparent;
            this.pnlHead.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlHead.Controls.Add(this.lblHello);
            this.pnlHead.Controls.Add(this.btnLang);
            this.pnlHead.Controls.Add(this.btnScreenMode);
            this.pnlHead.Controls.Add(this.pictureBoxLogo);
            this.pnlHead.Controls.Add(this.menuStripMain);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(1440, 50);
            this.pnlHead.TabIndex = 1;
            // 
            // lblHello
            // 
            this.lblHello.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHello.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.lblHello.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblHello.Location = new System.Drawing.Point(1212, 5);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(215, 39);
            this.lblHello.TabIndex = 6;
            this.lblHello.Tag = "";
            this.lblHello.Text = "lblNameLogin";
            this.lblHello.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLang
            // 
            this.btnLang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLang.Animated = true;
            this.btnLang.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLang.BorderRadius = 20;
            this.btnLang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLang.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnLang.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnLang.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnLang.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnLang.FillColor = System.Drawing.Color.Transparent;
            this.btnLang.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnLang.ForeColor = System.Drawing.Color.Black;
            this.btnLang.Image = global::CMS.Properties.Resources.iconVietNam_;
            this.btnLang.ImageSize = new System.Drawing.Size(30, 30);
            this.btnLang.Location = new System.Drawing.Point(1166, 4);
            this.btnLang.Name = "btnLang";
            this.btnLang.Size = new System.Drawing.Size(40, 40);
            this.btnLang.TabIndex = 5;
            this.btnLang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnLang.Click += new System.EventHandler(this.btnLang_Click);
            // 
            // btnScreenMode
            // 
            this.btnScreenMode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnScreenMode.Animated = true;
            this.btnScreenMode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnScreenMode.BorderRadius = 20;
            this.btnScreenMode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnScreenMode.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnScreenMode.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnScreenMode.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnScreenMode.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnScreenMode.FillColor = System.Drawing.Color.Transparent;
            this.btnScreenMode.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold);
            this.btnScreenMode.ForeColor = System.Drawing.Color.Black;
            this.btnScreenMode.Image = global::CMS.Properties.Resources.iconDarkMode_;
            this.btnScreenMode.ImageSize = new System.Drawing.Size(30, 30);
            this.btnScreenMode.Location = new System.Drawing.Point(1120, 3);
            this.btnScreenMode.Name = "btnScreenMode";
            this.btnScreenMode.Size = new System.Drawing.Size(40, 40);
            this.btnScreenMode.TabIndex = 4;
            this.btnScreenMode.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.btnScreenMode.Click += new System.EventHandler(this.btnScreenMode_Click);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.BackgroundImage")));
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxLogo.Location = new System.Drawing.Point(11, 4);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(40, 40);
            this.pictureBoxLogo.TabIndex = 2;
            this.pictureBoxLogo.TabStop = false;
            // 
            // lblLogan
            // 
            this.lblLogan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogan.BackColor = System.Drawing.Color.Transparent;
            this.lblLogan.Font = new System.Drawing.Font("Times New Roman", 40F, System.Drawing.FontStyle.Bold);
            this.lblLogan.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblLogan.Location = new System.Drawing.Point(0, 670);
            this.lblLogan.Name = "lblLogan";
            this.lblLogan.Size = new System.Drawing.Size(1440, 131);
            this.lblLogan.TabIndex = 2;
            this.lblLogan.Text = "Where health begins, technology leads the way";
            this.lblLogan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.tabControlMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 50);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1440, 760);
            this.pnlMain.TabIndex = 3;
            // 
            // tabControlMain
            // 
            this.tabControlMain.Controls.Add(this.tabPagePatients);
            this.tabControlMain.Controls.Add(this.tabPageDoctors);
            this.tabControlMain.Controls.Add(this.tabPageManageAppointments);
            this.tabControlMain.Controls.Add(this.tabPageManageMedicineInventory);
            this.tabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlMain.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlMain.Location = new System.Drawing.Point(0, 0);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1440, 760);
            this.tabControlMain.TabIndex = 0;
            // 
            // tabPagePatients
            // 
            this.tabPagePatients.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPagePatients.Location = new System.Drawing.Point(4, 28);
            this.tabPagePatients.Name = "tabPagePatients";
            this.tabPagePatients.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePatients.Size = new System.Drawing.Size(1432, 728);
            this.tabPagePatients.TabIndex = 0;
            this.tabPagePatients.Text = "Manage Patients";
            this.tabPagePatients.UseVisualStyleBackColor = true;
            // 
            // tabPageDoctors
            // 
            this.tabPageDoctors.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageDoctors.Location = new System.Drawing.Point(4, 28);
            this.tabPageDoctors.Name = "tabPageDoctors";
            this.tabPageDoctors.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDoctors.Size = new System.Drawing.Size(1432, 728);
            this.tabPageDoctors.TabIndex = 1;
            this.tabPageDoctors.Text = "Manage Doctors";
            this.tabPageDoctors.UseVisualStyleBackColor = true;
            // 
            // tabPageManageAppointments
            // 
            this.tabPageManageAppointments.Location = new System.Drawing.Point(4, 28);
            this.tabPageManageAppointments.Name = "tabPageManageAppointments";
            this.tabPageManageAppointments.Size = new System.Drawing.Size(1432, 728);
            this.tabPageManageAppointments.TabIndex = 2;
            this.tabPageManageAppointments.Text = "Manage Appointments";
            this.tabPageManageAppointments.UseVisualStyleBackColor = true;
            // 
            // tabPageManageMedicineInventory
            // 
            this.tabPageManageMedicineInventory.Location = new System.Drawing.Point(4, 28);
            this.tabPageManageMedicineInventory.Name = "tabPageManageMedicineInventory";
            this.tabPageManageMedicineInventory.Size = new System.Drawing.Size(1432, 728);
            this.tabPageManageMedicineInventory.TabIndex = 3;
            this.tabPageManageMedicineInventory.Text = "Manage Medicine Inventory";
            this.tabPageManageMedicineInventory.UseVisualStyleBackColor = true;
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1440, 810);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.lblLogan);
            this.Controls.Add(this.pnlHead);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Times New Roman", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStripMain;
            this.Name = "frmMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.pnlHead.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem tsmiFile;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.ToolStripMenuItem tsmiManagement;
        private System.Windows.Forms.ToolStripMenuItem tsmiPatientExamination;
        private System.Windows.Forms.ToolStripMenuItem tsmiReports;
        private System.Windows.Forms.ToolStripMenuItem tsmiSystem;
        private System.Windows.Forms.ToolStripMenuItem tsmiHelp;
        private System.Windows.Forms.Label lblLogan;
        private Guna.UI2.WinForms.Guna2Button btnScreenMode;
        private Guna.UI2.WinForms.Guna2Button btnLang;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogin;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogout;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangePassword;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripMenuItem tsmiManagePatient;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageDoctors;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageAppointments;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageMedicineInventory;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageExaminationHistory;
        private System.Windows.Forms.ToolStripMenuItem tsmiManagePrescriptions;
        private System.Windows.Forms.ToolStripMenuItem tsmiPatientListReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiAppointmentScheduleReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiInventoryAndMedicineRevenueReport;
        private System.Windows.Forms.ToolStripMenuItem tsmiManageUserAccounts;
        private System.Windows.Forms.ToolStripMenuItem tsmiViewActivityLog;
        private System.Windows.Forms.ToolStripMenuItem tsmiBackupandRestoreDatabase;
        private System.Windows.Forms.ToolStripMenuItem tsmiAboutSoftware;
        private System.Windows.Forms.ToolStripMenuItem tsmiUserGuide;
        private System.Windows.Forms.ToolStripMenuItem tsmiContactSupport;
        private System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPagePatients;
        private System.Windows.Forms.TabPage tabPageDoctors;
        private System.Windows.Forms.TabPage tabPageManageAppointments;
        private System.Windows.Forms.TabPage tabPageManageMedicineInventory;
    }
}


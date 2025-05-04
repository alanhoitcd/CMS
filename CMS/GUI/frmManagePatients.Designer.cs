namespace CMS.GUI
{
    partial class frmManagePatients
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.pnlHead = new System.Windows.Forms.Panel();
            this.panelBody = new System.Windows.Forms.Panel();
            this.cboGender = new System.Windows.Forms.ComboBox();
            this.lblSocialSecurityNumber = new System.Windows.Forms.Label();
            this.txtSocialSecurityNumber = new System.Windows.Forms.TextBox();
            this.AddressPatients = new System.Windows.Forms.Label();
            this.txtAddressPatients = new System.Windows.Forms.TextBox();
            this.lblPhoneNumber = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.TextBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.lblDateOfBirth = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.lblPatientId = new System.Windows.Forms.Label();
            this.txtPatientId = new System.Windows.Forms.TextBox();
            this.btnFindPatients = new Guna.UI2.WinForms.Guna2Button();
            this.btnDeletePatients = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditPatients = new Guna.UI2.WinForms.Guna2Button();
            this.btnAddPatients = new Guna.UI2.WinForms.Guna2Button();
            this.panelFoot = new System.Windows.Forms.Panel();
            this.dgvManagePatients = new System.Windows.Forms.DataGridView();
            this.dtpDateOfBirth = new System.Windows.Forms.DateTimePicker();
            this.pnlHead.SuspendLayout();
            this.panelBody.SuspendLayout();
            this.panelFoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagePatients)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1587, 57);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Patients";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Transparent;
            this.btnClose.BorderColor = System.Drawing.Color.Transparent;
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.FillColor = System.Drawing.Color.Transparent;
            this.btnClose.FocusedColor = System.Drawing.Color.Transparent;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.Transparent;
            this.btnClose.Location = new System.Drawing.Point(1546, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedColor = System.Drawing.Color.Transparent;
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.Size = new System.Drawing.Size(44, 43);
            this.btnClose.TabIndex = 21;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlHead
            // 
            this.pnlHead.BackColor = System.Drawing.Color.Transparent;
            this.pnlHead.Controls.Add(this.btnClose);
            this.pnlHead.Controls.Add(this.label1);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(1593, 60);
            this.pnlHead.TabIndex = 25;
            // 
            // panelBody
            // 
            this.panelBody.Controls.Add(this.dtpDateOfBirth);
            this.panelBody.Controls.Add(this.cboGender);
            this.panelBody.Controls.Add(this.lblSocialSecurityNumber);
            this.panelBody.Controls.Add(this.txtSocialSecurityNumber);
            this.panelBody.Controls.Add(this.AddressPatients);
            this.panelBody.Controls.Add(this.txtAddressPatients);
            this.panelBody.Controls.Add(this.lblPhoneNumber);
            this.panelBody.Controls.Add(this.txtPhoneNumber);
            this.panelBody.Controls.Add(this.lblGender);
            this.panelBody.Controls.Add(this.lblDateOfBirth);
            this.panelBody.Controls.Add(this.lblLastName);
            this.panelBody.Controls.Add(this.txtLastName);
            this.panelBody.Controls.Add(this.lblFirstName);
            this.panelBody.Controls.Add(this.txtFirstName);
            this.panelBody.Controls.Add(this.lblPatientId);
            this.panelBody.Controls.Add(this.txtPatientId);
            this.panelBody.Controls.Add(this.btnFindPatients);
            this.panelBody.Controls.Add(this.btnDeletePatients);
            this.panelBody.Controls.Add(this.btnEditPatients);
            this.panelBody.Controls.Add(this.btnAddPatients);
            this.panelBody.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBody.Location = new System.Drawing.Point(0, 60);
            this.panelBody.Name = "panelBody";
            this.panelBody.Size = new System.Drawing.Size(1593, 278);
            this.panelBody.TabIndex = 27;
            // 
            // cboGender
            // 
            this.cboGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboGender.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.cboGender.FormattingEnabled = true;
            this.cboGender.Location = new System.Drawing.Point(1055, 6);
            this.cboGender.Name = "cboGender";
            this.cboGender.Size = new System.Drawing.Size(148, 39);
            this.cboGender.TabIndex = 50;
            // 
            // lblSocialSecurityNumber
            // 
            this.lblSocialSecurityNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSocialSecurityNumber.AutoSize = true;
            this.lblSocialSecurityNumber.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSocialSecurityNumber.Location = new System.Drawing.Point(900, 159);
            this.lblSocialSecurityNumber.Name = "lblSocialSecurityNumber";
            this.lblSocialSecurityNumber.Size = new System.Drawing.Size(92, 33);
            this.lblSocialSecurityNumber.TabIndex = 48;
            this.lblSocialSecurityNumber.Text = "CCCD";
            this.lblSocialSecurityNumber.Click += new System.EventHandler(this.lblSocialSecurityNumber_Click);
            // 
            // txtSocialSecurityNumber
            // 
            this.txtSocialSecurityNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSocialSecurityNumber.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSocialSecurityNumber.Location = new System.Drawing.Point(1055, 156);
            this.txtSocialSecurityNumber.Name = "txtSocialSecurityNumber";
            this.txtSocialSecurityNumber.Size = new System.Drawing.Size(526, 39);
            this.txtSocialSecurityNumber.TabIndex = 47;
            // 
            // AddressPatients
            // 
            this.AddressPatients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressPatients.AutoSize = true;
            this.AddressPatients.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressPatients.Location = new System.Drawing.Point(900, 107);
            this.AddressPatients.Name = "AddressPatients";
            this.AddressPatients.Size = new System.Drawing.Size(105, 33);
            this.AddressPatients.TabIndex = 46;
            this.AddressPatients.Text = "Address";
            // 
            // txtAddressPatients
            // 
            this.txtAddressPatients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddressPatients.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddressPatients.Location = new System.Drawing.Point(1055, 104);
            this.txtAddressPatients.Name = "txtAddressPatients";
            this.txtAddressPatients.Size = new System.Drawing.Size(526, 39);
            this.txtAddressPatients.TabIndex = 45;
            // 
            // lblPhoneNumber
            // 
            this.lblPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPhoneNumber.AutoSize = true;
            this.lblPhoneNumber.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNumber.Location = new System.Drawing.Point(900, 58);
            this.lblPhoneNumber.Name = "lblPhoneNumber";
            this.lblPhoneNumber.Size = new System.Drawing.Size(85, 33);
            this.lblPhoneNumber.TabIndex = 44;
            this.lblPhoneNumber.Text = "Phone";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPhoneNumber.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(1055, 54);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(526, 39);
            this.txtPhoneNumber.TabIndex = 43;
            // 
            // lblGender
            // 
            this.lblGender.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGender.AutoSize = true;
            this.lblGender.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGender.Location = new System.Drawing.Point(900, 9);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(95, 33);
            this.lblGender.TabIndex = 42;
            this.lblGender.Text = "Gender";
            // 
            // lblDateOfBirth
            // 
            this.lblDateOfBirth.AutoSize = true;
            this.lblDateOfBirth.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateOfBirth.Location = new System.Drawing.Point(6, 156);
            this.lblDateOfBirth.Name = "lblDateOfBirth";
            this.lblDateOfBirth.Size = new System.Drawing.Size(168, 33);
            this.lblDateOfBirth.TabIndex = 40;
            this.lblDateOfBirth.Text = "Date Of Birth";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(6, 107);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(133, 33);
            this.lblLastName.TabIndex = 38;
            this.lblLastName.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLastName.Location = new System.Drawing.Point(226, 104);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(506, 39);
            this.txtLastName.TabIndex = 37;
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.Location = new System.Drawing.Point(6, 58);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(138, 33);
            this.lblFirstName.TabIndex = 36;
            this.lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFirstName.Location = new System.Drawing.Point(226, 55);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(506, 39);
            this.txtFirstName.TabIndex = 35;
            // 
            // lblPatientId
            // 
            this.lblPatientId.AutoSize = true;
            this.lblPatientId.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPatientId.Location = new System.Drawing.Point(6, 9);
            this.lblPatientId.Name = "lblPatientId";
            this.lblPatientId.Size = new System.Drawing.Size(128, 33);
            this.lblPatientId.TabIndex = 34;
            this.lblPatientId.Text = "Patient ID";
            // 
            // txtPatientId
            // 
            this.txtPatientId.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPatientId.Location = new System.Drawing.Point(226, 6);
            this.txtPatientId.Name = "txtPatientId";
            this.txtPatientId.Size = new System.Drawing.Size(506, 39);
            this.txtPatientId.TabIndex = 33;
            // 
            // btnFindPatients
            // 
            this.btnFindPatients.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnFindPatients.BorderRadius = 18;
            this.btnFindPatients.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnFindPatients.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnFindPatients.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnFindPatients.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnFindPatients.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFindPatients.ForeColor = System.Drawing.Color.White;
            this.btnFindPatients.Location = new System.Drawing.Point(1305, 212);
            this.btnFindPatients.Name = "btnFindPatients";
            this.btnFindPatients.Size = new System.Drawing.Size(141, 50);
            this.btnFindPatients.TabIndex = 32;
            this.btnFindPatients.Text = "Find";
            // 
            // btnDeletePatients
            // 
            this.btnDeletePatients.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnDeletePatients.BorderRadius = 18;
            this.btnDeletePatients.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeletePatients.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeletePatients.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeletePatients.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeletePatients.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeletePatients.ForeColor = System.Drawing.Color.White;
            this.btnDeletePatients.Location = new System.Drawing.Point(906, 212);
            this.btnDeletePatients.Name = "btnDeletePatients";
            this.btnDeletePatients.Size = new System.Drawing.Size(141, 50);
            this.btnDeletePatients.TabIndex = 31;
            this.btnDeletePatients.Text = "Delete";
            // 
            // btnEditPatients
            // 
            this.btnEditPatients.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnEditPatients.BorderRadius = 18;
            this.btnEditPatients.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditPatients.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditPatients.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditPatients.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditPatients.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditPatients.ForeColor = System.Drawing.Color.White;
            this.btnEditPatients.Location = new System.Drawing.Point(507, 212);
            this.btnEditPatients.Name = "btnEditPatients";
            this.btnEditPatients.Size = new System.Drawing.Size(141, 50);
            this.btnEditPatients.TabIndex = 30;
            this.btnEditPatients.Text = "Edit";
            // 
            // btnAddPatients
            // 
            this.btnAddPatients.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddPatients.BorderRadius = 18;
            this.btnAddPatients.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPatients.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPatients.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPatients.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddPatients.Font = new System.Drawing.Font("Times New Roman", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPatients.ForeColor = System.Drawing.Color.White;
            this.btnAddPatients.Location = new System.Drawing.Point(108, 212);
            this.btnAddPatients.Name = "btnAddPatients";
            this.btnAddPatients.Size = new System.Drawing.Size(141, 50);
            this.btnAddPatients.TabIndex = 29;
            this.btnAddPatients.Text = "Add";
            this.btnAddPatients.Click += new System.EventHandler(this.btnAddPatients_Click);
            // 
            // panelFoot
            // 
            this.panelFoot.Controls.Add(this.dgvManagePatients);
            this.panelFoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFoot.Location = new System.Drawing.Point(0, 338);
            this.panelFoot.Name = "panelFoot";
            this.panelFoot.Size = new System.Drawing.Size(1593, 509);
            this.panelFoot.TabIndex = 28;
            // 
            // dgvManagePatients
            // 
            this.dgvManagePatients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvManagePatients.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvManagePatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvManagePatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagePatients.Location = new System.Drawing.Point(12, 15);
            this.dgvManagePatients.Name = "dgvManagePatients";
            this.dgvManagePatients.RowHeadersWidth = 51;
            this.dgvManagePatients.RowTemplate.Height = 24;
            this.dgvManagePatients.Size = new System.Drawing.Size(1569, 478);
            this.dgvManagePatients.TabIndex = 61;
            this.dgvManagePatients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManagePatients_CellClick);
            this.dgvManagePatients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvManagePatients_CellContentClick);
            // 
            // dtpDateOfBirth
            // 
            this.dtpDateOfBirth.Font = new System.Drawing.Font("Times New Roman", 16.2F);
            this.dtpDateOfBirth.Location = new System.Drawing.Point(226, 150);
            this.dtpDateOfBirth.Name = "dtpDateOfBirth";
            this.dtpDateOfBirth.Size = new System.Drawing.Size(506, 39);
            this.dtpDateOfBirth.TabIndex = 51;
            // 
            // frmManagePatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1593, 847);
            this.Controls.Add(this.panelFoot);
            this.Controls.Add(this.panelBody);
            this.Controls.Add(this.pnlHead);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmManagePatients";
            this.Text = "frmManagePatients";
            this.Load += new System.EventHandler(this.frmManagePatients_Load);
            this.pnlHead.ResumeLayout(false);
            this.panelBody.ResumeLayout(false);
            this.panelBody.PerformLayout();
            this.panelFoot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagePatients)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private System.Windows.Forms.Panel pnlHead;
        private System.Windows.Forms.Panel panelBody;
        private Guna.UI2.WinForms.Guna2Button btnFindPatients;
        private Guna.UI2.WinForms.Guna2Button btnDeletePatients;
        private Guna.UI2.WinForms.Guna2Button btnEditPatients;
        private Guna.UI2.WinForms.Guna2Button btnAddPatients;
        private System.Windows.Forms.Label lblPatientId;
        private System.Windows.Forms.TextBox txtPatientId;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblDateOfBirth;
        private System.Windows.Forms.Label lblSocialSecurityNumber;
        private System.Windows.Forms.TextBox txtSocialSecurityNumber;
        private System.Windows.Forms.Label AddressPatients;
        private System.Windows.Forms.TextBox txtAddressPatients;
        private System.Windows.Forms.Label lblPhoneNumber;
        private System.Windows.Forms.TextBox txtPhoneNumber;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.ComboBox cboGender;
        private System.Windows.Forms.Panel panelFoot;
        private System.Windows.Forms.DataGridView dgvManagePatients;
        private System.Windows.Forms.DateTimePicker dtpDateOfBirth;
    }
}
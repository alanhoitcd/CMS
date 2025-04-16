namespace CMS.GUI
{
    partial class frmCreateAccount
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
            this.panelIMG = new System.Windows.Forms.Panel();
            this.ptbSignUp = new System.Windows.Forms.PictureBox();
            this.panelMain = new System.Windows.Forms.Panel();
            this.cboSecurityQuestion = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSecurityAnswer = new System.Windows.Forms.Label();
            this.txtSecurityAnswer = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.cboUsersRole = new Guna.UI2.WinForms.Guna2ComboBox();
            this.lblSecurityQuestion = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblUsersRole = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new Guna.UI2.WinForms.Guna2TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnSignUp = new Guna.UI2.WinForms.Guna2Button();
            this.txtUserName = new Guna.UI2.WinForms.Guna2TextBox();
            this.btnClose = new Guna.UI2.WinForms.Guna2CircleButton();
            this.lblSigup = new System.Windows.Forms.Label();
            this.panelIMG.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbSignUp)).BeginInit();
            this.panelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelIMG
            // 
            this.panelIMG.BackColor = System.Drawing.Color.Transparent;
            this.panelIMG.Controls.Add(this.ptbSignUp);
            this.panelIMG.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIMG.Location = new System.Drawing.Point(0, 0);
            this.panelIMG.Name = "panelIMG";
            this.panelIMG.Size = new System.Drawing.Size(396, 576);
            this.panelIMG.TabIndex = 19;
            // 
            // ptbSignUp
            // 
            this.ptbSignUp.BackColor = System.Drawing.Color.White;
            this.ptbSignUp.Location = new System.Drawing.Point(10, 10);
            this.ptbSignUp.Name = "ptbSignUp";
            this.ptbSignUp.Size = new System.Drawing.Size(375, 554);
            this.ptbSignUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbSignUp.TabIndex = 6;
            this.ptbSignUp.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.Transparent;
            this.panelMain.Controls.Add(this.cboSecurityQuestion);
            this.panelMain.Controls.Add(this.lblSecurityAnswer);
            this.panelMain.Controls.Add(this.txtSecurityAnswer);
            this.panelMain.Controls.Add(this.lblConfirmPassword);
            this.panelMain.Controls.Add(this.txtConfirmPassword);
            this.panelMain.Controls.Add(this.cboUsersRole);
            this.panelMain.Controls.Add(this.lblSecurityQuestion);
            this.panelMain.Controls.Add(this.lblEmail);
            this.panelMain.Controls.Add(this.txtEmail);
            this.panelMain.Controls.Add(this.lblUsersRole);
            this.panelMain.Controls.Add(this.lblPassword);
            this.panelMain.Controls.Add(this.txtPassword);
            this.panelMain.Controls.Add(this.lblUserName);
            this.panelMain.Controls.Add(this.btnSignUp);
            this.panelMain.Controls.Add(this.txtUserName);
            this.panelMain.Controls.Add(this.btnClose);
            this.panelMain.Controls.Add(this.lblSigup);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(396, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(638, 576);
            this.panelMain.TabIndex = 20;
            // 
            // cboSecurityQuestion
            // 
            this.cboSecurityQuestion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboSecurityQuestion.BackColor = System.Drawing.Color.Transparent;
            this.cboSecurityQuestion.BorderRadius = 20;
            this.cboSecurityQuestion.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboSecurityQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSecurityQuestion.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSecurityQuestion.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboSecurityQuestion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboSecurityQuestion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboSecurityQuestion.ItemHeight = 30;
            this.cboSecurityQuestion.Location = new System.Drawing.Point(222, 385);
            this.cboSecurityQuestion.Name = "cboSecurityQuestion";
            this.cboSecurityQuestion.Size = new System.Drawing.Size(367, 36);
            this.cboSecurityQuestion.TabIndex = 36;
            // 
            // lblSecurityAnswer
            // 
            this.lblSecurityAnswer.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSecurityAnswer.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblSecurityAnswer.Location = new System.Drawing.Point(46, 442);
            this.lblSecurityAnswer.Name = "lblSecurityAnswer";
            this.lblSecurityAnswer.Size = new System.Drawing.Size(170, 36);
            this.lblSecurityAnswer.TabIndex = 35;
            this.lblSecurityAnswer.Text = "Security Answer";
            this.lblSecurityAnswer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSecurityAnswer
            // 
            this.txtSecurityAnswer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSecurityAnswer.Animated = true;
            this.txtSecurityAnswer.BorderRadius = 20;
            this.txtSecurityAnswer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSecurityAnswer.DefaultText = "";
            this.txtSecurityAnswer.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtSecurityAnswer.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtSecurityAnswer.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSecurityAnswer.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtSecurityAnswer.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSecurityAnswer.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtSecurityAnswer.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtSecurityAnswer.Location = new System.Drawing.Point(223, 442);
            this.txtSecurityAnswer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSecurityAnswer.Name = "txtSecurityAnswer";
            this.txtSecurityAnswer.PlaceholderText = "Enter Security Answer";
            this.txtSecurityAnswer.SelectedText = "";
            this.txtSecurityAnswer.Size = new System.Drawing.Size(367, 36);
            this.txtSecurityAnswer.TabIndex = 34;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblConfirmPassword.Location = new System.Drawing.Point(46, 214);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(170, 36);
            this.lblConfirmPassword.TabIndex = 33;
            this.lblConfirmPassword.Text = "Confirm Password";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmPassword.Animated = true;
            this.txtConfirmPassword.BorderRadius = 20;
            this.txtConfirmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtConfirmPassword.DefaultText = "";
            this.txtConfirmPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtConfirmPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtConfirmPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtConfirmPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtConfirmPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtConfirmPassword.Location = new System.Drawing.Point(223, 214);
            this.txtConfirmPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PlaceholderText = "Enter Confirm Password";
            this.txtConfirmPassword.SelectedText = "";
            this.txtConfirmPassword.Size = new System.Drawing.Size(367, 36);
            this.txtConfirmPassword.TabIndex = 32;
            // 
            // cboUsersRole
            // 
            this.cboUsersRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cboUsersRole.BackColor = System.Drawing.Color.Transparent;
            this.cboUsersRole.BorderRadius = 20;
            this.cboUsersRole.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboUsersRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUsersRole.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboUsersRole.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.cboUsersRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboUsersRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(88)))), ((int)(((byte)(112)))));
            this.cboUsersRole.ItemHeight = 30;
            this.cboUsersRole.Location = new System.Drawing.Point(223, 271);
            this.cboUsersRole.Name = "cboUsersRole";
            this.cboUsersRole.Size = new System.Drawing.Size(367, 36);
            this.cboUsersRole.TabIndex = 31;
            // 
            // lblSecurityQuestion
            // 
            this.lblSecurityQuestion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSecurityQuestion.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblSecurityQuestion.Location = new System.Drawing.Point(46, 385);
            this.lblSecurityQuestion.Name = "lblSecurityQuestion";
            this.lblSecurityQuestion.Size = new System.Drawing.Size(170, 36);
            this.lblSecurityQuestion.TabIndex = 30;
            this.lblSecurityQuestion.Text = "Security Question";
            this.lblSecurityQuestion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEmail
            // 
            this.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEmail.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblEmail.Location = new System.Drawing.Point(46, 328);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(170, 36);
            this.lblEmail.TabIndex = 28;
            this.lblEmail.Text = "Email";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Animated = true;
            this.txtEmail.BorderRadius = 20;
            this.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtEmail.DefaultText = "";
            this.txtEmail.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtEmail.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtEmail.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtEmail.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtEmail.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtEmail.Location = new System.Drawing.Point(223, 328);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.PlaceholderText = "Enter Email";
            this.txtEmail.SelectedText = "";
            this.txtEmail.Size = new System.Drawing.Size(367, 36);
            this.txtEmail.TabIndex = 27;
            // 
            // lblUsersRole
            // 
            this.lblUsersRole.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUsersRole.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblUsersRole.Location = new System.Drawing.Point(46, 271);
            this.lblUsersRole.Name = "lblUsersRole";
            this.lblUsersRole.Size = new System.Drawing.Size(170, 36);
            this.lblUsersRole.TabIndex = 26;
            this.lblUsersRole.Text = "Users Role";
            this.lblUsersRole.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPassword.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblPassword.Location = new System.Drawing.Point(46, 157);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(170, 36);
            this.lblPassword.TabIndex = 25;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Animated = true;
            this.txtPassword.BorderRadius = 20;
            this.txtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPassword.DefaultText = "";
            this.txtPassword.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtPassword.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtPassword.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtPassword.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtPassword.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtPassword.Location = new System.Drawing.Point(223, 157);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PlaceholderText = "Enter Password";
            this.txtPassword.SelectedText = "";
            this.txtPassword.Size = new System.Drawing.Size(367, 36);
            this.txtPassword.TabIndex = 24;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblUserName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.lblUserName.Location = new System.Drawing.Point(46, 100);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(170, 36);
            this.lblUserName.TabIndex = 23;
            this.lblUserName.Text = "User Name";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Animated = true;
            this.btnSignUp.BorderRadius = 18;
            this.btnSignUp.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnSignUp.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnSignUp.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnSignUp.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnSignUp.FillColor = System.Drawing.Color.RoyalBlue;
            this.btnSignUp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold);
            this.btnSignUp.ForeColor = System.Drawing.Color.White;
            this.btnSignUp.Location = new System.Drawing.Point(137, 504);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(392, 35);
            this.btnSignUp.TabIndex = 22;
            this.btnSignUp.Text = "Sign up";
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Animated = true;
            this.txtUserName.BorderRadius = 20;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtUserName.DefaultText = "";
            this.txtUserName.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtUserName.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtUserName.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtUserName.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.txtUserName.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtUserName.Location = new System.Drawing.Point(223, 100);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.PlaceholderText = "Enter User Name";
            this.txtUserName.SelectedText = "";
            this.txtUserName.Size = new System.Drawing.Size(367, 36);
            this.txtUserName.TabIndex = 21;
            // 
            // btnClose
            // 
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
            this.btnClose.Location = new System.Drawing.Point(591, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedColor = System.Drawing.Color.Transparent;
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.Size = new System.Drawing.Size(44, 43);
            this.btnClose.TabIndex = 20;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblSigup
            // 
            this.lblSigup.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSigup.Font = new System.Drawing.Font("Times New Roman", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSigup.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblSigup.Location = new System.Drawing.Point(0, 0);
            this.lblSigup.Name = "lblSigup";
            this.lblSigup.Size = new System.Drawing.Size(638, 85);
            this.lblSigup.TabIndex = 19;
            this.lblSigup.Text = "Sigup";
            this.lblSigup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmCreateAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 576);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelIMG);
            this.Font = new System.Drawing.Font("Times New Roman", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmCreateAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCreateAccount";
            this.Load += new System.EventHandler(this.frmCreateAccount_Load);
            this.panelIMG.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ptbSignUp)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelIMG;
        private System.Windows.Forms.PictureBox ptbSignUp;
        private System.Windows.Forms.Panel panelMain;
        private Guna.UI2.WinForms.Guna2ComboBox cboUsersRole;
        private System.Windows.Forms.Label lblSecurityQuestion;
        private System.Windows.Forms.Label lblEmail;
        private Guna.UI2.WinForms.Guna2TextBox txtEmail;
        private System.Windows.Forms.Label lblUsersRole;
        private System.Windows.Forms.Label lblPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtPassword;
        private System.Windows.Forms.Label lblUserName;
        private Guna.UI2.WinForms.Guna2Button btnSignUp;
        private Guna.UI2.WinForms.Guna2TextBox txtUserName;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private System.Windows.Forms.Label lblSigup;
        private System.Windows.Forms.Label lblConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblSecurityAnswer;
        private Guna.UI2.WinForms.Guna2TextBox txtSecurityAnswer;
        private Guna.UI2.WinForms.Guna2ComboBox cboSecurityQuestion;
    }
}
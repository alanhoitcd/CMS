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
            this.btnAddPatients = new Guna.UI2.WinForms.Guna2Button();
            this.btnEditPatients = new Guna.UI2.WinForms.Guna2Button();
            this.dgvManagePatients = new System.Windows.Forms.DataGridView();
            this.pnlHead = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagePatients)).BeginInit();
            this.pnlHead.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(345, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage Patients";
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Black;
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
            this.btnClose.Location = new System.Drawing.Point(759, 172);
            this.btnClose.Name = "btnClose";
            this.btnClose.PressedColor = System.Drawing.Color.Transparent;
            this.btnClose.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            this.btnClose.Size = new System.Drawing.Size(44, 43);
            this.btnClose.TabIndex = 21;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddPatients
            // 
            this.btnAddPatients.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPatients.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnAddPatients.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnAddPatients.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnAddPatients.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAddPatients.ForeColor = System.Drawing.Color.White;
            this.btnAddPatients.Location = new System.Drawing.Point(30, 170);
            this.btnAddPatients.Name = "btnAddPatients";
            this.btnAddPatients.Size = new System.Drawing.Size(180, 45);
            this.btnAddPatients.TabIndex = 22;
            this.btnAddPatients.Text = "Add";
            // 
            // btnEditPatients
            // 
            this.btnEditPatients.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnEditPatients.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnEditPatients.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnEditPatients.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnEditPatients.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnEditPatients.ForeColor = System.Drawing.Color.White;
            this.btnEditPatients.Location = new System.Drawing.Point(317, 170);
            this.btnEditPatients.Name = "btnEditPatients";
            this.btnEditPatients.Size = new System.Drawing.Size(180, 45);
            this.btnEditPatients.TabIndex = 23;
            this.btnEditPatients.Text = "Edit";
            // 
            // dgvManagePatients
            // 
            this.dgvManagePatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManagePatients.Location = new System.Drawing.Point(50, 259);
            this.dgvManagePatients.Name = "dgvManagePatients";
            this.dgvManagePatients.RowHeadersWidth = 51;
            this.dgvManagePatients.RowTemplate.Height = 24;
            this.dgvManagePatients.Size = new System.Drawing.Size(240, 150);
            this.dgvManagePatients.TabIndex = 24;
            // 
            // pnlHead
            // 
            this.pnlHead.BackColor = System.Drawing.Color.Transparent;
            this.pnlHead.Controls.Add(this.label1);
            this.pnlHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHead.Location = new System.Drawing.Point(0, 0);
            this.pnlHead.Name = "pnlHead";
            this.pnlHead.Size = new System.Drawing.Size(900, 80);
            this.pnlHead.TabIndex = 25;
            // 
            // frmManagePatients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 534);
            this.Controls.Add(this.pnlHead);
            this.Controls.Add(this.dgvManagePatients);
            this.Controls.Add(this.btnEditPatients);
            this.Controls.Add(this.btnAddPatients);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmManagePatients";
            this.Text = "frmManagePatients";
            this.Load += new System.EventHandler(this.frmManagePatients_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManagePatients)).EndInit();
            this.pnlHead.ResumeLayout(false);
            this.pnlHead.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2CircleButton btnClose;
        private Guna.UI2.WinForms.Guna2Button btnAddPatients;
        private Guna.UI2.WinForms.Guna2Button btnEditPatients;
        private System.Windows.Forms.DataGridView dgvManagePatients;
        private System.Windows.Forms.Panel pnlHead;
    }
}
namespace OJT_Project
{
    partial class loginForm
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
            this.tbl_controls = new System.Windows.Forms.TableLayoutPanel();
            this.tbx_username = new System.Windows.Forms.TextBox();
            this.tbx_password = new System.Windows.Forms.TextBox();
            this.lbl_username = new System.Windows.Forms.Label();
            this.lbl_password = new System.Windows.Forms.Label();
            this.btn_login = new System.Windows.Forms.Button();
            this.lbl_permissionsLevel = new System.Windows.Forms.Label();
            this.cbx_permissionLevel = new System.Windows.Forms.ComboBox();
            this.lbl_forgotPassword = new System.Windows.Forms.LinkLabel();
            this.lbl_validationCheck = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tbl_controls.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbl_controls
            // 
            this.tbl_controls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbl_controls.ColumnCount = 3;
            this.tbl_controls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.73254F));
            this.tbl_controls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.7006F));
            this.tbl_controls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.56687F));
            this.tbl_controls.Controls.Add(this.tbx_username, 1, 0);
            this.tbl_controls.Controls.Add(this.tbx_password, 1, 1);
            this.tbl_controls.Controls.Add(this.lbl_username, 0, 0);
            this.tbl_controls.Controls.Add(this.lbl_password, 0, 1);
            this.tbl_controls.Controls.Add(this.btn_login, 1, 3);
            this.tbl_controls.Controls.Add(this.lbl_permissionsLevel, 0, 2);
            this.tbl_controls.Controls.Add(this.cbx_permissionLevel, 1, 2);
            this.tbl_controls.Controls.Add(this.lbl_forgotPassword, 0, 4);
            this.tbl_controls.Location = new System.Drawing.Point(12, 64);
            this.tbl_controls.Name = "tbl_controls";
            this.tbl_controls.RowCount = 5;
            this.tbl_controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tbl_controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tbl_controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tbl_controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23F));
            this.tbl_controls.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tbl_controls.Size = new System.Drawing.Size(500, 252);
            this.tbl_controls.TabIndex = 0;
            this.tbl_controls.Paint += new System.Windows.Forms.PaintEventHandler(this.tbl_controls_Paint);
            // 
            // tbx_username
            // 
            this.tbx_username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_username.Location = new System.Drawing.Point(171, 16);
            this.tbx_username.Name = "tbx_username";
            this.tbx_username.Size = new System.Drawing.Size(242, 25);
            this.tbx_username.TabIndex = 1;
            // 
            // tbx_password
            // 
            this.tbx_password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tbx_password.Location = new System.Drawing.Point(171, 73);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.Size = new System.Drawing.Size(242, 25);
            this.tbx_password.TabIndex = 2;
            this.tbx_password.UseSystemPasswordChar = true;
            // 
            // lbl_username
            // 
            this.lbl_username.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(95, 20);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(70, 17);
            this.lbl_username.TabIndex = 3;
            this.lbl_username.Text = "Username:";
            // 
            // lbl_password
            // 
            this.lbl_password.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(98, 77);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(67, 17);
            this.lbl_password.TabIndex = 4;
            this.lbl_password.Text = "Password:";
            // 
            // btn_login
            // 
            this.btn_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btn_login.Location = new System.Drawing.Point(251, 184);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(82, 31);
            this.btn_login.TabIndex = 1;
            this.btn_login.Text = "Log-In";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // lbl_permissionsLevel
            // 
            this.lbl_permissionsLevel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_permissionsLevel.AutoSize = true;
            this.lbl_permissionsLevel.Location = new System.Drawing.Point(52, 134);
            this.lbl_permissionsLevel.Name = "lbl_permissionsLevel";
            this.lbl_permissionsLevel.Size = new System.Drawing.Size(113, 17);
            this.lbl_permissionsLevel.TabIndex = 5;
            this.lbl_permissionsLevel.Text = "Permissions Level:";
            // 
            // cbx_permissionLevel
            // 
            this.cbx_permissionLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_permissionLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_permissionLevel.FormattingEnabled = true;
            this.cbx_permissionLevel.Items.AddRange(new object[] {
            "User",
            "Dept. Head",
            "Admin"});
            this.cbx_permissionLevel.Location = new System.Drawing.Point(171, 132);
            this.cbx_permissionLevel.Name = "cbx_permissionLevel";
            this.cbx_permissionLevel.Size = new System.Drawing.Size(242, 25);
            this.cbx_permissionLevel.TabIndex = 6;
            // 
            // lbl_forgotPassword
            // 
            this.lbl_forgotPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_forgotPassword.AutoSize = true;
            this.lbl_forgotPassword.Location = new System.Drawing.Point(3, 228);
            this.lbl_forgotPassword.Name = "lbl_forgotPassword";
            this.lbl_forgotPassword.Size = new System.Drawing.Size(162, 24);
            this.lbl_forgotPassword.TabIndex = 7;
            this.lbl_forgotPassword.TabStop = true;
            this.lbl_forgotPassword.Text = "Forgot your password?";
            this.lbl_forgotPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbl_forgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_forgotPassword_LinkClicked);
            // 
            // lbl_validationCheck
            // 
            this.lbl_validationCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_validationCheck.AutoSize = true;
            this.lbl_validationCheck.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_validationCheck.ForeColor = System.Drawing.Color.Red;
            this.lbl_validationCheck.Location = new System.Drawing.Point(3, 5);
            this.lbl_validationCheck.Name = "lbl_validationCheck";
            this.lbl_validationCheck.Size = new System.Drawing.Size(494, 30);
            this.lbl_validationCheck.TabIndex = 1;
            this.lbl_validationCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbl_validationCheck, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 322);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 40);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // loginForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(524, 374);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tbl_controls);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "loginForm";
            this.Resizable = false;
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "Login Form";
            this.Load += new System.EventHandler(this.loginForm_Load);
            this.tbl_controls.ResumeLayout(false);
            this.tbl_controls.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tbl_controls;
        private System.Windows.Forms.TextBox tbx_username;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox tbx_password;
        private System.Windows.Forms.Label lbl_username;
        private System.Windows.Forms.Label lbl_password;
        private System.Windows.Forms.Label lbl_permissionsLevel;
        private System.Windows.Forms.ComboBox cbx_permissionLevel;
        private System.Windows.Forms.Label lbl_validationCheck;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.LinkLabel lbl_forgotPassword;
    }
}


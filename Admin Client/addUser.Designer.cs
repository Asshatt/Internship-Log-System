namespace OJT_Project.Admin_Client
{
    partial class userRegistration
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_addUser = new System.Windows.Forms.Button();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_role = new System.Windows.Forms.ComboBox();
            this.tbx_username = new System.Windows.Forms.TextBox();
            this.tbx_email = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tbx_password = new System.Windows.Forms.TextBox();
            this.btn_generatePassword = new System.Windows.Forms.Button();
            this.lbl_role = new System.Windows.Forms.Label();
            this.lbl_department = new System.Windows.Forms.Label();
            this.cbx_department = new System.Windows.Forms.ComboBox();
            this.cbx_permissions = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 299);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btn_cancel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_addUser, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(76, 257);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(408, 39);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_cancel.Location = new System.Drawing.Point(237, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(137, 33);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_addUser
            // 
            this.btn_addUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_addUser.Location = new System.Drawing.Point(33, 3);
            this.btn_addUser.Name = "btn_addUser";
            this.btn_addUser.Size = new System.Drawing.Size(137, 33);
            this.btn_addUser.TabIndex = 0;
            this.btn_addUser.Text = "Add User";
            this.btn_addUser.UseVisualStyleBackColor = true;
            this.btn_addUser.Click += new System.EventHandler(this.btn_addUser_Click);
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.cbx_role, 1, 5);
            this.tableLayoutPanel4.Controls.Add(this.tbx_username, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tbx_email, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.lbl_role, 0, 5);
            this.tableLayoutPanel4.Controls.Add(this.lbl_department, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.cbx_department, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.cbx_permissions, 1, 3);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 12);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(554, 229);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 21);
            this.label3.TabIndex = 5;
            this.label3.Text = "Permissions Level:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // cbx_role
            // 
            this.cbx_role.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbx_role.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_role.DropDownWidth = 300;
            this.cbx_role.FormattingEnabled = true;
            this.cbx_role.Location = new System.Drawing.Point(210, 199);
            this.cbx_role.Name = "cbx_role";
            this.cbx_role.Size = new System.Drawing.Size(236, 29);
            this.cbx_role.TabIndex = 7;
            // 
            // tbx_username
            // 
            this.tbx_username.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbx_username.Location = new System.Drawing.Point(210, 4);
            this.tbx_username.Name = "tbx_username";
            this.tbx_username.Size = new System.Drawing.Size(170, 29);
            this.tbx_username.TabIndex = 1;
            // 
            // tbx_email
            // 
            this.tbx_email.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbx_email.Location = new System.Drawing.Point(210, 42);
            this.tbx_email.Name = "tbx_email";
            this.tbx_email.Size = new System.Drawing.Size(236, 29);
            this.tbx_email.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Email Address:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 21);
            this.label5.TabIndex = 8;
            this.label5.Text = "Password";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 57.52213F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 42.47787F));
            this.tableLayoutPanel2.Controls.Add(this.tbx_password, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_generatePassword, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(207, 76);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(347, 38);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // tbx_password
            // 
            this.tbx_password.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbx_password.Location = new System.Drawing.Point(3, 4);
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.Size = new System.Drawing.Size(170, 29);
            this.tbx_password.TabIndex = 10;
            // 
            // btn_generatePassword
            // 
            this.btn_generatePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_generatePassword.Location = new System.Drawing.Point(220, 3);
            this.btn_generatePassword.Name = "btn_generatePassword";
            this.btn_generatePassword.Size = new System.Drawing.Size(105, 32);
            this.btn_generatePassword.TabIndex = 11;
            this.btn_generatePassword.Text = "Generate";
            this.btn_generatePassword.UseVisualStyleBackColor = true;
            this.btn_generatePassword.Click += new System.EventHandler(this.btn_generatePassword_Click);
            // 
            // lbl_role
            // 
            this.lbl_role.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_role.AutoSize = true;
            this.lbl_role.Location = new System.Drawing.Point(93, 199);
            this.lbl_role.Name = "lbl_role";
            this.lbl_role.Size = new System.Drawing.Size(111, 21);
            this.lbl_role.TabIndex = 6;
            this.lbl_role.Text = "Assigned Role:";
            // 
            // lbl_department
            // 
            this.lbl_department.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_department.AutoSize = true;
            this.lbl_department.Location = new System.Drawing.Point(41, 160);
            this.lbl_department.Name = "lbl_department";
            this.lbl_department.Size = new System.Drawing.Size(163, 21);
            this.lbl_department.TabIndex = 4;
            this.lbl_department.Text = "Assigned Department:";
            // 
            // cbx_department
            // 
            this.cbx_department.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbx_department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_department.DropDownWidth = 300;
            this.cbx_department.FormattingEnabled = true;
            this.cbx_department.Location = new System.Drawing.Point(210, 160);
            this.cbx_department.Name = "cbx_department";
            this.cbx_department.Size = new System.Drawing.Size(236, 29);
            this.cbx_department.TabIndex = 5;
            this.cbx_department.SelectedIndexChanged += new System.EventHandler(this.cbx_department_SelectedIndexChanged);
            // 
            // cbx_permissions
            // 
            this.cbx_permissions.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbx_permissions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_permissions.FormattingEnabled = true;
            this.cbx_permissions.Items.AddRange(new object[] {
            "User",
            "Dept. Head",
            "Admin"});
            this.cbx_permissions.Location = new System.Drawing.Point(210, 122);
            this.cbx_permissions.Name = "cbx_permissions";
            this.cbx_permissions.Size = new System.Drawing.Size(170, 29);
            this.cbx_permissions.TabIndex = 10;
            this.cbx_permissions.SelectedIndexChanged += new System.EventHandler(this.cbx_permissions_SelectedIndexChanged);
            // 
            // userRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 374);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "userRegistration";
            this.Resizable = false;
            this.Text = "User Registration";
            this.Load += new System.EventHandler(this.userRegistration_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox tbx_email;
        private System.Windows.Forms.TextBox tbx_username;
        private System.Windows.Forms.ComboBox cbx_department;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_addUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lbl_role;
        private System.Windows.Forms.Label lbl_department;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TextBox tbx_password;
        private System.Windows.Forms.Button btn_generatePassword;
        private System.Windows.Forms.ComboBox cbx_role;
        private System.Windows.Forms.ComboBox cbx_permissions;
        private System.Windows.Forms.Label label3;
    }
}
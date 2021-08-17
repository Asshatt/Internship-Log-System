namespace OJT_Project.Admin_Client
{
    partial class updateUser
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
            this.tbx_email = new System.Windows.Forms.TextBox();
            this.lbl_role = new System.Windows.Forms.Label();
            this.lbl_department = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_role = new System.Windows.Forms.ComboBox();
            this.tbx_username = new System.Windows.Forms.TextBox();
            this.lbl_email = new System.Windows.Forms.Label();
            this.cbx_department = new System.Windows.Forms.ComboBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_updateUser = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_updatePassword = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbx_email
            // 
            this.tbx_email.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbx_email.Location = new System.Drawing.Point(210, 44);
            this.tbx_email.Name = "tbx_email";
            this.tbx_email.Size = new System.Drawing.Size(236, 29);
            this.tbx_email.TabIndex = 3;
            // 
            // lbl_role
            // 
            this.lbl_role.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_role.AutoSize = true;
            this.lbl_role.Location = new System.Drawing.Point(93, 126);
            this.lbl_role.Name = "lbl_role";
            this.lbl_role.Size = new System.Drawing.Size(111, 21);
            this.lbl_role.TabIndex = 6;
            this.lbl_role.Text = "Assigned Role:";
            // 
            // lbl_department
            // 
            this.lbl_department.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_department.AutoSize = true;
            this.lbl_department.Location = new System.Drawing.Point(41, 87);
            this.lbl_department.Name = "lbl_department";
            this.lbl_department.Size = new System.Drawing.Size(163, 21);
            this.lbl_department.TabIndex = 4;
            this.lbl_department.Text = "Assigned Department:";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 9);
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
            this.cbx_role.Location = new System.Drawing.Point(210, 126);
            this.cbx_role.Name = "cbx_role";
            this.cbx_role.Size = new System.Drawing.Size(236, 29);
            this.cbx_role.TabIndex = 7;
            // 
            // tbx_username
            // 
            this.tbx_username.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbx_username.Location = new System.Drawing.Point(210, 5);
            this.tbx_username.Name = "tbx_username";
            this.tbx_username.Size = new System.Drawing.Size(170, 29);
            this.tbx_username.TabIndex = 1;
            // 
            // lbl_email
            // 
            this.lbl_email.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(93, 48);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(111, 21);
            this.lbl_email.TabIndex = 2;
            this.lbl_email.Text = "Email Address:";
            // 
            // cbx_department
            // 
            this.cbx_department.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbx_department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_department.DropDownWidth = 300;
            this.cbx_department.FormattingEnabled = true;
            this.cbx_department.Location = new System.Drawing.Point(210, 87);
            this.cbx_department.Name = "cbx_department";
            this.cbx_department.Size = new System.Drawing.Size(236, 29);
            this.cbx_department.TabIndex = 5;
            this.cbx_department.SelectedIndexChanged += new System.EventHandler(this.cbx_department_SelectedIndexChanged);
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
            // btn_updateUser
            // 
            this.btn_updateUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.btn_updateUser.Location = new System.Drawing.Point(33, 3);
            this.btn_updateUser.Name = "btn_updateUser";
            this.btn_updateUser.Size = new System.Drawing.Size(137, 33);
            this.btn_updateUser.TabIndex = 0;
            this.btn_updateUser.Text = "Update User";
            this.btn_updateUser.UseVisualStyleBackColor = true;
            this.btn_updateUser.Click += new System.EventHandler(this.btn_updateUser_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btn_cancel, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.btn_updateUser, 0, 0);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(76, 257);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(408, 39);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.5F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tbx_username, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.tbx_email, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lbl_email, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.cbx_department, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.lbl_department, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.lbl_role, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.cbx_role, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.btn_updatePassword, 1, 4);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 27);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(554, 199);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // btn_updatePassword
            // 
            this.btn_updatePassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_updatePassword.Location = new System.Drawing.Point(210, 159);
            this.btn_updatePassword.Name = "btn_updatePassword";
            this.btn_updatePassword.Size = new System.Drawing.Size(170, 37);
            this.btn_updatePassword.TabIndex = 8;
            this.btn_updatePassword.Text = "Change Password";
            this.btn_updatePassword.UseVisualStyleBackColor = true;
            this.btn_updatePassword.Click += new System.EventHandler(this.btn_updatePassword_Click);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(11, 63);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 299);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // updateUser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(584, 374);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.MaximizeBox = false;
            this.Name = "updateUser";
            this.Resizable = false;
            this.Text = "Update User Information";
            this.Load += new System.EventHandler(this.updateUser_Load);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbx_email;
        private System.Windows.Forms.Label lbl_role;
        private System.Windows.Forms.Label lbl_department;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_role;
        private System.Windows.Forms.TextBox tbx_username;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.ComboBox cbx_department;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_updateUser;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btn_updatePassword;
    }
}
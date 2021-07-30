namespace OJT_Project.Admin_Client
{
    partial class editUser
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
            this.tcl_userCategory = new System.Windows.Forms.TabControl();
            this.tbp_users = new System.Windows.Forms.TabPage();
            this.tcl_users = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbp_deptHeads = new System.Windows.Forms.TabPage();
            this.flp_deptHeads = new System.Windows.Forms.FlowLayoutPanel();
            this.tbp_admins = new System.Windows.Forms.TabPage();
            this.flp_admins = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_updateUser = new System.Windows.Forms.Button();
            this.btn_addTask = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_removeUser = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tcl_userCategory.SuspendLayout();
            this.tbp_users.SuspendLayout();
            this.tcl_users.SuspendLayout();
            this.tbp_deptHeads.SuspendLayout();
            this.tbp_admins.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.77702F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.22297F));
            this.tableLayoutPanel1.Controls.Add(this.tcl_userCategory, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 64);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(538, 421);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tcl_userCategory
            // 
            this.tcl_userCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcl_userCategory.Controls.Add(this.tbp_users);
            this.tcl_userCategory.Controls.Add(this.tbp_deptHeads);
            this.tcl_userCategory.Controls.Add(this.tbp_admins);
            this.tcl_userCategory.Location = new System.Drawing.Point(3, 4);
            this.tcl_userCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcl_userCategory.Name = "tcl_userCategory";
            this.tcl_userCategory.SelectedIndex = 0;
            this.tcl_userCategory.Size = new System.Drawing.Size(374, 413);
            this.tcl_userCategory.TabIndex = 1;
            // 
            // tbp_users
            // 
            this.tbp_users.BackColor = System.Drawing.Color.Silver;
            this.tbp_users.Controls.Add(this.tcl_users);
            this.tbp_users.Location = new System.Drawing.Point(4, 26);
            this.tbp_users.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbp_users.Name = "tbp_users";
            this.tbp_users.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_users.Size = new System.Drawing.Size(366, 383);
            this.tbp_users.TabIndex = 0;
            this.tbp_users.Text = "Users";
            // 
            // tcl_users
            // 
            this.tcl_users.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcl_users.Controls.Add(this.tabPage1);
            this.tcl_users.Location = new System.Drawing.Point(6, 6);
            this.tcl_users.Name = "tcl_users";
            this.tcl_users.SelectedIndex = 0;
            this.tcl_users.Size = new System.Drawing.Size(354, 371);
            this.tcl_users.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(346, 341);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbp_deptHeads
            // 
            this.tbp_deptHeads.BackColor = System.Drawing.Color.Silver;
            this.tbp_deptHeads.Controls.Add(this.flp_deptHeads);
            this.tbp_deptHeads.Location = new System.Drawing.Point(4, 26);
            this.tbp_deptHeads.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbp_deptHeads.Name = "tbp_deptHeads";
            this.tbp_deptHeads.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_deptHeads.Size = new System.Drawing.Size(373, 404);
            this.tbp_deptHeads.TabIndex = 1;
            this.tbp_deptHeads.Text = "Dept. Heads";
            // 
            // flp_deptHeads
            // 
            this.flp_deptHeads.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flp_deptHeads.AutoScroll = true;
            this.flp_deptHeads.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_deptHeads.Location = new System.Drawing.Point(6, 7);
            this.flp_deptHeads.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flp_deptHeads.Name = "flp_deptHeads";
            this.flp_deptHeads.Size = new System.Drawing.Size(361, 390);
            this.flp_deptHeads.TabIndex = 2;
            // 
            // tbp_admins
            // 
            this.tbp_admins.BackColor = System.Drawing.Color.Silver;
            this.tbp_admins.Controls.Add(this.flp_admins);
            this.tbp_admins.Location = new System.Drawing.Point(4, 26);
            this.tbp_admins.Name = "tbp_admins";
            this.tbp_admins.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_admins.Size = new System.Drawing.Size(373, 404);
            this.tbp_admins.TabIndex = 2;
            this.tbp_admins.Text = "Admins";
            // 
            // flp_admins
            // 
            this.flp_admins.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flp_admins.AutoScroll = true;
            this.flp_admins.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_admins.Location = new System.Drawing.Point(6, 7);
            this.flp_admins.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flp_admins.Name = "flp_admins";
            this.flp_admins.Size = new System.Drawing.Size(361, 390);
            this.flp_admins.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btn_updateUser, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_addTask, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_cancel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn_removeUser, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(383, 116);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(152, 188);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btn_updateUser
            // 
            this.btn_updateUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_updateUser.Location = new System.Drawing.Point(3, 50);
            this.btn_updateUser.Name = "btn_updateUser";
            this.btn_updateUser.Size = new System.Drawing.Size(146, 41);
            this.btn_updateUser.TabIndex = 2;
            this.btn_updateUser.Text = "Update";
            this.btn_updateUser.UseVisualStyleBackColor = true;
            this.btn_updateUser.Click += new System.EventHandler(this.btn_updateUser_Click);
            // 
            // btn_addTask
            // 
            this.btn_addTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addTask.Location = new System.Drawing.Point(3, 3);
            this.btn_addTask.Name = "btn_addTask";
            this.btn_addTask.Size = new System.Drawing.Size(146, 41);
            this.btn_addTask.TabIndex = 1;
            this.btn_addTask.Text = "Add";
            this.btn_addTask.UseVisualStyleBackColor = true;
            this.btn_addTask.Click += new System.EventHandler(this.btn_addTask_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Location = new System.Drawing.Point(3, 144);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(146, 41);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_removeUser
            // 
            this.btn_removeUser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_removeUser.Location = new System.Drawing.Point(3, 97);
            this.btn_removeUser.Name = "btn_removeUser";
            this.btn_removeUser.Size = new System.Drawing.Size(146, 41);
            this.btn_removeUser.TabIndex = 0;
            this.btn_removeUser.Text = "Remove";
            this.btn_removeUser.UseVisualStyleBackColor = true;
            this.btn_removeUser.Click += new System.EventHandler(this.btn_removeUser_Click);
            // 
            // editUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 519);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "editUser";
            this.Text = "User Editor";
            this.Load += new System.EventHandler(this.deleteUser_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tcl_userCategory.ResumeLayout(false);
            this.tbp_users.ResumeLayout(false);
            this.tcl_users.ResumeLayout(false);
            this.tbp_deptHeads.ResumeLayout(false);
            this.tbp_admins.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tcl_userCategory;
        private System.Windows.Forms.TabPage tbp_users;
        private System.Windows.Forms.TabPage tbp_deptHeads;
        private System.Windows.Forms.TabPage tbp_admins;
        private System.Windows.Forms.FlowLayoutPanel flp_deptHeads;
        private System.Windows.Forms.FlowLayoutPanel flp_admins;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_removeUser;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_addTask;
        private System.Windows.Forms.TabControl tcl_users;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btn_updateUser;
    }
}
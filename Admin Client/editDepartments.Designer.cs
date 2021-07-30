namespace OJT_Project.Admin_Client
{
    partial class editDepartments
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
            this.tcl_departments = new System.Windows.Forms.TabControl();
            this.tbp_admins = new System.Windows.Forms.TabPage();
            this.flp_departments = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_updateDepartment = new System.Windows.Forms.Button();
            this.btn_addDepartment = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_removeDepartment = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.tcl_departments.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.tcl_departments, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(23, 64);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(529, 431);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // tcl_departments
            // 
            this.tcl_departments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcl_departments.Controls.Add(this.tbp_admins);
            this.tcl_departments.Location = new System.Drawing.Point(3, 4);
            this.tcl_departments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tcl_departments.Name = "tcl_departments";
            this.tcl_departments.SelectedIndex = 0;
            this.tcl_departments.Size = new System.Drawing.Size(368, 423);
            this.tcl_departments.TabIndex = 1;
            // 
            // tbp_admins
            // 
            this.tbp_admins.BackColor = System.Drawing.Color.Silver;
            this.tbp_admins.Controls.Add(this.flp_departments);
            this.tbp_admins.Location = new System.Drawing.Point(4, 26);
            this.tbp_admins.Name = "tbp_admins";
            this.tbp_admins.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_admins.Size = new System.Drawing.Size(360, 393);
            this.tbp_admins.TabIndex = 2;
            this.tbp_admins.Text = "Departments";
            // 
            // flp_departments
            // 
            this.flp_departments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flp_departments.AutoScroll = true;
            this.flp_departments.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_departments.Location = new System.Drawing.Point(6, 7);
            this.flp_departments.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flp_departments.Name = "flp_departments";
            this.flp_departments.Size = new System.Drawing.Size(348, 379);
            this.flp_departments.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.btn_updateDepartment, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btn_addDepartment, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_cancel, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.btn_removeDepartment, 0, 2);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(377, 121);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(149, 188);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btn_updateDepartment
            // 
            this.btn_updateDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_updateDepartment.Location = new System.Drawing.Point(3, 50);
            this.btn_updateDepartment.Name = "btn_updateDepartment";
            this.btn_updateDepartment.Size = new System.Drawing.Size(143, 41);
            this.btn_updateDepartment.TabIndex = 2;
            this.btn_updateDepartment.Text = "Update";
            this.btn_updateDepartment.UseVisualStyleBackColor = true;
            this.btn_updateDepartment.Click += new System.EventHandler(this.btn_updateDepartment_Click);
            // 
            // btn_addDepartment
            // 
            this.btn_addDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addDepartment.Location = new System.Drawing.Point(3, 3);
            this.btn_addDepartment.Name = "btn_addDepartment";
            this.btn_addDepartment.Size = new System.Drawing.Size(143, 41);
            this.btn_addDepartment.TabIndex = 1;
            this.btn_addDepartment.Text = "Add";
            this.btn_addDepartment.UseVisualStyleBackColor = true;
            this.btn_addDepartment.Click += new System.EventHandler(this.btn_addDepartment_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Location = new System.Drawing.Point(3, 144);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(143, 41);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_removeDepartment
            // 
            this.btn_removeDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_removeDepartment.Location = new System.Drawing.Point(3, 97);
            this.btn_removeDepartment.Name = "btn_removeDepartment";
            this.btn_removeDepartment.Size = new System.Drawing.Size(143, 41);
            this.btn_removeDepartment.TabIndex = 0;
            this.btn_removeDepartment.Text = "Remove";
            this.btn_removeDepartment.UseVisualStyleBackColor = true;
            this.btn_removeDepartment.Click += new System.EventHandler(this.btn_removeDepartment_Click);
            // 
            // editDepartments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 519);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "editDepartments";
            this.Resizable = false;
            this.Text = "Department Editor";
            this.Load += new System.EventHandler(this.editDepartments_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tcl_departments.ResumeLayout(false);
            this.tbp_admins.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TabControl tcl_departments;
        private System.Windows.Forms.TabPage tbp_admins;
        private System.Windows.Forms.FlowLayoutPanel flp_departments;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btn_updateDepartment;
        private System.Windows.Forms.Button btn_addDepartment;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_removeDepartment;
    }
}
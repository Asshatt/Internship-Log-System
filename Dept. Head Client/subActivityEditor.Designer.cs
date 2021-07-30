namespace OJT_Project.Dept._Head_Client
{
    partial class subActivityEditor
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
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_addSubActivity = new System.Windows.Forms.Button();
            this.tbx_subActivityName = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_activeActivity = new System.Windows.Forms.ComboBox();
            this.btn_deleteActivity = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.flp_subActivityDisplay = new System.Windows.Forms.FlowLayoutPanel();
            this.tlp_subActivityHolder = new System.Windows.Forms.TableLayoutPanel();
            this.btn_delete = new System.Windows.Forms.Button();
            this.tbx_subActivity = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.flp_subActivityDisplay.SuspendLayout();
            this.tlp_subActivityHolder.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(26, 81);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 74.14966F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.88435F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(579, 441);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 23.21117F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.50262F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.46073F));
            this.tableLayoutPanel4.Controls.Add(this.btn_addSubActivity, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.tbx_subActivityName, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btn_cancel, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 395);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(573, 43);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // btn_addSubActivity
            // 
            this.btn_addSubActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_addSubActivity.Location = new System.Drawing.Point(3, 3);
            this.btn_addSubActivity.Name = "btn_addSubActivity";
            this.btn_addSubActivity.Size = new System.Drawing.Size(126, 37);
            this.btn_addSubActivity.TabIndex = 0;
            this.btn_addSubActivity.Text = "Add Sub-Activity";
            this.btn_addSubActivity.UseVisualStyleBackColor = true;
            this.btn_addSubActivity.Click += new System.EventHandler(this.btn_addSubActivity_Click);
            // 
            // tbx_subActivityName
            // 
            this.tbx_subActivityName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbx_subActivityName.Location = new System.Drawing.Point(135, 9);
            this.tbx_subActivityName.Name = "tbx_subActivityName";
            this.tbx_subActivityName.Size = new System.Drawing.Size(248, 25);
            this.tbx_subActivityName.TabIndex = 1;
            // 
            // btn_cancel
            // 
            this.btn_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_cancel.Location = new System.Drawing.Point(389, 3);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(181, 37);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "Return to Dashboard";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.49913F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.95462F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.72077F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbx_activeActivity, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_deleteActivity, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(573, 60);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active Activity:";
            // 
            // cbx_activeActivity
            // 
            this.cbx_activeActivity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cbx_activeActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_activeActivity.FormattingEnabled = true;
            this.cbx_activeActivity.Location = new System.Drawing.Point(108, 19);
            this.cbx_activeActivity.Name = "cbx_activeActivity";
            this.cbx_activeActivity.Size = new System.Drawing.Size(347, 25);
            this.cbx_activeActivity.TabIndex = 1;
            this.cbx_activeActivity.SelectedIndexChanged += new System.EventHandler(this.cbx_activeActivity_SelectedIndexChanged);
            // 
            // btn_deleteActivity
            // 
            this.btn_deleteActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_deleteActivity.Location = new System.Drawing.Point(462, 16);
            this.btn_deleteActivity.Name = "btn_deleteActivity";
            this.btn_deleteActivity.Size = new System.Drawing.Size(108, 27);
            this.btn_deleteActivity.TabIndex = 2;
            this.btn_deleteActivity.Text = "Delete";
            this.btn_deleteActivity.UseVisualStyleBackColor = true;
            this.btn_deleteActivity.Click += new System.EventHandler(this.btn_deleteActivity_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Silver;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.flp_subActivityDisplay, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 69);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(573, 320);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Sub-Activities";
            // 
            // flp_subActivityDisplay
            // 
            this.flp_subActivityDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flp_subActivityDisplay.Controls.Add(this.tlp_subActivityHolder);
            this.flp_subActivityDisplay.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flp_subActivityDisplay.Location = new System.Drawing.Point(3, 35);
            this.flp_subActivityDisplay.Name = "flp_subActivityDisplay";
            this.flp_subActivityDisplay.Size = new System.Drawing.Size(567, 282);
            this.flp_subActivityDisplay.TabIndex = 1;
            // 
            // tlp_subActivityHolder
            // 
            this.tlp_subActivityHolder.ColumnCount = 2;
            this.tlp_subActivityHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.67376F));
            this.tlp_subActivityHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.32624F));
            this.tlp_subActivityHolder.Controls.Add(this.btn_delete, 1, 0);
            this.tlp_subActivityHolder.Controls.Add(this.tbx_subActivity, 0, 0);
            this.tlp_subActivityHolder.Location = new System.Drawing.Point(3, 3);
            this.tlp_subActivityHolder.Name = "tlp_subActivityHolder";
            this.tlp_subActivityHolder.RowCount = 1;
            this.tlp_subActivityHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlp_subActivityHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlp_subActivityHolder.Size = new System.Drawing.Size(564, 44);
            this.tlp_subActivityHolder.TabIndex = 0;
            // 
            // btn_delete
            // 
            this.btn_delete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_delete.Location = new System.Drawing.Point(458, 3);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(103, 38);
            this.btn_delete.TabIndex = 0;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            // 
            // tbx_subActivity
            // 
            this.tbx_subActivity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tbx_subActivity.Location = new System.Drawing.Point(3, 9);
            this.tbx_subActivity.Name = "tbx_subActivity";
            this.tbx_subActivity.Size = new System.Drawing.Size(449, 25);
            this.tbx_subActivity.TabIndex = 1;
            // 
            // subActivityEditor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(631, 551);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "subActivityEditor";
            this.Padding = new System.Windows.Forms.Padding(23, 78, 23, 26);
            this.Resizable = false;
            this.Text = "Activity Editor";
            this.Load += new System.EventHandler(this.subActivityEditor_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.flp_subActivityDisplay.ResumeLayout(false);
            this.tlp_subActivityHolder.ResumeLayout(false);
            this.tlp_subActivityHolder.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_activeActivity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel flp_subActivityDisplay;
        private System.Windows.Forms.TableLayoutPanel tlp_subActivityHolder;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox tbx_subActivity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btn_addSubActivity;
        private System.Windows.Forms.TextBox tbx_subActivityName;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_deleteActivity;
    }
}
using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OJT_Project.Dept._Head_Client
{
    public partial class subActivityEditor : MetroFramework.Forms.MetroForm
    {
        DataTable activityList = new DataTable();
        int initialId = 0;

        public subActivityEditor(DataTable activities, int id)
        {
            //pass activity list from last form into this one
            activityList = activities;
            initialId = id;
            InitializeComponent();
        }

        private void createSubActivity(string subActivityInfo, int id) 
        {
            //make table layout panel
            TableLayoutPanel tbl_subActivityHolder = new TableLayoutPanel();
            tbl_subActivityHolder.ColumnCount = 2;
            tbl_subActivityHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.67376F));
            tbl_subActivityHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.32624F));
            tbl_subActivityHolder.Location = new System.Drawing.Point(3, 3);
            tbl_subActivityHolder.RowCount = 1;
            tbl_subActivityHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tbl_subActivityHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tbl_subActivityHolder.Size = new System.Drawing.Size(564, 44);
            tbl_subActivityHolder.TabIndex = 0;
            tbl_subActivityHolder.BackColor = Color.DarkGray;

            flp_subActivityDisplay.Controls.Add(tbl_subActivityHolder);

            //make textbox
            indexedTextbox tbx_subActivityInput = new indexedTextbox();
            tbx_subActivityInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            tbx_subActivityInput.Location = new System.Drawing.Point(3, 9);
            tbx_subActivityInput.Name = "tbx_subActivity";
            tbx_subActivityInput.Text = subActivityInfo.Trim();
            tbx_subActivityInput.initialText = subActivityInfo.Trim();

            tbx_subActivityInput.Size = new System.Drawing.Size(449, 25);
            tbx_subActivityInput.TabIndex = 1;
            tbx_subActivityInput.id = id;
            tbx_subActivityInput.LostFocus += (s, args) => changeSubActivityName(tbx_subActivityInput.Text.Trim(), tbx_subActivityInput.id, tbx_subActivityInput);

            tbl_subActivityHolder.Controls.Add(tbx_subActivityInput);

            //make delete button
            indexedButton btn_deleteSubActivity = new indexedButton();
            btn_deleteSubActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            btn_deleteSubActivity.Location = new System.Drawing.Point(458, 3);
            btn_deleteSubActivity.Name = "btn_delete";
            btn_deleteSubActivity.Size = new System.Drawing.Size(103, 38);
            btn_deleteSubActivity.TabIndex = 0;
            btn_deleteSubActivity.Text = "Delete";
            btn_deleteSubActivity.UseVisualStyleBackColor = true;
            btn_deleteSubActivity.id = id;
            btn_deleteSubActivity.Click += (s, args) => deleteSubActivity(btn_deleteSubActivity.id);

            tbl_subActivityHolder.Controls.Add(btn_deleteSubActivity);
        }

        //event for deleting sub activity
        private void deleteSubActivity(int id)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this sub activity?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.No)
            {
                return;
            }
            else
            {
                connection.executeQuery("UPDATE `sub_activities` SET `status` = 0 WHERE `sub_activities`.`id` = " + id);
                updateSubActivities(Convert.ToInt32(activityList.Rows[cbx_activeActivity.SelectedIndex]["id"]));
            }
        }

        //whenever textbox is edited, update the sub-activity
        private void changeSubActivityName(string newName, int id, indexedTextbox tbx)
        {
            //if name hasn't been changed, then don't do anything
            if(newName == tbx.initialText)
            {
                return;
            }
            
            DialogResult result = MessageBox.Show("Are you sure you want to change this sub-activity?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.No)
            {
                return;
            }
            tbx.initialText = newName;
            MySqlCommand updateSubActivityName = new MySqlCommand("UPDATE `sub_activities` SET `subActivityName` = @newName WHERE `id` = @id");
            updateSubActivityName.Parameters.AddWithValue("@newName", newName);
            updateSubActivityName.Parameters.AddWithValue("@id", id);
            connection.executeQuery_secure(updateSubActivityName);
            updateSubActivities(Convert.ToInt32(activityList.Rows[cbx_activeActivity.SelectedIndex]["id"]));
        }

        private void updateSubActivities(int id) 
        {
            flp_subActivityDisplay.Controls.Clear();
            //get a table of all subActivities under the currently selected activity
            DataTable subActivites = connection.parseDataTableFromDB("SELECT * FROM `sub_activities` WHERE `parentActivity_id` = " + id + " AND `status` = 1 ORDER BY `subActivityName`");
            
            //create sub activity containers for all of the sub activities in the table
            for(int i = 0; i < subActivites.Rows.Count; i++)
            {
                createSubActivity(Convert.ToString(subActivites.Rows[i]["subActivityName"]), Convert.ToInt32(subActivites.Rows[i]["id"]));
            }
        }

        private void updateActivityDropdown()
        {
            cbx_activeActivity.Items.Clear();
            //set active activity dropdown to have the list of activities
            for (int i = 0; i < activityList.Rows.Count; i++)
            {
                cbx_activeActivity.Items.Add(activityList.Rows[i]["activityName"]);
                if (Convert.ToInt32(activityList.Rows[i]["id"]) == initialId)
                {
                    cbx_activeActivity.SelectedIndex = i;
                }
            }
        }

        private void subActivityEditor_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            updateActivityDropdown();
            //update sub activities with the given id value
            updateSubActivities(Convert.ToInt32(activityList.Rows[cbx_activeActivity.SelectedIndex]["id"]));
            //createSubActivity("Thing", 0);
        }

        private void cbx_activeActivity_SelectedIndexChanged(object sender, EventArgs e)
        {
            //whenever the combobox changes value, update the sub activities
            updateSubActivities(Convert.ToInt32(activityList.Rows[cbx_activeActivity.SelectedIndex]["id"]));
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_addSubActivity_Click(object sender, EventArgs e)
        {
            MySqlCommand selectSubActvitiesWithName = new MySqlCommand("SELECT * FROM `sub_activities` WHERE `status` = 1 AND `subActivityName` = @subActivityName AND `parentActivity_id` = @parentActivityID");
            selectSubActvitiesWithName.Parameters.AddWithValue("@subActivityName", tbx_subActivity.Text.Trim());
            selectSubActvitiesWithName.Parameters.AddWithValue("@parentActivityID", activityList.Rows[cbx_activeActivity.SelectedIndex]["id"]);

            MySqlCommand selectSubActvitiesWithName_inactive = new MySqlCommand("SELECT * FROM `sub_activities` WHERE `status` = 0 AND `subActivityName` = @subActivityName AND `parentActivity_id` = @parentActivityID");
            selectSubActvitiesWithName_inactive.Parameters.AddWithValue("@subActivityName", tbx_subActivity.Text.Trim());
            selectSubActvitiesWithName_inactive.Parameters.AddWithValue("@parentActivityID", activityList.Rows[cbx_activeActivity.SelectedIndex]["id"]);


            //if there is no inputted name, return
            if (tbx_subActivityName.Text.Trim() == "")
            {
                MessageBox.Show("Cannot make a sub-activity without a name.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //if sub-activity already exists and is active under the current activity, then return
            else if (connection.parseDataTableFromDB_secure(selectSubActvitiesWithName).Rows.Count > 0)
            {
                MessageBox.Show("Activity " + tbx_subActivityName.Text.Trim() + " already exists in your department.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //if sub-activity already exists but is inactive, then reactivate it.
            else if(connection.parseDataTableFromDB_secure(selectSubActvitiesWithName_inactive).Rows.Count > 0)
            {
                MySqlCommand reactivateSubActivity = new MySqlCommand("UPDATE `sub_activities` SET `status` = 1 WHERE `subActivityName` = @subActivityName");
                reactivateSubActivity.Parameters.AddWithValue("@subActivityName", tbx_subActivityName.Text.Trim());
                //connection.executeQuery("UPDATE `sub_activities` SET `status` = 1 WHERE `subActivityName` = '" + tbx_subActivityName.Text.Trim() + "'");
                connection.executeQuery_secure(reactivateSubActivity);
            }
            else
            {
                MySqlCommand insertNewActivity = new MySqlCommand("INSERT INTO `sub_activities` (`subActivityName`, `parentActivity_id`) VALUES (@subActivityName, @parentActivityID)");
                insertNewActivity.Parameters.AddWithValue("@subActivityName", tbx_subActivityName.Text.Trim());
                insertNewActivity.Parameters.AddWithValue("@parentActivityID", activityList.Rows[cbx_activeActivity.SelectedIndex]["id"]);
                connection.executeQuery_secure(insertNewActivity);
                //connection.executeQuery("INSERT INTO `sub_activities` (`subActivityName`, `parentActivity_id`) VALUES ('" + tbx_subActivityName.Text.Trim() + "', " + activityList.Rows[cbx_activeActivity.SelectedIndex]["id"] + ")");
            }
            updateSubActivities(Convert.ToInt32(activityList.Rows[cbx_activeActivity.SelectedIndex]["id"]));
        }

        private void btn_deleteActivity_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this activity?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.No)
            {
                return;
            }
            //remove the activity from the database
            connection.executeQuery("UPDATE `activities` SET `status` = 0 WHERE `id` = " + activityList.Rows[cbx_activeActivity.SelectedIndex]["id"]);
            //remove child activities from the database
            connection.executeQuery("UPDATE `sub_activities` SET `status` = 0 WHERE `parentActivity_id` = " + activityList.Rows[cbx_activeActivity.SelectedIndex]["id"]);
            //update activity list
            activityList = connection.parseDataTableFromDB("SELECT * FROM `activities` WHERE `status` = 1 AND `department_id` = " + user.deptID + " ORDER BY `activityName`");
            updateActivityDropdown();
        }
    }
}

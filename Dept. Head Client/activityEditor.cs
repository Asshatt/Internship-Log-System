using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace OJT_Project.Dept._Head_Client
{
    public partial class activityEditor : MetroFramework.Forms.MetroForm
    {
        //datatable for activities
        DataTable activities = new DataTable();

        public activityEditor()
        {
            InitializeComponent();
        }

        private void createActivityHolder(int activityID, string info) 
        {
            //create table split
            TableLayoutPanel activityContainerTable = new TableLayoutPanel();
            activityContainerTable.ColumnCount = 3;
            activityContainerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.5F));
            activityContainerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.5F));
            activityContainerTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 1F));
            activityContainerTable.RowCount = 1;
            activityContainerTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            activityContainerTable.Size = new System.Drawing.Size(663, 46);
            activityContainerTable.TabIndex = 0;
            activityContainerTable.BackColor = Color.DarkGray;

            flp_activityList.Controls.Add(activityContainerTable);

            //creates the label
            Label activityInfo = new Label();
            activityInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            activityInfo.AutoSize = true;
            activityInfo.Location = new System.Drawing.Point(115, 12);
            activityInfo.Size = new System.Drawing.Size(52, 21);
            activityInfo.TabIndex = 0;
            activityInfo.Text = info;

            activityContainerTable.Controls.Add(activityInfo);

            //create the button
            indexedButton button = new indexedButton();
            button.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            button.Location = new System.Drawing.Point(3, 3);
            button.Size = new System.Drawing.Size(107, 40);
            button.TabIndex = 1;
            button.Text = "Edit";
            button.UseVisualStyleBackColor = true;
            button.id = activityID;

            //assigns btn_editActivity_Click to the button's clicked event
            button.Click += (s, args) => btn_editActivity_Click(button.id);

            activityContainerTable.Controls.Add(button);
        }

        private void btn_editActivity_Click(int id)
        {
            //pass activities datatable into the new form
            subActivityEditor subActiveHeader = new subActivityEditor(activities, id);
            subActiveHeader.FormClosed += (s, args) => closeSubActivityEditor();
            subActiveHeader.Show();
            this.Hide();
        }

        private void closeSubActivityEditor()
        {
            this.Show();
            updateActivityHolder();
        }

        private void activityEditor_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            updateActivityHolder();

            MySqlConnection load = new MySqlConnection(connection.DatabaseConnection);
            load.OpenWithWarning();

            lbl_departmentInfo.Text = Convert.ToString(connection.parseDataTableFromDB("SELECT * FROM `departments` WHERE `id` = " + user.deptID, load).Rows[0]["deptName"]);
            load.Close();
        }

        private void updateActivityHolder()
        {
            MySqlConnection updateActHolderCon = new MySqlConnection(connection.DatabaseConnection);
            updateActHolderCon.OpenWithWarning();

            flp_activityList.Controls.Clear();
            //pareses database for all activities corresponding to the user's department 
            activities = connection.parseDataTableFromDB("SELECT * FROM `activities` WHERE `status` = 1 AND `department_id` = " + user.deptID + " ORDER BY `activityName`", updateActHolderCon);

            //creates an activity holder for all activities 
            for (int i = 0; i < activities.Rows.Count; i++)
            {
                //pareses through all sub activities of each activity
                DataTable subActivities = connection.parseDataTableFromDB("SELECT `id` FROM `sub_activities` WHERE `status` = 1 AND `parentActivity_id` = " + activities.Rows[i]["id"], updateActHolderCon);
                string info = activities.Rows[i]["activityName"] + " [Contains " + subActivities.Rows.Count;
                if (subActivities.Rows.Count == 1)
                {
                    info += " Sub-Activity]";
                }
                else
                {
                    info += " Sub-Activities]";
                }
                createActivityHolder(Convert.ToInt32(activities.Rows[i]["id"]), info);
            }
            updateActHolderCon.Close();
        }

        private void btn_addActivity_Click(object sender, EventArgs e)
        {
            MySqlConnection addActCon = new MySqlConnection(connection.DatabaseConnection);
            addActCon.OpenWithWarning();

            //define commands for the 2 else if statements
            MySqlCommand selectActiveWithSameName = new MySqlCommand("SELECT * FROM `activities` WHERE `status` = 1 AND `activityName` = @activityName AND `department_id` = @deptID");
            selectActiveWithSameName.Parameters.AddWithValue("@activityName", tbx_activityName.Text.Trim());
            selectActiveWithSameName.Parameters.AddWithValue("@deptID", user.deptID);
            
            MySqlCommand selectActiveWithSameName_inactive = new MySqlCommand("SELECT * FROM `activities` WHERE `status` = 0 AND `activityName` = @activityName AND `department_id` = @deptID");
            selectActiveWithSameName_inactive.Parameters.AddWithValue("@activityName", tbx_activityName.Text.Trim());
            selectActiveWithSameName_inactive.Parameters.AddWithValue("@deptID", user.deptID);


            //if there is no inputted name, return
            if (tbx_activityName.Text.Trim() == "") 
            {
                MessageBox.Show("Cannot make an activity without a name.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                addActCon.Close();
                return;
            }
            else if (connection.parseDataTableFromDB_secure(selectActiveWithSameName, addActCon).Rows.Count > 0)
            {
                MessageBox.Show("Activity " + tbx_activityName.Text.Trim() + " already exists in your department.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                addActCon.Close();
                return;
            }
            //if activity is in database, but deactivated, reactivate it
            else if(connection.parseDataTableFromDB_secure(selectActiveWithSameName_inactive, addActCon).Rows.Count > 0)
            {
                //connection.executeQuery("UPDATE `activities` SET `status` = 1 WHERE `activityName` = '" + tbx_activityName.Text.Trim() + "' AND `department_id` = " + user.deptID);
                MySqlCommand updateActivity = new MySqlCommand("UPDATE `activities` SET `status` = 1 WHERE `activityName` = @activityName AND `department_id` = @userID");
                updateActivity.Parameters.AddWithValue("@activityName", tbx_activityName.Text.Trim());
                updateActivity.Parameters.AddWithValue("@userID", user.deptID);
                connection.executeQuery_secure(updateActivity, addActCon);
                updateActivityHolder();
                addActCon.Close();
                return;
            }
            else
            {
                MySqlCommand insertNewActivity = new MySqlCommand("INSERT INTO `activities` (`activityName`, `department_id`) VALUES (@activityName, @deptID)");
                insertNewActivity.Parameters.AddWithValue("@activityName", tbx_activityName.Text.Trim());
                insertNewActivity.Parameters.AddWithValue("@deptID", user.deptID);
                //connection.executeQuery("INSERT INTO `activities` (`activityName`, `department_id`) VALUES ('" + tbx_activityName.Text.Trim() + "', " + user.deptID + ")");
                connection.executeQuery_secure(insertNewActivity, addActCon);
            }
            updateActivityHolder();
            addActCon.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void flp_activityList_Layout(object sender, LayoutEventArgs e)
        {
            flp_activityList.SuspendLayout();
            foreach(Control ctrl in flp_activityList.Controls)
            {
                ctrl.Width = flp_activityList.ClientSize.Width - 1;
            }
            flp_activityList.ResumeLayout();
        }
    }
}

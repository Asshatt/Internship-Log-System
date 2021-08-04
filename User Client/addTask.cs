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

namespace OJT_Project.User_Client
{
    public partial class addTask : MetroFramework.Forms.MetroForm
    {
        DataTable activities;
        DataTable subActivities;
        public addTask()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to quit? All currently inputted task information will be lost.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void addTask_Load(object sender, EventArgs e)
        {
            MySqlConnection loadCon = new MySqlConnection(connection.DatabaseConnection);
            loadCon.OpenWithWarning();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            activities = connection.parseDataTableFromDB("SELECT * FROM `activities` WHERE `status` = 1 AND `department_id` = " + user.deptID, loadCon);
            globalFunctions.addDbInfoToComboBox(cbx_activity, activities, "activityName");
            /*
            dtp_startTime.Format = DateTimePickerFormat.Custom;
            dtp_startTime.CustomFormat = "mm-dd-yyy | hh:mm:ss";
            dtp_endTime.Format = DateTimePickerFormat.Custom;*/
            loadCon.Close();
        }

        private void cbx_activity_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection indexChangeCon = new MySqlConnection(connection.DatabaseConnection);
            indexChangeCon.OpenWithWarning();
            subActivities = connection.parseDataTableFromDB("SELECT * FROM `sub_activities` WHERE `status` = 1 AND `parentActivity_id` = " + activities.Rows[cbx_activity.SelectedIndex]["id"], indexChangeCon);
            globalFunctions.addDbInfoToComboBox(cbx_subActivity, subActivities, "subActivityName");
            indexChangeCon.Close();
        }

        private void btn_addTask_Click(object sender, EventArgs e)
        {
            //get the date and time values from both Date Time Pickers
            DateTime startTime = (dtp_startDate.Value.Date + dtp_startHour.Value.TimeOfDay);
            DateTime endTime = dtp_endDate.Value.Date + dtp_endHour.Value.TimeOfDay;
            double duration = (endTime - startTime).TotalHours;
            
            //check if there the start time is greater than the end time
            if(startTime > endTime)
            {
                MessageBox.Show("End time is before start time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if(endTime > DateTime.Now)
            {
                MessageBox.Show("Cannot register events in the future.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MySqlConnection addTaskCon = new MySqlConnection(connection.DatabaseConnection);
            addTaskCon.OpenWithWarning();

            //check if there is another task from the same user at the same time
            if (connection.parseDataTableFromDB("SELECT * FROM `tasks` WHERE `user_id` = " + user.id + " AND `startTime` = '" + startTime.ToString("yyyy-MM-dd H:mm:ss") + "'", addTaskCon).Rows.Count > 0) 
            {
                MessageBox.Show("You already have an assigned task for that time. Choose another start time.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addTaskCon.Close();
                return;
            }

            if (cbx_activity.SelectedIndex == -1 || cbx_subActivity.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an activity and sub-activity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                addTaskCon.Close();
                return;
            }

            //add the task to the table
            MySqlCommand insertTask = new MySqlCommand("INSERT INTO `tasks` (`user_id`, `department_id`, `startTime`, `endTime`, `duration`, `activity`, `subActivity`, `action`)" +
                " VALUES(@userID, @deptID, @startTime, @endTime, @duration, @activity, @subActivity, @action)");
            insertTask.Parameters.AddWithValue("@userID", user.id);
            insertTask.Parameters.AddWithValue("@deptID", user.deptID);
            insertTask.Parameters.AddWithValue("@startTime",  startTime.ToString(globalFunctions.sqlDateFormat));
            insertTask.Parameters.AddWithValue("@endTime", endTime.ToString(globalFunctions.sqlDateFormat));
            insertTask.Parameters.AddWithValue("@duration", duration);
            insertTask.Parameters.AddWithValue("@activity", activities.Rows[cbx_activity.SelectedIndex]["activityName"]);
            insertTask.Parameters.AddWithValue("@subActivity", subActivities.Rows[cbx_subActivity.SelectedIndex]["subActivityName"]);
            insertTask.Parameters.AddWithValue("@action", tbx_action.Text.Trim());

            connection.executeQuery_secure(insertTask, addTaskCon);
            /*
            connection.executeQuery("INSERT INTO `tasks` (`user_id`, `department_id`, `startTime`, `endTime`, `duration`, `activity`, `subActivity`, `action`) VALUES (" +
                user.id + ", " + user.deptID + ", '" + startTime.ToString("yyyy-MM-dd H:mm:ss") + "', '" + endTime.ToString("yyyy-MM-dd H:mm:ss") + "', " + duration + ", '" + activities.Rows[cbx_activity.SelectedIndex]["activityName"] +
                "', '" + subActivities.Rows[cbx_subActivity.SelectedIndex]["subActivityName"] + "', '" + tbx_action.Text.Trim() + "'" +
                ")");*/

            addTaskCon.Close();
            //check if user wants to add another task or exit
            DialogResult result = MessageBox.Show("Your task has been registered successfully. Do you want to register another task?", "", MessageBoxButtons.YesNo);
            if(result == DialogResult.Yes) 
            {
                cbx_activity.SelectedIndex = 0;
                tbx_action.Clear();
            }
            else
            {
                this.Close();
            }
        }
    }
}

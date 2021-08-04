using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace OJT_Project.User_Client
{
    public partial class editTask : MetroFramework.Forms.MetroForm
    {
        DataTable taskTable = new DataTable();
        public editTask()
        {
            InitializeComponent();
        }

        private void updateDateRange()
        {
            MySqlConnection updateCon = new MySqlConnection(connection.DatabaseConnection);
            updateCon.OpenWithWarning();

            taskTable = connection.parseDataTableFromDB("SELECT * FROM `tasks` WHERE `user_id` = " + user.id + " ORDER BY `startTime`", updateCon);
            if (taskTable.Rows.Count > 0)
            {
                DateTime startDate = (DateTime)taskTable.Rows[0]["startTime"];
                //cut off time 
                dtp_startDate.Value = startDate.Date;

                DateTime endDate = (DateTime)taskTable.Rows[taskTable.Rows.Count - 1]["startTime"];
                //cut off time and add 23 hours
                dtp_endDate.Value = endDate.Date.AddHours(23.9999f);
            }
            else
            {
                dtp_startDate.Value = DateTime.Today;
                dtp_endDate.Value = DateTime.Today.AddHours(23.9999f);
            }
            updateCon.Close();
            updateTasks();
        }

        private void editTask_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            updateDateRange();
        }

        //update the task view
        private void updateTasks()
        {
            MySqlConnection updateTaskCon = new MySqlConnection(connection.DatabaseConnection);
            updateTaskCon.OpenWithWarning();

            this.Show();
            flp_taskContainer.Controls.Clear();
            //get all tasks of the user that's within the defined date range
            taskTable = connection.parseDataTableFromDB("SELECT * FROM `tasks` WHERE `user_id` = " + user.id  + " AND (`startTime` BETWEEN '" + dtp_startDate.Value.ToString("yyyy-MM-dd H:mm:ss") + "' AND '" + dtp_endDate.Value.ToString("yyyy-MM-dd H:mm:ss") + "') ORDER BY `startTime`", updateTaskCon);
            for (int i = 0; i < taskTable.Rows.Count; i++)
            {
                //add the task radio button to the list
                indexedRadioButton task = new indexedRadioButton();
                task.Text = (taskTable.Rows[i]["startTime"] + ", " + taskTable.Rows[i]["activity"] + ", " + taskTable.Rows[i]["subActivity"] + ", " + taskTable.Rows[i]["action"] + ", " + taskTable.Rows[i]["duration"] + "hrs.");
                task.AutoSize = true;
                task.AutoEllipsis = false;

                //use the start time as the ID value
                DateTime startTime = (DateTime)taskTable.Rows[i]["startTime"];
                task.stringID = startTime.ToString("yyyy-MM-dd H:mm:ss");

                flp_taskContainer.Controls.Add(task);
            }

            updateTaskCon.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_addTask_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Client.addTask taskScreen = new User_Client.addTask();
            taskScreen.FormClosed += (s, args) => updateDateRange();
            taskScreen.Show();
        }

        private void dateRange_ValueChanged(object sender, EventArgs e)
        {
            updateTasks();
        }

        private void btn_removeTask_Click(object sender, EventArgs e)
        {
            MySqlConnection removeTaskCon = new MySqlConnection(connection.DatabaseConnection);
            removeTaskCon.OpenWithWarning();

            indexedRadioButton checkedTask = globalFunctions.getCheckedRadio(flp_taskContainer);
            //if nothing is selected then prompt the user
            if (checkedTask == null)
            {
                MessageBox.Show("Select a task to delete.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to remove this task? Removed tasks cannot be recovered.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(result == DialogResult.No)
            {
                return;
            }
            connection.executeQuery("DELETE FROM `tasks` WHERE `user_id` = " + user.id + " AND `startTime` = '" + checkedTask.stringID + "'", removeTaskCon);
            removeTaskCon.Close();
            updateTasks();
        }

        private void btn_showAllTasks_Click(object sender, EventArgs e)
        {
            updateDateRange();
        }
    }
}

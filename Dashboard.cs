using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;

namespace OJT_Project
{
    public partial class dashboard : MetroFramework.Forms.MetroForm
    {
        DataTable allDepartments;
        DataGridView selectedDGV = null;

        public string userDashboardQuery = "SELECT `startTime`, `duration`, `activity`, `subActivity`, `action` FROM `tasks` WHERE `user_id` = " + user.id + " ORDER BY `startTime`";
        public string deptHeadDashboardQuery = "SELECT `user_id`, `startTime`, `duration`, `activity`, `subActivity`, `action` FROM `tasks` WHERE `department_id` = " + user.deptID + " ORDER BY `startTime`";
        public dashboard()
        {
            InitializeComponent();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            MySqlConnection dashLoadCon = new MySqlConnection(connection.DatabaseConnection);
            dashLoadCon.OpenWithWarning();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            //display tasks
            switch (user.permissionLevel) 
            {
                //User
                case 0:
                    //get all tasks corresponding to the current user ID and cache the results
                    DataTable myTasks = connection.parseDataTableFromDB(userDashboardQuery, dashLoadCon);
                    drawTaskPreview(myTasks);

                    tcl_previewControls.TabPages.RemoveAt(2);
                    tcl_previewControls.TabPages.RemoveAt(1);
                    tcl_controls.TabPages.RemoveAt(2);
                    tcl_controls.TabPages.RemoveAt(1);

                    tcl_dashboardInfo.TabPages.RemoveAt(2);
                    tcl_dashboardInfo.TabPages.RemoveAt(1);
                    break;

                //Department Head
                case 1:
                    DataTable deptTasks = connection.parseDataTableFromDB(deptHeadDashboardQuery, dashLoadCon);
                    drawTaskPreview(deptTasks);

                    tcl_previewControls.TabPages.RemoveAt(1);
                    tcl_controls.TabPages.RemoveAt(2);
                    tcl_controls.TabPages.RemoveAt(0);

                    tcl_dashboardInfo.TabPages.RemoveAt(2);
                    tcl_dashboardInfo.TabPages.RemoveAt(0);
                    break;

                //Admin
                case 2:
                    drawUserPreview();

                    tcl_previewControls.TabPages.RemoveAt(2);
                    tcl_controls.TabPages.RemoveAt(1);
                    tcl_controls.TabPages.RemoveAt(0);

                    tcl_dashboardInfo.TabPages.RemoveAt(1);
                    tcl_dashboardInfo.TabPages.RemoveAt(0);
                    break;
                
                //edge case
                default:
                    MessageBox.Show("What the fuck");
                    break;
            }
            dashLoadCon.Close();
            updateDashboard();
        }

        //draws dashboard
        private void drawTaskPreview(DataTable data) 
        {
            MySqlConnection drawTaskPreview = new MySqlConnection(connection.DatabaseConnection);
            drawTaskPreview.OpenWithWarning();

            //set userinfo label
            lbl_userInfo.Text = "Current User: " + user.username + ", " + user.email;

            DataTable drawnTasks = data;
            //create a collection of all the columns in the 
            DataColumnCollection columns = drawnTasks.Columns;
            
            DataColumn username = drawnTasks.Columns.Add("username", System.Type.GetType("System.String"));
            DataColumn department = drawnTasks.Columns.Add("department", System.Type.GetType("System.String"));
            username.SetOrdinal(0);
            department.SetOrdinal(1);

            for(int i = 0; i < drawnTasks.Rows.Count; i++)
            {
                //if user id is recorded (aka, if its a department head or admin) then do this 
                if (columns.Contains("user_id"))
                {
                    //replace all user IDs with their usernames
                    drawnTasks.Rows[i]["username"] = connection.parseDataTableFromDB("SELECT `username` FROM `users` WHERE `id` = " + drawnTasks.Rows[i]["user_id"], drawTaskPreview).Rows[0]["username"];
                }
                else
                {
                    //if its just a normal ass user, set the username to the currently logged user
                    drawnTasks.Rows[i]["username"] = user.username;
                }

                //if department id is recorded
                if (columns.Contains("department_id"))
                {
                    MySqlCommand selectDepartmentName = new MySqlCommand("SELECT `deptName` FROM `departments` WHERE `id` = @id");
                    selectDepartmentName.Parameters.AddWithValue("@id", drawnTasks.Rows[i]["department_id"]);
                    string departmentName = Convert.ToString(connection.parseDataTableFromDB_secure(selectDepartmentName, drawTaskPreview).Rows[0][0]);

                    drawnTasks.Rows[i]["department"] = departmentName;
                }
                else
                {
                    try
                    {
                        drawnTasks.Columns.Remove("department");
                    }
                    catch
                    {

                    }
                }
            }
            if (columns.Contains("user_id")) { drawnTasks.Columns.Remove("user_id"); }
            if (columns.Contains("department_id")) { drawnTasks.Columns.Remove("department_id"); }

            dgv_taskPreview.DataSource = drawnTasks;
            drawTaskPreview.Close();
            globalFunctions.updateDataGridViewStyle(dgv_taskPreview);
        }

        private void drawUserPreview()
        {
            MySqlConnection userPrevCon = new MySqlConnection(connection.DatabaseConnection);
            userPrevCon.OpenWithWarning();

            //parse all 3 user tables and draw the user previes
            DataTable users = connection.parseDataTableFromDB("SELECT `username`, `email`, `department_id`, `role_id` FROM `users` WHERE `status` = 1 ORDER BY `id`", userPrevCon);
            DataTable deptHeads = connection.parseDataTableFromDB("SELECT `username`, `email`, `department_id` FROM `department_heads` WHERE `status` = 1 AND `id` != 0 ORDER BY `id`", userPrevCon);
            DataTable admins = connection.parseDataTableFromDB("SELECT `username`, `email` FROM `admins` WHERE `status` = 1 ORDER BY `id`", userPrevCon);

            #region Users
            ///BEGIN USERS///
            //create department and role columns
            users.Columns.Add("department");
            users.Columns.Add("role");

            //set department id and role id 
            for (int i = 0; i < users.Rows.Count; i++)
            {
                users.Rows[i]["department"] = connection.parseDataTableFromDB("SELECT `deptName` FROM `departments` WHERE `id` = " + users.Rows[i]["department_id"], userPrevCon).Rows[0]["deptName"];
                users.Rows[i]["role"] = connection.parseDataTableFromDB("SELECT `role` FROM `roles` WHERE `id` = " + users.Rows[i]["role_id"], userPrevCon).Rows[0]["role"];
            }

            //remove id columns
            users.Columns.Remove("department_id");
            users.Columns.Remove("role_id");

            dgv_users.DataSource = users;
            globalFunctions.updateDataGridViewStyle(dgv_users);
            ///END USERS///
            #endregion

            #region Dept Heads
            ///BEGIN DEPT. HEADS///
            //create department columns
            deptHeads.Columns.Add("department");

            //set department id
            for(int i = 0; i < deptHeads.Rows.Count; i++)
            {
                deptHeads.Rows[i]["department"] = connection.parseDataTableFromDB("SELECT `deptName` FROM `departments` WHERE `id` = " + deptHeads.Rows[i]["department_id"], userPrevCon).Rows[0]["deptName"];
            }

            //remove dept id column
            deptHeads.Columns.Remove("department_id");

            dgv_deptHeads.DataSource = deptHeads;
            globalFunctions.updateDataGridViewStyle(dgv_deptHeads);
            ///END DEPT. HEADS///
            #endregion

            dgv_admins.DataSource = admins;
            globalFunctions.updateDataGridViewStyle(dgv_admins);

            userPrevCon.Close();
        }

        private void btn_addTask_Click(object sender, EventArgs e)
        {
            this.Hide();
            User_Client.editTask taskScreen = new User_Client.editTask();
            taskScreen.FormClosed += (s, args) => updateDashboard();
            taskScreen.Show();
        }

        //call whenever the task preview needs to be updated
        private void updateDashboard() 
        {
            MySqlConnection updateCon = new MySqlConnection(connection.DatabaseConnection);
            updateCon.OpenWithWarning();

            this.Show();
            //change query based on permission level of current user
            switch (user.permissionLevel) 
            {
                //Users
                case 0:
                    DataTable updatedTasks = connection.parseDataTableFromDB(userDashboardQuery, updateCon);
                    drawTaskPreview(updatedTasks);
                   
                    #region duration for today
                    //calculate total duration for today
                    DataTable tasksForToday = connection.parseDataTableFromDB("SELECT SUM(`duration`) FROM `tasks` WHERE `user_id` = " + user.id + " AND (`startTime` BETWEEN '" + DateTime.Today.ToString(globalFunctions.sqlDateFormat) + "' AND '" + DateTime.Today.AddHours(23.9999).ToString(globalFunctions.sqlDateFormat) + "')", updateCon);
                    float totalDurationToday = 0;
                    try
                    {
                        totalDurationToday = float.Parse(Convert.ToString(tasksForToday.Rows[0][0]));
                    }
                    catch
                    {
                        //do nothing
                    }
                    //round to 2 decimal places then show on label
                    totalDurationToday = totalDurationToday.roundToTwoDecimalPlaces();
                    if (totalDurationToday == 1)
                    {
                        lbl_durationCurrentDay.Text = totalDurationToday + " Hour";
                    }
                    else
                    {
                        lbl_durationCurrentDay.Text = totalDurationToday + " Hours";
                    }
                    #endregion

                    #region duration for this week
                    //get array of labels for the weeks
                    Label[] weekLabels = { lbl_monday, lbl_tuesday, lbl_wednesday, lbl_thursday, lbl_friday, lbl_saturday, lbl_sunday };
                    string[] weekText = { "Monday: ", "Tuesday: ", "Wednesday: ", "Thursday: ", "Friday: ", "Saturday: ", "Sunday: " };

                    for(int i = 0; i < weekLabels.Length; i++)
                    {
                        //Console.WriteLine("SELECT SUM(`duration`) FROM `tasks` WHERE `user_id` = " + user.id + " AND (`startTime` BETWEEN '" + DateTime.Today.StartOfWeek(DayOfWeek.Monday).AddDays(i).ToString(globalFunctions.sqlDateFormat) + "' AND '" + DateTime.Today.StartOfWeek(DayOfWeek.Monday).AddDays(i).AddHours(23.9999f).ToString(globalFunctions.sqlDateFormat) + "')");
                        DataTable taskForTheWeek = connection.parseDataTableFromDB("SELECT SUM(`duration`) FROM `tasks` WHERE `user_id` = " + user.id + " AND (`startTime` BETWEEN '" + DateTime.Today.StartOfWeek(DayOfWeek.Monday).AddDays(i).ToString(globalFunctions.sqlDateFormat) +"' AND '" + DateTime.Today.StartOfWeek(DayOfWeek.Monday).AddDays(i).AddHours(23.9999f).ToString(globalFunctions.sqlDateFormat) + "')", updateCon);
                        float duration = 0;
                        try
                        {
                            duration = float.Parse(Convert.ToString(taskForTheWeek.Rows[0][0]));
                        }
                        catch
                        {

                        }
                        duration = duration.roundToTwoDecimalPlaces();
                        weekLabels[i].Text = weekText[i] + duration + " Hours";
                    }
                    #endregion

                    #region duration for this month
                    //calculate total duration for this month
                    DataTable tasksForThisMonth = connection.parseDataTableFromDB("SELECT SUM(`duration`) FROM `tasks` WHERE `user_id` = " + user.id + " AND (`startTime` BETWEEN '" + new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).ToString(globalFunctions.sqlDateFormat) + "' AND '" + new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1).AddMonths(1).AddDays(-1).AddHours(23.9999f).ToString(globalFunctions.sqlDateFormat) + "')", updateCon);
                    float totalDurationThisMonth = 0;
                    try
                    {
                        totalDurationThisMonth = float.Parse(Convert.ToString(tasksForThisMonth.Rows[0][0]));
                    }
                    catch
                    {
                        //do nothing
                    }
                    //round to 2 decimal places then show on label
                    totalDurationThisMonth = totalDurationThisMonth.roundToTwoDecimalPlaces();
                    if (totalDurationThisMonth == 1)
                    {
                        lbl_durationMonth.Text = totalDurationThisMonth + " Hour";
                    }
                    else
                    {
                        lbl_durationMonth.Text = totalDurationThisMonth + " Hours";
                    }
                    #endregion
                    break;
                
                //Dept. Heads
                case 1:
                    DataTable updatedDeptTasks = connection.parseDataTableFromDB(deptHeadDashboardQuery, updateCon);
                    drawTaskPreview(updatedDeptTasks);

                    #region draw pie chart
                    pie_roleSummary.Series["s1"].Points.Clear();

                    //get a datatable of all roles in the current department
                    DataTable roles = connection.parseDataTableFromDB("SELECT * FROM `roles` WHERE `status` = 1 AND `department_id` = " + user.deptID, updateCon);
                    
                    //iterate through the roles
                    for (int i = 0; i < roles.Rows.Count; i++)
                    {
                        float duration = 0;
                        //get all active user IDs assigned to the current role 
                        DataTable users = connection.parseDataTableFromDB("SELECT `id` FROM `users` WHERE `status` = 1 AND `role_id` = " + roles.Rows[i]["id"], updateCon);
                        
                        //iterate through the users in the table
                        for(int j = 0; j < users.Rows.Count; j++)
                        {
                            //get all tasks of the current user
                            //DataTable currentUserTasks = connection.parseDataTableFromDB("SELECT `duration` FROM `tasks` WHERE `user_id` = " + users.Rows[j]["id"]);

                            //add the duration of all the tasks 
                            duration = float.Parse(Convert.ToString(connection.parseDataTableFromDB("SELECT SUM(`duration`) FROM `tasks` WHERE `user_id` = " + users.Rows[j]["id"], updateCon).Rows[0][0]));
                        }
                        //after all that shit, add the points to the pie chart
                        if (duration > 0)
                        {
                            pie_roleSummary.Series["s1"].Points.AddXY(roles.Rows[i]["role"], duration);
                        }
                    }
                    #endregion

                    #region draw activity summary
                    //select activities from department
                    DataTable activities = connection.parseDataTableFromDB("SELECT * FROM `activities` WHERE `status` = 1 AND `department_id` = " + user.deptID + " ORDER BY `activityName`", updateCon);
                    //add tabs for each activity
                    tcl_activityTabs.TabPages.Clear();
                    for(int i = 0; i < activities.Rows.Count; i++)
                    {
                        TabPage activityPage = new TabPage();
                        activityPage.Text = "" + activities.Rows[i]["activityName"];
                        activityPage.BackColor = Color.Silver;

                        tcl_activityTabs.TabPages.Add(activityPage);

                        //create a datagridview
                        DataGridView subActivityGraph = new DataGridView();
                        subActivityGraph.CellClick += new DataGridViewCellEventHandler(this.SetSelectedDGV);
                        subActivityGraph.Size = activityPage.Size;
                        subActivityGraph.Name = "activity" + i;
                        subActivityGraph.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                        //the style wont display properly unless I do this bullshit
                        //it's inefficient but idgaf anymore
                        subActivityGraph.CellFormatting += (s, args) => globalFunctions.updateDataGridViewStyle(subActivityGraph);

                        //create the datatable for the sub activity summary
                        DataTable subActivitySummary = new DataTable();
                        subActivitySummary.Columns.Add("Sub Activity");
                        subActivitySummary.Columns.Add("Duration");

                        //get all subactivities of the current activity
                        DataTable subActivities = connection.parseDataTableFromDB("SELECT `subActivityName` from `sub_activities` WHERE `status` = 1 AND `parentActivity_id` = " + activities.Rows[i]["id"], updateCon);
                        
                        for(int j = 0; j < subActivities.Rows.Count; j++)
                        {
                            float duration = 0;
                            //get all tasks with the currently selected sub activity
                            try
                            {
                                duration = float.Parse(Convert.ToString(connection.parseDataTableFromDB("SELECT SUM(`duration`) FROM `tasks` WHERE `subActivity` = '" + subActivities.Rows[j]["subActivityName"] + "'", updateCon).Rows[0][0]));
                            }
                            catch
                            {
                                //do literally nothing
                            }
                            subActivitySummary.Rows.Add(subActivities.Rows[j]["subActivityName"], duration);
                        }

                        //assign datatable as datasource of datagridview
                        subActivityGraph.DataSource = subActivitySummary;
                        activityPage.Controls.Add(subActivityGraph);
                    }
                    #endregion

                    #region draw user summary
                    //define data table
                    DataTable userSummary = new DataTable();
                    userSummary.Columns.Add("Username");
                    userSummary.Columns.Add("Duration");

                    //select all users from the current department
                    MySqlCommand selectUsersInDatabase = new MySqlCommand("SELECT * FROM `users` WHERE `department_id` = @deptID AND `status` = 1");
                    selectUsersInDatabase.Parameters.AddWithValue("@deptID", user.deptID);
                    DataTable usersInDept = connection.parseDataTableFromDB_secure(selectUsersInDatabase, updateCon);

                    //for every user in the table
                    for(int i = 0; i < usersInDept.Rows.Count; i++)
                    {
                        //parse username
                        string username = usersInDept.Rows[i]["username"].ToString();

                        //add all the task durations assigned to the currently selected user
                        MySqlCommand selectSumOfAllUserTasks = new MySqlCommand("SELECT SUM(`duration`) FROM `tasks` WHERE `user_id` = @id");
                        selectSumOfAllUserTasks.Parameters.AddWithValue("@id", usersInDept.Rows[i]["id"]);
                        DataTable durationSum = connection.parseDataTableFromDB_secure(selectSumOfAllUserTasks, updateCon);

                        //get duration into a float
                        float duration = float.Parse(Convert.ToString(durationSum.Rows[0][0]));
                        duration = duration.roundToTwoDecimalPlaces();
                        
                        //add the row
                        userSummary.Rows.Add(username, duration);
                    }

                    //set datatable to display
                    dgv_userSummary.DataSource = userSummary;
                    globalFunctions.updateDataGridViewStyle(dgv_userSummary);
                    #endregion

                    #region draw total man hours

                    MySqlCommand selectTasksInDept = new MySqlCommand("SELECT SUM(`duration`) FROM `tasks` WHERE `department_id` = @deptID");
                    selectTasksInDept.Parameters.AddWithValue("@deptID", user.deptID);
                    float totalManHours = 0;
                    try
                    {
                        totalManHours = float.Parse(Convert.ToString(connection.parseDataTableFromDB_secure(selectTasksInDept, updateCon).Rows[0][0]));
                    }
                    catch
                    {
                        //do nothing
                    }
                    totalManHours = totalManHours.roundToTwoDecimalPlaces();
                    lbl_manHours.Text = totalManHours + " Hours";
                    #endregion

                    #region draw total man days
                    float totalManDays = totalManHours/9;
                    totalManDays = totalManDays.roundToTwoDecimalPlaces();
                    lbl_manDays.Text = totalManDays + " Days";
                    #endregion
                    break;

                //Admins
                case 2:
                    MySqlCommand selectAllTasks = new MySqlCommand("SELECT `user_id`, `department_id`, `startTime`, `duration`, `activity`, `subActivity`, `action` FROM `tasks` ORDER BY `startTime`");
                    DataTable allTasks = connection.parseDataTableFromDB_secure(selectAllTasks, updateCon);

                    //draw department filter combobox
                    cbx_adminDepartmentFilter.Items.Clear();
                    cbx_adminDepartmentFilter.Items.Add("All Departments");
                    cbx_adminDepartmentFilter.SelectedIndex = 0;
                    allDepartments = connection.parseDataTableFromDB("SELECT * FROM `departments` WHERE `status` = 1", updateCon);
                    for(int i = 0; i < allDepartments.Rows.Count; i++)
                    {
                        cbx_adminDepartmentFilter.Items.Add(allDepartments.Rows[i]["deptName"]);
                    }

                    drawTaskPreview(allTasks);
                    drawUserPreview();
                    break;
            }

            updateCon.Close();
            /*
            DataTable updatedTasks = connection.parseDataTableFromDB(query);
            drawTaskPreview(updatedTasks);*/
        }

        private void btn_editUser_Click(object sender, EventArgs e)
        {
            Admin_Client.editUser userForm = new Admin_Client.editUser();
            userForm.FormClosed += (s, args) => updateDashboard();
            userForm.Show();
            this.Hide();
        }

        private void btn_editActivities_Click(object sender, EventArgs e)
        {
            Dept._Head_Client.activityEditor editor = new Dept._Head_Client.activityEditor();
            editor.FormClosed += (s, args) => updateDashboard();
            editor.Show();
            this.Hide();
        }

        //Export Task Table to CSV
        private void btn_exportToCSV_Click(object sender, EventArgs e)
        {
            //dumb fuckery to get data table from source of dgv_taskPreview
            DataTable table = new DataTable();
            var source = selectedDGV.DataSource;
            while (source is BindingSource)
            {
                source = ((BindingSource)source).DataSource;
            }
            if (source is DataTable)
            {
                table = (DataTable)source;
            }

            //create a save file dialog
            SaveFileDialog sv = new SaveFileDialog();
            sv.Filter = "CSV File (*.csv)|*.csv";
            sv.FilterIndex = 1;
            sv.RestoreDirectory = true;
            DialogResult result = sv.ShowDialog();
            if(result == DialogResult.OK)
            {
                table.toCSV(sv.FileName);
            }
        }

        private void btn_editRoles_Click(object sender, EventArgs e)
        {
            Dept._Head_Client.roleEditor role = new Dept._Head_Client.roleEditor();
            role.FormClosed += (s, args) => updateDashboard();
            role.Show();
            this.Hide();
        }

        private void btn_updateMyAccount_Click(object sender, EventArgs e)
        {
            Admin_Client.updateUser updateMyInfo = new Admin_Client.updateUser(user.id, user.permissionLevel, false);
            updateMyInfo.FormClosed += (s, args) => updateCurrentUserInfo();
            updateMyInfo.Show();
            this.Hide();
        }

        private void updateCurrentUserInfo()
        {
            MySqlConnection updateInfo = new MySqlConnection(connection.DatabaseConnection);
            updateInfo.OpenWithWarning();

            MySqlCommand searchForUser = new MySqlCommand();
            //function to update the variables of the user static class
            switch (user.permissionLevel)
            {
                case 0:
                    searchForUser = new MySqlCommand("SELECT * FROM `users` WHERE `id` = @id");
                    break;

                case 1:
                    searchForUser = new MySqlCommand("SELECT * FROM `department_heads` WHERE `id` = @id");
                    break;

                case 2:
                    searchForUser = new MySqlCommand("SELECT * FROM `admins` WHERE `id` = @id");
                    break;
            }
            searchForUser.Parameters.AddWithValue("@id", user.id);
            DataTable updatedUserInfo = connection.parseDataTableFromDB_secure(searchForUser, updateInfo);
            user.username = updatedUserInfo.Rows[0]["username"].ToString();
            user.email = updatedUserInfo.Rows[0]["email"].ToString();
            updateInfo.Close();
            updateDashboard();
            this.Show();
        }

        private void btn_editDepartments_Click(object sender, EventArgs e)
        {
            Admin_Client.editDepartments departmentEditor = new Admin_Client.editDepartments();
            departmentEditor.FormClosed += (s, args) => this.Show();
            departmentEditor.Show();
            this.Hide();
        }

        private void cbx_adminDepartmentFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlConnection filterCon = new MySqlConnection(connection.DatabaseConnection);
            filterCon.OpenWithWarning();

            DataTable drawnTasks = new DataTable();
            if (cbx_adminDepartmentFilter.SelectedIndex == 0)
            {
                drawnTasks = connection.parseDataTableFromDB_secure(new MySqlCommand("SELECT `user_id`, `department_id`, `startTime`, `duration`, `activity`, `subActivity`, `action` FROM `tasks` ORDER BY `startTime`"), filterCon);
            }
            else
            {
                MySqlCommand getFromDepartment = new MySqlCommand("SELECT `user_id`, `department_id`, `startTime`, `duration`, `activity`, `subActivity`, `action` FROM `tasks` WHERE `department_id` = @deptID ORDER BY `startTime`");
                getFromDepartment.Parameters.AddWithValue("@deptID", allDepartments.Rows[cbx_adminDepartmentFilter.SelectedIndex - 1]["id"]);
                drawnTasks = connection.parseDataTableFromDB_secure(getFromDepartment, filterCon);
            }
            filterCon.Close();
            drawTaskPreview(drawnTasks);
        }

        private void SetSelectedDGV(object sender, DataGridViewCellEventArgs e)
        {
            selectedDGV = (DataGridView)sender;
            //Console.WriteLine(obj.Name);
        }

        private void btn_clearDatabase_Click(object sender, EventArgs e)
        {
            Admin_Client.clearDatabase clearDatabase = new Admin_Client.clearDatabase();
            z_misc.enterPassword passwordConfirmation = new z_misc.enterPassword(clearDatabase, user.id, user.permissionLevel);
            passwordConfirmation.FormClosed += (s, args) => updateDashboard();
            this.Hide();
            passwordConfirmation.Show();
        }
    }
}

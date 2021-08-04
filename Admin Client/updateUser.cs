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

namespace OJT_Project.Admin_Client
{
    public partial class updateUser : MetroFramework.Forms.MetroForm
    {
        int userID;
        int userPermLevel;
        DataTable userInfo = new DataTable();
        DataTable departments = new DataTable();
        DataTable roles = new DataTable();

        public updateUser(int id, int permLevel, bool isAdmin)
        {
            //get ID and permission level from last form
            userID = id;
            userPermLevel = permLevel;
            InitializeComponent();

            //is the user accessing the thing is not an admin, then disable the department and role changes
            if (!isAdmin)
            {
                lbl_department.Visible = false;
                lbl_role.Visible = false;
                cbx_department.Visible = false;
                cbx_role.Visible = false;
            }
            else
            {
                btn_updatePassword.Visible = false;
            }
        }

        private void updateDropdowns()
        {
            MySqlConnection dropdownUpdateCon = new MySqlConnection(connection.DatabaseConnection);
            dropdownUpdateCon.OpenWithWarning();

            cbx_role.Items.Clear();
            //if roles are also visible
            if (cbx_role.Visible)
            {
                //get roles under the current database
                try
                {
                    roles = connection.parseDataTableFromDB("SELECT * FROM `roles` WHERE `status` = 1 AND `department_id` = " + departments.Rows[cbx_department.SelectedIndex]["id"], dropdownUpdateCon);
                }
                catch
                {

                }
                //add roles into the options
                for (int i = 0; i < roles.Rows.Count; i++)
                {
                    cbx_role.Items.Add(roles.Rows[i]["role"]);
                    //if currently selected role is equal to user's role, then select this one
                    if (Convert.ToInt32(roles.Rows[i]["id"]) ==  Convert.ToInt32(userInfo.Rows[0]["role_id"]))
                    {
                        cbx_role.SelectedIndex = i;
                    }
                }
            }
            dropdownUpdateCon.Close();
        }

        private void updateUser_Load(object sender, EventArgs e)
        {
            MySqlConnection updateUserCon = new MySqlConnection(connection.DatabaseConnection);
            updateUserCon.OpenWithWarning();
            //parse database for this user info
            MySql.Data.MySqlClient.MySqlCommand selectActiveUser = new MySql.Data.MySqlClient.MySqlCommand();
            switch (userPermLevel)
            {
                //User
                case 0:
                    //userInfo = connection.parseDataTableFromDB("SELECT * FROM `users` WHERE `id` = " + userID);
                    selectActiveUser = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `users` WHERE `id` = @id");
                    break;

                //Dept Head
                case 1:
                    //userInfo = connection.parseDataTableFromDB("SELECT * FROM `department_heads` WHERE `id` = " + userID);
                    selectActiveUser = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `department_heads` WHERE `id` = @id");
                    lbl_role.Visible = false;
                    cbx_role.Visible = false;
                    break;

                //Admin
                case 2:
                    //userInfo = connection.parseDataTableFromDB("SELECT * FROM `admins` WHERE `id` = " + userID);
                    selectActiveUser = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `admins` WHERE `id` = @id");
                    lbl_role.Visible = false;
                    cbx_role.Visible = false;
                    lbl_department.Visible = false;
                    cbx_department.Visible = false;
                    break;
            }
            selectActiveUser.Parameters.AddWithValue("@id", userID);
            userInfo = connection.parseDataTableFromDB_secure(selectActiveUser, updateUserCon);

            //set current controls to the info of the current user
            tbx_username.Text = "" + userInfo.Rows[0]["username"];
            tbx_email.Text = "" + userInfo.Rows[0]["email"];

            //if departments are visible
            if (cbx_department.Visible)
            {
                //get all departments from the DB
                departments = connection.parseDataTableFromDB("SELECT * FROM `departments` WHERE `status` = 1 AND `id` != 0", updateUserCon);
                //add the options to the dropdown
                for (int i = 0; i < departments.Rows.Count; i++)
                {
                    string prefix = "";
                    //check if the department is vacant and if user is a department head and add a prefix if it is vacant
                    if(Convert.ToInt32(departments.Rows[i]["head_id"]) == 0 && userPermLevel == 1)
                    {
                        prefix = "[VACANT] ";
                    }

                    cbx_department.Items.Add(prefix + departments.Rows[i]["deptName"]);
                    //if the currently selected department is equal to the user's department, set it as selected
                    if (Convert.ToInt32(departments.Rows[i]["id"]) == Convert.ToInt32(userInfo.Rows[0]["department_id"]))
                    {
                        cbx_department.SelectedIndex = i;
                    }
                }
                updateDropdowns();
            }
            updateUserCon.Close();
        }

        private void cbx_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateDropdowns();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to cancel this action? Any saved changes will be lost.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_updateUser_Click(object sender, EventArgs e)
        {
            //create the query string
            string query = "UPDATE";

            //change which table to update depending on perm level
            switch (userPermLevel)
            {
                case 0:
                    query += " `users`";
                    break;

                case 1:
                    query += " `department_heads`";
                    break;

                case 2:
                    query += " `admins`";
                    break;
            }
            query += " SET `username` = '" + tbx_username.Text.Trim() + "', `email` = '" + tbx_email.Text.Trim() + "'";
            MySqlConnection updateUserCon = new MySqlConnection(connection.DatabaseConnection);
            updateUserCon.OpenWithWarning();
            try
            {
                if (cbx_department.Visible)
                {
                    query += ", `department_id` = " + departments.Rows[cbx_department.SelectedIndex]["id"];

                    if (cbx_role.Visible)
                    {
                        query += ", `role_id` = " + roles.Rows[cbx_role.SelectedIndex]["id"];
                        //if the user has any tasks assigned to them and their department has changed, change the department ID of the task to the user's new department ID
                        /*
                        MySqlCommand updateTasksToDepartment = new MySqlCommand("UPDATE `tasks` SET `department_id` = @deptID WHERE `user_id` = @userID");
                        updateTasksToDepartment.Parameters.AddWithValue("@deptID", departments.Rows[cbx_department.SelectedIndex]["id"]);
                        updateTasksToDepartment.Parameters.AddWithValue("@userID", userID);

                        connection.executeQuery_secure(updateTasksToDepartment);
                        */
                        //connection.executeQuery("UPDATE `tasks` SET `department_id` = " + departments.Rows[cbx_department.SelectedIndex]["id"] + " WHERE `user_id` = " + userID);
                    }
                    else
                    {
                        //if the edited user is a department head 
                        MySqlCommand checkIfDeptIsTaken = new MySqlCommand("SELECT * FROM `department_heads` WHERE `status` = 1 AND `department_id` = @deptID AND `department_id` != 0 AND `id` != @userID AND `id` != 0");
                        checkIfDeptIsTaken.Parameters.AddWithValue("@deptID", departments.Rows[cbx_department.SelectedIndex]["id"]);
                        checkIfDeptIsTaken.Parameters.AddWithValue("@userID", userID);

                        if(connection.parseDataTableFromDB_secure(checkIfDeptIsTaken, updateUserCon).Rows.Count > 0)
                        {
                            DialogResult result = MessageBox.Show("There is already a head assigned to this department. Would you still like to reassign this user as department head?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if(result == DialogResult.Yes)
                            {
                                //set previous department head to be departmentless
                                MySqlCommand destroyPreviousHead = new MySqlCommand("UPDATE `department_heads` SET `department_id` = 0 WHERE `department_id` = @deptID");
                                destroyPreviousHead.Parameters.AddWithValue("@deptID", departments.Rows[cbx_department.SelectedIndex]["id"]);
                                connection.executeQuery_secure(destroyPreviousHead, updateUserCon);
                            }
                            else
                            {
                                return;
                            }
                        }
                        //otherwise, update every department to assign the current user as the new head
                        MySqlCommand updateDepartment = new MySqlCommand("UPDATE `departments` SET `head_id` = @userID WHERE `id` = @deptID");
                        updateDepartment.Parameters.AddWithValue("@userID", userID);
                        updateDepartment.Parameters.AddWithValue("@deptID", departments.Rows[cbx_department.SelectedIndex]["id"]);

                        connection.executeQuery_secure(updateDepartment, updateUserCon);

                        //also set the dept head's former department to be vacant if they changed department
                        if (Convert.ToInt32(departments.Rows[cbx_department.SelectedIndex]["id"]) != Convert.ToInt32(userInfo.Rows[0]["department_id"]))
                        {
                            //connection.executeQuery("UPDATE `departments` SET `head_id` = 0 WHERE `id` = " + userInfo.Rows[0]["department_id"]);
                            MySqlCommand updateDepartmentToVacant = new MySqlCommand("UPDATE `departments` SET `head_id` = 0 WHERE `id` = @deptID");
                            updateDepartmentToVacant.Parameters.AddWithValue("@deptID", userInfo.Rows[0]["department_id"]);
                            connection.executeQuery_secure(updateDepartmentToVacant, updateUserCon);
                        }
                        //set any inactive department heads assigned to this department to be vacant
                        ///connection.executeQuery("UPDATE `department_heads` SET `department_id` = 0 WHERE `status` = 0 AND `department_id` = " + departments.Rows[cbx_department.SelectedIndex]["id"]);
                    }
                }

                query += " WHERE `id` = " + userID;
                connection.executeQuery(query, updateUserCon);
                updateUserCon.Close();
            }
            catch
            {
                MessageBox.Show("Something went wrong. Check if you inputted everything correctly.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.Close();
        }

        private void btn_updatePassword_Click(object sender, EventArgs e)
        {
            //define the form to be opened after the password confirmation screen
            z_misc.changePassword changePassword = new z_misc.changePassword(userID, userPermLevel);
            
            //create the password confirmations creen
            z_misc.enterPassword passwordConfirmation = new z_misc.enterPassword(changePassword, userID, userPermLevel);
            passwordConfirmation.FormClosed += (s, args) => this.Show();
            passwordConfirmation.Show();
            this.Hide();
        }
    }
}

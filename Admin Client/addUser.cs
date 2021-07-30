using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OJT_Project.Admin_Client
{
    public partial class userRegistration : MetroFramework.Forms.MetroForm
    {
        DataTable departments = new DataTable();
        DataTable roles = new DataTable();
        public userRegistration()
        {
            InitializeComponent();
        }

        private void userRegistration_Load(object sender, EventArgs e)
        {
            //parse all departments from the database and cache the result
            departments = connection.parseDataTableFromDB_secure(new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `departments` WHERE `status` = 1 ORDER BY `id`"));
            globalFunctions.addDbInfoToComboBox(cbx_department, departments, "deptName");
        }

        private void cbx_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set selectable roles depending on department
            MySql.Data.MySqlClient.MySqlCommand retrieveRoles = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `roles` WHERE `department_id` = @deptID ORDER BY `id`");
            retrieveRoles.Parameters.AddWithValue("@deptID" ,departments.Rows[cbx_department.SelectedIndex]["id"]);

            roles = connection.parseDataTableFromDB_secure(retrieveRoles);
            
            //clear role items before adding the ones from the database
            globalFunctions.addDbInfoToComboBox(cbx_role, roles, "role");
        }

        private void btn_generatePassword_Click(object sender, EventArgs e)
        {
            tbx_password.Text = globalFunctions.randomPassword(8);
        }

        //generates a random password 

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to quit? All currently inputted user credentials will be lost.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void cbx_permissions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set everything to visible
            lbl_department.Visible = true;
            lbl_role.Visible = true;
            cbx_department.Visible = true;
            cbx_role.Visible = true;

            switch (cbx_permissions.SelectedIndex) 
            {
                case 0:
                    //if registering a user, department and role are visible
                    //change nothing
                    break;

                case 2:
                    //if registering an admin, hide department
                    lbl_department.Visible = false;
                    cbx_department.Visible = false;

                    //no break so that it executes case 1 as well, which will deactivate the role
                    goto case 1;

                case 1:
                    //if registering a department head, role is hidden
                    lbl_role.Visible = false;
                    cbx_role.Visible = false;
                    departments = connection.parseDataTableFromDB_secure(new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `departments` WHERE `status` = 1 AND `head_id` = 0 ORDER BY `id`"));
                    globalFunctions.addDbInfoToComboBox(cbx_department, departments, "deptName");
                    break;
            }
        }

        private void btn_addUser_Click(object sender, EventArgs e)
        {
            //lbl_debug.Text = hashing.GetHashString(tbx_password.Text.Trim() + tbx_username.Text.Trim());
            int id;
            
            //initialize sql commands to use across all 3 cases
            MySql.Data.MySqlClient.MySqlCommand insertUser;
            MySql.Data.MySqlClient.MySqlCommand retrieveID;
            MySql.Data.MySqlClient.MySqlCommand updatePassword;


            switch (cbx_permissions.SelectedIndex)
            {
                case 0:
                    //insert info into user without password                    
                    //use SQL Parameters for security reasons
                    insertUser = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO `users` (`username`, `email`, `department_id`, `role_id`) VALUES (@username, @email, @deptID, @roleID)");
                    insertUser.Parameters.AddWithValue("@username", tbx_username.Text.Trim());
                    insertUser.Parameters.AddWithValue("@email", tbx_email.Text.Trim());
                    insertUser.Parameters.AddWithValue("@deptID", departments.Rows[cbx_department.SelectedIndex]["id"]);
                    insertUser.Parameters.AddWithValue("@roleID", roles.Rows[cbx_role.SelectedIndex]["id"]);

                    connection.executeQuery_secure(insertUser);

                    //retrive ID from newly created entry
                    retrieveID = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `users` WHERE `email` = @email AND `username` = @username AND `password` = ''");
                    retrieveID.Parameters.AddWithValue("@email", tbx_email.Text.Trim());
                    retrieveID.Parameters.AddWithValue("@username", tbx_username.Text.Trim());

                    id = Convert.ToInt32(connection.parseDataTableFromDB_secure(retrieveID).Rows[0]["id"]);

                    //update the password
                    updatePassword = new MySql.Data.MySqlClient.MySqlCommand("UPDATE `users` SET `password` = @password WHERE `id` = @id");
                    updatePassword.Parameters.AddWithValue("@password", hashing.GetHashString(tbx_password.Text + id));
                    updatePassword.Parameters.AddWithValue("@id", id);

                    connection.executeQuery_secure(updatePassword);
                    break;

                case 1:
                    //check if department is taken
                    if(Convert.ToInt32(departments.Rows[cbx_department.SelectedIndex]["head_id"]) != 0)
                    {
                        MessageBox.Show("There is already a head assigned to this department.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    //insert info into user without password
                    insertUser = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO `department_heads` (`username`, `email`, `department_id`) VALUES (@username, @email, @deptID)");
                    insertUser.Parameters.AddWithValue("@username", tbx_username.Text.Trim());
                    insertUser.Parameters.AddWithValue("@email", tbx_email.Text.Trim());
                    insertUser.Parameters.AddWithValue("@deptID", departments.Rows[cbx_department.SelectedIndex]["id"]);

                    connection.executeQuery_secure(insertUser);

                    //retrive ID from newly created entry
                    retrieveID = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `department_heads` WHERE `email` = @email AND `username` = @username AND `password` = ''");
                    retrieveID.Parameters.AddWithValue("@email", tbx_email.Text.Trim());
                    retrieveID.Parameters.AddWithValue("@username", tbx_username.Text.Trim());

                    id = Convert.ToInt32(connection.parseDataTableFromDB_secure(retrieveID).Rows[0]["id"]);

                    //update password
                    updatePassword = new MySql.Data.MySqlClient.MySqlCommand("UPDATE `department_heads` SET `password` = @password WHERE `id` = @id");
                    updatePassword.Parameters.AddWithValue("@password", hashing.GetHashString(tbx_password.Text + id));
                    updatePassword.Parameters.AddWithValue("@id", id);

                    connection.executeQuery_secure(updatePassword);

                    //update the department to set this new person as the head
                    if (Convert.ToInt32(departments.Rows[cbx_department.SelectedIndex]["id"]) != 0)
                    {
                        MySql.Data.MySqlClient.MySqlCommand updateDept = new MySql.Data.MySqlClient.MySqlCommand("UPDATE `departments` SET `head_id` = @id WHERE `id` = @deptID");
                        updateDept.Parameters.AddWithValue("@id", id);
                        updateDept.Parameters.AddWithValue("@deptID", departments.Rows[cbx_department.SelectedIndex]["id"]);
                        connection.executeQuery_secure(updateDept);
                    }
                    break;

                case 2:
                    //insert info into admin without password
                    //connection.executeQuery("INSERT INTO `admins` (`username`, `email`) VALUES ('" + tbx_username.Text.Trim() + "', '" + tbx_email.Text.Trim() + "')");
                    insertUser = new MySql.Data.MySqlClient.MySqlCommand("INSERT INTO `admins` (`username`, `email`) VALUES (@username, @email)");
                    insertUser.Parameters.AddWithValue("@username", tbx_username.Text.Trim());
                    insertUser.Parameters.AddWithValue("@email", tbx_email.Text.Trim());

                    connection.executeQuery_secure(insertUser);

                    //retrieve ID from the newly created entry
                    //id = Convert.ToInt32(connection.parseDataTableFromDB("SELECT * FROM `admins` WHERE `email` = '" + tbx_email.Text.Trim() + "' AND `username` = '" + tbx_username.Text.Trim() + "' AND `password` = ''").Rows[0]["id"]);
                    retrieveID = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `admins` WHERE `email` = @email AND `username` = @username AND `password` = ''");
                    retrieveID.Parameters.AddWithValue("@email", tbx_email.Text.Trim());
                    retrieveID.Parameters.AddWithValue("@username", tbx_username.Text.Trim());

                    id = Convert.ToInt32(connection.parseDataTableFromDB_secure(retrieveID).Rows[0]["id"]);

                    //set password to equal to the hash of the inputted password with the id appeneded to the end
                    updatePassword = new MySql.Data.MySqlClient.MySqlCommand("UPDATE `admins` SET `password` = @password WHERE `id` = @id");
                    updatePassword.Parameters.AddWithValue("@password", hashing.GetHashString(tbx_password.Text + id));
                    updatePassword.Parameters.AddWithValue("@id", id);

                    connection.executeQuery_secure(updatePassword);
                    break;

                default:
                    MessageBox.Show("You shouldn't be seeing this. If you do see this, then I definitely fucked up somewhere");
                    break;
            }

            DialogResult result = MessageBox.Show("User " + tbx_username.Text.Trim() + " has been successfully registered into the database. Would you like to add another user?", "Success", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes) 
            {
                tbx_email.Clear();
                tbx_password.Clear();
                tbx_username.Clear();
                cbx_permissions.SelectedIndex = 0;
            }
            else 
            {
                this.Close();
            }
        }
    }
}

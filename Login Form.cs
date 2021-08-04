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


namespace OJT_Project
{
    public partial class loginForm : MetroFramework.Forms.MetroForm
    {
        public loginForm()
        {
            InitializeComponent();
        }

        private void tbl_controls_Paint(object sender, PaintEventArgs e)
        {
            //login(tbx_username.Text.Trim(), tbx_password.Text.Trim());
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            login(tbx_username.Text.Trim(), tbx_password.Text.Trim());
        }

        //function for logging in
        private void login(string username, string password) 
        {
            //select the user's password where user is username

            //check which permission level is selected to identify which form to load
            MySqlCommand query = new MySqlCommand();
            switch (cbx_permissionLevel.SelectedIndex) 
            {
                case 0:
                    query = new MySqlCommand("SELECT * FROM `users` WHERE `users`.`username` = @username;");
                    break;
                
                case 1:
                    query = new MySqlCommand("SELECT * FROM `department_heads` WHERE `department_heads`.`username` = @username;");
                    break;

                case 2:
                    query = new MySqlCommand("SELECT * FROM `admins` WHERE `admins`.`username` = @username;");
                    break;
                default:
                    lbl_validationCheck.Text = "Select a permissions level.";
                    return;
            }
            query.Parameters.AddWithValue("@username", username);
            //parses profile data from database and caches result
            MySqlConnection loginCon = new MySqlConnection(connection.DatabaseConnection);
            loginCon.OpenWithWarning();

            DataTable userInfo = connection.parseDataTableFromDB_secure(query, loginCon);
            loginCon.Close();

            string output = "";
            //check if user is null before checking password
            if (userInfo.Rows.Count > 0)
            {
                output = Convert.ToString(userInfo.Rows[0]["password"]);
            }
            try
            {
                if (hashing.GetHashString(password + userInfo.Rows[0]["id"]) == output && password != "" && Convert.ToInt32(userInfo.Rows[0]["status"]) == 1)
                {
                    lbl_validationCheck.Text = "sucessfully logged in!";

                    //assign user info to the user static class to be referenced by the rest of the program
                    user.id = Convert.ToInt32(userInfo.Rows[0]["id"]);
                    user.username = Convert.ToString(userInfo.Rows[0]["username"]);
                    user.email = Convert.ToString(userInfo.Rows[0]["email"]);
                    user.permissionLevel = cbx_permissionLevel.SelectedIndex;

                    //if the user is not an admin then register department ID, if user is not a dept head then register role id
                    //To prevent any errors, since admins dont have dept IDs and dept heads don't have role IDs
                    if (cbx_permissionLevel.SelectedIndex != 2)
                    {
                        user.deptID = Convert.ToInt32(userInfo.Rows[0]["department_id"]);
                        if (cbx_permissionLevel.SelectedIndex == 0)
                        {
                            user.roleID = Convert.ToInt32(userInfo.Rows[0]["role_id"]);
                        }
                    }

                    this.Hide();
                    dashboard dash = new dashboard();
                    dash.FormClosed += (s, args) => this.Close();
                    dash.Show();
                }
                else
                {
                    lbl_validationCheck.Text = "Invalid username or password";
                }
            }
            catch 
            {
                lbl_validationCheck.Text = "Invalid username or password";
            }
        }

        private void loginForm_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void lbl_forgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            z_misc.forgotPassword passwordForm = new z_misc.forgotPassword();
            passwordForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            passwordForm.Show();
        }
    }
}

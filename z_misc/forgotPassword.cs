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
using System.Net;
using System.Net.Mail;

namespace OJT_Project.z_misc
{
    public partial class forgotPassword : MetroFramework.Forms.MetroForm
    {

        public forgotPassword()
        {
            InitializeComponent();
        }

        private void forgotPassword_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            MySqlConnection confirmCon = new MySqlConnection(connection.DatabaseConnection);
            confirmCon.OpenWithWarning();

            //check if user is registered in the database
            MySqlCommand checkIfUserExists = new MySqlCommand(
                "SELECT `email` FROM `users` WHERE `status` = 1 AND `email` = @email UNION " +
                "SELECT `email` FROM `department_heads` WHERE `status` = 1 AND `email` = @email UNION " +
                "SELECT `email` FROM `admins` WHERE `status` = 1 AND `email` = @email");
            checkIfUserExists.Parameters.AddWithValue("@email", tbx_email.Text.Trim());

            DataTable usersWithThisEmail = connection.parseDataTableFromDB_secure(checkIfUserExists, confirmCon);
            //if user exists, send them an email featuring the one time password
            if(usersWithThisEmail.Rows.Count > 0)
            {
                string oneTimePassword = globalFunctions.randomPassword(4);
                globalFunctions.sendEmail(tbx_email.Text.Trim(), "Password Reset", "One Time Password: " + oneTimePassword);

                //check if user already has a password reset ticket
                MySqlCommand checkOTP = new MySqlCommand("SELECT * FROM `temp_passwords` WHERE `email` = @email");
                checkOTP.Parameters.AddWithValue("@email", tbx_email.Text.Trim());
                
                //if the user already has a password reset ticket, update the temp password to the current one
                if(connection.parseDataTableFromDB_secure(checkOTP, confirmCon).Rows.Count > 0)
                {
                    MySqlCommand updateOTP = new MySqlCommand("UPDATE `temp_passwords` SET `password` = @currentPassword WHERE `email` = @email");
                    updateOTP.Parameters.AddWithValue("@currentPassword", oneTimePassword);
                    updateOTP.Parameters.AddWithValue("@email", tbx_email.Text.Trim());
                    connection.executeQuery_secure(updateOTP, confirmCon);
                }
                //if user does not have a password reset ticket, then make one
                else
                {
                    MySqlCommand addOTP = new MySqlCommand("INSERT INTO `temp_passwords` (`password`, `email`) VALUES (@password, @email)");
                    addOTP.Parameters.AddWithValue("@password", oneTimePassword);
                    addOTP.Parameters.AddWithValue("@email", tbx_email.Text.Trim());
                    connection.executeQuery_secure(addOTP, confirmCon);
                }
            }
            else
            {
                MessageBox.Show("This email is not registered in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                confirmCon.Close();
                return;
            }
            MessageBox.Show("A message has been sent to your email containing your one time password");
            //open the OTP confirmation form
            oneTimePasswordVerification OTP = new oneTimePasswordVerification(tbx_email.Text.Trim());
            OTP.FormClosed += (s, args) => this.Close();
            OTP.Show();
            confirmCon.Close();
            this.Hide();
            //MySqlCommand getEmail = new MySqlCommand("");
        }
    }
}

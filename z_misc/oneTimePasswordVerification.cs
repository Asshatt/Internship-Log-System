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

namespace OJT_Project.z_misc
{
    public partial class oneTimePasswordVerification : MetroFramework.Forms.MetroForm
    {
        string userEmail = "";
        public oneTimePasswordVerification(string email)
        {
            userEmail = email;
            InitializeComponent();
        }

        private void oneTimePasswordVerification_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            //check if OTP is valid
            MySqlCommand validateOTP = new MySqlCommand("SELECT `password` FROM `temp_passwords` WHERE `email` = @email");
            validateOTP.Parameters.AddWithValue("@email", userEmail);
            if(Convert.ToString(connection.parseDataTableFromDB_secure(validateOTP).Rows[0][0]) == tbx_otp.Text.Trim())
            {
                //remove the OTP from the database
                MySqlCommand removeOTP = new MySqlCommand("DELETE FROM `temp_passwords` WHERE `email` = @email");
                removeOTP.Parameters.AddWithValue("@email", userEmail);
                connection.executeQuery_secure(removeOTP);

                //check for user's permission level
                int permLevel = 0;
                int id = 0;
                DataTable userSearch = connection.parseDataTableFromDB("SELECT `id` FROM `users` WHERE `status` = 1 AND `email` = '" + userEmail + "'");
                DataTable deptHeadSearch = connection.parseDataTableFromDB("SELECT `id` FROM `department_heads` WHERE `status` = 1 AND `email` = '" + userEmail + "'");
                if (userSearch.Rows.Count > 0)
                {
                    id = Convert.ToInt32(userSearch.Rows[0][0]);
                    permLevel = 0;
                }
                else if(deptHeadSearch.Rows.Count > 0)
                {
                    id = Convert.ToInt32(deptHeadSearch.Rows[0][0]);
                    permLevel = 1;
                }
                else
                {
                    id = Convert.ToInt32(connection.parseDataTableFromDB("SELECT `id` FROM `admins` WHERE `status` = 1 AND `email` = '" + userEmail + "'").Rows[0][0]);
                    permLevel = 2;
                }
                changePassword passwordUpdate = new changePassword(id, permLevel);
                passwordUpdate.FormClosed += (s, args) => this.Close();
                this.Hide();
                passwordUpdate.Show();
            }
            else
            {
                MessageBox.Show("Invalid Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

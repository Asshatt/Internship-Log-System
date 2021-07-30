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
    public partial class changePassword : MetroFramework.Forms.MetroForm
    {
        int userID;
        int userPermLevel;

        public changePassword(int id, int permLevel)
        {
            userID = id;
            userPermLevel = permLevel;
            InitializeComponent();
            Console.WriteLine(userID + ", " + userPermLevel);
        }

        private void changePassword_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            //check if both password inputs are equal to each other
            if(tbx_password1.Text.Trim() == tbx_password2.Text.Trim())
            {
                MySqlCommand updatePassword = new MySqlCommand();
                //update the password
                switch (userPermLevel)
                {
                    //user
                    case 0:
                        updatePassword = new MySqlCommand("UPDATE `users` SET `password` = @password WHERE `id` = @id");
                        break;
                    
                    //dept heads
                    case 1:
                        updatePassword = new MySqlCommand("UPDATE `department_heads` SET `password` = @password WHERE `id` = @id");
                        break;

                    //admins
                    case 2:
                        updatePassword = new MySqlCommand("UPDATE `admins` SET `password` = @password WHERE `id` = @id");
                        break;
                }
                updatePassword.Parameters.AddWithValue("@password", hashing.GetHashString(tbx_password1.Text.Trim() + userID));
                updatePassword.Parameters.AddWithValue("@id", userID);

                connection.executeQuery_secure(updatePassword);

                MessageBox.Show("Your password has been updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            else
            {
                MessageBox.Show("Passwords are not equal.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbx_password2_TextChanged(object sender, EventArgs e)
        {
            lbl_passwordConfirmation.Visible = false;
        }

        private void tbx_password2_Leave(object sender, EventArgs e)
        {
            if(tbx_password2.Text.Trim() == tbx_password1.Text.Trim())
            {
                lbl_passwordConfirmation.Visible = false;
            }
            else
            {
                lbl_passwordConfirmation.Visible = true;
            }
        }
    }
}

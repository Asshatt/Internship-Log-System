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
    public partial class enterPassword : MetroFramework.Forms.MetroForm
    {
        MetroFramework.Forms.MetroForm openOnCorrectPassword;
        int userID;
        int userPermLevel;
        string correctPassword;


        public enterPassword(MetroFramework.Forms.MetroForm newForm, int id, int permLevel)
        {
            userID = id;
            userPermLevel = permLevel;
            openOnCorrectPassword = newForm;
            openOnCorrectPassword.FormClosed += (s, args) => this.Close();
            InitializeComponent();
        }

        private void enterPassword_Load(object sender, EventArgs e)
        {
            MySqlConnection passwordCon = new MySqlConnection(connection.DatabaseConnection);

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            //get the password of the currentUser
            MySqlCommand getPassword = new MySqlCommand();
            switch (userPermLevel)
            {
                case 0:
                    getPassword = new MySqlCommand("SELECT `password` FROM `users` WHERE `id` = @id");
                    break;

                case 1:
                    getPassword = new MySqlCommand("SELECT `password` FROM `department_heads` WHERE `id` = @id");
                    break;

                case 2:
                    getPassword = new MySqlCommand("SELECT `password` FROM `admins` WHERE `id` = @id");
                    break;
            }
            getPassword.Parameters.AddWithValue("@id", userID);
            DataTable userInfo = connection.parseDataTableFromDB_secure(getPassword, passwordCon);
            correctPassword = Convert.ToString(userInfo.Rows[0][0]);
            passwordCon.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_submit_Click(object sender, EventArgs e)
        {
            if(correctPassword == hashing.GetHashString(tbx_password.Text.Trim() + userID))
            {
                openOnCorrectPassword.Show();
            }
            else
            {
                MessageBox.Show("Invalid Password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

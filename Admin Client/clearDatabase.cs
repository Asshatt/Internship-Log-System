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
    public partial class clearDatabase : MetroFramework.Forms.MetroForm
    {
        public clearDatabase()
        {
            InitializeComponent();
        }

        private void clearDatabase_Load(object sender, EventArgs e)
        {

        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            //delete all tasks
            connection.executeQuery("DELETE FROM `tasks`");
            //delete all activities and sub-activities with status 0
            connection.executeQuery("DELETE FROM `sub_activities` WHERE `status` = 0");
            connection.executeQuery("DELETE FROM `activities` WHERE `status` = 0");
            //delete all users with status of 0
            connection.executeQuery("DELETE FROM `users` WHERE `status` = 0");
            connection.executeQuery("DELETE FROM `admins` WHERE `status` = 0");
            connection.executeQuery("DELETE FROM `department_heads` WHERE `status` = 0");
            //delete departments with status of 0
            connection.executeQuery("DELETE FROM `departments` WHERE `status` = 0");
            //delete roles with status of 0
            connection.executeQuery("DELETE FROM `roles` WHERE `status` = 0");

            this.Close();
        }
    }
}

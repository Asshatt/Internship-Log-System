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
            MySqlConnection confirmCon = new MySqlConnection(connection.DatabaseConnection);
            confirmCon.OpenWithWarning();

            //delete all tasks
            MySqlCommand deleteBetweenDates = new MySqlCommand("DELETE FROM `tasks` WHERE (`startTime` BETWEEN @startTime AND @endTime)");
            deleteBetweenDates.Parameters.AddWithValue("@startTime", dtp_startTime.Value.Date.AddSeconds(0.1f).ToString(globalFunctions.sqlDateFormat));
            deleteBetweenDates.Parameters.AddWithValue("@endTime", dtp_startTime.Value.Date.AddHours(23.9999f).ToString(globalFunctions.sqlDateFormat));
            connection.executeQuery_secure(deleteBetweenDates, confirmCon);
            //delete all activities and sub-activities with status 0
            connection.executeQuery("DELETE FROM `sub_activities` WHERE `status` = 0", confirmCon);
            connection.executeQuery("DELETE FROM `activities` WHERE `status` = 0", confirmCon);
            //delete all users with status of 0
            connection.executeQuery("DELETE FROM `users` WHERE `status` = 0", confirmCon);
            connection.executeQuery("DELETE FROM `admins` WHERE `status` = 0", confirmCon);
            connection.executeQuery("DELETE FROM `department_heads` WHERE `status` = 0 AND `id` != 0", confirmCon);
            //delete departments with status of 0
            connection.executeQuery("DELETE FROM `departments` WHERE `status` = 0 AND `id` != 0", confirmCon);
            //delete roles with status of 0
            connection.executeQuery("DELETE FROM `roles` WHERE `status` = 0", confirmCon);
            confirmCon.Close();
            this.Close();
        }
    }
}

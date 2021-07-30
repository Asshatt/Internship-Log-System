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
    public partial class editDepartments : MetroFramework.Forms.MetroForm
    {
        public editDepartments()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateDepartmentPreview()
        {
            this.Show();
            flp_departments.Controls.Clear();
            MySqlCommand selectAllDepartments = new MySqlCommand("SELECT * FROM `departments` WHERE `status` = 1 AND `id` != 0");
            DataTable allDepartments = connection.parseDataTableFromDB_secure(selectAllDepartments);

            for (int i = 0; i < allDepartments.Rows.Count; i++)
            {
                indexedRadioButton deptButton = new indexedRadioButton();
                deptButton.id = Convert.ToInt32(allDepartments.Rows[i]["id"]);
                deptButton.Text = Convert.ToString(allDepartments.Rows[i]["deptName"]);
                if (Convert.ToInt32(allDepartments.Rows[i]["head_id"]) == 0)
                {
                    deptButton.Text += " [VACANT]";
                }

                deptButton.AutoSize = true;
                deptButton.AutoEllipsis = false;
                flp_departments.Controls.Add(deptButton);
            }
        }

        private void editDepartments_Load(object sender, EventArgs e)
        {
            updateDepartmentPreview();
        }

        private void btn_removeDepartment_Click(object sender, EventArgs e)
        {
            indexedRadioButton selectedButton = globalFunctions.getCheckedRadio(flp_departments);
            if (selectedButton == null)
            {
                MessageBox.Show("Select a department to delete.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MySqlCommand removeDepartment = new MySqlCommand("UPDATE `departments` SET `status` = 0 WHERE `id` = @id");
            removeDepartment.Parameters.AddWithValue("@id", selectedButton.id);
            connection.executeQuery_secure(removeDepartment);

            MySqlCommand updateDepartmentHead = new MySqlCommand("UPDATE `department_heads` SET `department_id` = 0 WHERE `department_id` = @deptID");
            updateDepartmentHead.Parameters.AddWithValue("@deptID", selectedButton.id);
            connection.executeQuery_secure(updateDepartmentHead);

            MySqlCommand updateUsers = new MySqlCommand("UPDATE `users` SET `department_id` = 0 WHERE `department_id` = @deptID");
            updateUsers.Parameters.AddWithValue("@deptID", selectedButton.id);
            connection.executeQuery_secure(updateUsers);

            updateDepartmentPreview();
        }

        private void btn_addDepartment_Click(object sender, EventArgs e)
        {
            addDepartments deptAdd = new addDepartments();
            deptAdd.FormClosed += (s, args) => updateDepartmentPreview();
            this.Hide();
            deptAdd.Show();
        }

        private void btn_updateDepartment_Click(object sender, EventArgs e)
        {
            indexedRadioButton selectedButton = globalFunctions.getCheckedRadio(flp_departments);
            if (selectedButton == null)
            {
                MessageBox.Show("Select a department to update.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            updateDepartments updateScreen = new updateDepartments(selectedButton.id);
            updateScreen.FormClosed += (s, args) => this.Show();
            updateScreen.Show();
            this.Hide();
        }
    }
}

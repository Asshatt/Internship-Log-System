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
    public partial class updateDepartments : MetroFramework.Forms.MetroForm
    {
        int deptID;
        DataTable deptInfo;
        DataTable deptHeads;

        public updateDepartments(int id)
        {
            deptID = id;
            //search for info of current department
            MySqlCommand searchForDeptInfo = new MySqlCommand("SELECT * FROM `departments` WHERE `id` = @deptID");
            searchForDeptInfo.Parameters.AddWithValue("@deptID", deptID);
            deptInfo = connection.parseDataTableFromDB_secure(searchForDeptInfo);

            deptHeads = connection.parseDataTableFromDB("SELECT * FROM `department_heads` WHERE `status` = 1");

            InitializeComponent();
        }

        private void updateDepartments_Load(object sender, EventArgs e)
        {
            tbx_deptName.Text = deptInfo.Rows[0]["deptName"].ToString();

            for (int i = 0; i < deptHeads.Rows.Count; i++)
            {
                string item = deptHeads.Rows[i]["username"].ToString();
                if (Convert.ToInt32(deptHeads.Rows[i]["department_id"]) == 0)
                {
                    item += " [VACANT]";
                }
                cbx_deptHead.Items.Add(item);

                if (Convert.ToInt32(deptHeads.Rows[i]["id"]) == Convert.ToInt32(deptInfo.Rows[0]["head_id"]))
                {
                    cbx_deptHead.SelectedIndex = i;
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_addDepartment_Click(object sender, EventArgs e)
        {
            //if department head changed
            if (deptInfo.Rows[0]["head_id"] != deptHeads.Rows[cbx_deptHead.SelectedIndex]["id"])
            {
                //set new department head's department id
                MySqlCommand setNewDepartmentHeadID = new MySqlCommand("UPDATE `department_heads` SET `department_id` = @deptID WHERE `id` = @id");
                setNewDepartmentHeadID.Parameters.AddWithValue("@deptID", deptID);
                setNewDepartmentHeadID.Parameters.AddWithValue("@id", deptHeads.Rows[cbx_deptHead.SelectedIndex]["id"]);
                connection.executeQuery_secure(setNewDepartmentHeadID);

                MySqlCommand setOldDepartmentHeadID = new MySqlCommand("UPDATE `department_heads` SET `department_id` = 0 WHERE `id` = @id");
                setOldDepartmentHeadID.Parameters.AddWithValue("@id", deptInfo.Rows[0]["head_id"]);
                connection.executeQuery_secure(setOldDepartmentHeadID);
            }

            MySqlCommand updateDepartment = new MySqlCommand("UPDATE `departments` SET `head_id` = @headID, `deptName` = @deptName WHERE `id` = @deptID");
            updateDepartment.Parameters.AddWithValue("@headID", deptHeads.Rows[cbx_deptHead.SelectedIndex]["id"]);
            updateDepartment.Parameters.AddWithValue("@deptName", tbx_deptName.Text.Trim());
            updateDepartment.Parameters.AddWithValue("@deptID", deptID);
            connection.executeQuery_secure(updateDepartment);
            this.Close();
        }
    }
}

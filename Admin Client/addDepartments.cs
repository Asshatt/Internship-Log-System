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
    public partial class addDepartments : MetroFramework.Forms.MetroForm
    {
        DataTable deptHeads;
        public addDepartments()
        {
            InitializeComponent();
        }

        private void addDepartments_Load(object sender, EventArgs e)
        {
            MySqlConnection load = new MySqlConnection(connection.DatabaseConnection);
            load.OpenWithWarning();

            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            //add department heads to the combobox
            cbx_deptHead.Items.Clear();
            deptHeads = connection.parseDataTableFromDB("SELECT * FROM `department_heads` WHERE `status` = 1", load);
            for(int i = 0; i < deptHeads.Rows.Count; i++)
            {
                string deptHeadName = Convert.ToString(deptHeads.Rows[i]["username"]);
                if(Convert.ToInt32(deptHeads.Rows[i]["department_id"]) == 0 && Convert.ToInt32(deptHeads.Rows[i]["id"]) != 0)
                {
                    deptHeadName += " [VACANT]";
                }
                cbx_deptHead.Items.Add(deptHeadName);
            }
            load.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_addDepartment_Click(object sender, EventArgs e)
        {
            if(cbx_deptHead.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a department head.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(tbx_deptName.Text.Trim() == "")
            {
                MessageBox.Show("Please set a name for this department.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //open the connection
            MySqlConnection addDeptCon = new MySqlConnection(connection.DatabaseConnection);
            addDeptCon.OpenWithWarning();

            if (Convert.ToInt32(deptHeads.Rows[cbx_deptHead.SelectedIndex]["department_id"]) != 0)
            {
                DialogResult result = MessageBox.Show("The selected department head is already assigned to a department. Are you sure you want to reassign them?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (result == DialogResult.No)
                {
                    addDeptCon.Close();
                    return;
                }
            }

            MySqlCommand searchForDepartments = new MySqlCommand("SELECT `deptName` FROM `departments` WHERE `deptName` = @deptName AND `status` = 1");
            searchForDepartments.Parameters.AddWithValue("@deptName", tbx_deptName.Text.Trim());


            MySqlCommand searchForDepartments_inactive = new MySqlCommand("SELECT `deptName` FROM `departments` WHERE `deptName` = @deptName AND `status` = 0");
            searchForDepartments_inactive.Parameters.AddWithValue("@deptName", tbx_deptName.Text.Trim());

            if (tbx_deptName.Text.Trim() == "")
            {
                MessageBox.Show("Set a name for this new department.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                addDeptCon.Close();
                return;
            }
            else if (connection.parseDataTableFromDB_secure(searchForDepartments, addDeptCon).Rows.Count > 0)
            {
                MessageBox.Show("This department already exists.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                addDeptCon.Close();
                return;
            }
            else if (connection.parseDataTableFromDB_secure(searchForDepartments_inactive, addDeptCon).Rows.Count > 0)
            {
                MySqlCommand updateInactiveDept = new MySqlCommand("UPDATE `departments` SET `head_id` = @headID, `status` = 1 WHERE `deptName` = @deptName");
                updateInactiveDept.Parameters.AddWithValue("@headID", Convert.ToInt32(deptHeads.Rows[cbx_deptHead.SelectedIndex]["id"]));
                updateInactiveDept.Parameters.AddWithValue("@deptName", tbx_deptName.Text.Trim());
                connection.executeQuery_secure(updateInactiveDept, addDeptCon);
            }
            else
            {
                MySqlCommand addDepartment = new MySqlCommand("INSERT INTO `departments` (`deptName`, `head_id`) VALUES (@deptName, @headID)");
                addDepartment.Parameters.AddWithValue("@deptName", tbx_deptName.Text.Trim());
                addDepartment.Parameters.AddWithValue("@headID", Convert.ToInt32(deptHeads.Rows[cbx_deptHead.SelectedIndex]["id"]));
                connection.executeQuery_secure(addDepartment, addDeptCon);
            }
            //if dept head is not "no head" then update their thing
            if (Convert.ToInt32(deptHeads.Rows[cbx_deptHead.SelectedIndex]["id"]) != 0)
            {
                MySqlCommand searchDeptID = new MySqlCommand("SELECT `id` FROM `departments` WHERE `deptName` = @deptName");
                searchDeptID.Parameters.AddWithValue("@deptName", tbx_deptName.Text.Trim());
                int newDeptID = int.Parse(Convert.ToString(connection.parseDataTableFromDB_secure(searchDeptID, addDeptCon).Rows[0][0]));

                MySqlCommand updateUser = new MySqlCommand("UPDATE `department_heads` SET `department_id` = @deptID WHERE `id` = @id");
                updateUser.Parameters.AddWithValue("@id", Convert.ToInt32(deptHeads.Rows[cbx_deptHead.SelectedIndex]["id"]));
                updateUser.Parameters.AddWithValue("@deptID", newDeptID);
                connection.executeQuery_secure(updateUser, addDeptCon);

                MySqlCommand updatePreviousDept = new MySqlCommand("UPDATE `departments` SET `head_id` = 0 WHERE `head_id` = @headID AND `id` != @newDeptID");
                updatePreviousDept.Parameters.AddWithValue("@headID", Convert.ToInt32(deptHeads.Rows[cbx_deptHead.SelectedIndex]["id"]));
                updatePreviousDept.Parameters.AddWithValue("@newDeptID", newDeptID);
                connection.executeQuery_secure(updatePreviousDept, addDeptCon);
            }

            addDeptCon.Close();
            this.Close();
        }
    }
}

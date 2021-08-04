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

namespace OJT_Project.Dept._Head_Client
{
    public partial class roleEditor : MetroFramework.Forms.MetroForm
    {
        public roleEditor()
        {
            InitializeComponent();
        }

        public void updateRoles()
        {
            MySqlConnection updateRoleCon = new MySqlConnection(connection.DatabaseConnection);
            flp_roleContainer.Controls.Clear();
            DataTable allRoles = connection.parseDataTableFromDB("SELECT * FROM `roles` WHERE `department_id` = " + user.deptID + " AND `status` = 1 ORDER BY `role`", updateRoleCon);
            updateRoleCon.Close();
            for (int i = 0; i < allRoles.Rows.Count; i++)
            {
                createRole(Convert.ToString(allRoles.Rows[i]["role"]), Convert.ToInt32(allRoles.Rows[i]["id"]));
            }
        }

        private void createRole(string roleInfo, int id)
        {
            //make table layout panel
            TableLayoutPanel tbl_subActivityHolder = new TableLayoutPanel();
            tbl_subActivityHolder.ColumnCount = 2;
            tbl_subActivityHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.67376F));
            tbl_subActivityHolder.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 19.32624F));
            tbl_subActivityHolder.Location = new System.Drawing.Point(3, 3);
            tbl_subActivityHolder.RowCount = 1;
            tbl_subActivityHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tbl_subActivityHolder.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            tbl_subActivityHolder.Size = new System.Drawing.Size(564, 44);
            tbl_subActivityHolder.TabIndex = 0;
            tbl_subActivityHolder.BackColor = Color.DarkGray;

            flp_roleContainer.Controls.Add(tbl_subActivityHolder);

            //make textbox
            indexedTextbox tbx_subActivityInput = new indexedTextbox();
            tbx_subActivityInput.Anchor = System.Windows.Forms.AnchorStyles.Left;
            tbx_subActivityInput.Location = new System.Drawing.Point(3, 9);
            tbx_subActivityInput.Name = "tbx_subActivity";
            tbx_subActivityInput.Text = roleInfo.Trim();
            tbx_subActivityInput.initialText = roleInfo.Trim();

            tbx_subActivityInput.Size = new System.Drawing.Size(449, 25);
            tbx_subActivityInput.TabIndex = 1;
            tbx_subActivityInput.id = id;
            tbx_subActivityInput.LostFocus += (s, args) => changeRoleName(tbx_subActivityInput.Text.Trim(), tbx_subActivityInput.id, tbx_subActivityInput);

            tbl_subActivityHolder.Controls.Add(tbx_subActivityInput);

            //make delete button
            indexedButton btn_deleteSubActivity = new indexedButton();
            btn_deleteSubActivity.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            btn_deleteSubActivity.Location = new System.Drawing.Point(458, 3);
            btn_deleteSubActivity.Name = "btn_delete";
            btn_deleteSubActivity.Size = new System.Drawing.Size(103, 38);
            btn_deleteSubActivity.TabIndex = 0;
            btn_deleteSubActivity.Text = "Delete";
            btn_deleteSubActivity.UseVisualStyleBackColor = true;
            btn_deleteSubActivity.id = id;
            btn_deleteSubActivity.Click += (s, args) => deleteRole(btn_deleteSubActivity.id);

            tbl_subActivityHolder.Controls.Add(btn_deleteSubActivity);
        }

        //whenever textbox is edited, update the sub-activity
        private void changeRoleName(string newName, int id, indexedTextbox tbx)
        {
            //if name hasn't been changed, then don't do anything
            if (newName == tbx.initialText)
            {
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to change this role?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }

            MySqlConnection updateRoleNameCon = new MySqlConnection(connection.DatabaseConnection);
            updateRoleNameCon.OpenWithWarning();

            tbx.initialText = newName;
            MySqlCommand updateRoleName = new MySqlCommand("UPDATE `roles` SET `role` = @newName WHERE `id` = @id");
            updateRoleName.Parameters.AddWithValue("@newName", newName);
            updateRoleName.Parameters.AddWithValue("@id", id);

            connection.executeQuery_secure(updateRoleName, updateRoleNameCon);
            //connection.executeQuery("UPDATE `roles` SET `role` = '" + newName + "' WHERE `id` = " + id);
            updateRoles();
            updateRoleNameCon.Close();
        }

        //event for deleting sub activity
        private void deleteRole(int id)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this role?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                return;
            }
            else
            {
                MySqlConnection deleteRoleCon = new MySqlConnection(connection.DatabaseConnection);
                deleteRoleCon.OpenWithWarning();
                connection.executeQuery("UPDATE `roles` SET `status` = 0 WHERE `roles`.`id` = " + id, deleteRoleCon);
                updateRoles();
                deleteRoleCon.Close();
            }
        }

        private void roleEditor_Load(object sender, EventArgs e)
        {
            this.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath);
            updateRoles();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_addRole_Click(object sender, EventArgs e)
        {
            MySqlConnection addRoleCon = new MySqlConnection(connection.DatabaseConnection);
            addRoleCon.OpenWithWarning();

            MySqlCommand selectExistingRoles = new MySqlCommand("SELECT * FROM `roles` WHERE `status` = 1 AND `role` = @roleName");
            selectExistingRoles.Parameters.AddWithValue("@roleName", tbx_roleName.Text.Trim());

            MySqlCommand selectExistingRoles_inactive = new MySqlCommand("SELECT * FROM `roles` WHERE `status` = 0 AND `role` = @roleName");
            selectExistingRoles_inactive.Parameters.AddWithValue("@roleName", tbx_roleName.Text.Trim());

            //if there is no inputted name, return
            if (tbx_roleName.Text.Trim() == "")
            {
                MessageBox.Show("Cannot make a role without a name.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                addRoleCon.Close();
                return;
            }
            //if role already exists and is active under the current activity, then return
            else if (connection.parseDataTableFromDB_secure(selectExistingRoles, addRoleCon).Rows.Count > 0)
            {
                MessageBox.Show("Role " + tbx_roleName.Text.Trim() + " already exists in your department.", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                addRoleCon.Close();
                return;
            }
            //if role already exists but is inactive, then reactivate it.
            else if (connection.parseDataTableFromDB_secure(selectExistingRoles_inactive, addRoleCon).Rows.Count > 0)
            {
                MySqlCommand reactivateRole = new MySqlCommand("UPDATE `roles` SET `status` = 1 WHERE `role` = @roleName AND `department_id` = @deptID");
                reactivateRole.Parameters.AddWithValue("@roleName", tbx_roleName.Text.Trim());
                reactivateRole.Parameters.AddWithValue("@deptID", user.deptID);
                connection.executeQuery_secure(reactivateRole, addRoleCon);
            }
            else
            {
                MySqlCommand addRole = new MySqlCommand("INSERT INTO `roles` (`role`, `department_id`) VALUES (@roleName, @deptID)");
                addRole.Parameters.AddWithValue("@rolename", tbx_roleName.Text.Trim());
                addRole.Parameters.AddWithValue("@deptID", user.deptID);
                connection.executeQuery_secure(addRole, addRoleCon);
            }
            updateRoles();
            addRoleCon.Close();
        }
    }
}

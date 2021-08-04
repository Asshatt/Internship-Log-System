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
    public partial class editUser : MetroFramework.Forms.MetroForm
    {
        public editUser()
        {
            InitializeComponent();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteUser_Load(object sender, EventArgs e)
        {
            updateList();
        }

        private void updateList()
        {
            MySqlConnection updateListCon = new MySqlConnection(connection.DatabaseConnection);
            updateListCon.OpenWithWarning();

            this.Show();

            //flp_users.Controls.Clear();
            flp_deptHeads.Controls.Clear();
            flp_admins.Controls.Clear();

            //add radio buttons for users
            DataTable departments = connection.parseDataTableFromDB_secure( new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `departments` WHERE `status` = 1 ORDER BY `id`"), updateListCon);


            tcl_users.TabPages.Clear();
            //add pages for every department to the tab control layout
            for(int i = 0; i < departments.Rows.Count; i++)
            {
                TabPage departmentTab = new TabPage(departments.Rows[i]["deptName"] + "");
                departmentTab.BackColor = Color.Silver;
                tcl_users.TabPages.Add(departmentTab);

                //add a vertical flow layout panel to every page
                FlowLayoutPanel userContainer = new FlowLayoutPanel();
                userContainer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                userContainer.FlowDirection = FlowDirection.TopDown;
                userContainer.Size = departmentTab.Size;
                userContainer.Location = new Point(0, 0);
                departmentTab.Controls.Add(userContainer);

                //get every user in the current department
                //DataTable usersInDepartment = connection.parseDataTableFromDB("SELECT * FROM `users` WHERE `status` = 1 AND `department_id` = " + departments.Rows[i]["id"] + " ORDER BY `username`");
                MySql.Data.MySqlClient.MySqlCommand getUsersInDepartment = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `users` WHERE `status` = 1 AND `department_id` = @deptID ORDER BY `username`");
                getUsersInDepartment.Parameters.AddWithValue("@deptID", departments.Rows[i]["id"]);

                DataTable usersInDepartment = connection.parseDataTableFromDB_secure(getUsersInDepartment, updateListCon);
                
                for(int j = 0; j < usersInDepartment.Rows.Count; j++)
                {
                    userRadioButton user = new userRadioButton();
                    user.Text = Convert.ToString(usersInDepartment.Rows[j]["username"]);
                    user.userId = Convert.ToInt32(usersInDepartment.Rows[j]["id"]);
                    user.userPermLevel = 0;
                    user.AutoSize = true;
                    user.AutoEllipsis = false;
                    userContainer.Controls.Add(user);
                }
            }

            //add radio buttons for department heads
            DataTable deptHeads = connection.parseDataTableFromDB_secure(new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `department_heads` WHERE `status` = 1 AND `id` != 0"), updateListCon);

            for (int i = 0; i < deptHeads.Rows.Count; i++)
            {
                userRadioButton user = new userRadioButton();
                user.Text = deptHeads.Rows[i]["username"] + " [Head of " + connection.parseDataTableFromDB("SELECT `deptName` FROM `departments` WHERE `id` = " + deptHeads.Rows[i]["department_id"], updateListCon).Rows[0]["deptName"] + "]";
                user.userId = Convert.ToInt32(deptHeads.Rows[i]["id"]);
                user.userPermLevel = 1;
                user.AutoSize = true;
                user.AutoEllipsis = false;
                flp_deptHeads.Controls.Add(user);
            }

            //add radio buttons for admins
            DataTable admins = connection.parseDataTableFromDB_secure(new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM `admins` WHERE `status` = 1"), updateListCon);

            for (int i = 0; i < admins.Rows.Count; i++)
            {
                userRadioButton user = new userRadioButton();
                user.Text = Convert.ToString(admins.Rows[i]["username"]);
                user.userId = Convert.ToInt32(admins.Rows[i]["id"]);
                user.userPermLevel = 2;
                user.AutoSize = true;
                user.AutoEllipsis = false;
                flp_admins.Controls.Add(user);
            }
            updateListCon.Close();
        }

        private void btn_updateUser_Click(object sender, EventArgs e)
        {
            //get currently selected radio button
            userRadioButton selectedRadioButton = getCheckedRadioInActiveTab();
            
            //if radio button is null, then tell the user to make it not null lol
            if (selectedRadioButton == null)
            {
                MessageBox.Show("Select a user to update.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            updateUser updateDialog = new updateUser(selectedRadioButton.userId, selectedRadioButton.userPermLevel, true);
            updateDialog.FormClosed += (s, args) => updateList();
            updateDialog.Show();
            this.Hide();
        }

        private void btn_removeUser_Click(object sender, EventArgs e)
        {
            userRadioButton selectedRadioButton = getCheckedRadioInActiveTab();

            if(selectedRadioButton == null)
            {
                MessageBox.Show("Select a user to delete.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(selectedRadioButton.userId == user.id && selectedRadioButton.userPermLevel == user.permissionLevel) 
            {
                MessageBox.Show("You cannot delete yourself.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if(selectedRadioButton.userId == 0 && selectedRadioButton.userPermLevel == 1)
            {
                MessageBox.Show("If I programmed this right, you shouldn't ever see this. If this form has triggered though, then fuck. Still though, don't delete that, it's very important.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show("Are you sure you want to deactivate this user?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                MySqlConnection deactivateUserCon = new MySqlConnection(connection.DatabaseConnection);
                deactivateUserCon.OpenWithWarning();

                MySql.Data.MySqlClient.MySqlCommand deleteUser = new MySql.Data.MySqlClient.MySqlCommand();
                //remove the selected user from the database
                switch (selectedRadioButton.userPermLevel) 
                {
                    //User
                    case 0:
                        //connection.executeQuery("UPDATE `users` SET `status` = 0 WHERE `users`.`id` = " + selectedRadioButton.userId);
                        deleteUser = new MySql.Data.MySqlClient.MySqlCommand("UPDATE `users` SET `status` = 0 WHERE `id` = @id");
                        break;

                    //Dept Head
                    case 1:
                        //connection.executeQuery("UPDATE `department_heads` SET `status` = 0 WHERE `department_heads`.`id` = " + selectedRadioButton.userId);
                        deleteUser = new MySqlCommand("UPDATE `department_heads` SET `status` = 0 WHERE `id` = @id");

                        //set the deleted head's department as vacant
                        //connection.executeQuery("UPDATE `departments` SET `head_id` = 0 WHERE `head_id` = " + selectedRadioButton.userId);
                        MySqlCommand updateDept = new MySqlCommand("UPDATE `departments` SET `head_id` = 0 WHERE `head_id` = @headID");
                        updateDept.Parameters.AddWithValue("@headID", selectedRadioButton.userId);
                        connection.executeQuery_secure(updateDept, deactivateUserCon);
                        break;

                    //Admin
                    case 2:
                        //connection.executeQuery("UPDATE `admins` SET `status` = 0 WHERE `admins`.`id` = " + selectedRadioButton.userId);
                        deleteUser = new MySql.Data.MySqlClient.MySqlCommand("UPDATE `admins` SET `status` = 0 WHERE `id` = @id");
                        break;
                }
                deleteUser.Parameters.AddWithValue("@id", selectedRadioButton.userId);
                connection.executeQuery_secure(deleteUser, deactivateUserCon);
                deactivateUserCon.Close();
            }
            updateList();
        }

        userRadioButton getCheckedRadio(Control container) 
        {
            foreach(var controls in container.Controls) 
            {
                userRadioButton radio = controls as userRadioButton;

                if (radio != null && radio.Checked) 
                {
                    return radio;
                }
            }
            return null;
        }

        //used to check for selected radio button in the currently active tab. Called by the remove and update buttons
        userRadioButton getCheckedRadioInActiveTab()
        {
            userRadioButton selectedRadioButton = new userRadioButton();
            //check which flowlayoutpanel to check depending on which tab is currently open
            switch (tcl_userCategory.SelectedIndex)
            {
                //Users
                case 0:
                    var flp = tcl_users.SelectedTab.Controls.Cast<Control>().FirstOrDefault(x => x is FlowLayoutPanel);
                    selectedRadioButton = getCheckedRadio((FlowLayoutPanel)flp);
                    break;

                //Dept Heads
                case 1:
                    selectedRadioButton = getCheckedRadio(flp_deptHeads);
                    break;

                //Admins
                case 2:
                    selectedRadioButton = getCheckedRadio(flp_admins);
                    break;
            }
            return selectedRadioButton;
        }

        private void btn_addTask_Click(object sender, EventArgs e)
        {
            this.Hide();
            Admin_Client.userRegistration registrationForm = new Admin_Client.userRegistration();
            registrationForm.FormClosed += (s, args) => updateList();
            registrationForm.Show();
        }
    }

    public class userRadioButton : RadioButton 
    {
        public int userPermLevel { get; set; }
        public int userId { get; set; }
    }
}

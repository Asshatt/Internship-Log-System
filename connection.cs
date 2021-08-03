using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using MySql.Data.MySqlClient;
using MySql.Data;

namespace OJT_Project
{
    public static class connection
    {
        //public static string DatabaseConnection = "datasource=127.0.0.1;port=3306;username=root;password=;database=ojt_todolist_project_deleteTest";
        public static string DatabaseConnection = "datasource=18.141.124.114;port=3306;username=logsys_user;password=;database=log_system";
        ///OLD SQL FUNCTIONS, VERY NOT SECURE
        public static DataTable parseDataTableFromDB(string query)
        {
            //establish connection
            MySqlConnection con = new MySqlConnection(connection.DatabaseConnection);
            DataTable table = new DataTable();
            con.Open();
            try
            {
            }
            catch 
            {
                databaseConnectionErrorMessage();
                return table;
            }
            MySqlCommand command = new MySqlCommand(query, con);
            MySqlDataAdapter adapter = new MySqlDataAdapter(command);
            adapter.Fill(table);
            con.Close();
            return table;
        }

        public static void executeQuery(string query)
        {
            MySqlConnection con = new MySqlConnection(connection.DatabaseConnection);
            try
            {
                con.Open();
            }
            catch
            {
                databaseConnectionErrorMessage();
            }

            MySqlCommand cmd = new MySqlCommand(query, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public static DataTable parseDataTableFromDB_secure(MySqlCommand cmd)
        {
            //establish connection
            MySqlConnection con = new MySqlConnection(connection.DatabaseConnection);
            DataTable table = new DataTable();
            try
            {
                con.Open();
            }
            catch
            {
                databaseConnectionErrorMessage();
                return table;
            }
            cmd.Connection = con;
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            adapter.Fill(table);
            con.Close();
            return table;
        }

        //using SQL parameters as opposed to query strings
        public static void executeQuery_secure(MySqlCommand cmd)
        {
            MySqlConnection con = new MySqlConnection(connection.DatabaseConnection);
            try
            {
                con.Open();
            }
            catch
            {
                databaseConnectionErrorMessage();
            }

            cmd.Connection = con;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        //messagebox that is displayed whenever the database fails to connect
        public static void databaseConnectionErrorMessage() 
        {
            DialogResult result = MessageBox.Show("Cannot connect to database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}
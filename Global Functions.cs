using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;

namespace OJT_Project
{
    public static class globalFunctions
    {
        public static string sqlDateFormat = "yyyy-MM-dd H:mm:ss";

        public static void addDbInfoToComboBox(ComboBox cbx, DataTable tbl, string parameter) 
        {
            cbx.Items.Clear();
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                cbx.Items.Add(tbl.Rows[i][parameter]);
            }
        }
        
        public static void updateDataGridViewStyle(DataGridView dgv)
        {
            dgv.ReadOnly = true;
            dgv.BackgroundColor = Color.Silver;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgv.Columns[i].DefaultCellStyle.Font = new Font("Segoe UI", 8);
                dgv.Columns[i].DefaultCellStyle.BackColor = Color.Silver;
            }
        }

        public static indexedRadioButton getCheckedRadio(Control container)
        {
            foreach (var controls in container.Controls)
            {
                indexedRadioButton radio = controls as indexedRadioButton;

                if (radio != null && radio.Checked)
                {
                    return radio;
                }
            }
            return null;
        }

        public static float roundToTwoDecimalPlaces(this float num)
        {
            num = (float)Math.Round(num * 100f) / 100f;
            return num;
        }

        public static bool isValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static void sendEmail(string to, string subject, string body)
        {
            NetworkCredential login;
            SmtpClient client;
            MailMessage msg;

            //TODO: make this not my porn alt
            login = new NetworkCredential("samplejames69@gmail.com", "tinola123");
            client = new SmtpClient("smtp.gmail.com");
            client.Port = 587;
            client.EnableSsl = true;
            client.Credentials = login;
            msg = new MailMessage { From = new MailAddress("samplejames69@gmail.com", "Password Reset Manager", Encoding.UTF8) };
            msg.To.Add(new MailAddress(to));
            msg.Subject = subject;
            msg.Body = body;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.Normal;
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            client.SendAsync(msg, "");
        }

        private static Random random = new Random();
        public static string randomPassword(int length)
        {
            const string chars = "1234567890qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        //get the start of the week
        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }
    }

    public static class CSVFunctions
    {
        //CSV conversion therapy
        public static void toCSV(this DataTable data, string strFilePath)
        {
            //stream writer writes strings to the file or something like that
            //I am very inexperienced with IO
            StreamWriter sw = new StreamWriter(strFilePath, false);
            
            //draws headers for all the stuff
            for(int i = 0; i < data.Columns.Count; i++)
            {
                //writes column data
                sw.Write(data.Columns[i]);
                
                //adds a comma to the end of it
                if(i < data.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            //press enter basically
            sw.Write(sw.NewLine);

            //for every data row, iterate through it's columns and write the data to the file
            foreach(DataRow dr in data.Rows)
            {
                for(int i = 0; i < data.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();

                        //I have no idea what this does
                        if (value.Contains(','))
                        {
                            value = string.Format("\"{0}\"", value);
                        }
                        sw.Write(value);
                    }

                    if(i < data.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }

                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }

    public class indexedButton : Button
    {
        public int id { get; set; }
    }

    public class indexedTextbox : TextBox
    {
        public int id { get; set; }
        public string initialText { get; set; }
    }

    public class indexedRadioButton : RadioButton
    {
        public int id { get; set; }
        public string stringID { get; set; }
    }
}

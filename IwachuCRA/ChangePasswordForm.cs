using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IwachuCRA
{
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        private void savenewPaswordBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string oldpass = oldPassBox.Text;
            string newpass = newPassBox.Text;
            if(oldpass.Length>0 && newpass.Length > 0)
            {
                string hashedPassword_old = Md5Hash(oldpass);
                string hashedPassword_new = Md5Hash(newpass);
                string connectionString = GlobalVariablesClass.connString;
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                try
                {
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "SELECT * FROM users WHERE username = '" + GlobalVariablesClass.username + "' AND password ='" + hashedPassword_old + "' AND status='active' LIMIT 1";
                    MySqlDataReader myReader = cmd.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        connection.Close();
                        connection.Open();
                        MySqlCommand cmd2 = connection.CreateCommand();
                        cmd2.CommandText = "UPDATE users SET password='"+hashedPassword_new+"' WHERE username='"+GlobalVariablesClass.username+"' AND password='"+hashedPassword_old+"'";
                        int affectedRows = cmd2.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Changed successfully, next time you login use new password!");
                        }
                        else
                        {
                            MessageBox.Show("Failed to change password, try again!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Old password is not correct!");
                    }
                    connection.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Enter old and new password!");
            }
            Cursor.Current = Cursors.Default;
        }

        public static string Md5Hash(string pass)
        {
            MD5 md5 = MD5CryptoServiceProvider.Create();
            byte[] dataMd5 = md5.ComputeHash(Encoding.Default.GetBytes(pass));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < dataMd5.Length; i++)
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            return sb.ToString();
        }
    }
}

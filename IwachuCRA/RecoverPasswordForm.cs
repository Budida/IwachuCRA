using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Security.Cryptography;

namespace IwachuCRA
{
    public partial class RecoverPasswordForm : Form
    {
       
        public RecoverPasswordForm()
        {
            InitializeComponent();
        }

        private void recoverPassBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //check system settings
            GlobalVariablesClass.system_ip  = Properties.Settings.Default.system_ip;
            GlobalVariablesClass.system_db  = Properties.Settings.Default.system_db;
            GlobalVariablesClass.db_pass    = Properties.Settings.Default.db_pass;
            GlobalVariablesClass.db_user    = Properties.Settings.Default.db_user;
            GlobalVariablesClass.connString = "Server=" + GlobalVariablesClass.system_ip + ";Database=" + GlobalVariablesClass.system_db + ";Uid=" + GlobalVariablesClass.db_user + ";Pwd=" + GlobalVariablesClass.db_pass;
            if (GlobalVariablesClass.system_ip == "" || GlobalVariablesClass.system_db == "" || GlobalVariablesClass.db_pass == "" || GlobalVariablesClass.db_user == "")
            {
                MessageBox.Show("Mpangilio wa mfumo hauko sawa, huwezi kuingia kwa sasa!");
            }
            else
            {
                string connectionString = GlobalVariablesClass.connString;
                bool checkUser = false;
                if (recoverPasswordBox.Text.Equals(""))
                {
                    MessageBox.Show("Weka Barua pepe yako");
                }
                else
                {
                    //checking if user with email provided is availabe
                    MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    connection.Open();
                    try
                    {
                        MySql.Data.MySqlClient.MySqlCommand cmd = connection.CreateCommand();
                        cmd.CommandText = "SELECT * FROM users WHERE email = '" + recoverPasswordBox.Text + "' AND status='active' LIMIT 1";
                        MySql.Data.MySqlClient.MySqlDataReader myReader = cmd.ExecuteReader();
                        if (myReader.HasRows)
                        {
                            checkUser = true;
                        }
                        else
                        {
                            checkUser = false;
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }

                    if (!checkUser)
                    {
                        MessageBox.Show("Umekosea barua pepe au hakuna mtumiaji mwenye barua pepe uliyoweka");
                    }
                    else
                    {
                        connection.Open();
                        //updating user password
                        try
                        {
                            MySql.Data.MySqlClient.MySqlCommand cmd2 = connection.CreateCommand();
                            cmd2.CommandText = "UPDATE users SET password = '" + Md5Hash("123456tz") + "' WHERE email = '" + recoverPasswordBox.Text + "'";
                            cmd2.ExecuteNonQuery();
                            //processing send email if user is available
                            try
                            {
                                string fromAddress = "bedabudida@gmail.com";
                                string mailPassword = "010686@janda";       // Mail id password from where mail will be sent.
                                string messageBody = "Nywila yako mpya ni: 123456tz";
                                // Create smtp connection.
                                SmtpClient client = new SmtpClient();
                                client.Port = 587; //outgoing port for the mail.
                                client.Host = "smtp.gmail.com";
                                client.EnableSsl = true;
                                client.Timeout = 10000;
                                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                                client.UseDefaultCredentials = false;
                                client.Credentials = new System.Net.NetworkCredential(fromAddress, mailPassword);
                                // Fill the mail form.
                                var send_mail = new MailMessage();
                                send_mail.IsBodyHtml = true;
                                //address from where mail will be sent.
                                send_mail.From = new MailAddress("info@iwachu.co.tz");
                                //address to which mail will be sent.           
                                send_mail.To.Add(new MailAddress(recoverPasswordBox.Text));
                                //subject of the mail.
                                send_mail.Subject = "Iwachu CRA Nywila Mpya";
                                send_mail.Body = messageBody;
                                client.Send(send_mail);
                                MessageBox.Show("Ujumbe wenye nywila mpya umetumwa!");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                        finally
                        {
                            if (connection.State == ConnectionState.Open)
                            {
                                connection.Close();
                            }
                        }
                    }
                }
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

        private void futaEmailBtn_Click(object sender, EventArgs e)
        {
            recoverPasswordBox.Text = "";
        }
    }
}

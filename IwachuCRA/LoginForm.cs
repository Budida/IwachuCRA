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
    public partial class frmLogin : Form
    {
       
        public frmLogin()
        {
            InitializeComponent();
        }

        private void clearLoginDetailsBtn_Click(object sender, EventArgs e)
        {
            //clear login details
            loginNameBox.Text   = "";
            passwordBox.Text    = "";
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            //process recover password
            RecoverPasswordForm frm = new RecoverPasswordForm();
            frm.ShowDialog();

        }

        private void forgotPasswordBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //check system settings
            GlobalVariablesClass.system_ip = Properties.Settings.Default.system_ip;
            GlobalVariablesClass.system_db = Properties.Settings.Default.system_db;
            GlobalVariablesClass.db_pass = Properties.Settings.Default.db_pass;
            GlobalVariablesClass.db_user = Properties.Settings.Default.db_user;
            GlobalVariablesClass.connString = "Server=" + GlobalVariablesClass.system_ip + ";Database=" + GlobalVariablesClass.system_db + ";Uid=" + GlobalVariablesClass.db_user + ";Pwd=" + GlobalVariablesClass.db_pass;
            //MessageBox.Show(GlobalVariablesClass.system_ip+"--"+ GlobalVariablesClass.system_db+"--"+ GlobalVariablesClass.db_pass+"--"+ GlobalVariablesClass.db_user+"==="+GlobalVariablesClass.connString);
            if (GlobalVariablesClass.system_ip == "" || GlobalVariablesClass.system_db == "" || GlobalVariablesClass.db_pass == "" || GlobalVariablesClass.db_user == "")
            {
                MessageBox.Show("Mpangilio wa mfumo hauko sawa, huwezi kuingia kwa sasa!");
            }
            else
            {
                //process user Login
                string loginName = loginNameBox.Text;
                string password = passwordBox.Text;
                string hashedPassword = Md5Hash(password);
                if (loginName.Equals("") || password.Equals(""))
                {
                    MessageBox.Show("Weka taarifa zote!");
                }
                else
                {
                    string connectionString = GlobalVariablesClass.connString;
                    MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
                    connection.Open();
                    try
                    {
                        MySql.Data.MySqlClient.MySqlCommand cmd = connection.CreateCommand();
                        cmd.CommandText = "SELECT * FROM users WHERE username = '" + loginName + "' AND password ='" + hashedPassword + "' AND status='active' LIMIT 1";
                        MySql.Data.MySqlClient.MySqlDataReader myReader = cmd.ExecuteReader();

                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                GlobalVariablesClass.username = myReader.GetString(myReader.GetOrdinal("username"));
                                GlobalVariablesClass.council_code = myReader.GetString(myReader.GetOrdinal("council_code"));
                                GlobalVariablesClass.region_code = myReader.GetString(myReader.GetOrdinal("region_code"));
                                GlobalVariablesClass.email = myReader.GetString(myReader.GetOrdinal("email"));
                                GlobalVariablesClass.fullname = myReader.GetString(myReader.GetOrdinal("fullname"));
                                GlobalVariablesClass.level = myReader.GetString(myReader.GetOrdinal("level"));
                                GlobalVariablesClass.userid = myReader.GetInt32(myReader.GetOrdinal("id"));
                                Properties.Settings.Default.active = "Yes";
                                Properties.Settings.Default.Save();
                                if (GlobalVariablesClass.level.Equals("DED") || GlobalVariablesClass.level.Equals("MED") || GlobalVariablesClass.level.Equals("TED"))
                                {
                                    GlobalVariablesClass.level = "DED";
                                }
                                else if (GlobalVariablesClass.level.Equals("DT") || GlobalVariablesClass.level.Equals("MT") || GlobalVariablesClass.level.Equals("TT"))
                                {
                                    GlobalVariablesClass.level = "DT";
                                }
                                loginNameBox.Text = "";
                                passwordBox.Text = "";
                                MainForm frm = new MainForm();
                                frm.refFrmLogin = this;
                                this.Hide();
                                frm.Show();
                            }
                            connection.Close();
                        }
                        //select council name
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                        connection.Open();
                        MySql.Data.MySqlClient.MySqlCommand cmd2 = connection.CreateCommand();
                        cmd2.CommandText = "SELECT * FROM basic_info WHERE council_code = '" + GlobalVariablesClass.council_code + "' AND region_code ='" + GlobalVariablesClass.region_code + "' LIMIT 1";
                        MySql.Data.MySqlClient.MySqlDataReader myReader2 = cmd2.ExecuteReader();
                        if (myReader2.HasRows)
                        {
                            while (myReader2.Read())
                            {
                                GlobalVariablesClass.council_name = myReader2.GetString(myReader2.GetOrdinal("dname"));
                                GlobalVariablesClass.daddress = myReader2.GetString(myReader2.GetOrdinal("daddress"));
                                GlobalVariablesClass.dfax = myReader2.GetString(myReader2.GetOrdinal("dfax"));
                                GlobalVariablesClass.demail = myReader2.GetString(myReader2.GetOrdinal("demail"));
                                GlobalVariablesClass.dphone = myReader2.GetString(myReader2.GetOrdinal("dphone"));
                                GlobalVariablesClass.makazi_percent = myReader2.GetDouble(myReader2.GetOrdinal("makazi_percent"));
                                GlobalVariablesClass.makazi_percent = myReader2.GetDouble(myReader2.GetOrdinal("makazi_percent"));
                                GlobalVariablesClass.biashara_percent = myReader2.GetDouble(myReader2.GetOrdinal("biashara_percent"));
                                GlobalVariablesClass.bmakazi_percent = myReader2.GetDouble(myReader2.GetOrdinal("makazi_biashara_percent"));
                                GlobalVariablesClass.limbikizo_percent = myReader2.GetDouble(myReader2.GetOrdinal("limbikizo_percent"));
                                GlobalVariablesClass.limbikizo_mwezi = myReader2.GetDouble(myReader2.GetOrdinal("limbikizo_mwezi"));
                                GlobalVariablesClass.riba_month = myReader2.GetDouble(myReader2.GetOrdinal("riba_month"));
                                GlobalVariablesClass.riba_tumika = myReader2.GetString(myReader2.GetOrdinal("riba_tumika"));
                                GlobalVariablesClass.bank_account = myReader2.GetString(myReader2.GetOrdinal("account_number"));
                                GlobalVariablesClass.dedname = myReader2.GetString(myReader2.GetOrdinal("dedname"));
                            }

                        }
                        else
                        {
                            if (connection.State == ConnectionState.Open)
                            {
                                connection.Close();
                            }
                            MessageBox.Show("Umekosea Jina au Nywila");
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
            Cursor.Current = Cursors.Default;
        }

        public static string Md5Hash(string pass)
        {
            MD5 md5             = MD5CryptoServiceProvider.Create();
            byte[] dataMd5      = md5.ComputeHash(Encoding.Default.GetBytes(pass));
            StringBuilder sb    = new StringBuilder();
            for (int i = 0; i < dataMd5.Length; i++)
                sb.AppendFormat("{0:x2}", dataMd5[i]);
            return sb.ToString();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string status = Properties.Settings.Default.active;
            if (status == "Yes")
            {
                //MessageBox.Show("All settings are setup now, continue!");
            }
            else
            {
                SettingsForm frm = new SettingsForm();
                frm.ShowDialog();
            }
           
        }
    }
}

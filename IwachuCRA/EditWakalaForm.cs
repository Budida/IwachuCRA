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
    public partial class EditWakalaForm : Form
    {
        ComboBox[] maeneo;
        public static DateTime referenceDate = new DateTime(1970, 1, 1);
        public EditWakalaForm()
        {
            InitializeComponent();
        }
        private void EditWakalaForm_Load(object sender, EventArgs e)
        {
            fullNameBox.Text            = OrodhaYaMawakalaForm.wakalafullname;
            phoneBox.Text               = OrodhaYaMawakalaForm.wakala_phone;
            emailBox.Text               = OrodhaYaMawakalaForm.wakalaemail;
            fromDateTimePicker.Value    = OrodhaYaMawakalaForm.from_date;
            toDateTimePicker.Value      = OrodhaYaMawakalaForm.to_date;
        }
        private void fromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
          //capture datepicker value changed event
        }

        private void idadiMaeneoBox_TextChanged(object sender, EventArgs e)
        {
            int idadi_maeneo;
            if (idadiMaeneoBox.Text.Equals("") || !int.TryParse(idadiMaeneoBox.Text, out idadi_maeneo))
            {
                if (int.TryParse(idadiMaeneoBox.Text, out idadi_maeneo) || (maeneo != null))
                {
                    //MessageBox.Show("Weka Idadi ya Maeneo!");
                    if (maeneo.Length > 0)
                    {
                        for (int i = 0; i < maeneo.Length; i++)
                        {
                            //remove maeneo drop downs
                            maeneoPanel.Controls.Remove(maeneo[i]);
                            maeneo[i].Dispose();
               
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Weka idadi kwa namba siyo alama au herufi!");
                }
            }
            else
            {
                //futa kwanza vipimo vilivyokuwepo kabla ya kuweka textboxes zingine
                if ((maeneo != null))
                {
                    if (maeneo.Length > 0)
                    {
                        for (int i = 0; i < maeneo.Length; i++)
                        {
                            //remove vipimo and tozo boxes
                            maeneoPanel.Controls.Remove(maeneo[i]);
                            maeneo[i].Dispose();
                        }
                    }
                }

                int maeneoIdadi = int.Parse(idadiMaeneoBox.Text);
                maeneo = new ComboBox[maeneoIdadi];
                for (int i = 0; i < maeneoIdadi; i++)
                {
                    maeneo[i]               = new ComboBox();
                    maeneo[i].Width         = 247;
                    maeneo[i].DropDownStyle = ComboBoxStyle.DropDownList;
                    FillDropDownListMaeneo("SELECT * FROM income_sources WHERE tax_payer='No' AND council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", maeneo[i]);
                    if (i > 0)
                    {
                        maeneo[i].Top = maeneo[i - 1].Bottom;
                    }
                    maeneoPanel.Controls.Add(maeneo[i]);
                }
            }
        }

        public static void FillDropDownListMaeneo(string Query, System.Windows.Forms.ComboBox DropDownName)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (var cn = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString))
            {
                cn.Open();
                DataTable dt = new DataTable();
                try
                {
                    MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(Query, cn);
                    MySql.Data.MySqlClient.MySqlDataReader myReader = cmd.ExecuteReader();
                    dt.Load(myReader);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return;
                }
                DropDownName.DataSource     = dt;
                DropDownName.ValueMember    = "id";
                DropDownName.DisplayMember  = "source";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void hifadhiWakalaBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int idadiMaeneo;
            if (zuiaWakalaAkauntiSelect.SelectedItem.ToString().Equals("") || fullNameBox.Text.Equals("") || phoneBox.Text.Equals("") || emailBox.Text.Equals("") || fromDateTimePicker.Value.Equals("") || toDateTimePicker.Value.Equals("") || idadiMaeneoBox.Text.Equals("") || !int.TryParse(idadiMaeneoBox.Text, out idadiMaeneo))
            {
                MessageBox.Show("Weka taarifa zote!");
            }
            else
            {
                //sajili wakala into database
                string status               = "";
                string fullname            = fullNameBox.Text;
                string simu                = phoneBox.Text;
                string email               = emailBox.Text;
                DateTime start_date        = fromDateTimePicker.Value;
                DateTime end_date          = toDateTimePicker.Value;
                string username            = OrodhaYaMawakalaForm.wakala_name;
                //int source_id              = int.Parse(maeneo[0].SelectedValue.ToString());
                //string password            = passwordBox.Text;
                int no_sources             = int.Parse(idadiMaeneoBox.Text);
                string user                = GlobalVariablesClass.fullname;
                string council_code        = GlobalVariablesClass.council_code;
                string region_code         = GlobalVariablesClass.region_code;
                //getting start_date and end_date in seconds
                Double start_date_seconds   = toSeconds(start_date, referenceDate);
                Double end_date_seconds     = toSeconds(end_date, referenceDate);
                string zuia_akaunti         = zuiaWakalaAkauntiSelect.SelectedItem.ToString();
                if (zuia_akaunti == "Ruhusu")
                {
                    status = "active";
                }
                else
                {
                    status = "banned";
                }

              //process save these data into db
                MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
                MySql.Data.MySqlClient.MySqlCommand cmd;
                MySql.Data.MySqlClient.MySqlCommand cmd2;
                MySql.Data.MySqlClient.MySqlCommand cmd3;
                MySql.Data.MySqlClient.MySqlCommand cmd4;
                connection.Open();
                try 
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "UPDATE wakala SET fullname ='" + fullname + "', simu='" + simu + "', email=" + email + ", start_date='" + start_date_seconds + "', end_date='" + end_date_seconds + "', user='"+user+"', status='"+status+ "' WHERE id='"+OrodhaYaMawakalaForm.wakala_id+"'";
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@simu", simu);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@start_date", start_date_seconds);
                    cmd.Parameters.AddWithValue("@end_date", end_date_seconds);
                    cmd.Parameters.AddWithValue("@user", user);
                    cmd.ExecuteNonQuery();

                    //insert wakala_sources
                    for (int i = 0; i < maeneo.Length; i++)
                    {
                        string slabel = "";
                        //getting namba ya eneo
                        cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM income_sources WHERE id='" + maeneo[i].SelectedValue.ToString() + "' AND region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "'", connection);
                        MySql.Data.MySqlClient.MySqlDataReader myReader = cmd3.ExecuteReader();
                        if (myReader.HasRows)
                        {
                            while (myReader.Read())
                            {
                                slabel = myReader.GetString(myReader.GetOrdinal("slabel"));
                            }
                            connection.Close(); //closing reader
                            connection.Open();
                            //checking if eneo ashapewa wakala huyo
                            cmd4 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM wakala_sources WHERE wakalaname='" + username + "' AND slabel='" + slabel + "' AND from_date='" + start_date_seconds + "' AND to_date='" + end_date_seconds + "' AND region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "'", connection);
                            MySql.Data.MySqlClient.MySqlDataReader myReader2 = cmd4.ExecuteReader();
                            if (myReader2.HasRows)
                            {
                                //do not insert it will double the same record
                            }
                            else
                            {
                                connection.Close(); //closing reader
                                connection.Open();
                                //inserting values
                                cmd2 = connection.CreateCommand();
                                cmd2.CommandText = "INSERT INTO wakala_sources(wakalaname, slabel, from_date, to_date, council_code, region_code) VALUES(" +
                                     "'" + username + "'," +
                                     "'" + slabel + "'," +
                                     "'" + start_date_seconds + "'," +
                                     "'" + end_date_seconds + "'," +
                                     "'" + council_code + "'," +
                                     "'" + region_code + "'" +
                                ")";
                                cmd2.Parameters.AddWithValue("@wakalaname", username);
                                cmd2.Parameters.AddWithValue("@slabel", slabel);
                                cmd2.Parameters.AddWithValue("@from_date", start_date_seconds);
                                cmd2.Parameters.AddWithValue("@to_date", end_date_seconds);
                                cmd2.Parameters.AddWithValue("@council_code", council_code);
                                cmd2.Parameters.AddWithValue("@region_code", region_code);
                                cmd2.ExecuteNonQuery();
                            }
                        }
                    }
                    MessageBox.Show("Umefanikiwa kuhifadhi!"+ zuia_akaunti);
                    fullNameBox.Text    = "";
                    idadiMaeneoBox.Text = "";
                }
                catch(Exception ex)
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
            Cursor.Current = Cursors.Default;
        }

        public Double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IwachuCRA
{
    public partial class SajiliMlipaKodiForm : Form
    {
        public static DateTime referenceDate = new DateTime(1970, 1, 1);
        public SajiliMlipaKodiForm()
        {
            InitializeComponent();
            FillDropDownListKata("SELECT * FROM wards WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", kataDropDown);
            FillDropDownListMtaaKijiji("SELECT * FROM streets WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", mtaaDropDown);
            FillDropDownListVyanzo("SELECT * FROM actual_sources WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", ainaYaKodiDropDown);
            matumiziDropDown.SelectedItem = "Biashara";
            flatRateDropDown.SelectedItem = "Hapana";
            if (OrodhaWalipaKodiForm.record_id > 0)
            {
                getMlipaKodi(OrodhaWalipaKodiForm.record_id);
            }
        }

        private void hifadhiMlipaKodiBtn_Click(object sender, EventArgs e)
        {
            double kodi_amount, thamani_amount;
            //process save mlipa kodi!
            if(jinaKamiliBox.Text.Equals("") || simuBox.Text.Equals("") || baruaPepeBox.Text.Equals("") || anuaniPostaBox.Text.Equals("") || kataDropDown.SelectedValue.ToString().Equals("") ||
                mtaaDropDown.SelectedValue.ToString().Equals("") || nambaKiwanjaBox.Text.Equals("") || kitaluBox.Text.Equals("") || !Double.TryParse(thamaniBox.Text, out thamani_amount) || !Double.TryParse(kiasiKodiBox.Text, out kodi_amount) ||
                 ainaYaKodiDropDown.SelectedValue.ToString().Equals("")
              )
            {
                MessageBox.Show("Weka taarifa zote kwanza!");
            }
            else 
            {
               //save details to db
                DateTime reg_date_given = usajiliDateTimePicker.Value;
                double reg_date         = toSeconds(reg_date_given, referenceDate);
                string source           = jinaKamiliBox.Text;
                string ward_id          = kataDropDown.SelectedValue.ToString();
                string flat_rate        = flatRateDropDown.SelectedItem.ToString();
                string slabel           = ""; //calculate value of new mlipa kodi namba
                int last_number         = 0;
                int new_number          = 0;
                string tax_payer        = "Yes";
                string phone_number     = simuBox.Text;
                string email_address    = baruaPepeBox.Text;
                string address          = anuaniPostaBox.Text;
                string street           = mtaaDropDown.SelectedValue.ToString();
                string plot_number      = nambaKiwanjaBox.Text;
                string msrc_id          = ainaYaKodiDropDown.SelectedValue.ToString();
                string block_number     = kitaluBox.Text;
                string ward             = kataDropDown.SelectedValue.ToString();
                string ward_name        = getWardName(int.Parse(ward));
                double rat_value        = double.Parse(thamaniBox.Text);
                double tax_amount       = double.Parse(kiasiKodiBox.Text);
                string matumizi         = matumiziDropDown.SelectedItem.ToString();
                string council_code     = GlobalVariablesClass.council_code;
                string region_code      = GlobalVariablesClass.region_code;
                double makazi_percent   = 0;
                double biashara_percent = 0;
                double bmakazi_percent  = 0;
                double kiwanda_percent  = 0;
                double taasisi_percent  = 0;
                MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
                MySql.Data.MySqlClient.MySqlCommand cmd, cmd2, cmd3, cmd4, cmd5;
                connection.Open();
                try
                {
                    //calculate new mlipa kodi namba
                    cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM taxpayers_numbers WHERE region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "' LIMIT 1", connection);
                    MySql.Data.MySqlClient.MySqlDataReader myReader = cmd.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        while (myReader.Read())
                        {
                            last_number = myReader.GetInt32(myReader.GetOrdinal("last_number"));
                            new_number  = last_number + 1;
                            slabel      = new_number.ToString();
                        }
                        connection.Close(); //close connection of checking last number of tax payer
                       
                        //checking if plot number and block number are already registered
                        connection.Open();
                        cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM income_sources WHERE plot_number = '"+plot_number+"' AND block_number='"+block_number+"' AND region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "' LIMIT 1", connection);
                        MySql.Data.MySqlClient.MySqlDataReader myReader2 = cmd2.ExecuteReader();
                        if (myReader2.HasRows && OrodhaWalipaKodiForm.record_id == 0 )
                        {
                            MessageBox.Show("Mwenye taarifa sawa na hizi za Kiwanja na Kitalu ameshajiliwa!");
                            connection.Close();
                        }
                        else
                        {
                            connection.Close();
                            //CACULATE TAX AMOUNT FIRST
                            if (tax_amount > 0)
                            {
                                //use the entered amount as tax_amount;
                            }
                            else
                            {
                                connection.Open();
                                cmd3 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM basic_info WHERE region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "' LIMIT 1", connection);
                                MySql.Data.MySqlClient.MySqlDataReader myReader3 = cmd3.ExecuteReader();
                                if (myReader3.HasRows)
                                {
                                    while (myReader3.Read())
                                    {
                                        makazi_percent = myReader3.GetDouble(myReader3.GetOrdinal("makazi_percent"));
                                        biashara_percent = myReader3.GetDouble(myReader3.GetOrdinal("biashara_percent"));
                                        bmakazi_percent = myReader3.GetDouble(myReader3.GetOrdinal("makazi_biashara_percent"));
                                        kiwanda_percent = myReader3.GetDouble(myReader3.GetOrdinal("kiwanda_percent"));
                                        taasisi_percent = myReader3.GetDouble(myReader3.GetOrdinal("taasisi_percent"));
                                    }
                                    connection.Close();
                                    //do mathematics to calculate tax_amount
                                    if (matumizi.Equals("Makazi") && flat_rate.Equals("Hapana"))
                                    {
                                        tax_amount = (makazi_percent * rat_value) / 100;
                                    }
                                    else if (matumizi.Equals("Biashara") && flat_rate.Equals("Hapana"))
                                    {
                                        tax_amount = (biashara_percent * rat_value) / 100;
                                    }
                                    else if (matumizi.Equals("Makazi/Biashara") && flat_rate.Equals("Hapana"))
                                    {
                                        tax_amount = (bmakazi_percent * rat_value) / 100;
                                    }
                                    else if (matumizi.Equals("Kiwanda") && flat_rate.Equals("Hapana"))
                                    {
                                        tax_amount = (kiwanda_percent * rat_value) / 100;
                                    }
                                    else if (matumizi.Equals("Taasisi") && flat_rate.Equals("Hapana"))
                                    {
                                        tax_amount = (taasisi_percent * rat_value) / 100;
                                    }
                                    else if (!ward.Equals("") && flat_rate == "Ndiyo" && matumizi.Equals("Makazi"))
                                    {
                                        tax_amount = getWardTaxAccordingToWard(int.Parse(ward), "makazi_value");
                                    }
                                    else if (!ward.Equals("") && flat_rate == "Ndiyo" && matumizi.Equals("Biashara"))
                                    {
                                        tax_amount = getWardTaxAccordingToWard(int.Parse(ward), "biashara_value");
                                    }
                                    else if (!ward.Equals("") && flat_rate == "Ndiyo" && matumizi.Equals("Makazi/Biashara"))
                                    {
                                        tax_amount = getWardTaxAccordingToWard(int.Parse(ward), "bmakazi_value");
                                    }
                                    else if (!ward.Equals("") && flat_rate == "Ndiyo" && matumizi.Equals("Taasisi"))
                                    {
                                        tax_amount = getWardTaxAccordingToWard(int.Parse(ward), "taasisi_value");
                                    }
                                    else if (!ward.Equals("") && flat_rate == "Ndiyo" && matumizi.Equals("Kiwanda"))
                                    {
                                        tax_amount = getWardTaxAccordingToWard(int.Parse(ward), "kiwanda_value");
                                    }
                                }
                                else
                                {

                                }
                            }

                            //check if is new record or editing existing record
                            if (OrodhaWalipaKodiForm.record_id == 0)
                            {
                                //save data into db
                                connection.Open();
                                cmd4 = connection.CreateCommand();
                                cmd4.CommandText = "INSERT INTO income_sources(source, ward_id, flat_rate, slabel, tax_payer, phone_number, email_address, address, street, plot_number, msrc_id, block_number, ward, rat_value, tax_amount, matumizi, reg_date, council_code, region_code) VALUES(" +
                                  "'" + source + "'," +
                                  "'" + ward_id + "'," +
                                  "'" + flat_rate + "'," +
                                  "'" + slabel + "'," +
                                  "'" + tax_payer + "'," +
                                  "'" + phone_number + "'," +
                                  "'" + email_address + "'," +
                                  "'" + address + "'," +
                                  "'" + street + "'," +
                                  "'" + plot_number + "'," +
                                  "'" + msrc_id + "'," +
                                  "'" + block_number + "'," +
                                  "'" + ward_name + "'," +
                                  "'" + rat_value + "'," +
                                  "'" + tax_amount + "'," +
                                  "'" + matumizi + "'," +
                                  "'" + reg_date + "'," +
                                  "'" + council_code + "'," +
                                  "'" + region_code + "'" +
                                ")";
                                cmd4.Parameters.AddWithValue("@source", source);
                                cmd4.Parameters.AddWithValue("@ward_id", ward_id);
                                cmd4.Parameters.AddWithValue("@flat_rate", flat_rate);
                                cmd4.Parameters.AddWithValue("@slabel", slabel);
                                cmd4.Parameters.AddWithValue("@tax_payer", tax_payer);
                                cmd4.Parameters.AddWithValue("@phone_number", phone_number);
                                cmd4.Parameters.AddWithValue("@email_address", email_address);
                                cmd4.Parameters.AddWithValue("@address", address);
                                cmd4.Parameters.AddWithValue("@street", street);
                                cmd4.Parameters.AddWithValue("@plot_number", plot_number);
                                cmd4.Parameters.AddWithValue("@msrc_id", msrc_id);
                                cmd4.Parameters.AddWithValue("@block_number", block_number);
                                cmd4.Parameters.AddWithValue("@ward", ward_name);
                                cmd4.Parameters.AddWithValue("@rat_value", rat_value);
                                cmd4.Parameters.AddWithValue("@tax_amount", tax_amount);
                                cmd4.Parameters.AddWithValue("@matumizi", matumizi);
                                cmd4.Parameters.AddWithValue("@reg_date", reg_date);
                                cmd4.Parameters.AddWithValue("@council_code", council_code);
                                cmd4.Parameters.AddWithValue("@region_code", region_code);
                                cmd4.ExecuteNonQuery();

                                cmd5 = connection.CreateCommand();
                                cmd5.CommandText = "UPDATE taxpayers_numbers SET last_number = '" + last_number + "' WHERE council_code = '" + council_code + "' AND region_code ='" + region_code + "'";
                                cmd5.ExecuteNonQuery();
                                MessageBox.Show("Umefanikiwa kusajili mlipa kodi!");
                                jinaKamiliBox.Text = "";
                                anuaniPostaBox.Text = "";
                                kiasiKodiBox.Text = "";
                            }
                            else
                            {
                                //edit record
                                connection.Open();
                                cmd4 = connection.CreateCommand();
                                cmd4.CommandText = "UPDATE income_sources SET source='" + source + "', ward_id=" + ward_id + ", flat_rate='" + flat_rate + "', phone_number='" + phone_number + "', email_address='" + email_address + "', address='" + address + "', street='" + street + "', plot_number='" + plot_number + "', msrc_id='" + msrc_id + "', block_number='" + block_number + "', ward='" + ward_name + "', rat_value='" + rat_value + "', tax_amount='" + tax_amount + "', matumizi='" + matumizi + "', reg_date='" + reg_date + "' WHERE id="+OrodhaWalipaKodiForm.record_id;
                               int affectedRows =  cmd4.ExecuteNonQuery();
                                if (affectedRows > 0)
                                {
                                    MessageBox.Show("Umefanikiwa kubadili taarifa za mlipa kodi!");
                                    OrodhaWalipaKodiForm.record_id = 0;
                                }
                                else
                                {
                                    MessageBox.Show("Imeshindikana kubadili taarifa za mlipa kodi!");
                                }

                            }
                        }
                    }
                    else 
                    {
                        MessageBox.Show("Kuna tatizo la kutengeneza namba ya mlipa kodi!");
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
        public static void FillDropDownListKata(string Query, System.Windows.Forms.ComboBox DropDownName)
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
                DropDownName.DataSource = dt;
                DropDownName.ValueMember = "wid";
                DropDownName.DisplayMember = "ward_name";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        public static void FillDropDownListMtaaKijiji(string Query, System.Windows.Forms.ComboBox DropDownName)
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
                DropDownName.DataSource = dt;
                DropDownName.ValueMember = "street_name";
                DropDownName.DisplayMember = "street_name";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        public static void FillDropDownListVyanzo(string Query, System.Windows.Forms.ComboBox DropDownName)
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
                DropDownName.DataSource = dt;
                DropDownName.ValueMember = "sid";
                DropDownName.DisplayMember = "src_name";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }
        public Double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }
        public Double getWardTaxAccordingToWard(int wid, string col_name)
        {
            Double taxamount = 0;
             MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
             MySql.Data.MySqlClient.MySqlCommand cmd;
            connection.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM wards WHERE wid="+wid+" AND region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "' LIMIT 1", connection);
            MySql.Data.MySqlClient.MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    taxamount = myReader.GetDouble(myReader.GetOrdinal(col_name));
                }
            }
            connection.Close();
            return taxamount;
        }

        public string getWardName(int wid)
        {
            string wardname ="";
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
            MySql.Data.MySqlClient.MySqlCommand cmd;
            connection.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM wards WHERE wid=" + wid + " AND region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "' LIMIT 1", connection);
            MySql.Data.MySqlClient.MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    wardname = myReader.GetString(myReader.GetOrdinal("ward_name"));
                }
            }
            connection.Close();
            return wardname;
        }
        public int getWardId(string wardname)
        {
            int wid = 0;
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
            MySql.Data.MySqlClient.MySqlCommand cmd;
            connection.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM wards WHERE ward_name='" + wardname + "' AND region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "' LIMIT 1", connection);
            MySql.Data.MySqlClient.MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    wid = myReader.GetInt32(myReader.GetOrdinal("wid"));
                }
            }
            connection.Close();
            return wid;
        }

        public void getMlipaKodi(int recordId)
        {
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
            MySql.Data.MySqlClient.MySqlCommand cmd;
            connection.Open();
            cmd = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM income_sources WHERE id=" + recordId + " AND region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "' LIMIT 1", connection);
            MySql.Data.MySqlClient.MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    //= myReader.GetDouble(myReader.GetOrdinal(""));
                    usajiliDateTimePicker.Value     = UnixTimeStampToDateTime(myReader.GetDouble(myReader.GetOrdinal("reg_date")));
                    jinaKamiliBox.Text              = myReader.GetString(myReader.GetOrdinal("source"));
                    kataDropDown.SelectedValue      = getWardId(myReader.GetString(myReader.GetOrdinal("ward")));
                    flatRateDropDown.SelectedItem   = myReader.GetString(myReader.GetOrdinal("flat_rate"));
                    simuBox.Text                    = myReader.GetString(myReader.GetOrdinal("flat_rate"));
                    baruaPepeBox.Text               = myReader.GetString(myReader.GetOrdinal("email_address"));
                    anuaniPostaBox.Text             = myReader.GetString(myReader.GetOrdinal("address"));
                    mtaaDropDown.SelectedValue      = myReader.GetString(myReader.GetOrdinal("street"));
                    nambaKiwanjaBox.Text            = myReader.GetString(myReader.GetOrdinal("plot_number"));
                    ainaYaKodiDropDown.SelectedValue = myReader.GetString(myReader.GetOrdinal("msrc_id"));
                    kitaluBox.Text                  = myReader.GetString(myReader.GetOrdinal("block_number"));
                    thamaniBox.Text                 = myReader.GetString(myReader.GetOrdinal("rat_value"));
                    kiasiKodiBox.Text               = myReader.GetString(myReader.GetOrdinal("tax_amount"));
                    matumiziDropDown.SelectedItem   = myReader.GetString(myReader.GetOrdinal("matumizi"));
                }
            }
            connection.Close();
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }

    }
}

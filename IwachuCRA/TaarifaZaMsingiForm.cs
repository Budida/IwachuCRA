using MySql.Data.MySqlClient;
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
    public partial class TaarifaZaMsingiForm : Form
    {
        static string connString = GlobalVariablesClass.connString;
        MySqlConnection connection = new MySqlConnection(connString);
        public TaarifaZaMsingiForm()
        {
            InitializeComponent();
        }

        private void TaarifaZaMsingiForm_Load(object sender, EventArgs e)
        {
            mwenziAdhabuDropDown.SelectedItem       = "1";
            mweziKuanzaRibaDropDown.SelectedItem    = "1";
            ribaTumikaDropDown.SelectedItem         = "Hapana";
            loadTaarifa();
        }

        private void loadTaarifa()
        {
            Cursor.Current = Cursors.WaitCursor;
            string sql      = "SELECT * FROM basic_info WHERE basic_info.council_code = '" + GlobalVariablesClass.council_code + "' AND basic_info.region_code = '" + GlobalVariablesClass.region_code + "' LIMIT 1";
            connection.Open();
            try
            {
                MySqlCommand cmd;
                cmd = new MySqlCommand(sql, connection);
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        jinaBox.Text = myReader.GetString(myReader.GetOrdinal("dname"));
                        mkoaBox.Text = myReader.GetString(myReader.GetOrdinal("dregion"));
                        anuaniBox.Text = myReader.GetString(myReader.GetOrdinal("daddress"));
                        simuBox.Text = myReader.GetString(myReader.GetOrdinal("dphone"));
                        akauntiBox.Text = myReader.GetString(myReader.GetOrdinal("account_number"));
                        nukshiBox.Text = myReader.GetString(myReader.GetOrdinal("dfax"));
                        mkurugenziBox.Text = myReader.GetString(myReader.GetOrdinal("dedname"));
                        emailBox.Text = myReader.GetString(myReader.GetOrdinal("demail"));
                        kodiMakaziBox.Text = myReader.GetString(myReader.GetOrdinal("makazi_percent"));
                        kodiBiasharaBox.Text = myReader.GetString(myReader.GetOrdinal("biashara_percent"));
                        kodiBMakaziBox.Text = myReader.GetString(myReader.GetOrdinal("makazi_biashara_percent"));
                        kodiKiwandaBox.Text = myReader.GetString(myReader.GetOrdinal("kiwanda_percent"));
                        kodiTaasisiBox.Text = myReader.GetString(myReader.GetOrdinal("taasisi_percent"));
                        asilimiaAdhabuBox.Text = myReader.GetString(myReader.GetOrdinal("limbikizo_percent"));
                        mwenziAdhabuDropDown.SelectedItem = myReader.GetString(myReader.GetOrdinal("limbikizo_mwezi"));
                        ribaTumikaDropDown.SelectedItem = myReader.GetString(myReader.GetOrdinal("riba_tumika"));
                        mweziKuanzaRibaDropDown.SelectedItem = myReader.GetString(myReader.GetOrdinal("riba_month"));
                        ribaBox.Text = myReader.GetString(myReader.GetOrdinal("riba_percent"));
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void hifadhiBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            double out_value;
            string dname                    = jinaBox.Text;
            string dregion                  =  mkoaBox.Text;
            string daddress                 = anuaniBox.Text;
            string dphone                   = simuBox.Text;
            string account_number           = akauntiBox.Text;
            string dfax                     = nukshiBox.Text;
            string dedname                  = mkurugenziBox.Text;
            string demail                   = emailBox.Text;
            string makazi_percent           = kodiMakaziBox.Text;
            string biashara_percent         =  kodiBiasharaBox.Text;
            string makazi_biashara_percent  = kodiBMakaziBox.Text;
            string kiwanda_percent          = kodiKiwandaBox.Text;
            string taasisi_percent          = kodiTaasisiBox.Text;
            string limbikizo_percent        = asilimiaAdhabuBox.Text;
            string limbikizo_mwezi          = mwenziAdhabuDropDown.SelectedItem.ToString();
            string riba_tumika              = ribaTumikaDropDown.SelectedItem.ToString();
            string riba_month               = mweziKuanzaRibaDropDown.SelectedItem.ToString();
            string riba_percent             = ribaBox.Text;
            if (dname.Length > 0 && dregion.Length > 0 && daddress.Length > 0 && dphone.Length > 0 && account_number.Length > 0 && dfax.Length > 0 &&
                dedname.Length > 0 && demail.Length > 0 && makazi_percent.Length > 0 && biashara_percent.Length > 0 && makazi_biashara_percent.Length > 0 &&
                kiwanda_percent.Length > 0 && taasisi_percent.Length > 0 && limbikizo_percent.Length > 0 && limbikizo_mwezi.Length > 0
                    && riba_percent.Length > 0 && riba_percent.Length > 0)
            {
                if (Double.TryParse(makazi_percent, out out_value) && Double.TryParse(biashara_percent, out out_value) && Double.TryParse(makazi_biashara_percent, out out_value)
                    && Double.TryParse(kiwanda_percent, out out_value) && Double.TryParse(taasisi_percent, out out_value) &&
                    Double.TryParse(kiwanda_percent, out out_value) && Double.TryParse(taasisi_percent, out out_value) && Double.TryParse(limbikizo_percent, out out_value)
                    )
                {
                    //update basic info
                    connection.Open();
                    try
                    {
                        MySqlCommand cmd = connection.CreateCommand();
                        cmd.CommandText = "UPDATE basic_info SET dname='" + dname + "', dregion='" + dregion + "', daddress='" + daddress + "', dphone='" + dphone + "', account_number='" + account_number + "', dfax='" + dfax + "', " +
                           " dedname= '" + dedname + "', demail='" + demail + "', makazi_percent='" + makazi_percent + "', biashara_percent='" + biashara_percent + "', makazi_biashara_percent='" + makazi_biashara_percent + "', " +
                           "kiwanda_percent='" + kiwanda_percent + "', taasisi_percent='" + taasisi_percent + "', limbikizo_percent='" + limbikizo_percent + "', limbikizo_mwezi='" + limbikizo_mwezi + "', " +
                           "riba_percent='" + riba_percent + "', riba_tumika='" + riba_tumika + "', riba_month='" + riba_month + "' WHERE council_code='"+GlobalVariablesClass.council_code+"' AND region_code='"+GlobalVariablesClass.region_code+"'";
                        int affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows>0)
                        {
                            MessageBox.Show("Umefanikiwa kuhifadhi, funga mfumo harafu uingie upya ili kuanza kutumia mabadilika uliyofanya!");
                        }
                        else
                        {
                            MessageBox.Show("jaribu tena tafadhari!");
                        }
                        connection.Close();

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
                else
                {
                    MessageBox.Show("Weka taarifa kwa tarakimu panapotakiwa kuwekwa tarakimu!");
                }
            }
            else
            {
                MessageBox.Show("Usifute taarifa yoyote, badili tu!");
            }
            Cursor.Current = Cursors.Default;
        }
    }
}

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
    public partial class SajiliKataForm : Form
    {
        public SajiliKataForm()
        {
            InitializeComponent();
        }

        private void futaKataBtn_Click(object sender, EventArgs e)
        {
            clearSajiliKataForm();
        }

        private void hifadhiKataBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (jinaKataBox.Text.Equals("") || kodiMajengoBiasharaBox.Text.Equals("") || kodiMajengoMakaziBox.Text.Equals("") || kodiMakaziBiasharaBox.Text.Equals("") || kodiTaasisiBox.Text.Equals("") || kodiKiwandaBox.Text.Equals(""))
            {
                MessageBox.Show("Weka Taarifa zote!");
            }
            else 
            {
                string ward_name        = jinaKataBox.Text;
                string biashara_value   = kodiMajengoBiasharaBox.Text;
                string makazi_value     = kodiMajengoMakaziBox.Text;
                string bmakazi_value    = kodiMakaziBiasharaBox.Text;
                string taasisi_value    = kodiTaasisiBox.Text;
                string kiwanda_value    = kodiKiwandaBox.Text;
                //insert kata here
                MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
                MySql.Data.MySqlClient.MySqlCommand cmd;
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO wards(ward_name, biashara_value, makazi_value, bmakazi_value, taasisi_value, kiwanda_value, council_code, region_code) VALUES("+
                        "'" + ward_name + "'," +
                        "'" + biashara_value + "'," +
                        "'" + makazi_value + "'," +
                        "'" + bmakazi_value + "'," +
                        "'" + taasisi_value + "'," +
                        "'" + kiwanda_value + "'," +
                        "'" + GlobalVariablesClass.council_code + "'," +
                        "'" + GlobalVariablesClass.region_code + "'" +
                        ")";
                    cmd.Parameters.AddWithValue("@ward_name", ward_name);
                    cmd.Parameters.AddWithValue("@biashara_value", biashara_value);
                    cmd.Parameters.AddWithValue("@makazi_value", makazi_value);
                    cmd.Parameters.AddWithValue("@bmakazi_value", bmakazi_value);
                    cmd.Parameters.AddWithValue("@taasisi_value", taasisi_value);
                    cmd.Parameters.AddWithValue("@kiwanda_value", kiwanda_value);
                    cmd.Parameters.AddWithValue("@council_code", GlobalVariablesClass.council_code);
                    cmd.Parameters.AddWithValue("@region_code", GlobalVariablesClass.region_code);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Umefanikiwa kusajili!");
                    clearSajiliKataForm();
                }catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
                finally{
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                    }
                }
               
            }
            Cursor.Current = Cursors.Default;
        }

        private void clearSajiliKataForm()
        {
            jinaKataBox.Text            = "";
            kodiKiwandaBox.Text         = "";
            kodiMajengoBiasharaBox.Text = "";
            kodiMajengoMakaziBox.Text   = "";
            kodiMakaziBiasharaBox.Text  = "";
            kodiTaasisiBox.Text         = "";
        }
    }
}

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
    public partial class SajiliChanzoForm : Form
    {
        public SajiliChanzoForm()
        {
            InitializeComponent();
        }

        private void hifadhiChanzoBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current      = Cursors.WaitCursor;
            string jinaChanzo   = jinaChanzoBox.Text;
            string nambaChanzo  = nambaChanzoBox.Text;
            if (jinaChanzo.Equals("") || nambaChanzo.Equals("")) {
                MessageBox.Show("Weka Jina na Namba ya Chanzo!");
            }
            else
            {
               //insert Chanzo
                MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
                MySql.Data.MySqlClient.MySqlCommand cmd;
                MySql.Data.MySqlClient.MySqlCommand cmd2;
                connection.Open();
                try
                {
                    //check if number has been used
                    cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM actual_sources WHERE src_label='" + nambaChanzo + "' AND region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "'", connection);
                    MySql.Data.MySqlClient.MySqlDataReader myReader = cmd2.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        MessageBox.Show("Namba ya Chanzo imeshatumika kwenye chanzo kingine!");
                        connection.Close();
                    }
                    else
                    {
                        connection.Close();
                        connection.Open();
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "INSERT INTO actual_sources(src_name, src_label, council_code, region_code) VALUES(" +
                            "'" + jinaChanzo + "'," +
                            "'" + nambaChanzo + "'," +
                            "'" + GlobalVariablesClass.council_code + "'," +
                            "'" + GlobalVariablesClass.region_code + "'" +
                            ")";
                        cmd.Parameters.AddWithValue("@src_name", jinaChanzo);
                        cmd.Parameters.AddWithValue("@src_label", nambaChanzo);
                        cmd.Parameters.AddWithValue("@council_code", GlobalVariablesClass.council_code);
                        cmd.Parameters.AddWithValue("@region_code", GlobalVariablesClass.region_code);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Umefanikiwa kusajili chanzo");
                        jinaChanzoBox.Text = "";
                        nambaChanzoBox.Text = "";
                    }
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
    }
}

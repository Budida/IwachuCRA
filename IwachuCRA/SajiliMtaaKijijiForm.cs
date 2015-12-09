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
    public partial class SajiliMtaaKijijiForm : Form
    {
        public SajiliMtaaKijijiForm()
        {
            InitializeComponent();
            FillDropDownList("SELECT * FROM wards WHERE council_code='"+GlobalVariablesClass.council_code+"' AND region_code='"+GlobalVariablesClass.region_code+"'", kataSelectDropDown);
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //do nothing
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //process save mtaa kijiji
            Cursor.Current = Cursors.WaitCursor;
            if(jinaLaMtaaKijijiBox.Text.Equals("") || kataSelectDropDown.Text.Equals(""))
            {
                MessageBox.Show("Weka taarifa zote kwanza!");
            }
            else
            {
                string street_name  = jinaLaMtaaKijijiBox.Text;
                string wardid       = kataSelectDropDown.SelectedValue.ToString();
                MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
                MySql.Data.MySqlClient.MySqlCommand cmd;
                connection.Open();
                try 
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO streets(street_name, wardid, council_code, region_code) VALUES ("+
                        "'"+street_name+"',"+
                        "'" + wardid + "'," +
                        "'" + GlobalVariablesClass.council_code + "'," +
                         "'" + GlobalVariablesClass.region_code + "'" +
                        ")";
                    cmd.Parameters.AddWithValue("@street_name", street_name);
                    cmd.Parameters.AddWithValue("@wardid", wardid);
                    cmd.Parameters.AddWithValue("@council_code", GlobalVariablesClass.council_code);
                    cmd.Parameters.AddWithValue("@region_code", GlobalVariablesClass.region_code);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Umefanikiwa kusajili");
                    jinaLaMtaaKijijiBox.Text = "";
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

            Cursor.Current = Cursors.Default;
        }

        public static void FillDropDownList(string Query, System.Windows.Forms.ComboBox DropDownName)
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
                DropDownName.ValueMember    = "wid";
                DropDownName.DisplayMember  = "ward_name";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }
    }
}

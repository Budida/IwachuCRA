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
    public partial class AndaaMakisioForm : Form
    {
        public static DateTime referenceDate = new DateTime(1970, 1, 1);
        string connectionString = GlobalVariablesClass.connString;
        TextBox[] amounts;
        Label[] ids;
        Label[] names;
        static int count = 0;
        static int i;
        public AndaaMakisioForm()
        {
            InitializeComponent();
            makisioBoxesPanel.HorizontalScroll.Enabled = false;
            serialNumberPanel.HorizontalScroll.Enabled = false;
        }

        private void AndaaMakisioForm_Load(object sender, EventArgs e)
        {
            getMaeneoList();
        }

        private void getMaeneoList()
        {
            MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM income_sources WHERE tax_payer='No' AND council_code='"+ GlobalVariablesClass.council_code + "'";
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.HasRows)
                {
                    i       = 0;
                    count   = getMaeneoListCount();
                    names   = new Label[count];
                    amounts = new TextBox[count];
                    ids     = new Label[count];
                    while (myReader.Read())
                    {
                        if (i < count)
                        {
                            names[i]    = new Label();
                            ids[i]      = new Label();
                            amounts[i]  = new TextBox();
                            amounts[i].Width = 250;
                            names[i].Width = 420;
                            names[i].Text   = (i+1).ToString()+". "+myReader.GetString(myReader.GetOrdinal("source"));
                            ids[i].Text     = myReader.GetString(myReader.GetOrdinal("id"));
                            amounts[i].Text = "No: " + (i + 1).ToString();
                            if (i > 0)
                            {
                                names[i].Top    = names[i - 1].Bottom;
                                amounts[i].Top  = amounts[i - 1].Bottom;
                                ids[i].Top      = ids[i - 1].Bottom;
                            }
                            maeneoNamesPanel.Controls.Add(names[i]);
                            makisioBoxesPanel.Controls.Add(amounts[i]);
                            serialNumberPanel.Controls.Add(ids[i]);
                           
                        }
                        i=i+1;
                    }
                }
                else
                {
                    MessageBox.Show("Hakuna maeneo yalisajiliwa!");
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
        private int getMaeneoListCount()
        {
            int idadi = 0;
            MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM income_sources WHERE tax_payer='No' AND council_code='" + GlobalVariablesClass.council_code + "'";
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        idadi = idadi + 1;
                    }
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
            return idadi;
        }
        private int getCheckMakisio(int id, double start_seconds, double end_seconds)
        {
            int count = 0;
            MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM makisio_mapato WHERE source_id='"+id+ "' AND start_date='"+start_seconds+ "' AND end_date='"+end_seconds+"' AND council_code='" + GlobalVariablesClass.council_code + "'";
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.HasRows)
                {
                    count++;
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
            return count;
        }
        private void serialNumberPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void maeneoNamesPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void makisioBoxesPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            int check = 0; ;
            int count_amount    = amounts.Length;
            int count_ids       = ids.Length;
            DateTime start_date = fromDatePick.Value;
            DateTime end_date   = toDatePick.Value;
            double from_seconds = toSeconds(start_date, referenceDate);
            double to_seconds   = toSeconds(end_date, referenceDate);
            if ( count_ids == count_amount )
            {
                int outvalue = 0 ;
                    //check if all entered amounts are correct ints
                    for (int i = 0; i < count_amount; i++)
                    {
                        if(!int.TryParse(amounts[i].Text, out outvalue)) {
                            check++;
                        }
                    }

                if (check == 0)
                {
                    for (int i = 0; i < count_amount; i++)
                    {
                        //check if makisio exists
                        if (getCheckMakisio(int.Parse(ids[i].Text), from_seconds, to_seconds) == 0)
                        {
                            //save makisio to db
                            MySqlConnection connection = new MySqlConnection(connectionString);
                            MySqlCommand cmd;
                            connection.Open();
                            try
                            {
                                cmd = connection.CreateCommand();
                                cmd.CommandText = "INSERT INTO makisio_mapato(source_id, amount, start_date, end_date, user, council_code, region_code) VALUES(" +
                                 "'" + ids[i].Text + "'," + "'" + amounts[i].Text + "'," + "'" + from_seconds + "'," + "'" + to_seconds + "'," + "'" + GlobalVariablesClass.fullname + "'," + "'" + GlobalVariablesClass.council_code + "'," + "'" + GlobalVariablesClass.region_code + "'"+
                                ")";
                                cmd.Parameters.AddWithValue("@source_id", ids[i].Text);
                                cmd.Parameters.AddWithValue("@amount", amounts[i].Text);
                                cmd.Parameters.AddWithValue("@start_date", from_seconds);
                                cmd.Parameters.AddWithValue("@end_date", to_seconds);
                                cmd.Parameters.AddWithValue("@user", GlobalVariablesClass.fullname);
                                cmd.Parameters.AddWithValue("@council_code", GlobalVariablesClass.council_code);
                                cmd.Parameters.AddWithValue("@region_code", GlobalVariablesClass.region_code);
                                cmd.ExecuteNonQuery();
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
                            //MessageBox.Show("Makisio yapo tayari ya: " + names[i].Text);
                        }
                    }
                    MessageBox.Show("Umefanikiwa kuhifadhi!");
                }
                else
                {
                    MessageBox.Show("Weka kiasi cha makisio kwa namba, usiweke herufi au alama nyingine");
                }
            }
            else
            {
                MessageBox.Show("Mpangalio wa makisio hauko vizuri!");
            }
            Cursor.Current = Cursors.Default;
        }

        private double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }
    }
}

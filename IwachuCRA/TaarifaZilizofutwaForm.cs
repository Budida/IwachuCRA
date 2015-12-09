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
    public partial class TaarifaZilizofutwaForm : Form
    {
        static double from_seconds  = 0;
        static double to_seconds    = 0;
        double jumla_all            = 0;
        static string connString = GlobalVariablesClass.connString;
        MySqlConnection connection = new MySqlConnection(connString);
        static string select_by = "";
        public TaarifaZilizofutwaForm()
        {
            InitializeComponent();
            selectDropDown.SelectedItem = "Makusanyo";
        }

        private void TaarifaZilizofutwaForm_Load(object sender, EventArgs e)
        {
            
        }

        private void angaliaBtn_Click(object sender, EventArgs e)
        {
            string rcpt, id;
            jumla_all = 0;
            select_by           = selectDropDown.SelectedItem.ToString();
            DateTime from_Date  = fromDatePick.Value;
            DateTime to_Date    = toDatePick.Value;
            from_seconds        = toSeconds(from_Date, GlobalVariablesClass.referenceDate);
            to_seconds          = toSeconds(to_Date, GlobalVariablesClass.referenceDate);
            if (select_by != "")
            {
                MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
                MySqlCommand cmd;
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    if (select_by == "Makusanyo")
                    {
                        cmd.CommandText = "SELECT * FROM income WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "' AND deleted='Yes' AND date>=" + from_seconds + " AND date<=" + to_seconds + "";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM actual_income WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "' AND deleted='Yes' AND date>=" + from_seconds + " AND date<=" + to_seconds + "";
                    }
                    MySqlDataReader myReader = cmd.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        recordsView.Rows.Clear();
                        int count = 1;
                        recordsView.Rows.Clear();
                        recordsView.ColumnCount = 8;
                        recordsView.Columns[0].Name = "SN";
                        recordsView.Columns[1].Name = "TAREHE";
                        recordsView.Columns[2].Name = "KIASI";
                        recordsView.Columns[3].Name = "STAKABADHI";
                        recordsView.Columns[4].Name = "ALIYEWEKA";
                        recordsView.Columns[5].Name = "ALIYEFUTA";
                        recordsView.Columns[6].Name = "SABABU";
                        recordsView.Columns[7].Name = "";
                        recordsView.Columns[0].Width = 50;
                        recordsView.Columns[7].Visible = false;
                        while (myReader.Read())
                        {
                            if (select_by == "Makusanyo")
                            {
                                rcpt = "agent_receipt";
                                id = "rid";
                            }
                            else
                            {
                                rcpt = "rcpt";
                                id = "id";
                            }
                            jumla_all += myReader.GetDouble(myReader.GetOrdinal("amount"));
                            string[] row = { count.ToString(), myReader.GetString(myReader.GetOrdinal("raw_date")), myReader.GetString(myReader.GetOrdinal("amount")), myReader.GetString(myReader.GetOrdinal(rcpt)), myReader.GetString(myReader.GetOrdinal("user")), myReader.GetString(myReader.GetOrdinal("who_deleted")), myReader.GetString(myReader.GetOrdinal("delete_details")), myReader.GetString(myReader.GetOrdinal(id)) };
                            recordsView.Rows.Add(row);
                            count++;
                        }
                        //recordsView.Rows.Add("", "JUMLA", jumla_all.ToString(), "", "", "", "", "", "0");
                        connection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Hakuna taarifa zilizofutwa kwa kipindi ulichochagua");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    connection.Close();
                }
            }
        }
        private double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }

        private void undoBtn_Click(object sender, EventArgs e)
        {
            int i;
            string col_name, table;
            i = recordsView.SelectedCells[0].RowIndex;
            int id = int.Parse(this.recordsView.Rows[i].Cells[7].Value.ToString());
            var confirmResult = MessageBox.Show("Ni kweli unataka kurejesha kwenye orodha ya miamala halali ?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                if (select_by.Length > 0)
                {
                    if (select_by == "Makusanyo")
                    {
                        col_name    = "rid";
                        table       = "income";
                    }
                    else
                    {
                        col_name    = "id";
                        table       = "actual_income";
                    }
                    MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
                    MySqlCommand cmd;
                    connection.Open();
                    try
                    {
                        cmd = connection.CreateCommand();
                        cmd.CommandText = "UPDATE "+table+" SET deleted='No' WHERE "+col_name+" = "+id;
                        int affectedRows = cmd.ExecuteNonQuery();
                        if (affectedRows > 0)
                        {
                            MessageBox.Show("Umefanikiwa kurejesha!");
                        }
                        else
                        {
                            MessageBox.Show("Imeshindikana kurejesha!");
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}

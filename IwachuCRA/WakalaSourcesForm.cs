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
    public partial class WakalaSourcesForm : Form
    {
        public WakalaSourcesForm()
        {
            InitializeComponent();
        }

        private void WakalaSourcesForm_Load(object sender, EventArgs e)
        {
            if(OrodhaYaMawakalaForm.wakala_name.Length >0)
            {
                loadMaeneoList(OrodhaYaMawakalaForm.from_seconds, OrodhaYaMawakalaForm.to_seconds);
            }
            else
            {
                MessageBox.Show("Chagua vizuri wakala");
            }
        }

        private void loadMaeneoList(Double startdate, Double enddate)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString))
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT wakala_sources.id, source, wakala_sources.slabel FROM wakala_sources JOIN income_sources ON wakala_sources.slabel=income_sources.slabel WHERE wakala_sources.council_code='" + GlobalVariablesClass.council_code + "' AND wakala_sources.region_code='" + GlobalVariablesClass.region_code + "' AND wakala_sources.from_date='" + OrodhaYaMawakalaForm.from_seconds + "' AND wakala_sources.to_date='" + OrodhaYaMawakalaForm.to_seconds + "' AND wakala_sources.wakalaname='"+OrodhaYaMawakalaForm.wakala_name+"'";
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            this.maeneoYaWakalaDataGridView.Visible = true;
                            DataTable dt                            = new DataTable();
                            dt.Load(reader);
                            this.maeneoYaWakalaDataGridView.DataSource = dt;

                            this.maeneoYaWakalaDataGridView.Columns["source"].HeaderText = "Jina La Eneo";
                            this.maeneoYaWakalaDataGridView.Columns["slabel"].HeaderText = "Namba Ya Eneo";
                            this.maeneoYaWakalaDataGridView.Columns["id"].Visible       = false;
                            if (null != this.maeneoYaWakalaDataGridView)
                            {
                                foreach (DataGridViewRow r in this.maeneoYaWakalaDataGridView.Rows)
                                {
                                    this.maeneoYaWakalaDataGridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                                }
                            }
                        }
                        else
                        {
                            this.maeneoYaWakalaDataGridView.Visible = false;
                            MessageBox.Show("Hakuna maeneo wakala anasimamia!");
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void LoadSerial(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[row.Index].HeaderCell.Value = string.Format("{0}  ", row.Index + 1).ToString();
                row.Height = 25;
            }
        }
        private void orodhaWakalaDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadSerial(this.maeneoYaWakalaDataGridView);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //remove eneo from wakala 
            if (this.maeneoYaWakalaDataGridView.Rows.Count > 1)
            {
                int i;
                i = this.maeneoYaWakalaDataGridView.SelectedCells[0].RowIndex;
                int id = int.Parse(this.maeneoYaWakalaDataGridView.Rows[i].Cells[0].Value.ToString());
                MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
                MySql.Data.MySqlClient.MySqlCommand cmd;
                connection.Open();
                try {
                    cmd                 = connection.CreateCommand();
                    cmd.CommandText     = "DELETE FROM wakala_sources WHERE id='"+id+"'";
                    int affectedRows    = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Umefanikiwa kuondoa eneo chini ya usimamizi wa wakala!");
                        loadMaeneoList(OrodhaYaMawakalaForm.from_seconds, OrodhaYaMawakalaForm.to_seconds);
                    }
                    else
                    {
                        MessageBox.Show("Imeshindikana, jaribu tena!");
                    }
                }
                catch (Exception ex) {
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
                MessageBox.Show("Hakuna eneo la kuondoa, anatakiwa abaki na eneo angalau moja!!");
            }
        }
    }
}

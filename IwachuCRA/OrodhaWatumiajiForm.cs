using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IwachuCRA
{
    public partial class OrodhaWatumiajiForm : Form
    {
        static int userid = 0;
        public OrodhaWatumiajiForm()
        {
            InitializeComponent();
        }
        private void OrodhaWatumiajiForm_Load(object sender, EventArgs e)
        {
            loadMaeneoList();
            FillDropDownListLevels("SELECT level FROM user_levels WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", this.levelsDropDown);
        }
        public static void FillDropDownListLevels(string Query, System.Windows.Forms.ComboBox DropDownName)
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
                DropDownName.ValueMember = "level";
                DropDownName.DisplayMember = "level";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void loadMaeneoList()
        {
            using (MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString))
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, fullname, username, email, phone, level  FROM users WHERE users.council_code='" + GlobalVariablesClass.council_code + "' AND users.region_code='" + GlobalVariablesClass.region_code + "'";
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            this.usersDataGridView.Visible = true;
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            this.usersDataGridView.DataSource = dt;

                            this.usersDataGridView.Columns["fullname"].HeaderText = "JINA KAMILI";
                            this.usersDataGridView.Columns["username"].HeaderText = "JINA LA KUINGILIA";
                            this.usersDataGridView.Columns["email"].HeaderText = "BARUA PEPE";
                            this.usersDataGridView.Columns["phone"].HeaderText = "SIMU";
                            this.usersDataGridView.Columns["level"].HeaderText = "CHEO";
                            this.usersDataGridView.Columns[0].Visible = false;

                            if (null != this.usersDataGridView)
                            {
                                foreach (DataGridViewRow r in this.usersDataGridView.Rows)
                                {
                                    this.usersDataGridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                                }
                            }
                        }
                        else
                        {
                            this.usersDataGridView.Visible = false;
                            MessageBox.Show("Hakuna watumiaji waliosajiliwa!");
                        }
                    }
                }
            }
        }

        private void pakuaUpyaBtn_Click(object sender, EventArgs e)
        {
            loadMaeneoList();
        }

        
        private void exportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Orodhayawatumiaji.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.usersDataGridView, sfd.FileName);

            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            try
            {
                string stOutput = "";
                // Export titles:
                string sHeaders = "";

                for (int j = 0; j < dGV.Columns.Count; j++)
                    sHeaders = sHeaders.ToString() + Convert.ToString(dGV.Columns[j].HeaderText) + "\t";
                stOutput += sHeaders + "\r\n";
                // Export data.
                for (int i = 0; i < dGV.RowCount - 1; i++)
                {
                    string stLine = "";
                    for (int j = 0; j < dGV.Rows[i].Cells.Count; j++)
                        stLine = stLine.ToString() + Convert.ToString(dGV.Rows[i].Cells[j].Value) + "\t";
                    stOutput += stLine + "\r\n";
                }
                Encoding utf16 = Encoding.GetEncoding(1254);
                byte[] output = utf16.GetBytes(stOutput);
                FileStream fs = new FileStream(filename, FileMode.Create);
                BinaryWriter bw = new BinaryWriter(fs);
                bw.Write(output, 0, output.Length); //write the encoded file
                bw.Flush();
                bw.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kuna tatizo, jaribu tena!" + ex.Message);
            }
        }

        private void badiliBtn_Click(object sender, EventArgs e)
        {
            int i;
            i = this.usersDataGridView.SelectedCells[0].RowIndex;
            userid = int.Parse(this.usersDataGridView.Rows[i].Cells[0].Value.ToString());
            fullNameBox.Text = this.usersDataGridView.Rows[i].Cells[1].Value.ToString();
            userNameBox.Text = this.usersDataGridView.Rows[i].Cells[2].Value.ToString();
            emailBox.Text   = this.usersDataGridView.Rows[i].Cells[3].Value.ToString();
            simuBox.Text    = this.usersDataGridView.Rows[i].Cells[4].Value.ToString();
            levelsDropDown.SelectedValue = this.usersDataGridView.Rows[i].Cells[5].Value.ToString();
            
        }

        private void hifadhiBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string fullname = fullNameBox.Text;
            string username = userNameBox.Text;
            string email = emailBox.Text;
            string phone = simuBox.Text;
            string level = levelsDropDown.SelectedValue.ToString();
            if (fullname.Length > 0 && username.Length > 0 && email.Length > 0 && phone.Length > 0 && level.Length > 0)
            {
                MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
                MySqlCommand cmd;
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "UPDATE users SET fullname='" + fullname + "', email='" + email + "', username='" + username + "', level='" + level + "', phone='" + phone + "', user='" + GlobalVariablesClass.fullname + "' WHERE id='"+userid+"'";
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@level", level);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@user", GlobalVariablesClass.fullname);
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        fullNameBox.Text = "";
                        userNameBox.Text = "";
                        emailBox.Text = "";
                        simuBox.Text = "";
                        MessageBox.Show("Umefanikiwa kubadili!");
                    }
                    else
                    {
                        MessageBox.Show("Imeshindikana kubadili, jaribu tena!");
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
            else
            {
                MessageBox.Show("Weka Taarifa zote!");
            }
            Cursor.Current = Cursors.Default;
        }
    }
}

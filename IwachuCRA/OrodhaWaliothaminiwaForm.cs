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
using iTextSharp.text.pdf;
using iTextSharp.text;
namespace IwachuCRA
{
    public partial class OrodhaWaliothaminiwaForm : Form
    {
        static int count_recordsexport = 1;
        static string connString = GlobalVariablesClass.connString;
        MySqlConnection connection = new MySqlConnection(connString);
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        static int page_number = 0;
        static int count_per_page = 100;
        static int next_offset = 0;
        static int total_pages = 0;
        static int total_rows = 0;
        static string search_ward = "";
        static string search_street = "";
        static string search_matumizi = "";
        static string tathmini = "Ndiyo";
        static double jumla_kodi = 0;
        public OrodhaWaliothaminiwaForm()
        {
            InitializeComponent();
            loadData(page_number, count_per_page, next_offset);
            currentPageLabel.Text = (page_number + 1).ToString();
            if (int.Parse(currentPageLabel.Text) == 1)
            {
                backwardBtn.Enabled = false;
            }
            string current_sql  = "SELECT * FROM income_sources WHERE tax_payer='Yes' AND rat_value > 0 AND council_code='" + GlobalVariablesClass.council_code + "'";
            jumla_kodi          = jumlaKodi(current_sql);
            total_rows          = countRows(current_sql);
            if (total_rows > 0)
            {
                total_pages = (int)Math.Ceiling((double)total_rows / (double)count_per_page);
                totalPagesLabel.Text = total_pages.ToString();
                idadiKodiLabel.Text = "IDADI: " + String.Format("{0:0,0}", total_rows).ToString();
                jumlaKodiLabel.Text = "JUMLA KODI: " + String.Format("{0:0,0.00}", jumla_kodi).ToString();
            }

            //fill mitaa na kata
            FillDropDownListKata("SELECT ward_name FROM wards WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", kataDropDown);
            FillDropDownListMtaaKijiji("SELECT street_name FROM streets WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", mitaaDropDown);
            //setting values of mitaa and kata to empty at initial waiting for user to select
            matumiziDropDown.SelectedItem = "";
            tathminiDropDown.SelectedItem = "Ndiyo";
        }

        private void OrodhaWaliothaminiwaForm_Load(object sender, EventArgs e)
        {

        }

        private void loadData(int pagenumber, int countperpage, int nextoffset)
        {
            Cursor.Current = Cursors.WaitCursor;
            ds.Clear();
            nextoffset = pagenumber * countperpage;
            page_number = pagenumber;
            MySqlCommand cmd;
            string sql;
            if (tathmini == "Ndiyo")
            {
                sql = "SELECT id, source, slabel, phone_number, email_address, address, street,ward, plot_number, block_number, matumizi, rat_value, tax_amount  FROM income_sources WHERE tax_payer= 'Yes' AND council_code='" + GlobalVariablesClass.council_code + "' AND rat_value > 0 LIMIT " + countperpage + " OFFSET " + nextoffset;
            }
            else
            {
                sql = "SELECT id, source, slabel, phone_number, email_address, address, street,ward, plot_number, block_number, matumizi, rat_value, tax_amount  FROM income_sources WHERE tax_payer= 'Yes' AND council_code='" + GlobalVariablesClass.council_code + "' AND rat_value = 0 LIMIT " + countperpage + " OFFSET " + nextoffset;
            }
            
            cmd = new MySqlCommand(sql, connection);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, 0, 100, "income_sources");
            this.waliothaminiwaDataGridView1.DataSource = ds.Tables[0];
            this.waliothaminiwaDataGridView1.Columns["id"].Visible = false;
            this.waliothaminiwaDataGridView1.Columns["source"].HeaderText = "JINA";
            this.waliothaminiwaDataGridView1.Columns["slabel"].HeaderText = "NAMBA YA USAJILI";
            this.waliothaminiwaDataGridView1.Columns["phone_number"].HeaderText = "SIMU";
            this.waliothaminiwaDataGridView1.Columns["email_address"].HeaderText = "BARUA PEPE";
            this.waliothaminiwaDataGridView1.Columns["address"].HeaderText = "ANUANI";
            this.waliothaminiwaDataGridView1.Columns["street"].HeaderText = "MTAA";
            this.waliothaminiwaDataGridView1.Columns["ward"].HeaderText = "KATA";
            this.waliothaminiwaDataGridView1.Columns["plot_number"].HeaderText = "NAMBA KIWANJA";
            this.waliothaminiwaDataGridView1.Columns["block_number"].HeaderText = "KITALU";
            this.waliothaminiwaDataGridView1.Columns["rat_value"].HeaderText = "THAMANI";
            this.waliothaminiwaDataGridView1.Columns["tax_amount"].HeaderText = "KODI";
            this.waliothaminiwaDataGridView1.Columns["matumizi"].HeaderText = "MATUMIZI";
            Cursor.Current = Cursors.Default;
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
                dt.Rows.Add("");
                DropDownName.DataSource = dt;
                DropDownName.ValueMember = "ward_name";
                DropDownName.DisplayMember = "ward_name";
                DropDownName.SelectedValue = "";
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
                dt.Rows.Add("");
                DropDownName.DataSource = dt;
                DropDownName.ValueMember = "street_name";
                DropDownName.DisplayMember = "street_name";
                DropDownName.SelectedValue = "";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }
        private int countRows(string sql)
        {
            int rows = 0;
            connection.Open();
            MySqlCommand cmd;
            cmd = new MySqlCommand(sql, connection);
            MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    rows++;
                }
            }
            connection.Close();
            return rows;
        }

        private double jumlaKodi(string sql)
        {
            double jumla = 0;
            connection.Open();
            MySqlCommand cmd;
            cmd = new MySqlCommand(sql, connection);
            MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    jumla = jumla + myReader.GetDouble(myReader.GetOrdinal("tax_amount"));
                }
            }
            connection.Close();
            return jumla;
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            page_number = int.Parse(currentPageLabel.Text) + 1;
            if (page_number > total_pages)
            {
                page_number = 0;
                currentPageLabel.Text = (page_number + 1).ToString();
                backwardBtn.Enabled = false;
            }
            else
            {
                currentPageLabel.Text = (page_number).ToString();
                backwardBtn.Enabled = true;
            }
            if (search_ward.Length == 0 && search_street.Length == 0 && search_matumizi.Length == 0)
            {
                loadData(page_number, count_per_page, next_offset);
            }
            else if (search_ward.Length > 0 && search_street.Length == 0 && search_matumizi.Length == 0)
            {
                loadDataKata(page_number, count_per_page, next_offset, search_ward);
            }
            else if (search_ward.Length == 0 && search_street.Length > 0 && search_matumizi.Length == 0)
            {
                loadDataStreet(page_number, count_per_page, next_offset, search_street);
            }
            else if (search_ward.Length == 0 && search_street.Length == 0 && search_matumizi.Length > 0)
            {
                loadDataMatumzi(page_number, count_per_page, next_offset, search_matumizi);
            }
        }

        private void backwardBtn_Click(object sender, EventArgs e)
        {
            page_number = int.Parse(currentPageLabel.Text) - 1;
            if (page_number <= 0)
            {
                page_number = 0;
                backwardBtn.Enabled = false;
                currentPageLabel.Text = (1).ToString();
            }
            else
            {
                currentPageLabel.Text = (page_number).ToString();
            }
            if (search_ward.Length == 0 && search_street.Length == 0 && search_matumizi.Length == 0)
            {
                loadData(page_number, count_per_page, next_offset);
            }
           else if (search_ward.Length > 0 && search_street.Length == 0 && search_matumizi.Length == 0)
            {
                loadDataKata(page_number, count_per_page, next_offset, search_ward);
            }
            else if (search_ward.Length == 0 && search_street.Length > 0 && search_matumizi.Length == 0)
            {
                loadDataStreet(page_number, count_per_page, next_offset, search_street);
            }
            else if (search_ward.Length == 0 && search_street.Length == 0 && search_matumizi.Length > 0)
            {
                loadDataMatumzi(page_number, count_per_page, next_offset, search_matumizi);
            }
           
        }

        private void searchWalithaminiwaBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string ward = kataDropDown.SelectedValue.ToString();
            string mtaa = mitaaDropDown.SelectedValue.ToString();
            string matumizi = matumiziDropDown.SelectedItem.ToString();
            if (ward.Length > 0 && mtaa.Length == 0 && matumizi.Length == 0)
            {
                search_ward     = ward;
                search_street   = "";
                search_matumizi = "";
                tathmini        = tathminiDropDown.SelectedItem.ToString();
                page_number     = 0;
                next_offset     = 0;
                count_per_page = 100;
                loadDataKata(page_number, count_per_page, next_offset, ward);
                //calculate total pages
                string current_sql;
                if (tathmini == "Ndiyo")
                {
                    current_sql = "SELECT * FROM income_sources WHERE tax_payer='Yes' AND rat_value > 0 AND council_code='" + GlobalVariablesClass.council_code + "' AND ward = '" + ward + "'";
                }
                else
                {
                    current_sql = "SELECT * FROM income_sources WHERE tax_payer='Yes' AND rat_value = 0 AND council_code='" + GlobalVariablesClass.council_code + "' AND ward = '" + ward + "'";
                }
                jumla_kodi = jumlaKodi(current_sql);
                total_rows = countRows(current_sql);
                if (total_rows > 0)
                {
                    total_pages = (int)Math.Ceiling((double)total_rows / (double)count_per_page);
                    totalPagesLabel.Text = total_pages.ToString();
                    idadiKodiLabel.Text = "IDADI: " + String.Format("{0:0,0}", total_rows).ToString();
                    jumlaKodiLabel.Text = "JUMLA KODI: " + String.Format("{0:0,0.00}", jumla_kodi).ToString();
                }
                else
                {
                    totalPagesLabel.Text    = "1";
                    idadiKodiLabel.Text     = "IDADI: 0";
                }
                //clear select options
                kataDropDown.SelectedValue = "";
                mitaaDropDown.SelectedValue = "";
                matumiziDropDown.SelectedItem = "";
            }
            else if (ward.Length == 0 && mtaa.Length > 0 && matumizi.Length == 0)
            {
                search_ward = "";
                search_street = mtaa;
                search_matumizi = "";
                tathmini = tathminiDropDown.SelectedItem.ToString();
                page_number = 0;
                next_offset = 0;
                count_per_page = 100;
                loadDataStreet(page_number, count_per_page, next_offset, mtaa);
                //calculate total pages
                string current_sql;
                if (tathmini == "Ndiyo")
                {
                    current_sql = "SELECT * FROM income_sources WHERE tax_payer='Yes' AND rat_value > 0 AND  council_code='" + GlobalVariablesClass.council_code + "' AND street = '" + mtaa + "'";
                }
                else
                {
                    current_sql = "SELECT * FROM income_sources WHERE tax_payer='Yes' AND rat_value = 0 AND  council_code='" + GlobalVariablesClass.council_code + "' AND street = '" + mtaa + "'";
                }
                jumla_kodi = jumlaKodi(current_sql);
                total_rows = countRows(current_sql);
                if (total_rows > 0)
                {
                    total_pages = (int)Math.Ceiling((double)total_rows / (double)count_per_page);
                    totalPagesLabel.Text = total_pages.ToString();
                    idadiKodiLabel.Text = "IDADI: " + String.Format("{0:0,0}", total_rows).ToString();
                    jumlaKodiLabel.Text = "JUMLA KODI: " + String.Format("{0:0,0.00}", jumla_kodi).ToString();
                }
                else
                {
                    totalPagesLabel.Text = "1";
                    idadiKodiLabel.Text = "IDADI: 0";
                }
                //clear select options
                kataDropDown.SelectedValue      = "";
                mitaaDropDown.SelectedValue     = "";
                matumiziDropDown.SelectedText   = "";
            }
            else if (ward.Length == 0 && mtaa.Length == 0 && matumizi.Length > 0)
            {
                search_ward = "";
                search_street = "";
                search_matumizi = matumizi;
                tathmini = tathminiDropDown.SelectedItem.ToString(); ;
                page_number = 0;
                next_offset = 0;
                count_per_page = 100;
                loadDataMatumzi(page_number, count_per_page, next_offset, matumizi);
                //calculate total pages
                string current_sql;
                if (tathmini == "Ndiyo")
                {
                    if (matumizi == "Biashara/Makazi")
                    {
                        current_sql = "SELECT * FROM income_sources WHERE tax_payer='Yes' AND rat_value > 0 AND council_code='" + GlobalVariablesClass.council_code + "' AND (matumizi = 'Makazi/Biashara' OR matumizi='Makazi_Biashara' OR matumizi='Biashara_Makazi' OR matumizi='Biashara/Makazi')";
                        jumla_kodi = jumlaKodi(current_sql);
                        total_rows = countRows(current_sql);
                    }
                    else
                    {
                        current_sql = "SELECT * FROM income_sources WHERE tax_payer='Yes' AND rat_value > 0 AND council_code='" + GlobalVariablesClass.council_code + "' AND matumizi = '" + matumizi + "'";
                        jumla_kodi = jumlaKodi(current_sql);
                        total_rows = countRows(current_sql);
                    }
                }
                else
                {
                    if (matumizi == "Biashara/Makazi")
                    {
                        current_sql = "SELECT * FROM income_sources WHERE tax_payer='Yes' AND rat_value = 0 AND council_code='" + GlobalVariablesClass.council_code + "' AND (matumizi = 'Makazi/Biashara' OR matumizi='Makazi_Biashara' OR matumizi='Biashara_Makazi' OR matumizi='Biashara/Makazi')";
                        jumla_kodi = jumlaKodi(current_sql);
                        total_rows = countRows(current_sql);
                    }
                    else
                    {
                        current_sql = "SELECT * FROM income_sources WHERE tax_payer='Yes' AND rat_value = 0 AND council_code='" + GlobalVariablesClass.council_code + "' AND matumizi = '" + matumizi + "'";
                        jumla_kodi = jumlaKodi(current_sql);
                        total_rows = countRows(current_sql);
                    }
                }

                if (total_rows > 0)
                {
                    total_pages = (int)Math.Ceiling((double)total_rows / (double)count_per_page);
                    totalPagesLabel.Text = total_pages.ToString();
                    idadiKodiLabel.Text = "IDADI: " + String.Format("{0:0,0}", total_rows).ToString();
                    jumlaKodiLabel.Text = "JUMLA KODI: " + String.Format("{0:0,0.00}", jumla_kodi).ToString();
                }
                else
                {
                    totalPagesLabel.Text    = "1";
                    idadiKodiLabel.Text     = "IDADI: 0";
                }
                //clear select options
                kataDropDown.SelectedValue = "";
                mitaaDropDown.SelectedValue = "";
                matumiziDropDown.SelectedItem = "";
            }
            Cursor.Current = Cursors.Default;
        }

        private void loadDataKata(int pagenumber, int countperpage, int nextoffset, string ward)
        {
            Cursor.Current = Cursors.WaitCursor;
            ds.Clear();
            nextoffset = pagenumber * countperpage;
            page_number = pagenumber;
            MySqlCommand cmd;
            string sql;
            if (tathmini == "Ndiyo")
            {
                sql = "SELECT id, source, slabel, phone_number, email_address, address, street,ward, plot_number, block_number, matumizi, rat_value, tax_amount  FROM income_sources WHERE tax_payer= 'Yes' AND rat_value > 0 AND ward='" + ward + "' LIMIT " + countperpage + " OFFSET " + nextoffset;
            }
            else
            {
                sql = "SELECT id, source, slabel, phone_number, email_address, address, street,ward, plot_number, block_number, matumizi, rat_value, tax_amount  FROM income_sources WHERE tax_payer= 'Yes' AND rat_value = 0 AND ward='" + ward + "' LIMIT " + countperpage + " OFFSET " + nextoffset;
            }
            
            cmd = new MySqlCommand(sql, connection);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, 0, 100, "income_sources");
            this.waliothaminiwaDataGridView1.DataSource = ds.Tables[0];
            this.waliothaminiwaDataGridView1.Columns["id"].Visible = false;
            this.waliothaminiwaDataGridView1.Columns["source"].HeaderText = "JINA";
            this.waliothaminiwaDataGridView1.Columns["slabel"].HeaderText = "NAMBA YA USAJILI";
            this.waliothaminiwaDataGridView1.Columns["phone_number"].HeaderText = "SIMU";
            this.waliothaminiwaDataGridView1.Columns["email_address"].HeaderText = "BARUA PEPE";
            this.waliothaminiwaDataGridView1.Columns["address"].HeaderText = "ANUANI";
            this.waliothaminiwaDataGridView1.Columns["street"].HeaderText = "MTAA";
            this.waliothaminiwaDataGridView1.Columns["ward"].HeaderText = "KATA";
            this.waliothaminiwaDataGridView1.Columns["plot_number"].HeaderText = "NAMBA KIWANJA";
            this.waliothaminiwaDataGridView1.Columns["block_number"].HeaderText = "KITALU";
            this.waliothaminiwaDataGridView1.Columns["rat_value"].HeaderText = "THAMANI";
            this.waliothaminiwaDataGridView1.Columns["tax_amount"].HeaderText = "KODI";
            this.waliothaminiwaDataGridView1.Columns["matumizi"].HeaderText = "MATUMIZI";
            Cursor.Current = Cursors.Default;
        }
        private void loadDataStreet(int pagenumber, int countperpage, int nextoffset, string street)
        {
            Cursor.Current = Cursors.WaitCursor;
            ds.Clear();
            nextoffset = pagenumber * countperpage;
            page_number = pagenumber;
            MySqlCommand cmd;
            string sql;
            if(tathmini == "Ndiyo")
            {
                sql = "SELECT id, source, slabel, phone_number, email_address, address, street,ward, plot_number, block_number, matumizi, rat_value, tax_amount  FROM income_sources WHERE tax_payer= 'Yes' AND rat_value > 0 AND street='" + street + "' LIMIT " + countperpage + " OFFSET " + nextoffset;
            }
            else
            {
                sql = "SELECT id, source, slabel, phone_number, email_address, address, street,ward, plot_number, block_number, matumizi, rat_value, tax_amount  FROM income_sources WHERE tax_payer= 'Yes' AND rat_value = 0 AND street='" + street + "' LIMIT " + countperpage + " OFFSET " + nextoffset;
            }
            
            cmd = new MySqlCommand(sql, connection);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, 0, 100, "income_sources");
            this.waliothaminiwaDataGridView1.DataSource = ds.Tables[0];
            this.waliothaminiwaDataGridView1.Columns["id"].Visible = false;
            this.waliothaminiwaDataGridView1.Columns["source"].HeaderText = "JINA";
            this.waliothaminiwaDataGridView1.Columns["slabel"].HeaderText = "NAMBA YA USAJILI";
            this.waliothaminiwaDataGridView1.Columns["phone_number"].HeaderText = "SIMU";
            this.waliothaminiwaDataGridView1.Columns["email_address"].HeaderText = "BARUA PEPE";
            this.waliothaminiwaDataGridView1.Columns["address"].HeaderText = "ANUANI";
            this.waliothaminiwaDataGridView1.Columns["street"].HeaderText = "MTAA";
            this.waliothaminiwaDataGridView1.Columns["ward"].HeaderText = "KATA";
            this.waliothaminiwaDataGridView1.Columns["plot_number"].HeaderText = "NAMBA KIWANJA";
            this.waliothaminiwaDataGridView1.Columns["block_number"].HeaderText = "KITALU";
            this.waliothaminiwaDataGridView1.Columns["rat_value"].HeaderText = "THAMANI";
            this.waliothaminiwaDataGridView1.Columns["tax_amount"].HeaderText = "KODI";
            this.waliothaminiwaDataGridView1.Columns["matumizi"].HeaderText = "MATUMIZI";
            Cursor.Current = Cursors.Default;
        }
        private void loadDataMatumzi(int pagenumber, int countperpage, int nextoffset, string matumizi)
        {
            Cursor.Current = Cursors.WaitCursor;
            ds.Clear();
            nextoffset = pagenumber * countperpage;
            page_number = pagenumber;
            MySqlCommand cmd;
            string sql = "";
            if (tathmini=="Ndiyo")
            {
                if (matumizi == "Biashara/Makazi")
                {
                    sql = "SELECT id, source, slabel, phone_number, email_address, address, street,ward, plot_number, block_number, matumizi, rat_value, tax_amount  FROM income_sources WHERE tax_payer= 'Yes' AND rat_value > 0 AND (matumizi = 'Makazi/Biashara' OR matumizi='Makazi_Biashara' OR matumizi='Biashara_Makazi' OR matumizi='Biashara/Makazi') LIMIT " + countperpage + " OFFSET " + nextoffset;
                }
                else
                {
                    sql = "SELECT id, source, slabel, phone_number, email_address, address, street,ward, plot_number, block_number, matumizi, rat_value, tax_amount  FROM income_sources WHERE tax_payer= 'Yes' AND rat_value > 0 AND matumizi ='" + matumizi + "' LIMIT " + countperpage + " OFFSET " + nextoffset;
                }
            }
            else
            {
                if (matumizi == "Biashara/Makazi")
                {
                    sql = "SELECT id, source, slabel, phone_number, email_address, address, street,ward, plot_number, block_number, matumizi, rat_value, tax_amount  FROM income_sources WHERE tax_payer= 'Yes' AND rat_value = 0 AND (matumizi = 'Makazi/Biashara' OR matumizi='Makazi_Biashara' OR matumizi='Biashara_Makazi' OR matumizi='Biashara/Makazi') LIMIT " + countperpage + " OFFSET " + nextoffset;
                }
                else
                {
                    sql = "SELECT id, source, slabel, phone_number, email_address, address, street,ward, plot_number, block_number, matumizi, rat_value, tax_amount  FROM income_sources WHERE tax_payer= 'Yes' AND rat_value = 0 AND matumizi ='" + matumizi + "' LIMIT " + countperpage + " OFFSET " + nextoffset;
                }
            }
           
            cmd = new MySqlCommand(sql, connection);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, 0, 100, "income_sources");
            this.waliothaminiwaDataGridView1.DataSource = ds.Tables[0];
            this.waliothaminiwaDataGridView1.Columns["id"].Visible = false;
            this.waliothaminiwaDataGridView1.Columns["source"].HeaderText = "JINA";
            this.waliothaminiwaDataGridView1.Columns["slabel"].HeaderText = "NAMBA YA USAJILI";
            this.waliothaminiwaDataGridView1.Columns["phone_number"].HeaderText = "SIMU";
            this.waliothaminiwaDataGridView1.Columns["email_address"].HeaderText = "BARUA PEPE";
            this.waliothaminiwaDataGridView1.Columns["address"].HeaderText = "ANUANI";
            this.waliothaminiwaDataGridView1.Columns["street"].HeaderText = "MTAA";
            this.waliothaminiwaDataGridView1.Columns["ward"].HeaderText = "KATA";
            this.waliothaminiwaDataGridView1.Columns["plot_number"].HeaderText = "NAMBA KIWANJA";
            this.waliothaminiwaDataGridView1.Columns["block_number"].HeaderText = "KITALU";
            this.waliothaminiwaDataGridView1.Columns["rat_value"].HeaderText = "THAMANI";
            this.waliothaminiwaDataGridView1.Columns["tax_amount"].HeaderText = "KODI";
            this.waliothaminiwaDataGridView1.Columns["matumizi"].HeaderText = "MATUMIZI";
            Cursor.Current = Cursors.Default;
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

        private void exportWaliothaminiwaBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Orodhawalipakodi_walitathminiwa.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.waliothaminiwaDataGridView1, sfd.FileName);
            }
        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            //creating document header
            Paragraph para = new Paragraph(GlobalVariablesClass.council_name + "\n" + GlobalVariablesClass.daddress + "\nSIMU: " + GlobalVariablesClass.dphone + "\nNUKSHI: " + GlobalVariablesClass.dfax + "\nBARUA PEPE: " + GlobalVariablesClass.demail + "\n");
            para.Alignment = Element.ALIGN_CENTER;
            Paragraph para_space = new Paragraph("--------WALIPA KODI---------\n");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph(DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            para_date.Font.Size = 10;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(waliothaminiwaDataGridView1.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 9);
            pdfTable.DefaultCell.Phrase = new Phrase() { Font = font };

            int[] widths = { 4, 7, 7, 8, 9, 8, 7, 7, 9, 9, 6, 7, 7 };
            pdfTable.SetWidths(widths);
            //Adding Header row
            foreach (DataGridViewColumn column in waliothaminiwaDataGridView1.Columns)
            {
                if (column.Index == 0)
                {
                    PdfPCell cell = new PdfPCell(new Phrase("SN"));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
                }
                if (column.Index != 0)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
                }

            }

            //Adding DataRow

            foreach (DataGridViewRow row in waliothaminiwaDataGridView1.Rows)
            {

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 0)
                    {
                        pdfTable.AddCell(count_recordsexport.ToString());
                    }
                    if (cell.ColumnIndex != 0)
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }

                }
                count_recordsexport++;
            }

            //Exporting to PDF
            string folderPath = "C:\\IWACHUPDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "WalipaKodiWaliothaminiwa" + count_recordsexport + "ICRADocumentExported.pdf", FileMode.Create))
            {
                //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                Document pdfDoc = new Document(new RectangleReadOnly(842, 595), 10f, 10f, 10f, 0f);
                PdfWriter.GetInstance(pdfDoc, stream);
                pdfDoc.Open();
                pdfDoc.Add(para);
                pdfDoc.Add(para_space);
                pdfDoc.Add(para_date);
                pdfDoc.Add(new_line_para);
                pdfDoc.Add(pdfTable);
                pdfDoc.Close();
                stream.Close();
            }
            MessageBox.Show("Document save in: " + folderPath + "WalipaKodiWaliothaminiwa" + count_recordsexport + "ICRADocumentExported.pdf");
        }
    }
}

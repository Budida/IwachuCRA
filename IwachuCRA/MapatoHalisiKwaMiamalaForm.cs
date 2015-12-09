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
    public partial class MapatoHalisiKwaMiamalaForm : Form
    {
        int count_recordsexport = 1;
        static string connString = GlobalVariablesClass.connString;
        MySqlConnection connection = new MySqlConnection(connString);
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        static int page_number      = 0;
        static int count_per_page   = 100;
        static int next_offset      = 0;
        static int total_pages      = 0;
        static int total_rows       = 0;
        static double jumla_income  = 0;
        static double from_seconds  = 0;
        static double to_seconds    = 0;
        static string user          = "";
        static string mwamala       = "";
        static int source_id        = 0;
        public MapatoHalisiKwaMiamalaForm()
        {
            InitializeComponent();
        }

        private void MapatoHalisiKwaMiamalaForm_Load(object sender, EventArgs e)
        {
            FillDropDownListVyanzo("SELECT sid, src_name FROM actual_sources WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", chanzoDropDown);
            FillDropDownListUsers("SELECT username FROM users WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", mtumiajiDropDown);
            chanzoDropDown.SelectedValue    = "0";
            mtumiajiDropDown.SelectedValue  = "";
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
                dt.Rows.Add("0", "");
                DropDownName.ValueMember = "sid";
                DropDownName.DisplayMember = "src_name";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }
        public static void FillDropDownListUsers(string Query, System.Windows.Forms.ComboBox DropDownName)
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
                dt.Rows.Add("");
                DropDownName.ValueMember = "username";
                DropDownName.DisplayMember = "username";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            user        = mtumiajiDropDown.SelectedValue.ToString();
            mwamala     = mwamalaBox.Text;
            source_id = int.Parse(chanzoDropDown.SelectedValue.ToString());
            DateTime from_Date  = fromDatePick.Value;
            DateTime to_Date    = toDatePick.Value;
            from_seconds        = toSeconds(from_Date, GlobalVariablesClass.referenceDate);
            to_seconds          = toSeconds(to_Date, GlobalVariablesClass.referenceDate);
            string current_sql;
            if (user == "" && source_id == 0 && mwamala.Length==0)
            {
                loadData(page_number, count_per_page, next_offset, from_seconds, to_seconds);
                current_sql = "SELECT amount FROM actual_income WHERE date >= " + from_seconds + " AND date <= " + to_seconds + " AND actual_income.council_code = '" + GlobalVariablesClass.council_code + "' AND actual_income.region_code = '" + GlobalVariablesClass.region_code + "' AND actual_income.deleted = 'no'";
                total_rows = countRows(current_sql);
                jumla_income = jumMakusanyo(current_sql);
                if (total_rows > 0)
                {
                    total_pages = (int)Math.Ceiling((double)total_rows / (double)count_per_page);
                    totalPagesLabel.Text = total_pages.ToString();
                    jumlaLabel.Text = "JUMLA MAPATO: " + String.Format("{0:0,0.00}", jumla_income).ToString();
                }
                else
                {
                    totalPagesLabel.Text = "00";
                    jumlaLabel.Text = "JUMLA MAPATO: 00";
                }
            }
            else if (user == "" && source_id > 0 && mwamala.Length == 0)
            {
                loadDataChanzo(page_number, count_per_page, next_offset, from_seconds, to_seconds);
                current_sql = "SELECT amount FROM actual_income WHERE main_src="+source_id+" AND date >= " + from_seconds + " AND date <= " + to_seconds + " AND actual_income.council_code = '" + GlobalVariablesClass.council_code + "' AND actual_income.region_code = '" + GlobalVariablesClass.region_code + "' AND actual_income.deleted = 'no'";
                total_rows = countRows(current_sql);
                jumla_income = jumMakusanyo(current_sql);
                if (total_rows > 0)
                {
                    total_pages = (int)Math.Ceiling((double)total_rows / (double)count_per_page);
                    totalPagesLabel.Text = total_pages.ToString();
                    jumlaLabel.Text = "JUMLA MAPATO: " + String.Format("{0:0,0.00}", jumla_income).ToString();
                }
                else
                {
                    totalPagesLabel.Text = "00";
                    jumlaLabel.Text = "JUMLA MAPATO: 00";
                }
            }
            else if (user.Length > 0 && source_id == 0 && mwamala.Length == 0)
            {
                loadDataUser(page_number, count_per_page, next_offset, from_seconds, to_seconds);
                current_sql = "SELECT amount FROM actual_income WHERE actual_income.user='" + user + "' AND date >= " + from_seconds + " AND date <= " + to_seconds + " AND actual_income.council_code = '" + GlobalVariablesClass.council_code + "' AND actual_income.region_code = '" + GlobalVariablesClass.region_code + "' AND actual_income.deleted = 'no'";
                total_rows = countRows(current_sql);
                jumla_income = jumMakusanyo(current_sql);
                if (total_rows > 0)
                {
                    total_pages = (int)Math.Ceiling((double)total_rows / (double)count_per_page);
                    totalPagesLabel.Text = total_pages.ToString();
                    jumlaLabel.Text = "JUMLA MAPATO: " + String.Format("{0:0,0.00}", jumla_income).ToString();
                }
                else
                {
                    totalPagesLabel.Text = "00";
                    jumlaLabel.Text = "JUMLA MAPATO: 00";
                }
            }
            else if (user.Length == 0 && source_id == 0 && mwamala.Length > 0)
            {
                loadDataMwamala(page_number, count_per_page, next_offset, from_seconds, to_seconds);
                current_sql = "SELECT amount FROM actual_income WHERE actual_income.rcpt='" + mwamala + "' AND actual_income.council_code = '" + GlobalVariablesClass.council_code + "' AND actual_income.region_code = '" + GlobalVariablesClass.region_code + "' AND actual_income.deleted = 'no'";
                total_rows = countRows(current_sql);
                jumla_income = jumMakusanyo(current_sql);
                if (total_rows > 0)
                {
                    total_pages = (int)Math.Ceiling((double)total_rows / (double)count_per_page);
                    totalPagesLabel.Text = total_pages.ToString();
                    jumlaLabel.Text = "JUMLA MAPATO: " + String.Format("{0:0,0.00}", jumla_income).ToString();
                }
                else
                {
                    totalPagesLabel.Text = "00";
                    jumlaLabel.Text = "JUMLA MAPATO: 00";
                }
            }
        }

        private void loadData(int pagenumber, int countperpage, int nextoffset, double from_seconds, double to_seconds)
        {
            Cursor.Current = Cursors.WaitCursor;
            ds.Clear();
            nextoffset = pagenumber * countperpage;
            page_number = pagenumber;
            MySqlCommand cmd;
            string sql = "SELECT actual_income.id, raw_date, muda, amount, rcpt, chq, slp,  src_name, source, client, user  FROM actual_income JOIN income_sources ON actual_income.branch_src=income_sources.slabel JOIN actual_sources ON actual_income.main_src=actual_sources.sid WHERE actual_income.date >=" + from_seconds + " AND actual_income.date <=" + to_seconds + " AND actual_income.council_code='" + GlobalVariablesClass.council_code + "' AND actual_income.region_code = '" + GlobalVariablesClass.region_code + "' AND  actual_sources.council_code='"+ GlobalVariablesClass.council_code + "' AND income_sources.council_code='"+ GlobalVariablesClass.council_code + "' AND actual_income.deleted ='no' LIMIT " + countperpage + " OFFSET " + nextoffset;
            cmd = new MySqlCommand(sql, connection);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, 0, 100, "actual_income");
            this.incomeResultsDataGridView.DataSource = ds.Tables[0];
            this.incomeResultsDataGridView.Columns["id"].Visible            = false;
            this.incomeResultsDataGridView.Columns["raw_date"].HeaderText   = "TAREHE";
            this.incomeResultsDataGridView.Columns["muda"].HeaderText       = "MUDA";
            this.incomeResultsDataGridView.Columns["amount"].HeaderText     = "KIASI";
            this.incomeResultsDataGridView.Columns["rcpt"].HeaderText       = "MWAMALA";
            this.incomeResultsDataGridView.Columns["chq"].HeaderText        = "HUNDI";
            this.incomeResultsDataGridView.Columns["slp"].HeaderText        = "#MWAMALA BENKI";
            this.incomeResultsDataGridView.Columns["src_name"].HeaderText   = "CHANZO";
            this.incomeResultsDataGridView.Columns["source"].HeaderText     = "ENEO/MLIPA KODI";
            this.incomeResultsDataGridView.Columns["client"].HeaderText     = "TOKA KWA";
            this.incomeResultsDataGridView.Columns["user"].HeaderText       = "ALIYEWEKA";
            Cursor.Current = Cursors.Default;
        }
        private void loadDataChanzo(int pagenumber, int countperpage, int nextoffset, double from_seconds, double to_seconds)
        {
            Cursor.Current = Cursors.WaitCursor;
            ds.Clear();
            nextoffset = pagenumber * countperpage;
            page_number = pagenumber;
            MySqlCommand cmd;
            string sql = "SELECT actual_income.id, raw_date, muda, amount, rcpt, chq, slp,  src_name, source, client, user  FROM actual_income INNER JOIN income_sources ON actual_income.branch_src=income_sources.slabel INNER JOIN actual_sources ON actual_income.main_src=actual_sources.sid WHERE actual_income.main_src='"+source_id+"' AND actual_income.date >=" + from_seconds + " AND actual_income.date <=" + to_seconds + " AND actual_income.council_code='" + GlobalVariablesClass.council_code + "' AND actual_income.region_code = '" + GlobalVariablesClass.region_code + "' AND actual_sources.council_code='"+ GlobalVariablesClass.council_code + "' AND income_sources.council_code='"+ GlobalVariablesClass.council_code + "' AND actual_income.deleted ='no' LIMIT " + countperpage + " OFFSET " + nextoffset;
            cmd = new MySqlCommand(sql, connection);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, 0, 100, "actual_income");
            this.incomeResultsDataGridView.DataSource = ds.Tables[0];
            this.incomeResultsDataGridView.Columns["id"].Visible = false;
            this.incomeResultsDataGridView.Columns["raw_date"].HeaderText = "TAREHE";
            this.incomeResultsDataGridView.Columns["muda"].HeaderText = "MUDA";
            this.incomeResultsDataGridView.Columns["amount"].HeaderText = "KIASI";
            this.incomeResultsDataGridView.Columns["rcpt"].HeaderText = "MWAMALA";
            this.incomeResultsDataGridView.Columns["chq"].HeaderText = "HUNDI";
            this.incomeResultsDataGridView.Columns["slp"].HeaderText = "#MWAMALA BENKI";
            this.incomeResultsDataGridView.Columns["src_name"].HeaderText = "CHANZO";
            this.incomeResultsDataGridView.Columns["source"].HeaderText = "ENEO/MLIPA KODI";
            this.incomeResultsDataGridView.Columns["client"].HeaderText = "TOKA KWA";
            this.incomeResultsDataGridView.Columns["user"].HeaderText = "ALIYEWEKA";
            Cursor.Current = Cursors.Default;
        }
        private void loadDataUser(int pagenumber, int countperpage, int nextoffset, double from_seconds, double to_seconds)
        {
            Cursor.Current = Cursors.WaitCursor;
            ds.Clear();
            nextoffset = pagenumber * countperpage;
            page_number = pagenumber;
            MySqlCommand cmd;
            string sql = "SELECT actual_income.id, raw_date, muda, amount, rcpt, chq, slp,  src_name, source, client, user  FROM actual_income INNER JOIN income_sources ON actual_income.branch_src=income_sources.slabel INNER JOIN actual_sources ON actual_income.main_src=actual_sources.sid WHERE actual_income.user='" + user + "' AND actual_income.date >=" + from_seconds + " AND actual_income.date <=" + to_seconds + " AND actual_income.council_code='" + GlobalVariablesClass.council_code + "' AND actual_income.region_code = '" + GlobalVariablesClass.region_code + "' AND actual_sources.council_code='" + GlobalVariablesClass.council_code + "' AND income_sources.council_code='" + GlobalVariablesClass.council_code + "' AND actual_income.deleted ='no' LIMIT " + countperpage + " OFFSET " + nextoffset;
            cmd = new MySqlCommand(sql, connection);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, 0, 100, "actual_income");
            this.incomeResultsDataGridView.DataSource = ds.Tables[0];
            this.incomeResultsDataGridView.Columns["id"].Visible = false;
            this.incomeResultsDataGridView.Columns["raw_date"].HeaderText = "TAREHE";
            this.incomeResultsDataGridView.Columns["muda"].HeaderText = "MUDA";
            this.incomeResultsDataGridView.Columns["amount"].HeaderText = "KIASI";
            this.incomeResultsDataGridView.Columns["rcpt"].HeaderText = "MWAMALA";
            this.incomeResultsDataGridView.Columns["chq"].HeaderText = "HUNDI";
            this.incomeResultsDataGridView.Columns["slp"].HeaderText = "#MWAMALA BENKI";
            this.incomeResultsDataGridView.Columns["src_name"].HeaderText = "CHANZO";
            this.incomeResultsDataGridView.Columns["source"].HeaderText = "ENEO/MLIPA KODI";
            this.incomeResultsDataGridView.Columns["client"].HeaderText = "TOKA KWA";
            this.incomeResultsDataGridView.Columns["user"].HeaderText = "ALIYEWEKA";
            Cursor.Current = Cursors.Default;
        }
        private void loadDataMwamala(int pagenumber, int countperpage, int nextoffset, double from_seconds, double to_seconds)
        {
            Cursor.Current = Cursors.WaitCursor;
            ds.Clear();
            nextoffset = pagenumber * countperpage;
            page_number = pagenumber;
            MySqlCommand cmd;
            string sql = "SELECT actual_income.id, raw_date, muda, amount, rcpt, chq, slp,  src_name, source, client, user  FROM actual_income INNER JOIN income_sources ON actual_income.branch_src=income_sources.slabel INNER JOIN actual_sources ON actual_income.main_src=actual_sources.sid WHERE actual_income.rcpt = '" + mwamala + "' AND actual_income.council_code='" + GlobalVariablesClass.council_code + "' AND actual_income.region_code = '" + GlobalVariablesClass.region_code + "' AND actual_sources.council_code='" + GlobalVariablesClass.council_code + "' AND income_sources.council_code='" + GlobalVariablesClass.council_code + "' AND actual_income.deleted ='no'";
            cmd = new MySqlCommand(sql, connection);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, 0, 100, "actual_income");
            this.incomeResultsDataGridView.DataSource = ds.Tables[0];
            this.incomeResultsDataGridView.Columns["id"].Visible = false;
            this.incomeResultsDataGridView.Columns["raw_date"].HeaderText = "TAREHE";
            this.incomeResultsDataGridView.Columns["muda"].HeaderText = "MUDA";
            this.incomeResultsDataGridView.Columns["amount"].HeaderText = "KIASI";
            this.incomeResultsDataGridView.Columns["rcpt"].HeaderText = "MWAMALA";
            this.incomeResultsDataGridView.Columns["chq"].HeaderText = "HUNDI";
            this.incomeResultsDataGridView.Columns["slp"].HeaderText = "#MWAMALA BENKI";
            this.incomeResultsDataGridView.Columns["src_name"].HeaderText = "CHANZO";
            this.incomeResultsDataGridView.Columns["source"].HeaderText = "ENEO/MLIPA KODI";
            this.incomeResultsDataGridView.Columns["client"].HeaderText = "TOKA KWA";
            this.incomeResultsDataGridView.Columns["user"].HeaderText = "ALIYEWEKA";
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

        private double jumMakusanyo(string sql)
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
                    jumla = jumla + myReader.GetDouble(myReader.GetOrdinal("amount"));
                }
            }
            connection.Close();
            return jumla;
        }
        private double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
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
            if (user.Length==0 && source_id == 0)
            {
                loadData(page_number, count_per_page, next_offset, from_seconds, to_seconds);
            }
            else if (user.Length == 0 && source_id > 0)
            {
                loadDataChanzo(page_number, count_per_page, next_offset, from_seconds, to_seconds);
            }
            else if (user.Length > 0 && source_id == 0)
            {
                loadDataUser(page_number, count_per_page, next_offset, from_seconds, to_seconds);
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
            if (user.Length == 0 && source_id == 0)
            {
                loadData(page_number, count_per_page, next_offset, from_seconds, to_seconds);
            }
            else if (user.Length == 0 && source_id > 0)
            {
                loadDataChanzo(page_number, count_per_page, next_offset, from_seconds, to_seconds);
            }
            else if (user.Length > 0 && source_id == 0)
            {
                loadDataUser(page_number, count_per_page, next_offset, from_seconds, to_seconds);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Taarifazamapato.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.incomeResultsDataGridView, sfd.FileName);
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

        private void exportPDF_Click(object sender, EventArgs e)
        {
            //creating document header
            Paragraph para = new Paragraph(GlobalVariablesClass.council_name + "\n" + GlobalVariablesClass.daddress + "\nSIMU: " + GlobalVariablesClass.dphone + "\nNUKSHI: " + GlobalVariablesClass.dfax + "\nBARUA PEPE: " + GlobalVariablesClass.demail + "\n");
            para.Alignment = Element.ALIGN_CENTER;
            Paragraph para_space = new Paragraph("--------TAARIFA YA MAPATO---------\n");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph("KUANZIA " + fromDatePick.Value.Day.ToString() + "-" + fromDatePick.Value.Month.ToString() + "-" + fromDatePick.Value.Year.ToString() + " MPAKA " + toDatePick.Value.Day.ToString() + "-" + toDatePick.Value.Month.ToString() + "-" + toDatePick.Value.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            para_date.Font.Size = 10;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(incomeResultsDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 99;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 9);
            pdfTable.DefaultCell.Phrase = new Phrase() { Font = font };

            int[] widths = { 4, 7, 7, 12, 9, 8, 10, 14, 9, 9, 6 };
            pdfTable.SetWidths(widths);
            //Adding Header row
            foreach (DataGridViewColumn column in incomeResultsDataGridView.Columns)
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

            foreach (DataGridViewRow row in incomeResultsDataGridView.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "Mapato" + count_recordsexport + "ICRADocumentExported.pdf", FileMode.Create))
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
            MessageBox.Show("Document saved in: " + folderPath + "Mapato" + count_recordsexport + "ICRADocumentExported.pdf");
        }
    }
}

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
    public partial class OrodhaKwaTareheForm : Form
    {
        int count_recordsexport = 1;
        public static DateTime referenceDate = new DateTime(1970, 1, 1);
        static string connString    = GlobalVariablesClass.connString;
        MySqlConnection connection  = new MySqlConnection(connString);
        MySqlDataAdapter adapter    = new MySqlDataAdapter();
        DataSet ds                  = new DataSet();
        static int page_number = 0;
        static int count_per_page = 100;
        static int next_offset = 0;
        static int total_pages = 0;
        static int total_rows = 0;
        static double jumla_kodi = 0;
        public OrodhaKwaTareheForm()
        {
            InitializeComponent();
        }

        private void OrodhaKwaTareheForm_Load(object sender, EventArgs e)
        {

        }
        private void loadData(int pagenumber, int countperpage, int nextoffset, double from_date, double to_date)
        {
            Cursor.Current = Cursors.WaitCursor;
            ds.Clear();
            nextoffset = pagenumber * countperpage;
            page_number = pagenumber;
            MySqlCommand cmd;
            string sql = "SELECT id, source, slabel, phone_number, email_address, address, street,ward, plot_number, block_number, matumizi, rat_value, tax_amount  FROM income_sources WHERE tax_payer= 'Yes' AND reg_date >="+from_date+ " AND reg_date <="+to_date+" LIMIT " + countperpage + " OFFSET " + nextoffset;
            cmd = new MySqlCommand(sql, connection);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, 0, 100, "income_sources");
            this.walipaKodiByDateDataGridView.DataSource                            = ds.Tables[0];
            this.walipaKodiByDateDataGridView.Columns["id"].Visible                 = false;
            this.walipaKodiByDateDataGridView.Columns["source"].HeaderText          = "JINA";
            this.walipaKodiByDateDataGridView.Columns["slabel"].HeaderText          = "NAMBA YA USAJILI";
            this.walipaKodiByDateDataGridView.Columns["phone_number"].HeaderText    = "SIMU";
            this.walipaKodiByDateDataGridView.Columns["email_address"].HeaderText   = "BARUA PEPE";
            this.walipaKodiByDateDataGridView.Columns["address"].HeaderText         = "ANUANI";
            this.walipaKodiByDateDataGridView.Columns["street"].HeaderText          = "MTAA";
            this.walipaKodiByDateDataGridView.Columns["ward"].HeaderText            = "KATA";
            this.walipaKodiByDateDataGridView.Columns["plot_number"].HeaderText     = "NAMBA KIWANJA";
            this.walipaKodiByDateDataGridView.Columns["block_number"].HeaderText    = "KITALU";
            this.walipaKodiByDateDataGridView.Columns["rat_value"].HeaderText       = "THAMANI";
            this.walipaKodiByDateDataGridView.Columns["tax_amount"].HeaderText      = "KODI";
            this.walipaKodiByDateDataGridView.Columns["matumizi"].HeaderText        = "MATUMIZI";
            Cursor.Current = Cursors.Default;
        }
        public Double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DateTime from_date  = fromDateTimePicker.Value;
            DateTime to_date    = toDateTimePicker.Value;
            double from_seconds = toSeconds(from_date, referenceDate);
            double to_seconds   = toSeconds(to_date, referenceDate);
            loadData(page_number, count_per_page, next_offset, from_seconds, to_seconds);
            //calculate total pages
            string current_sql = "SELECT * FROM income_sources WHERE tax_payer='Yes' AND council_code='" + GlobalVariablesClass.council_code + "' AND reg_date >="+from_seconds+" AND reg_date <="+to_seconds;
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

        private void exportbtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Orodhawalipakodi.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.walipaKodiByDateDataGridView, sfd.FileName);
            }
        }

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            page_number = int.Parse(currentPageLabel.Text) + 1;
            if (page_number > total_pages)
            {
                page_number = 0;
                currentPageLabel.Text = (page_number + 1).ToString();
                backWardBtn.Enabled = false;
            }
            else
            {
                currentPageLabel.Text = (page_number).ToString();
                backWardBtn.Enabled = true;
            }
            DateTime from_date = fromDateTimePicker.Value;
            DateTime to_date = toDateTimePicker.Value;
            double from_seconds = toSeconds(from_date, referenceDate);
            double to_seconds = toSeconds(to_date, referenceDate);
            loadData(page_number, count_per_page, next_offset, from_seconds, to_seconds);
        }

        private void backWardBtn_Click(object sender, EventArgs e)
        {
            page_number = int.Parse(currentPageLabel.Text) - 1;
            if (page_number <= 0)
            {
                page_number = 0;
                backWardBtn.Enabled = false;
                currentPageLabel.Text = (1).ToString();
            }
            else
            {
                currentPageLabel.Text = (page_number).ToString();
            }
            DateTime from_date = fromDateTimePicker.Value;
            DateTime to_date = toDateTimePicker.Value;
            double from_seconds = toSeconds(from_date, referenceDate);
            double to_seconds = toSeconds(to_date, referenceDate);
            loadData(page_number, count_per_page, next_offset, from_seconds, to_seconds);
        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            //creating document header
            Paragraph para = new Paragraph(GlobalVariablesClass.council_name + "\n" + GlobalVariablesClass.daddress + "\nSIMU: " + GlobalVariablesClass.dphone + "\nNUKSHI: " + GlobalVariablesClass.dfax + "\nBARUA PEPE: " + GlobalVariablesClass.demail + "\n");
            para.Alignment = Element.ALIGN_CENTER;
            Paragraph para_space = new Paragraph("--------TAARIFA ZA USAJILI WALIPA KODI---------\n");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph("KUANZIA " + fromDateTimePicker.Value.Day.ToString() + "-" + fromDateTimePicker.Value.Month.ToString() + "-" + fromDateTimePicker.Value.Year.ToString() + " MPAKA " + toDateTimePicker.Value.Day.ToString() + "-" + toDateTimePicker.Value.Month.ToString() + "-" + toDateTimePicker.Value.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            para_date.Font.Size = 10;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(walipaKodiByDateDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 99;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 9);
            pdfTable.DefaultCell.Phrase = new Phrase() { Font = font };

            int[] widths = { 4, 7, 7, 8, 9, 8, 7, 7, 9, 9, 6, 7, 7 };
            pdfTable.SetWidths(widths);
            //Adding Header row
            foreach (DataGridViewColumn column in walipaKodiByDateDataGridView.Columns)
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

            foreach (DataGridViewRow row in walipaKodiByDateDataGridView.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "UsajiliWalipakodi" + count_recordsexport + "ICRADocumentExported.pdf", FileMode.Create))
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
            MessageBox.Show("Document save in: " + folderPath + "UsajiliWalipakodi" + count_recordsexport + "ICRADocumentExported.pdf");
        }
    }
}

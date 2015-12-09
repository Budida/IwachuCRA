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
    public partial class TaxPayersWakalaReportsForm : Form
    {
        int count_recordsexport  = 1;
        static string connString = GlobalVariablesClass.connString;
        MySqlConnection connection = new MySqlConnection(connString);
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        
        static double from_seconds      = 0;
        static double to_seconds        = 0;
        static string wakala_taxpayer   = "";
        public TaxPayersWakalaReportsForm()
        {
            InitializeComponent();
        }

        private void TaxPayersWakalaReportsForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            wakala_taxpayer = nambaBox.Text;
            DateTime from_Date = fromDatePick.Value;
            DateTime to_Date = toDatePick.Value;
            from_seconds    = toSeconds(from_Date, GlobalVariablesClass.referenceDate);
            to_seconds      = toSeconds(to_Date, GlobalVariablesClass.referenceDate);
            if (wakala_taxpayer.Length > 0)
            {
                loadData(from_seconds, to_seconds);
            }
            else
            {
                MessageBox.Show("Weka namba ya Mlipa kodi au Eneo analosimamia wakala!");
            }
        }
        private double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }
        private void loadData(double from_seconds, double to_seconds)
        {
            Cursor.Current = Cursors.WaitCursor;
            ds.Clear();
            MySqlCommand cmd;
            string sql = "SELECT actual_income.id, raw_date, muda, amount, rcpt, chq, slp,  src_name, source, client, user  FROM actual_income JOIN income_sources ON actual_income.branch_src=income_sources.slabel JOIN actual_sources ON actual_income.main_src=actual_sources.sid WHERE actual_income.date >=" + from_seconds + " AND actual_income.date <=" + to_seconds + " AND actual_income.branch_src='"+wakala_taxpayer+"' AND actual_income.council_code='" + GlobalVariablesClass.council_code + "' AND actual_income.region_code = '" + GlobalVariablesClass.region_code + "' AND  actual_sources.council_code='" + GlobalVariablesClass.council_code + "' AND income_sources.council_code='" + GlobalVariablesClass.council_code + "' AND actual_income.deleted ='no'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Ulipajiwawalipakodina mawakala.xls";
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
            Paragraph para_space = new Paragraph("--------ULIPAJI WA MAWAKALA NA WALIPA KODI---------\n");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph(DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(incomeResultsDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;

            int[] widths = { 5, 9, 9, 9, 9, 9, 9, 10, 8, 8, 6 };
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
            using (FileStream stream = new FileStream(folderPath + "UlipajiMawakalaWalipakodi" + count_recordsexport + "ICRADocumentExported.pdf", FileMode.Create))
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
            MessageBox.Show("Document save in: " + folderPath + "UlipajiMawakalaWalipakodi" + count_recordsexport + "ICRADocumentExported.pdf");
        }
    }
}

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
    public partial class OrodhaYaMawakalaForm : Form
    {
        public static DateTime referenceDate        = new DateTime(1970, 1, 1);
        public static string wakala_name            = "";
        public static Double from_seconds           = 0;
        public static Double to_seconds             = 0;
        public static int wakala_id                 = 0;
        public static string wakalafullname         = "";
        public static string wakalaemail            = "";
        public static string wakala_phone           = "";
        public static DateTime from_date            = DateTime.Now.Date;
        public static DateTime to_date              = DateTime.Now.Date;
        public OrodhaYaMawakalaForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //select wakala list
            DateTime from_date  = fromDatePicker.Value;
            DateTime to_date    = toDatePicker.Value;
            Double from_seconds = toSeconds(from_date, referenceDate);
            Double to_seconds   = toSeconds(to_date, referenceDate);
            loadMawakalaList(from_seconds, to_seconds);
        }

        public Double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }

        private void loadMawakalaList(Double startdate, Double enddate)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString))
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, fullname, username, simu, email FROM wakala WHERE wakala.council_code='" + GlobalVariablesClass.council_code + "' AND wakala.region_code='" + GlobalVariablesClass.region_code + "' AND wakala.start_date="+startdate+" AND wakala.end_date="+enddate+"";
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            this.orodhaWakalaDataGridView.Visible = true;
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            this.orodhaWakalaDataGridView.DataSource = dt;

                            this.orodhaWakalaDataGridView.Columns["fullname"].HeaderText = "Jina La Wakala";
                            this.orodhaWakalaDataGridView.Columns["username"].HeaderText = "Jina La Kuingilia";
                            this.orodhaWakalaDataGridView.Columns["simu"].HeaderText = "Simu";
                            this.orodhaWakalaDataGridView.Columns["email"].HeaderText = "Barua Pepe";
                            this.orodhaWakalaDataGridView.Columns[0].Visible = false;
                           
                            if (null != this.orodhaWakalaDataGridView)
                            {
                                foreach (DataGridViewRow r in this.orodhaWakalaDataGridView.Rows)
                                {
                                    this.orodhaWakalaDataGridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                                }
                            }
                        }
                        else
                        {
                            this.orodhaWakalaDataGridView.Visible = false;
                            MessageBox.Show("Hakuna mawakala kwa kipindi ulichochagua!");
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
            LoadSerial(this.orodhaWakalaDataGridView);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.orodhaWakalaDataGridView.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.xls)|*.xls";
                sfd.FileName = "Orodhamawakala.xls";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    //ToCsV(dataGridView1, @"c:\export.xls");
                    ToCsV(this.orodhaWakalaDataGridView, sfd.FileName);
                }
            }
            else
            {
                MessageBox.Show("Hakuna orodha ya mawakala!");
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

        private void button2_Click(object sender, EventArgs e)
        {
            //edit wakala details
            if (this.orodhaWakalaDataGridView.Rows.Count > 0)
            {
                int i;
                i                   = this.orodhaWakalaDataGridView.SelectedCells[0].RowIndex;
                wakala_id           = int.Parse(this.orodhaWakalaDataGridView.Rows[i].Cells[0].Value.ToString());
                wakalafullname      = this.orodhaWakalaDataGridView.Rows[i].Cells[1].Value.ToString();
                wakala_name         = this.orodhaWakalaDataGridView.Rows[i].Cells[2].Value.ToString();
                wakala_phone        = this.orodhaWakalaDataGridView.Rows[i].Cells[3].Value.ToString();
                wakalaemail         = this.orodhaWakalaDataGridView.Rows[i].Cells[3].Value.ToString();
                from_date           = fromDatePicker.Value;
                to_date             = toDatePicker.Value;
                EditWakalaForm frm = new EditWakalaForm();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hakuna taarifa ya kubadili!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.orodhaWakalaDataGridView.Rows.Count >0)
            {
                int i;
                i                   = this.orodhaWakalaDataGridView.SelectedCells[0].RowIndex;
                wakala_name         = this.orodhaWakalaDataGridView.Rows[i].Cells[2].Value.ToString();
                DateTime from_date  = fromDatePicker.Value;
                DateTime to_date    = toDatePicker.Value;
                Double fromseconds  = toSeconds(from_date, referenceDate);
                Double toseconds    = toSeconds(to_date, referenceDate);
                from_seconds        = fromseconds;
                to_seconds          = toseconds;
                WakalaSourcesForm frm = new WakalaSourcesForm();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Hakuna orodha ya mawakala!");
            }
        }

        private void banWakala_Click(object sender, EventArgs e)
        {
            MessageBox.Show("");
        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            //creating document header
            Paragraph para = new Paragraph(GlobalVariablesClass.council_name + "\n" + GlobalVariablesClass.daddress + "\nSIMU: " + GlobalVariablesClass.dphone + "\nNUKSHI: " + GlobalVariablesClass.dfax + "\nBARUA PEPE: " + GlobalVariablesClass.demail + "\n");
            para.Alignment = Element.ALIGN_CENTER;
            Paragraph para_space = new Paragraph("--------ORODHA YA MAWAKALA---------");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph("KUANZIA "+fromDatePicker.Value.Day.ToString() + "-" + fromDatePicker.Value.Month.ToString() + "-" + fromDatePicker.Value.Year.ToString()+" MPAKA "+ toDatePicker.Value.Day.ToString() + "-" + toDatePicker.Value.Month.ToString() + "-" + toDatePicker.Value.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable               = new PdfPTable(orodhaWakalaDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding     = 3;
            pdfTable.WidthPercentage         = 100;
            pdfTable.HorizontalAlignment     = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;

            int[] widths = { 5, 19, 19, 19, 19 };
            pdfTable.SetWidths(widths);
            //Adding Header row
            foreach (DataGridViewColumn column in orodhaWakalaDataGridView.Columns)
            {
                if (column.Index == 0)
                {
                    PdfPCell cell = new PdfPCell(new Phrase("SN"));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }
                if (column.Index != 0)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }

            }

            //Adding DataRow
            int count_rows = 1;
            foreach (DataGridViewRow row in orodhaWakalaDataGridView.Rows)
            {

                foreach (DataGridViewCell cell in row.Cells)
                {

                    if (cell.ColumnIndex == 0)
                    {
                        pdfTable.AddCell(count_rows.ToString());
                    }
                    if (cell.ColumnIndex != 0)
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }

                }
                count_rows++;
            }

            //Exporting to PDF
            string folderPath = "C:\\IWACHUPDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "MawakalaICRADocumentExported.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 15f, 10f, 2f);
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
            MessageBox.Show("Document save in: C:\\IWACHUPDFs\\MawakalaICRADocumentExported.pdf");
        }
    }
}

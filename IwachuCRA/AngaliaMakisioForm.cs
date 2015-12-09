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
    public partial class AngaliaMakisioForm : Form
    {
        int count_recordsexport = 1;
        public static DateTime referenceDate = new DateTime(1970, 1, 1);
        string connectionString = GlobalVariablesClass.connString;
        static int recordid = 0;
        public AngaliaMakisioForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime start_date = fromDatePick.Value;
            DateTime end_date   = toDatePick.Value;
            double from_seconds = toSeconds(start_date, referenceDate);
            double to_seconds   = toSeconds(end_date, referenceDate);
            loadKata(from_seconds, to_seconds);
        }

        private double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }
        private void loadKata(double from_seconds, double to_seconds)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString))
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT makisio_mapato.id, source, makisio_mapato.amount FROM makisio_mapato JOIN income_sources ON makisio_mapato.source_id=income_sources.id WHERE makisio_mapato.council_code='" + GlobalVariablesClass.council_code + "' AND makisio_mapato.region_code='" + GlobalVariablesClass.region_code + "' AND makisio_mapato.start_date="+from_seconds+ " AND makisio_mapato.end_date="+to_seconds;
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            this.makisioDataGridView.Visible = true;
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            this.makisioDataGridView.DataSource = dt;

                            this.makisioDataGridView.Columns["source"].HeaderText        = "CHANZO(ENEO)";
                            this.makisioDataGridView.Columns["amount"].HeaderText           = "KIASI";
                            this.makisioDataGridView.Columns[0].Visible                     = false;


                            if (null != this.makisioDataGridView)
                            {
                                foreach (DataGridViewRow r in this.makisioDataGridView.Rows)
                                {
                                    this.makisioDataGridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                                }
                            }
                        }
                        else
                        {
                            this.makisioDataGridView.Visible = false;
                            MessageBox.Show("Hakuna makisio yaliyopatiakana!");
                        }
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime start_date = fromDatePick.Value;
            DateTime end_date = toDatePick.Value;
            double from_seconds = toSeconds(start_date, referenceDate);
            double to_seconds = toSeconds(end_date, referenceDate);
            loadKata(from_seconds, to_seconds);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            i = makisioDataGridView.SelectedCells[0].RowIndex;
            recordid            = int.Parse(this.makisioDataGridView.Rows[i].Cells[0].Value.ToString());
            amountTextBox.Text  = this.makisioDataGridView.Rows[i].Cells[2].Value.ToString();
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            double outvalue;
            if(recordid > 0 && Double.TryParse(amountTextBox.Text, out outvalue))
            {
                MySqlConnection connection = new MySqlConnection(connectionString);
                MySqlCommand cmd;
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "UPDATE makisio_mapato SET amount ='"+Double.Parse(amountTextBox.Text) +"' WHERE id="+recordid;
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Umefanikiwa kubadili!");
                        amountTextBox.Text = "";
                        recordid = 0;
                        connection.Close();
                    }
                    else
                    {
                        connection.Close();
                        MessageBox.Show("Imeshindikana kubadili!");
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
                MessageBox.Show("Click Badili");
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

        private void printKataBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd  = new SaveFileDialog();
            sfd.Filter          = "Excel Documents (*.xls)|*.xls";
            sfd.FileName        = "Makisio"+fromDatePick.Value.ToString()+"-"+toDatePick.Value.ToString()+"excel.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.makisioDataGridView, sfd.FileName);
            }
        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            //creating document header
            Paragraph para = new Paragraph(GlobalVariablesClass.council_name + "\n" + GlobalVariablesClass.daddress + "\nSIMU: " + GlobalVariablesClass.dphone + "\nNUKSHI: " + GlobalVariablesClass.dfax + "\nBARUA PEPE: " + GlobalVariablesClass.demail + "\n");
            para.Alignment = Element.ALIGN_CENTER;
            Paragraph para_space = new Paragraph("--------MAKISIO---------\n");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph("KUANZIA "+fromDatePick.Value.Day.ToString() + "-" + fromDatePick.Value.Month.ToString() + "-" + fromDatePick.Value.Year.ToString()+" MPAKA "+ toDatePick.Value.Day.ToString() + "-" + toDatePick.Value.Month.ToString() + "-" + toDatePick.Value.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            para_date.Font.Size = 10;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(makisioDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding        = 3;
            pdfTable.WidthPercentage            = 100;
            pdfTable.HorizontalAlignment        = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth    = 1;
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font font           = new iTextSharp.text.Font(bf, 9);
            pdfTable.DefaultCell.Phrase         = new Phrase() { Font = font };

            int[] widths = { 5, 45, 40 };
            pdfTable.SetWidths(widths);

            //Adding Header row
            foreach (DataGridViewColumn column in makisioDataGridView.Columns)
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

            foreach (DataGridViewRow row in makisioDataGridView.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "Makisio" + count_recordsexport + "ICRADocumentExported.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                //Document pdfDoc = new Document(new RectangleReadOnly(842, 595), 10f, 10f, 10f, 0f);
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
            MessageBox.Show("Document save in: " + folderPath + "Makisio" + count_recordsexport + "ICRADocumentExported.pdf");
        }
    }
}

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
    public partial class LejaYaMakusanyoForm : Form
    {
        int count_recordsexport = 1;
        static string connString    = GlobalVariablesClass.connString;
        MySqlConnection connection  = new MySqlConnection(connString);
        public LejaYaMakusanyoForm()
        {
            InitializeComponent();
            
        }

        private void LejaYaMakusanyoForm_Load(object sender, EventArgs e)
        {
            FillDropDownListEneo("SELECT slabel, source FROM income_sources WHERE council_code='" + GlobalVariablesClass.council_code + "' AND tax_payer='No' AND region_code='" + GlobalVariablesClass.region_code + "'", eneoDropDown);
            eneoDropDown.SelectedValue = "";
        }
        private double getSumCollectionDay(string slabel, double second_s)
        {
            double result = 0;
            connection.Open();
            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT SUM(amount) FROM income WHERE s_label=" + slabel + " AND date=" + second_s + " AND council_code='"+GlobalVariablesClass.council_code+"' AND deleted='no'";
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        result = Double.Parse(myReader.GetString(0));
                    }
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                connection.Close();
            }

            return result;
        }
        public static void FillDropDownListEneo(string Query, System.Windows.Forms.ComboBox DropDownName)
        {
            Cursor.Current = Cursors.WaitCursor;
            using (var cn = new MySqlConnection(GlobalVariablesClass.connString))
            {
                cn.Open();
                DataTable dt = new DataTable();
                try
                {
                    MySqlCommand cmd = new MySqlCommand(Query, cn);
                    MySqlDataReader myReader = cmd.ExecuteReader();
                    dt.Load(myReader);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    return;
                }
                DropDownName.DataSource = dt;
                dt.Rows.Add("", "");
                DropDownName.ValueMember = "slabel";
                DropDownName.DisplayMember = "source";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }
        private int GetTotalMonthsFrom(DateTime dt1, DateTime dt2)
        {
            DateTime earlyDate = (dt1 > dt2) ? dt2.Date : dt1.Date;
            DateTime lateDate = (dt1 > dt2) ? dt1.Date : dt2.Date;

            // Start with 1 month's difference and keep incrementing
            // until we overshoot the late date
            int monthsDiff = 1;
            while (earlyDate.AddMonths(monthsDiff) <= lateDate)
            {
                monthsDiff++;
            }

            return monthsDiff;
        }
        private void angaliaBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string slabel = eneoDropDown.SelectedValue.ToString();
            DateTime from_date = fromDatePcik.Value;
            DateTime to_date = toDatePick.Value;
            int months = GetTotalMonthsFrom(from_date, to_date);
            if (months > 0 && slabel.Length > 0 && months <=12)
            {
                double total = 0;
                int count = 1;
                lejaDataGridView.Rows.Clear();
                for (int i = 0; i < months; i++)
                {
                    double amount_permonth = 0;
                    DateTime next_month = from_date.AddMonths(i);
                    int lastDayOfMonth = DateTime.DaysInMonth(next_month.Year, next_month.Month);
                    for(int i_i=1; i_i< lastDayOfMonth; i_i++)
                    {
                        double seconds = toSeconds(new DateTime(next_month.Year, next_month.Month, i_i), GlobalVariablesClass.referenceDate);
                        amount_permonth += getSumCollectionDay(slabel, seconds);
                    }
                    total += amount_permonth;
                    lejaDataGridView.ColumnCount = 3;
                    lejaDataGridView.Columns[0].Name = "SN";
                    lejaDataGridView.Columns[1].Name = "MWEZI";
                    lejaDataGridView.Columns[2].Name = "KIASI";
                    lejaDataGridView.Columns[0].Width = 50;
                    string[] row = new string[] { count.ToString(), lastDayOfMonth.ToString() + "-" + next_month.Month + "-" + next_month.Year, amount_permonth.ToString() };
                    lejaDataGridView.Rows.Add(row);
                    count++;
                }
                string[] row_final = new string[] { "", "JUMLA", total.ToString() };
                lejaDataGridView.Rows.Add(row_final);
            }
            else
            {
                MessageBox.Show("Chagua eneo idadi ya miezi iwe 12 au pungufu!");
            }
            Cursor.Current = Cursors.Default;
        }
        private double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }
        private void exportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Leja ya makusanyo.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.lejaDataGridView, sfd.FileName);
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
            Paragraph para_space = new Paragraph("--------LEJA YA MAKUSANYO---------\n");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph("KUANZIA " + fromDatePcik.Value.Day.ToString() + "-" + fromDatePcik.Value.Month.ToString() + "-" + fromDatePcik.Value.Year.ToString() + " MPAKA " + toDatePick.Value.Day.ToString() + "-" + toDatePick.Value.Month.ToString() + "-" + toDatePick.Value.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            para_date.Font.Size = 10;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(lejaDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 99;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 9);
            pdfTable.DefaultCell.Phrase = new Phrase() { Font = font };

            int[] widths = { 5, 45, 40 };
            pdfTable.SetWidths(widths);
            //Adding Header row
            foreach (DataGridViewColumn column in lejaDataGridView.Columns)
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

            foreach (DataGridViewRow row in lejaDataGridView.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "LejaMakusanyo" + count_recordsexport + "ICRADocumentExported.pdf", FileMode.Create))
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
            MessageBox.Show("Document saved in: " + folderPath + "LejaMakusanyo" + count_recordsexport + "ICRADocumentExported.pdf");
        }
    }
}

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
    public partial class MakusanyoKwaMwakaWaFedhaForm : Form
    {
        int count_recordsexport = 1;
        static string connString = GlobalVariablesClass.connString;
        MySqlConnection connection = new MySqlConnection(connString);
        static double from_seconds  = 0;
        static double to_seconds    = 0;
        static double startyear_seconds = 0;
        static double endyear_seconds = 0;
        
        public MakusanyoKwaMwakaWaFedhaForm()
        {
            InitializeComponent();
        }

        private void angaliaBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current       = Cursors.WaitCursor;
            DateTime from_Date   = fromDatePick.Value;
            DateTime to_Date     = toDatePick.Value;
            DateTime start_year  = startYearPick.Value;
            DateTime end_year    = endYearPick.Value;
            DateTime from_date_less = from_Date.AddDays(-1);
            from_seconds         = toSeconds(from_Date, GlobalVariablesClass.referenceDate);
            to_seconds           = toSeconds(to_Date, GlobalVariablesClass.referenceDate);
            startyear_seconds    = toSeconds(start_year, GlobalVariablesClass.referenceDate);
            endyear_seconds      = toSeconds(end_year, GlobalVariablesClass.referenceDate);
            double jumla_all        = 0;
            double jumla_one        = 0;
            double jumla_two        = 0;
            double jumla_makisio    = 0;
            MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM income_sources WHERE tax_payer='No' AND council_code='" + GlobalVariablesClass.council_code + "'";
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.HasRows)
                {
                    int count = 1;
                    makusanyoDataGridView.Rows.Clear();
                    double sum_persource_one = 0;
                    double sum_persource_two = 0;
                    double makisio          = 0;
                    makusanyoDataGridView.ColumnCount = 7;
                    makusanyoDataGridView.Columns[0].Name = "SN";
                    makusanyoDataGridView.Columns[1].Name = "ENEO";
                    makusanyoDataGridView.Columns[2].Name = "MAKISIO";
                    makusanyoDataGridView.Columns[3].Name = "MAKUSANYO "+ start_year.Day.ToString()+"-"+ start_year.Month.ToString()+"-"+ start_year.Year.ToString()+" | "+ from_date_less.Day.ToString() + "-" + from_date_less.Month.ToString() + "-" + from_date_less.Year.ToString();
                    makusanyoDataGridView.Columns[4].Name = "MAKUSANYO " + from_Date.Day.ToString() + "-" + from_Date.Month.ToString() + "-" + from_Date.Year.ToString() + " | " + to_Date.Day.ToString() + "-" + to_Date.Month.ToString() + "-" + to_Date.Year.ToString();
                    makusanyoDataGridView.Columns[5].Name = "JUMLA";
                    makusanyoDataGridView.Columns[6].Name = "ASILIMIA%";
                    makusanyoDataGridView.Columns[0].Width = 50;

                    while (myReader.Read())
                    {
                        double row_total = 0;
                        double percent  = 0;
                        string percent_value = "";
                        sum_persource_one = jumMakusanyoone(myReader.GetInt32(myReader.GetOrdinal("id")), startyear_seconds, from_seconds);
                        sum_persource_two = jumMakusanyo(myReader.GetInt32(myReader.GetOrdinal("id")), from_seconds, to_seconds);
                        jumla_one = jumla_one + sum_persource_one;
                        jumla_two = jumla_two + sum_persource_two;
                        row_total = sum_persource_one + sum_persource_two;
                        jumla_all += row_total;
                        makisio = jumlaMakisio(myReader.GetInt32(myReader.GetOrdinal("id")));
                        if(makisio > 0) { 
                            percent = (row_total / makisio)*100;
                        }
                        if (percent > 0)
                        {
                            percent_value = percent.ToString("#.##");
                        }
                        else
                        {
                            percent_value = "0";
                        }
                        jumla_makisio += makisio;
                        string[] row = new string[] { count.ToString(), myReader.GetString(myReader.GetOrdinal("source")), makisio.ToString(), sum_persource_one.ToString(), sum_persource_two.ToString(), row_total.ToString(), percent_value };
                        makusanyoDataGridView.Rows.Add(row);
                        count++;
                    }
                    string total_percent_value = "";
                    double final_percent = 0;
                    if (jumla_makisio > 0)
                    {
                        final_percent = (jumla_all / jumla_makisio)*100;
                    }
                    if (final_percent > 0)
                    {
                        total_percent_value = final_percent.ToString("#.##");
                    }
                    else
                    {
                        total_percent_value = "0";
                    }
                    string[] row_final = new string[] { "", "JUMLA", String.Format("{0:0,0.00}", jumla_makisio).ToString(), String.Format("{0:0,0.00}", jumla_one).ToString(), String.Format("{0:0,0.00}", jumla_two).ToString(), String.Format("{0:0,0.00}", jumla_all).ToString(), total_percent_value };
                    makusanyoDataGridView.Rows.Add(row_final);
                   
                }
                else
                {
                    MessageBox.Show("Hakuna maeneo yaliysajiliwa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tatizo: " + ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        private double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }
        private double jumMakusanyo(int source_id, double fromdate, double todate)
        {
            string sql = "SELECT amount FROM income WHERE source_id=" + source_id + " AND date >= " + fromdate + " AND date <= " + todate + " AND income.council_code = '" + GlobalVariablesClass.council_code + "' AND income.region_code = '" + GlobalVariablesClass.region_code + "' AND deleted = 'no'";
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
        private double jumMakusanyoone(int source_id, double fromdate, double todate)
        {
            string sql = "SELECT amount FROM income WHERE source_id=" + source_id + " AND date >= " + fromdate + " AND date < " + todate + " AND income.council_code = '" + GlobalVariablesClass.council_code + "' AND income.region_code = '" + GlobalVariablesClass.region_code + "' AND deleted = 'no'";
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
        private double jumlaMakisio(int source_id)
        {
            string sql = "SELECT amount FROM makisio_mapato WHERE source_id=" + source_id + " AND start_date = " + startyear_seconds + " AND end_date = " + endyear_seconds + " AND makisio_mapato.council_code = '" + GlobalVariablesClass.council_code + "' AND makisio_mapato.region_code = '" + GlobalVariablesClass.region_code + "'";
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

        private void exportbtn_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Taarifazamakusanyokwamawkawafedha.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.makusanyoDataGridView, sfd.FileName);
            }
        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            //creating document header
            Paragraph para = new Paragraph(GlobalVariablesClass.council_name + "\n" + GlobalVariablesClass.daddress + "\nSIMU: " + GlobalVariablesClass.dphone + "\nNUKSHI: " + GlobalVariablesClass.dfax + "\nBARUA PEPE: " + GlobalVariablesClass.demail + "\n");
            para.Alignment = Element.ALIGN_CENTER;
            Paragraph para_space = new Paragraph("--------MAKUSANYO YA MAPATO MWAKA WA FEDHA---------\n");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph("KUANZIA " + fromDatePick.Value.Day.ToString() + "-" + fromDatePick.Value.Month.ToString() + "-" + fromDatePick.Value.Year.ToString() + " MPAKA " + toDatePick.Value.Day.ToString() + "-" + toDatePick.Value.Month.ToString() + "-" + toDatePick.Value.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            para_date.Font.Size = 10;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(makusanyoDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding = 3;
            pdfTable.WidthPercentage = 100;
            pdfTable.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 9);
            pdfTable.DefaultCell.Phrase = new Phrase() { Font = font };

            int[] widths = { 6, 22, 16, 13, 13, 16, 14 };
            pdfTable.SetWidths(widths);
            //Adding Header row
            foreach (DataGridViewColumn column in makusanyoDataGridView.Columns)
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

            foreach (DataGridViewRow row in makusanyoDataGridView.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "Makusanyokwamwaka" + count_recordsexport + "ICRADocumentExported.pdf", FileMode.Create))
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
            MessageBox.Show("Document saved in: " + folderPath + "Makusanyokwamwaka" + count_recordsexport + "ICRADocumentExported.pdf");
        }
    }
}

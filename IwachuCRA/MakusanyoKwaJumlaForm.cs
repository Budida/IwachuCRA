﻿using MySql.Data.MySqlClient;
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
    public partial class MakusanyoKwaJumlaForm : Form
    {
        int count_recordsexport     = 1;
        static double from_seconds  = 0;
        static double to_seconds    = 0;
        double jumla_all            = 0;
        static string connString    = GlobalVariablesClass.connString;
        MySqlConnection connection  = new MySqlConnection(connString);
        public MakusanyoKwaJumlaForm()
        {
            InitializeComponent();
        }

        private void angaliaBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            jumla_all = 0;
            DateTime from_Date  = fromDatePick.Value;
            DateTime to_Date    = toDatePick.Value;
            from_seconds        = toSeconds(from_Date, GlobalVariablesClass.referenceDate);
            to_seconds          = toSeconds(to_Date, GlobalVariablesClass.referenceDate);
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
                    double sum_persource = 0;
                    makusanyoDataGridView.ColumnCount       = 3;
                    makusanyoDataGridView.Columns[0].Name   = "SN";
                    makusanyoDataGridView.Columns[1].Name   = "ENEO";
                    makusanyoDataGridView.Columns[2].Name   = "KIASI";
                    makusanyoDataGridView.Columns[0].Width  = 50;
                    
                    while (myReader.Read())
                    {
                        sum_persource = jumMakusanyo(myReader.GetInt32(myReader.GetOrdinal("id")));
                        jumla_all = jumla_all + sum_persource;
                        string[] row = new string[] { count.ToString(), myReader.GetString(myReader.GetOrdinal("source")), sum_persource .ToString()};
                        makusanyoDataGridView.Rows.Add(row);
                        count++;
                    }
                    jumlaLabel.Text = "JUMLA:" + String.Format("{0:0,0.00}", jumla_all).ToString();
                }
                else
                {
                    MessageBox.Show("Hakuna maeneo yaliysajiliwa!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tatizo: "+ex.Message);
            }
            Cursor.Current = Cursors.Default;
        }
        private double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }
        private double jumMakusanyo(int source_id)
        {
            string sql = "SELECT amount FROM income WHERE source_id="+source_id+" AND date >= " + from_seconds + " AND date <= " + to_seconds + " AND income.council_code = '" + GlobalVariablesClass.council_code + "' AND income.region_code = '" + GlobalVariablesClass.region_code + "' AND deleted = 'no'";
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

        private void exportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Taarifazamakusanyo.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.makusanyoDataGridView, sfd.FileName);
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
            Paragraph para_space = new Paragraph("--------MAKUSANYO KWA JUMLA---------\n");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph("KUANZIA " + fromDatePick.Value.Day.ToString() + "-" + fromDatePick.Value.Month.ToString() + "-" + fromDatePick.Value.Year.ToString() + " MPAKA " + toDatePick.Value.Day.ToString() + "-" + toDatePick.Value.Month.ToString() + "-" + toDatePick.Value.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            para_date.Font.Size = 10;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(makusanyoDataGridView.ColumnCount);
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
            using (FileStream stream = new FileStream(folderPath + "Makusanyokwajumla" + count_recordsexport + "ICRADocumentExported.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
               // Document pdfDoc = new Document(new RectangleReadOnly(842, 595), 10f, 10f, 10f, 0f);
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
            MessageBox.Show("Document save in: " + folderPath + "Makusanyokwajumla" + count_recordsexport + "ICRADocumentExported.pdf");
        }
    }
    
}

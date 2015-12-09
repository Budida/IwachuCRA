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
    public partial class OrodhaYaMaeneoForm : Form
    {
        static int count_recordsexport = 1;
        public static int eneo_id           = 0;
        public static string jinaEneo       = "";
        public static string nambaEneo      = "";
        public static string max_amount     = "";
        public static string wardname       = "";
        public static string streetname     = "";
        public static string src_name       = "";
        public static int main_source_id    = 0;
        public OrodhaYaMaeneoForm()
        {
            InitializeComponent();
        }

        private void OrodhaYaMaeneoForm_Load(object sender, EventArgs e)
        {
            loadMaeneoList();
        }
        private void LoadSerial(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[row.Index].HeaderCell.Value = string.Format("{0}  ", row.Index + 1).ToString();
                row.Height = 25;
            }
        }
        private void orodhaMaeneoDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadSerial(this.orodhaMaeneoDataGridView);
        }
        private void loadMaeneoList()
        {
            using (MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString))
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, source, slabel, max_amount, src_name, street, ward, msrc_id   FROM income_sources JOIN actual_sources ON income_sources.msrc_id = actual_sources.sid WHERE income_sources.council_code='" + GlobalVariablesClass.council_code + "' AND income_sources.region_code='" + GlobalVariablesClass.region_code + "' AND income_sources.tax_payer='No'";
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            this.orodhaMaeneoDataGridView.Visible = true;
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            this.orodhaMaeneoDataGridView.DataSource = dt;

                            this.orodhaMaeneoDataGridView.Columns["source"].HeaderText      = "Jina La Eneo";
                            this.orodhaMaeneoDataGridView.Columns["slabel"].HeaderText      = "Namba Ya Eneo";
                            this.orodhaMaeneoDataGridView.Columns["src_name"].HeaderText    = "Chanzo Kikuu";
                            this.orodhaMaeneoDataGridView.Columns["street"].HeaderText      = "Mtaa";
                            this.orodhaMaeneoDataGridView.Columns["ward"].HeaderText        = "Kata";
                            this.orodhaMaeneoDataGridView.Columns["max_amount"].HeaderText  = "Kiwango Cha Mwisho";
                            this.orodhaMaeneoDataGridView.Columns[0].Visible = false;
                            this.orodhaMaeneoDataGridView.Columns[2].Visible = false;
                            this.orodhaMaeneoDataGridView.Columns[7].Visible = false;

                            if (null != this.orodhaMaeneoDataGridView)
                            {
                                foreach (DataGridViewRow r in this.orodhaMaeneoDataGridView.Rows)
                                {
                                    this.orodhaMaeneoDataGridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                                }
                            }
                        }
                        else
                        {
                            this.orodhaMaeneoDataGridView.Visible = false;
                            MessageBox.Show("Hakuna mitaa iliyosajiliwa!");
                        }
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadMaeneoList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Orodhamaeneo.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.orodhaMaeneoDataGridView, sfd.FileName);
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

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
            i               = this.orodhaMaeneoDataGridView.SelectedCells[0].RowIndex;
            eneo_id         = int.Parse(this.orodhaMaeneoDataGridView.Rows[i].Cells[0].Value.ToString());
            jinaEneo        = this.orodhaMaeneoDataGridView.Rows[i].Cells[1].Value.ToString();
            nambaEneo       = this.orodhaMaeneoDataGridView.Rows[i].Cells[2].Value.ToString();
            max_amount      = this.orodhaMaeneoDataGridView.Rows[i].Cells[3].Value.ToString();
            wardname        = this.orodhaMaeneoDataGridView.Rows[i].Cells[6].Value.ToString();
            streetname      = this.orodhaMaeneoDataGridView.Rows[i].Cells[5].Value.ToString();
            src_name        = this.orodhaMaeneoDataGridView.Rows[i].Cells[4].Value.ToString();
            main_source_id  = int.Parse(this.orodhaMaeneoDataGridView.Rows[i].Cells[7].Value.ToString());
            SajiliEneoForm frm = new SajiliEneoForm();
            frm.ShowDialog();
        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            //creating document header
            Paragraph para = new Paragraph(GlobalVariablesClass.council_name + "\n" + GlobalVariablesClass.daddress + "\nSIMU: " + GlobalVariablesClass.dphone + "\nNUKSHI: " + GlobalVariablesClass.dfax + "\nBARUA PEPE: " + GlobalVariablesClass.demail + "\n");
            para.Alignment = Element.ALIGN_CENTER;
            Paragraph para_space = new Paragraph("--------ORODHA YA MAENEO---------");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph(DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(orodhaMaeneoDataGridView.ColumnCount-1);
            pdfTable.DefaultCell.Padding    = 3;
            pdfTable.WidthPercentage        = 99;
            pdfTable.HorizontalAlignment    = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;

            int[] widths = { 4, 16, 16, 16, 16, 16, 16 };
            pdfTable.SetWidths(widths);
            //Adding Header row
            foreach (DataGridViewColumn column in orodhaMaeneoDataGridView.Columns)
            {
                if(column.Index == 0)
                {
                    PdfPCell cell = new PdfPCell(new Phrase("SN"));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }
                if (column.Index != 0 && column.Index !=7)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    pdfTable.AddCell(cell);
                }

            }

            //Adding DataRow
            
            foreach (DataGridViewRow row in orodhaMaeneoDataGridView.Rows)
            {

                foreach (DataGridViewCell cell in row.Cells)
                {
                    
                    if(cell.ColumnIndex == 0)
                    {
                        pdfTable.AddCell(count_recordsexport.ToString());
                    }
                    if (cell.ColumnIndex != 0 && cell.ColumnIndex !=7)
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
            using (FileStream stream = new FileStream(folderPath + "MaeneoICRADocumentExported.pdf", FileMode.Create))
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
            MessageBox.Show("Document save in: C:\\IWACHUPDFs\\MaeneoICRADocumentExported.pdf");
        }
    }
}

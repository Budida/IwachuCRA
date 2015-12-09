using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace IwachuCRA
{
    public partial class OrodhaYaKataForm : Form
    {
        int ward_id = 0;
        static int count_recordsexport = 1;
        public OrodhaYaKataForm()
        {
            InitializeComponent();
        }

        private void OrodhaYaKataForm_Load(object sender, EventArgs e)
        {
            loadKataList();
        }

        private void kataDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void LoadSerial(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[row.Index].HeaderCell.Value = string.Format("{0}  ", row.Index + 1).ToString();
                row.Height = 25;
            }
        }
        private void kataDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadSerial(this.kataDataGridView);
        }

        private void loadKataList() {
            using (MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString))
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT wid, ward_name, biashara_value, makazi_value, bmakazi_value,  taasisi_value, kiwanda_value   FROM wards WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'";
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            this.kataDataGridView.Visible = true;
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            this.kataDataGridView.DataSource = dt;

                            this.kataDataGridView.Columns["ward_name"].HeaderText = "Jina La Kata";
                            this.kataDataGridView.Columns["biashara_value"].HeaderText = "Kodi(Biashara)";
                            this.kataDataGridView.Columns["makazi_value"].HeaderText = "Kodi(Makazi)";
                            this.kataDataGridView.Columns["bmakazi_value"].HeaderText = "Kodi(Biashara/Makazi)";
                            this.kataDataGridView.Columns["taasisi_value"].HeaderText = "Kodi(Taasisi)";
                            this.kataDataGridView.Columns["kiwanda_value"].HeaderText = "Kodi(Kiwanda)";
                            this.kataDataGridView.Columns[6].AutoSizeMode   = DataGridViewAutoSizeColumnMode.Fill;
                            this.kataDataGridView.Columns["wid"].HeaderText = "WID";
                            this.kataDataGridView.Columns[0].Visible        = false;
                    

                            if (null != this.kataDataGridView)
                            {
                                foreach (DataGridViewRow r in this.kataDataGridView.Rows)
                                {
                                    this.kataDataGridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                                }
                            }
                        }
                        else
                        {
                            this.kataDataGridView.Visible = false;
                            MessageBox.Show("Hakuna kata zilizosajiliwa!");
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadKataList();
        }

        private void printKataBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Orodhakata.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.kataDataGridView, sfd.FileName); 
            }
        }

        private void ToCsV(DataGridView dGV, string filename)
        {
            try { 
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
            catch(Exception ex){
                MessageBox.Show("Kuna tatizo, jaribu tena!" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i;
            i = kataDataGridView.SelectedCells[0].RowIndex;
            ward_id             = int.Parse(this.kataDataGridView.Rows[i].Cells[0].Value.ToString());
            wardNameBox.Text    = this.kataDataGridView.Rows[i].Cells[1].Value.ToString();
            makaziValueBox.Text = this.kataDataGridView.Rows[i].Cells[2].Value.ToString();
            biasharaValueBox.Text = this.kataDataGridView.Rows[i].Cells[3].Value.ToString();
            bmakaziValueBox.Text = this.kataDataGridView.Rows[i].Cells[4].Value.ToString();
            taasisiValueBox.Text = this.kataDataGridView.Rows[i].Cells[5].Value.ToString();
            kiwandaValueBox.Text = this.kataDataGridView.Rows[i].Cells[6].Value.ToString();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void hifadhiEditWardBtn_Click(object sender, EventArgs e)
        {
            if (ward_id > 0)
            {
                Double outvalue;
                //update ward details
                string ward_name        = wardNameBox.Text;
                string makazi_value     = makaziValueBox.Text;
                string biashara_value   = biasharaValueBox.Text;
                string bmakazi_value    = bmakaziValueBox.Text;
                string taasisi_value    = taasisiValueBox.Text;
                string kiwanda_value    = kiwandaValueBox.Text;
                if (ward_name.Length > 0 && Double.TryParse(makazi_value, out outvalue) && Double.TryParse(biashara_value, out outvalue) && Double.TryParse(bmakazi_value, out outvalue) && Double.TryParse(taasisi_value, out outvalue) && Double.TryParse(kiwanda_value, out outvalue))
                {
                    MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "UPDATE wards SET ward_name='" + ward_name + "', makazi_value='" + makazi_value + "', biashara_value='" + biashara_value + "', bmakazi_value='" + bmakazi_value + "', taasisi_value='" + taasisi_value + "', kiwanda_value='" + kiwanda_value + "' WHERE wid='"+ward_id+"'";
                   int affectedRows = cmd.ExecuteNonQuery();
                   if (affectedRows > 0)
                   {
                       MessageBox.Show("Umefanikiwa kubadili!");
                       wardNameBox.Text = "";
                        connection.Close();
                   }
                   else 
                   {
                        connection.Close();
                        MessageBox.Show("Imeshindikana kubadili!");
                   }
                }
                else 
                {
                    MessageBox.Show("Weka taarifa zote kwa usahihi!");
                }
            }
            else 
            {
                MessageBox.Show("Click Badili kwanza!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //creating document header
            Paragraph para = new Paragraph(GlobalVariablesClass.council_name+"\n"+GlobalVariablesClass.daddress+"\nSIMU: "+GlobalVariablesClass.dphone+"\nNUKSHI: "+GlobalVariablesClass.dfax+"\nBARUA PEPE: "+GlobalVariablesClass.demail+"\n");
            para.Alignment = Element.ALIGN_CENTER;
            Paragraph para_space = new Paragraph("--------ORODHA YA KATA---------");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph(DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable = new PdfPTable(kataDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding        = 3;
            pdfTable.WidthPercentage            = 100;
            pdfTable.HorizontalAlignment        = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth    = 1;

            int[] widths = { 6, 16, 16, 16, 16, 15, 15 };
            pdfTable.SetWidths(widths);
            //Adding Header row
            foreach (DataGridViewColumn column in kataDataGridView.Columns)
            {
                if (column.Index == 0)
                {
                    PdfPCell cell = new PdfPCell(new Phrase("SN"));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
                }
                if(column.Index != 0)
                {
                    PdfPCell cell       = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
                }
                    
            }

            //Adding DataRow
            foreach (DataGridViewRow row in kataDataGridView.Rows)
            {
                
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 0)
                    {
                        pdfTable.AddCell(count_recordsexport.ToString());
                    }
                    if(cell.ColumnIndex != 0)
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
            using (FileStream stream = new FileStream(folderPath + "KataICRADocumentExported.pdf", FileMode.Create))
            {
                Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
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
            MessageBox.Show("Document save in: C:\\IWACHUPDFs\\KataICRADocumentExported.pdf");
        }
    }
}

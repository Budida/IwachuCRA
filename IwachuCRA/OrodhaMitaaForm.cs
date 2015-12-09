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
    public partial class OrodhaMitaaForm : Form
    {
        int street_id = 0;
        public OrodhaMitaaForm()
        {
            InitializeComponent();
            FillDropDownListKata("SELECT * FROM wards WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", wardDropDownSelect);
        }

        private void OrodhaMitaaForm_Load(object sender, EventArgs e)
        {
            loadMitaaList();
        }
        private void LoadSerial(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[row.Index].HeaderCell.Value = string.Format("{0}  ", row.Index + 1).ToString();
                row.Height = 25;
            }
        }
        private void mitaaDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadSerial(this.mitaaDataGridView);
        }
        private void loadMitaaList()
        {
            using (MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString))
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT id, street_name, wardid, ward_name   FROM streets JOIN wards ON streets.wardid = wards.wid WHERE streets.council_code='" + GlobalVariablesClass.council_code + "' AND streets.region_code='" + GlobalVariablesClass.region_code + "'";
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            this.mitaaDataGridView.Visible = true;
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            this.mitaaDataGridView.DataSource = dt;

                            this.mitaaDataGridView.Columns["ward_name"].HeaderText      = "Jina La Kata";
                            this.mitaaDataGridView.Columns["street_name"].HeaderText    = "Jina La Mtaa/Kijiji";
                            this.mitaaDataGridView.Columns[0].Visible                   = false;
                            this.mitaaDataGridView.Columns[2].Visible                   = false;


                            if (null != this.mitaaDataGridView)
                            {
                                foreach (DataGridViewRow r in this.mitaaDataGridView.Rows)
                                {
                                    this.mitaaDataGridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                                }
                            }
                        }
                        else
                        {
                            this.mitaaDataGridView.Visible = false;
                            MessageBox.Show("Hakuna mitaa iliyosajiliwa!");
                        }
                    }
                }
            }
        }

        private void pakuaMitaaUpya_Click(object sender, EventArgs e)
        {
            loadMitaaList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Orodhamitaa.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.mitaaDataGridView, sfd.FileName);
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

        private void badilimtaaBtn_Click(object sender, EventArgs e)
        {
            int i;
            i                                   = this.mitaaDataGridView.SelectedCells[0].RowIndex;
            street_id                           = int.Parse(this.mitaaDataGridView.Rows[i].Cells[0].Value.ToString());
            streetnameBox.Text                  = this.mitaaDataGridView.Rows[i].Cells[1].Value.ToString();
            wardDropDownSelect.SelectedText     = this.mitaaDataGridView.Rows[i].Cells[3].Value.ToString();
            wardDropDownSelect.SelectedValue    = this.mitaaDataGridView.Rows[i].Cells[2].Value.ToString();
        }

        public static void FillDropDownListKata(string Query, System.Windows.Forms.ComboBox DropDownName)
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
                DropDownName.DataSource     = dt;
                DropDownName.ValueMember    = "wid";
                DropDownName.DisplayMember  = "ward_name";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void hifadhiMtaaBtn_Click(object sender, EventArgs e)
        {
            string street_name  = streetnameBox.Text;
            int wardid          = int.Parse(wardDropDownSelect.SelectedValue.ToString());
            int id              = street_id;
            if (street_id > 0)
            {
                if (street_name.Length > 0)
                {
                    MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "UPDATE streets SET street_name='" + street_name + "', wardid='" + wardid + "' WHERE id='" + id + "'";
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Umefanikiwa kubadili!");
                        streetnameBox.Text = "";
                    }
                    else
                    {
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
                MessageBox.Show("Click badili!");
            }
        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            //creating document header
            Paragraph para          = new Paragraph(GlobalVariablesClass.council_name + "\n" + GlobalVariablesClass.daddress + "\nSIMU: " + GlobalVariablesClass.dphone + "\nNUKSHI: " + GlobalVariablesClass.dfax + "\nBARUA PEPE: " + GlobalVariablesClass.demail + "\n");
            para.Alignment          = Element.ALIGN_CENTER;
            Paragraph para_space    = new Paragraph("--------ORODHA YA MITAA---------\n");
            para_space.Alignment    = Element.ALIGN_CENTER;
            Paragraph para_date     = new Paragraph(DateTime.Now.Day.ToString()+"-"+DateTime.Now.Month.ToString()+"-"+DateTime.Now.Year.ToString());
            para_date.Alignment     = Element.ALIGN_CENTER;
            para_date.Font.Size     = 10;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable              = new PdfPTable(mitaaDataGridView.ColumnCount - 1);
            pdfTable.DefaultCell.Padding    = 3;
            pdfTable.WidthPercentage        = 100;
            pdfTable.HorizontalAlignment    = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;
            int[] widths = { 5, 55, 40 };
            pdfTable.SetWidths(widths);
            //Adding Header row
            foreach (DataGridViewColumn column in mitaaDataGridView.Columns)
            {
                if(column.Index == 0)
                {
                    PdfPCell cell = new PdfPCell(new Phrase("SN"));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
                }
                if (column.Index != 0 && column.Index !=2)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdfTable.AddCell(cell);
                }

            }

            //Adding DataRow
            int count = 1;
            foreach (DataGridViewRow row in mitaaDataGridView.Rows)
            {

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 0)
                    {
                        pdfTable.AddCell(count.ToString());
                    }
                    if (cell.ColumnIndex != 0 && cell.ColumnIndex != 2)
                    {
                        pdfTable.AddCell(cell.Value.ToString());
                    }

                }
                count++;
            }

            //Exporting to PDF
            string folderPath = "C:\\IWACHUPDFs\\";
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            using (FileStream stream = new FileStream(folderPath + "MitaaICRADocumentExported.pdf", FileMode.Create))
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
            MessageBox.Show("Document save in: C:\\IWACHUPDFs\\MitaaICRADocumentExported.pdf");
        }
    }
}

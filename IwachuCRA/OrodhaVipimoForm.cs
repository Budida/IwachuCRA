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
    public partial class OrodhaVipimoForm : Form
    {
        static string connString = GlobalVariablesClass.connString;
        MySqlConnection connection = new MySqlConnection(connString);
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        DataSet ds = new DataSet();
        static int page_number      = 0;
        static int count_per_page   = 100;
        static int next_offset      = 0;
        static int total_pages      = 0;
        static int total_rows       = 0;
        static int kid              = 0;
        public OrodhaVipimoForm()
        {
            InitializeComponent();
            currentPageLabel.Text = (page_number + 1).ToString();
            loadData(page_number, count_per_page, next_offset);
            string current_sql = "SELECT * FROM vipimo WHERE council_code='" + GlobalVariablesClass.council_code + "'";
            total_rows = countRows(current_sql);
            if (total_rows > 0)
            {
                total_pages = (int)Math.Ceiling((double)total_rows / (double)count_per_page);
                totalPagesLabel.Text = total_pages.ToString();
                idadiLabel.Text = "IDADI: " + String.Format("{0:0,0}", total_rows).ToString();
            }
        }

        private void OrodhaVipimoForm_Load(object sender, EventArgs e)
        {

        }
        private void loadData(int pagenumber, int countperpage, int nextoffset)
        {
            Cursor.Current = Cursors.WaitCursor;
            ds.Clear();
            nextoffset = pagenumber * countperpage;
            page_number = pagenumber;
            MySqlCommand cmd;
            string sql = "SELECT kid, jina, eneo, tozo FROM vipimo WHERE council_code= '"+GlobalVariablesClass.council_code+"' AND region_code='"+GlobalVariablesClass.region_code+"' LIMIT " + countperpage + " OFFSET " + nextoffset;
            cmd = new MySqlCommand(sql, connection);
            adapter.SelectCommand = cmd;
            adapter.Fill(ds, 0, 100, "income_sources");
            this.orodhaVipimoDataGridView.DataSource                    = ds.Tables[0];
            this.orodhaVipimoDataGridView.Columns["kid"].Visible        = false;
            this.orodhaVipimoDataGridView.Columns["jina"].HeaderText    = "JINA LA KIPIMO";
            this.orodhaVipimoDataGridView.Columns["eneo"].HeaderText    = "ENEO";
            this.orodhaVipimoDataGridView.Columns["tozo"].HeaderText    = "TOZO";
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

        private void forwardBtn_Click(object sender, EventArgs e)
        {
            page_number = int.Parse(currentPageLabel.Text) + 1;
            if (page_number > total_pages)
            {
                page_number = 0;
                currentPageLabel.Text = (page_number + 1).ToString();
                backwardBtn.Enabled = false;
            }
            else
            {
                currentPageLabel.Text = (page_number).ToString();
                backwardBtn.Enabled = true;
            }
            loadData(page_number, count_per_page, next_offset);
        }

        private void backwardBtn_Click(object sender, EventArgs e)
        {
            page_number = int.Parse(currentPageLabel.Text) - 1;
            if (page_number <= 0)
            {
                page_number = 0;
                backwardBtn.Enabled = false;
                currentPageLabel.Text = (1).ToString();
            }
            else
            {
                currentPageLabel.Text = (page_number).ToString();
            }
            loadData(page_number, count_per_page, next_offset);
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

        private void exportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Orodhayavipimo.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.orodhaVipimoDataGridView, sfd.FileName);
            }
        }

        private void pakuaUpyaBtn_Click(object sender, EventArgs e)
        {
            loadData(page_number, count_per_page, next_offset);
        }
        private void LoadSerial(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[row.Index].HeaderCell.Value = string.Format("{0}  ", row.Index + 1).ToString();
                row.Height = 25;
            }
        }
        private void orodhaVipimoDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadSerial(this.orodhaVipimoDataGridView);
        }

        private void badiliBtn_Click(object sender, EventArgs e)
        {
            int i;
            i = orodhaVipimoDataGridView.SelectedCells[0].RowIndex;
            kid = int.Parse(this.orodhaVipimoDataGridView.Rows[i].Cells[0].Value.ToString());
            jinaKipimoBox.Text  = this.orodhaVipimoDataGridView.Rows[i].Cells[1].Value.ToString();
            tozoBox.Text        = this.orodhaVipimoDataGridView.Rows[i].Cells[3].Value.ToString();
        }

        private void hifadhiKipimoBtn_Click(object sender, EventArgs e)
        {
            if (kid > 0)
            {
                Double outvalue;
                //update ward details
                string jina             = jinaKipimoBox.Text;
                string tozo             = tozoBox.Text;
                if (jina.Length > 0 && Double.TryParse(tozo, out outvalue))
                {
                    MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
                    connection.Open();
                    MySqlCommand cmd = connection.CreateCommand();
                    cmd.CommandText = "UPDATE vipimo SET jina='" + jina + "', tozo='" + tozo + "' WHERE kid='" + kid + "'";
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Umefanikiwa kubadili!");
                        jinaKipimoBox.Text = "";
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
                MessageBox.Show("Click Badili kwanza!");
            }

        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            //creating document header
            Paragraph para = new Paragraph(GlobalVariablesClass.council_name + "\n" + GlobalVariablesClass.daddress + "\nSIMU: " + GlobalVariablesClass.dphone + "\nNUKSHI: " + GlobalVariablesClass.dfax + "\nBARUA PEPE: " + GlobalVariablesClass.demail + "\n");
            para.Alignment = Element.ALIGN_CENTER;
            Paragraph para_space = new Paragraph("--------ORODHA YA VIPIMO---------\n");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph(DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            para_date.Font.Size = 11;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable                  = new PdfPTable(orodhaVipimoDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding        = 3;
            pdfTable.WidthPercentage            = 100;
            pdfTable.HorizontalAlignment        = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth    = 1;

            int[] widths = { 5, 30, 40, 25 };
            pdfTable.SetWidths(widths);
            //Adding Header row
            foreach (DataGridViewColumn column in orodhaVipimoDataGridView.Columns)
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
            int count = 1;
            foreach (DataGridViewRow row in orodhaVipimoDataGridView.Rows)
            {

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 0)
                    {
                        pdfTable.AddCell(count.ToString());
                    }
                    if (cell.ColumnIndex != 0)
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
            using (FileStream stream = new FileStream(folderPath + "VipimoICRADocumentExported.pdf", FileMode.Create))
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
            MessageBox.Show("Document save in: "+ folderPath + "VipimoICRADocumentExported.pdf");
        }
    }
}

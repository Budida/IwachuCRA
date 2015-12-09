using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
namespace IwachuCRA
{
    public partial class OrodhaYaVyanzoForm : Form
    {
        int sid = 0;
        static int count_recordsexport = 1;
        public OrodhaYaVyanzoForm()
        {
            InitializeComponent();
        }

        private void OrodhaYaVyanzoForm_Load(object sender, EventArgs e)
        {
            loadVyanzoList();
        }
        public static void LoadSerial(DataGridView grid)
        {
            foreach (DataGridViewRow row in grid.Rows)
            {
                grid.Rows[row.Index].HeaderCell.Value = string.Format("{0}  ", row.Index + 1).ToString();
                row.Height = 25;
            }
        }
        private void vyanzoDataGridView_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            LoadSerial(this.vyanzoDataGridView);
        }
        private void loadVyanzoList()
        {
            using (MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString))
            {
                using (MySqlCommand cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT sid, src_name, src_label FROM actual_sources WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'";
                    connection.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {

                            this.vyanzoDataGridView.Visible = true;
                            DataTable dt = new DataTable();
                            dt.Load(reader);
                            this.vyanzoDataGridView.DataSource = dt;

                            this.vyanzoDataGridView.Columns["src_name"].HeaderText = "Jina La Chanzo";
                            this.vyanzoDataGridView.Columns["src_label"].HeaderText = "Namba Ya Chanzo";
                            this.vyanzoDataGridView.Columns[0].Visible = false;


                            if (null != this.vyanzoDataGridView)
                            {
                                foreach (DataGridViewRow r in this.vyanzoDataGridView.Rows)
                                {
                                    this.vyanzoDataGridView.Rows[r.Index].HeaderCell.Value = (r.Index + 1).ToString();
                                }
                            }
                        }
                        else
                        {
                            this.vyanzoDataGridView.Visible = false;
                            MessageBox.Show("Hakuna vyanzo vilivyosajiliwa!");
                        }
                    }
                }
            }
        }

        private void pakuaUpyaVyanzoBtn_Click(object sender, EventArgs e)
        {
            loadVyanzoList();
        }

        private void badiliChanzoBtn_Click(object sender, EventArgs e)
        {
            int i;
            i                   = this.vyanzoDataGridView.SelectedCells[0].RowIndex;
            sid                 = int.Parse(this.vyanzoDataGridView.Rows[i].Cells[0].Value.ToString());
            jinaChanzoBox.Text = this.vyanzoDataGridView.Rows[i].Cells[1].Value.ToString();
            nambaChanzoBox.Text = this.vyanzoDataGridView.Rows[i].Cells[2].Value.ToString();
        }

        private void hifadhiBadiliChanzo_Click(object sender, EventArgs e)
        {
            string src_name     = jinaChanzoBox.Text;
            string src_label    = nambaChanzoBox.Text;
            if (sid > 0)
            {
                if (src_name.Length > 0 && src_label.Length > 0)
                {
                    MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
                    MySqlCommand cmd2;
                    connection.Open();
                    try 
                    { 
                        //check first if there is income records of this source
                        cmd2 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM actual_income WHERE main_src='" + sid + "' AND region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "'", connection);
                        MySql.Data.MySqlClient.MySqlDataReader myReader = cmd2.ExecuteReader();
                        if (myReader.HasRows)
                        {
                            //MessageBox.Show("Tayari kuna taarifa za mapato za hiki chanzo, huwezi kibadili!");
                            connection.Close();
                            connection.Open();
                            MySqlCommand cmd = connection.CreateCommand();
                            cmd.CommandText = "UPDATE actual_sources SET src_name='" + src_name + "' WHERE sid='" + sid + "'";
                            int affectedRows = cmd.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                MessageBox.Show("Umefanikiwa kubadili!");
                                jinaChanzoBox.Text = "";
                                nambaChanzoBox.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Imeshindikana kubadili!");
                            }
                        }
                        else
                        {
                            connection.Close();
                            connection.Open();
                            MySqlCommand cmd    = connection.CreateCommand();
                            cmd.CommandText     = "UPDATE actual_sources SET src_name='" + src_name + "', src_label='" + src_label + "' WHERE sid='" + sid + "'";
                            int affectedRows    = cmd.ExecuteNonQuery();
                            if (affectedRows > 0)
                            {
                                MessageBox.Show("Umefanikiwa kubadili!");
                                jinaChanzoBox.Text  = "";
                                nambaChanzoBox.Text = "";
                            }
                            else
                            {
                                MessageBox.Show("Imeshindikana kubadili!");
                            }
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
                    MessageBox.Show("Weka taarifa zote kwa usahihi!");
                }
                
            }
            else 
            {
                MessageBox.Show("Click badili chanzo kwanza!");
            }
        }

        private void exportPDF_Click(object sender, EventArgs e)
        {
            //creating document header
            Paragraph para = new Paragraph(GlobalVariablesClass.council_name + "\n" + GlobalVariablesClass.daddress + "\nSIMU: " + GlobalVariablesClass.dphone + "\nNUKSHI: " + GlobalVariablesClass.dfax + "\nBARUA PEPE: " + GlobalVariablesClass.demail + "\n");
            para.Alignment = Element.ALIGN_CENTER;
            Paragraph para_space = new Paragraph("--------ORODHA YA VYANZO VYA MAPATO---------");
            para_space.Alignment = Element.ALIGN_CENTER;
            Paragraph para_date = new Paragraph(DateTime.Now.Day.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Year.ToString());
            para_date.Alignment = Element.ALIGN_CENTER;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;
            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable               = new PdfPTable(vyanzoDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding     = 3;
            pdfTable.WidthPercentage         = 100;
            pdfTable.HorizontalAlignment     = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;

            int[] widths = { 5, 55, 40 };
            pdfTable.SetWidths(widths);
            //Adding Header row
            foreach (DataGridViewColumn column in vyanzoDataGridView.Columns)
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
            foreach (DataGridViewRow row in vyanzoDataGridView.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "VyanzoICRADocumentExported.pdf", FileMode.Create))
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
            MessageBox.Show("Document save in: C:\\IWACHUPDFs\\VyanzoICRADocumentExported.pdf");
        }
    }
}

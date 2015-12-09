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
    public partial class TaarifaZaWalipaKodiForm : Form
    {
        int count_recordsexport = 1;
        static string connString = GlobalVariablesClass.connString;
        MySqlConnection connection = new MySqlConnection(connString);
        public TaarifaZaWalipaKodiForm()
        {
            InitializeComponent();
            FillDropDownListKata("SELECT ward_name FROM wards WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", kataDropDown);
            FillDropDownListMtaaKijiji("SELECT street_name FROM streets WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", mtaaDropDown);
        }

        private void TaarifaZaWalipaKodiForm_Load(object sender, EventArgs e)
        {
            setYearsDropItems();
            kataDropDown.SelectedValue = "";
            mtaaDropDown.SelectedValue = "";
        }

        private void setYearsDropItems()
        {
            int max_year = DateTime.Now.Year;
            int min_year = max_year - 25;
            yearDropDown.Items.Add("");
            while (max_year > min_year)
            {
                yearDropDown.Items.Add(max_year);
                max_year--;
            }
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
                dt.Rows.Add("");
                DropDownName.ValueMember    = "ward_name";
                DropDownName.DisplayMember  = "ward_name";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        public static void FillDropDownListMtaaKijiji(string Query, System.Windows.Forms.ComboBox DropDownName)
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
                DropDownName.DataSource = dt;
                dt.Rows.Add("");
                DropDownName.ValueMember = "street_name";
                DropDownName.DisplayMember = "street_name";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void angaliaBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            incomeResultsDataGridView.Rows.Clear();
            string sort_by  = angaliaDropDwon.SelectedItem.ToString();
            string year     = yearDropDown.SelectedItem.ToString();
            string ward     = kataDropDown.SelectedValue.ToString();
            string street   = mtaaDropDown.SelectedValue.ToString();
            if(year.Length >0 && sort_by.Length > 0)
            {
                MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
                MySqlCommand cmd;
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    //change command text according to select creteria
                    if(ward.Length > 0 && street.Length == 0)
                    {
                        cmd.CommandText = "SELECT * FROM income_sources WHERE ward='"+ward+"' AND tax_payer='Yes' AND council_code='" + GlobalVariablesClass.council_code + "'";
                    }
                    else if(ward.Length == 0 && street.Length  >0)
                    {
                        cmd.CommandText = "SELECT * FROM income_sources WHERE street='"+street+"' AND tax_payer='Yes' AND council_code='" + GlobalVariablesClass.council_code + "'";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM income_sources WHERE street='' AND ward='' AND tax_payer='Yes' AND council_code='" + GlobalVariablesClass.council_code + "'";
                    }
                   
                    MySqlDataReader myReader = cmd.ExecuteReader();
                    if (myReader.HasRows)
                    {
                        if (sort_by == "Waliolipa")
                        {
                            int count = 1;
                            
                            incomeResultsDataGridView.ColumnCount = 12;
                            incomeResultsDataGridView.Columns[0].Name = "SN";
                            incomeResultsDataGridView.Columns[1].Name = "JINA";
                            incomeResultsDataGridView.Columns[2].Name = "NAMBA";
                            incomeResultsDataGridView.Columns[3].Name = "KATA";
                            incomeResultsDataGridView.Columns[4].Name = "MTAA";
                            incomeResultsDataGridView.Columns[5].Name = "KIWANJA";
                            incomeResultsDataGridView.Columns[6].Name = "KITALU";
                            incomeResultsDataGridView.Columns[7].Name = "SIMU";
                            incomeResultsDataGridView.Columns[8].Name = "KODI";
                            incomeResultsDataGridView.Columns[9].Name = "ALIYOLIPA";
                            incomeResultsDataGridView.Columns[10].Name = "DENI";
                            incomeResultsDataGridView.Columns[11].Name = "";
                            incomeResultsDataGridView.Columns[0].Width = 50;
                            while (myReader.Read())
                            {
                                double paid_kodi    = jumlaKodiAliyolipa(year, myReader.GetString(myReader.GetOrdinal("slabel")));
                                if (paid_kodi > 0)
                                {
                                    double tax_amount = myReader.GetDouble(myReader.GetOrdinal("tax_amount"));
                                    double deni = tax_amount - paid_kodi;
                                    if (deni < 0)
                                    {
                                        deni = 0;
                                    }
                                    string[] row = new string[] {
                                    count.ToString(),
                                    myReader.GetString(myReader.GetOrdinal("source")),
                                    myReader.GetString(myReader.GetOrdinal("slabel")),
                                    myReader.GetString(myReader.GetOrdinal("ward")),
                                    myReader.GetString(myReader.GetOrdinal("street")),
                                    myReader.GetString(myReader.GetOrdinal("plot_number")),
                                    myReader.GetString(myReader.GetOrdinal("block_number")),
                                    myReader.GetString(myReader.GetOrdinal("phone_number")),
                                    myReader.GetString(myReader.GetOrdinal("tax_amount")),
                                    paid_kodi.ToString(),
                                    deni.ToString(),
                                    ""
                                    };
                                    incomeResultsDataGridView.Rows.Add(row);
                                    count++;
                                }
                            }
                        }
                        else if (sort_by== "Ambao Hawajalipa")
                        {
                            int count = 1;
                            incomeResultsDataGridView.ColumnCount = 12;
                            incomeResultsDataGridView.Columns[0].Name = "SN";
                            incomeResultsDataGridView.Columns[1].Name = "JINA";
                            incomeResultsDataGridView.Columns[2].Name = "NAMBA";
                            incomeResultsDataGridView.Columns[3].Name = "KATA";
                            incomeResultsDataGridView.Columns[4].Name = "MTAA";
                            incomeResultsDataGridView.Columns[5].Name = "KIWANJA";
                            incomeResultsDataGridView.Columns[6].Name = "KITALU";
                            incomeResultsDataGridView.Columns[7].Name = "SIMU";
                            incomeResultsDataGridView.Columns[8].Name = "KODI";
                            incomeResultsDataGridView.Columns[9].Name = "ALIYOLIPA";
                            incomeResultsDataGridView.Columns[10].Name = "DENI";
                            incomeResultsDataGridView.Columns[11].Name = "";
                            incomeResultsDataGridView.Columns[0].Width = 50;
                            while (myReader.Read())
                            {
                                double paid_kodi = jumlaKodiAliyolipa(year, myReader.GetString(myReader.GetOrdinal("slabel")));
                                if (paid_kodi == 0)
                                {
                                    double tax_amount = myReader.GetDouble(myReader.GetOrdinal("tax_amount"));
                                    double deni = tax_amount - paid_kodi;
                                    if (deni < 0)
                                    {
                                        deni = 0;
                                    }
                                    string[] row = new string[] {
                                    count.ToString(),
                                    myReader.GetString(myReader.GetOrdinal("source")),
                                    myReader.GetString(myReader.GetOrdinal("slabel")),
                                    myReader.GetString(myReader.GetOrdinal("ward")),
                                    myReader.GetString(myReader.GetOrdinal("street")),
                                    myReader.GetString(myReader.GetOrdinal("plot_number")),
                                    myReader.GetString(myReader.GetOrdinal("block_number")),
                                    myReader.GetString(myReader.GetOrdinal("phone_number")),
                                    myReader.GetString(myReader.GetOrdinal("tax_amount")),
                                    paid_kodi.ToString(),
                                    deni.ToString(),
                                    ""
                                    };
                                    incomeResultsDataGridView.Rows.Add(row);
                                    count++;
                                }
                            }
                        }
                        else if (sort_by=="Wanaodaiwa")
                        {
                            int count = 1;
                            incomeResultsDataGridView.ColumnCount = 12;
                            incomeResultsDataGridView.Columns[0].Name = "SN";
                            incomeResultsDataGridView.Columns[1].Name = "JINA";
                            incomeResultsDataGridView.Columns[2].Name = "NAMBA";
                            incomeResultsDataGridView.Columns[3].Name = "KATA";
                            incomeResultsDataGridView.Columns[4].Name = "MTAA";
                            incomeResultsDataGridView.Columns[5].Name = "KIWANJA";
                            incomeResultsDataGridView.Columns[6].Name = "KITALU";
                            incomeResultsDataGridView.Columns[7].Name = "SIMU";
                            incomeResultsDataGridView.Columns[8].Name = "KODI";
                            incomeResultsDataGridView.Columns[9].Name = "ALIYOLIPA";
                            incomeResultsDataGridView.Columns[10].Name = "DENI";
                            incomeResultsDataGridView.Columns[11].Name = "";
                            incomeResultsDataGridView.Columns[0].Width = 50;
                            while (myReader.Read())
                            {
                                double paid_kodi = jumlaKodiAliyolipa(year, myReader.GetString(myReader.GetOrdinal("slabel")));
                                double tax_amount = myReader.GetDouble(myReader.GetOrdinal("tax_amount"));
                                double deni = tax_amount - paid_kodi;
                                if (deni > 0)
                                {
                                    if (deni < 0)
                                    {
                                        deni = 0;
                                    }
                                    string[] row = new string[] {
                                    count.ToString(),
                                    myReader.GetString(myReader.GetOrdinal("source")),
                                    myReader.GetString(myReader.GetOrdinal("slabel")),
                                    myReader.GetString(myReader.GetOrdinal("ward")),
                                    myReader.GetString(myReader.GetOrdinal("street")),
                                    myReader.GetString(myReader.GetOrdinal("plot_number")),
                                    myReader.GetString(myReader.GetOrdinal("block_number")),
                                    myReader.GetString(myReader.GetOrdinal("phone_number")),
                                    myReader.GetString(myReader.GetOrdinal("tax_amount")),
                                    paid_kodi.ToString(),
                                    deni.ToString(),
                                    ""
                                    };
                                    incomeResultsDataGridView.Rows.Add(row);
                                    count++;
                                }
                            }
                        }
                        else if (sort_by=="Waliopewa Bill")
                        {
                            int count = 1;
                            incomeResultsDataGridView.ColumnCount = 12;
                            incomeResultsDataGridView.Columns[0].Name = "SN";
                            incomeResultsDataGridView.Columns[1].Name = "JINA";
                            incomeResultsDataGridView.Columns[2].Name = "NAMBA";
                            incomeResultsDataGridView.Columns[3].Name = "KATA";
                            incomeResultsDataGridView.Columns[4].Name = "MTAA";
                            incomeResultsDataGridView.Columns[5].Name = "KIWANJA";
                            incomeResultsDataGridView.Columns[6].Name = "KITALU";
                            incomeResultsDataGridView.Columns[7].Name = "SIMU";
                            incomeResultsDataGridView.Columns[8].Name = "TAREHE";
                            incomeResultsDataGridView.Columns[9].Name = "KIASI";
                            incomeResultsDataGridView.Columns[10].Name = "MWISHO WA KULIPA";
                            incomeResultsDataGridView.Columns[11].Name = "";
                            incomeResultsDataGridView.Columns[0].Width = 50;
                            while (myReader.Read())
                            {
                                int check_bill = checkBill(year, myReader.GetString(myReader.GetOrdinal("slabel")));
                                if (check_bill > 0)
                                {
                                    string[] row = new string[] {
                                    count.ToString(),
                                    myReader.GetString(myReader.GetOrdinal("source")),
                                    myReader.GetString(myReader.GetOrdinal("slabel")),
                                    myReader.GetString(myReader.GetOrdinal("ward")),
                                    myReader.GetString(myReader.GetOrdinal("street")),
                                    myReader.GetString(myReader.GetOrdinal("plot_number")),
                                    myReader.GetString(myReader.GetOrdinal("block_number")),
                                    myReader.GetString(myReader.GetOrdinal("phone_number")),
                                    getBillDate(year, myReader.GetString(myReader.GetOrdinal("slabel"))).ToString(),
                                    getBillAmount(year, myReader.GetString(myReader.GetOrdinal("slabel"))).ToString(),
                                    getBillPayDate(year, myReader.GetString(myReader.GetOrdinal("slabel"))).ToString(),
                                    ""
                                    };
                                    incomeResultsDataGridView.Rows.Add(row);
                                    count++;
                                }
                            }
                        }
                   
                    }
                    else
                    {
                        MessageBox.Show("Hakuna walipa kodi waliosajili yaliysajiliwa!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Tatizo: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Chagua mwaka na unataka kuangalia nini?");
            }
            Cursor.Current = Cursors.Default;
        }

        private double jumlaKodiAliyolipa(string year, string codenumber)
        {
            double jumla = 0;
            connection.Open();
            MySqlCommand cmd;
            string sql = "SELECT amount FROM actual_income WHERE year='"+year+"' AND branch_src='"+ codenumber + "'";
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
        private int checkBill(string year, string codenumber)
        {
            int count = 0;
            connection.Open();
            MySqlCommand cmd;
            string sql = "SELECT amount FROM bills WHERE year='" + year + "' AND codenumber='" + codenumber + "'";
            cmd = new MySqlCommand(sql, connection);
            MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                count++;
            }
            connection.Close();
            return count;
        }
        private double getBillAmount(string year, string codenumber)
        {
            double amount = 0;
            connection.Open();
            MySqlCommand cmd;
            string sql = "SELECT amount FROM bills WHERE year='" + year + "' AND codenumber='" + codenumber + "'";
            cmd = new MySqlCommand(sql, connection);
            MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    amount = amount + myReader.GetDouble(myReader.GetOrdinal("amount"));
                }
            }
            connection.Close();
            return amount;
        }
        private string getBillDate(string year, string codenumber)
        {
            string rdate = "";
            connection.Open();
            MySqlCommand cmd;
            string sql = "SELECT tarehe FROM bills WHERE year='" + year + "' AND codenumber='" + codenumber + "'";
            cmd = new MySqlCommand(sql, connection);
            MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    rdate = myReader.GetString(myReader.GetOrdinal("tarehe"));
                }
            }
            connection.Close();
            return rdate;
        }
        private string getBillPayDate(string year, string codenumber)
        {
            string paytarehe = "";
            connection.Open();
            MySqlCommand cmd;
            string sql = "SELECT paytarehe FROM bills WHERE year='" + year + "' AND codenumber='" + codenumber + "'";
            cmd = new MySqlCommand(sql, connection);
            MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    paytarehe = myReader.GetString(myReader.GetOrdinal("paytarehe"));
                }
            }
            connection.Close();
            return paytarehe;
        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "Taarifa za walipa kodi.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                //ToCsV(dataGridView1, @"c:\export.xls");
                ToCsV(this.incomeResultsDataGridView, sfd.FileName);
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
            Paragraph para          = new Paragraph(GlobalVariablesClass.council_name + "\n" + GlobalVariablesClass.daddress + "\nSIMU: " + GlobalVariablesClass.dphone + "\nNUKSHI: " + GlobalVariablesClass.dfax + "\nBARUA PEPE: " + GlobalVariablesClass.demail + "\n");
            para.Alignment          = Element.ALIGN_CENTER;
            Paragraph para_space    = new Paragraph("--------TAARIFA ZA WALIPA KODI---------");
            para_space.Alignment    = Element.ALIGN_CENTER;
            Paragraph para_date     = new Paragraph("Mwaka " + yearDropDown.SelectedItem.ToString()+" "+angaliaDropDwon.SelectedItem.ToString());
            para_date.Alignment     = Element.ALIGN_CENTER;
            Paragraph new_line_para = new Paragraph("----");
            new_line_para.Alignment = Element.ALIGN_CENTER;

            //Creating iTextSharp Table from the DataTable data
            PdfPTable pdfTable      = new PdfPTable(incomeResultsDataGridView.ColumnCount);
            pdfTable.DefaultCell.Padding    = 3;
            pdfTable.WidthPercentage        = 100;
            pdfTable.HorizontalAlignment    = Element.ALIGN_CENTER;
            pdfTable.DefaultCell.BorderWidth = 1;

            int[] widths = { 5, 9, 9, 9, 9, 7, 7, 10, 8, 8, 6, 4 };
            pdfTable.SetWidths(widths);
            //Adding Header row
            foreach (DataGridViewColumn column in incomeResultsDataGridView.Columns)
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
            foreach (DataGridViewRow row in incomeResultsDataGridView.Rows)
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
            using (FileStream stream = new FileStream(folderPath + "TaarifaZaWalipakodi" + count_recordsexport + "CRADocumentExported.pdf", FileMode.Create))
            {
                //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                Document pdfDoc = new Document(new RectangleReadOnly(842, 595), 10f, 10f, 10f, 0f);
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
            MessageBox.Show("Document save in: " + folderPath + "TaarifaZaWalipakodi" + count_recordsexport + "CRADocumentExported.pdf");
        }
    }
}

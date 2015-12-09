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

namespace IwachuCRA
{
    public partial class AndaaBillForm : Form
    {
        public static DateTime referenceDate = new DateTime(1970, 1, 1);
        string connectionString     = GlobalVariablesClass.connString;
        static string fullname      = "";
        static string address       = "";
        static string ward          = "";
        static string street        = "";
        static string plot_number   = "";
        static string block_number  = "";
        static double rat_value     = 0;
        static string tax_amount    = "";
        static string matumizi      = "";
        static string codenumber    = "";
        static double reg_seconds   = 0;
        public AndaaBillForm()
        {
            InitializeComponent();
           
        }
        private void AndaaBillForm_Load(object sender, EventArgs e)
        {
            setReceiptLogo(this.logoPictureBox);
            setReceiptDedSign(this.signPictureBox);
            FillDropDownListKata("SELECT ward_name FROM wards WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", kataDropDown);
            dnameLabel.Text     = GlobalVariablesClass.council_name;
            dAddreaaLabel.Text  = GlobalVariablesClass.daddress;
            dPhoneLabel.Text    = "SIMU: "+GlobalVariablesClass.dphone;
            dFaxLabel.Text      = "NUKSHI: "+GlobalVariablesClass.dfax;
            emailLabel.Text     = "BARUA PEPE: "+GlobalVariablesClass.demail;
            hifadhiDropDown.SelectedItem = "Hapana";
            kataDropDown.SelectedValue  = "";
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(billPanel.Width, billPanel.Height);
            billPanel.DrawToBitmap(bmp, new Rectangle(0, 0, billPanel.Width, billPanel.Height));
            //e.Graphics.DrawImage(bmp, billPanel.Width, billPanel.Height);
            //e.Graphics.DrawImage(bmp, e.PageBounds);
            e.Graphics.DrawImage(bmp, e.MarginBounds);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            billPanel.CreateGraphics().DrawLines(new Pen(Color.Black), new Point[] { new Point(2, 2), new Point(2, 2) });
        }
        private void PrintPanel(Panel pnl)
        {
            try
            {
              
                PrintDialog myPrintDialog = new PrintDialog();
                PrinterSettings values;
                values = myPrintDialog.PrinterSettings;
                myPrintDialog.Document = printDocument1;
                printDocument1.PrintController = new StandardPrintController();
                printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);

                printPreviewDialog1.Document    = printDocument1;
                 printPreviewDialog1.ShowDialog();
                if (myPrintDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument1.Print();
                    printDocument1.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PrintPanel(billPanel);
        }

        private void billPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void setReceiptLogo(PictureBox picBox)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(GlobalVariablesClass.connString);
                cn.Open();

                //Retrieve BLOB from database into DataSet.
                MySqlCommand cmd = new MySqlCommand("SELECT logo_blob FROM basic_info WHERE council_code = '" + GlobalVariablesClass.council_code + "'", cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "basic_info");
                int c = ds.Tables["basic_info"].Rows.Count;

                if (c > 0)
                {   //BLOB is read into Byte array, then used to construct MemoryStream,
                    //then passed to PictureBox.
                    Byte[] byteBLOBData = new Byte[0];
                    byteBLOBData = (Byte[])(ds.Tables["basic_info"].Rows[c - 1]["logo_blob"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                    picBox.Image = Image.FromStream(stmBLOBData);
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void setReceiptDedSign(PictureBox picBox)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(GlobalVariablesClass.connString);
                cn.Open();

                //Retrieve BLOB from database into DataSet.
                MySqlCommand cmd = new MySqlCommand("SELECT dedsign_blob FROM basic_info WHERE council_code = '" + GlobalVariablesClass.council_code + "'", cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "basic_info");
                int c = ds.Tables["basic_info"].Rows.Count;

                if (c > 0)
                {   //BLOB is read into Byte array, then used to construct MemoryStream,
                    //then passed to PictureBox.
                    Byte[] byteBLOBData = new Byte[0];
                    byteBLOBData = (Byte[])(ds.Tables["basic_info"].Rows[c - 1]["dedsign_blob"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                    picBox.Image = Image.FromStream(stmBLOBData);
                }
                cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void andaaBillBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //process bill contents
            DateTime recordDate = tareheYaHatiDatePick.Value;
            string codenumber   = regNumberBox.Text;
            string hifadhi      = hifadhiDropDown.SelectedItem.ToString();
            DateTime paytarehe = tareheYaKulipaDatePick.Value;
            if(codenumber.Length == 0)
            {
                MessageBox.Show("Weka namba ya usajili ya mlipa kodi!");
            }
            else
            { 
                getPayersInfo(codenumber);
                if (reg_seconds > 0)
                {
                    jinaLabel.Text      = "";
                    addressLabel.Text   = "";
                    nambaLabel.Text     = "";
                    kataLabel.Text      = "";
                    mtaaLabel.Text      = "";
                    plotLabel.Text      = "";
                    blockLabel.Text     = "";
                    matumiziLabel.Text  = "";
                    ainaLabel.Text      = "";

                    thamaniLabel.Text       = "";
                    tareheLabel.Text        = "";
                    kodiLabel.Text          = "";
                    kodiMchanganuoLabel.Text = "";
                    malimbikizoLabel.Text   = "";
                    tozoLabel.Text          = "";
                    jumlaLabel.Text         = "";
                    kilicholipwaLabel.Text  = "";

                    Double taxamount = Double.Parse(tax_amount);
                    int selected_day = recordDate.Day;
                    int selected_month = recordDate.Month;
                    int selected_year = recordDate.Year;
                    double selected_seconds = toSeconds(recordDate, referenceDate);
                    DateTime regDate = UnixTimeStampToDateTime(reg_seconds); //return reg seconds to reg date
                    int years_passed = recordDate.Year - regDate.Year;
                    int reg_year = regDate.Year;
                    int reg_month = regDate.Month;
                    //caculate limbikizo per each year
                    double last_month = 0;
                    double new_limbikizo = 0;
                    //double new_penalty = 0;
                    double ziada_new = 0;
                    double total_paid_new = 0;
                    double riba_total = 0;
                    years_passed = years_passed + 1;
                    double payment_per_year = 0;
                    double penalty_total = 0;
                    if (years_passed > 0)
                    {
                        for (int y = reg_year; y <= selected_year; y++)
                        {
                            payment_per_year = getTaxpayerTotalYearPayment(codenumber, y);
                            last_month = getLastPaymentMonth(codenumber, y);
                            if (payment_per_year > 0)
                            {
                                total_paid_new += payment_per_year;

                                if (payment_per_year > taxamount)
                                {
                                    if (last_month > GlobalVariablesClass.limbikizo_mwezi)
                                    {
                                        if (y < DateTime.Now.Year)
                                        {
                                            new_limbikizo += taxamount;
                                        }
                                        penalty_total += (GlobalVariablesClass.limbikizo_percent * taxamount) / 100;
                                        double difference = payment_per_year - GlobalVariablesClass.limbikizo_mwezi;
                                        if (difference > ((GlobalVariablesClass.limbikizo_percent * taxamount) / 100))
                                        {
                                            ziada_new += (difference - (GlobalVariablesClass.limbikizo_percent * taxamount) / 100);
                                        }

                                    }
                                    else
                                    {
                                        ziada_new += payment_per_year - taxamount;
                                    }
                                }
                                else if (payment_per_year < taxamount)
                                {
                                    //no payment found per given year
                                    if (y < selected_year)
                                    {
                                        if (last_month > GlobalVariablesClass.limbikizo_mwezi)
                                        {
                                            new_limbikizo += (taxamount - payment_per_year);
                                            penalty_total += (GlobalVariablesClass.limbikizo_percent * taxamount) / 100;
                                        }
                                        else
                                        {
                                            new_limbikizo += (taxamount - payment_per_year);
                                        }
                                    }
                                    else if (y == selected_year)
                                    {
                                        if (last_month > GlobalVariablesClass.limbikizo_mwezi)
                                        {
                                            penalty_total += (GlobalVariablesClass.limbikizo_percent * taxamount) / 100;
                                        }
                                    }
                                }

                                if (last_month > GlobalVariablesClass.riba_month)
                                {
                                    riba_total += ((GlobalVariablesClass.riba_percent * taxamount * last_month) - GlobalVariablesClass.riba_month) / 100;
                                }
                            }
                            else
                            {
                                //no payment doen per specific year
                                    if (y < DateTime.Now.Year)
								    {
									    riba_total += (GlobalVariablesClass.riba_percent * taxamount * (12 - GlobalVariablesClass.riba_month))/ 100;
									    new_limbikizo += taxamount;
									    penalty_total += (GlobalVariablesClass.limbikizo_percent * taxamount)/ 100;
                                    }
								    else if ( y == selected_year )
								    {
                                        if (selected_month > GlobalVariablesClass.limbikizo_mwezi)
								        {
										        //$new_limbikizo 	+= $tax_amount;
										        penalty_total += (GlobalVariablesClass.limbikizo_percent * taxamount)/ 100;
                                        }
                                        if (selected_month > GlobalVariablesClass.riba_month)
								        {
										        riba_total += (GlobalVariablesClass.riba_percent * taxamount * (selected_month - GlobalVariablesClass.riba_month))/ 100;
                                        }
                                    }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Hajafika muda wa kulipa kodi");
                    }

                    //assign values to the bill form
                    thamaniLabel.Text           = String.Format("{0:0,0}", rat_value).ToString();
                    tareheLabel.Text            = recordDate.Day.ToString()+"/"+recordDate.Month.ToString()+"/"+recordDate.Year.ToString();
                    kodiLabel.Text              = String.Format("{0:0,0}", taxamount).ToString();
                    kodiMchanganuoLabel.Text    = String.Format("{0:0,0}", taxamount).ToString();
                    malimbikizoLabel.Text       = String.Format("{0:0,0}", new_limbikizo).ToString();
                    tozoLabel.Text              = String.Format("{0:0,0}", penalty_total).ToString();
                    double jumla_deni           = new_limbikizo +taxamount + penalty_total;
                    jumlaLabel.Text             = String.Format("{0:0,0}", jumla_deni).ToString();
                    kilicholipwaLabel.Text      = String.Format("{0:0,0}", total_paid_new).ToString();
                    double diff                 = jumla_deni - total_paid_new;
                    double deni                 = 0;
                    double ziada                = 0;
                    if (diff > 0)
                    {
                        deni                = diff;
                        ziada               = 0;
                    }
                    else
                    {
                        ziada               = -1 * diff;
                        deni                = 0;
                    }
                    deniLabel.Text              = String.Format("{0:0,0}", deni).ToString();
                    ziadaLabel.Text             = String.Format("{0:0,0}", ziada).ToString();
                    lipaKablaLabel.Text         = paytarehe.Day.ToString() + "/" + paytarehe.Month.ToString() + "/" + paytarehe.Year.ToString();
                    kiasiChaLabel.Text          = String.Format("{0:0,0}", deni).ToString();
                    akauntiLabel.Text           = GlobalVariablesClass.bank_account;
                    mkurugenziNameLabel.Text    = GlobalVariablesClass.dedname;

                    //assign tax payers info on bill
                    jinaLabel.Text          = fullname;
                    addressLabel.Text       = address;
                    nambaLabel.Text         = codenumber;
                    kataLabel.Text          = ward;
                    mtaaLabel.Text          = street;
                    plotLabel.Text          = plot_number;
                    blockLabel.Text         = block_number;
                    matumiziLabel.Text      = matumizi;
                    ainaLabel.Text          = "";

                    //save bill to db
                    if(hifadhi=="Ndiyo" && diff > 0 && getPreparedBills(codenumber, selected_year) == 0)
                    {
                        MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
                        MySql.Data.MySqlClient.MySqlCommand cmd;
                        connection.Open();
                        try
                        {
                            string tarehe = recordDate.Day.ToString() + "-" + recordDate.Month.ToString() + "-" + recordDate.Year.ToString();
                            string payTarehe = paytarehe.Day.ToString() + "-" + paytarehe.Month.ToString() + "-" + paytarehe.Year.ToString();
                            cmd = connection.CreateCommand();
                            cmd.CommandText = "INSERT INTO bills (codenumber, year, amount, tarehe, paytarehe, council_code, region_code) VALUES("+
                             "'"+codenumber+"', "+ "'" + selected_year + "', " + "'" + diff + "', " + "'" + tarehe + "', " + "'" + payTarehe + "', " + "'" + GlobalVariablesClass.council_code + "', " + "'" + GlobalVariablesClass.region_code + "'" +
                            ")";
                            cmd.Parameters.AddWithValue("@codenumber", codenumber);
                            cmd.Parameters.AddWithValue("@year", selected_year);
                            cmd.Parameters.AddWithValue("@tarehe", tarehe);
                            cmd.Parameters.AddWithValue("@paytarehe", payTarehe);
                            cmd.Parameters.AddWithValue("@council_code", GlobalVariablesClass.council_code);
                            cmd.Parameters.AddWithValue("@region_code", GlobalVariablesClass.region_code);
                            int affectedRows = cmd.ExecuteNonQuery();
                            if (affectedRows >0)
                            {
                                MessageBox.Show("Umefanikiwa kuhifadhi Hati ya madai!");
                            }
                            else
                            {
                                MessageBox.Show("Imeshindikana kuhifadhi hati ya madai!");
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
                }
                else
                {
                    MessageBox.Show("Hakuna mlipa kodi mwenye namba "+codenumber);
                }
            }
            Cursor.Current = Cursors.Default;
        }
        
        private double getTaxpayerTotalYearPayment(string codenumber, int year)
        {
            MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
            double jumla = 0;
            connection.Open();
            MySqlCommand cmd;
            cmd = new MySqlCommand("SELECT amount FROM actual_income WHERE branch_src='"+codenumber+"' AND year="+year+" AND council_code='"+GlobalVariablesClass.council_code+"' AND region_code='"+GlobalVariablesClass.region_code+"'", connection);
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

        private int getPreparedBills(string codenumber, int year)
        {
            MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
            int count = 0;
            connection.Open();
            MySqlCommand cmd;
            cmd = new MySqlCommand("SELECT * FROM bills WHERE codenumber='" + codenumber + "' AND year=" + year + " AND council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", connection);
            MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                count = count + 1;
            }
            connection.Close();
            return count;
        }

        private double getLastPaymentMonth(string codenumber, int year)
        {
            MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
            int month = 0;
            connection.Open();
            MySqlCommand cmd;
            cmd = new MySqlCommand("SELECT month FROM actual_income WHERE branch_src='" + codenumber + "' AND year=" + year + " AND council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "' ORDER BY id DESC LIMIT 1", connection);
            MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    month = myReader.GetInt32(myReader.GetOrdinal("month"));
                }
            }
            connection.Close();
            return month;
        }
        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        private double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }
        private void getPayersInfo(string regnumber)
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            MySqlCommand cmd;
            connection.Open();
            try
            {
                cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM income_sources WHERE slabel = '" + regnumber + "' AND tax_payer='Yes' AND council_code='"+ GlobalVariablesClass.council_code + "' LIMIT 1";
                MySqlDataReader myReader = cmd.ExecuteReader();
                if (myReader.HasRows)
                {
                    //tax payer found
                    while (myReader.Read())
                    {
                        
                        fullname        = myReader.GetString(myReader.GetOrdinal("source"));
                        if (myReader["address"] != DBNull.Value)
                        {
                            address = myReader.GetString(myReader.GetOrdinal("address"));
                        }
                        else
                        {
                            address = "";
                        }
                        if (myReader["plot_number"] != DBNull.Value)
                        {
                            plot_number = myReader.GetString(myReader.GetOrdinal("plot_number"));
                        }
                        else
                        {
                            plot_number = "";
                        }
                        if (myReader["block_number"] != DBNull.Value)
                        {
                            block_number = myReader.GetString(myReader.GetOrdinal("block_number"));
                        }
                        else
                        {
                            block_number = "";
                        }
                        if (myReader["rat_value"] != DBNull.Value)
                        {
                            rat_value = myReader.GetDouble(myReader.GetOrdinal("rat_value"));
                        }
                        else
                        {
                            rat_value = 0;
                        }
                        if (myReader["tax_amount"] != DBNull.Value)
                        {
                            tax_amount = myReader.GetString(myReader.GetOrdinal("tax_amount"));
                        }
                        else
                        {
                            tax_amount = "";
                        }
                        if (myReader["matumizi"] != DBNull.Value)
                        {
                            matumizi = myReader.GetString(myReader.GetOrdinal("matumizi"));
                        }
                        else
                        {
                            matumizi = "";
                        }
                        if (myReader["slabel"] != DBNull.Value)
                        {
                            codenumber = myReader.GetString(myReader.GetOrdinal("slabel"));
                        }
                        else
                        {
                            codenumber = "";
                        }
                        if (myReader["reg_date"] != DBNull.Value)
                        {
                            reg_seconds = myReader.GetDouble(myReader.GetOrdinal("reg_date"));
                        }
                        else
                        {
                            reg_seconds = 0;
                        }
                        if (myReader["ward"] != DBNull.Value)
                        {
                            ward = myReader.GetString(myReader.GetOrdinal("ward"));
                        }
                        else
                        {
                            ward = "";
                        }
                        if (myReader["street"] != DBNull.Value)
                        {
                            street = myReader.GetString(myReader.GetOrdinal("street"));
                        }
                        else
                        {
                            street = "";
                        }
                        
                    }
                }
                else
                {
                    fullname        = "";
                    address         = "";
                    ward            = "";
                    street          = "";
                    plot_number     = "";
                    block_number    = "";
                    rat_value       = 0;
                    tax_amount      = "";
                    matumizi        = "";
                    codenumber      = "";
                    reg_seconds     = 0;
                }
            }
            catch (Exception ex)
            {
                //reset values if exception found
                MessageBox.Show(ex.Message);
                fullname        = "";
                address         = "";
                ward            = "";
                street          = "";
                plot_number     = "";
                block_number    = "";
                rat_value       = 0;
                tax_amount      = "";
                matumizi        = "";
                codenumber      = "";
                reg_seconds     = 0;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
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
                DropDownName.DataSource = dt;
                dt.Rows.Add("");
                DropDownName.ValueMember = "ward_name";
                DropDownName.DisplayMember = "ward_name";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }
    }
}

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
    public partial class AddActualIncomeForm : Form
    {
        public static DateTime referenceDate    = new DateTime(1970, 1, 1);
        public const string Alphabet            = "OLEN5BEDAS6I0USALICEAR8RHE3NI7USA4NDYDARI9U1SXIJA9NDAIMANYOVUIWABHUIKIGOMA0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZIWACHUCOMPANYLTDHDFHJDFLKASKOPDS0D3K5F9S8AQXT7C3P9H7M8CX34GBNGT9871XA";
        public AddActualIncomeForm()
        {
            InitializeComponent();
        }
        private void AddActualIncomeForm_Load(object sender, EventArgs e)
        {
            pokelewaNaLabel.Text  = GlobalVariablesClass.fullname;
            dnameLabel.Text       = GlobalVariablesClass.council_name;
            dAddreaaLabel.Text    = GlobalVariablesClass.daddress;
            dPhoneLabel.Text      = "Simu: "+GlobalVariablesClass.dphone;
            dFaxLabel.Text        = "Nukshi: "+GlobalVariablesClass.dfax;
            emailLabel.Text       = "Barua Pepe: "+GlobalVariablesClass.demail;
            setReceiptLogo(this.pictureBox1);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            PrintPanel(receiptPanel);
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(receiptPanel.Width, receiptPanel.Height);
            receiptPanel.DrawToBitmap(bmp, new Rectangle(0, 0, receiptPanel.Width, receiptPanel.Height));
            //e.Graphics.DrawImage(bmp, receiptPanel.Width, receiptPanel.Height);
            //e.Graphics.DrawImage(bmp, e.PageBounds);
            e.Graphics.DrawImage(bmp, e.MarginBounds);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            receiptPanel.CreateGraphics().DrawLines(new Pen(Color.Black), new Point[] { new Point(2, 2), new Point(2, 2) });
        }
        private void PrintPanel(Panel pnl)
        {
            try 
            {
              
                PrintDialog myPrintDialog = new PrintDialog();
                PrinterSettings values;
                values = myPrintDialog.PrinterSettings;
                myPrintDialog.Document          = printDocument1;
                printDocument1.PrintController  = new StandardPrintController();
                printDocument1.PrintPage        += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
               
               printPreviewDialog1.Document    = printDocument1;
                printPreviewDialog1.ShowDialog();
                if (myPrintDialog.ShowDialog() == DialogResult.OK) { 
                    printDocument1.Print();
                    printDocument1.Dispose();
                }
            }
            catch(Exception ex){
                MessageBox.Show(ex.Message);
            }
        }

        private void hifadhiWekaMapatoBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Double entered_amount;
            if (amountBox.Text.Length > 0 && nambaMlipaKodiEneoBox.Text.Length > 0 && tokaKwaBox.Text.Length > 0 && Double.TryParse(amountBox.Text, out entered_amount) && hundiBox.Text.Length >0 && mwamalaBenkiBox.Text.Length > 0)
            {
                string pmd = "";
                string rcpt = "";
                string raw_date = "";
                string amount = amountBox.Text;
                string nambaEneoMlipaKodi = nambaMlipaKodiEneoBox.Text;
                string tokaKwa = tokaKwaBox.Text;
                string hundi_taslimu = hundiBox.Text;
                string mwamala_benki = mwamalaBenkiBox.Text;
                DateTime tarehe = tareheDatePicker.Value;
                double dateSeconds = toSeconds(tarehe, referenceDate);
                double todaySeconds = toSeconds(DateTime.Now, referenceDate);
                int main_src = getMainSourceId(nambaEneoMlipaKodi);
                if (dateSeconds <= todaySeconds)
                {
                    if (main_src > 0)
                    {
                        string chanzo = getMainSourceName(nambaEneoMlipaKodi);
                        string mlipa_kodi_eneo = getEneoMlipaKodiName(nambaEneoMlipaKodi);
                        raw_date = tarehe.Day.ToString() + "-" + tarehe.Month.ToString() + "-" + tarehe.Year.ToString();
                        rcpt = GenerateString(8);

                        //finding payment method used
                        if (hundi_taslimu.Equals("NA") && mwamala_benki.Equals("NA"))
                        {
                            pmd = "cash";
                        }
                        else
                        {
                            pmd = "bank";
                        }

                        ///saving records into database
                        MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
                        MySql.Data.MySqlClient.MySqlCommand cmd;
                        connection.Open();
                        try
                        {
                            cmd = connection.CreateCommand();
                            cmd.CommandText = "INSERT INTO actual_income(date, user, amount, adhabu_amount, riba_amount, chq, slp, rcpt, client, pmd, branch_src, main_src, raw_date, month, year, council_code, region_code, record_time, muda) VALUES(" +
                             "'" + dateSeconds + "'," +
                             "'" + GlobalVariablesClass.username + "'," +
                             "'" + Double.Parse(amount) + "'," +
                             "'0'," +
                             "'0'," +
                             "'" + hundi_taslimu + "'," +
                             "'" + mwamala_benki + "'," +
                             "'" + rcpt + "'," +
                             "'" + tokaKwa + "'," +
                             "'" + pmd + "'," +
                             "'" + nambaEneoMlipaKodi + "'," +
                             "'" + main_src + "'," +
                             "'" + raw_date + "'," +
                             "'" + tarehe.Month.ToString() + "'," +
                             "'" + tarehe.Year.ToString() + "'," +
                             "'" + GlobalVariablesClass.council_code + "'," +
                             "'" + GlobalVariablesClass.region_code + "'," +
                             "'ofisi" + toSeconds(DateTime.Now, referenceDate) + "'," +
                             "'" + DateTime.Now.ToString() + "'" +
                            ")";
                            cmd.Parameters.AddWithValue("@date", dateSeconds);
                            cmd.Parameters.AddWithValue("@user", GlobalVariablesClass.username);
                            cmd.Parameters.AddWithValue("@amount", Double.Parse(amount));
                            cmd.Parameters.AddWithValue("@adhabu_amount", 0);
                            cmd.Parameters.AddWithValue("@riba_amount", 0);
                            cmd.Parameters.AddWithValue("@chq", hundi_taslimu);
                            cmd.Parameters.AddWithValue("@slp", mwamala_benki);
                            cmd.Parameters.AddWithValue("@rcpt", rcpt);
                            cmd.Parameters.AddWithValue("@client", tokaKwa);
                            cmd.Parameters.AddWithValue("@pmd", pmd);
                            cmd.Parameters.AddWithValue("@branch_src", nambaEneoMlipaKodi);
                            cmd.Parameters.AddWithValue("@main_src", main_src);
                            cmd.Parameters.AddWithValue("@raw_date", raw_date);
                            cmd.Parameters.AddWithValue("@month", tarehe.Month.ToString());
                            cmd.Parameters.AddWithValue("@year", tarehe.Year.ToString());
                            cmd.Parameters.AddWithValue("@council_code", GlobalVariablesClass.council_code);
                            cmd.Parameters.AddWithValue("@region_code", GlobalVariablesClass.region_code);
                            cmd.Parameters.AddWithValue("@record_time", toSeconds(DateTime.Now.Date, referenceDate));
                            cmd.Parameters.AddWithValue("@muda", DateTime.Now.Date.ToString());
                            int count_affected_rows = cmd.ExecuteNonQuery();
                            if (count_affected_rows == 0)
                            {
                                MessageBox.Show("Imeshindikana kuhifadhi taarifa, jaribu tena!");
                            }
                            else
                            {
                                //prepare receipt for print

                                chanzoLabel.Text = chanzo;
                                nambaMlipaKodiEneoLabel.Text = mlipa_kodi_eneo;
                                tareheLabel.Text = raw_date; ;
                                amountLabel.Text = String.Format("{0:0,0.00}", Double.Parse(amount));
                                tokaKwaLabel.Text = tokaKwa;
                                nambaStkLabel.Text = rcpt;
                                amountBox.Text = "";
                                //PrintPanel(receiptPanel);
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
                        MessageBox.Show("Umekosea namba ya mlipa kodi au eneo!");
                    }
                }
                else
                {
                    MessageBox.Show("Huwezi kuweka mapato ya siku ambayo hujafikia!");
                }
            }
            else 
            {
                MessageBox.Show("Hakikisha umeweka taarifa zote vizuri!");
            }
            Cursor.Current = Cursors.Default;
        }

        private double toSeconds(DateTime theDate, DateTime refDate)
        {
            Double valSeconds = (new DateTime(theDate.Year, theDate.Month, theDate.Day) - refDate).TotalSeconds - 10800;
            return valSeconds;
        }

        private int getMainSourceId(string slabel) 
        {
            int sid = 0;
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
            connection.Open();
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM income_sources JOIN actual_sources ON actual_sources.sid=income_sources.msrc_id WHERE income_sources.slabel='" + slabel + "' AND income_sources.council_code = '" + GlobalVariablesClass.council_code + "' AND income_sources.region_code ='" + GlobalVariablesClass.region_code + "' LIMIT 1";
                MySql.Data.MySqlClient.MySqlDataReader myReader2 = cmd2.ExecuteReader();
                if (myReader2.HasRows)
                {
                    while (myReader2.Read())
                    {
                        sid = myReader2.GetInt32(myReader2.GetOrdinal("sid"));
                    }

                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            return sid;
        }

        private string getMainSourceName(string slabel)
        {
            string chanzo = "";
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
            connection.Open();
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM income_sources JOIN actual_sources ON actual_sources.sid=income_sources.msrc_id WHERE income_sources.slabel='" + slabel + "' AND income_sources.council_code = '" + GlobalVariablesClass.council_code + "' AND income_sources.region_code ='" + GlobalVariablesClass.region_code + "' LIMIT 1";
                MySql.Data.MySqlClient.MySqlDataReader myReader2 = cmd2.ExecuteReader();
                if (myReader2.HasRows)
                {
                    while (myReader2.Read())
                    {
                        chanzo = myReader2.GetString(myReader2.GetOrdinal("src_name"));
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return chanzo;
        }
        private string getEneoMlipaKodiName(string slabel)
        {
            string source = "";
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
            connection.Open();
            try
            {
                MySql.Data.MySqlClient.MySqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "SELECT * FROM income_sources JOIN actual_sources ON actual_sources.sid=income_sources.msrc_id WHERE income_sources.slabel='" + slabel + "' AND income_sources.council_code = '" + GlobalVariablesClass.council_code + "' AND income_sources.region_code ='" + GlobalVariablesClass.region_code + "' LIMIT 1";
                MySql.Data.MySqlClient.MySqlDataReader myReader2 = cmd2.ExecuteReader();
                if (myReader2.HasRows)
                {
                    while (myReader2.Read())
                    {
                        source = myReader2.GetString(myReader2.GetOrdinal("source"));
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return source;
        }
        public string GenerateString(int size)
        {
            Random rand = new Random();
            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = Alphabet[rand.Next(Alphabet.Length)];
            }
            return new string(chars);
        }

        private void setReceiptLogo(PictureBox picBox) {
            try
            {
                MySqlConnection cn = new MySqlConnection(GlobalVariablesClass.connString);
                cn.Open();

                //Retrieve BLOB from database into DataSet.
                MySqlCommand cmd    = new MySqlCommand("SELECT logo_blob FROM basic_info WHERE council_code = '"+GlobalVariablesClass.council_code+"'", cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds          = new DataSet();
                da.Fill(ds, "basic_info");
                int c = ds.Tables["basic_info"].Rows.Count;

                if (c > 0)
                {   //BLOB is read into Byte array, then used to construct MemoryStream,
                    //then passed to PictureBox.
                    Byte[] byteBLOBData         = new Byte[0];
                    byteBLOBData                = (Byte[])(ds.Tables["basic_info"].Rows[c - 1]["logo_blob"]);
                    MemoryStream stmBLOBData    = new MemoryStream(byteBLOBData);
                    picBox.Image                = Image.FromStream(stmBLOBData);
                }
                cn.Close();
            }
            catch (Exception ex)
            { 
                MessageBox.Show(ex.Message); 
            }
        }
        
    }
}

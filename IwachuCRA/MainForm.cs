using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IwachuCRA
{
    public partial class MainForm : Form
    {
        public Form refFrmLogin { get; set; }
        string connectionString             = GlobalVariablesClass.connString;
        public static DateTime startDate    = new DateTime(1970, 1, 1);
        public static int dToday            = DateTime.Now.Day;
        public static int mToday            = DateTime.Now.Month;
        public static int dYear             = DateTime.Now.Year;
        public static DateTime endDate      = new DateTime(dYear, mToday, dToday);
        public static double dTotalSeconds  = (endDate - startDate).TotalSeconds;
        double modifiedSeconds              = dTotalSeconds - 10800;
        public MainForm()
        {
            InitializeComponent();
            this.FormClosing += MainForm_FormClosing;
            //disable some menus according to user level
            if (GlobalVariablesClass.level != "Admin" && GlobalVariablesClass.level !="DED")
            {
                tAARIFAZAMSINGIToolStripMenuItem.Enabled    = false;
                wATUMIAJIToolStripMenuItem.Enabled          = false;
                taarifaZilizofutwaMenu.Enabled              = false;
            }
            if (GlobalVariablesClass.level == "Valuer" || GlobalVariablesClass.level== "Mshauri" || GlobalVariablesClass.level == "Cashier") {
                orodhaVyanzoMenu.Enabled                    = false;
                orodhaMaeneoMenu.Enabled                    = false;
                orodhaMawakalaMenu.Enabled                  = false;
                orodhaVipimoMenu.Enabled                    = false;
                taarifaZaMakusanyoMenu.Enabled              = false;
                wekaMakisiomenu.Enabled                     = false;
                angaliaMakisioMenu.Enabled                  = false;
                lEJAYAMAKUSANYOToolStripMenuItem.Enabled    = false;
            }
            if (GlobalVariablesClass.level == "Cashier")
            {
                vyanzoVyaMapatoTitleMenu.Enabled    = false;
                andaaBillMenu.Enabled               = false;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!GlobalVariablesClass.council_code.Equals("")) 
            {
                //setting main form title
                this.Text = "Iwachu CRA - " + GlobalVariablesClass.username + "[" + GlobalVariablesClass.level + "]";
                makusanyoLeoLabel.Text = "Makusanyo: " + String.Format("{0:0,0.00}", getTodaysCollections(modifiedSeconds)).ToString() + "   Mapato Halisi: " + String.Format("{0:0,0.00}", getTodaysActualIncome(modifiedSeconds)).ToString();
                copyRightLabel.Text = "iCRA | " + DateTime.Now.Year.ToString() + " © Iwachu Company Ltd";
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
           var confirmResult = MessageBox.Show("Ni kweli unataka kufunga ?", "User Logout!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                this.Hide();
                this.refFrmLogin.Show();
            }
            else
            {
                e.Cancel = true;
                return;
            }
        }

        private void wEKAMAENEOYAKUKUSANYAMAPATOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //show sajili eno form
            SajiliEneoForm frm = new SajiliEneoForm();
            frm.Show();
        }

        private void tAARIFAZAMAPATOToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void printExample(object sender, EventArgs e)
        {
           //print example
            string printString = "Print contents here and there!\n"
                                +"This contents here again!";
            System.Drawing.Printing.PrintDocument p = new System.Drawing.Printing.PrintDocument();
            p.PrintPage += delegate(object sender1, System.Drawing.Printing.PrintPageEventArgs e1)
            {
                e1.Graphics.DrawString(printString, new Font("Times New Roman", 12), new SolidBrush(Color.Black), 
                    new RectangleF(0, 0, p.DefaultPageSettings.PrintableArea.Width, p.DefaultPageSettings.PrintableArea.Height));
            };

            try
            {
                PrintDialog myDialog    = new PrintDialog();
                myDialog.Document       = p;
                if (myDialog.ShowDialog() == DialogResult.OK)
                {
                    p.Print();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void wekaVyanzoMenu_Click(object sender, EventArgs e)
        {
            //show sajili vyanzo vya mapato fomu
            SajiliChanzoForm frm = new SajiliChanzoForm();
            frm.Show();
        }

        private void sajiliKataMenu_Click(object sender, EventArgs e)
        {
            SajiliKataForm frm = new SajiliKataForm();
            frm.Show();
        }

        private void sajiliMtaaKijijiMenu_Click(object sender, EventArgs e)
        {
            SajiliMtaaKijijiForm frm = new SajiliMtaaKijijiForm();
            frm.Show();
        }

        private Double getTodaysCollections(Double currentTime)
        {
            Double todayIncome = 0;
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            connection.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM income WHERE date = '" + currentTime + "' AND council_code ='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'";
            MySql.Data.MySqlClient.MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    todayIncome += myReader.GetDouble(myReader.GetOrdinal("amount"));
                }
            }
            return todayIncome;
        }
        private Double getTodaysActualIncome(Double currentTime)
        {
            Double todayIncome = 0;
            MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);
            connection.Open();
            MySql.Data.MySqlClient.MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM actual_income WHERE date = '" + currentTime + "' AND council_code ='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'";
            MySql.Data.MySqlClient.MySqlDataReader myReader = cmd.ExecuteReader();
            if (myReader.HasRows)
            {
                while (myReader.Read())
                {
                    todayIncome += myReader.GetDouble(myReader.GetOrdinal("amount"));
                }
            }
            return todayIncome;
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void sajiliWakalaMenu_Click(object sender, EventArgs e)
        {
            SajiliWakalaForm frm = new SajiliWakalaForm();
            frm.Show();
        }

        private void sajiliMlipaKodiMenu_Click(object sender, EventArgs e)
        {
            SajiliMlipaKodiForm frm = new SajiliMlipaKodiForm();
            frm.Show();
        }

        private void taarifaFupiBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current                          = Cursors.WaitCursor;
            makusanyoLeoLabel.Text                  = "Makusanyo: " + String.Format("{0:0,0.00}", getTodaysCollections(modifiedSeconds)).ToString() + "   Mapato Halisi: " + String.Format("{0:0,0.00}", getTodaysActualIncome(modifiedSeconds)).ToString();
            Cursor.Current                          = Cursors.Default;
        }

        private void sajiliKataMenu_Click_1(object sender, EventArgs e)
        {
            SajiliKataForm frm = new SajiliKataForm();
            frm.Show();
        }

        private void sajiliMtaaKijijiMenu_Click_1(object sender, EventArgs e)
        {
            SajiliMtaaKijijiForm frm = new SajiliMtaaKijijiForm();
            frm.Show();
        }

        private void wekaVyanzoMenu_Click_1(object sender, EventArgs e)
        {
            //show sajili vyanzo vya mapato fomu
            SajiliChanzoForm frm = new SajiliChanzoForm();
            frm.Show();
        }

        private void wekaMaeneoMenu_Click(object sender, EventArgs e)
        {
            SajiliEneoForm frm = new SajiliEneoForm();
            frm.Show();
        }

        private void sajiliWakalaMenu_Click_1(object sender, EventArgs e)
        {
            SajiliWakalaForm frm = new SajiliWakalaForm();
            frm.Show();
        }

        private void sajiliMlipaKodiMenu_Click_1(object sender, EventArgs e)
        {
            SajiliMlipaKodiForm frm = new SajiliMlipaKodiForm();
            frm.Show();
        }

        private void badiliTaarifaMsingiMenu_Click(object sender, EventArgs e)
        {
            UpdateBasicSettingsForm frm = new UpdateBasicSettingsForm();
            frm.Show();
        }

        private void wekaMapatoMenu_Click(object sender, EventArgs e)
        {
            AddActualIncomeForm frm = new AddActualIncomeForm();
            frm.Show();
        }

        private void orodhaKataMenu_Click(object sender, EventArgs e)
        {
            OrodhaYaKataForm frm = new OrodhaYaKataForm();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var confirmResult = MessageBox.Show("Ni kweli unataka kufunga ?", "User Logout!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmResult == DialogResult.Yes)
            {
                this.Hide();
                this.refFrmLogin.Show();
            }
           
        }

        private void bADILINEMBOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BadiliNemboForm frm = new BadiliNemboForm();
            frm.Show();
        }

        private void orodhaMitaaVijijiMenu_Click(object sender, EventArgs e)
        {
            OrodhaMitaaForm frm = new OrodhaMitaaForm();
            frm.Show();
        }

        private void orodhaVyanzoMenu_Click(object sender, EventArgs e)
        {
            OrodhaYaVyanzoForm frm = new OrodhaYaVyanzoForm();
            frm.Show();
        }

        private void orodhaMaeneoMenu_Click(object sender, EventArgs e)
        {
            OrodhaYaMaeneoForm frm = new OrodhaYaMaeneoForm();
            frm.Show();
        }

        private void orodhaMawakalaMenu_Click(object sender, EventArgs e)
        {
            OrodhaYaMawakalaForm frm = new OrodhaYaMawakalaForm();
            frm.Show();
        }

        private void oRODHAYAWOTEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrodhaWalipaKodiForm frm = new OrodhaWalipaKodiForm();
            frm.Show();
        }

        private void wALIOTHAMINIWAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrodhaWaliothaminiwaForm frm = new OrodhaWaliothaminiwaForm();
            frm.Show();
        }

        private void kUTOKANANATAREHEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrodhaKwaTareheForm frm = new OrodhaKwaTareheForm();
            frm.Show();
        }

        private void orodhaVipimoMenu_Click(object sender, EventArgs e)
        {
            OrodhaVipimoForm frm = new OrodhaVipimoForm();
            frm.Show();
        }

        private void sajiliWatumiajiMenu_Click(object sender, EventArgs e)
        {
            RegisterUserForm frm = new RegisterUserForm();
            frm.Show();
        }

        private void orodhaWatumiajiMenu_Click(object sender, EventArgs e)
        {
            OrodhaWatumiajiForm frm = new OrodhaWatumiajiForm();
            frm.Show();
        }

        private void vyanzoVyaMapatoTitleMenu_Click(object sender, EventArgs e)
        {

        }

        private void andaaBillMenu_Click(object sender, EventArgs e)
        {
            AndaaBillForm frm = new AndaaBillForm();
            frm.Show();
        }

        private void wekaMakisiomenu_Click(object sender, EventArgs e)
        {
            AndaaMakisioForm frm = new AndaaMakisioForm();
            frm.Show();
        }

        private void angaliaMakisioMenu_Click(object sender, EventArgs e)
        {
            AngaliaMakisioForm frm = new AngaliaMakisioForm();
            frm.Show();
        }

        private void kWATAREHEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakusanyoKwaMiamalaForm frm = new MakusanyoKwaMiamalaForm();
            frm.Show();
        }

        private void kWAJUMLAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakusanyoKwaJumlaForm frm = new MakusanyoKwaJumlaForm();
            frm.Show();
        }

        private void kWAMWAKAWAFEDHAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MakusanyoKwaMwakaWaFedhaForm frm = new MakusanyoKwaMwakaWaFedhaForm();
            frm.Show();
        }

        private void taarifaZaWakusanyajiMenu_Click(object sender, EventArgs e)
        {
            TaarifaZaWakusanyajiForm frm = new TaarifaZaWakusanyajiForm();
            frm.Show();
        }

        private void aNGALIAMIAMALAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MapatoHalisiKwaMiamalaForm frm = new MapatoHalisiKwaMiamalaForm();
            frm.Show();
        }

        private void kWAJUMLAVYANZOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaarifaMapatoKwaJumlaForm frm = new TaarifaMapatoKwaJumlaForm();
            frm.Show();
        }

        private void taarifaZawalipaKodiMenu_Click(object sender, EventArgs e)
        {
            TaarifaZaWalipaKodiForm frm = new TaarifaZaWalipaKodiForm();
            frm.Show();
        }

        private void ulipajiWaMawakalaMenu_Click(object sender, EventArgs e)
        {
            TaxPayersWakalaReportsForm frm = new TaxPayersWakalaReportsForm();
            frm.Show();
        }

        private void taarifaZilizofutwaMenu_Click(object sender, EventArgs e)
        {
            TaarifaZilizofutwaForm frm = new TaarifaZilizofutwaForm();
            frm.Show();
        }

        private void lEJAYAMAPATOHALISIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LejaMapatoHalisiForm frm = new LejaMapatoHalisiForm();
            frm.Show();
        }

        private void lEJAYAMAKUSANYOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LejaYaMakusanyoForm frm = new LejaYaMakusanyoForm();
            frm.Show();
        }

        private void angaliaTaarifaMsingiMenu_Click(object sender, EventArgs e)
        {
            TaarifaZaMsingiForm frm = new TaarifaZaMsingiForm();
            frm.Show();
        }
    }
}

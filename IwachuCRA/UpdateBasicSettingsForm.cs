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
    public partial class UpdateBasicSettingsForm : Form
    {
        public UpdateBasicSettingsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                pictureBox1.Image = new Bitmap(open.FileName);
                // image file path
                textBox1.Text = open.FileName;
            } 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
            MySql.Data.MySqlClient.MySqlCommand cmd;
            FileStream fs;
            BinaryReader br;

            try
            {
                if (textBox1.Text.Length > 0)
                {
                    string FileName = textBox1.Text;
                    byte[] ImageData;
                    fs = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                    br = new BinaryReader(fs);
                    ImageData = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();

                    string CmdString = "INSERT INTO test_table(logo) VALUES(@logo)";
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(CmdString, con);
                    cmd.Parameters.Add("@logo", MySql.Data.MySqlClient.MySqlDbType.Blob);
                   
                    cmd.Parameters["@logo"].Value = ImageData;

                    con.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        MessageBox.Show("Image saved sucessfully!");
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Incomplete data!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection cn = new MySqlConnection(GlobalVariablesClass.connString);
                cn.Open();

                //Retrieve BLOB from database into DataSet.
                MySqlCommand cmd    = new MySqlCommand("SELECT logo FROM test_table WHERE id = 2", cn);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataSet ds          = new DataSet();
                da.Fill(ds, "test_table");
                int c = ds.Tables["test_table"].Rows.Count;

                if (c > 0)
                {   //BLOB is read into Byte array, then used to construct MemoryStream,
                    //then passed to PictureBox.
                    Byte[] byteBLOBData = new Byte[0];
                    byteBLOBData = (Byte[])(ds.Tables["test_table"].Rows[c - 1]["logo"]);
                    MemoryStream stmBLOBData = new MemoryStream(byteBLOBData);
                    pictureBox2.Image = Image.FromStream(stmBLOBData);
                }
                cn.Close();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, new Rectangle(0, 0, panel1.Width, panel1.Height));
            e.Graphics.DrawImage(bmp, panel1.Width, panel1.Height);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            panel1.CreateGraphics().DrawLines(new Pen(Color.Black),
              new Point[] { new Point(10, 10), new Point(50, 50) });
        }
        private void PrintPanel(Panel pnl)
        {
            PrintDialog myPrintDialog = new PrintDialog();
            PrinterSettings values;
            values = myPrintDialog.PrinterSettings;
            myPrintDialog.Document = printDocument1;
            printDocument1.PrintController = new StandardPrintController();
            printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.Show();
            printDocument1.Print();
            printDocument1.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PrintPanel(panel1);
        }
    }
}

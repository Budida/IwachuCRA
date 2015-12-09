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

namespace IwachuCRA
{
    public partial class BadiliNemboForm : Form
    {
        public BadiliNemboForm()
        {
            InitializeComponent();
        }

        private void chaguaPichaBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                this.previewPictureBox.Image = new Bitmap(open.FileName);
                // image file path
                textBox1.Text = open.FileName;
            }
        }

        private void chaguaSahihiBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg; *.jpeg; *.gif; *.bmp; *.png";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box
                this.sahihiPreviewPictureBox.Image = new Bitmap(open.FileName);
                // image file path
                textBox2.Text = open.FileName;
            }
        }
        private void hifadhiNemboBtn_Click(object sender, EventArgs e)
        {
            MySql.Data.MySqlClient.MySqlConnection con = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
            MySql.Data.MySqlClient.MySqlCommand cmd;
            FileStream fs, fs2;
            BinaryReader br, br2;

            try
            {
                if (textBox1.Text.Length > 0 && textBox2.Text.Length > 0)
                {
                    string FileName = textBox1.Text;
                    string FileName2 = textBox2.Text;
                    byte[] ImageData, sahihiImageData;
                    fs              = new FileStream(FileName, FileMode.Open, FileAccess.Read);
                    fs2             = new FileStream(FileName2, FileMode.Open, FileAccess.Read);
                    br              = new BinaryReader(fs);
                    br2             = new BinaryReader(fs2);
                    ImageData       = br.ReadBytes((int)fs.Length);
                    sahihiImageData = br2.ReadBytes((int)fs2.Length);
                    br.Close();
                    fs.Close();
                    br2.Close();
                    fs2.Close();

                    string CmdString    = "UPDATE basic_info SET logo_blob = @logo_blob, dedsign_blob=@dedsign_blob WHERE council_code = '" + GlobalVariablesClass.council_code + "'";
                    cmd                 = new MySql.Data.MySqlClient.MySqlCommand(CmdString, con);
                    cmd.Parameters.Add("@logo_blob", MySql.Data.MySqlClient.MySqlDbType.Blob);
                    cmd.Parameters.Add("@dedsign_blob", MySql.Data.MySqlClient.MySqlDbType.Blob);
                    cmd.Parameters["@logo_blob"].Value      = ImageData;
                    cmd.Parameters["@dedsign_blob"].Value   = sahihiImageData;

                    con.Open();
                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        MessageBox.Show("Umefanikiwa Kubadili nembo!");
                    }
                    con.Close();
                }
                else
                {
                    MessageBox.Show("Imeshindikana jaribu tena!!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}

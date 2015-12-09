using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IwachuCRA
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string status = Properties.Settings.Default.active;
            if (status == "Yes")
            {
                MessageBox.Show("All settings are setup now, continue!");
            }
            else
            {
                string ip = ipbox.Text;
                string db = dbbox.Text;
                string dbuser = userbox.Text;
                string pass = pasbox.Text;
                if (ip.Length > 0 && db.Length > 0 && dbuser.Length > 0 && pass.Length > 0)
                {
                    Properties.Settings.Default.system_ip = ip;
                    Properties.Settings.Default.system_db = db;
                    Properties.Settings.Default.db_user = dbuser;
                    Properties.Settings.Default.db_pass = pass;
                    Properties.Settings.Default.Save();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Weka taarifa zote vizuri!");
                }
            }
           
        }
    }
}

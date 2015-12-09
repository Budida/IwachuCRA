using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IwachuCRA
{
    public partial class RegisterUserForm : Form
    {
        public RegisterUserForm()
        {
            InitializeComponent();
            FillDropDownListLevels("SELECT level FROM user_levels WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", this.levelsDropDown);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string fullname = fullNameBox.Text;
            string username = userNameBox.Text;
            string email    = emailBox.Text;
            string phone    = simuBox.Text;
            string level    = levelsDropDown.SelectedValue.ToString();
            string password = "123tz";
            string hashedPassword;
            //HASH PASSWORD
            using (MD5 md5Hash = MD5.Create())
            {
                hashedPassword = GetMd5Hash(md5Hash, password);
            }
            if (fullname.Length >0 && username.Length >0 && email.Length >0 && phone.Length >0 && level.Length>0)
            {
                MySqlConnection connection = new MySqlConnection(GlobalVariablesClass.connString);
                MySqlCommand cmd;
                connection.Open();
                try
                {
                    cmd = connection.CreateCommand();
                    cmd.CommandText = "INSERT INTO users (fullname, email, username, password, level, phone, user, council_code, region_code) VALUES("+
                     "'"+fullname+"',"+
                     "'"+email+"'," +
                     "'" +username + "'," +
                     "'" + hashedPassword + "'," +
                     "'" + level + "'," +
                     "'" + phone + "'," +
                     "'" + GlobalVariablesClass.fullname + "'," +
                     "'" + GlobalVariablesClass.council_code + "'," +
                     "'" + GlobalVariablesClass.region_code + "'" +
                    ")";
                    cmd.Parameters.AddWithValue("@fullname", fullname);
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@level", level);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@user", GlobalVariablesClass.fullname);
                    cmd.Parameters.AddWithValue("@council_code", GlobalVariablesClass.council_code);
                    cmd.Parameters.AddWithValue("@region_code", GlobalVariablesClass.region_code);
                    int affectedRows = cmd.ExecuteNonQuery();
                    if (affectedRows > 0)
                    {
                        fullNameBox.Text    = "";
                        userNameBox.Text    = "";
                        emailBox.Text       = "";
                        simuBox.Text        = "";
                        MessageBox.Show("Umefanikiwa kusajili!");
                    }
                    else
                    {
                        MessageBox.Show("Imeshindikana kusajili, jaribu tena!");
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
                MessageBox.Show("Weka Taarifa zote!");
            }
            Cursor.Current = Cursors.Default;
        }
        public static void FillDropDownListLevels(string Query, System.Windows.Forms.ComboBox DropDownName)
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
                DropDownName.ValueMember = "level";
                DropDownName.DisplayMember = "level";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}

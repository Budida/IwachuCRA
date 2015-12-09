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
    public partial class SajiliEneoForm : Form
    {
        TextBox[] vipimo;
        TextBox[] tozo;
        bool checkValue;
        public SajiliEneoForm()
        {
            InitializeComponent();
            FillDropDownListKata("SELECT * FROM wards WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", kataDropDown);
            FillDropDownListMtaaKijiji("SELECT * FROM streets WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", mtaaKijijiDropDown);
            FillDropDownListVyanzo("SELECT * FROM actual_sources WHERE council_code='" + GlobalVariablesClass.council_code + "' AND region_code='" + GlobalVariablesClass.region_code + "'", chanzoMapatoDropDown);
        }

        private void SajiliEneoForm_Load(object sender, EventArgs e)
        {
           //form load function
            //check is form is opened for editing
            int eneoId = OrodhaYaMaeneoForm.eneo_id;
            if (eneoId > 0)
            {
                jinaEneoTextBox.Text                = OrodhaYaMaeneoForm.jinaEneo;
                nambaEneoTextBox.Text               = OrodhaYaMaeneoForm.nambaEneo;
                maxAmountTextBox.Text               = OrodhaYaMaeneoForm.max_amount;
                kataDropDown.SelectedText           = OrodhaYaMaeneoForm.wardname;
                kataDropDown.SelectedValue          = OrodhaYaMaeneoForm.wardname;
                mtaaKijijiDropDown.SelectedText     = OrodhaYaMaeneoForm.streetname;
                mtaaKijijiDropDown.SelectedValue    = OrodhaYaMaeneoForm.streetname;
                chanzoMapatoDropDown.SelectedText   = OrodhaYaMaeneoForm.src_name;
                chanzoMapatoDropDown.SelectedValue  = OrodhaYaMaeneoForm.main_source_id;
                
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
                DropDownName.DataSource     = dt;
                DropDownName.ValueMember    = "street_name";
                DropDownName.DisplayMember  = "street_name";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        public static void FillDropDownListVyanzo(string Query, System.Windows.Forms.ComboBox DropDownName)
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
                DropDownName.ValueMember = "sid";
                DropDownName.DisplayMember = "src_name";
                cn.Close();
            }
            Cursor.Current = Cursors.Default;
        }

        private void idadiVipimoTExtBox_TextChanged(object sender, EventArgs e)
        {
            int idadi_vipimo;
            if (idadiVipimoTExtBox.Text.Equals("") || !int.TryParse(idadiVipimoTExtBox.Text, out idadi_vipimo)) 
            {
                if(int.TryParse(idadiVipimoTExtBox.Text, out idadi_vipimo) || (vipimo != null))
                {
                    //MessageBox.Show("Weka Idadi ya Vipimo!");
                    if (vipimo.Length > 0)
                    {
                        for (int i = 0; i < vipimo.Length; i++)
                        { 
                            //remove vipimo and tozo boxes
                            vipimoPanel.Controls.Remove(vipimo[i]);
                            vipimo[i].Dispose();
                            tozoPanel.Controls.Remove(tozo[i]);
                            tozo[i].Dispose();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Weka idadi kwa namba siyo alama au herufi!");
                }
            }
            else 
            {
                //futa kwanza vipimo vilivyokuwepo kabla ya kuweka textboxes zingine
                if ((vipimo != null)) 
                { 
                    if(vipimo.Length > 0)
                    {
                        for (int i = 0; i < vipimo.Length; i++)
                        {
                            //remove vipimo and tozo boxes
                            vipimoPanel.Controls.Remove(vipimo[i]);
                            vipimo[i].Dispose();
                            tozoPanel.Controls.Remove(tozo[i]);
                            tozo[i].Dispose();
                        }
                    }
                }
                
                int vipimoIdadi = int.Parse(idadiVipimoTExtBox.Text);
                vipimo          = new TextBox[vipimoIdadi];
                tozo            = new TextBox[vipimoIdadi];
                for (int i = 0; i < vipimoIdadi; i++)
                {
                    vipimo[i]       = new TextBox();
                    tozo[i]         = new TextBox();
                    vipimo[i].Width = 150;
                    tozo[i].Width   = 150;
                    if (i > 0)
                    {
                        vipimo[i].Top   = vipimo[i - 1].Bottom;
                        tozo[i].Top     = tozo[i - 1].Bottom;
                    }
                    vipimoPanel.Controls.Add(vipimo[i]);
                    tozoPanel.Controls.Add(tozo[i]);
                }
            }
        }

        private void hifadhiEneoBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            //process save eneo
            if (jinaEneoTextBox.Text.Equals("") || nambaEneoTextBox.Text.Equals("") || idadiVipimoTExtBox.Text.Equals(""))
            {
                MessageBox.Show("Weka taarifa zote!");
            }
            else
            {
                int idadi_vipimo;
                double maximum_amount;
                if (int.TryParse(idadiVipimoTExtBox.Text, out idadi_vipimo) && Double.TryParse(maxAmountTextBox.Text, out maximum_amount))
                {
                    //check vipimo vyote kama vimewekwa
                    checkValue = true;
                    int countVipimo = int.Parse(idadiVipimoTExtBox.Text);
                    for (int i = 0; i < countVipimo; i++)
                    {

                        if (vipimo[i].Text.Equals(""))
                        {
                            checkValue = false;
                        }
                    }
                     int tozo_given;
                    //check tozos are filled
                    for (int i = 0; i < countVipimo; i++)
                    {

                        if (tozo[i].Text.Equals("") || !int.TryParse(tozo[i].Text, out tozo_given))
                        {
                            checkValue = false;
                        }
                    }

                    if (checkValue)
                    {
                        //save eneo into database
                        string source           = jinaEneoTextBox.Text;
                        string ward             = kataDropDown.SelectedValue.ToString();
                        string street           = mtaaKijijiDropDown.SelectedValue.ToString();
                        string msrc_id          = chanzoMapatoDropDown.SelectedValue.ToString();
                        string max_amount       = maxAmountTextBox.Text;
                        string slabel           = nambaEneoTextBox.Text;
                       //insert data into database
                        MySql.Data.MySqlClient.MySqlConnection connection = new MySql.Data.MySqlClient.MySqlConnection(GlobalVariablesClass.connString);
                        MySql.Data.MySqlClient.MySqlCommand cmd;
                        MySql.Data.MySqlClient.MySqlCommand cmd2;
                        MySql.Data.MySqlClient.MySqlCommand cmd3;
                        MySql.Data.MySqlClient.MySqlCommand cmd4;
                        connection.Open();
                        try
                        {
                            //insert new record if it is not editing session
                            if (OrodhaYaMaeneoForm.eneo_id == 0)
                            {
                                cmd4 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM income_sources WHERE slabel='" + slabel + "' AND region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "'", connection);
                                MySql.Data.MySqlClient.MySqlDataReader myReader = cmd4.ExecuteReader();
                                if (myReader.HasRows)
                                {
                                    MessageBox.Show("Namba ya Eneo imeshatumika kwenye eneo jingine!");
                                    connection.Close();
                                }
                                else
                                {
                                    connection.Close();
                                    connection.Open();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "INSERT INTO income_sources (" +
                                       "source," +
                                       "slabel," +
                                        "ward," +
                                        "street," +
                                        "max_amount," +
                                        "msrc_id," +
                                        "council_code," +
                                        "region_code" +
                                    ") VALUES (" +
                                        "'" + source + "'," +
                                        "'" + slabel + "'," +
                                        "'" + ward + "'," +
                                        "'" + street + "'," +
                                        "'" + Double.Parse(max_amount) + "'," +
                                        "'" + int.Parse(msrc_id) + "'," +
                                        "'" + GlobalVariablesClass.council_code + "'," +
                                        "'" + GlobalVariablesClass.region_code + "'" +
                                    ")";
                                    cmd.Parameters.AddWithValue("@source", source);
                                    cmd.Parameters.AddWithValue("@ward", ward);
                                    cmd.Parameters.AddWithValue("@street", street);
                                    cmd.Parameters.AddWithValue("@max_amount", Double.Parse(max_amount));
                                    cmd.Parameters.AddWithValue("@msrc_id", int.Parse(msrc_id));
                                    cmd.Parameters.AddWithValue("@council_code", GlobalVariablesClass.council_code);
                                    cmd.Parameters.AddWithValue("@region_code", GlobalVariablesClass.region_code);
                                    cmd.ExecuteNonQuery();

                                    //insert vipimo
                                    for (int i = 0; i < countVipimo; i++)
                                    {
                                        cmd2 = connection.CreateCommand();
                                        cmd2.CommandText = "INSERT INTO vipimo(jina, tozo, eneo, council_code, region_code) VALUES(" +
                                        "'" + vipimo[i].Text + "'," +
                                        "'" + Double.Parse(tozo[i].Text) + "'," +
                                        "'" + source + "'," +
                                        "'" + GlobalVariablesClass.council_code + "'," +
                                        "'" + GlobalVariablesClass.region_code + "'" +
                                        ")";
                                        cmd2.Parameters.AddWithValue("@jina", vipimo[i].Text);
                                        cmd2.Parameters.AddWithValue("@tozo", Double.Parse(tozo[i].Text));
                                        cmd2.Parameters.AddWithValue("@source", source);
                                        cmd2.Parameters.AddWithValue("@council_code", GlobalVariablesClass.council_code);
                                        cmd2.Parameters.AddWithValue("@region_code", GlobalVariablesClass.region_code);
                                        cmd2.ExecuteNonQuery();
                                        long id = cmd2.LastInsertedId;
                                        cmd3 = connection.CreateCommand();
                                        cmd3.CommandText = "INSERT INTO vipimo_sources(source_code, kipimo_id) VALUES(" +
                                        "'" + slabel + "'," +
                                        "'" + id + "'" +
                                        ")";
                                        cmd3.Parameters.AddWithValue("@source_code", slabel);
                                        cmd3.Parameters.AddWithValue("@kipimo_id", id);
                                        cmd3.ExecuteNonQuery();
                                    }
                                    MessageBox.Show("Umefanikiwa kusajili Eneo");
                                    jinaEneoTextBox.Text = "";
                                    maxAmountTextBox.Text = "";
                                }
                            }
                            else 
                            { 
                            //edit eneo record
                                cmd4 = new MySql.Data.MySqlClient.MySqlCommand("SELECT * FROM income WHERE s_label='" + slabel + "' AND region_code='" + GlobalVariablesClass.region_code + "' AND council_code='" + GlobalVariablesClass.council_code + "'", connection);
                                MySql.Data.MySqlClient.MySqlDataReader myReader = cmd4.ExecuteReader();
                                if (myReader.HasRows) //if eneo tayari lina mapato usibadili namba ya eneo, retain the existing one
                                {
                                    connection.Close();
                                    slabel = OrodhaYaMaeneoForm.nambaEneo;
                                }
                                    connection.Close();
                                    connection.Open();
                                    cmd = connection.CreateCommand();
                                    cmd.CommandText = "UPDATE income_sources " +
                                       " SET source ='" + source + "'," +
                                       "slabel ='" + slabel + "'," +
                                        "ward = '" + ward + "'," +
                                        "street ='" + street + "'," +
                                        "max_amount ='" + Double.Parse(max_amount) + "'," +
                                        "msrc_id ='" + int.Parse(msrc_id) + "' WHERE id='" + OrodhaYaMaeneoForm.eneo_id + "' ";
                                    cmd.Parameters.AddWithValue("@source", source);
                                    cmd.Parameters.AddWithValue("@ward", ward);
                                    cmd.Parameters.AddWithValue("@street", street);
                                    cmd.Parameters.AddWithValue("@max_amount", Double.Parse(max_amount));
                                    cmd.Parameters.AddWithValue("@msrc_id", int.Parse(msrc_id));
                                    cmd.ExecuteNonQuery();

                                    //insert vipimo
                                    for (int i = 0; i < countVipimo; i++)
                                    {
                                        cmd2 = connection.CreateCommand();
                                        cmd2.CommandText = "INSERT INTO vipimo(jina, tozo, eneo, council_code, region_code) VALUES(" +
                                        "'" + vipimo[i].Text + "'," +
                                        "'" + Double.Parse(tozo[i].Text) + "'," +
                                        "'" + source + "'," +
                                        "'" + GlobalVariablesClass.council_code + "'," +
                                        "'" + GlobalVariablesClass.region_code + "'" +
                                        ")";
                                        cmd2.Parameters.AddWithValue("@jina", vipimo[i].Text);
                                        cmd2.Parameters.AddWithValue("@tozo", Double.Parse(tozo[i].Text));
                                        cmd2.Parameters.AddWithValue("@source", source);
                                        cmd2.Parameters.AddWithValue("@council_code", GlobalVariablesClass.council_code);
                                        cmd2.Parameters.AddWithValue("@region_code", GlobalVariablesClass.region_code);
                                        cmd2.ExecuteNonQuery();
                                        long id = cmd2.LastInsertedId;
                                        cmd3 = connection.CreateCommand();
                                        cmd3.CommandText = "INSERT INTO vipimo_sources(source_code, kipimo_id) VALUES(" +
                                        "'" + slabel + "'," +
                                        "'" + id + "'" +
                                        ")";
                                        cmd3.Parameters.AddWithValue("@source_code", slabel);
                                        cmd3.Parameters.AddWithValue("@kipimo_id", id);
                                        cmd3.ExecuteNonQuery();
                                    }
                                    MessageBox.Show("Umefanikiwa kubadili taarifa za Eneo");
                                //jinaEneoTextBox.Text = "";
                                // maxAmountTextBox.Text = "";
                                OrodhaYaMaeneoForm.eneo_id = 0;

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
                        MessageBox.Show("Weka Vipimo na Tozo Zake kwa usahihi!");
                    }
                }
                else
                {
                    MessageBox.Show("Weka idadi ya vipimo na Kiwango cha mwisho kwa namba, siyo herufi au alama yoyote!");
                }
            }
            Cursor.Current = Cursors.Default;
        }
    }
    }

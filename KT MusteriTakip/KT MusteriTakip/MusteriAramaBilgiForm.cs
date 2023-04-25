using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace KT_MusteriTakip
{
    public partial class MusteriAramaBilgiForm : Form
    {
        public string musteriid = string.Empty;
        public string cihazid = string.Empty;
        public string borcid = string.Empty;
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public MusteriAramaBilgiForm()
        {
            InitializeComponent();
        }

        private void MusteriAramaBilgiForm_Load(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(musteriid) || String.IsNullOrEmpty(cihazid))
            {
                return;
            }
            else
            {

                string querry4 = "select cihaz.chz_live ";
                querry4 += "from dbo.cihaz ";
                querry4 += "where cihaz.chz_id = @chz_id";
                SqlCommand cmd4 = new SqlCommand(querry4, sqlcon);
                cmd4.Parameters.AddWithValue("@chz_id", cihazid);
                sqlcon.Open();
                SqlDataAdapter sdr4 = new SqlDataAdapter(cmd4);
                DataTable dt4 = new DataTable();
                sdr4.Fill(dt4);
                sqlcon.Close();
                if (dt4.Rows[0]["chz_live"] != DBNull.Value)
                {
                    if (dt4.Rows[0]["chz_live"].ToString() == "False")
                    {
                        btnArsiv.Text = "Arşiv Geri Al";
                    }
                }



                string querry = "select musteri.m_adsoyad,m_tel ";
                querry += "from dbo.musteri ";
                querry += "where musteri.m_id = @m_id";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                cmd.Parameters.AddWithValue("@m_id", musteriid);
                sqlcon.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                sqlcon.Close();
                if(dt.Rows.Count > 0)
                {
                    txtadsoyad.Text = dt.Rows[0]["m_adsoyad"].ToString();
                    txttel.Text = dt.Rows[0]["m_tel"].ToString();
                }
                


                string querry2 = "select cihaz.chz_ad,chz_ariza,chz_fiyat,chz_son,chz_geltarih,chz_gittarih ";
                querry2 += "from dbo.cihaz ";
                querry2 += "where cihaz.chz_id = @chz_id";
                SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
                cmd2.Parameters.AddWithValue("@chz_id", cihazid);
                sqlcon.Open();
                SqlDataAdapter sdr2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                sdr2.Fill(dt2);
                sqlcon.Close();
                txtcihazad.Text = dt2.Rows[0]["chz_ad"].ToString();
                txtariza.Text = dt2.Rows[0]["chz_ariza"].ToString();
                txtfiyat.Text = dt2.Rows[0]["chz_fiyat"].ToString();
                dateTimePicker1.Value = (DateTime)dt2.Rows[0]["chz_geltarih"];
                if (dt2.Rows[0]["chz_gittarih"] != DBNull.Value)
                {
                    dateTimePicker2.Value = (DateTime)dt2.Rows[0]["chz_gittarih"];
                }

                string son = dt2.Rows[0]["chz_son"].ToString();
                if (String.IsNullOrEmpty(son))
                {
                    txtson.Text = son;
                }
                else
                {
                    string[] ara = son.Split('&');
                    if (ara.Length > 1)
                    {
                        txtson.Text = ara[1];
                        string[] checks = ara[0].Split(',');
                        foreach (string check in checks)
                        {
                            string[] str = check.Split('-');
                            if (str[0] == "101")
                            {
                                checkBox1.Checked = true;
                                txt1.Text = str[1];
                            }

                            if (str[0] == "102")
                            {
                                checkBox2.Checked = true;
                                txt2.Text = str[1];
                            }

                            if (str[0] == "103")
                            {
                                checkBox3.Checked = true;
                                txt3.Text = str[1];
                            }

                            if (str[0] == "104")
                            {
                                checkBox4.Checked = true;
                                txt4.Text = str[1];
                            }

                            if (str[0] == "105")
                            {
                                checkBox5.Checked = true;
                                txt5.Text = str[1];
                            }

                            if (str[0] == "106")
                            {
                                checkBox6.Checked = true;
                                txt6.Text = str[1];
                            }
                            if (str[0] == "107")
                            {
                                checkBox7.Checked = true;
                                txt7.Text = str[1];
                            }
                            if (str[0] == "108")
                            {
                                checkBox8.Checked = true;
                                txt8.Text = str[1];
                            }
                            if (str[0] == "109")
                            {
                                checkBox9.Checked = true;
                                txt9.Text = str[1];
                            }

                        }
                    }

                }
            }
            string querry3 = "select borc.m_id,borc_borcid ";
            querry3 += "from dbo.borc ";
            querry3 += "where borc.m_id = @m_id";
            SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
            cmd3.Parameters.AddWithValue("@m_id", musteriid);
            sqlcon.Open();
            SqlDataAdapter sdr3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            sdr3.Fill(dt3);
            sqlcon.Close();
            if (dt3.Rows.Count > 0)
            {
                foreach (DataRow dtRow in dt3.Rows)
                {
                    string borcson = dtRow["borc_borcid"].ToString();
                    string[] borc = borcson.Split(',');
                    if (borc[0] == "cihaz" && borc[1] == cihazid)
                        checkBoxborc.Checked = true;

                }
            }

            if (!String.IsNullOrEmpty(borcid))
            {
                tableLayoutPanel6.Controls.Remove(checkBoxborc);
                //checkBoxborc.Visible = false;
                Label labelborc= new Label();
                labelborc.Location = new Point(3, 54);
                labelborc.Text = "Borç Fiyat :";
                labelborc.AutoSize = true;
                labelborc.TextAlign = ContentAlignment.MiddleCenter;
                labelborc.Dock = DockStyle.Fill;
                tableLayoutPanel6.Controls.Add(labelborc);

                btnArsiv.Text = "Borç ve Cihazı Arşivle";

                labelborc2.Visible = true;
                txtborcbilgi.Visible = true;
                txtborcfiyat.Visible = true;

                string querry = "select borc.borc_bilgi, borc_fiyat ";
                querry += "from dbo.borc ";
                querry += "where borc.borc_id = @borc_id";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                cmd.Parameters.AddWithValue("@borc_id", borcid);
                sqlcon.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                sqlcon.Close();
                if (dt.Rows.Count > 0)
                {
                    txtborcbilgi.Text = dt.Rows[0]["borc_bilgi"].ToString();
                    txtborcfiyat.Text = dt.Rows[0]["borc_fiyat"].ToString();
                    
                }

               
            }
        }


        private void dataKaydet(string not)
        {

            sqlcon.Open();
            string querry3 = "UPDATE musteri SET m_adsoyad = @m_adsoyad ,";
            querry3 += "m_tel = @m_tel where m_id = @m_id";
            SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
            cmd3.Parameters.AddWithValue("@m_adsoyad", txtadsoyad.Text.Trim());
            cmd3.Parameters.AddWithValue("@m_tel", txttel.Text.Trim());
            cmd3.Parameters.AddWithValue("@m_id", musteriid.Trim());
            cmd3.ExecuteNonQuery();
            sqlcon.Close();

            string son = "&";
            son += txtson.Text.Trim();
            if (not == "İade")
                son += Environment.NewLine + "İADE EDİLECEK";
            if (checkBox1.Checked)
                son = "101-" + txt1.Text + "," + son;
            if (checkBox2.Checked)
                son = "102-" + txt2.Text + "," + son;
            if (checkBox3.Checked)
                son = "103-" + txt3.Text + "," + son;
            if (checkBox4.Checked)
                son = "104-" + txt4.Text + "," + son;
            if (checkBox5.Checked)
                son = "105-" + txt5.Text + "," + son;
            if (checkBox6.Checked)
                son = "106-" + txt6.Text + "," + son;
            if (checkBox7.Checked)
                son = "107-" + txt7.Text + "," + son;
            if (checkBox8.Checked)
                son = "108-" + txt8.Text + "," + son;
            if (checkBox9.Checked)
                son = "109-" + txt9.Text + "," + son;

            sqlcon.Open();
            string querry = "UPDATE cihaz SET chz_fiyat = @chz_fiyat, chz_son = @chz_son, ";
            querry += "chz_ad = @chz_ad ,chz_ariza = @chz_ariza, chz_geltarih = @chz_geltarih, ";
            if (not == "Arşiv")
                querry += "chz_gittarih = @chz_gittarih, chz_live = @chz_live where chz_id = @chz_id";
            else
                querry += "chz_gittarih = @chz_gittarih where chz_id = @chz_id";

            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            if (String.IsNullOrEmpty(txtfiyat.Text)) // AD
                cmd.Parameters.AddWithValue("@chz_fiyat", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@chz_fiyat", txtfiyat.Text.Trim());
            cmd.Parameters.AddWithValue("@chz_son", son);
            if (not == "Arşiv")
            {
                cmd.Parameters.AddWithValue("@chz_live", false);
            }

            cmd.Parameters.AddWithValue("@chz_ad", txtcihazad.Text.Trim());

            cmd.Parameters.AddWithValue("@chz_ariza", txtariza.Text.Trim());
            string sqlDate1 = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");
            string sqlDate2 = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");

            cmd.Parameters.AddWithValue("@chz_geltarih", sqlDate1);

            cmd.Parameters.AddWithValue("@chz_gittarih", sqlDate2);
            cmd.Parameters.AddWithValue("@chz_id", cihazid);
            cmd.ExecuteNonQuery();
            sqlcon.Close();

            if (checkBoxborc.Checked)
            {
                bool borckontrol = true;
                
                string querry4 = "select borc.m_id,borc_borcid ";
                querry4 += "from dbo.borc ";
                querry4 += "where borc.m_id = @m_id";
                SqlCommand cmd4 = new SqlCommand(querry4, sqlcon);
                cmd4.Parameters.AddWithValue("@m_id", musteriid);
                sqlcon.Open();
                SqlDataAdapter sdr4 = new SqlDataAdapter(cmd4);
                DataTable dt4 = new DataTable();
                sdr4.Fill(dt4);
                sqlcon.Close();
                if (dt4.Rows.Count > 0)
                {
                    foreach (DataRow dtRow in dt4.Rows)
                    {
                        string borcson = dtRow["borc_borcid"].ToString();
                        string[] borc = borcson.Split(',');
                        if (borc[0] == "cihaz" && borc[1] == cihazid)
                            borckontrol = false;

                    }
                }
                if(borckontrol)
                {
                    sqlcon.Open();
                    string querry2 = "insert into [dbo].[borc] (m_id,borc_borcid,borc_bilgi,borc_tarih,borc_fiyat,borc_live) ";
                    querry2 += "values (@m_id,@borc_borcid,@borc_bilgi,@borc_tarih,@borc_fiyat,@borc_live);";
                    SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
                    cmd2.Parameters.AddWithValue("@m_id", musteriid);
                    cmd2.Parameters.AddWithValue("@borc_borcid", "cihaz," + cihazid);
                    cmd2.Parameters.AddWithValue("@borc_bilgi", "cihaz borcu");
                    cmd2.Parameters.AddWithValue("@borc_tarih", sqlDate2);
                    cmd2.Parameters.AddWithValue("@borc_live", true);
                    cmd2.Parameters.AddWithValue("@borc_fiyat", txtfiyat.Text.Trim());
                    cmd2.ExecuteNonQuery();
                    sqlcon.Close();
                   
                }

            }


            if (!String.IsNullOrEmpty(borcid))
            {
                sqlcon.Open();
                string querry2 = "UPDATE borc SET borc_fiyat = @borc_fiyat ,borc_live = @borc_live, " +
                    "borc_bilgi = @borc_bilgi WHERE borc_id = @borc_id";
                SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
                if(not == "Arşiv")
                    cmd2.Parameters.AddWithValue("@borc_live", false);
                else
                    cmd2.Parameters.AddWithValue("@borc_live", true);
                cmd2.Parameters.AddWithValue("@borc_fiyat", txtborcfiyat.Text.Trim());
                cmd2.Parameters.AddWithValue("@borc_bilgi", txtborcbilgi.Text.Trim());
                cmd2.Parameters.AddWithValue("@borc_id", borcid);
                cmd2.ExecuteNonQuery();
                sqlcon.Close();

            }
            }
        private void btnbitir_Click(object sender, EventArgs e)
        {

            dataKaydet("Kaydet");
            AutoClosingMessageBox.Show("Bilgiler Değiştirildi!", "Uyarı!", 1000);
            
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            txt1.Visible = checkBox1.Checked;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            txt2.Visible = checkBox2.Checked;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            txt3.Visible = checkBox3.Checked;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            txt4.Visible = checkBox4.Checked;
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            txt5.Visible = checkBox5.Checked;
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            txt6.Visible = checkBox6.Checked;
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            txt7.Visible = checkBox7.Checked;
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            txt8.Visible = checkBox8.Checked;
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            txt9.Visible = checkBox9.Checked;
        }

        private void btnArsiv_Click(object sender, EventArgs e)
        {
            dataKaydet("Arşiv");
            if (btnArsiv.Text == "Arşiv Geri Al")
            {
                string querry = "UPDATE cihaz SET chz_live = @chz_live where chz_id = @chz_id ";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                cmd.Parameters.AddWithValue("@chz_live", true);
                cmd.Parameters.AddWithValue("@chz_id", cihazid);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                sqlcon.Close();
            }

            AutoClosingMessageBox.Show("Bilgiler Arşivlendi!", "Uyarı!", 1000);
            
            this.Close();
        }

        private void btnİade_Click(object sender, EventArgs e)
        {
            dataKaydet("İade");
            AutoClosingMessageBox.Show("İADE EDİLDİ!", "Uyarı!", 1000);
            
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            if (!String.IsNullOrEmpty(borcid))
                dialogResult = MessageBox.Show("Borç Verisi Silinsin Mi ? ", "UYARI", MessageBoxButtons.YesNo);
            else
                dialogResult = MessageBox.Show("Data Silinsin Mi ? ", "UYARI", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (!String.IsNullOrEmpty(borcid))
                {
                    sqlcon.Open();
                    string querry4 = "DELETE FROM borc WHERE borc_id = @borc_id ";
                    SqlCommand cmd4 = new SqlCommand(querry4, sqlcon);
                    cmd4.Parameters.AddWithValue("@borc_id", borcid);
                    cmd4.ExecuteNonQuery();
                    sqlcon.Close();

                }
                else
                {
                    sqlcon.Open();
                    string querry3 = "DELETE FROM anatablo WHERE m_id = @m_id and chz_id = @chz_id";
                    SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
                    cmd3.Parameters.AddWithValue("@m_id", musteriid);
                    cmd3.Parameters.AddWithValue("@chz_id", cihazid);
                    cmd3.ExecuteNonQuery();
                    string querry2 = "DELETE FROM cihaz WHERE chz_id = @chz_id";
                    SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
                    cmd2.Parameters.AddWithValue("@chz_id", cihazid);
                    cmd2.ExecuteNonQuery();
                    sqlcon.Close();
                }
                

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            AutoClosingMessageBox.Show("Data Silindi!", "Uyarı!", 1000);
            MusteriGlobals.form.TableUpdate();
            this.Close();
        }
    }
}

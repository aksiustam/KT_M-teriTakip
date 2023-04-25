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

namespace KT_MusteriTakip
{
    public partial class BorcGenel : Form
    {
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public string bilgi = String.Empty;
        public string borcid = String.Empty;
        public string musteriid = String.Empty;
        public string id = String.Empty;
        public BorcGenel()
        {
            InitializeComponent();
        }

        private void BorcGenel_Load(object sender, EventArgs e)
        {
            
            if(bilgi == "satis")
            {
                string querry = "select satistablo.sat_fiyat,satistablo.sat_tarih,satis.sat_ad,sat_not,sat_bilgi ";
                querry += "from dbo.satistablo join dbo.satis on satistablo.sat_id = satis.sat_id ";
                querry += "where satistablo.id = @sat_id";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                cmd.Parameters.AddWithValue("@sat_id", id);
                sqlcon.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                sqlcon.Close();
                
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["sat_tarih"] != DBNull.Value)
                    {
                        dateTimePicker1.Value = (DateTime)dt.Rows[0]["sat_tarih"];
                    }
                    txtsatisad.Text = dt.Rows[0]["sat_ad"].ToString();
                    txtsatisnot.Text = dt.Rows[0]["sat_not"].ToString();
                    txtsatisucret.Text = dt.Rows[0]["sat_fiyat"].ToString();
                    txtsatBilgi.Text = dt.Rows[0]["sat_bilgi"].ToString();
                }

                string querry2 = "select borc_bilgi,borc_fiyat ";
                querry2 += "from dbo.borc ";
                querry2 += "where borc.borc_id = @borc_id";
                SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
                cmd2.Parameters.AddWithValue("@borc_id", borcid);
                sqlcon.Open();
                SqlDataAdapter sdr2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                sdr2.Fill(dt2);
                sqlcon.Close();
                if (dt2.Rows.Count > 0)
                {
                    txtbilgi.Text = dt2.Rows[0]["borc_bilgi"].ToString();
                    txtfiyat.Text = dt2.Rows[0]["borc_fiyat"].ToString();
                }

                
                string querry3 = "select musteri.m_id,m_adsoyad,m_tel,FL.fl_ad ";
                querry3 += "from dbo.musteri join dbo.FL on FL.fl_id = musteri.fl_id ";
                querry3 += "where musteri.m_id = @m_id";
                SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
                cmd3.Parameters.AddWithValue("@m_id", musteriid);
                sqlcon.Open();
                SqlDataAdapter sdr3 = new SqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                sdr3.Fill(dt3);
                sqlcon.Close();
                if (dt3.Rows.Count > 0)
                {
                    cmbfirma.Text = dt3.Rows[0]["fl_ad"].ToString();
                    txtadsoyad.Text = dt3.Rows[0]["m_adsoyad"].ToString();
                    
                    txttel.Text = dt3.Rows[0]["m_tel"].ToString();
                    
                }

            }
            else if (bilgi == "genel")
            {
                string querry2 = "select borc_bilgi,borc_fiyat,borc_tarih ";
                querry2 += "from dbo.borc ";
                querry2 += "where borc.borc_id = @borc_id";
                SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
                cmd2.Parameters.AddWithValue("@borc_id", borcid);
                sqlcon.Open();
                SqlDataAdapter sdr2 = new SqlDataAdapter(cmd2);
                DataTable dt2 = new DataTable();
                sdr2.Fill(dt2);
                sqlcon.Close();
                if (dt2.Rows.Count > 0)
                {
                    if (dt2.Rows[0]["borc_tarih"] != DBNull.Value)
                    {
                        dateTimePicker1.Value = (DateTime)dt2.Rows[0]["borc_tarih"];
                    }
                    txtbilgi.Text = dt2.Rows[0]["borc_bilgi"].ToString();
                    txtfiyat.Text = dt2.Rows[0]["borc_fiyat"].ToString();
                }


                string querry3 = "select musteri.m_id,m_adsoyad,m_tel,FL.fl_ad ";
                querry3 += "from dbo.musteri join dbo.FL on FL.fl_id = musteri.fl_id ";
                querry3 += "where musteri.m_id = @m_id";
                SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
                cmd3.Parameters.AddWithValue("@m_id", musteriid);
                sqlcon.Open();
                SqlDataAdapter sdr3 = new SqlDataAdapter(cmd3);
                DataTable dt3 = new DataTable();
                sdr3.Fill(dt3);
                sqlcon.Close();
                if (dt3.Rows.Count > 0)
                {
                    cmbfirma.Text = dt3.Rows[0]["fl_ad"].ToString();
                    txtadsoyad.Text = dt3.Rows[0]["m_adsoyad"].ToString();
                    txttel.Text = dt3.Rows[0]["m_tel"].ToString();
                    
                }
            }

            
        }

        private void btnbitir_Click(object sender, EventArgs e)
        {
            string querry = "UPDATE borc SET borc_bilgi = @borc_bilgi , borc_fiyat = @borc_fiyat WHERE borc_id = @borc_id ";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            cmd.Parameters.AddWithValue("@borc_bilgi", txtbilgi.Text.Trim());
            cmd.Parameters.AddWithValue("@borc_fiyat", txtfiyat.Text.Trim());
            cmd.Parameters.AddWithValue("@borc_id", borcid);
            sqlcon.Open();
            cmd.ExecuteNonQuery();
            sqlcon.Close();

            AutoClosingMessageBox.Show("Bilgiler Değiştirildi!", "Uyarı!", 1000);
            BorcGlobals.form.TableUpdate();
            this.Close();
           

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Data Silinsin Mi ? ", "UYARI", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                sqlcon.Open();
                string querry = "DELETE FROM borc WHERE borc_id = @borc_id";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                cmd.Parameters.AddWithValue("@borc_id", borcid);
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            AutoClosingMessageBox.Show("Borç Kaydı Silindi!", "Uyarı!", 1000);
            BorcGlobals.form.TableUpdate();
            this.Close();
            
        }

        private void btnArsiv_Click(object sender, EventArgs e)
        {

            sqlcon.Open();
            string querry = "UPDATE borc SET borc_bilgi = @borc_bilgi , borc_fiyat = @borc_fiyat , borc_live = @borc_live WHERE borc_id = @borc_id";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            cmd.Parameters.AddWithValue("@borc_bilgi", txtbilgi.Text.Trim());
            cmd.Parameters.AddWithValue("@borc_fiyat", txtfiyat.Text.Trim());
            cmd.Parameters.AddWithValue("@borc_live", false);
            cmd.Parameters.AddWithValue("@borc_id", borcid);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
            AutoClosingMessageBox.Show("Borç Arşivlendi!", "Uyarı!", 1000);
            BorcGlobals.form.TableUpdate();
            this.Close();
            
        }
    }
}

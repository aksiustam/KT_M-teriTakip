using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT_MusteriTakip
{
    public partial class EmanetBilgiForm : Form
    {
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);

        public string eid = String.Empty;
        public string mid = String.Empty;
        public EmanetBilgiForm()
        {
            InitializeComponent();
        }

        private void EmanetBilgiForm_Load(object sender, EventArgs e)
        {
            string querry = "select musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon, ";
            querry += "emanet.e_id,e_bilgi as Bilgi,e_fiyat as Fiyat,FL.fl_ad as Firma, ";
            querry += "CONVERT(VARCHAR(11), e_tarih, 103) as Tarih ";
            querry += "from dbo.emanet join dbo.musteri on emanet.m_id = musteri.m_id ";
            querry += "join dbo.FL on FL.fl_id = musteri.fl_id ";
            querry += "where e_id = @e_id ";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            cmd.Parameters.AddWithValue("@e_id", eid);
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            if(dt.Rows.Count > 0)
            {
                txtadsoyad.Text = dt.Rows[0]["AdSoyad"].ToString();
                txttel.Text = dt.Rows[0]["Telefon"].ToString();
                txtbilgi.Text = dt.Rows[0]["Bilgi"].ToString();
                txtfiyat.Text = dt.Rows[0]["Fiyat"].ToString();

            }

            sqlcon.Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            string querry = "UPDATE emanet SET e_bilgi = @e_bilgi , e_fiyat = @e_fiyat ";
            querry += "where e_id = @e_id";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            cmd.Parameters.AddWithValue("@e_bilgi", txtbilgi.Text.Trim());
            cmd.Parameters.AddWithValue("@e_fiyat", txtfiyat.Text.Trim());
            cmd.Parameters.AddWithValue("@e_id", eid);
            cmd.ExecuteNonQuery();

            string querry2 = "UPDATE musteri SET m_adsoyad = @m_adsoyad , m_tel = @m_tel ";
            querry2 += "where m_id = @m_id";
            SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);

            cmd2.Parameters.AddWithValue("@m_adsoyad", txtadsoyad.Text.Trim());
            cmd2.Parameters.AddWithValue("@m_tel", txttel.Text.Trim());
            cmd2.Parameters.AddWithValue("@m_id", mid);
            cmd2.ExecuteNonQuery();
            sqlcon.Close();

            AutoClosingMessageBox.Show("Kaydedildi!", "Uyarı!", 1000);
            
            this.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Data Silinsin Mi ? ", "UYARI", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {


                sqlcon.Open();
                string querry = "DELETE FROM emanet WHERE e_id = @e_id";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                cmd.Parameters.AddWithValue("@e_id", eid);
                cmd.ExecuteNonQuery();
                sqlcon.Close();

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
            AutoClosingMessageBox.Show("Emanet Kaydı Silindi!", "Uyarı!", 1000);
            this.Close();
        }
    }
}

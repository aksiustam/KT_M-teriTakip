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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace KT_MusteriTakip
{
    public partial class SatisAramaBilgiForm : Form
    {

        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public string musteriid = String.Empty;
        public string satisid = String.Empty;
        public string id = String.Empty;
        public SatisAramaBilgiForm()
        {
            InitializeComponent();
        }

        private void SatisSatisBilgiForm_Load(object sender, EventArgs e)
        {
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
            if (dt.Rows.Count > 0)
            {
                txtadsoyad.Text = dt.Rows[0]["m_adsoyad"].ToString();
                txttel.Text = dt.Rows[0]["m_tel"].ToString();
            }



            string querry2 = "select satis.sat_ad,sat_not,sat_gelis ";
            querry2 += "from dbo.satis ";
            querry2 += "where satis.sat_id = @sat_id";
            SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
            cmd2.Parameters.AddWithValue("@sat_id", satisid);
            sqlcon.Open();
            SqlDataAdapter sdr2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            sdr2.Fill(dt2);
            sqlcon.Close();

            if (dt2.Rows.Count > 0)
            {
                txtsatisad.Text = dt2.Rows[0]["sat_ad"].ToString();
                txtsatisbilgi.Text = dt2.Rows[0]["sat_not"].ToString();
                txtsatisgelis.Text = dt2.Rows[0]["sat_gelis"].ToString();
            }

            string querry3 = "select satistablo.sat_fiyat,sat_satadet,sat_bilgi ";
            querry3 += "from dbo.satistablo ";
            querry3 += "where satistablo.id = @id";
            SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
            cmd3.Parameters.AddWithValue("@id", id);
            sqlcon.Open();
            SqlDataAdapter sdr3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            sdr3.Fill(dt3);
            sqlcon.Close();

            if (dt3.Rows.Count > 0)
            {
                txtsatisfiyat.Text = dt3.Rows[0]["sat_fiyat"].ToString();
                txtsatbilgi.Text = dt3.Rows[0]["sat_bilgi"].ToString();
                numAdet.Value = Convert.ToInt32(dt3.Rows[0]["sat_satadet"]);
            }

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
                    if (borc[0] == "satis" && borc[1] == id)
                        checkBoxborc.Checked = true;

                }
            }
        }

        private void btnekle_Click(object sender, EventArgs e)
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


            sqlcon.Open();
            string querry = "UPDATE satis SET sat_ad = @sat_ad, sat_not = @sat_not, ";
            querry += "sat_gelis = @sat_gelis where sat_id = @sat_id ";
           
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            if (String.IsNullOrEmpty(txtsatisad.Text)) // AD
                cmd.Parameters.AddWithValue("@sat_ad", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@sat_ad", txtsatisad.Text.Trim());

            if (String.IsNullOrEmpty(txtsatisbilgi.Text)) // AD
                cmd.Parameters.AddWithValue("@sat_not", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@sat_not", txtsatisbilgi.Text.Trim());

            if (String.IsNullOrEmpty(txtsatisgelis.Text)) // AD
                cmd.Parameters.AddWithValue("@sat_gelis", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@sat_gelis", txtsatisgelis.Text.Trim());
            
            cmd.Parameters.AddWithValue("@sat_id", satisid);
            cmd.ExecuteNonQuery();
            sqlcon.Close();
            
            sqlcon.Open();
            string querry2 = "UPDATE satistablo SET sat_fiyat = @sat_fiyat, sat_satadet = @sat_satadet, ";
            querry2 += "sat_bilgi = @sat_bilgi where id = @id ";

            SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
            if (String.IsNullOrEmpty(txtsatisfiyat.Text)) // AD
                cmd2.Parameters.AddWithValue("@sat_fiyat", DBNull.Value);
            else
                cmd2.Parameters.AddWithValue("@sat_fiyat", txtsatisfiyat.Text.Trim());

            cmd2.Parameters.AddWithValue("@sat_satadet", numAdet.Value);

            if (String.IsNullOrEmpty(txtsatbilgi.Text)) // AD
                cmd2.Parameters.AddWithValue("@sat_bilgi", DBNull.Value);
            else
                cmd2.Parameters.AddWithValue("@sat_bilgi", txtsatbilgi.Text.Trim());

            cmd2.Parameters.AddWithValue("@id", id);
            cmd2.ExecuteNonQuery();
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
                        if (borc[0] == "satis" && borc[1] == id)
                        {
                            borckontrol = false;
                        }

                    }
                }
                if (borckontrol)
                {
                    sqlcon.Open();
                    string querry5 = "insert into [dbo].[borc] (m_id,borc_borcid,borc_bilgi,borc_tarih,borc_fiyat,borc_live) ";
                    querry5 += "values (@m_id,@borc_borcid,@borc_bilgi,@borc_tarih,@borc_fiyat,@borc_live);";
                    SqlCommand cmd5 = new SqlCommand(querry5, sqlcon);
                    cmd5.Parameters.AddWithValue("@m_id", musteriid);
                    cmd5.Parameters.AddWithValue("@borc_borcid", "satis," + id);
                    cmd5.Parameters.AddWithValue("@borc_bilgi", "satis borcu");
                    DateTime myDateTime = DateTime.Now;
                    string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    cmd5.Parameters.AddWithValue("@borc_tarih", sqlDate);
                    cmd5.Parameters.AddWithValue("@borc_live", true);
                    cmd5.Parameters.AddWithValue("@borc_fiyat", txtsatisfiyat.Text.Trim());
                    cmd5.ExecuteNonQuery();
                    sqlcon.Close();
                }

                
            }


            AutoClosingMessageBox.Show("Bilgiler Değiştirildi!", "Uyarı!", 1000);
            this.Close();
        }

        private void txttel_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txttel.Select(0, 0);
            });
        }
    }
}

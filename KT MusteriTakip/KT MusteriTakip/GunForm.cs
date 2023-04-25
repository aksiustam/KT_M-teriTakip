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
    public partial class GunForm : Form
    {
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public GunForm()
        {
            InitializeComponent();
        }

        private void GunForm_Load(object sender, EventArgs e)
        {
            string querry = "select FL.fl_ad as Firma,musteri.m_id as No,m_adsoyad as AdSoyad,m_tel as Telefon,";
            querry += "cihaz.chz_id as CihazNo,chz_ad as CihazAdı,chz_geltarih as Tarih ";
            querry += "from dbo.musteri join dbo.FL on FL.fl_id = musteri.fl_id ";
            querry += "join dbo.anatablo on musteri.m_id = anatablo.m_id ";
            querry += "join dbo.cihaz on cihaz.chz_id = anatablo.chz_id ";
            querry += "where chz_geltarih >= @tarih1 AND chz_geltarih < @tarih2 ";
            querry += "Order by musteri.m_id DESC";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            DateTime myDateTime = DateTime.Now.AddDays(1);
            string sqlDate1 = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
            DateTime myDateTime2 = DateTime.Now.AddDays(-8);
            string sqlDate2 = myDateTime2.ToString("yyyy-MM-dd HH:mm:ss.fff");
            cmd.Parameters.AddWithValue("@tarih2", sqlDate1);
            cmd.Parameters.AddWithValue("@tarih1", sqlDate2);
            
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);


            /*
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string str = reader["AdSoyad"].ToString() + "  ";
                str += reader["chz_geltarih"].ToString() + " de " + reader["CihazAdı"].ToString() + " getirdi.";
                listBox.Items.Add(str);
                listBox.Refresh();
            }
            reader.Close();
            */
            sqlcon.Close();


            string querry2 = "select FL.fl_ad as Firma,musteri.m_id as No,m_adsoyad as AdSoyad,m_tel as Telefon,";
            querry2 += "satis.sat_ad as Ad, satistablo.sat_fiyat as Fiyat,satistablo.sat_tarih as Tarih ";
            querry2 += "from dbo.musteri join dbo.FL on FL.fl_id = musteri.fl_id ";
            querry2 += "join dbo.satistablo on satistablo.m_id = musteri.m_id ";
            querry2 += "join dbo.satis on satis.sat_id = satistablo.sat_id ";
            querry2 += "where satistablo.sat_tarih >= @tarih1 AND satistablo.sat_tarih < @tarih2 ";
            querry2 += "Order by id DESC";
            SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);

            cmd2.Parameters.AddWithValue("@tarih2", sqlDate1);
            cmd2.Parameters.AddWithValue("@tarih1", sqlDate2);

            sqlcon.Open();
            SqlDataAdapter sdr2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            sdr2.Fill(dt2);
            DataTable dtAll = new DataTable();
            dtAll = dt.Copy();
            dtAll.Merge(dt2);
            dataGridView.DataSource = dtAll;
            sqlcon.Close();

            dataGridView.Sort(dataGridView.Columns["Tarih"], ListSortDirection.Descending);
            //this.Column1.HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;

            /*
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                string str = reader2["AdSoyad"].ToString() + " ";
                str += reader2["sat_tarih"].ToString() + " de " + reader2["sat_ad"].ToString() + " ";
                str += " ı " + reader2["sat_fiyat"].ToString() + " TL ye satıldı.";
                listBox.Items.Add(str);
                listBox.Refresh();
            }
            reader.Close();
            */




        }
    }
}

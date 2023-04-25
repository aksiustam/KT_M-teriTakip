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
    public partial class HesaplarForm : Form
    {
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public HesaplarForm()
        {
            InitializeComponent();
        }
       
        private void HesaplarForm_Load(object sender, EventArgs e)
        {
            MusteriHesap();
            SatisHesap();

        }
        public void MusteriHesap()
        {




            string querry = "select SUM(chz_fiyat) ";
            querry += "from cihaz ";
            querry += "where YEAR(chz_geltarih) = @chz_tarih and MONTH(chz_geltarih) = @chz_geltarih";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            DateTime myDateTime = DateTime.Now;

            cmd.Parameters.AddWithValue("@chz_geltarih", myDateTime.Date.Month);
            cmd.Parameters.AddWithValue("@chz_tarih", myDateTime.Date.Year);
            sqlcon.Open();
            var obj = cmd.ExecuteScalar();
            int buay = 0;
            if (obj != null && DBNull.Value != obj)
                buay = Convert.ToInt32(obj);
            sqlcon.Close();
            labelMusbay.Text = "Müşteriden Bu Ay Kazanç: " + buay + " TL";


            string querry2 = "select SUM(chz_fiyat) ";
            querry2 += "from cihaz ";
            querry2 += "where YEAR(chz_geltarih) = @chz_tarih and MONTH(chz_geltarih) = @chz_geltarih";
            SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
            int ay = myDateTime.Date.Month;
            int yil = myDateTime.Date.Year;
            if (ay == 1)
            {
                ay = 12;
                yil -= 1;
            }
            else
                ay -= 1;
            cmd2.Parameters.AddWithValue("@chz_geltarih", ay);
            cmd2.Parameters.AddWithValue("@chz_tarih", yil);
            sqlcon.Open();
            var obj2 = cmd2.ExecuteScalar();
            int gecay = 0;
            if (obj2 != null && DBNull.Value != obj2)
                gecay = Convert.ToInt32(obj2);
            sqlcon.Close();
            labelMusgay.Text = "Müşteriden Geçen Ay Kazanç: " + gecay + " TL";


            string querry3 = "select SUM(chz_fiyat) ";
            querry3 += "from cihaz ";
            querry3 += "where YEAR(chz_geltarih) = @chz_geltarih";
            SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
            cmd3.Parameters.AddWithValue("@chz_geltarih", myDateTime.Date.Year);
            sqlcon.Open();
            var obj3 = cmd3.ExecuteScalar();
            int sonyil = 0;
            if (obj3 != null && DBNull.Value != obj3)
                sonyil = Convert.ToInt32(obj3);
            sqlcon.Close();
            labelMusyay.Text = "Müşteriden Bu Yılki Kazanç: " + sonyil + " TL";


            string querry4 = "SET DATEFIRST 1 ";
            querry4 += "select SUM(chz_fiyat) ";
            querry4 += "from cihaz ";
            querry4 += "WHERE chz_geltarih >= dateadd(day, 1-datepart(dw, getdate()), CONVERT(date,getdate()))  ";
            querry4 += "AND chz_geltarih <  dateadd(day, 8-datepart(dw, getdate()), CONVERT(date,getdate())) ";
            SqlCommand cmd4 = new SqlCommand(querry4, sqlcon);
            
            sqlcon.Open();
            var obj4 = cmd4.ExecuteScalar();
            int sonweek = 0;
            if (obj4 != null && DBNull.Value != obj4)
                sonweek = Convert.ToInt32(obj4);
            sqlcon.Close();
            labelMusWeek.Text = "Müşteriden Bu Hafta Kazanç: " + sonweek + " TL";
        }

        public void SatisHesap()
        {
            string querry = "select SUM(sat_fiyat) ";
            querry += "from satistablo ";
            querry += "where YEAR(sat_tarih) = @chz_tarih and MONTH(sat_tarih) = @chz_geltarih";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            DateTime myDateTime = DateTime.Now;

            cmd.Parameters.AddWithValue("@chz_geltarih", myDateTime.Date.Month);
            cmd.Parameters.AddWithValue("@chz_tarih", myDateTime.Date.Year);
            sqlcon.Open();
            var obj = cmd.ExecuteScalar();
            int buay = 0;
            if (obj != null && DBNull.Value != obj)
                buay = Convert.ToInt32(obj);
            sqlcon.Close();
            labelSatbay.Text = "Satiştan Bu Ay Kazanç: " + buay + " TL";


            string querry2 = "select SUM(sat_fiyat) ";
            querry2 += "from satistablo ";
            querry2 += "where YEAR(sat_tarih) = @chz_tarih and MONTH(sat_tarih) = @chz_geltarih";
            SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
            int ay = myDateTime.Date.Month;
            int yil = myDateTime.Date.Year;
            if (ay == 1)
            {
                ay = 12;
                yil -= 1;
            }
            else
                ay -= 1;
            cmd2.Parameters.AddWithValue("@chz_geltarih", ay);
            cmd2.Parameters.AddWithValue("@chz_tarih", yil);
            sqlcon.Open();
            var obj2 = cmd2.ExecuteScalar();
            int gecay = 0;
            if (obj2 != null && DBNull.Value != obj2)
                gecay = Convert.ToInt32(obj2);
            sqlcon.Close();
            labelSatgay.Text = "Satıştan Geçen Ay Kazanç: " + gecay + " TL";


            string querry3 = "select SUM(sat_fiyat) ";
            querry3 += "from satistablo ";
            querry3 += "where YEAR(sat_tarih) = @chz_geltarih";
            SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
            cmd3.Parameters.AddWithValue("@chz_geltarih", myDateTime.Date.Year);
            sqlcon.Open();
            var obj3 = cmd3.ExecuteScalar();
            int sonyil = 0;
            if (obj3 != null && DBNull.Value != obj3)
                sonyil = Convert.ToInt32(obj3);
            sqlcon.Close();
            labelSatyay.Text = "Satıştan Bu Yılki Kazanç: " + sonyil + " TL";

            string querry4 = "SET DATEFIRST 1 ";
            querry4 += "select SUM(sat_fiyat) ";
            querry4 += "from satistablo ";
            querry4 += "WHERE sat_tarih >= dateadd(day, 1-datepart(dw, getdate()), CONVERT(date,getdate()))  ";
            querry4 += "AND sat_tarih <  dateadd(day, 8-datepart(dw, getdate()), CONVERT(date,getdate())) ";
            SqlCommand cmd4 = new SqlCommand(querry4, sqlcon);
            
            sqlcon.Open();
            var obj4 = cmd4.ExecuteScalar();
            int sonweek = 0; 
            if (obj4 != null && DBNull.Value != obj4)
                sonweek = Convert.ToInt32(obj4);
            sqlcon.Close();
            labelSatWeek.Text = "Satiştan Bu Hafta Kazanç: " + sonweek + " TL";
        }


        private void btngunluk_Click(object sender, EventArgs e)
        {
            GunForm fr = new GunForm();
            fr.Show();
        }
    }
}

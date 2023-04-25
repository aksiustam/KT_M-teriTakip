using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace KT_MusteriTakip
{
    public partial class AyarlarFirma : Form
    {
        public AyarlarFirma()
        {
            InitializeComponent();
        }
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        private void TableUpdate()
        {
            // TODO: Bu kod satırı 'kTMTDataSet.FL' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            

            string querry = "select FL.fl_id,fl_ad as Firma,fl_adsoyad as AdSoyad ";
            querry += "from dbo.FL ";
            querry += "where FL.fl_id != 1 and FL.fl_id != 2 ";
            querry += "Order by FL.fl_id DESC";
            SqlCommand cmd = new SqlCommand(querry, sqlcon); 
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            dataGridView.DataSource = dt;
            sqlcon.Close();
        }
        private void btnekle_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(txtfirma.Text) || String.IsNullOrEmpty(txtadsoyad.Text))
            {
                MessageBox.Show("Firma Adı ve İsim Giriniz.");
                return;
            }
            if (sqlcon.State == ConnectionState.Closed)
            {

                sqlcon.Open();
                string querryf = "insert into [dbo].[FL] (fl_ad,fl_adsoyad,fl_tel) ";
                querryf += "values (@fl_ad,@fl_adsoyad,@fl_tel); SELECT SCOPE_IDENTITY()";
                SqlCommand cmdf = new SqlCommand(querryf, sqlcon);
                if (String.IsNullOrEmpty(txtfirma.Text)) // AD
                    cmdf.Parameters.AddWithValue("@fl_ad", DBNull.Value);
                else
                    cmdf.Parameters.AddWithValue("@fl_ad", txtfirma.Text);
                if (String.IsNullOrEmpty(txtadsoyad.Text)) // AD
                    cmdf.Parameters.AddWithValue("@fl_adsoyad", DBNull.Value);
                else
                    cmdf.Parameters.AddWithValue("@fl_adsoyad", txtadsoyad.Text);
                if (String.IsNullOrEmpty(txttel.Text)) // AD
                    cmdf.Parameters.AddWithValue("@fl_tel", DBNull.Value);
                else
                    cmdf.Parameters.AddWithValue("@fl_tel", txttel.Text);
                cmdf.ExecuteNonQuery();

                sqlcon.Close();
                AutoClosingMessageBox.Show("Firma Eklendi!", "Uyarı!", 1000);
                this.Close();
            }

            else
            {
                MessageBox.Show("Veri Kaydı Başarısız !");
            }


        }

        private void AyarlarFirma_Load(object sender, EventArgs e)
        {
            TableUpdate();
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

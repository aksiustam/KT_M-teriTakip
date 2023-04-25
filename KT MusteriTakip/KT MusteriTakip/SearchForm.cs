using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KT_MusteriTakip
{
    public partial class SearchForm : Form
    {

        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public string formNo = String.Empty;
        public string musteriad = String.Empty;

        public SearchForm()
        {
            InitializeComponent();
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            string querryara = "Select FL.fl_ad as Firma,musteri.m_id as No,m_adsoyad as AdSoyad,m_tel as Telefon ";
            querryara += "from dbo.musteri join dbo.FL on FL.fl_id = musteri.fl_id ";
            querryara += "where m_adsoyad = @m_adsoyad ";
            SqlCommand cmdara = new SqlCommand(querryara, sqlcon);
            cmdara.Parameters.AddWithValue("@m_adsoyad", musteriad);
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmdara);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            sqlcon.Close();
            dataGridView.DataSource = dt;


        }

        private void btnSec_Click(object sender, EventArgs e)
        {
            dataGridView.CurrentRow.Selected = true;
            string musteriNo = dataGridView.CurrentRow.Cells["No"].FormattedValue.ToString();
            if(formNo == "Cihaz")
                MusteriGlobals.form.musteriNo = musteriNo;
            else if(formNo == "Borc")
                BorcGlobals.form.musteriNo = musteriNo;
            else if (formNo == "Emanet")
                EmanetGlobals.form.musteriNo = musteriNo;
            else if (formNo == "Satis")
                SatisSatisGlobals.form.musteriNo = musteriNo;

            AutoClosingMessageBox.Show(musteriNo + " No'lu Müşteriyi seçtiniz!", "Uyarı!", 1000);

            this.Close();
        }
    }


}

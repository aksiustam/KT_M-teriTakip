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
using static KT_MusteriTakip.KTMTDataSet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace KT_MusteriTakip
{
    public partial class BorcForm : Form
    {
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public string musteriNo = String.Empty;
        public BorcForm()
        {
            InitializeComponent();
        }
        public void TableUpdate()
        {
            string querry = "select musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon, ";
            querry += "borc.borc_id,borc_borcid,borc_bilgi as Bilgi,borc_fiyat as Fiyat, CONVERT(VARCHAR(11), borc_tarih, 103) as Tarih ";
            querry += "from dbo.borc join dbo.musteri on borc.m_id = musteri.m_id ";
            querry += "where borc_live = 'true' Order by borc_id DESC";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            dataGridView.DataSource = dt;
            dataGridView.Columns["borc_id"].Visible = false;
            dataGridView.Columns["borc_borcid"].Visible = false;
            dataGridView.Columns["m_id"].Visible = false;
            sqlcon.Close();
        }
        private void BorcForm_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kTMTDataSet.FL' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.fLTableAdapter.Fill(this.kTMTDataSet.FL);
            BorcGlobals.form = this;
            TableUpdate();
        }

        private void cmbfirma_SelectedIndexChanged(object sender, EventArgs e)
        {


            if (cmbfirma.Text != "Müşteri")
            {
                int sayi = Convert.ToInt32(cmbfirma.SelectedValue);
                string querry = "select FL.fl_adsoyad, fl_tel ";
                querry += "from dbo.FL ";
                querry += "where FL.fl_id = @fl_id";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                cmd.Parameters.AddWithValue("@fl_id", sayi);
                sqlcon.Open();
                SqlDataAdapter sdr = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                sqlcon.Close();
                if (dt.Rows.Count > 0)
                {
                    txtadsoyad.Text = dt.Rows[0]["fl_adsoyad"].ToString();
                    txttel.Text = dt.Rows[0]["fl_tel"].ToString();
                    
                }

            }
            else
            {
                txtadsoyad.Text = "";
                txttel.Text = "";
                
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            cmbfirma.SelectedIndex = 0;
            txtadsoyad.Text = "";
            
            txttel.Text = "";
            txtbilgi.Text = "";
            txtfiyat.Text = "";
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Data Arşivlensin Mi ? ", "UYARI", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView.CurrentRow.Selected = true;
                string id = dataGridView.CurrentRow.Cells["borc_id"].FormattedValue.ToString();
                sqlcon.Open(); 
                string querry = "UPDATE borc SET borc_live = @borc_live WHERE borc_id = @borc_id";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                cmd.Parameters.AddWithValue("@borc_live", false);
                cmd.Parameters.AddWithValue("@borc_id", id);
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                TableUpdate();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        public void borcarama()
        {


            List<string> allParams = new List<string>();
            //here add fields you want to filter and their impact on rowview in string form
            if (txtadsoyad.Text != "") { allParams.Add("AdSoyad like  '%" + txtadsoyad.Text.Trim() + "%'"); }
            if (txttel.Text != "") { allParams.Add("Telefon like  '%" + txttel.Text.Trim() + "%'"); }
            if (txtbilgi.Text != "") { allParams.Add("Bilgi like  '%" + txtbilgi.Text.Trim() + "%'"); }
            if (txtfiyat.Text != "") { allParams.Add("Fiyat like  '%" + txtfiyat.Text.Trim() + "%'"); }

            string finalFilter = string.Join(" and ", allParams);
            if (finalFilter != "")
            { (dataGridView.DataSource as DataTable).DefaultView.RowFilter = "(" + finalFilter + ")"; }
            else
            { (dataGridView.DataSource as DataTable).DefaultView.RowFilter = ""; }

            dataGridView.Refresh();

        }
        private void txtad_TextChanged(object sender, EventArgs e)
        {
            borcarama();
        }


        private void txttel_TextChanged(object sender, EventArgs e)
        {
            borcarama();
        }


        private void txtbilgi_TextChanged(object sender, EventArgs e)
        {
            borcarama();
        }

        private void txtfiyat_TextChanged(object sender, EventArgs e)
        {
            borcarama();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {

            if (sqlcon.State == ConnectionState.Closed)
            {
                int musteriid = 1;

                sqlcon.Open();
                string querryara = "Select FL.fl_ad as Firma,musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon ";
                querryara += "from dbo.musteri join dbo.FL on FL.fl_id = musteri.fl_id ";
                querryara += "where m_adsoyad = @m_adsoyad ";
                SqlCommand cmdara = new SqlCommand(querryara, sqlcon);
                if (String.IsNullOrEmpty(txtadsoyad.Text.Trim())) // AD
                    cmdara.Parameters.AddWithValue("@m_adsoyad", DBNull.Value);
                else
                    cmdara.Parameters.AddWithValue("@m_adsoyad", txtadsoyad.Text.Trim());

                SqlDataAdapter sdr = new SqlDataAdapter(cmdara);
                DataTable dt = new DataTable();
                sdr.Fill(dt);
                sqlcon.Close();

                if (dt.Rows.Count == 1)
                {
                    musteriid = Convert.ToInt32(dt.Rows[0]["m_id"]);

                }
                else if (dt.Rows.Count > 1)
                {

                    SearchForm fr = new SearchForm();
                    fr.formNo = "Borc";
                    fr.musteriad = dt.Rows[0]["AdSoyad"].ToString();
                    fr.ShowDialog();
                    if (String.IsNullOrEmpty(musteriNo))
                    {

                        MessageBox.Show("Müşteri Seçmeniz Lazım");
                        return;

                    }
                    musteriid = Convert.ToInt32(musteriNo);

                }
                else if (dt.Rows.Count == 0)
                {

                    sqlcon.Open();
                    string querry = "insert into [dbo].[musteri] (fl_id,m_live,m_adsoyad,m_tel) ";
                    querry += "values (@fl_id,@m_live,@m_adsoyad,@m_tel);";
                    querry += "SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(querry, sqlcon);
                    cmd.Parameters.AddWithValue("@fl_id", cmbfirma.SelectedValue.ToString());
                    cmd.Parameters.AddWithValue("@m_live", true);
                    if (String.IsNullOrEmpty(txtadsoyad.Text)) // AD
                        cmd.Parameters.AddWithValue("@m_adsoyad", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@m_adsoyad", txtadsoyad.Text.Trim());
                    if (String.IsNullOrEmpty(txttel.Text)) // TEL
                        cmd.Parameters.AddWithValue("@m_tel", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@m_tel", txttel.Text.Trim());
                    musteriid = Convert.ToInt32(cmd.ExecuteScalar());
                    sqlcon.Close();
                }

                sqlcon.Open();
                string querry2 = "insert into [dbo].[borc] (m_id,borc_borcid,borc_bilgi,borc_tarih,borc_fiyat,borc_live) ";
                querry2 += "values (@m_id,@borc_borcid,@borc_bilgi,@borc_tarih,@borc_fiyat,@borc_live);";
                
                SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
                cmd2.Parameters.AddWithValue("@m_id", musteriid);
                cmd2.Parameters.AddWithValue("@borc_live", true);
                cmd2.Parameters.AddWithValue("@borc_borcid", "genel,"+ musteriid);
                if (String.IsNullOrEmpty(txtbilgi.Text))
                    cmd2.Parameters.AddWithValue("@borc_bilgi", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@borc_bilgi", txtbilgi.Text.Trim());

                if (String.IsNullOrEmpty(txtfiyat.Text))
                    cmd2.Parameters.AddWithValue("@borc_fiyat", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@borc_fiyat", txtfiyat.Text.Trim());

               
                DateTime myDateTime = DateTime.Now;
                string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd2.Parameters.AddWithValue("@borc_tarih", sqlDate);
                cmd2.ExecuteNonQuery();
                sqlcon.Close();

                TableUpdate();
            }

            else
            {
                MessageBox.Show("Veri Kaydı Başarısız !");
            }

        }

        private void dataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentCell == null ||
            dataGridView.CurrentCell.Value == null ||
            e.RowIndex == -1 || e.ColumnIndex == -1) return;

            int row = e.RowIndex;
            int col = e.ColumnIndex;

            

            if (dataGridView.Rows[row].Cells[col].Value != null)
            {

                dataGridView.CurrentRow.Selected = true;

                string borcid = dataGridView.Rows[row].Cells["borc_id"].FormattedValue.ToString();
                string son = dataGridView.Rows[row].Cells["borc_borcid"].FormattedValue.ToString();
                string musteriid = dataGridView.Rows[row].Cells["m_id"].FormattedValue.ToString();
                string[] ara = son.Split(',');
                if (ara.Length > 1)
                {
                    string formbilgi = ara[0];
                    string id = ara[1];
                    if(formbilgi == "cihaz")
                    {
                        MusteriAramaBilgiForm fm = new MusteriAramaBilgiForm();
                        fm.musteriid = musteriid;
                        fm.cihazid = id;
                        fm.borcid = borcid;
                        fm.ShowDialog();
                        
                    }
                    else 
                    {
                        BorcGenel fm = new BorcGenel();
                        fm.bilgi = formbilgi;
                        fm.borcid = borcid;
                        fm.musteriid = musteriid;
                        fm.id = id;
                        fm.ShowDialog();
                    }
                    
                }
               

            }
        }

        private void txttel_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txttel.Select(0, 0);
            });
        }

        private void checkBoxborc_CheckedChanged(object sender, EventArgs e)
        {
            string querry = "";

            if (checkBoxborc.Checked == true)
            {
                querry += "select musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon, ";
                querry += "borc.borc_id,borc_borcid,borc_bilgi as Bilgi,borc_fiyat as Fiyat, CONVERT(VARCHAR(11), borc_tarih, 103) as Tarih  ";
                querry += "from dbo.borc join dbo.musteri on borc.m_id = musteri.m_id ";
                querry += "Order by borc_id DESC ";

            }
            if (checkBoxborc.Checked == false)
            {
                querry += "select musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon, ";
                querry += "borc.borc_id,borc_borcid,borc_bilgi as Bilgi,borc_fiyat as Fiyat, CONVERT(VARCHAR(11), borc_tarih, 103) as Tarih  ";
                querry += "from dbo.borc join dbo.musteri on borc.m_id = musteri.m_id ";
                querry += "where borc_live = 'true' Order by borc_id DESC ";
            }
            
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            dataGridView.DataSource = dt;
            dataGridView.Columns["borc_id"].Visible = false;
            dataGridView.Columns["borc_borcid"].Visible = false;
            dataGridView.Columns["m_id"].Visible = false;
            sqlcon.Close();

        }
    }

    class BorcGlobals
    {
        public static BorcForm form;
    }
}

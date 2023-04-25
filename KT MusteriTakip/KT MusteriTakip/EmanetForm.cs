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

namespace KT_MusteriTakip
{
    public partial class EmanetForm : Form
    {
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public string musteriNo = String.Empty;
        public EmanetForm()
        {
            InitializeComponent();
        }
        public void TableUpdate()
        {
            string querry = "select musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon, ";
            querry += "emanet.e_id,e_bilgi as Bilgi,e_fiyat as Fiyat,FL.fl_ad as Firma, ";
            querry += "CONVERT(VARCHAR(11), e_tarih, 103) as Tarih ";
            querry += "from dbo.emanet join dbo.musteri on emanet.m_id = musteri.m_id ";
            querry += "join dbo.FL on FL.fl_id = musteri.fl_id "; 
            querry += "Where e_live = 'true' Order by e_id DESC";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            dataGridView.DataSource = dt;
            dataGridView.Columns["e_id"].Visible = false;
            dataGridView.Columns["m_id"].Visible = false;
            dataGridView.Columns["Firma"].Visible = false;
            sqlcon.Close();
        }

      
        private void EmanetForm_Load(object sender, EventArgs e)
        {
            this.fLTableAdapter.Fill(this.kTMTDataSet.FL);
            TableUpdate();
            EmanetGlobals.form = this;
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
            chkEmanet.Checked = false;
            cmbfirma.SelectedIndex = 0;
            txtadsoyad.Text = "";
            txttel.Text = "";
            txtbilgi.Text = "";
            txtfiyat.Text = "";
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Data Arşivleniyor ? ", "UYARI", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView.CurrentRow.Selected = true;
                string id = dataGridView.CurrentRow.Cells["e_id"].FormattedValue.ToString();
                sqlcon.Open();
                string querry = "UPDATE emanet SET e_live = @e_live WHERE e_id = @e_id";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                cmd.Parameters.AddWithValue("@e_live", false);
                cmd.Parameters.AddWithValue("@e_id", id);
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                TableUpdate();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        public void emanetarama()
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
            emanetarama();
        }


        private void txttel_TextChanged(object sender, EventArgs e)
        {
            emanetarama();
        }


        private void txtbilgi_TextChanged(object sender, EventArgs e)
        {
            emanetarama();
        }

        private void txtfiyat_TextChanged(object sender, EventArgs e)
        {
            emanetarama();
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
                    fr.formNo = "Emanet";
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
                        cmd.Parameters.AddWithValue("@m_adsoyad", txtadsoyad.Text);
                    if (String.IsNullOrEmpty(txttel.Text)) // TEL
                        cmd.Parameters.AddWithValue("@m_tel", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@m_tel", txttel.Text);
                    musteriid = Convert.ToInt32(cmd.ExecuteScalar());
                    sqlcon.Close();
                }


                
                


                sqlcon.Open();
                string querry2 = "insert into [dbo].[emanet] (m_id,e_bilgi,e_tarih,e_fiyat,e_live) ";
                querry2 += "values (@m_id,@e_bilgi,@e_tarih,@e_fiyat,@e_live);";
                
                SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
                cmd2.Parameters.AddWithValue("@m_id", musteriid);
                cmd2.Parameters.AddWithValue("@e_live", true);
                if (String.IsNullOrEmpty(txtbilgi.Text)) // cihazAD
                    cmd2.Parameters.AddWithValue("@e_bilgi", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@e_bilgi", txtbilgi.Text);

                if (String.IsNullOrEmpty(txtfiyat.Text)) // cihazmarka
                    cmd2.Parameters.AddWithValue("@e_fiyat", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@e_fiyat", txtfiyat.Text);


                DateTime myDateTime = DateTime.Now;
                string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd2.Parameters.AddWithValue("@e_tarih", sqlDate);
                cmd2.ExecuteNonQuery();
                sqlcon.Close();

                TableUpdate();
            }

            else
            {
                MessageBox.Show("Veri Kaydı Başarısız !");
            }
        }

        private void txttel_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txttel.Select(0, 0);
            });
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.CurrentCell == null ||
            dataGridView.CurrentCell.Value == null ||
            e.RowIndex == -1 || e.ColumnIndex == -1) return;
            int row = e.RowIndex;

            int col = e.ColumnIndex;

            if (dataGridView.Rows[row].Cells[col].Value != null)
            {

                dataGridView.CurrentRow.Selected = true;
                string firma, adsoyad, tel, fiyat, bilgi;
                firma = dataGridView.Rows[row].Cells["Firma"].FormattedValue.ToString();
                adsoyad = dataGridView.Rows[row].Cells["AdSoyad"].FormattedValue.ToString();
                tel = dataGridView.Rows[row].Cells["Telefon"].FormattedValue.ToString();
                fiyat = dataGridView.Rows[row].Cells["Fiyat"].FormattedValue.ToString();
                bilgi = dataGridView.Rows[row].Cells["Bilgi"].FormattedValue.ToString();

                txtadsoyad.Text = adsoyad;
                txttel.Text = tel;
                txtbilgi.Text = bilgi;
                txtfiyat.Text = fiyat;
                cmbfirma.Text = firma;
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
                string eid = dataGridView.Rows[row].Cells["e_id"].FormattedValue.ToString();
                string mid = dataGridView.Rows[row].Cells["m_id"].FormattedValue.ToString();
                EmanetBilgiForm fr = new EmanetBilgiForm();
                
                fr.eid = eid;
                fr.mid = mid;
                fr.ShowDialog();
            }
        }

        private void chkEmanet_CheckedChanged(object sender, EventArgs e)
        {
            string querry = "";
            if (chkEmanet.Checked == true)
            {
                querry = "select musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon, ";
                querry += "emanet.e_id,e_bilgi as Bilgi,e_fiyat as Fiyat,FL.fl_ad as Firma, ";
                querry += "CONVERT(VARCHAR(11), e_tarih, 103) as Tarih ";
                querry += "from dbo.emanet join dbo.musteri on emanet.m_id = musteri.m_id ";
                querry += "join dbo.FL on FL.fl_id = musteri.fl_id ";
                querry += "Order by e_id DESC";


            }
            if (chkEmanet.Checked == false)
            {
                querry = "select musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon, ";
                querry += "emanet.e_id,e_bilgi as Bilgi,e_fiyat as Fiyat,FL.fl_ad as Firma, ";
                querry += "CONVERT(VARCHAR(11), e_tarih, 103) as Tarih ";
                querry += "from dbo.emanet join dbo.musteri on emanet.m_id = musteri.m_id ";
                querry += "join dbo.FL on FL.fl_id = musteri.fl_id ";
                querry += "Where e_live = 'true' Order by e_id DESC";
            }
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            dataGridView.DataSource = dt;
            dataGridView.Columns["e_id"].Visible = false;
            dataGridView.Columns["m_id"].Visible = false;
            dataGridView.Columns["Firma"].Visible = false;
            
            sqlcon.Close();
        }
    }
    class EmanetGlobals
    {
        public static EmanetForm form;
    }
}

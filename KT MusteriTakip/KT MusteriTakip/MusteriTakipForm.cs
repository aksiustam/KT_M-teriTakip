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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KT_MusteriTakip
{
    public partial class MusteriTakipForm : Form
    {

        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public string musteriNo = String.Empty;
        public MusteriTakipForm()
        {
            InitializeComponent();
        }
        public void TableUpdate()
        {
            // TODO: Bu kod satırı 'kTMTDataSet.FL' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.fLTableAdapter.Fill(this.kTMTDataSet.FL);

            string querry = "select cihaz.chz_id as No, FL.fl_ad as Firma,musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon,";
            querry += "cihaz.chz_ad as CihazAdı,chz_ariza as Arıza,chz_fiyat as Fiyat,chz_son, CONVERT(VARCHAR(11), chz_geltarih, 103) as Tarih  ";
            querry += "from dbo.musteri join dbo.FL on FL.fl_id = musteri.fl_id ";
            querry += "join dbo.anatablo on musteri.m_id = anatablo.m_id ";
            querry += "join dbo.cihaz on cihaz.chz_id = anatablo.chz_id ";
            querry += "where cihaz.chz_live = 'true'";
            querry += "Order by No DESC";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            dataGridView.DataSource = dt;
            dataGridView.Columns["No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["Fiyat"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridView.Columns["m_id"].Visible = false;  
            dataGridView.Columns["chz_son"].Visible = false;
            sqlcon.Close();
        }
        private void MusteriTakipForm_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kTMTDataSet.FL' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.fLTableAdapter.Fill(this.kTMTDataSet.FL);
            TableUpdate();
            MusteriGlobals.form = this;
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

                cmbfirma.Text = dataGridView.Rows[row].Cells["Firma"].FormattedValue.ToString();

                txtadsoyad.Text = dataGridView.Rows[row].Cells["AdSoyad"].FormattedValue.ToString();
                txttel.Text = dataGridView.Rows[row].Cells["Telefon"].FormattedValue.ToString();

                txtfiyat.Text = dataGridView.Rows[row].Cells["Fiyat"].FormattedValue.ToString();
                txtcihazad.Text = dataGridView.Rows[row].Cells["CihazAdı"].FormattedValue.ToString();
                txtariza.Text = dataGridView.Rows[row].Cells["Arıza"].FormattedValue.ToString();
                string[] str = dataGridView.Rows[row].Cells["chz_son"].FormattedValue.ToString().Split('&');
                if (str.Length > 1)
                    txtson.Text = str[1];
                else
                    txtson.Text = str[0];
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

            cmbfirma.SelectedIndex = 0;
            txtadsoyad.Text = "";
            txttel.Text = "";

            txtfiyat.Text = "";

            txtcihazad.Text = "";
            txtariza.Text = "";
            txtson.Text = "";



        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Data Arşivleniyor ? ", "UYARI", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView.CurrentRow.Selected = true;
                string id = dataGridView.CurrentRow.Cells["No"].FormattedValue.ToString();
                sqlcon.Open();
                string querry = "UPDATE cihaz SET chz_live = @live where chz_id = @id";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                cmd.Parameters.AddWithValue("@live", false);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                TableUpdate();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (sqlcon.State == ConnectionState.Closed)
            {
                if (txtadsoyad.Text == "")
                {
                    MessageBox.Show("Ad giriniz.");
                    return;
                }

                int rowIndex = -1;
                foreach (DataGridViewRow row in dataGridView.Rows) 
                {
                    if (row.Cells["AdSoyad"].Value.ToString().Equals(txtadsoyad.Text) && 
                        row.Cells["CihazAdı"].Value.ToString().Equals(txtcihazad.Text) &&
                        row.Cells["Arıza"].Value.ToString().Equals(txtariza.Text))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }

                if(rowIndex != -1)
                {
                    MessageBox.Show("Aynı müşteri var!");
                    return;
                }

                int musteriid = 0;

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
                    fr.formNo = "Cihaz";
                    fr.musteriad = dt.Rows[0]["AdSoyad"].ToString();
                    fr.ShowDialog();
                    if (String.IsNullOrEmpty(musteriNo))
                    {

                        MessageBox.Show("Müşteri Seçmeniz Lazım");
                        return;

                    }
                    musteriid = Convert.ToInt32(musteriNo);
                    
                }
                else if(dt.Rows.Count == 0)
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
                    ///////////////////////////////
                    if (String.IsNullOrEmpty(txttel.Text)) // TEL
                        cmd.Parameters.AddWithValue("@m_tel", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@m_tel", txttel.Text.Trim());
                    ///////////////////////////////
                    musteriid = Convert.ToInt32(cmd.ExecuteScalar());
                    sqlcon.Close();
                }


                


                sqlcon.Open();
                string querry2 = "insert into [dbo].[cihaz] (chz_ad,chz_ariza,chz_geltarih,chz_fiyat,chz_son,chz_live) ";
                querry2 += "values (@chz_ad,@chz_ariza,@chz_geltarih,@chz_fiyat,@chz_son,@chz_live);";
                querry2 += "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
               
                if (String.IsNullOrEmpty(txtcihazad.Text)) // cihazAD
                    cmd2.Parameters.AddWithValue("@chz_ad", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@chz_ad", txtcihazad.Text.Trim());

                if (String.IsNullOrEmpty(txtariza.Text)) // cihazariza
                    cmd2.Parameters.AddWithValue("@chz_ariza", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@chz_ariza", txtariza.Text.Trim());

                if (String.IsNullOrEmpty(txtfiyat.Text)) // cihazAD
                    cmd2.Parameters.AddWithValue("@chz_fiyat", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@chz_fiyat", txtfiyat.Text.Trim());

                if (String.IsNullOrEmpty(txtson.Text)) // cihazek
                    cmd2.Parameters.AddWithValue("@chz_son", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@chz_son", ("&" + txtson.Text.Trim()));
                DateTime myDateTime = DateTime.Now;
                string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd2.Parameters.AddWithValue("@chz_geltarih", sqlDate);
                cmd2.Parameters.AddWithValue("@chz_live", true);
                int cihazid = Convert.ToInt32(cmd2.ExecuteScalar());



                string querry3 = "insert into [dbo].[anatablo] (m_id,chz_id) ";
                querry3 += "values (@m_id,@chz_id)";
                SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
                cmd3.Parameters.AddWithValue("@m_id", musteriid);
                cmd3.Parameters.AddWithValue("@chz_id", cihazid);
                cmd3.ExecuteNonQuery();
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

                string musteriid = dataGridView.Rows[row].Cells["m_id"].FormattedValue.ToString();
                string cihazid = dataGridView.Rows[row].Cells["No"].FormattedValue.ToString();
                MusteriBilgiForm fr = new MusteriBilgiForm();
                fr.musteriid = musteriid;
                fr.cihazid = cihazid;
                fr.ShowDialog();

            }
        }

        private void cmbfirma_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cmbfirma.Text != "Müşteri")
            {
                int sayi = Convert.ToInt32(cmbfirma.SelectedValue);
                string querry = "select FL.fl_adsoyad,fl_tel ";
                querry += "from dbo.FL where FL.fl_id = @fl_id";

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

        private void txttel_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txttel.Select(0, 0);
            });
        }

       
    }
    class MusteriGlobals
    {
        public static MusteriTakipForm form;
    }
}

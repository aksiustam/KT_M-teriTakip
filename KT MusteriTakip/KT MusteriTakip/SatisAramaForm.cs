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
    public partial class SatisAramaForm : Form
    {

        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);


        public SatisAramaForm()
        {
            InitializeComponent();
        }
        public void TableUpdate()
        {
            DateTime myDateTime = DateTime.Now.AddMonths(-3);

            dateTimePicker1.Value = myDateTime;


            string querry = "select FL.fl_ad as Firma,musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon,";
            querry += "satis.sat_id,sat_ad as Ad,sat_not as Bilgi,sat_satadet as Adet,satistablo.id,satistablo.sat_fiyat as Fiyat,CONVERT(VARCHAR(11), satistablo.sat_tarih, 103)  as Tarih ";
            querry += "from dbo.musteri join dbo.FL on FL.fl_id = musteri.fl_id ";
            querry += "join dbo.satistablo on musteri.m_id = satistablo.m_id ";
            querry += "join dbo.satis on satis.sat_id = satistablo.sat_id ";
            querry += "Where satistablo.sat_tarih >= @sat_geltarih and satistablo.sat_tarih <= @sat_gittarih ";
            querry += "Order by satistablo.id DESC";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            cmd.Parameters.AddWithValue("@sat_geltarih", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@sat_gittarih", dateTimePicker2.Value);
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            dataGridView.DataSource = dt;
            dataGridView.Columns["m_id"].Visible = false;
            dataGridView.Columns["sat_id"].Visible = false; 
            dataGridView.Columns["id"].Visible = false;

            sqlcon.Close();

        }
        private void SatisAramaForm_Load(object sender, EventArgs e)
        {
            TableUpdate();
        }
        public void satisarama()
        {
            List<string> allParams = new List<string>();
            //here add fields you want to filter and their impact on rowview in string form
            if (txtadsoyad.Text != "") { allParams.Add("AdSoyad like  '%" + txtadsoyad.Text.Trim() + "%'"); }
            if (txtfirma.Text != "") { allParams.Add("Firma like  '%" + txtfirma.Text.Trim() + "%'"); }
            if (txttel.Text != "") { allParams.Add("Telefon like  '%" + txttel.Text.Trim() + "%'"); }
            if (txtsatisad.Text != "") { allParams.Add("Ad like  '%" + txtsatisad.Text.Trim() + "%'"); }
            if (txtsatisbilgi.Text != "") { allParams.Add("Bilgi like  '%" + txtsatisbilgi.Text.Trim() + "%'"); }

            string finalFilter = string.Join(" and ", allParams);
            if (finalFilter != "")
            { (dataGridView.DataSource as DataTable).DefaultView.RowFilter = "(" + finalFilter + ")"; }
            else
            { (dataGridView.DataSource as DataTable).DefaultView.RowFilter = ""; }


            dataGridView.Refresh();
        }

        private void txtsatisad_TextChanged(object sender, EventArgs e)
        {
            satisarama();
        }

        private void txtadsoyad_TextChanged(object sender, EventArgs e)
        {
            satisarama();
        }

        private void txttel_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            satisarama();
        }

        private void txtfirma_TextChanged(object sender, EventArgs e)
        {
            satisarama();
        }

        private void txtsatisbilgi_TextChanged(object sender, EventArgs e)
        {
            satisarama();
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            

            txtadsoyad.Text = "";
            txtsatisad.Text = "";
            txtsatisbilgi.Text = "";
            txtfirma.Text = "";
            txttel.Text = "";

            DateTime myDateTime = DateTime.Now.AddMonths(-3);

            dateTimePicker1.Value = myDateTime;
            dateTimePicker2.Value = DateTime.Now;
            TableUpdate();
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Data Silinsin Mi ? ", "UYARI", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView.CurrentRow.Selected = true;
                string musteriid = dataGridView.CurrentRow.Cells["m_id"].FormattedValue.ToString();
                string satisid = dataGridView.CurrentRow.Cells["sat_id"].FormattedValue.ToString();
                
                sqlcon.Open();
                string querry3 = "DELETE FROM satistablo WHERE m_id = @m_id and sat_id = @sat_id";
                SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
                cmd3.Parameters.AddWithValue("@m_id", musteriid);
                cmd3.Parameters.AddWithValue("@sat_id", satisid);
                cmd3.ExecuteNonQuery();
                

                sqlcon.Close();
                TableUpdate();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

        }

        public void DateUpdate()
        {
            string querry = "select FL.fl_ad as Firma,musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon,";
            querry += "satis.sat_id,sat_ad as Ad,sat_not as Bilgi,sat_satadet as Adet,satistablo.id,satistablo.sat_fiyat as Fiyat,CONVERT(VARCHAR(11), satistablo.sat_tarih, 103)  as Tarih ";
            querry += "from dbo.musteri join dbo.FL on FL.fl_id = musteri.fl_id ";
            querry += "join dbo.satistablo on musteri.m_id = satistablo.m_id ";
            querry += "join dbo.satis on satis.sat_id = satistablo.sat_id ";
            querry += "Where satistablo.sat_tarih >= @sat_geltarih and satistablo.sat_tarih <= @sat_gittarih ";
            querry += "Order by satistablo.id DESC";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            cmd.Parameters.AddWithValue("@sat_geltarih", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@sat_gittarih", dateTimePicker2.Value);
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            dataGridView.DataSource = dt;
            dataGridView.Columns["m_id"].Visible = false;
            dataGridView.Columns["sat_id"].Visible = false;
            dataGridView.Columns["id"].Visible = false;
            sqlcon.Close();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateUpdate();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateUpdate();
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
                string satisid = dataGridView.Rows[row].Cells["sat_id"].FormattedValue.ToString();
                string id = dataGridView.Rows[row].Cells["id"].FormattedValue.ToString();
                SatisAramaBilgiForm fr = new SatisAramaBilgiForm();
                fr.musteriid = musteriid;
                fr.satisid = satisid;
                fr.id = id;
                fr.ShowDialog();

            }
        }
    }

}

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
    public partial class MusteriGenelAramaForm : Form
    {
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public MusteriGenelAramaForm()
        {
            InitializeComponent();
        }
        private void MusteriGenelAramaForm_Load(object sender, EventArgs e)
        {
            DateTime myDateTime = DateTime.Now.AddMonths(-3);

            dateTimePicker1.Value = myDateTime;

            this.fLTableAdapter.Fill(this.kTMTDataSet.FL);
            dataGrid();

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

        public void musteriarama()
        {
            List<string> allParams = new List<string>();
            //here add fields you want to filter and their impact on rowview in string form
            if (txtadsoyad.Text != "") { allParams.Add("AdSoyad like  '%" + txtadsoyad.Text.Trim() + "%'"); }
            if (txttel.Text != "") { allParams.Add("Telefon like  '%" + txttel.Text.Trim() + "%'"); }
            
            string finalFilter = string.Join(" and ", allParams);
            if (finalFilter != "")
            { 
                (dataGridViewCihaz.DataSource as DataTable).DefaultView.RowFilter = "(" + finalFilter + ")";
                (dataGridViewSatis.DataSource as DataTable).DefaultView.RowFilter = "(" + finalFilter + ")";
                (dataGridViewBorc.DataSource as DataTable).DefaultView.RowFilter = "(" + finalFilter + ")";
                (dataGridViewEmanet.DataSource as DataTable).DefaultView.RowFilter = "(" + finalFilter + ")";
            }
            else
            { 
                (dataGridViewCihaz.DataSource as DataTable).DefaultView.RowFilter = "";
                (dataGridViewSatis.DataSource as DataTable).DefaultView.RowFilter = "";
                (dataGridViewBorc.DataSource as DataTable).DefaultView.RowFilter = "";
                (dataGridViewEmanet.DataSource as DataTable).DefaultView.RowFilter = "";
            }
            dataGridViewCihaz.Refresh();
            dataGridViewSatis.Refresh();
            dataGridViewBorc.Refresh();
            dataGridViewEmanet.Refresh();
        }
        private void txtadsoyad_TextChanged(object sender, EventArgs e)
        {
            musteriarama();
        }

        private void txttel_TextChanged(object sender, EventArgs e)
        {
            musteriarama();
        }

        public void dataGrid()
        {
            string querry = "select cihaz.chz_id as No,musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon,";
            querry += "cihaz.chz_ad as CihazAdı,chz_ariza as Arıza ";
            querry += "from dbo.musteri ";
            querry += "join dbo.anatablo on musteri.m_id = anatablo.m_id ";
            querry += "join dbo.cihaz on cihaz.chz_id = anatablo.chz_id ";
            querry += "Where chz_geltarih >= @chz_geltarih and chz_geltarih <= @chz_gittarih ";
            querry += "Order by No DESC";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            cmd.Parameters.AddWithValue("@chz_geltarih", dateTimePicker1.Value);
            cmd.Parameters.AddWithValue("@chz_gittarih", dateTimePicker2.Value);
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            dataGridViewCihaz.DataSource = dt;
            dataGridViewCihaz.Columns["m_id"].Visible = false;
            dataGridViewCihaz.Columns["Telefon"].Visible = false;
            sqlcon.Close();


            string querry2 = "select musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon,";
            querry2 += "satis.sat_id,sat_ad as Ad,sat_not as Bilgi,satistablo.id ";
            querry2 += "from dbo.musteri ";
            querry2 += "join dbo.satistablo on musteri.m_id = satistablo.m_id ";
            querry2 += "join dbo.satis on satis.sat_id = satistablo.sat_id ";
            querry2 += "Where satistablo.sat_tarih >= @sat_geltarih and satistablo.sat_tarih <= @sat_gittarih ";
            querry2 += "Order by satistablo.id DESC";
            SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
            cmd2.Parameters.AddWithValue("@sat_geltarih", dateTimePicker1.Value);
            cmd2.Parameters.AddWithValue("@sat_gittarih", dateTimePicker2.Value);
            sqlcon.Open();
            SqlDataAdapter sdr2 = new SqlDataAdapter(cmd2);
            DataTable dt2 = new DataTable();
            sdr2.Fill(dt2);

            dataGridViewSatis.DataSource = dt2;
            dataGridViewSatis.Columns["m_id"].Visible = false;
            dataGridViewSatis.Columns["sat_id"].Visible = false;
            dataGridViewSatis.Columns["id"].Visible = false;

            sqlcon.Close();


            string querry3 = "select musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon, ";
            querry3 += "borc.borc_id,borc_borcid,borc_bilgi as Bilgi,borc_fiyat as Fiyat ";
            querry3 += "from dbo.borc join dbo.musteri on borc.m_id = musteri.m_id ";
            querry3 += "where borc.borc_tarih >= @borc_geltarih and borc.borc_tarih <= @borc_gittarih ";
            querry3 += "and borc_live = 'true' Order by borc_id DESC";
            SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
            cmd3.Parameters.AddWithValue("@borc_geltarih", dateTimePicker1.Value);
            cmd3.Parameters.AddWithValue("@borc_gittarih", dateTimePicker2.Value);
            sqlcon.Open();
            SqlDataAdapter sdr3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            sdr3.Fill(dt3);

            dataGridViewBorc.DataSource = dt3;
            dataGridViewBorc.Columns["borc_id"].Visible = false;
            dataGridViewBorc.Columns["borc_borcid"].Visible = false;
            dataGridViewBorc.Columns["m_id"].Visible = false;
            sqlcon.Close();

            string querry4 = "select musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon, ";
            querry4 += "emanet.e_id,e_bilgi as Bilgi,e_fiyat as Fiyat ";
            querry4 += "from dbo.emanet join dbo.musteri on emanet.m_id = musteri.m_id ";
            querry4 += "Where e_tarih >= @e_geltarih and e_tarih <= @e_gittarih ";
            querry4 += "and e_live = 'true' Order by e_id DESC";
            SqlCommand cmd4 = new SqlCommand(querry4, sqlcon);
            cmd4.Parameters.AddWithValue("@e_geltarih", dateTimePicker1.Value);
            cmd4.Parameters.AddWithValue("@e_gittarih", dateTimePicker2.Value);
            sqlcon.Open();
            SqlDataAdapter sdr4 = new SqlDataAdapter(cmd4);
            DataTable dt4 = new DataTable();
            sdr4.Fill(dt4);

            dataGridViewEmanet.DataSource = dt4;
            dataGridViewEmanet.Columns["e_id"].Visible = false;
            dataGridViewEmanet.Columns["m_id"].Visible = false;
            sqlcon.Close();
        }
        private void txttel_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txttel.Select(0, 0);
            });
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dataGrid();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dataGrid(); 
        }

        private void dataGridViewCihaz_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewCihaz.CurrentCell == null ||
            dataGridViewCihaz.CurrentCell.Value == null ||
            e.RowIndex == -1 || e.ColumnIndex == -1) return;
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (dataGridViewCihaz.Rows[row].Cells[col].Value != null)
            {

                dataGridViewCihaz.CurrentRow.Selected = true;

                string musteriid = dataGridViewCihaz.Rows[row].Cells["m_id"].FormattedValue.ToString();
                string cihazid = dataGridViewCihaz.Rows[row].Cells["No"].FormattedValue.ToString();
                MusteriBilgiForm fr = new MusteriBilgiForm();
                fr.musteriid = musteriid;
                fr.cihazid = cihazid;
                fr.ShowDialog();

            }
        }

        private void dataGridViewSatis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSatis.CurrentCell == null ||
          dataGridViewSatis.CurrentCell.Value == null ||
          e.RowIndex == -1 || e.ColumnIndex == -1) return;
            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (dataGridViewSatis.Rows[row].Cells[col].Value != null)
            {

                dataGridViewSatis.CurrentRow.Selected = true;

                string musteriid = dataGridViewSatis.Rows[row].Cells["m_id"].FormattedValue.ToString();
                string satisid = dataGridViewSatis.Rows[row].Cells["sat_id"].FormattedValue.ToString();
                string id = dataGridViewSatis.Rows[row].Cells["id"].FormattedValue.ToString();
                SatisAramaBilgiForm fr = new SatisAramaBilgiForm();
                fr.musteriid = musteriid;
                fr.satisid = satisid;
                fr.id = id;
                fr.ShowDialog();

            }
        }

        private void dataGridViewBorc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewBorc.CurrentCell == null ||
            dataGridViewBorc.CurrentCell.Value == null ||
            e.RowIndex == -1 || e.ColumnIndex == -1) return;

            int row = e.RowIndex;
            int col = e.ColumnIndex;



            if (dataGridViewBorc.Rows[row].Cells[col].Value != null)
            {

                dataGridViewBorc.CurrentRow.Selected = true;

                string borcid = dataGridViewBorc.Rows[row].Cells["borc_id"].FormattedValue.ToString();
                string son = dataGridViewBorc.Rows[row].Cells["borc_borcid"].FormattedValue.ToString();
                string musteriid = dataGridViewBorc.Rows[row].Cells["m_id"].FormattedValue.ToString();
                string[] ara = son.Split(',');
                if (ara.Length > 1)
                {
                    string formbilgi = ara[0];
                    string id = ara[1];
                    if (formbilgi == "cihaz")
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

        private void dataGridViewEmanet_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewEmanet.CurrentCell == null ||
            dataGridViewEmanet.CurrentCell.Value == null ||
            e.RowIndex == -1 || e.ColumnIndex == -1) return;

            int row = e.RowIndex;
            int col = e.ColumnIndex;

            if (dataGridViewEmanet.Rows[row].Cells[col].Value != null)
            {

                dataGridViewEmanet.CurrentRow.Selected = true;
                string eid = dataGridViewEmanet.Rows[row].Cells["e_id"].FormattedValue.ToString();
                string mid = dataGridViewEmanet.Rows[row].Cells["m_id"].FormattedValue.ToString();
                EmanetBilgiForm fr = new EmanetBilgiForm();

                fr.eid = eid;
                fr.mid = mid;
                fr.ShowDialog();
            }
        }
    }
}

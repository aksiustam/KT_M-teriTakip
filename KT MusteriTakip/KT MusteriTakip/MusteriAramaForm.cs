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
    public partial class MusteriAramaForm : Form
    {

        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public MusteriAramaForm()
        {
            InitializeComponent();
        }

        public void TableUpdate()
        {
            DateTime myDateTime = DateTime.Now.AddMonths(-3);

            dateTimePicker1.Value = myDateTime;


            string querry = "select cihaz.chz_id as No , FL.fl_ad as Firma,musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon,";
            querry += "cihaz.chz_ad as CihazAdı,chz_ariza as Arıza, CONVERT(VARCHAR(11), chz_geltarih, 103) as Tarih  ";
            querry += "from dbo.musteri join dbo.FL on FL.fl_id = musteri.fl_id ";
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

            dataGridView.DataSource = dt;
            dataGridView.Columns["No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            
            dataGridView.Columns["m_id"].Visible = false;
            
            sqlcon.Close();

        }
        private void MusteriAramaForm_Load(object sender, EventArgs e)
        {
            TableUpdate();
            

        }

        public void musteriarama()
        {
            List<string> allParams = new List<string>();
            //here add fields you want to filter and their impact on rowview in string form
            if (txtadsoyad.Text != "") { allParams.Add("AdSoyad like  '%" + txtadsoyad.Text.Trim() + "%'"); }
            if (txtfirma.Text != "") { allParams.Add("Firma like  '%" + txtfirma.Text.Trim() + "%'"); }
            if (txttel.Text != "") { allParams.Add("Telefon like  '%" + txttel.Text.Trim() + "%'"); }
            if (txtcihazad.Text != "") { allParams.Add("CihazAdı like  '%" + txtcihazad.Text.Trim() + "%'"); }
            if (txtariza.Text != "") { allParams.Add("Arıza like  '%" + txtariza.Text.Trim() + "%'"); }

            string finalFilter = string.Join(" and ", allParams);
            if (finalFilter != "")
            { (dataGridView.DataSource as DataTable).DefaultView.RowFilter = "(" + finalFilter + ")"; }
            else
            { (dataGridView.DataSource as DataTable).DefaultView.RowFilter = ""; }


            dataGridView.Refresh();
        }

        private void txtadsoyad_TextChanged(object sender, EventArgs e)
        {
            musteriarama();
        }
        


        private void txtfirma_TextChanged(object sender, EventArgs e)
        {
            musteriarama();
        }

        private void txttel_TextChanged(object sender, EventArgs e)
        {
            musteriarama();
        }

        private void txtcihazad_TextChanged(object sender, EventArgs e)
        {
            musteriarama();
        }

        private void txtcihazmarka_TextChanged(object sender, EventArgs e)
        {
            musteriarama();
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
                MusteriAramaBilgiForm fr = new MusteriAramaBilgiForm();
                fr.musteriid = musteriid;
                fr.cihazid = cihazid;
                fr.ShowDialog();

            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            TableUpdate();

            txtadsoyad.Text = "";
            txtcihazad.Text = "";
            txtariza.Text = "";
            txtfirma.Text = "";
            txttel.Text = "";
            
            DateTime myDateTime = DateTime.Now.AddMonths(-3);

            dateTimePicker1.Value = myDateTime;
            dateTimePicker2.Value = DateTime.Now;
        }

        public void DateUpdate()
        {
            string querry = "select cihaz.chz_id as No, FL.fl_ad as Firma,musteri.m_id,m_adsoyad as AdSoyad,m_tel as Telefon,";
            querry += "chz_ad as CihazAdı,chz_ariza as Arıza, CONVERT(VARCHAR(11), chz_geltarih, 103) as Tarih ";
            querry += "from dbo.musteri join dbo.FL on FL.fl_id = musteri.fl_id ";
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

            dataGridView.DataSource = dt;
            dataGridView.Columns["No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            
            dataGridView.Columns["m_id"].Visible = false;
            
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

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Data Silinsin Mi ? ", "UYARI", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView.CurrentRow.Selected = true;
                string musteriid = dataGridView.CurrentRow.Cells["m_id"].FormattedValue.ToString();
                string cihazid = dataGridView.CurrentRow.Cells["No"].FormattedValue.ToString();

                sqlcon.Open();
                string querry3 = "DELETE FROM anatablo WHERE m_id = @m_id and chz_id = @chz_id";
                SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
                cmd3.Parameters.AddWithValue("@m_id", musteriid);
                cmd3.Parameters.AddWithValue("@chz_id", cihazid);
                cmd3.ExecuteNonQuery();
                string querry2 = "DELETE FROM cihaz WHERE chz_id = @chz_id";
                SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
                cmd2.Parameters.AddWithValue("@chz_id", cihazid);
                cmd2.ExecuteNonQuery();
                
                
                sqlcon.Close();
                TableUpdate();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
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
}

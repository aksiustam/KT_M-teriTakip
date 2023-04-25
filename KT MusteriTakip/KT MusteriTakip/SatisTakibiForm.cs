using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
   
    public partial class SatisTakibiForm : Form
    {
        
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);

        


        public SatisTakibiForm()
        {
            InitializeComponent();
        }
        public void TableUpdate()
        {
            string querry = "";
            if (checkBoxstok.Checked == true)
            {
                querry = "select satis.sat_id,sat_ad as Ad,sat_not as Bilgi,sat_adet as Adet ";
                querry += "from dbo.satis ";
                querry += "where sat_adet > '0'";
                querry += "Order by sat_id DESC";

            }
            if (checkBoxstok.Checked == false)
            {
                querry = "select satis.sat_id,sat_ad as Ad,sat_not as Bilgi,sat_adet as Adet ";
                querry += "from dbo.satis ";
                querry += "where sat_adet >= '0'";
                querry += "Order by sat_id DESC";
            }
            
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            dataGridView.DataSource = dt;
            dataGridView.Columns["sat_id"].Visible = false;

            dataGridView.Columns["Bilgi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sqlcon.Close();
        }
        private void SatisTakibiForm_Load(object sender, EventArgs e)
        {
            TableUpdate();
            SatisGlobals.form = this;
        }

        public void satisarama()
        {
            
            
            List<string> allParams = new List<string>();
            //here add fields you want to filter and their impact on rowview in string form
            if (txturunad.Text != "") { allParams.Add("Ad like  '%" + txturunad.Text.Trim() + "%'"); }
            if (txturunnot.Text != "") { allParams.Add("Bilgi like  '%" + txturunnot.Text.Trim() + "%'"); }
           
            string finalFilter = string.Join(" and ", allParams);
            if (finalFilter != "")
            { (dataGridView.DataSource as DataTable).DefaultView.RowFilter = "(" + finalFilter + ")"; }
            else
            { (dataGridView.DataSource as DataTable).DefaultView.RowFilter = ""; }
 
            dataGridView.Refresh();
            
        }
        private void txturunad_TextChanged(object sender, EventArgs e)
        {
                satisarama();
        }

        private void txturunnot_TextChanged(object sender, EventArgs e)
        {
            
                satisarama();

        }

        

        private void btnclear_Click(object sender, EventArgs e)
        {
            txturunad.Text = "";
            txturunnot.Text = "";
            
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
                string ad = dataGridView.Rows[row].Cells["Ad"].FormattedValue.ToString();
                string not = dataGridView.Rows[row].Cells["Bilgi"].FormattedValue.ToString();
                txturunad.Text = ad;
                txturunnot.Text = not;    
            }
            
            
            
            
        }

        private void checkBoxstok_CheckedChanged(object sender, EventArgs e)
        {
            string querry = "";
            if (checkBoxstok.Checked == true)
            {
                querry = "select satis.sat_id,sat_ad as Ad,sat_not as Bilgi,sat_adet as Adet ";
                querry += "from dbo.satis ";
                querry += "where sat_adet > '0'";
                querry += "Order by sat_id DESC";

            }
            if (checkBoxstok.Checked == false)
            {
                querry = "select satis.sat_id,sat_ad as Ad,sat_not as Bilgi,sat_adet as Adet ";
                querry += "from dbo.satis ";
                querry += "where sat_adet >= '0'";
                querry += "Order by sat_id DESC";
            }
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            sqlcon.Open();
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);

            dataGridView.DataSource = dt;
            dataGridView.Columns["sat_id"].Visible = false;

            dataGridView.Columns["Bilgi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            sqlcon.Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            
            
            string urunad = "";
            string urunnot = "";
            if (!(String.IsNullOrEmpty(txturunad.Text)))
                urunad = txturunad.Text.Trim();
            if (!(String.IsNullOrEmpty(txturunnot.Text)))
                urunnot = txturunnot.Text.Trim();
            SatisEkleForm fr = new SatisEkleForm();
            fr.urunad = urunad;
            fr.urunnot = urunnot;
            
            fr.Show();

        }

        private void btnsat_Click(object sender, EventArgs e)
        {
            int adet = Convert.ToInt32(dataGridView.CurrentRow.Cells["Adet"].FormattedValue);
            if (adet == 0)
            {
                MessageBox.Show("Adeti 0 olanlar satılmaz!");
                return;
            }
            else
            {
                string satisid = dataGridView.CurrentRow.Cells["sat_id"].FormattedValue.ToString();
                string urunad = dataGridView.CurrentRow.Cells["Ad"].FormattedValue.ToString();
                string urunnot = dataGridView.CurrentRow.Cells["Bilgi"].FormattedValue.ToString();
                SatisSatisForm fr = new SatisSatisForm();
                fr.satisid = satisid;
                fr.urunad = urunad;
                fr.urunnot = urunnot;
                fr.Show();
            }
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Data Silinsin Mi ? ", "UYARI", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                dataGridView.CurrentRow.Selected = true;
                string id = dataGridView.CurrentRow.Cells["sat_id"].FormattedValue.ToString();
                sqlcon.Open();
                string querry = "DELETE FROM satis WHERE sat_id = @sat_id";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                cmd.Parameters.AddWithValue("@sat_id", id);
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                TableUpdate();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
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
                string satisid = dataGridView.Rows[row].Cells["sat_id"].FormattedValue.ToString();
                SatisBilgiForm fr = new SatisBilgiForm();
                fr.satisid = satisid;
                fr.Show();
            }
        }
    }

    class SatisGlobals
    {
        public static SatisTakibiForm form;
    }
}

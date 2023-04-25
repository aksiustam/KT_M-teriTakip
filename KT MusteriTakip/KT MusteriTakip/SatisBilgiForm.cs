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
    public partial class SatisBilgiForm : Form
    {

        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);

        public string satisid = String.Empty;
        public SatisBilgiForm()
        {
            InitializeComponent();
        }

        private void SatisBilgiForm_Load(object sender, EventArgs e)
        {

            sqlcon.Open();
            string querry = "select satis.sat_ad,sat_not,sat_gelis,sat_adet ";
            querry += "from satis where sat_id = @sat_id ";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);
            cmd.Parameters.AddWithValue("@sat_id", satisid);
            SqlDataAdapter sdr = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sdr.Fill(dt);
            sqlcon.Close();
            if(dt.Rows.Count > 0)
            {
                txtsatisad.Text = dt.Rows[0]["sat_ad"].ToString();
                txtsatisnot.Text = dt.Rows[0]["sat_not"].ToString();
                txtsatisucret.Text = dt.Rows[0]["sat_gelis"].ToString();
                txtsatisadet.Text = dt.Rows[0]["sat_adet"].ToString();

            }


        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            sqlcon.Open();
            string querry = "UPDATE satis SET sat_ad = @sat_ad , sat_not = @sat_not,";
            querry += "sat_gelis = @sat_gelis, sat_adet = @sat_adet where sat_id = @sat_id";
            SqlCommand cmd = new SqlCommand(querry, sqlcon);

            cmd.Parameters.AddWithValue("@sat_ad", txtsatisad.Text.Trim());
            cmd.Parameters.AddWithValue("@sat_not", txtsatisnot.Text.Trim());
            cmd.Parameters.AddWithValue("@sat_gelis", txtsatisucret.Text.Trim());
            cmd.Parameters.AddWithValue("@sat_adet", txtsatisadet.Text.Trim());
            cmd.Parameters.AddWithValue("@sat_id", satisid);
            cmd.ExecuteNonQuery();
            sqlcon.Close();

            AutoClosingMessageBox.Show("Kaydedildi!", "Uyarı!", 1000);
            SatisGlobals.form.TableUpdate();
            this.Close();
        }
    }


}

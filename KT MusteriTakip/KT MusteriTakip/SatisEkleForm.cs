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

    public partial class SatisEkleForm : Form
    {
        public string urunad = String.Empty;
        public string urunnot = String.Empty;

        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public SatisEkleForm()
        {
            InitializeComponent();
        }

        private void SatisEkleForm_Load(object sender, EventArgs e)
        {
            txtsatisad.Text = urunad;
            txtsatisnot.Text = urunnot;
        }

        private void btnekle_Click(object sender, EventArgs e)
        {

            if (sqlcon.State == ConnectionState.Closed)
            {

                sqlcon.Open();
                string querry = "insert into [dbo].[satis] (sat_ad,sat_not,sat_gelis,sat_tarih,sat_adet) ";
                querry += "values (@sat_ad,@sat_not,@sat_gelis,@sat_tarih,@sat_adet);";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                if (String.IsNullOrEmpty(txtsatisad.Text)) // AD
                    cmd.Parameters.AddWithValue("@sat_ad", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@sat_ad", txtsatisad.Text.Trim());
                ///////////////////////////////
                if (String.IsNullOrEmpty(txtsatisnot.Text)) // SOYAD
                    cmd.Parameters.AddWithValue("@sat_not", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@sat_not", txtsatisnot.Text.Trim());
                ///////////////////////////////
                if (String.IsNullOrEmpty(txtsatisucret.Text)) // TC
                    cmd.Parameters.AddWithValue("@sat_gelis", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@sat_gelis", txtsatisucret.Text.Trim());
                ///////////////////////////////
                if (String.IsNullOrEmpty(txtsatisadet.Text)) // TEL
                    cmd.Parameters.AddWithValue("@sat_adet", DBNull.Value);
                else
                    cmd.Parameters.AddWithValue("@sat_adet", txtsatisadet.Text.Trim());
                DateTime myDateTime = DateTime.Now;
                string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd.Parameters.AddWithValue("@sat_tarih", sqlDate);
                cmd.ExecuteNonQuery();
                sqlcon.Close();
                AutoClosingMessageBox.Show("Veri Eklendi!", "Uyarı!", 1000);
                
                this.Close();
            }

            else
            {
                MessageBox.Show("Veri Kaydı Başarısız !");
            }
        }
    }


    public class AutoClosingMessageBox
    {
        System.Threading.Timer _timeoutTimer;
        string _caption;
        AutoClosingMessageBox(string text, string caption, int timeout)
        {
            _caption = caption;
            _timeoutTimer = new System.Threading.Timer(OnTimerElapsed,
                null, timeout, System.Threading.Timeout.Infinite);
            using (_timeoutTimer)
                MessageBox.Show(text, caption);
        }
        public static void Show(string text, string caption, int timeout)
        {
            new AutoClosingMessageBox(text, caption, timeout);
        }
        void OnTimerElapsed(object state)
        {
            IntPtr mbWnd = FindWindow("#32770", _caption); // lpClassName is #32770 for MessageBox
            if (mbWnd != IntPtr.Zero)
                SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            _timeoutTimer.Dispose();
        }
        const int WM_CLOSE = 0x0010;
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImport("user32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);
    }
}

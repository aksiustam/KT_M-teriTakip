using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KT_MusteriTakip.KTMTDataSet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace KT_MusteriTakip
{
    public partial class SatisSatisForm : Form
    {
        public string musteriNo = String.Empty;
        public string urunad = String.Empty;
        public string urunnot = String.Empty;
        public string satisid = String.Empty;
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);

        
        public SatisSatisForm()
        {
            InitializeComponent();
        }

        private void SatisSatisForm_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'kTMTDataSet.FL' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.fLTableAdapter.Fill(this.kTMTDataSet.FL);
            SatisSatisGlobals.form = this;
            txtsatisad.Text = urunad;
            txtsatisnot.Text = urunnot;

        }

      
        private void btnyeni_Click(object sender, EventArgs e)
        {

            if (txtsatisad.Enabled)
            {
                txtsatisad.Text = urunad;
                txtsatisad.Enabled = false;
            }
            else
            {
                
                txtsatisad.Enabled = true;
            }
                

            if (txtsatisnot.Enabled)
            {
                txtsatisnot.Text = urunnot;
                txtsatisnot.Enabled = false;
                
            }  
            else
            {
                
                txtsatisnot.Enabled = true;
            }
                


        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            int satissonid = 0;
            int musteriid = 0;
            bool  kontrolsatis = false;
            if (txtsatisad.Enabled && txtsatisnot.Enabled)
                kontrolsatis = true;


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
                fr.formNo = "Satis";
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

            if(kontrolsatis)
            {
                sqlcon.Open();
                string querry3 = "insert into [dbo].[satis] (sat_ad,sat_not,sat_tarih,sat_adet) ";
                querry3 += "values (@sat_ad,@sat_not,@sat_tarih,@sat_adet);";
                querry3 += "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
                if (String.IsNullOrEmpty(txtsatisad.Text)) // cihazariza
                    cmd3.Parameters.AddWithValue("@sat_ad", DBNull.Value);
                else
                    cmd3.Parameters.AddWithValue("@sat_ad", txtsatisad.Text.Trim());
                if (String.IsNullOrEmpty(txtsatisnot.Text)) // cihazariza
                    cmd3.Parameters.AddWithValue("@sat_not", DBNull.Value);
                else
                    cmd3.Parameters.AddWithValue("@sat_not", txtsatisnot.Text.Trim());

                DateTime myDateTime = DateTime.Now;
                string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd3.Parameters.AddWithValue("@sat_tarih", sqlDate);
                cmd3.Parameters.AddWithValue("@sat_adet", 0);
                int satid = Convert.ToInt32(cmd3.ExecuteScalar());
                
                string querry2 = "insert into [dbo].[satistablo] (sat_id,m_id,sat_fiyat,sat_tarih,sat_satadet,sat_bilgi) ";
                querry2 += "values (@sat_id,@m_id,@sat_fiyat,@sat_tarih,@sat_satadet,@sat_bilgi);";
                querry2 += "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
                cmd2.Parameters.AddWithValue("@sat_id", satid);
                cmd2.Parameters.AddWithValue("@m_id", musteriid);
                cmd2.Parameters.AddWithValue("@sat_tarih", sqlDate);
                if (String.IsNullOrEmpty(txtsatisucret.Text)) // cihazariza
                    cmd2.Parameters.AddWithValue("@sat_fiyat", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@sat_fiyat", txtsatisucret.Text.Trim());

                
                cmd2.Parameters.AddWithValue("@sat_satadet", numAdet.Value);
                if (String.IsNullOrEmpty(txtsatisbilgi.Text)) // cihazariza
                    cmd2.Parameters.AddWithValue("@sat_bilgi", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@sat_bilgi", txtsatisbilgi.Text.Trim());

                
                satissonid = Convert.ToInt32(cmd2.ExecuteScalar());
                sqlcon.Close();
                


            }
            else
            {

                sqlcon.Open();
                string adetquerry = "Select sat_adet from [dbo].[satis] ";
                adetquerry += "where sat_id = @sat_id ";
                
                SqlCommand adetcmd = new SqlCommand(adetquerry, sqlcon);
                adetcmd.Parameters.AddWithValue("@sat_id", satisid);
                int adet = Convert.ToInt32(adetcmd.ExecuteScalar());
                if (adet > 0)
                {

                    if (numAdet.Value != 1)
                    {
                        adet = adet - (int)numAdet.Value;
                        if (adet < 0)
                        {
                            adet = 0;
                        }
                    }
                    else
                        adet--;
                    string querry4 = "UPDATE satis SET sat_adet = @adet WHERE sat_id = @sat_id ";
                    SqlCommand cmd4 = new SqlCommand(querry4, sqlcon);
                    cmd4.Parameters.AddWithValue("@adet", adet);
                    cmd4.Parameters.AddWithValue("@sat_id", satisid);
                    cmd4.ExecuteNonQuery();

                }


                string querry2 = "insert into [dbo].[satistablo] (sat_id,m_id,sat_fiyat,sat_tarih,sat_satadet,sat_bilgi) ";
                querry2 += "values (@sat_id,@m_id,@sat_fiyat,@sat_tarih,@sat_satadet,@sat_bilgi);";
                querry2 += "SELECT SCOPE_IDENTITY()";
                SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
                cmd2.Parameters.AddWithValue("@sat_id", satisid);
                cmd2.Parameters.AddWithValue("@m_id", musteriid);
                DateTime myDateTime = DateTime.Now;
                string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd2.Parameters.AddWithValue("@sat_tarih", sqlDate);
                cmd2.Parameters.AddWithValue("@sat_satadet", (int)numAdet.Value);
                if (String.IsNullOrEmpty(txtsatisucret.Text)) // cihazariza
                    cmd2.Parameters.AddWithValue("@sat_fiyat", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@sat_fiyat", txtsatisucret.Text.Trim());

                if (String.IsNullOrEmpty(txtsatisbilgi.Text)) // cihazariza
                    cmd2.Parameters.AddWithValue("@sat_bilgi", DBNull.Value);
                else
                    cmd2.Parameters.AddWithValue("@sat_bilgi", txtsatisbilgi.Text.Trim());
                satissonid = Convert.ToInt32(cmd2.ExecuteScalar());
                
                sqlcon.Close();

            }


            if(checkBoxborc.Checked)
            {
                sqlcon.Open();
                string querry5 = "insert into [dbo].[borc] (m_id,borc_borcid,borc_bilgi,borc_tarih,borc_fiyat,borc_live) ";
                querry5 += "values (@m_id,@borc_borcid,@borc_bilgi,@borc_tarih,@borc_fiyat,@borc_live);";
                SqlCommand cmd5 = new SqlCommand(querry5, sqlcon);
                cmd5.Parameters.AddWithValue("@m_id", musteriid);
                cmd5.Parameters.AddWithValue("@borc_borcid", "satis," + satissonid);
                cmd5.Parameters.AddWithValue("@borc_bilgi", "satis borcu");
                DateTime myDateTime = DateTime.Now;
                string sqlDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
                cmd5.Parameters.AddWithValue("@borc_tarih", sqlDate);
                cmd5.Parameters.AddWithValue("@borc_live", true);
                cmd5.Parameters.AddWithValue("@borc_fiyat", txtsatisucret.Text.Trim());
                cmd5.ExecuteNonQuery();
                sqlcon.Close();
            }
            AutoClosingMessageBox.Show("İşlem Tamam!", "Uyarı!", 1000);
            this.Close();
            
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
                if(dt.Rows.Count > 0)
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

        

        private void SatisSatisForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            SatisGlobals.form.TableUpdate();

        }

        private void txttel_Enter(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate ()
            {
                txttel.Select(0, 0);
            });
        }
    }
    class SatisSatisGlobals
    {
        public static SatisSatisForm form;
    }

}

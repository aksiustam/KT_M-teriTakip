using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace KT_MusteriTakip
{
    public partial class AyarlarDataYedek : Form
    {
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public AyarlarDataYedek()
        {
            InitializeComponent();
        }

        private void AyarlarDataYedek_Load(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                string database = sqlcon.Database.ToString();
                string querry = "BACKUP DATABASE [" + database + "] TO DISK =";
               querry += "'" + txtfile1.Text + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd") + ".bak'";
                SqlCommand cmd = new SqlCommand(querry, sqlcon);
                sqlcon.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Database Yedeklendi.");
                sqlcon.Close();

            
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlcon.Close();
            }
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fr = new FolderBrowserDialog();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                txtfile1.Text = fr.SelectedPath;
                button1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog fr= new OpenFileDialog(); 
            fr.Filter = "SQL SERVER database backup files(*.bak)|*.bak";
            fr.Title = "Database restore";
            if(fr.ShowDialog() == DialogResult.OK)
            {
                txtfile2.Text = fr.FileName;
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string database = sqlcon.Database.ToString();
            
            sqlcon.Open();

            try
            {
                string querry1 = String.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                SqlCommand cmd1 = new SqlCommand(querry1, sqlcon);
                cmd1.ExecuteNonQuery();

                string querry2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK ='" + txtfile2.Text + "' WITH REPLACE;";
                SqlCommand cmd2 = new SqlCommand(querry2, sqlcon);
                cmd2.ExecuteNonQuery();

                string querry3 = String.Format("ALTER DATABASE [" + database + "] SET MULTI_USER ");
                SqlCommand cmd3 = new SqlCommand(querry3, sqlcon);
                cmd3.ExecuteNonQuery();


                MessageBox.Show("Database Başarıyla Geri Yüklendi.");
                sqlcon.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlcon.Close();
            }
        }
    }
}

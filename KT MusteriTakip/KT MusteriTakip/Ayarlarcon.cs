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
    public partial class Ayarlarcon : Form
    {
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public Ayarlarcon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Ayarları Değiştireceksiniz. ", "UYARI", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string constring = "Data Source=" + textBox1.Text + ";Initial Catalog=" + textBox2.Text + ";";
                constring += "Persist Security Info=True;User ID=" + textBox3.Text + ";Password=" + textBox4.Text;
                var config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
                connectionStringsSection.ConnectionStrings["KT_MusteriTakip.Properties.Settings.KTMTConnectionString"].ConnectionString = constring;
                config.Save(ConfigurationSaveMode.Modified, true);
                ConfigurationManager.RefreshSection("connectionStrings");
                MessageBox.Show("Ayarlar Değiştirildi.\nAyarların uygulanması için lütfen programı yeniden başlatın.");

            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }

            
        }

        private void Ayarlarcon_Load(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder myBuilder = new SqlConnectionStringBuilder(Properties.Settings.Default.KTMTConnectionString);
            textBox1.Text = myBuilder.DataSource;
            textBox2.Text = myBuilder.InitialCatalog;
            textBox3.Text = myBuilder.UserID;
            textBox4.Text = myBuilder.Password;

        }
    }
}

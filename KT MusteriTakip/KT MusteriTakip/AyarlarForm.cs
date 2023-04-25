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
    public partial class AyarlarForm : Form
    {
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        public int sayi = 0;
        public AyarlarForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            sayi++;
            if (sayi == 1)
                Properties.Settings.Default.Renk = Color.CadetBlue;
            else if (sayi == 2)
                Properties.Settings.Default.Renk = Color.DeepSkyBlue;
            else if (sayi == 3)
                Properties.Settings.Default.Renk = Color.SlateBlue;
            else if (sayi == 4)
                Properties.Settings.Default.Renk = Color.Aquamarine;
            else if (sayi == 5)
                Properties.Settings.Default.Renk = Color.LightGreen;
            else if (sayi > 5)
                sayi = 1;

            Properties.Settings.Default.Save();
        }

        private void AyarlarForm_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Ayarlarcon fr = new Ayarlarcon();
            fr.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AyarlarDataYedek fr = new AyarlarDataYedek();
            fr.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AyarlarFirma fr = new AyarlarFirma();
            fr.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

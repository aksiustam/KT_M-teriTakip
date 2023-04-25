using KT_MusteriTakip.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static KT_MusteriTakip.KTMTDataSet;

namespace KT_MusteriTakip
{
    
    public partial class AnaForm : Form
    {
        static string constring = Properties.Settings.Default.KTMTConnectionString;
        SqlConnection sqlcon = new SqlConnection(constring);
        private string pass = String.Empty;
        public AnaForm()
        {
            InitializeComponent();
            customizeDesing();
        }

        private void customizeDesing()
        {
            panelBorcMenu.Visible = false;
            panelMusteriMenu.Visible = false;
            panelSatisMenu.Visible = false;
        }
        private void hideSubMenu()
        {
            if(panelBorcMenu.Visible == true)
                panelBorcMenu.Visible = false;
            if (panelMusteriMenu.Visible == true)
                panelMusteriMenu.Visible = false;
            if (panelSatisMenu.Visible == true)
                panelSatisMenu.Visible = false;
        }

        private void showSubMenu (Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
                subMenu.Visible = false;
        }
        private void AnaForm_Load(object sender, EventArgs e)
        {
            



        }

        private void AnaForm_Shown(object sender, EventArgs e)
        {
            labelsql.Text = "SQL AÇILIYOR!";
            
             
            bool sqlbit = true;
            try
            {
                sqlcon.Open();
            }
            catch (Exception f)
            {
                sqlbit = false;
            }
            if (sqlbit)
                labelsql.Text = "SQL SERVER ÇALIŞIYOR";
            else
                labelsql.Text = "SQL SERVER ÇALIŞMIYOR";

            

        }
        #region MenuButton
        private void btnMusteri_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            showSubMenu(panelMusteriMenu);
        }

        private void btnMusteriTakip_Click(object sender, EventArgs e)
        {
            openContainerForm(new MusteriTakipForm());
           
            
        }

        private void btnMusteriArama_Click(object sender, EventArgs e)
        {
            openContainerForm(new MusteriAramaForm());
           
            
        }
        private void btnGenelArama_Click(object sender, EventArgs e)
        {
            openContainerForm(new MusteriGenelAramaForm());
        }
        private void btnSatis_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            showSubMenu(panelSatisMenu);
        }
        private void btnSatisTakip_Click(object sender, EventArgs e)
        {
            openContainerForm(new SatisTakibiForm());
            
            
        }

        private void btnSatisArama_Click(object sender, EventArgs e)
        {
            openContainerForm(new SatisAramaForm());

        }
        private void btnBorcEmanet_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            showSubMenu(panelBorcMenu);
        }

        private void btnBorc_Click(object sender, EventArgs e)
        {
            openContainerForm(new BorcForm());
        }

        private void btnEmanet_Click(object sender, EventArgs e)
        {
            openContainerForm(new EmanetForm());
        }
        private void btnAlınacaklar_Click(object sender, EventArgs e)
        {
            openContainerForm(new AlınacaklarForm());
        }

        private void btnGunluk_Click(object sender, EventArgs e)
        {
            openContainerForm(new GunForm());
        }
        private void btnHesaplar_Click(object sender, EventArgs e)
        {
            openContainerForm(new HesaplarForm());
           
            hideSubMenu();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            openContainerForm(new AyarlarForm());
            
            hideSubMenu();
        }
       


        #endregion

        private Form activeForm = null; 
        private void openContainerForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(childForm);
            panelContainer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
    }
}

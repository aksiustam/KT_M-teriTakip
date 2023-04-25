namespace KT_MusteriTakip
{
    partial class AnaForm
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.labelsql = new System.Windows.Forms.Label();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.panelSideMenu = new System.Windows.Forms.Panel();
            this.btnAyarlar = new System.Windows.Forms.Button();
            this.btnRakamlar = new System.Windows.Forms.Button();
            this.panelBorcMenu = new System.Windows.Forms.Panel();
            this.btnGunluk = new System.Windows.Forms.Button();
            this.btnAlınacaklar = new System.Windows.Forms.Button();
            this.btnEmanet = new System.Windows.Forms.Button();
            this.btnBorc = new System.Windows.Forms.Button();
            this.btnHesaplar = new System.Windows.Forms.Button();
            this.panelSatisMenu = new System.Windows.Forms.Panel();
            this.btnSatisArama = new System.Windows.Forms.Button();
            this.btnSatisTakip = new System.Windows.Forms.Button();
            this.btnSatis = new System.Windows.Forms.Button();
            this.panelMusteriMenu = new System.Windows.Forms.Panel();
            this.btnGenelArama = new System.Windows.Forms.Button();
            this.btnMusteriArama = new System.Windows.Forms.Button();
            this.btnMusteriTakip = new System.Windows.Forms.Button();
            this.btnMusteri = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelSideMenu.SuspendLayout();
            this.panelBorcMenu.SuspendLayout();
            this.panelSatisMenu.SuspendLayout();
            this.panelMusteriMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panelContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelsql
            // 
            this.labelsql.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelsql.AutoSize = true;
            this.labelsql.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelsql.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelsql.Location = new System.Drawing.Point(440, 437);
            this.labelsql.Name = "labelsql";
            this.labelsql.Size = new System.Drawing.Size(30, 15);
            this.labelsql.TabIndex = 2;
            this.labelsql.Text = "Test";
            // 
            // dtp
            // 
            this.dtp.Enabled = false;
            this.dtp.Location = new System.Drawing.Point(471, 12);
            this.dtp.Name = "dtp";
            this.dtp.Size = new System.Drawing.Size(151, 20);
            this.dtp.TabIndex = 3;
            // 
            // panelSideMenu
            // 
            this.panelSideMenu.AutoScroll = true;
            this.panelSideMenu.BackColor = global::KT_MusteriTakip.Properties.Settings.Default.Renk;
            this.panelSideMenu.Controls.Add(this.btnAyarlar);
            this.panelSideMenu.Controls.Add(this.btnRakamlar);
            this.panelSideMenu.Controls.Add(this.panelBorcMenu);
            this.panelSideMenu.Controls.Add(this.btnHesaplar);
            this.panelSideMenu.Controls.Add(this.panelSatisMenu);
            this.panelSideMenu.Controls.Add(this.btnSatis);
            this.panelSideMenu.Controls.Add(this.panelMusteriMenu);
            this.panelSideMenu.Controls.Add(this.btnMusteri);
            this.panelSideMenu.Controls.Add(this.panelLogo);
            this.panelSideMenu.DataBindings.Add(new System.Windows.Forms.Binding("BackColor", global::KT_MusteriTakip.Properties.Settings.Default, "Renk", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.panelSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSideMenu.Location = new System.Drawing.Point(0, 0);
            this.panelSideMenu.Name = "panelSideMenu";
            this.panelSideMenu.Size = new System.Drawing.Size(200, 461);
            this.panelSideMenu.TabIndex = 4;
            // 
            // btnAyarlar
            // 
            this.btnAyarlar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnAyarlar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAyarlar.FlatAppearance.BorderSize = 0;
            this.btnAyarlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAyarlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAyarlar.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnAyarlar.Location = new System.Drawing.Point(0, 673);
            this.btnAyarlar.Name = "btnAyarlar";
            this.btnAyarlar.Size = new System.Drawing.Size(183, 40);
            this.btnAyarlar.TabIndex = 8;
            this.btnAyarlar.Text = "Ayarlar";
            this.btnAyarlar.UseVisualStyleBackColor = false;
            this.btnAyarlar.Click += new System.EventHandler(this.btnAyarlar_Click);
            // 
            // btnRakamlar
            // 
            this.btnRakamlar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnRakamlar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRakamlar.FlatAppearance.BorderSize = 0;
            this.btnRakamlar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRakamlar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRakamlar.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnRakamlar.Location = new System.Drawing.Point(0, 633);
            this.btnRakamlar.Name = "btnRakamlar";
            this.btnRakamlar.Size = new System.Drawing.Size(183, 40);
            this.btnRakamlar.TabIndex = 7;
            this.btnRakamlar.Text = "Rakamlar";
            this.btnRakamlar.UseVisualStyleBackColor = false;
            this.btnRakamlar.Click += new System.EventHandler(this.btnHesaplar_Click);
            // 
            // panelBorcMenu
            // 
            this.panelBorcMenu.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelBorcMenu.Controls.Add(this.btnGunluk);
            this.panelBorcMenu.Controls.Add(this.btnAlınacaklar);
            this.panelBorcMenu.Controls.Add(this.btnEmanet);
            this.panelBorcMenu.Controls.Add(this.btnBorc);
            this.panelBorcMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBorcMenu.Location = new System.Drawing.Point(0, 459);
            this.panelBorcMenu.Name = "panelBorcMenu";
            this.panelBorcMenu.Size = new System.Drawing.Size(183, 174);
            this.panelBorcMenu.TabIndex = 6;
            // 
            // btnGunluk
            // 
            this.btnGunluk.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnGunluk.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGunluk.FlatAppearance.BorderSize = 0;
            this.btnGunluk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGunluk.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnGunluk.Location = new System.Drawing.Point(0, 120);
            this.btnGunluk.Name = "btnGunluk";
            this.btnGunluk.Size = new System.Drawing.Size(183, 40);
            this.btnGunluk.TabIndex = 3;
            this.btnGunluk.Text = "Günlük Özet";
            this.btnGunluk.UseVisualStyleBackColor = false;
            this.btnGunluk.Click += new System.EventHandler(this.btnGunluk_Click);
            // 
            // btnAlınacaklar
            // 
            this.btnAlınacaklar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnAlınacaklar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlınacaklar.FlatAppearance.BorderSize = 0;
            this.btnAlınacaklar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlınacaklar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAlınacaklar.Location = new System.Drawing.Point(0, 80);
            this.btnAlınacaklar.Name = "btnAlınacaklar";
            this.btnAlınacaklar.Size = new System.Drawing.Size(183, 40);
            this.btnAlınacaklar.TabIndex = 2;
            this.btnAlınacaklar.Text = "Alınacaklar";
            this.btnAlınacaklar.UseVisualStyleBackColor = false;
            this.btnAlınacaklar.Click += new System.EventHandler(this.btnAlınacaklar_Click);
            // 
            // btnEmanet
            // 
            this.btnEmanet.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnEmanet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEmanet.FlatAppearance.BorderSize = 0;
            this.btnEmanet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmanet.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnEmanet.Location = new System.Drawing.Point(0, 40);
            this.btnEmanet.Name = "btnEmanet";
            this.btnEmanet.Size = new System.Drawing.Size(183, 40);
            this.btnEmanet.TabIndex = 1;
            this.btnEmanet.Text = "Emanet";
            this.btnEmanet.UseVisualStyleBackColor = false;
            this.btnEmanet.Click += new System.EventHandler(this.btnEmanet_Click);
            // 
            // btnBorc
            // 
            this.btnBorc.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnBorc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBorc.FlatAppearance.BorderSize = 0;
            this.btnBorc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorc.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnBorc.Location = new System.Drawing.Point(0, 0);
            this.btnBorc.Name = "btnBorc";
            this.btnBorc.Size = new System.Drawing.Size(183, 40);
            this.btnBorc.TabIndex = 0;
            this.btnBorc.Text = "Borç";
            this.btnBorc.UseVisualStyleBackColor = false;
            this.btnBorc.Click += new System.EventHandler(this.btnBorc_Click);
            // 
            // btnHesaplar
            // 
            this.btnHesaplar.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnHesaplar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHesaplar.FlatAppearance.BorderSize = 0;
            this.btnHesaplar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHesaplar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnHesaplar.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnHesaplar.Location = new System.Drawing.Point(0, 419);
            this.btnHesaplar.Name = "btnHesaplar";
            this.btnHesaplar.Size = new System.Drawing.Size(183, 40);
            this.btnHesaplar.TabIndex = 5;
            this.btnHesaplar.Text = "Hesaplar";
            this.btnHesaplar.UseVisualStyleBackColor = false;
            this.btnHesaplar.Click += new System.EventHandler(this.btnBorcEmanet_Click);
            // 
            // panelSatisMenu
            // 
            this.panelSatisMenu.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelSatisMenu.Controls.Add(this.btnSatisArama);
            this.panelSatisMenu.Controls.Add(this.btnSatisTakip);
            this.panelSatisMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSatisMenu.Location = new System.Drawing.Point(0, 331);
            this.panelSatisMenu.Name = "panelSatisMenu";
            this.panelSatisMenu.Size = new System.Drawing.Size(183, 88);
            this.panelSatisMenu.TabIndex = 4;
            // 
            // btnSatisArama
            // 
            this.btnSatisArama.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSatisArama.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSatisArama.FlatAppearance.BorderSize = 0;
            this.btnSatisArama.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatisArama.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSatisArama.Location = new System.Drawing.Point(0, 40);
            this.btnSatisArama.Name = "btnSatisArama";
            this.btnSatisArama.Size = new System.Drawing.Size(183, 40);
            this.btnSatisArama.TabIndex = 1;
            this.btnSatisArama.Text = "Satış Arama";
            this.btnSatisArama.UseVisualStyleBackColor = false;
            this.btnSatisArama.Click += new System.EventHandler(this.btnSatisArama_Click);
            // 
            // btnSatisTakip
            // 
            this.btnSatisTakip.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnSatisTakip.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSatisTakip.FlatAppearance.BorderSize = 0;
            this.btnSatisTakip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatisTakip.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSatisTakip.Location = new System.Drawing.Point(0, 0);
            this.btnSatisTakip.Name = "btnSatisTakip";
            this.btnSatisTakip.Size = new System.Drawing.Size(183, 40);
            this.btnSatisTakip.TabIndex = 0;
            this.btnSatisTakip.Text = "Satış Takip";
            this.btnSatisTakip.UseVisualStyleBackColor = false;
            this.btnSatisTakip.Click += new System.EventHandler(this.btnSatisTakip_Click);
            // 
            // btnSatis
            // 
            this.btnSatis.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnSatis.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSatis.FlatAppearance.BorderSize = 0;
            this.btnSatis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSatis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSatis.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnSatis.Location = new System.Drawing.Point(0, 291);
            this.btnSatis.Name = "btnSatis";
            this.btnSatis.Size = new System.Drawing.Size(183, 40);
            this.btnSatis.TabIndex = 3;
            this.btnSatis.Text = "Satış";
            this.btnSatis.UseVisualStyleBackColor = false;
            this.btnSatis.Click += new System.EventHandler(this.btnSatis_Click);
            // 
            // panelMusteriMenu
            // 
            this.panelMusteriMenu.BackColor = System.Drawing.Color.CornflowerBlue;
            this.panelMusteriMenu.Controls.Add(this.btnGenelArama);
            this.panelMusteriMenu.Controls.Add(this.btnMusteriArama);
            this.panelMusteriMenu.Controls.Add(this.btnMusteriTakip);
            this.panelMusteriMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMusteriMenu.Location = new System.Drawing.Point(0, 161);
            this.panelMusteriMenu.Name = "panelMusteriMenu";
            this.panelMusteriMenu.Size = new System.Drawing.Size(183, 130);
            this.panelMusteriMenu.TabIndex = 2;
            // 
            // btnGenelArama
            // 
            this.btnGenelArama.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnGenelArama.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGenelArama.FlatAppearance.BorderSize = 0;
            this.btnGenelArama.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenelArama.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnGenelArama.Location = new System.Drawing.Point(0, 80);
            this.btnGenelArama.Name = "btnGenelArama";
            this.btnGenelArama.Size = new System.Drawing.Size(183, 37);
            this.btnGenelArama.TabIndex = 2;
            this.btnGenelArama.Text = "Genel Arama";
            this.btnGenelArama.UseVisualStyleBackColor = false;
            this.btnGenelArama.Click += new System.EventHandler(this.btnGenelArama_Click);
            // 
            // btnMusteriArama
            // 
            this.btnMusteriArama.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMusteriArama.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMusteriArama.FlatAppearance.BorderSize = 0;
            this.btnMusteriArama.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteriArama.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnMusteriArama.Location = new System.Drawing.Point(0, 40);
            this.btnMusteriArama.Name = "btnMusteriArama";
            this.btnMusteriArama.Size = new System.Drawing.Size(183, 40);
            this.btnMusteriArama.TabIndex = 1;
            this.btnMusteriArama.Text = "Müşteri Arama";
            this.btnMusteriArama.UseVisualStyleBackColor = false;
            this.btnMusteriArama.Click += new System.EventHandler(this.btnMusteriArama_Click);
            // 
            // btnMusteriTakip
            // 
            this.btnMusteriTakip.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnMusteriTakip.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMusteriTakip.FlatAppearance.BorderSize = 0;
            this.btnMusteriTakip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteriTakip.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnMusteriTakip.Location = new System.Drawing.Point(0, 0);
            this.btnMusteriTakip.Name = "btnMusteriTakip";
            this.btnMusteriTakip.Size = new System.Drawing.Size(183, 40);
            this.btnMusteriTakip.TabIndex = 0;
            this.btnMusteriTakip.Text = "Müşteri Kayıt";
            this.btnMusteriTakip.UseVisualStyleBackColor = false;
            this.btnMusteriTakip.Click += new System.EventHandler(this.btnMusteriTakip_Click);
            // 
            // btnMusteri
            // 
            this.btnMusteri.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnMusteri.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMusteri.FlatAppearance.BorderSize = 0;
            this.btnMusteri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMusteri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnMusteri.ForeColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btnMusteri.Location = new System.Drawing.Point(0, 121);
            this.btnMusteri.Name = "btnMusteri";
            this.btnMusteri.Size = new System.Drawing.Size(183, 40);
            this.btnMusteri.TabIndex = 1;
            this.btnMusteri.Text = "Müşteri";
            this.btnMusteri.UseVisualStyleBackColor = false;
            this.btnMusteri.Click += new System.EventHandler(this.btnMusteri_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.pictureBox2);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(183, 121);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.Image = global::KT_MusteriTakip.Properties.Resources.LOGO;
            this.pictureBox2.Location = new System.Drawing.Point(51, 23);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(89, 80);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // panelContainer
            // 
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.Controls.Add(this.pictureBox1);
            this.panelContainer.Controls.Add(this.labelsql);
            this.panelContainer.Controls.Add(this.dtp);
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelContainer.Location = new System.Drawing.Point(200, 0);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(634, 461);
            this.panelContainer.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::KT_MusteriTakip.Properties.Resources.LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(159, 96);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 288);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(834, 461);
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.panelSideMenu);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(850, 500);
            this.Name = "AnaForm";
            this.Text = "AnaForm";
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.Shown += new System.EventHandler(this.AnaForm_Shown);
            this.panelSideMenu.ResumeLayout(false);
            this.panelBorcMenu.ResumeLayout(false);
            this.panelSatisMenu.ResumeLayout(false);
            this.panelMusteriMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.panelContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelsql;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Panel panelSideMenu;
        private System.Windows.Forms.Button btnMusteri;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Panel panelMusteriMenu;
        private System.Windows.Forms.Button btnMusteriArama;
        private System.Windows.Forms.Button btnMusteriTakip;
        private System.Windows.Forms.Button btnRakamlar;
        private System.Windows.Forms.Panel panelBorcMenu;
        private System.Windows.Forms.Button btnEmanet;
        private System.Windows.Forms.Button btnBorc;
        private System.Windows.Forms.Button btnHesaplar;
        private System.Windows.Forms.Panel panelSatisMenu;
        private System.Windows.Forms.Button btnSatisArama;
        private System.Windows.Forms.Button btnSatisTakip;
        private System.Windows.Forms.Button btnSatis;
        private System.Windows.Forms.Button btnAyarlar;
        private System.Windows.Forms.Panel panelContainer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnGunluk;
        private System.Windows.Forms.Button btnAlınacaklar;
        private System.Windows.Forms.Button btnGenelArama;
    }
}


namespace KT_MusteriTakip
{
    partial class EmanetForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.fLTableAdapter = new KT_MusteriTakip.KTMTDataSetTableAdapters.FLTableAdapter();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.btnekle = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtbilgi = new System.Windows.Forms.TextBox();
            this.txtadsoyad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtfiyat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbfirma = new System.Windows.Forms.ComboBox();
            this.fLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kTMTDataSet = new KT_MusteriTakip.KTMTDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.txttel = new System.Windows.Forms.MaskedTextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.chkEmanet = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.fLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kTMTDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fLTableAdapter
            // 
            this.fLTableAdapter.ClearBeforeFill = true;
            // 
            // btnclear
            // 
            this.btnclear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnclear.Location = new System.Drawing.Point(434, 15);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(141, 50);
            this.btnclear.TabIndex = 4;
            this.btnclear.Text = "Temizle";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnsil
            // 
            this.btnsil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsil.Location = new System.Drawing.Point(220, 15);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(141, 50);
            this.btnsil.TabIndex = 3;
            this.btnsil.Text = "Arşivle";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnekle
            // 
            this.btnekle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnekle.Location = new System.Drawing.Point(0, 15);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(148, 50);
            this.btnekle.TabIndex = 1;
            this.btnekle.Text = "Ekle";
            this.btnekle.UseVisualStyleBackColor = true;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 78);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Emanet Fiyatı: ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbilgi
            // 
            this.txtbilgi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtbilgi.Location = new System.Drawing.Point(90, 18);
            this.txtbilgi.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtbilgi.MaxLength = 120;
            this.txtbilgi.Multiline = true;
            this.txtbilgi.Name = "txtbilgi";
            this.txtbilgi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbilgi.Size = new System.Drawing.Size(193, 51);
            this.txtbilgi.TabIndex = 7;
            this.txtbilgi.TextChanged += new System.EventHandler(this.txtbilgi_TextChanged);
            // 
            // txtadsoyad
            // 
            this.txtadsoyad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtadsoyad.Location = new System.Drawing.Point(50, 48);
            this.txtadsoyad.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtadsoyad.MaxLength = 65;
            this.txtadsoyad.Name = "txtadsoyad";
            this.txtadsoyad.Size = new System.Drawing.Size(213, 20);
            this.txtadsoyad.TabIndex = 6;
            this.txtadsoyad.TextChanged += new System.EventHandler(this.txtad_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Firma :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 48);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Ad :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtfiyat
            // 
            this.txtfiyat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtfiyat.Location = new System.Drawing.Point(90, 75);
            this.txtfiyat.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtfiyat.MaxLength = 20;
            this.txtfiyat.Name = "txtfiyat";
            this.txtfiyat.Size = new System.Drawing.Size(193, 20);
            this.txtfiyat.TabIndex = 6;
            this.txtfiyat.TextChanged += new System.EventHandler(this.txtfiyat_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 20);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Emanet Bilgisi :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbfirma
            // 
            this.cmbfirma.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbfirma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbfirma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbfirma.DataSource = this.fLBindingSource;
            this.cmbfirma.DisplayMember = "fl_ad";
            this.cmbfirma.FormattingEnabled = true;
            this.cmbfirma.Location = new System.Drawing.Point(50, 16);
            this.cmbfirma.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cmbfirma.Name = "cmbfirma";
            this.cmbfirma.Size = new System.Drawing.Size(213, 21);
            this.cmbfirma.TabIndex = 8;
            this.cmbfirma.ValueMember = "fl_id";
            this.cmbfirma.SelectedIndexChanged += new System.EventHandler(this.cmbfirma_SelectedIndexChanged);
            // 
            // fLBindingSource
            // 
            this.fLBindingSource.DataMember = "FL";
            this.fLBindingSource.DataSource = this.kTMTDataSet;
            // 
            // kTMTDataSet
            // 
            this.kTMTDataSet.DataSetName = "KTMTDataSet";
            this.kTMTDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tel :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txttel
            // 
            this.txttel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txttel.Location = new System.Drawing.Point(50, 77);
            this.txttel.Mask = "(999) 000-0000";
            this.txttel.Name = "txttel";
            this.txttel.Size = new System.Drawing.Size(213, 20);
            this.txttel.TabIndex = 15;
            this.txttel.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txttel.TextChanged += new System.EventHandler(this.txttel_TextChanged);
            this.txttel.Enter += new System.EventHandler(this.txttel_Enter);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(65, 170);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(487, 199);
            this.dataGridView.TabIndex = 8;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.txtadsoyad);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cmbfirma);
            this.groupBox3.Controls.Add(this.txttel);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(9, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(274, 151);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox4.Controls.Add(this.chkEmanet);
            this.groupBox4.Controls.Add(this.txtfiyat);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.txtbilgi);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(289, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(303, 151);
            this.groupBox4.TabIndex = 16;
            this.groupBox4.TabStop = false;
            // 
            // chkEmanet
            // 
            this.chkEmanet.AutoSize = true;
            this.chkEmanet.Location = new System.Drawing.Point(7, 117);
            this.chkEmanet.Name = "chkEmanet";
            this.chkEmanet.Size = new System.Drawing.Size(97, 17);
            this.chkEmanet.TabIndex = 8;
            this.chkEmanet.Text = "Geçmişi Göster";
            this.chkEmanet.UseVisualStyleBackColor = true;
            this.chkEmanet.CheckedChanged += new System.EventHandler(this.chkEmanet_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnekle);
            this.panel1.Controls.Add(this.btnsil);
            this.panel1.Controls.Add(this.btnclear);
            this.panel1.Location = new System.Drawing.Point(24, 375);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(578, 79);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox4);
            this.panel2.Location = new System.Drawing.Point(24, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(607, 161);
            this.panel2.TabIndex = 18;
            // 
            // EmanetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView);
            this.Name = "EmanetForm";
            this.Text = "EmanetForm";
            this.Load += new System.EventHandler(this.EmanetForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kTMTDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KTMTDataSetTableAdapters.FLTableAdapter fLTableAdapter;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtbilgi;
        private System.Windows.Forms.TextBox txtadsoyad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtfiyat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbfirma;
        private System.Windows.Forms.BindingSource fLBindingSource;
        private KTMTDataSet kTMTDataSet;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.MaskedTextBox txttel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox chkEmanet;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
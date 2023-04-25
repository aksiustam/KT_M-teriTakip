namespace KT_MusteriTakip
{
    partial class BorcForm
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txtadsoyad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbfirma = new System.Windows.Forms.ComboBox();
            this.fLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kTMTDataSet = new KT_MusteriTakip.KTMTDataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.txttel = new System.Windows.Forms.MaskedTextBox();
            this.txtfiyat = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtbilgi = new System.Windows.Forms.TextBox();
            this.fLTableAdapter = new KT_MusteriTakip.KTMTDataSetTableAdapters.FLTableAdapter();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxborc = new System.Windows.Forms.CheckBox();
            this.btnekle = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kTMTDataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(56, 147);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(516, 190);
            this.dataGridView.TabIndex = 8;
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // txtadsoyad
            // 
            this.txtadsoyad.Location = new System.Drawing.Point(69, 48);
            this.txtadsoyad.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtadsoyad.MaxLength = 30;
            this.txtadsoyad.Name = "txtadsoyad";
            this.txtadsoyad.Size = new System.Drawing.Size(187, 20);
            this.txtadsoyad.TabIndex = 6;
            this.txtadsoyad.TextChanged += new System.EventHandler(this.txtad_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 19);
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
            this.label3.Location = new System.Drawing.Point(6, 51);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "AdSoyad:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbfirma
            // 
            this.cmbfirma.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbfirma.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbfirma.DataSource = this.fLBindingSource;
            this.cmbfirma.DisplayMember = "fl_ad";
            this.cmbfirma.FormattingEnabled = true;
            this.cmbfirma.Location = new System.Drawing.Point(69, 19);
            this.cmbfirma.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.cmbfirma.Name = "cmbfirma";
            this.cmbfirma.Size = new System.Drawing.Size(187, 21);
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
            this.label4.Location = new System.Drawing.Point(31, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Tel :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txttel
            // 
            this.txttel.Location = new System.Drawing.Point(69, 80);
            this.txttel.Mask = "(999) 000-0000";
            this.txttel.Name = "txttel";
            this.txttel.Size = new System.Drawing.Size(187, 20);
            this.txttel.TabIndex = 15;
            this.txttel.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txttel.TextChanged += new System.EventHandler(this.txttel_TextChanged);
            this.txttel.Enter += new System.EventHandler(this.txttel_Enter);
            // 
            // txtfiyat
            // 
            this.txtfiyat.Location = new System.Drawing.Point(85, 80);
            this.txtfiyat.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtfiyat.MaxLength = 20;
            this.txtfiyat.Name = "txtfiyat";
            this.txtfiyat.Size = new System.Drawing.Size(163, 20);
            this.txtfiyat.TabIndex = 6;
            this.txtfiyat.TextChanged += new System.EventHandler(this.txtfiyat_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 19);
            this.label8.Margin = new System.Windows.Forms.Padding(3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Borç Bilgisi :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 80);
            this.label9.Margin = new System.Windows.Forms.Padding(3);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Borç Fiyat : ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtbilgi
            // 
            this.txtbilgi.Location = new System.Drawing.Point(85, 19);
            this.txtbilgi.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txtbilgi.MaxLength = 120;
            this.txtbilgi.Multiline = true;
            this.txtbilgi.Name = "txtbilgi";
            this.txtbilgi.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtbilgi.Size = new System.Drawing.Size(163, 49);
            this.txtbilgi.TabIndex = 7;
            this.txtbilgi.TextChanged += new System.EventHandler(this.txtbilgi_TextChanged);
            // 
            // fLTableAdapter
            // 
            this.fLTableAdapter.ClearBeforeFill = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cmbfirma);
            this.groupBox1.Controls.Add(this.txtadsoyad);
            this.groupBox1.Controls.Add(this.txttel);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 129);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.checkBoxborc);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtbilgi);
            this.groupBox2.Controls.Add(this.txtfiyat);
            this.groupBox2.Location = new System.Drawing.Point(312, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(283, 129);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // checkBoxborc
            // 
            this.checkBoxborc.AutoSize = true;
            this.checkBoxborc.Location = new System.Drawing.Point(19, 106);
            this.checkBoxborc.Name = "checkBoxborc";
            this.checkBoxborc.Size = new System.Drawing.Size(118, 17);
            this.checkBoxborc.TabIndex = 8;
            this.checkBoxborc.Text = "Eski Borçları Göster";
            this.checkBoxborc.UseVisualStyleBackColor = true;
            this.checkBoxborc.CheckedChanged += new System.EventHandler(this.checkBoxborc_CheckedChanged);
            // 
            // btnekle
            // 
            this.btnekle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnekle.Location = new System.Drawing.Point(12, 26);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(148, 50);
            this.btnekle.TabIndex = 18;
            this.btnekle.Text = "Ekle";
            this.btnekle.UseVisualStyleBackColor = true;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // btnsil
            // 
            this.btnsil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsil.Location = new System.Drawing.Point(216, 26);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(141, 50);
            this.btnsil.TabIndex = 19;
            this.btnsil.Text = "Arşivle";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnclear
            // 
            this.btnclear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnclear.Location = new System.Drawing.Point(404, 26);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(141, 50);
            this.btnclear.TabIndex = 20;
            this.btnclear.Text = "Temizle";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.btnclear);
            this.panel1.Controls.Add(this.btnekle);
            this.panel1.Controls.Add(this.btnsil);
            this.panel1.Location = new System.Drawing.Point(36, 349);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 100);
            this.panel1.TabIndex = 21;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(27, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(595, 138);
            this.panel2.TabIndex = 22;
            // 
            // BorcForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView);
            this.Name = "BorcForm";
            this.Text = " ";
            this.Load += new System.EventHandler(this.BorcForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kTMTDataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtadsoyad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbfirma;
        private System.Windows.Forms.Label label4;
        private KTMTDataSet kTMTDataSet;
        private System.Windows.Forms.BindingSource fLBindingSource;
        private KTMTDataSetTableAdapters.FLTableAdapter fLTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txtfiyat;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtbilgi;
        private System.Windows.Forms.MaskedTextBox txttel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.CheckBox checkBoxborc;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
    }
}
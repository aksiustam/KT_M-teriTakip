namespace KT_MusteriTakip
{
    partial class SatisTakibiForm
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnekle = new System.Windows.Forms.Button();
            this.btnclear = new System.Windows.Forms.Button();
            this.btnsil = new System.Windows.Forms.Button();
            this.btnsat = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txturunad = new System.Windows.Forms.TextBox();
            this.txturunnot = new System.Windows.Forms.TextBox();
            this.checkBoxstok = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.btnekle);
            this.groupBox2.Controls.Add(this.btnclear);
            this.groupBox2.Controls.Add(this.btnsil);
            this.groupBox2.Controls.Add(this.btnsat);
            this.groupBox2.Location = new System.Drawing.Point(288, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 134);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // btnekle
            // 
            this.btnekle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnekle.Location = new System.Drawing.Point(15, 19);
            this.btnekle.Name = "btnekle";
            this.btnekle.Size = new System.Drawing.Size(111, 45);
            this.btnekle.TabIndex = 0;
            this.btnekle.Text = "Ekle";
            this.btnekle.UseVisualStyleBackColor = true;
            this.btnekle.Click += new System.EventHandler(this.btnekle_Click);
            // 
            // btnclear
            // 
            this.btnclear.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnclear.Location = new System.Drawing.Point(191, 76);
            this.btnclear.Name = "btnclear";
            this.btnclear.Size = new System.Drawing.Size(111, 45);
            this.btnclear.TabIndex = 3;
            this.btnclear.Text = "Temizle";
            this.btnclear.UseVisualStyleBackColor = true;
            this.btnclear.Click += new System.EventHandler(this.btnclear_Click);
            // 
            // btnsil
            // 
            this.btnsil.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsil.Location = new System.Drawing.Point(15, 76);
            this.btnsil.Name = "btnsil";
            this.btnsil.Size = new System.Drawing.Size(111, 45);
            this.btnsil.TabIndex = 2;
            this.btnsil.Text = "Sil";
            this.btnsil.UseVisualStyleBackColor = true;
            this.btnsil.Click += new System.EventHandler(this.btnsil_Click);
            // 
            // btnsat
            // 
            this.btnsat.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnsat.Location = new System.Drawing.Point(191, 20);
            this.btnsat.Name = "btnsat";
            this.btnsat.Size = new System.Drawing.Size(111, 45);
            this.btnsat.TabIndex = 1;
            this.btnsat.Text = "Sat";
            this.btnsat.UseVisualStyleBackColor = true;
            this.btnsat.Click += new System.EventHandler(this.btnsat_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(60, 176);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(493, 253);
            this.dataGridView.TabIndex = 6;
            this.dataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellClick);
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txturunad);
            this.groupBox1.Controls.Add(this.txturunnot);
            this.groupBox1.Controls.Add(this.checkBoxstok);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 134);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Ürün Adı :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txturunad
            // 
            this.txturunad.Location = new System.Drawing.Point(64, 16);
            this.txturunad.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txturunad.MaxLength = 50;
            this.txturunad.Name = "txturunad";
            this.txturunad.Size = new System.Drawing.Size(166, 20);
            this.txturunad.TabIndex = 3;
            this.txturunad.TextChanged += new System.EventHandler(this.txturunad_TextChanged);
            // 
            // txturunnot
            // 
            this.txturunnot.Location = new System.Drawing.Point(64, 49);
            this.txturunnot.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.txturunnot.MaxLength = 100;
            this.txturunnot.Multiline = true;
            this.txturunnot.Name = "txturunnot";
            this.txturunnot.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txturunnot.Size = new System.Drawing.Size(212, 49);
            this.txturunnot.TabIndex = 6;
            this.txturunnot.TextChanged += new System.EventHandler(this.txturunnot_TextChanged);
            // 
            // checkBoxstok
            // 
            this.checkBoxstok.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBoxstok.AutoSize = true;
            this.checkBoxstok.Checked = true;
            this.checkBoxstok.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxstok.Location = new System.Drawing.Point(6, 104);
            this.checkBoxstok.Name = "checkBoxstok";
            this.checkBoxstok.Size = new System.Drawing.Size(112, 17);
            this.checkBoxstok.TabIndex = 8;
            this.checkBoxstok.Text = "Stoktakileri Göster";
            this.checkBoxstok.UseVisualStyleBackColor = true;
            this.checkBoxstok.CheckedChanged += new System.EventHandler(this.checkBoxstok_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 52);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Açıklama :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 143);
            this.panel1.TabIndex = 7;
            // 
            // SatisTakibiForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView);
            this.MinimumSize = new System.Drawing.Size(650, 500);
            this.Name = "SatisTakibiForm";
            this.Text = "SatisTakibiForm";
            this.Load += new System.EventHandler(this.SatisTakibiForm_Load);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txturunnot;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txturunad;
        private System.Windows.Forms.Button btnclear;
        private System.Windows.Forms.Button btnsil;
        private System.Windows.Forms.Button btnsat;
        private System.Windows.Forms.Button btnekle;
        private System.Windows.Forms.CheckBox checkBoxstok;
        private System.Windows.Forms.Panel panel1;
    }
}
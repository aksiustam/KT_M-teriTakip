namespace KT_MusteriTakip
{
    partial class HesaplarForm
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
            this.labelSatyay = new System.Windows.Forms.Label();
            this.labelSatgay = new System.Windows.Forms.Label();
            this.labelSatbay = new System.Windows.Forms.Label();
            this.labelMusyay = new System.Windows.Forms.Label();
            this.labelMusgay = new System.Windows.Forms.Label();
            this.labelMusbay = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelMusWeek = new System.Windows.Forms.Label();
            this.labelSatWeek = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelSatyay
            // 
            this.labelSatyay.AutoSize = true;
            this.labelSatyay.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSatyay.Location = new System.Drawing.Point(5, 130);
            this.labelSatyay.Name = "labelSatyay";
            this.labelSatyay.Size = new System.Drawing.Size(162, 24);
            this.labelSatyay.TabIndex = 3;
            this.labelSatyay.Text = "Bu Yılki Kazanç:";
            this.labelSatyay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSatgay
            // 
            this.labelSatgay.AutoSize = true;
            this.labelSatgay.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSatgay.Location = new System.Drawing.Point(5, 94);
            this.labelSatgay.Name = "labelSatgay";
            this.labelSatgay.Size = new System.Drawing.Size(175, 24);
            this.labelSatgay.TabIndex = 2;
            this.labelSatgay.Text = "Geçen Ay Kazanç:";
            this.labelSatgay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSatbay
            // 
            this.labelSatbay.AutoSize = true;
            this.labelSatbay.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSatbay.Location = new System.Drawing.Point(6, 56);
            this.labelSatbay.Name = "labelSatbay";
            this.labelSatbay.Size = new System.Drawing.Size(144, 24);
            this.labelSatbay.TabIndex = 1;
            this.labelSatbay.Text = "Bu Ay Kazanç:";
            this.labelSatbay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMusyay
            // 
            this.labelMusyay.AutoSize = true;
            this.labelMusyay.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMusyay.Location = new System.Drawing.Point(6, 137);
            this.labelMusyay.Name = "labelMusyay";
            this.labelMusyay.Size = new System.Drawing.Size(162, 24);
            this.labelMusyay.TabIndex = 2;
            this.labelMusyay.Text = "Bu Yılki Kazanç:";
            this.labelMusyay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMusgay
            // 
            this.labelMusgay.AutoSize = true;
            this.labelMusgay.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMusgay.Location = new System.Drawing.Point(6, 97);
            this.labelMusgay.Name = "labelMusgay";
            this.labelMusgay.Size = new System.Drawing.Size(175, 24);
            this.labelMusgay.TabIndex = 1;
            this.labelMusgay.Text = "Geçen Ay Kazanç:";
            this.labelMusgay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelMusbay
            // 
            this.labelMusbay.AutoSize = true;
            this.labelMusbay.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMusbay.Location = new System.Drawing.Point(6, 61);
            this.labelMusbay.Name = "labelMusbay";
            this.labelMusbay.Size = new System.Drawing.Size(144, 24);
            this.labelMusbay.TabIndex = 0;
            this.labelMusbay.Text = "Bu Ay Kazanç:";
            this.labelMusbay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelMusWeek);
            this.groupBox3.Controls.Add(this.labelMusgay);
            this.groupBox3.Controls.Add(this.labelMusyay);
            this.groupBox3.Controls.Add(this.labelMusbay);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(403, 185);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelSatWeek);
            this.groupBox4.Controls.Add(this.labelSatyay);
            this.groupBox4.Controls.Add(this.labelSatbay);
            this.groupBox4.Controls.Add(this.labelSatgay);
            this.groupBox4.Location = new System.Drawing.Point(12, 203);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(403, 169);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            // 
            // labelMusWeek
            // 
            this.labelMusWeek.AutoSize = true;
            this.labelMusWeek.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelMusWeek.Location = new System.Drawing.Point(6, 25);
            this.labelMusWeek.Name = "labelMusWeek";
            this.labelMusWeek.Size = new System.Drawing.Size(174, 24);
            this.labelMusWeek.TabIndex = 3;
            this.labelMusWeek.Text = "Bu Hafta Kazanç:";
            this.labelMusWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSatWeek
            // 
            this.labelSatWeek.AutoSize = true;
            this.labelSatWeek.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelSatWeek.Location = new System.Drawing.Point(6, 16);
            this.labelSatWeek.Name = "labelSatWeek";
            this.labelSatWeek.Size = new System.Drawing.Size(174, 24);
            this.labelSatWeek.TabIndex = 4;
            this.labelSatWeek.Text = "Bu Hafta Kazanç:";
            this.labelSatWeek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HesaplarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 461);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Name = "HesaplarForm";
            this.Text = "HesaplarForm";
            this.Load += new System.EventHandler(this.HesaplarForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelMusyay;
        private System.Windows.Forms.Label labelMusgay;
        private System.Windows.Forms.Label labelMusbay;
        private System.Windows.Forms.Label labelSatyay;
        private System.Windows.Forms.Label labelSatgay;
        private System.Windows.Forms.Label labelSatbay;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label labelMusWeek;
        private System.Windows.Forms.Label labelSatWeek;
    }
}
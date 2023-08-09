namespace Eğitim_Takip
{
    partial class IcsOlusturma
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
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btn_ics_olustur = new System.Windows.Forms.Button();
            this.txt_Aciklama_Description = new System.Windows.Forms.TextBox();
            this.txt_Baslik_Summary = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.txt_konum_location = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(129, 85);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(106, 20);
            this.dateTimePicker1.TabIndex = 170;
            // 
            // btn_ics_olustur
            // 
            this.btn_ics_olustur.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_ics_olustur.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_ics_olustur.Location = new System.Drawing.Point(180, 270);
            this.btn_ics_olustur.Name = "btn_ics_olustur";
            this.btn_ics_olustur.Size = new System.Drawing.Size(88, 37);
            this.btn_ics_olustur.TabIndex = 168;
            this.btn_ics_olustur.Text = "Oluştur";
            this.btn_ics_olustur.UseVisualStyleBackColor = true;
            this.btn_ics_olustur.Click += new System.EventHandler(this.btn_ics_olustur_Click);
            // 
            // txt_Aciklama_Description
            // 
            this.txt_Aciklama_Description.Location = new System.Drawing.Point(129, 168);
            this.txt_Aciklama_Description.Multiline = true;
            this.txt_Aciklama_Description.Name = "txt_Aciklama_Description";
            this.txt_Aciklama_Description.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txt_Aciklama_Description.Size = new System.Drawing.Size(213, 87);
            this.txt_Aciklama_Description.TabIndex = 167;
            // 
            // txt_Baslik_Summary
            // 
            this.txt_Baslik_Summary.Location = new System.Drawing.Point(129, 56);
            this.txt_Baslik_Summary.Name = "txt_Baslik_Summary";
            this.txt_Baslik_Summary.Size = new System.Drawing.Size(213, 20);
            this.txt_Baslik_Summary.TabIndex = 167;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(78, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 171;
            this.label1.Text = "Başlık:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(20, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 15);
            this.label2.TabIndex = 171;
            this.label2.Text = "Başlangıç Tarihi: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(51, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 15);
            this.label3.TabIndex = 171;
            this.label3.Text = "Bitiş Tarihi: ";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker2.Location = new System.Drawing.Point(129, 112);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(106, 20);
            this.dateTimePicker2.TabIndex = 170;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(241, 85);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(101, 21);
            this.comboBox1.TabIndex = 172;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(241, 112);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(101, 21);
            this.comboBox2.TabIndex = 172;
            // 
            // txt_konum_location
            // 
            this.txt_konum_location.Location = new System.Drawing.Point(129, 142);
            this.txt_konum_location.Name = "txt_konum_location";
            this.txt_konum_location.Size = new System.Drawing.Size(213, 20);
            this.txt_konum_location.TabIndex = 167;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(73, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 15);
            this.label4.TabIndex = 171;
            this.label4.Text = "Konum:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(57, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 15);
            this.label5.TabIndex = 171;
            this.label5.Text = "Açıklama: ";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(12, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(359, 23);
            this.label6.TabIndex = 173;
            this.label6.Text = ".ics Oluşturma";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // IcsOlusturma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 325);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btn_ics_olustur);
            this.Controls.Add(this.txt_konum_location);
            this.Controls.Add(this.txt_Baslik_Summary);
            this.Controls.Add(this.txt_Aciklama_Description);
            this.Name = "IcsOlusturma";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ".ics Oluşturma";
            this.Load += new System.EventHandler(this.IcsOlusturma_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_ics_olustur;
        private System.Windows.Forms.TextBox txt_Aciklama_Description;
        private System.Windows.Forms.TextBox txt_Baslik_Summary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.TextBox txt_konum_location;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
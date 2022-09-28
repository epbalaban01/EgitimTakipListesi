using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using System.Drawing.Text;

namespace Eğitim_Takip
{
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();

            notify = new NotifyIcon()
            {
                Visible = true,
                Icon = Properties.Resources.sdf,
                BalloonTipIcon = ToolTipIcon.Info,
                ContextMenuStrip = contextMenuStrip2,
            };
            now = DateTime.Now;

        }

        NotifyIcon notify;
        DateTime now;


        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");
        OleDbDataAdapter adapter = new OleDbDataAdapter();
        public DataTable tablo = new DataTable();
        DataTable dt = new DataTable();
        OleDbDataReader oku1;
        OleDbDataReader okuyucu;

        OleDbCommand komut = new OleDbCommand();
        private void Form1_Load(object sender, EventArgs e)
        {
            PrivateFontCollection ozelfont = new PrivateFontCollection();
            ozelfont.AddFontFile(@"..\..\Font\Gilroy-ExtraBold.otf");
          
            label15.Font = new Font(ozelfont.Families[0], 24, FontStyle.Italic);
           

            timer1.Start();
            comboBox1.Text = "GAİB";
            label13.Text = comboBox1.Text;
            bos();

            DateTime tarih = dateTimePicker2.Value;
            timer2.Start();
            timer3.Start();

         
            
            
  


        }

        #region Güncelle

        public void bos()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select *from bos", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            //DataGridViewButtonColumn dgvBtn = new DataGridViewButtonColumn();  /*** NORMAL BUTON EKLEME ***/
            //dgvBtn.HeaderText = "Zoom Link";   //Kolon Başlığı
            //dgvBtn.Text = "Sayfaya Git";      // Butonun Text
            //dgvBtn.UseColumnTextForButtonValue = true;     // Butonda Text Kullanılmasını aktifleştirme
            //dgvBtn.DefaultCellStyle.BackColor = Color.Blue;        // Buton çerçeve rengi
            //dgvBtn.DefaultCellStyle.SelectionBackColor = Color.Red;        // Buton seçiliykenki çerçeve rengi
            //dgvBtn.Width = 120;         // Butonun genişiliği
            //dataGridView1.Columns.Add(dgvBtn);         // DataGridView e ekleme
            add();
            adtr.Dispose();
            renklendir();

            baglanti.Close();



        }
      
        public void guncelle()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select *from gaib", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
     
            add();
            adtr.Dispose();
            renklendir();
          

            //BİLDİRİM HATIRLATMA
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM gaib";
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu[3].ToString() == DateTime.Now.ToShortDateString())
                {
                   
                   
                    label17.Text = okuyucu[2].ToString();
                    label20.Text = okuyucu[3].ToString();
                    label19.Text = okuyucu[6].ToString();
                    label18.Text = okuyucu[7].ToString();
                    label16.Text = "Eğitim Var";
                }

            }
            //

            // EKLENEN LİSTE SAYISI
            OleDbCommand adtr4 = new OleDbCommand("SELECT  count(id) as toplamkayit from gaib", baglanti);
            oku1 = adtr4.ExecuteReader();
            if (oku1.Read())
            {
                toolStripStatusLabel1.Text = "Toplam " + oku1[0].ToString() + " kayıt var.";
            }
            //
            
            baglanti.Close();
            OtoSıraNo();
        }

        public void guncelle1()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select *from immib", baglanti);
            adtr.Fill(tablo);


            dataGridView1.DataSource = tablo;
            add();
            adtr.Dispose();
            renklendir();

            //BİLDİRİM HATIRLATMA
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM immib";
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu[3].ToString() == DateTime.Now.ToShortDateString())
                {
                    label21.Text = "Eğitim Var";

                    label25.Text = okuyucu[2].ToString();
                    label22.Text = okuyucu[3].ToString();
                    label24.Text = okuyucu[6].ToString();
                    label23.Text = okuyucu[7].ToString();
                }

            }
            //

            // EKLENEN LİSTE SAYISI
            OleDbCommand adtr4 = new OleDbCommand("SELECT  count(id) as toplamkayit from immib", baglanti);
            oku1 = adtr4.ExecuteReader();
            if (oku1.Read())
            {
                toolStripStatusLabel1.Text = "Toplam " + oku1[0].ToString() + " kayıt var.";
            }
            //

            baglanti.Close();
            OtoSıraNo();
        }

        public void guncelle2()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select *from iso", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            add();
            adtr.Dispose();
            renklendir();

            //BİLDİRİM HATIRLATMA
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM iso";
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu[3].ToString() == DateTime.Now.ToShortDateString())
                {
                    label26.Text = "Eğitim Var";

                    label30.Text = okuyucu[2].ToString();
                    label27.Text = okuyucu[3].ToString();
                    label29.Text = okuyucu[6].ToString();
                    label28.Text = okuyucu[7].ToString();
                }

            }
            //

            // EKLENEN LİSTE SAYISI
            OleDbCommand adtr4 = new OleDbCommand("SELECT  count(id) as toplamkayit from iso", baglanti);
            oku1 = adtr4.ExecuteReader();
            if (oku1.Read())
            {
                toolStripStatusLabel1.Text = "Toplam " + oku1[0].ToString() + " kayıt var.";
            }

            baglanti.Close();
            OtoSıraNo();
        }

        public void guncelle3()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select *from akbank", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            add();
            adtr.Dispose();
            renklendir();

            //BİLDİRİM HATIRLATMA
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM akbank";
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu[3].ToString() == DateTime.Now.ToShortDateString())
                {
                    label26.Text = "Eğitim Var";

                    label35.Text = okuyucu[2].ToString();
                    label32.Text = okuyucu[3].ToString();
                    label34.Text = okuyucu[6].ToString();
                    label31.Text = okuyucu[7].ToString();
                }

            }
            //

            // EKLENEN LİSTE SAYISI
            OleDbCommand adtr4 = new OleDbCommand("SELECT  count(id) as toplamkayit from akbank", baglanti);
            oku1 = adtr4.ExecuteReader();
            if (oku1.Read())
            {
                toolStripStatusLabel1.Text = "Toplam " + oku1[0].ToString() + " kayıt var.";
            }

            baglanti.Close();
            OtoSıraNo();
        }

        public void guncelle4()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select *from microfon", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            add();
            adtr.Dispose();
            renklendir();

            //BİLDİRİM HATIRLATMA
            komut.Connection = baglanti;
            komut.CommandText = "SELECT * FROM microfon";
            okuyucu = komut.ExecuteReader();
            while (okuyucu.Read())
            {
                if (okuyucu[3].ToString() == DateTime.Now.ToShortDateString())
                {
                    label26.Text = "Eğitim Var";

                    label30.Text = okuyucu[2].ToString();
                    label27.Text = okuyucu[3].ToString();
                    label29.Text = okuyucu[6].ToString();
                    label28.Text = okuyucu[7].ToString();
                }

            }
            //

            // EKLENEN LİSTE SAYISI
            OleDbCommand adtr4 = new OleDbCommand("SELECT  count(id) as toplamkayit from microfon", baglanti);
            oku1 = adtr4.ExecuteReader();
            if (oku1.Read())
            {
                toolStripStatusLabel1.Text = "Toplam " + oku1[0].ToString() + " kayıt var.";
            }

            baglanti.Close();
            OtoSıraNo();
        }

        public void guncelle5()
        {
            baglanti.Open();
            OleDbDataAdapter adtr = new OleDbDataAdapter("select *from solidworks", baglanti);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;

            add();
            adtr.Dispose();
            renklendir();

            // EKLENEN LİSTE SAYISI
            OleDbCommand adtr4 = new OleDbCommand("SELECT  count(id) as toplamkayit from solidworks", baglanti);
            oku1 = adtr4.ExecuteReader();
            if (oku1.Read())
            {
                toolStripStatusLabel1.Text = "Toplam " + oku1[0].ToString() + " kayıt var.";
            }

            baglanti.Close();
            OtoSıraNo();
        }
        #endregion

        #region Add
        private void add()
        {
            
            dataGridView1.AllowUserToAddRows = false; // remove the null line
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns["sira_no"].DisplayIndex = 0;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Visible = true;
            dataGridView1.Columns[1].Width = 45;
            dataGridView1.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[1].HeaderText = "";
            dataGridView1.Columns[2].Width = 174;
            dataGridView1.Columns[2].HeaderText = "Eğitim Adı";
            dataGridView1.Columns[3].Visible = true;
            dataGridView1.Columns[3].HeaderText = "Eğitim Zamanı";
            dataGridView1.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[4].Visible = true;
            dataGridView1.Columns[4].HeaderText = "Zoom ID";
            dataGridView1.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[5].Visible = true;
            dataGridView1.Columns[5].HeaderText = "Zoom Şifre";
            dataGridView1.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[6].Visible = true;
            dataGridView1.Columns[6].HeaderText = "Zoom Link";
            dataGridView1.Columns[6].Width = 115;
            dataGridView1.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns[7].Visible = true;
            dataGridView1.Columns[7].HeaderText = "Saat";
            dataGridView1.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }
        #endregion

        #region Silme İşlemi
        private void delete()
        {
            if (comboBox1.Text == "GAİB")
            {
                if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    baglanti.Open();
                    OleDbCommand komut2 = new OleDbCommand("DELETE FROM gaib WHERE egitim_adi='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", baglanti);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi", "Eğitim Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    tablo.Clear();
                    guncelle();
                    OtoSıraNo();

                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi");

                }
            }
            else if (comboBox1.Text == "İMMİB Akademi")
            {
                if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    baglanti.Open();
                    OleDbCommand komut2 = new OleDbCommand("DELETE FROM immib WHERE egitim_adi='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", baglanti);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi", "Eğitim Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    tablo.Clear();
                    guncelle1();
                    OtoSıraNo();
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi");

                }
            }
            else if (comboBox1.Text == "ISO Akademi")
            {
                if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    baglanti.Open();
                    OleDbCommand komut2 = new OleDbCommand("DELETE FROM iso WHERE egitim_adi='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", baglanti);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi", "Eğitim Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    tablo.Clear();
                    guncelle2();
                    OtoSıraNo();
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi");

                }
            }

            else if (comboBox1.Text == "AKBANK Akademi")
            {
                if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    baglanti.Open();
                    OleDbCommand komut2 = new OleDbCommand("DELETE FROM akbank WHERE egitim_adi='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", baglanti);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi", "Eğitim Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    tablo.Clear();
                    guncelle3();
                    OtoSıraNo();
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi");

                }
            }
            else if (comboBox1.Text == "Microfon")
            {
                if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    baglanti.Open();
                    OleDbCommand komut2 = new OleDbCommand("DELETE FROM microfon WHERE egitim_adi='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", baglanti);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi", "Eğitim Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    tablo.Clear();
                    guncelle4();
                    OtoSıraNo();
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi");

                }
            }
            else if (comboBox1.Text == "Solidworks")
            {
                if (MessageBox.Show("Seçili Ögeyi Silmek İstiyor Musunuz ?", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    baglanti.Open();
                    OleDbCommand komut2 = new OleDbCommand("DELETE FROM solidworks WHERE egitim_adi='" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "'", baglanti);
                    komut2.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Silindi", "Eğitim Sil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    baglanti.Close();

                    tablo.Clear();
                    guncelle5();
                    OtoSıraNo();
                }
                else
                {
                    MessageBox.Show("Silme İşlemi İptal Edildi");

                }
            }
            else
            {
                MessageBox.Show("Seçim Yap");
            }


        }
        #endregion

        #region Düzenle İşlemi
        public void Duzenle()
        {
            if (label14.Text == "Düzenle")
            {



            }


        }
        #endregion


        #region Renklendirme
        void renklendir()
        {

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (Convert.ToDateTime(dataGridView1.Rows[i].Cells["egitim_zamani"].Value.ToString()) == Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                }

                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }


        }
        #endregion


        private void OtoSıraNo() //For Döngüsünü Tanımlama
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++) //DataGridView satır sayısı kadar int i yi bir artırma
            {
                dataGridView1.Rows[i].Cells[1].Value = (i + 1).ToString();//Belirlediğimiz 2.Sutuna ( Cells[1] ) DataGridView satır sayısı kadar otomatik artan sayı verme
            }
            dataGridView1.AllowUserToAddRows = false;//DataGridView in son sırasını gizleme



        }
        private void timer1_Tick(object sender, EventArgs e)
        { 
            lbltarih.Text = DateTime.Now.ToShortDateString();
            lblsaat.Text = DateTime.Now.ToLongTimeString();

            dateTimePicker1.Text = DateTime.Now.ToShortDateString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6)
            {// hangi kolona göre işlem yapacaksak onun index i ile karşılaştırıyoruz

                System.Diagnostics.Process.Start(dataGridView1.CurrentRow.Cells[7].Value.ToString());
            }

            lblegitimadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lblegitimzamani.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            lblegitimsaati.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString(); 
        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            lblegitimadi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lblegitimzamani.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            lblegitimsaati.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
 
            if (lblegitimzamani.Text == lbltarih.Text)
            {
                label11.Text = "Bugün eğitimin var";
                pictureBox6.Image = Properties.Resources._01_Warning_icon;
            }
            else
            {
                label11.Text = "Bugün eğitimin yok";
                pictureBox6.Image = Properties.Resources._15_Tick_icon;
            }
        }

        private void btn_ileri_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1)
            {
                comboBox1.SelectedIndex = comboBox1.SelectedIndex + 1;
                label13.Text = comboBox1.Text;

                textboxEgitimAdi.Text = "";
                textboxEgitimZamani.Text = "";
                textboxZoomID.Text = "";
                textboxZoomLink.Text = "";
                textboxZoomSifre.Text = "";
                comboboxSaat.Text = "";

                panel2.Visible = true;
            }
        }

        private void btn_geri_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > 0)
            {
                comboBox1.SelectedIndex = comboBox1.SelectedIndex - 1;
                label13.Text = comboBox1.Text;

                textboxEgitimAdi.Text = "";
                textboxEgitimZamani.Text = "";
                textboxZoomID.Text = "";
                textboxZoomLink.Text = "";
                textboxZoomSifre.Text = "";
                comboboxSaat.Text = "";

                panel2.Visible = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "GAİB")
            {
                pictureBox1.Image = Properties.Resources.gaiblogo;
                tablo.Clear();
                guncelle();
            }
            else if (comboBox1.Text == "İMMİB Akademi")
            {
                pictureBox1.Image = Properties.Resources.immib;
                tablo.Clear();
                guncelle1();
            }
            else if (comboBox1.Text == "ISO Akademi")
            {
                pictureBox1.Image = Properties.Resources.ISO_logo_1280_146;
                tablo.Clear();
                guncelle2();
            }

            else if (comboBox1.Text == "AKBANK Akademi")
            {
                pictureBox1.Image = Properties.Resources.akbank;
                tablo.Clear();
                guncelle3();
            }
            else if (comboBox1.Text == "Microfon")
            {
                pictureBox1.Image = Properties.Resources.microfon;
                tablo.Clear();
                guncelle4();
            }
            else if (comboBox1.Text == "Solidworks")
            {
                pictureBox1.Image = Properties.Resources.solidworks;
                tablo.Clear();
                guncelle5();
            }
            else
            {
                MessageBox.Show("Seçim Yap");
            }
        }

        private void silToolStripMenuItem_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void düzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;

            lblid.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textboxEgitimAdi.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textboxEgitimZamani.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textboxZoomID.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textboxZoomSifre.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textboxZoomLink.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            comboboxSaat.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

            label14.Text = "Düzenle";
            btn_kaydet.Text = "Güncelle";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        #region Kaydet ve Güncelle
        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            if (label14.Text == "Kaydet")
            {
                if (comboBox1.Text == "GAİB")
                {
                    try
                    {
                        baglanti.Open();
                        OleDbCommand kayit = new OleDbCommand("insert into gaib ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti);
                        kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                        kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                        kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                        kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                        kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                        kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);

                        kayit.ExecuteNonQuery();
                        MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tablo.Clear();
                        baglanti.Close();

                        guncelle();
                        OtoSıraNo();

                        textboxEgitimAdi.Text = "";
                        textboxEgitimZamani.Text = "";
                        textboxZoomID.Text = "";
                        textboxZoomSifre.Text = "";
                        textboxZoomLink.Text = "";
                        comboboxSaat.Text = "";

                    }
                    catch (InvalidCastException ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (comboBox1.Text == "İMMİB Akademi")
                {
                    try
                    {
                        baglanti.Open();
                        OleDbCommand kayit = new OleDbCommand("insert into immib ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti);
                        kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                        kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                        kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                        kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                        kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                        kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);

                        kayit.ExecuteNonQuery();
                        MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tablo.Clear();
                        baglanti.Close();

                        guncelle1();
                        OtoSıraNo();

                        textboxEgitimAdi.Text = "";
                        textboxEgitimZamani.Text = "";
                        textboxZoomID.Text = "";
                        textboxZoomSifre.Text = "";
                        textboxZoomLink.Text = "";
                        comboboxSaat.Text = "";

                    }
                    catch (InvalidCastException ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (comboBox1.Text == "ISO Akademi")
                {
                    try
                    {
                        baglanti.Open();
                        OleDbCommand kayit = new OleDbCommand("insert into iso ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti);
                        kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                        kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                        kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                        kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                        kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                        kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);

                        kayit.ExecuteNonQuery();
                        MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tablo.Clear();
                        baglanti.Close();

                        guncelle2();
                        OtoSıraNo();

                        textboxEgitimAdi.Text = "";
                        textboxEgitimZamani.Text = "";
                        textboxZoomID.Text = "";
                        textboxZoomSifre.Text = "";
                        textboxZoomLink.Text = "";
                        comboboxSaat.Text = "";

                    }
                    catch (InvalidCastException ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (comboBox1.Text == "AKBANK Akademi")
                {
                    try
                    {
                        baglanti.Open();
                        OleDbCommand kayit = new OleDbCommand("insert into akbank ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti);
                        kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                        kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                        kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                        kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                        kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                        kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);

                        kayit.ExecuteNonQuery();
                        MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tablo.Clear();
                        baglanti.Close();

                        guncelle3();
                        OtoSıraNo();

                        textboxEgitimAdi.Text = "";
                        textboxEgitimZamani.Text = "";
                        textboxZoomID.Text = "";
                        textboxZoomSifre.Text = "";
                        textboxZoomLink.Text = "";
                        comboboxSaat.Text = "";

                    }
                    catch (InvalidCastException ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (comboBox1.Text == "Microfon")
                {
                    try
                    {
                        baglanti.Open();
                        OleDbCommand kayit = new OleDbCommand("insert into microfon ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti);
                        kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                        kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                        kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                        kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                        kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                        kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);

                        kayit.ExecuteNonQuery();
                        MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tablo.Clear();
                        baglanti.Close();

                        guncelle4();
                        OtoSıraNo();

                        textboxEgitimAdi.Text = "";
                        textboxEgitimZamani.Text = "";
                        textboxZoomID.Text = "";
                        textboxZoomSifre.Text = "";
                        textboxZoomLink.Text = "";
                        comboboxSaat.Text = "";

                    }
                    catch (InvalidCastException ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else if (comboBox1.Text == "Solidworks")
                {
                    try
                    {
                        baglanti.Open();
                        OleDbCommand kayit = new OleDbCommand("insert into solidworks ([egitim_adi], [egitim_zamani],[zoom_id],[zoom_sifre],[zoom_link],[saat]) values (@egitim_adi, @egitim_zamani, @zoom_id, @zoom_sifre, @zoom_link, @saat)", baglanti);
                        kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                        kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                        kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                        kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                        kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                        kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);

                        kayit.ExecuteNonQuery();
                        MessageBox.Show("Yeni eğitim başarıyla eklendi!", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tablo.Clear();
                        baglanti.Close();

                        guncelle5();
                        OtoSıraNo();

                        textboxEgitimAdi.Text = "";
                        textboxEgitimZamani.Text = "";
                        textboxZoomID.Text = "";
                        textboxZoomSifre.Text = "";
                        textboxZoomLink.Text = "";
                        comboboxSaat.Text = "";

                    }
                    catch (InvalidCastException ex)
                    {
                        MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // GÜNCELLE
            else if (label14.Text == "Düzenle")
            {
                if (comboBox1.Text == "GAİB")
                {
                    baglanti.Open();
                    OleDbCommand kayit = new OleDbCommand("UPDATE gaib SET egitim_adi=@egitim_adi,egitim_zamani=@egitim_zamani,zoom_id=@zoom_id,zoom_sifre=@zoom_sifre,zoom_link=@zoom_link,saat=@saat WHERE id=@id", baglanti);

                    kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                    kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                    kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                    kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                    kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                    kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);

                    kayit.Parameters.AddWithValue("@id", Convert.ToInt32(lblid.Text));


                    kayit.ExecuteNonQuery();
                    MessageBox.Show("Liste başarıyla güncellendi!", "Eğitim Liste Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglanti.Close();
                    tablo.Clear();
                    guncelle();
                    OtoSıraNo();

                    textboxEgitimAdi.Text = "";
                    textboxEgitimZamani.Text = "";
                    textboxZoomID.Text = "";
                    textboxZoomLink.Text = "";
                    textboxZoomSifre.Text = "";
                    comboboxSaat.Text = "";
                    btn_kaydet.Text = "Kaydet";
                    
                }
                else if (comboBox1.Text == "İMMİB Akademi")
                {
                    baglanti.Open();
                    OleDbCommand kayit = new OleDbCommand("UPDATE immib SET egitim_adi=@egitim_adi,egitim_zamani=@egitim_zamani,zoom_id=@zoom_id,zoom_sifre=@zoom_sifre,zoom_link=@zoom_link,saat=@saat WHERE id=@id", baglanti);

                    kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                    kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                    kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                    kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                    kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                    kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);

                    kayit.Parameters.AddWithValue("@id", Convert.ToInt32(lblid.Text));


                    kayit.ExecuteNonQuery();
                    MessageBox.Show("Liste başarıyla güncellendi!", "Eğitim Liste Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglanti.Close();

                    tablo.Clear();
                    guncelle1();
                    OtoSıraNo();

                    textboxEgitimAdi.Text = "";
                    textboxEgitimZamani.Text = "";
                    textboxZoomID.Text = "";
                    textboxZoomLink.Text = "";
                    textboxZoomSifre.Text = "";
                    comboboxSaat.Text = "";
                }
                else if (comboBox1.Text == "ISO Akademi")
                {
                    baglanti.Open();
                    OleDbCommand kayit = new OleDbCommand("UPDATE iso SET egitim_adi=@egitim_adi,egitim_zamani=@egitim_zamani,zoom_id=@zoom_id,zoom_sifre=@zoom_sifre,zoom_link=@zoom_link,saat=@saat WHERE id=@id", baglanti);

                    kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                    kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                    kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                    kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                    kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                    kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);

                    kayit.Parameters.AddWithValue("@id", Convert.ToInt32(lblid.Text));


                    kayit.ExecuteNonQuery();
                    MessageBox.Show("Liste başarıyla güncellendi!", "Eğitim Liste Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglanti.Close();

                    tablo.Clear();
                    guncelle2();
                    OtoSıraNo();

                    textboxEgitimAdi.Text = "";
                    textboxEgitimZamani.Text = "";
                    textboxZoomID.Text = "";
                    textboxZoomLink.Text = "";
                    textboxZoomSifre.Text = "";
                    comboboxSaat.Text = "";
                }

                else if (comboBox1.Text == "AKBANK Akademi")
                {
                    baglanti.Open();
                    OleDbCommand kayit = new OleDbCommand("UPDATE akbank SET egitim_adi=@egitim_adi,egitim_zamani=@egitim_zamani,zoom_id=@zoom_id,zoom_sifre=@zoom_sifre,zoom_link=@zoom_link,saat=@saat WHERE id=@id", baglanti);

                    kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                    kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                    kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                    kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                    kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                    kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);

                    kayit.Parameters.AddWithValue("@id", Convert.ToInt32(lblid.Text));


                    kayit.ExecuteNonQuery();
                    MessageBox.Show("Liste başarıyla güncellendi!", "Eğitim Liste Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglanti.Close();

                    tablo.Clear();
                    guncelle3();
                    OtoSıraNo();

                    textboxEgitimAdi.Text = "";
                    textboxEgitimZamani.Text = "";
                    textboxZoomID.Text = "";
                    textboxZoomLink.Text = "";
                    textboxZoomSifre.Text = "";
                    comboboxSaat.Text = "";
                }
                else if (comboBox1.Text == "Microfon")
                {
                    baglanti.Open();
                    OleDbCommand kayit = new OleDbCommand("UPDATE microfon SET egitim_adi=@egitim_adi,egitim_zamani=@egitim_zamani,zoom_id=@zoom_id,zoom_sifre=@zoom_sifre,zoom_link=@zoom_link,saat=@saat WHERE id=@id", baglanti);

                    kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                    kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                    kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                    kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                    kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                    kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);

                    kayit.Parameters.AddWithValue("@id", Convert.ToInt32(lblid.Text));


                    kayit.ExecuteNonQuery();
                    MessageBox.Show("Liste başarıyla güncellendi!", "Eğitim Liste Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglanti.Close();

                    tablo.Clear();
                    guncelle4();
                    OtoSıraNo();

                    textboxEgitimAdi.Text = "";
                    textboxEgitimZamani.Text = "";
                    textboxZoomID.Text = "";
                    textboxZoomLink.Text = "";
                    textboxZoomSifre.Text = "";
                    comboboxSaat.Text = "";
                }
                else if (comboBox1.Text == "Solidworks")
                {
                    baglanti.Open();
                    OleDbCommand kayit = new OleDbCommand("UPDATE solidworks SET egitim_adi=@egitim_adi,egitim_zamani=@egitim_zamani,zoom_id=@zoom_id,zoom_sifre=@zoom_sifre,zoom_link=@zoom_link,saat=@saat WHERE id=@id", baglanti);

                    kayit.Parameters.AddWithValue("@egitim_adi", textboxEgitimAdi.Text);
                    kayit.Parameters.AddWithValue("@egitim_zamani", textboxEgitimZamani.Text);
                    kayit.Parameters.AddWithValue("@zoom_id", textboxZoomID.Text);
                    kayit.Parameters.AddWithValue("@zoom_sifre", textboxZoomSifre.Text);
                    kayit.Parameters.AddWithValue("@zoom_link", textboxZoomLink.Text);
                    kayit.Parameters.AddWithValue("@saat", comboboxSaat.Text);

                    kayit.Parameters.AddWithValue("@id", Convert.ToInt32(lblid.Text));


                    kayit.ExecuteNonQuery();
                    MessageBox.Show("Liste başarıyla güncellendi!", "Eğitim Liste Güncelleme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    baglanti.Close();

                    tablo.Clear();
                    guncelle5();
                    OtoSıraNo();

                    textboxEgitimAdi.Text = "";
                    textboxEgitimZamani.Text = "";
                    textboxZoomID.Text = "";
                    textboxZoomLink.Text = "";
                    textboxZoomSifre.Text = "";
                    comboboxSaat.Text = "";
                }
                else
                {
                    MessageBox.Show("Hata");
                }
            }


        }
        #endregion

        private void timer2_Tick(object sender, EventArgs e)
        {
            notification();
        }

        private void notification()
        {
            if (label20.Text == DateTime.Now.ToShortDateString()) //GAİB
            {
                if (vakit == kalanvakit)
                {
                    timer2.Stop();
                    if (MessageBox.Show("Eğitim Adı: " + label17.Text + "\n" + "\n" + "Eğitim Saati: " + label18.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(label19.Text);            
                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }

                }
                else if (vakit == kalanvakit1)
                {
                    timer2.Stop();
                    if (MessageBox.Show("Eğitim Adı: " + label17.Text + "\n" + "\n" + "Eğitim Saati: " + label18.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(label19.Text);
                      
                    }
                    else
                    {

                        //ZAMAN HESAPLAMA
                    }


                }
            }
            else if (label22.Text == DateTime.Now.ToShortDateString()) //İMMİB AKADEMİ
            {
                if (vakit == immibkalanvakit)
                {
                    timer2.Stop();
                    if (MessageBox.Show("Eğitim Adı: " + label25.Text + "\n" + "\n" + "Eğitim Saati: " + label23.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(label24.Text);

                    }
                    else
                    {
                        //ZAMAN HESAPLAMA
                    }

                }
                else if (immibvakit == immibkalanvakit1)
                {
                    timer2.Stop();
                    if (MessageBox.Show("Eğitim Adı: " + label25.Text + "\n" + "\n" + "Eğitim Saati: " + label23.Text, "Hatırlatıcı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        System.Diagnostics.Process.Start(label24.Text);

                    }
                    else
                    {

                        //ZAMAN HESAPLAMA
                    }


                }
            }
            else
            {
                //
            }   
          
            
           
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hakkinda yeni = new Hakkinda();
            yeni.Show();
        }

        private void genelAyarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ayarlar yeni = new Ayarlar();
            yeni.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void btn_link_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(dataGridView1.CurrentRow.Cells[6].Value.ToString());
        }

        private void btn_iptal_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            textboxEgitimAdi.Text = "";
            textboxEgitimZamani.Text = "";
            textboxZoomID.Text = "";
            textboxZoomSifre.Text = "";
            textboxZoomLink.Text = "";
            comboboxSaat.Text = "";
            btn_kaydet.Text = "Kaydet";
           
        }

        private void btn_ac_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
                textboxEgitimAdi.Text = "";
                textboxEgitimZamani.Text = "";
                textboxZoomID.Text = "";
                textboxZoomSifre.Text = "";
                textboxZoomLink.Text = "";
                comboboxSaat.Text = "";
                label14.Text = "Kaydet";
            }
            else
            {
                panel2.Visible = false;
            }
           
        }
        string vakit, kalanvakit, kalanvakit1;

        string immibvakit, immibkalanvakit, immibkalanvakit1;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (label20.Text == DateTime.Now.ToShortDateString()) //GAİB
            {
                string suankiSaat = DateTime.Now.ToShortTimeString();
                string bitisSaati = label18.Text;
                TimeSpan fark = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(suankiSaat));
                string calismasüresi = fark.TotalMinutes.ToString();
                label12.Text = calismasüresi;

                vakit = label12.Text;
                kalanvakit = "120";
                kalanvakit1 = "60";
            }
            else if (label22.Text == DateTime.Now.ToShortDateString()) // İMMİB AKADEMİ
            {
                string suankiSaat = DateTime.Now.ToShortTimeString();
                string bitisSaati = label23.Text;
                TimeSpan fark = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(suankiSaat));
                string calismasüresi = fark.TotalMinutes.ToString();
                label36.Text = calismasüresi;

                immibvakit = label36.Text;
                immibkalanvakit = "120";
                immibkalanvakit1 = "60";
            }
            else
            {
                //
            }      
        }
    }
}

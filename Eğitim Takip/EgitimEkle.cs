using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Eğitim_Takip
{
    public partial class EgitimEkle : Form
    {
        //SqlConnection baglanti2 = new SqlConnection("Data Source=IT-EYUP-LP\\SQLEXPRESS;Initial Catalog=veritabani;MultipleActiveResultSets=True;Integrated Security=True");
        SqlConnection baglanti2 = new SqlConnection(string.Format("Server={0};Database={1};Uid={2};Pwd={3};MultipleActiveResultSets=True;Integrated Security=True", svsettings.Default.server, svsettings.Default.database, svsettings.Default.username, svsettings.Default.password));
        public EgitimEkle()
        {
            InitializeComponent();
        }
       
        private void EgitimEkle_Load(object sender, EventArgs e)
        {
            textboxEgitimZamani.Text = DateTime.Now.ToShortDateString();
        }

        private void btn_kaydet_Click(object sender, EventArgs e)
        {
            try
            {
                if (textboxEgitimAdi.Text == "" || textboxEgitimZamani.Text == "" || textboxZoomID.Text == "" || textboxZoomSifre.Text == "" || textboxZoomLink.Text == "" || comboboxSaat.Text == "")
                {
                    MessageBox.Show("Lütfen boş bırakmayın", "Eğitim Ekle", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (label6.Text == "GAİB")
                    {
                        try
                        {
                            baglanti2.Open();
                            string query = "SELECT COUNT(*) FROM gaib WHERE egitim_adi = @egitimAdi";
                            SqlCommand tekrar = new SqlCommand(query, baglanti2);
                            tekrar.Parameters.AddWithValue("@egitimAdi", textboxEgitimAdi.Text);
                            int sonuc = (int)tekrar.ExecuteScalar();
                            if (sonuc == 0)
                            {
                                VeritabaniSec yeni = new VeritabaniSec();

                                yeni.a = textboxEgitimAdi.Text;
                                yeni.b = textboxEgitimZamani.Text;
                                yeni.c = textboxZoomID.Text;
                                yeni.d = textboxZoomSifre.Text;
                                yeni.f = textboxZoomLink.Text;
                                yeni.g = comboboxSaat.Text;
                                yeni.h = checkBox1.Text;
                                yeni.j = label6.Text;

                                yeni.Show();
                                this.Close();
                            }
                            if (sonuc > 0)
                            {
                                MessageBox.Show("Bu kayıt veritabanın da mevcut\nLütfen eğitim adı değiştirip yeniden düzenler misiniz?", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            baglanti2.Close();
                            
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else if (label6.Text == "İMMİB Akademi")
                    {
                        try
                        {
                            baglanti2.Open();
                            string query = "SELECT COUNT(*) FROM immib WHERE egitim_adi = @egitimAdi";
                            SqlCommand tekrar = new SqlCommand(query, baglanti2);
                            tekrar.Parameters.AddWithValue("@egitimAdi", textboxEgitimAdi.Text);
                            int sonuc = (int)tekrar.ExecuteScalar();
                            if (sonuc == 0)
                            {
                                VeritabaniSec yeni = new VeritabaniSec();

                                yeni.a = textboxEgitimAdi.Text;
                                yeni.b = textboxEgitimZamani.Text;
                                yeni.c = textboxZoomID.Text;
                                yeni.d = textboxZoomSifre.Text;
                                yeni.f = textboxZoomLink.Text;
                                yeni.g = comboboxSaat.Text;
                                yeni.h = checkBox1.Text;
                                yeni.j = label6.Text;

                                yeni.Show();
                                this.Close();
                            }
                            if (sonuc > 0)
                            {
                                MessageBox.Show("Bu kayıt veritabanın da mevcut\nLütfen eğitim adı değiştirip yeniden düzenler misiniz?", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            baglanti2.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (label6.Text == "ISO Akademi")
                    {
                        try
                        {
                            baglanti2.Open();
                            string query = "SELECT COUNT(*) FROM iso WHERE egitim_adi = @egitimAdi";
                            SqlCommand tekrar = new SqlCommand(query, baglanti2);
                            tekrar.Parameters.AddWithValue("@egitimAdi", textboxEgitimAdi.Text);
                            int sonuc = (int)tekrar.ExecuteScalar();
                            if (sonuc == 0)
                            {
                                VeritabaniSec yeni = new VeritabaniSec();

                                yeni.a = textboxEgitimAdi.Text;
                                yeni.b = textboxEgitimZamani.Text;
                                yeni.c = textboxZoomID.Text;
                                yeni.d = textboxZoomSifre.Text;
                                yeni.f = textboxZoomLink.Text;
                                yeni.g = comboboxSaat.Text;
                                yeni.h = checkBox1.Text;
                                yeni.j = label6.Text;

                                yeni.Show();
                                this.Close();
                            }
                            if (sonuc > 0)
                            {
                                MessageBox.Show("Bu kayıt veritabanın da mevcut\nLütfen eğitim adı değiştirip yeniden düzenler misiniz?", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            baglanti2.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (label6.Text == "AKBANK Akademi")
                    {
                        try
                        {
                            baglanti2.Open();
                            string query = "SELECT COUNT(*) FROM akbank WHERE egitim_adi = @egitimAdi";
                            SqlCommand tekrar = new SqlCommand(query, baglanti2);
                            tekrar.Parameters.AddWithValue("@egitimAdi", textboxEgitimAdi.Text);
                            int sonuc = (int)tekrar.ExecuteScalar();
                            if (sonuc == 0)
                            {
                                VeritabaniSec yeni = new VeritabaniSec();

                                yeni.a = textboxEgitimAdi.Text;
                                yeni.b = textboxEgitimZamani.Text;
                                yeni.c = textboxZoomID.Text;
                                yeni.d = textboxZoomSifre.Text;
                                yeni.f = textboxZoomLink.Text;
                                yeni.g = comboboxSaat.Text;
                                yeni.h = checkBox1.Text;
                                yeni.j = label6.Text;

                                yeni.Show();
                                this.Close();
                            }
                            if (sonuc > 0)
                            {
                                MessageBox.Show("Bu kayıt veritabanın da mevcut\nLütfen eğitim adı değiştirip yeniden düzenler misiniz?", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            baglanti2.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else if (label6.Text == "Microfon")
                    {
                        try
                        {
                            baglanti2.Open();
                            string query = "SELECT COUNT(*) FROM microfon WHERE egitim_adi = @egitimAdi";
                            SqlCommand tekrar = new SqlCommand(query, baglanti2);
                            tekrar.Parameters.AddWithValue("@egitimAdi", textboxEgitimAdi.Text);
                            int sonuc = (int)tekrar.ExecuteScalar();
                            if (sonuc == 0)
                            {
                                VeritabaniSec yeni = new VeritabaniSec();

                                yeni.a = textboxEgitimAdi.Text;
                                yeni.b = textboxEgitimZamani.Text;
                                yeni.c = textboxZoomID.Text;
                                yeni.d = textboxZoomSifre.Text;
                                yeni.f = textboxZoomLink.Text;
                                yeni.g = comboboxSaat.Text;
                                yeni.h = checkBox1.Text;
                                yeni.j = label6.Text;

                                yeni.Show();
                                this.Close();
                            }
                            if (sonuc > 0)
                            {
                                MessageBox.Show("Bu kayıt veritabanın da mevcut\nLütfen eğitim adı değiştirip yeniden düzenler misiniz?", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            baglanti2.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    else if (label6.Text == "Solidworks")
                    {
                        try
                        {
                            baglanti2.Open();
                            string query = "SELECT COUNT(*) FROM solidworks WHERE egitim_adi = @egitimAdi";
                            SqlCommand tekrar = new SqlCommand(query, baglanti2);
                            tekrar.Parameters.AddWithValue("@egitimAdi", textboxEgitimAdi.Text);
                            int sonuc = (int)tekrar.ExecuteScalar();
                            if (sonuc == 0)
                            {
                                VeritabaniSec yeni = new VeritabaniSec();

                                yeni.a = textboxEgitimAdi.Text;
                                yeni.b = textboxEgitimZamani.Text;
                                yeni.c = textboxZoomID.Text;
                                yeni.d = textboxZoomSifre.Text;
                                yeni.f = textboxZoomLink.Text;
                                yeni.g = comboboxSaat.Text;
                                yeni.h = checkBox1.Text;
                                yeni.j = label6.Text;

                                yeni.Show();
                                this.Close();
                            }
                            if (sonuc > 0)
                            {
                                MessageBox.Show("Bu kayıt veritabanın da mevcut\nLütfen eğitim adı değiştirip yeniden düzenler misiniz?", "Veritabanı Kaydı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            baglanti2.Close();
                        }
                        catch (InvalidCastException ex)
                        {
                            MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  
 

        private void btn_ekle_Click(object sender, EventArgs e)
        {

            try
            {
                if (label6.Text == "GAİB")
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "ICS Files (*.ics)|*.ics";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string filePath = openFileDialog.FileName;
                        string[] lines = File.ReadAllLines(filePath);

                        DateTime startDateTime = DateTime.MinValue;
      
                        string password = "";
                        string locationData = "";
                        string summaryData = "";
                        string meetingId = "";
                        string numberPart = "";

                        bool insideSummary = false;
                        bool insideLocation = false;
                        bool insideDescription = false;

                        foreach (string line in lines)
                        {
                            int startIndex = line.IndexOf("*") + 1;
                            int endIndex = line.IndexOf("#", startIndex);

                            if (line.StartsWith("DTSTART;"))
                            {
                                string dateTimeString = line.Substring("DTSTART;TZID=Europe/Istanbul:".Length);
                                startDateTime = DateTime.ParseExact(dateTimeString, "yyyyMMddTHHmmss", CultureInfo.InvariantCulture);
                            }

                            else if (line.StartsWith("SUMMARY:") && !insideSummary)
                            {
                                insideSummary = true;
                                summaryData = line.Substring("SUMMARY:".Length).Trim();
                            }
                            else if (insideSummary && line.StartsWith("UID:"))
                            {
                                insideSummary = false;
                            }
                            else if (insideSummary)
                            {
                                summaryData += line.Trim();
                            }
                            else if (line.StartsWith("LOCATION:") && !insideDescription)
                            {
                                insideLocation = true;
                                locationData = line.Substring("LOCATION:".Length).Trim();

                                int slashIndex = locationData.IndexOf("w/") + 2; // "w/" sonrasından başlayacak
                                int questionMarkIndex = locationData.IndexOf("?", slashIndex);

                                if (slashIndex >= 2 && questionMarkIndex > slashIndex)
                                {
                                    numberPart = locationData.Substring(slashIndex, questionMarkIndex - slashIndex);

                                }
                            }
                            else if (line.StartsWith("DESCRIPTION:"))
                            {
                                insideDescription = true;
                            }
                            else if (insideDescription && startIndex > 0 && endIndex > 0)
                            {
                                password = line.Substring(startIndex, endIndex - startIndex).Trim();
                                insideDescription = false;
                            }
                            else if (insideDescription && line.EndsWith("#"))
                            {
                                int lastSpaceIndex = line.LastIndexOf(" ");
                                if (lastSpaceIndex > 0)
                                {
                                    meetingId = line.Substring(lastSpaceIndex + 1, line.Length - lastSpaceIndex - 2);
                                    insideDescription = false;
                                }
                            }
                            else if (line.StartsWith("LOCATION:") && !insideDescription)
                            {
                                insideLocation = true;
                                locationData = line.Substring("LOCATION:".Length).Trim();
                            }
                            else if (insideLocation && line.StartsWith("BEGIN:"))
                            {
                                insideLocation = false;
                            }
                            else if (insideLocation)
                            {
                                locationData += line.Trim();
                            }
                        }

                        // Boşluk eklemek için metni parçalayalım
                        string formattedMeetingId = string.Format("{0} {1} {2}", numberPart.Substring(0, 3), numberPart.Substring(3, 4), numberPart.Substring(7));

                        textboxEgitimAdi.Text = summaryData;
                        textboxEgitimZamani.Text = startDateTime.ToString("dd.MM.yyyy");
                        comboboxSaat.Text = startDateTime.ToString("HH:mm");
                        textboxZoomLink.Text = locationData;
                        textboxZoomSifre.Text = password;
                        textboxZoomID.Text = formattedMeetingId;
                    }
                }
                else
                {
                    MessageBox.Show("Her bazı dosya bu programa uyumsuz olduğu için .ics dosyası açamıyoruz.\nÇok yakında güncelleme ile beraber gelecektir!", ".ics Hatası", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message, "ERROR12", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eğitim_Takip
{
    public partial class VeritabaniYedekleMail : Form
    {
        public VeritabaniYedekleMail()
        {
            InitializeComponent();
        }

        private void VeritabaniYedekleMail_Load(object sender, EventArgs e)
        {
            lblYedeklemeZamani.Text = Settings1.Default.yedeklemetarih.ToString();
            lblSonGondermeZamani.Text = Settings1.Default.mailtarih.ToString();
            textBox3.Text = Settings1.Default.mailadres.ToString();


        }

        private void btn_sqlyedekle_Click(object sender, EventArgs e)
        {
            lblYedeklemeZamani.Text = DateTime.Now.ToString();
            SqlConnection baglanti = new SqlConnection(string.Format("Server={0};Database={1};Uid={2};Pwd={3};MultipleActiveResultSets=True;Integrated Security=True", svsettings.Default.server, svsettings.Default.database, svsettings.Default.username, svsettings.Default.password));
            OleDbConnection baglanti1 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabani.mdb");
            SqlConnection baglanti2 = new SqlConnection(string.Format("Server={0};Database={1};Uid={2};Pwd={3};MultipleActiveResultSets=True;Integrated Security=True", svsettings.Default.server, svsettings.Default.database, svsettings.Default.username, svsettings.Default.password));
            string komutt = "backup database model to disk='veritabani.bak'";
            SqlCommand komut = new SqlCommand(komutt, baglanti);
            baglanti.Open();
            komut.ExecuteNonQuery();
            baglanti.Close();
            lblYedeklenenVeritabani.Text = textBox2.Text;
            Settings1.Default.yedeklemetarih = lblYedeklemeZamani.Text;
            Settings1.Default.Save();
        }

        private void btn_dosyabul_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Backup Dosyası |*.bak";
            saveFileDialog1.Title = "Yedeklenmiş bak dosyasını seçin";
            saveFileDialog1.ShowDialog();
            textBox2.Text = saveFileDialog1.FileName;
        }

        private void btn_mailgonder_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text =="")
            {
                MessageBox.Show("Yedeklenecek dosyayı ve maili boş geçmeyin");
            }
            else
            {
                string adres = textBox2.Text;
                Loading fl = new Loading();
                fl.ac();
                fl.mesaj_yaz("Gönderiyor..");

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("eyup.balaban@alfakimyaas.com");
                    mail.To.Add(textBox1.Text);
                    mail.Subject = "Balaban Yazılım";
                    mail.Body = "Balaban Yazılım veritabanı yedeklemesi";
                    mail.Attachments.Add(new Attachment(adres));
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.outlook.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("eyup.balaban@alfakimyaas.com", "eyup.2022");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                    fl.kapat();
                    MessageBox.Show("Mail gönderildi.");
                }

                lblSonGondermeZamani.Text = DateTime.Now.ToString();
                textBox3.Text = textBox2.Text;
                Settings1.Default.mailtarih = lblSonGondermeZamani.Text;
                Settings1.Default.mailadres = textBox2.Text;
                Settings1.Default.Save();
            }
        }
    }
}

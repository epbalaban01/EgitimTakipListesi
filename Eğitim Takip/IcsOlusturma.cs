using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eğitim_Takip
{
    public partial class IcsOlusturma : Form
    {
        public IcsOlusturma()
        {
            InitializeComponent();
        }

        private void IcsOlusturma_Load(object sender, EventArgs e)
        {
            List<string> saatler = new List<string>();

            for (int saat = 0; saat <= 23; saat++)
            {
                for (int dakika = 0; dakika < 60; dakika += 30)
                {
                    saatler.Add($"{saat:00}:{dakika:00}");
                }
            }

            comboBox1.Items.AddRange(saatler.ToArray());
            comboBox2.Items.AddRange(saatler.ToArray());
        }

        public class IcsEvent
        {
            public DateTime Start { get; set; }
            public DateTime saat { get; set; }
            public DateTime End { get; set; }
            public string Summary { get; set; }
            public string Description { get; set; }
            // Diğer özellikler de eklenebilir, ihtiyacınıza göre düzenleyebilirsiniz.
        }



        public class IcsGenerator
        {

            public static string GenerateIcsFile(DateTime start, DateTime end, DateTime saat, DateTime saat2, string summary, string description, string location)
            {
                String timeZone = "Europe/Istanbul";

                StringBuilder sbICSFile = new StringBuilder();
                sbICSFile.AppendLine("BEGIN:VCALENDAR");
                sbICSFile.AppendLine("VERSION:2.0");
                sbICSFile.AppendLine("PRODID://Balaban ICS/");
                sbICSFile.AppendLine("CALSCALE:GREGORIAN");

                // Event
                sbICSFile.AppendLine("BEGIN:VEVENT");
                sbICSFile.AppendLine("DTSTART;TZID=" + timeZone + ":" + start.ToString("yyyyMMdd") + "T" + saat.ToString("HHmmss"));
                sbICSFile.AppendLine("DTEND;TZID=" + timeZone + ":" + end.ToString("yyyyMMdd") + "T" + saat2.ToString("HHmmss"));
                sbICSFile.AppendLine("SUMMARY:" + summary);
                sbICSFile.AppendLine("DESCRIPTION:" + description);
                sbICSFile.AppendLine("LOCATION:" + location);
                sbICSFile.AppendLine("UID:1");
                sbICSFile.AppendLine("SEQUENCE:0");
                sbICSFile.AppendLine("END:VEVENT");

                sbICSFile.AppendLine("END:VCALENDAR");

                return sbICSFile.ToString();
            }
        }

        private void btn_ics_olustur_Click(object sender, EventArgs e)
        {
            DateTime start = dateTimePicker1.Value;
            DateTime end = dateTimePicker2.Value;

            string selectedSaat = comboBox1.Text;
            DateTime saat;
            if (!DateTime.TryParseExact(selectedSaat, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out saat))
            {
                MessageBox.Show("Başlangıç saatini geçerli bir saat formatında seçiniz.");
                return;
            }

            string selectedSaat2 = comboBox2.Text;
            DateTime saat2;
            if (!DateTime.TryParseExact(selectedSaat2, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out saat2))
            {
                MessageBox.Show("Bitiş saatini geçerli bir saat formatında seçiniz.");
                return;
            }

            string summary = txt_Baslik_Summary.Text;
            string location = txt_konum_location.Text;

            string description = txt_Aciklama_Description.Text.Replace(Environment.NewLine, "\\n");


            string icsContent = IcsGenerator.GenerateIcsFile(start, end, saat, saat2, summary, description, location);




            // ICS dosyasını kaydet veya kullanıcıya indirme seçeneği sun
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "iCalendar Files|*.ics";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog.FileName, icsContent);
                MessageBox.Show("ICS dosyası başarıyla oluşturuldu ve kaydedildi.");
            }

        }
    }
}

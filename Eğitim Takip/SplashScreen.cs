using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;

namespace Eğitim_Takip
{
    public partial class SplashScreen : Form
    {
        PrivateFontCollection privateFontCollection = new PrivateFontCollection();
        public SplashScreen()

        {
            InitializeComponent();

            // Font dosyasını yükle
            privateFontCollection.AddFontFile(Application.StartupPath + @"\Font\gilroy.otf");
        }
        
  
        private void SplashScreen_Load(object sender, EventArgs e)
        {
            label1.Font = new Font(privateFontCollection.Families[0], 30, FontStyle.Regular);
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //timer1.Enabled = true;
            //progressBar1.Increment(10);
            //if(progressBar1.Value == 100)
            //{
            //    timer1.Enabled = false;
            //    Form1 yeni = new Form1();
            //    yeni.Show();
            //    this.Hide();
            //}
            if (progressBar1.Value < 100)
            {
                progressBar1.Value += 5;    
            }
            else
            {
                timer1.Stop();
                GirisYap yeni = new GirisYap();
                yeni.Show();
                this.Hide();
            }

        }
    }
}

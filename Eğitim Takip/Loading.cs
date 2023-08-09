using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Eğitim_Takip
{
    public interface Loading_interface
    {
        void ac();
        void kapat();
        void mesaj_yaz(string smesaj);
    }

    public partial class Loading : Form, Loading_interface
    {
        public Loading()
        {
            InitializeComponent();
        }

        private void Loading_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblZaman.Text = DateTime.Now.ToString();
        }

        public void ac()
        {
            this.Show();
            label2.Text = "Bekleme Ekranı";
        }

        public void kapat()
        {
            this.Close();
        }

        public void mesaj_yaz(string smesaj)
        {
            label2.Text = smesaj;
            this.BringToFront();
            this.Refresh();
            Application.DoEvents();
        }
    }
}

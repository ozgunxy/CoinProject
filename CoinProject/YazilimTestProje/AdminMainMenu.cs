using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YazilimTestProje
{
    public partial class AdminMainMenu : Form
    {
        public AdminMainMenu()
        {
            InitializeComponent();
        }
        public void formcontrol()
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Çıkmak İstediğinizden Emin misiniz ?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (sonuc == DialogResult.No)
            {

            }
            if (sonuc == DialogResult.Yes)
            {
                this.Close();
                Application.Exit();
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            formcontrol();
        }
       public Admin admin;

        private void button1_Click(object sender, EventArgs e)
        {
            AdminKullaniciYonetimFormu akyf = new AdminKullaniciYonetimFormu();
            akyf.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AdminMeterialYönetimFormu amyf = new AdminMeterialYönetimFormu();
            amyf.admin = admin;
            amyf.Show();
            this.Hide();
        }

        private void AdminMainMenu_Load(object sender, EventArgs e)
        {

        }
    }
}

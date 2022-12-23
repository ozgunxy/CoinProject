using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace YazilimTestProje
{
    public partial class MainForm : Form
    {

        public User user;
        public MainForm()
        {
            InitializeComponent();
        }
        public void MainForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show(user.UserID.ToString());
            label1.Text = user.FirstName;
            label2.Text = user.lastName;
            MessageBox.Show(BitConverter.ToString(user.wallet.Address).Replace("-", ""));

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }






        private void button3_Click(object sender, EventArgs e)
        {
            KullanıcıBilgi kb = new KullanıcıBilgi();
            kb.ShowDialog();
        }

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            KullanıcıBilgi forms = new KullanıcıBilgi();
            forms.user = user;
            forms.Show();
            this.Hide();
        }
    }
}
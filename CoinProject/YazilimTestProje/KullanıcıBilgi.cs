using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Devart.Data.PostgreSql;
using Devart.Data;
using Devart.Common;
namespace YazilimTestProje
{
    public partial class KullanıcıBilgi : Form
    {
        public KullanıcıBilgi()
        {
            InitializeComponent();
        }
        public User user;
        private void KullanıcıBilgi_Load(object sender, EventArgs e)
        {

        }
        MainForm mf = new MainForm();
        private void button2_Click(object sender, EventArgs e)
        {
            mf.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mf.Show();
            this.Hide();
        }
    }
}
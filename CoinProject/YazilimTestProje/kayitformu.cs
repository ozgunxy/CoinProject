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
    public partial class kayitformu : Form
    {
        public kayitformu()
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
        private void pictureBox9_Click(object sender, EventArgs e)
        {
            formcontrol();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((long)DB.getInstance().executeScalar("SELECT COUNT(*) from public.users where userloginid = '"+textBox2.Text+"'") >0)
            {
                MessageBox.Show("This UserName is already used,please try again");
                return;
            }
            DB.getInstance().executeNonQuery("INSERT INTO users (userloginid,userpassword,username,usersurname,useremail) VALUES" +
                " ('" + textBox2.Text + "','" + textBox1.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')");
            MainForm forms = new MainForm();
            User user = new User(textBox2.Text, textBox1.Text);
            forms.user = user;
            forms.Show();
            this.Hide();
        }

        private void kayitformu_Load(object sender, EventArgs e)
        {
            
        }
    }
}

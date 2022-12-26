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
    public partial class AdminMeterialYönetimFormu : Form
    {
        public AdminMeterialYönetimFormu()
        {
            InitializeComponent();
        }
       public Admin admin;
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

        private void AdminMeterialYönetimFormu_Load(object sender, EventArgs e)
        {
            label6.Text = admin.adminUserName;
            dataGridView1.DataSource = DB.getInstance().executeDataTable("SELECT * FROM recyclematerial");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB.getInstance().executeDataTable("SELECT * FROM recyclematerial");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
            if (textBox1.Text == "" || textBox3.Text == "" || label13.Text == "")
            {
                MessageBox.Show("alanlari doldurunuz ?", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
                DB.getInstance().executeNonQuery("INSERT INTO recyclematerial (materialname,materialcarbonprice,materialtype) VALUES ('" + textBox1.Text + "','" + label13.Text + "','" + textBox3.Text + "')");
                dataGridView1.DataSource = DB.getInstance().executeDataTable("SELECT * FROM recyclematerial");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Olustu", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;

           
            if (rowIndex >= 0)
            {
                
                DataGridViewRow row = dataGridView1.Rows[rowIndex];

                
                textBox2.Text = row.Cells["materialid"].Value.ToString();
               textBox1.Text = row.Cells["materialname"].Value.ToString();
               textBox3.Text = row.Cells["materialtype"].Value.ToString();
                label13.Text = row.Cells["materialcarbonprice"].Value.ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
               DB.getInstance().executeNonQuery("DELETE FROM recyclematerial WHERE materialid = '" + textBox2.Text + "' ");
                dataGridView1.DataSource = DB.getInstance().executeDataTable("SELECT * FROM recyclematerial");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Olustu", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
             DB.getInstance().executeNonQuery("UPDATE recyclematerial SET materialname = '" + textBox1.Text + "',materialcarbonprice = '" + label13.Text + "',materialtype = '" + textBox3.Text + "' where materialid = '"+textBox2.Text+"' ");
                dataGridView1.DataSource = DB.getInstance().executeDataTable("SELECT * FROM recyclematerial");
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Olustu", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }
    }
}

﻿using System;
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
    public partial class DonusumFormu : Form
    {
        double carbonSayisi;
        double FullCarbon;
        public DonusumFormu()
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
        public User user;
        private void DonusumFormu_Load(object sender, EventArgs e)
        {
            PgSqlConnection conn = new PgSqlConnection("User Id=postgres;password=admin;Host=localhost;Port=8081;Database=INFO;Initial Schema=public");
            PgSqlCommand cmd = new PgSqlCommand("SELECT * FROM usersviews('" + user.UserID + "'); ", conn);
            PgSqlDataReader reader;
            conn.Open();
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                label6.Text = reader.GetString(0);
                label5.Text = reader.GetString(1);
                label8.Text = reader.GetString(2);
                label9.Text = reader.GetString(3);
                label10.Text = reader.GetString(4) + "RC";
                label20.Text = reader.GetString(5);
            }


            PgSqlCommand cmx = new PgSqlCommand("SELECT materialname FROM recyclematerial ", conn);
            PgSqlDataReader reader1;

            conn.Open();
            reader1 = cmx.ExecuteReader();
            while (reader1.Read())
            {

                comboBox2.Items.Add(reader1.GetString(0));
            }
            conn.Close();

            PgSqlCommand cmxx = new PgSqlCommand("SELECT materialtypename FROM materialtype ", conn);
            PgSqlDataReader reader11;

            conn.Open();
            reader11 = cmxx.ExecuteReader();
            while (reader11.Read())
            {

                comboBox1.Items.Add(reader11.GetString(0));
            }
            conn.Close();
            
              
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string x = comboBox2.SelectedItem.ToString();
            

            carbonSayisi = (int)DB.getInstance().executeScalar("SELECT materialcarbonprice FROM recyclematerial WHERE materialname = '" +x + "'");
            label13.Text = carbonSayisi.ToString();

            carboncarp();
            RcCoin();
        }
        

        public void carboncarp()
        {
            int textbox2value = Convert.ToInt32(textBox2.Text);
            FullCarbon = textbox2value * carbonSayisi;
            label13.Text = FullCarbon.ToString();
        }

        public void RcCoin()
        {
            double Rc;
            Rc = FullCarbon / Coin.RecyclecoinOnCarbon;
            label15.Text = Rc.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
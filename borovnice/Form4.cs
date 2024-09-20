using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace borovnice
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 9;
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Form1 form1 = new Form1();
                form1.StartPosition = FormStartPosition.CenterScreen;
                form1.Location = this.Location;
                form1.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                Form2 form2 = new Form2();
                form2.StartPosition = FormStartPosition.CenterScreen;
                form2.Location = this.Location;
                form2.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                Form3 form3 = new Form3();
                form3.StartPosition = FormStartPosition.CenterScreen;
                form3.Location = this.Location;
                form3.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                Form4 form4 = new Form4();
                form4.StartPosition = FormStartPosition.CenterScreen;
                form4.Location = this.Location;
                form4.Show();
                this.Hide();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string leto = comboBox1.Text;
            string prihodek = textBox9.Text;
            string odhodek = textBox10.Text;
            string iz_dob = "";

            int prihodek1 = Convert.ToInt32(textBox9.Text);
            int odhodek1 = Convert.ToInt32(textBox10.Text);

            if(prihodek1 > odhodek1)
            {
                int iz_dob1 = prihodek1 - odhodek1;
                iz_dob = Convert.ToString(iz_dob1);
                koncno_stanje.Text = iz_dob + "€";
                koncno_stanje.BackColor = Color.Green;
            }
            if (prihodek1 < odhodek1)
            {
                int iz_dob1 = prihodek1 - odhodek1;
                iz_dob = Convert.ToString(iz_dob1);
                koncno_stanje.Text = iz_dob + "€";
                koncno_stanje.BackColor = Color.Red;
            }

            using (SQLiteConnection conn = new SQLiteConnection("data source=borovniceB.db"))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                        // Vstavi datum, gnjilo, GERK1, GERK2, ukrep, kolicino v bazo
                        cmd.CommandText = "INSERT INTO stroski_ (leto, prihodek, odhodek, iz_dob) VALUES (@leto, @prihodek, @odhodek, @iz_dob)";
                        cmd.Parameters.AddWithValue("@leto", leto);
                        cmd.Parameters.AddWithValue("@prihodek", prihodek);
                        cmd.Parameters.AddWithValue("@odhodek", odhodek);
                        cmd.Parameters.AddWithValue("@iz_dob", iz_dob);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Podatek je uspešno vstavljen!");
                }
            }
        }
    }
}


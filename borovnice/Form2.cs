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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace borovnice
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string gnojilo = textBox5.Text;
                string kolicina = textBox8.Text;
                string datum = dateTimePicker3.Text;
                string analiza = "";
                string GERK1383 = "";
                string GERK6008911 = "";

                if (radioButton5.Checked)
                {
                    analiza = "Da"; 
                }
                if (radioButton6.Checked)
                {
                    analiza = "Ne"; 
                }
                if (radioButton3.Checked)
                {
                    GERK1383 = "Da";
                }
                if (radioButton4.Checked)
                {
                    GERK1383 = "Ne";
                }
                if (radioButton1.Checked)
                {
                    GERK6008911 = "Da";
                }
                if (radioButton2.Checked)
                {
                    GERK6008911 = "Ne";
                }

                using (SQLiteConnection conn = new SQLiteConnection("data source=borovniceB.db"))
                {
                    conn.Open();

                    using (SQLiteCommand cmd = new SQLiteCommand(conn))
                    {
                        DateTime datumDateTime;

                        if (DateTime.TryParseExact(datum, "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out datumDateTime))
                        {
                            // Vstavi datum, gnjilo, GERK1, GERK2, ukrep, kolicino v bazo
                            cmd.CommandText = "INSERT INTO Gnojenje (datum, gnojilo, GERK6008911, GERK1383, analiza, kolicina) VALUES (@datum, @gnojilo, @GERK6008911, @GERK1383, @analiza, @kolicina)";
                            cmd.Parameters.AddWithValue("@datum", datum);
                            cmd.Parameters.AddWithValue("@gnojilo", gnojilo);
                            cmd.Parameters.AddWithValue("@GERK1383", GERK1383);
                            cmd.Parameters.AddWithValue("@GERK6008911", GERK6008911);
                            cmd.Parameters.AddWithValue("@analiza", analiza);
                            cmd.Parameters.AddWithValue("@kolicina", kolicina);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Podatek je uspešno vstavljen!");
                        }
                        else
                        {
                            MessageBox.Show("Vstavljen naroben format!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}


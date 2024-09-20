using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Globalization;

namespace borovnice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            comboBox1.SelectedIndex = 0;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double a = 0;
                double b = 0;
                double c = 0;

                a = Convert.ToDouble(textBox1.Text);
                b = Convert.ToDouble(textBox2.Text);

                c = a - b;
                koncno_stanje.Text = Convert.ToString(c);

                string dokup = textBox1.Text;
                string poraba = textBox2.Text;
                string datum = dateTimePicker1.Text;
                string stanje = koncno_stanje.Text;

                try
                {
                    using (SQLiteConnection conn = new SQLiteConnection("data source=borovniceB.db"))
                    {
                        conn.Open();

                        using (SQLiteCommand cmd = new SQLiteCommand(conn))
                        {
                            DateTime datumDateTime;
                            switch (comboBox1.SelectedIndex)
                            {
                                //BCX900
                                case 1:

                                    if (DateTime.TryParseExact(datum, "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out datumDateTime))
                                    {
                                        // Vstavi datum, dokup, porabo v bazo
                                        cmd.CommandText = "INSERT INTO BCX900 (datum, dokup, poraba) VALUES (@datum, @dokup, @poraba)";
                                        cmd.Parameters.AddWithValue("@datum", datum);
                                        cmd.Parameters.AddWithValue("@dokup", dokup);
                                        cmd.Parameters.AddWithValue("@poraba", poraba);
                                        cmd.ExecuteNonQuery();

                                        // Pridobi zadnjo vrsto v bazi
                                        cmd.CommandText = "SELECT last_insert_rowid()";
                                        int lastInsertedRowId = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Od stanja odšteje porabo
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET BCX900 = BCX900 - (SELECT poraba FROM BCX900 WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();

                                        // Stanju prišteje dokup
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET BCX900 = BCX900 + (SELECT dokup FROM BCX900 WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vstavljen naroben format!");
                                    }

                                    break;

                                //BCX900_2
                                case 2:

                                    if (DateTime.TryParseExact(datum, "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out datumDateTime))
                                    {
                                        // Vstavi datum, dokup, porabo v bazo
                                        cmd.CommandText = "INSERT INTO BCX900_2 (datum, dokup, poraba) VALUES (@datum, @dokup, @poraba)";
                                        cmd.Parameters.AddWithValue("@datum", datum);
                                        cmd.Parameters.AddWithValue("@dokup", dokup);
                                        cmd.Parameters.AddWithValue("@poraba", poraba);
                                        cmd.ExecuteNonQuery();

                                        // Pridobi zadnjo vrsto v bazi
                                        cmd.CommandText = "SELECT last_insert_rowid()";
                                        int lastInsertedRowId = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Od stanja odšteje porabo
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET BCX900_2 = BCX900_2 - (SELECT poraba FROM BCX900_2 WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();

                                        // Stanju prišteje dokup
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET BCX900_2 = BCX900_2 + (SELECT dokup FROM BCX900_2 WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vstavljen naroben format!");
                                    }

                                    break;

                                //biogvano
                                case 3:

                                    if (DateTime.TryParseExact(datum, "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out datumDateTime))
                                    {
                                        // Vstavi datum, dokup, porabo v bazo
                                        cmd.CommandText = "INSERT INTO bioguano (datum, dokup, poraba) VALUES (@datum, @dokup, @poraba)";
                                        cmd.Parameters.AddWithValue("@datum", datum);
                                        cmd.Parameters.AddWithValue("@dokup", dokup);
                                        cmd.Parameters.AddWithValue("@poraba", poraba);
                                        cmd.ExecuteNonQuery();

                                        // Pridobi zadnjo vrsto v bazi
                                        cmd.CommandText = "SELECT last_insert_rowid()";
                                        int lastInsertedRowId = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Od stanja odšteje porabo
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET bioguano = bioguano - (SELECT poraba FROM bioguano WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();

                                        // Stanju prišteje dokup
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET bioguano = bioguano + (SELECT dokup FROM bioguano WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vstavljen naroben format!");
                                    }

                                    break;

                                //borax
                                case 4:

                                    if (DateTime.TryParseExact(datum, "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out datumDateTime))
                                    {
                                        // Vstavi datum, dokup, porabo v bazo
                                        cmd.CommandText = "INSERT INTO borax (datum, dokup, poraba) VALUES (@datum, @dokup, @poraba)";
                                        cmd.Parameters.AddWithValue("@datum", datum);
                                        cmd.Parameters.AddWithValue("@dokup", dokup);
                                        cmd.Parameters.AddWithValue("@poraba", poraba);
                                        cmd.ExecuteNonQuery();

                                        // Pridobi zadnjo vrsto v bazi
                                        cmd.CommandText = "SELECT last_insert_rowid()";
                                        int lastInsertedRowId = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Od stanja odšteje porabo
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET borax = borax - (SELECT poraba FROM borax WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();

                                        // Stanju prišteje dokup
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET borax = borax + (SELECT dokup FROM borax WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vstavljen naroben format!");
                                    }

                                    break;

                                //cuprablau z
                                case 5:

                                    if (DateTime.TryParseExact(datum, "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out datumDateTime))
                                    {
                                        // Vstavi datum, dokup, porabo v bazo
                                        cmd.CommandText = "INSERT INTO cuprablauz (datum, dokup, poraba) VALUES (@datum, @dokup, @poraba)";
                                        cmd.Parameters.AddWithValue("@datum", datum);
                                        cmd.Parameters.AddWithValue("@dokup", dokup);
                                        cmd.Parameters.AddWithValue("@poraba", poraba);
                                        cmd.ExecuteNonQuery();

                                        // Pridobi zadnjo vrsto v bazi
                                        cmd.CommandText = "SELECT last_insert_rowid()";
                                        int lastInsertedRowId = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Od stanja odšteje porabo
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET cuprablauz = cuprablauz - (SELECT poraba FROM cuprablauz WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();

                                        // Stanju prišteje dokup
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET cuprablauz = cuprablauz + (SELECT dokup FROM cuprablauz WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vstavljen naroben format!");
                                    }

                                    break;

                                //ecosid g
                                case 6:

                                    if (DateTime.TryParseExact(datum, "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out datumDateTime))
                                    {
                                        // Vstavi datum, dokup, porabo v bazo
                                        cmd.CommandText = "INSERT INTO ecosidG (datum, dokup, poraba) VALUES (@datum, @dokup, @poraba)";
                                        cmd.Parameters.AddWithValue("@datum", datum);
                                        cmd.Parameters.AddWithValue("@dokup", dokup);
                                        cmd.Parameters.AddWithValue("@poraba", poraba);
                                        cmd.ExecuteNonQuery();

                                        // Pridobi zadnjo vrsto v bazi
                                        cmd.CommandText = "SELECT last_insert_rowid()";
                                        int lastInsertedRowId = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Od stanja odšteje porabo
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET ecosidG = ecosidG - (SELECT poraba FROM ecosidG WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();

                                        // Stanju prišteje dokup
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET ecosidG = ecosidG + (SELECT dokup FROM ecosidG WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vstavljen naroben format!");
                                    }

                                    break;

                                //fertil
                                case 7:

                                    if (DateTime.TryParseExact(datum, "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out datumDateTime))
                                    {
                                        // Vstavi datum, dokup, porabo v bazo
                                        cmd.CommandText = "INSERT INTO fertilD (datum, dokup, poraba) VALUES (@datum, @dokup, @poraba)";
                                        cmd.Parameters.AddWithValue("@datum", datum);
                                        cmd.Parameters.AddWithValue("@dokup", dokup);
                                        cmd.Parameters.AddWithValue("@poraba", poraba);
                                        cmd.ExecuteNonQuery();

                                        // Pridobi zadnjo vrsto v bazi
                                        cmd.CommandText = "SELECT last_insert_rowid()";
                                        int lastInsertedRowId = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Od stanja odšteje porabo
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET fertilD = fertilD - (SELECT poraba FROM fertilD WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();

                                        // Stanju prišteje dokup
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET fertilD = fertilD + (SELECT dokup FROM fertilD WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vstavljen naroben format!");
                                    }

                                    break;

                                //ovitex
                                case 8:

                                    if (DateTime.TryParseExact(datum, "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out datumDateTime))
                                    {
                                        // Vstavi datum, dokup, porabo v bazo
                                        cmd.CommandText = "INSERT INTO ovitex (datum, dokup, poraba) VALUES (@datum, @dokup, @poraba)";
                                        cmd.Parameters.AddWithValue("@datum", datum);
                                        cmd.Parameters.AddWithValue("@dokup", dokup);
                                        cmd.Parameters.AddWithValue("@poraba", poraba);
                                        cmd.ExecuteNonQuery();

                                        // Pridobi zadnjo vrsto v bazi
                                        cmd.CommandText = "SELECT last_insert_rowid()";
                                        int lastInsertedRowId = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Od stanja odšteje porabo
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET ovitex = ovitex - (SELECT poraba FROM ovitex WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();

                                        // Stanju prišteje dokup
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET ovitex = ovitex + (SELECT dokup FROM ovitex WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vstavljen naroben format!");
                                    }

                                    break;

                                //redoxAgro
                                case 9:

                                    if (DateTime.TryParseExact(datum, "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out datumDateTime))
                                    {
                                        // Vstavi datum, dokup, porabo v bazo
                                        cmd.CommandText = "INSERT INTO redoxAgro (datum, dokup, poraba) VALUES (@datum, @dokup, @poraba)";
                                        cmd.Parameters.AddWithValue("@datum", datum);
                                        cmd.Parameters.AddWithValue("@dokup", dokup);
                                        cmd.Parameters.AddWithValue("@poraba", poraba);
                                        cmd.ExecuteNonQuery();

                                        // Pridobi zadnjo vrsto v bazi
                                        cmd.CommandText = "SELECT last_insert_rowid()";
                                        int lastInsertedRowId = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Od stanja odšteje porabo
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET redoxAgro = redoxAgro - (SELECT poraba FROM redoxAgro WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();

                                        // Stanju prišteje dokup
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET redoxAgro = redoxAgro + (SELECT dokup FROM redoxAgro WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vstavljen naroben format!");
                                    }

                                    break;

                                //zeolitG
                                case 10:

                                    if (DateTime.TryParseExact(datum, "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out datumDateTime))
                                    {
                                        // Vstavi datum, dokup, porabo v bazo
                                        cmd.CommandText = "INSERT INTO zeolitG (datum, dokup, poraba) VALUES (@datum, @dokup, @poraba)";
                                        cmd.Parameters.AddWithValue("@datum", datum);
                                        cmd.Parameters.AddWithValue("@dokup", dokup);
                                        cmd.Parameters.AddWithValue("@poraba", poraba);
                                        cmd.ExecuteNonQuery();

                                        // Pridobi zadnjo vrsto v bazi
                                        cmd.CommandText = "SELECT last_insert_rowid()";
                                        int lastInsertedRowId = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Od stanja odšteje porabo
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET zeolitG = zeolitG - (SELECT poraba FROM zeolitG WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();

                                        // Stanju prišteje dokup
                                        cmd.Parameters.Clear();
                                        cmd.CommandText = "UPDATE stanje_ SET zeolitG = zeolitG + (SELECT dokup FROM zeolitG WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vstavljen naroben format!");
                                    }

                                    break;

                                //zeolitM
                                case 11:

                                    if (DateTime.TryParseExact(datum, "d", CultureInfo.CurrentCulture, DateTimeStyles.None, out datumDateTime))
                                    {
                                        // Vstavi datum, dokup, porabo v bazo
                                        cmd.CommandText = "INSERT INTO zeolitM (datum, dokup, poraba) VALUES (@datum, @dokup, @poraba)";
                                        cmd.Parameters.AddWithValue("@datum", datum);
                                        cmd.Parameters.AddWithValue("@dokup", dokup);
                                        cmd.Parameters.AddWithValue("@poraba", poraba);
                                        cmd.ExecuteNonQuery(); 

                                        // Pridobi zadnjo vrsto v bazi
                                        cmd.CommandText = "SELECT last_insert_rowid()";
                                        int lastInsertedRowId = Convert.ToInt32(cmd.ExecuteScalar());

                                        // Od stanja odšteje porabo
                                        cmd.Parameters.Clear(); 
                                        cmd.CommandText = "UPDATE stanje_ SET zeolitM = zeolitM - (SELECT poraba FROM zeolitM WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();

                                        // Stanju prišteje dokup
                                        cmd.Parameters.Clear(); 
                                        cmd.CommandText = "UPDATE stanje_ SET zeolitM = zeolitM + (SELECT dokup FROM zeolitM WHERE id = @id)";
                                        cmd.Parameters.AddWithValue("@id", lastInsertedRowId);
                                        cmd.ExecuteNonQuery();
                                    }
                                    else
                                    {
                                        Console.WriteLine("Vstavljen naroben format!");
                                    }
                                    
                                    break;
                            }
                        }
                    }

                    MessageBox.Show("Podatek je uspešno vstavljen!");

                    koncno_stanje.Text = "_____________";
                    textBox1.Text = "";
                    textBox2.Text = "";
                    comboBox1.SelectedIndex = 0;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                //BCX900
                case 1:
                    label6.Text = "l";
                    label7.Text = "l";

                    break;

                //BCX900+2
                case 2:
                    label6.Text = "l";
                    label7.Text = "l";

                    break;

                //Bioguana
                case 3:
                    label6.Text = "KG";
                    label7.Text = "KG";

                    break;

                //Borax
                case 4:
                    label6.Text = "KG";
                    label7.Text = "KG";

                    break;

                //Cuprablau z
                case 5:
                    label6.Text = "KG";
                    label7.Text = "KG";

                    break;

                //Ecocid G
                case 6:
                    label6.Text = "KG";
                    label7.Text = "KG";

                    break;

                //Fertil 
                case 7:
                    label6.Text = "KG";
                    label7.Text = "KG";

                    break;

                //Ovitex
                case 8:
                    label6.Text = "l";
                    label7.Text = "l";

                    break;

                //RedoxAgro 
                case 9:
                    label6.Text = "l";
                    label7.Text = "l";

                    break;

                //ZeolitG
                case 10:
                    label6.Text = "KG";
                    label7.Text = "KG";

                    break;

                //ZeolitG
                case 11:
                    label6.Text = "KG";
                    label7.Text = "KG";

                    break;
            }
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Taller_02_base_de_datos
{
    public partial class RF_6_7_10 : Form
    {
        public RF_6_7_10()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void botonVolverRF6_Click(object sender, EventArgs e)
        {

           
            this.Close();
        }

        private void RF6_Load(object sender, EventArgs e)
        {


            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Open();
            micodigo.Connection = miconectar;

            micodigo.CommandText = ("SELECT rut, nombre_profesor FROM profesor order by nombre_profesor;");
            MySqlDataReader leer = micodigo.ExecuteReader();
            if (leer.Read())
            {
                miconectar.Close();
                miconectar.Open();
                micodigo.Connection = miconectar;
                micodigo.CommandText = ("SELECT rut, nombre_profesor FROM profesor order by nombre_profesor;");
                MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
                DataTable dt = new DataTable();
                da1.Fill(dt);

                comboBox1.ValueMember = "rut";
                comboBox1.DisplayMember = "nombre_profesor";
                comboBox1.DataSource = dt;
            }
            else { MessageBox.Show("no hay profesores registrados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            miconectar.Close();
            comboBox1.SelectedItem = null;
            label2.Visible = false;
            listBox1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                MySqlCommand micodigo = new MySqlCommand();
                MySqlConnection miconectar = Program.estamosconectados;
                miconectar.Close();
                miconectar.Open();
                micodigo.Connection = miconectar;
                micodigo.CommandText = ("SELECT bono  , nombre_curso FROM curso where profesorrut = '" + comboBox1.SelectedValue + "' ;");
                //MessageBox.Show(micodigo.CommandText);
                MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
                DataTable dt = new DataTable();
                da1.Fill(dt);

                listBox1.DisplayMember = "nombre_curso";
                listBox1.ValueMember = "bono";
                listBox1.DataSource = dt;
                miconectar.Close();

                label2.Visible = true;
                listBox1.Visible = true;
                label3.Text = "total de cursos: " + listBox1.Items.Count.ToString();
                label3.Visible = true;
            
            
                miconectar.Open();
                micodigo.Connection = miconectar;
                micodigo.CommandText = ("SELECT sum(bono) FROM curso where profesorrut = '" + comboBox1.SelectedValue + "' ;");
                //MessageBox.Show(micodigo.CommandText);
                da1 = new MySqlDataAdapter(micodigo);
                dt = new DataTable();
                da1.Fill(dt);


                label5.Text = dt.Rows[0].ItemArray[0].ToString();
                label4.Visible = true;
                label5.Visible = true;
                listBox1.ClearSelected();
            miconectar.Close();

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

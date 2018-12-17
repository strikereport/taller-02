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
    public partial class RF16 : Form
    {
        public RF16()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

        private void RF16_Load(object sender, EventArgs e)
        {


            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Open();
            micodigo.Connection = miconectar;

            micodigo.CommandText = ("SELECT id_curso, nombre_curso FROM curso order by nombre_curso;");
            MySqlDataReader leer = micodigo.ExecuteReader();
            if (leer.Read())
            {
                miconectar.Close();
                miconectar.Open();
                micodigo.Connection = miconectar;
                micodigo.CommandText = ("SELECT id_curso, nombre_curso FROM curso order by nombre_curso;");
                MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
                DataTable dt = new DataTable();
                da1.Fill(dt);

                comboBox1.ValueMember = "id_curso";
                comboBox1.DisplayMember = "nombre_curso";
                comboBox1.DataSource = dt;
            }
            else { MessageBox.Show("no hay cursos registrados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            miconectar.Close();
            

        }

        private void botonBuscarRF16_Click(object sender, EventArgs e)
        {

            /*
            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Open();
            micodigo.Connection = miconectar;

            micodigo.CommandText = ("select count(*) as inscritos from estudiante_curso where estudiante_curso.id_curso = " + comboBox1.SelectedValue + " and cast(estudiante_curso.fecha_creacion as time) >= '00:00:00' and  cast(estudiante_curso.fecha_creacion as time) <= '08:00:00';");
            
                MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
                DataTable dt = new DataTable();
                da1.Fill(dt);
            label2.Text = dt.Rows[0].ItemArray[0].ToString();
            label2.Visible = true;    
            miconectar.Close();
            */
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Close();
            miconectar.Open();
            micodigo.Connection = miconectar;

            micodigo.CommandText = ("select count(*) as inscritos from estudiante_curso where estudiante_curso.id_curso = " + comboBox1.SelectedValue + " and cast(estudiante_curso.fecha_creacion as time) >= '00:00:00' and  cast(estudiante_curso.fecha_creacion as time) <= '08:00:00';");

            MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            label2.Text ="Inscritos entre las 00:00 a 08:00 : "+ dt.Rows[0].ItemArray[0].ToString();
            label2.Visible = true;
            miconectar.Close();
        }
    }
}

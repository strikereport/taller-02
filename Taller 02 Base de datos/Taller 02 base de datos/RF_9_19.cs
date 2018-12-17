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
    public partial class RF_9_19 : Form
    {
        public RF_9_19()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void RF9_Load(object sender, EventArgs e)
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
            label2.Visible = true;
            


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Close();
            miconectar.Open();
            micodigo.Connection = miconectar;

            micodigo.CommandText = ("select count(*) as inscritos from estudiante_curso where estudiante_curso.id_curso = " + comboBox1.SelectedValue + " ;");

            MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            label2.Text = "total de estudiantes : " + dt.Rows[0].ItemArray[0].ToString();
            label2.Visible = true;
            miconectar.Close();


            miconectar.Open();
            micodigo.Connection = miconectar;

            micodigo.CommandText = ("select nombre_estudiante from estudiante_curso, estudiante where estudiante_curso.id_curso = " + comboBox1.SelectedValue + " and estudiante.rut_estudiante = estudiante_curso.rut_estudiante;");

             da1 = new MySqlDataAdapter(micodigo);
             dt = new DataTable();
            da1.Fill(dt);
            listBox1.DisplayMember = "nombre_estudiante";
            listBox1.DataSource = dt;
            label3.Visible = true;
            listBox1.Visible = true;
            listBox1.ClearSelected();
            miconectar.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

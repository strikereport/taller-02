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
    public partial class RF5 : Form
    {
        public RF5()
        {
            InitializeComponent();
        }

        private void RF5_Load(object sender, EventArgs e)
        {


            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Open();
            micodigo.Connection = miconectar;

            micodigo.CommandText = ("SELECT rut_estudiante, nombre_estudiante FROM estudiante;");
            MySqlDataReader leer = micodigo.ExecuteReader();
            if (leer.Read())
            {
                miconectar.Close();
                miconectar.Open();
                micodigo.Connection = miconectar;
                micodigo.CommandText = ("SELECT rut_estudiante, nombre_estudiante FROM estudiante order by nombre_estudiante;");
                MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
                DataTable dt = new DataTable();
                da1.Fill(dt);

                comboBox1.ValueMember = "rut_estudiante";
                comboBox1.DisplayMember = "nombre_estudiante";
                comboBox1.DataSource = dt;
            }
            else { MessageBox.Show("no hay estudiantes registrados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            miconectar.Close();
            
        }

        private void VolverRF5_Click(object sender, EventArgs e)
        {
            
           // this.Hide();
            //Busqueda busqueda = new Busqueda();
            //busqueda.ShowDialog();
            this.Close();
        }

        private void BuscarRF5_Click(object sender, EventArgs e)
        {

            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Open();
            micodigo.Connection = miconectar;
            micodigo.CommandText = ("SELECT nombre_curso FROM curso, estudiante_curso where rut_estudiante = '"+comboBox1.SelectedValue+ "' and curso.id_curso = estudiante_curso.id_curso;");
            //MessageBox.Show(micodigo.CommandText);
            MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            listBox1.DisplayMember = "nombre_curso";
            listBox1.DataSource = dt;
            miconectar.Close();
            listBox1.Visible = true;
            listBox1.ClearSelected();
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

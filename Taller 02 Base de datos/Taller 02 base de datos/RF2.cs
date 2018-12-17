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
    public partial class RF2 : Form
    {
        public RF2()
        {
            InitializeComponent();
        }

        private void RF2_Load(object sender, EventArgs e)
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Close();
            miconectar.Open();
            micodigo.Connection = miconectar;
            micodigo.CommandText = ("SELECT curso.id_curso , nombre_curso FROM curso, estudiante_curso where rut_estudiante = '" + comboBox1.SelectedValue + "' and curso.id_curso = estudiante_curso.id_curso;");
            //MessageBox.Show(micodigo.CommandText);
            MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            listBox1.ValueMember = "id_curso";
            listBox1.DisplayMember = "nombre_curso";
            listBox1.DataSource = dt;
            miconectar.Close();
            listBox1.Visible = true;
            listBox1.ClearSelected();
        }
        private void refrescarLista() {
            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            
            miconectar.Open();
            micodigo.Connection = miconectar;
            micodigo.CommandText = ("SELECT curso.id_curso , nombre_curso FROM curso, estudiante_curso where rut_estudiante = '" + comboBox1.SelectedValue + "' and curso.id_curso = estudiante_curso.id_curso;");
            //MessageBox.Show(micodigo.CommandText);
            MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            listBox1.ValueMember = "id_curso";
            listBox1.DisplayMember = "nombre_curso";
            listBox1.DataSource = dt;
            miconectar.Close();
            listBox1.Visible = true;
            listBox1.ClearSelected();
        }

        private void botonDeleteR2_Click(object sender, EventArgs e)
        {
            //MessageBox.Show((comboBox1.SelectedValue) + " - "+ (listBox1.SelectedValue));
            if ((listBox1.Text == "") || (comboBox1.Text == ""))
            {
                MessageBox.Show("seleccione un estudiante y un curso antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else {
                RF2popUp confirmar = new RF2popUp(comboBox1.SelectedValue.ToString(), comboBox1.Text, listBox1.SelectedValue.ToString(), listBox1.Text);
                confirmar.ShowDialog();
                refrescarLista();
            }
        }
    }
}

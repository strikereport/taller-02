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
using Microsoft.VisualBasic;


namespace Taller_02_base_de_datos
{
    public partial class RF3 : Form
    {
        public RF3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RF3_Load(object sender, EventArgs e)
        {
            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Open();
            micodigo.Connection = miconectar;

            micodigo.CommandText = ("SELECT id_curso, nombre_curso FROM curso order by nombre_curso;");
            MySqlDataReader leer = micodigo.ExecuteReader();
            if (leer.Read())
            {
                refrescarComboBox();
            }
            else { MessageBox.Show("no hay cursos registrados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            miconectar.Close();
            comboBox1.SelectedItem = null;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(comboBox1.SelectedValue.ToString()+"\n"+ comboBox1.Text + "\n"+ comboBox1.Text.Equals(""));
            if (comboBox1.Text.Equals("")) {
                MessageBox.Show("seleccione un curso antes de continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            String pass = "";

            String cantInscritos = getDatoUnico("select count(*) from estudiante_curso where estudiante_curso.id_curso = "+comboBox1.SelectedValue.ToString()+";");
            pass = Microsoft.VisualBasic.Interaction.InputBox("desea eliminar el curso "+comboBox1.Text+"? esta accion desvinculara a "+ cantInscritos+" estudiantes inscritos\nIngrese su contraseña para continuar:","");
            if (pass == null || pass.Equals("")) {
                return;
            }

            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Open();
            micodigo.Connection = miconectar;

            micodigo.CommandText = ("SELECT password FROM administrador where password = '"+pass+"';");
            MySqlDataReader leer = micodigo.ExecuteReader();
            if (leer.Read())
            {
                string[] comando = { "DELETE FROM estudiante_curso WHERE id_curso ='"+comboBox1.SelectedValue.ToString()+"';", "DELETE FROM curso WHERE id_curso = '"+comboBox1.SelectedValue.ToString()+"' ;" };
                for (int i = 0; i<comando.Length;i++) {
                    miconectar.Close();
                    miconectar.Open();
                    micodigo.Connection = miconectar;
                    micodigo.CommandText = (comando[i]);
                    int j = micodigo.ExecuteNonQuery();
                }
               
                refrescarComboBox();
            }
            else { MessageBox.Show("la contraseña ingresada no es valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            miconectar.Close();
            comboBox1.SelectedItem = null;
        }

        private void refrescarComboBox() {
            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            

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
           
            miconectar.Close();
            comboBox1.SelectedItem = null;

        }
        private string getDatoUnico(string consulta) {
            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;


            miconectar.Close();
            miconectar.Open();
            micodigo.Connection = miconectar;
            micodigo.CommandText = (consulta);
            //MessageBox.Show(micodigo.CommandText);
            MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
            DataTable dt = new DataTable();
            da1.Fill(dt);

            miconectar.Close();
            return dt.Rows[0].ItemArray[0].ToString();

            

        }
    }
}

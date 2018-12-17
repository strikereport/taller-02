using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Taller_02_base_de_datos.Clases;

namespace Taller_02_base_de_datos
{
    public partial class Agregar01 : Form
    {
        public Agregar01()
        {
            InitializeComponent();
        }

        public static implicit operator Agregar01(Eliminar v)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //funcion para validar el rut
        public bool validarRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "") {
                MessageBox.Show("seleccione un estudiante y un curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Alumno_Curso Alumno = new Alumno_Curso();
            Alumno.rut_estudiante = comboBox1.SelectedValue.ToString();
            Alumno.id_curso = Convert.ToInt32(comboBox2.SelectedValue.ToString());
            Alumno.fecha_creacion = DateTime.Now;

            int resultado = Alumno_CursoDAL.Agregar(Alumno);

            if(resultado > 0)
            {
                MessageBox.Show("Alumno ingresado correctamente");
                
                comboBox2.Text = "";
                comboBox2.ResetText();
                string consulta = "select id_curso , nombre_curso from curso where id_curso not in (select id_curso from estudiante_curso where rut_estudiante= '" + comboBox1.SelectedValue.ToString() + "') order by nombre_curso;";
                string cboxValues = "id_curso";
                string display = "nombre_curso";
                BdComun.llenarCombobox(comboBox2, consulta, cboxValues, display);

            }
            else
            {
                MessageBox.Show("No se pudo guardar los datos");

            }
        }

        private void Agregar01_Load(object sender, EventArgs e)
        {
            string consulta = "SELECT rut_estudiante, nombre_estudiante FROM estudiante  order by nombre_estudiante;";
            string cboxValues = "rut_estudiante";
            string display = "nombre_estudiante";
            

            BdComun.llenarCombobox(comboBox1,consulta,cboxValues,display);
            //comboBox1.SelectedItem = null;
            //comboBox2.SelectedItem = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consulta = "select id_curso , nombre_curso from curso where id_curso not in (select id_curso from estudiante_curso where rut_estudiante= '"+comboBox1.SelectedValue.ToString()+ "') order by nombre_curso;";
            string cboxValues = "id_curso";
            string display = "nombre_curso";
            BdComun.llenarCombobox(comboBox2, consulta, cboxValues, display);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

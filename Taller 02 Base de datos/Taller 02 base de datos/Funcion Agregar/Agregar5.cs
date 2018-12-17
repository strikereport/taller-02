using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taller_02_base_de_datos.Clases;

namespace Taller_02_base_de_datos.Funcion_Agregar
{
    public partial class Agregar5 : Form
    {
        public Agregar5()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //variable local
        string rut = "10";
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "" || textBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("seleccione un curso y su codigo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
           NuevoCurso Curso = new NuevoCurso();
           Curso.id_curso = Convert.ToInt32(textBox2.Text); 
           Curso.nombre_curso = textBox2.Text;
           Curso.creditos = Convert.ToInt32(textBox3.Text); 
           Curso.profesorrut = rut;
           Curso.bono = Convert.ToInt32(textBox4.Text);

           int resultado = NuevoCursoDAL.Agregar(Curso);
            if (resultado > 0)
            {
                MessageBox.Show("Curso ingresado correctamente");
            }else
            {
                MessageBox.Show("No se pudo guardar los datos");
            }

        }
    }
}

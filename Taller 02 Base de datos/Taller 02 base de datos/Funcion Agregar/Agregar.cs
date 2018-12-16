using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Taller_02_base_de_datos.Funcion_Agregar;

namespace Taller_02_base_de_datos
{
    public partial class Agregar : Form
    {
        public Agregar()
        {
            InitializeComponent();
        }
        //para cerrar la forma de agregar
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Agregar01 AgregarAlumnoCurso = new Agregar01();
            AgregarAlumnoCurso.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Agregar2 ModificarCurso = new Agregar2();
            ModificarCurso.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Agregar5 Nuevocurso = new Agregar5();
            Nuevocurso.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Agregar3 Modificarbono = new Agregar3();
            Modificarbono.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Agregar4 NuevoEstudiante = new Agregar4();
            NuevoEstudiante.ShowDialog();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Agregar6 ActualizarDireccion = new Agregar6();
            ActualizarDireccion.ShowDialog();

        }
    }
}

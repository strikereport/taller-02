using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller_02_base_de_datos
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }
        //para ir al la pantalla de agregar
        private void button1_Click(object sender, EventArgs e)
        {
            Agregar ParaAgregar = new Agregar();
            ParaAgregar.ShowDialog();
        }

        // para ir a la pantalla de eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            Eliminar ParaEliminar = new Eliminar();
            ParaEliminar.ShowDialog();
        }
        // para ir a la pantalla de busqueda
        private void button3_Click(object sender, EventArgs e)
        {
            Busqueda ParaBusqueda = new Busqueda();
            ParaBusqueda.ShowDialog();
        }
        // para la pantalla de consulta y estadisticas
        private void button4_Click(object sender, EventArgs e)
        {
            Consultas ParaConsultas = new Consultas();
            ParaConsultas.ShowDialog();
        }
    }
}

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
            // escondemos la pantalla
            this.Hide();
            //cargamos la siguiente pantalla
            Agregar ParaAgregar = new Agregar();
            ParaAgregar.ShowDialog();
            //al terminar se carga denuevo la pantalla
            this.Show();
        }

        // para ir a la pantalla de eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            // escondemos la pantalla
            this.Hide();
            //cargamos la siguiente pantalla
            Eliminar ParaEliminar = new Eliminar();
            ParaEliminar.ShowDialog();
            //al terminar se carga denuevo la pantalla
            this.Show();
        }
        // para ir a la pantalla de busqueda
        private void button3_Click(object sender, EventArgs e)
        {
            // escondemos la pantalla
            this.Hide();
            //cargamos la siguiente pantalla
            Busqueda ParaBusqueda = new Busqueda();
            ParaBusqueda.ShowDialog();
            //al terminar se carga denuevo la pantalla
            this.Show();
        }
        // para la pantalla de consulta y estadisticas
        private void button4_Click(object sender, EventArgs e)
        {
            // escondemos la pantalla
            this.Hide();
            //cargamos la siguiente pantalla
            Consultas ParaConsultas = new Consultas();
            ParaConsultas.ShowDialog();
            //al terminar se carga denuevo la pantalla
            this.Show();
        }
        
    }
}

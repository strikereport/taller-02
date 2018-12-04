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
    }
}

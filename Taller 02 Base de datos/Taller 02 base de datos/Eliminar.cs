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
    public partial class Eliminar : Form
    {
        public Eliminar()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //cerramos el menu de eliminar
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RF2 orf2 = new RF2();
            orf2.ShowDialog();
            this.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RF3 orf3 = new RF3();
            orf3.ShowDialog();
            this.Show();
        }
    }
}

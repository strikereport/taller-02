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
    public partial class Busqueda : Form
    {
        public Busqueda()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RF5 orf5 = new RF5();
            orf5.ShowDialog();
            this.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            RF16 orf16 = new RF16();
            orf16.ShowDialog();
            this.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            RF_6_7_10 orf6 = new RF_6_7_10();
            orf6.ShowDialog();
            this.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            RF_9_19 orf9 = new RF_9_19();
            orf9.ShowDialog();
            this.Show();
        }
    }
}

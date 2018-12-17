using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller_02_base_de_datos.Funcion_Agregar
{
    public partial class Agregar3 : Form
    {
        public Agregar3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Agregar3_Load(object sender, EventArgs e)
        {
            string consulta = "select id_curso , nombre_curso from curso  order by nombre_curso;";
            string cboxValues = "id_curso";
            string display = "nombre_curso";

            BdComun.llenarCombobox(comboBox1, consulta, cboxValues, display);
            consulta = "SELECT bono FROM curso where id_curso = '"+comboBox1.SelectedValue.ToString()+"';";
            string bono = BdComun.getDatoUnico(consulta);
            label2.Text = "Bono Actual\n "+bono;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consulta = "SELECT bono FROM curso where id_curso = '" + comboBox1.SelectedValue.ToString() + "';";
            string bono = BdComun.getDatoUnico(consulta);
            label2.Text = "Bono Actual\n " + bono;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(textBox2.Text, "[0-9]+") || comboBox1.Text=="") {
                MessageBox.Show("el bono ingresado es invalido o no se ha seleccinado un curso", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string comando = "UPDATE curso SET bono ='"+textBox2.Text+"' WHERE id_curso ='"+comboBox1.SelectedValue.ToString()+"';";

            int resultado = BdComun.ejecutarConsulta(comando);

            if (resultado > 0)
            {
                MessageBox.Show("bono modificado correctamente");

                string consulta = "SELECT bono FROM curso where id_curso = '" + comboBox1.SelectedValue.ToString() + "';";
                string bono = BdComun.getDatoUnico(consulta);
                label2.Text = "Bono Actual\n " + bono;

            }
            else
            {
                MessageBox.Show("No se pudo modificar los datos");

            }

        }
    }
}

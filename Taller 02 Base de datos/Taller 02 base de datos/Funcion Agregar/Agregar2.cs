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
    public partial class Agregar2 : Form
    {
        public Agregar2()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Agregar2_Load(object sender, EventArgs e)
        {
            string consulta = "select id_curso , nombre_curso from curso  order by nombre_curso;";
            string cboxValues = "id_curso";
            string display = "nombre_curso";
            
            BdComun.llenarCombobox(comboBox1,consulta,cboxValues,display);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consulta = "select rut, nombre_profesor from profesor where rut <> (select curso.profesorrut from curso where id_curso ='" + comboBox1.SelectedValue.ToString() + "' )order by nombre_profesor ;";
            string valores = "rut";
            string display = "nombre_profesor";
            BdComun.llenarCombobox(comboBox2, consulta, valores, display);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "" || comboBox2.Text == "") {
                MessageBox.Show("seleccione un curso y un profesor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string comando = "UPDATE curso SET profesorrut ='" + comboBox2.SelectedValue.ToString() + "' WHERE id_curso ='" + comboBox1.SelectedValue.ToString() + "' ;";

            int resultado = BdComun.ejecutarConsulta(comando);

            if (resultado > 0)
            {
                MessageBox.Show("profesor modificado correctamente");

                comboBox2.SelectedItem = null;
                comboBox2.ResetText();
                string consulta = "select rut, nombre_profesor from profesor where rut <> (select curso.profesorrut from curso where id_curso ='" + comboBox1.SelectedValue.ToString() + "' )order by nombre_profesor ;";
                string valores = "rut";
                string display = "nombre_profesor";
                BdComun.llenarCombobox(comboBox2, consulta, valores, display);

            }
            else
            {
                MessageBox.Show("No se pudo modificar los datos");

            }

        }
    }
}

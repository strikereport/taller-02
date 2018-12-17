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
    public partial class RF2popUp : Form
    {
        private string rut, id,nombre,curso;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
           
            miconectar.Open();
            micodigo.Connection = miconectar;
            micodigo.CommandText = "DELETE FROM estudiante_curso WHERE rut_estudiante='"+this.rut+"' and id_curso = "+this.id+" ;";
            int i = 0;
            i = micodigo.ExecuteNonQuery();
            miconectar.Close();
            this.Close();
        }

        public RF2popUp(string rut,string nombre, string id,string curso)
        {
            this.rut = rut;
            this.id = id;
            this.nombre = nombre;
            this.curso = curso;
            InitializeComponent();
        }

        private void RF2popUp_Load(object sender, EventArgs e)
        {
            label1.Text = "desea eliminar a " + nombre + " del curso " + curso + " ?";
        }
    }
}

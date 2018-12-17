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
    public partial class RF_14_15 : Form
    {
        public RF_14_15()
        {
            InitializeComponent();
        }

        private void RF_14_15_Load(object sender, EventArgs e)
        {
          

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Close();
            miconectar.Open();
            micodigo.Connection = miconectar;

           // micodigo.CommandText = ("select count(*) as inscritos from estudiante_curso where estudiante_curso.id_curso = " + comboBox1.SelectedValue + " and cast(estudiante_curso.fecha_creacion as time) >= '00:00:00' and  cast(estudiante_curso.fecha_creacion as time) <= '08:00:00';");

           
            if (comboBox1.SelectedIndex == 0)
            {
                micodigo.CommandText = "select rut_estudiante as RUT, nombre_estudiante as Nombre,TIMESTAMPDIFF(YEAR,fecha_nacimiento,CURDATE()) as edad  from estudiante where (TIMESTAMPDIFF(YEAR,fecha_nacimiento,CURDATE()))<18 ;";
            }
            else {
                micodigo.CommandText = "select rut_estudiante as RUT, nombre_estudiante as Nombre,TIMESTAMPDIFF(YEAR,fecha_nacimiento,CURDATE()) as edad  from estudiante where (TIMESTAMPDIFF(YEAR,fecha_nacimiento,CURDATE())) > 30 ;";
            }
            MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
            DataTable dt = new DataTable();
            da1.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.ReadOnly = true;
            miconectar.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
           // Consultas consultas = new Consultas();
            //consultas.ShowDialog();
            this.Close();
        }
    }
}

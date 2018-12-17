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
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            RF_14_15 orF_14_15 = new RF_14_15();
            orF_14_15.ShowDialog();
            this.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string mensaje = "";
               string[] totales_e_c_p_h_a = {"Total de estudiantes: ","Total de cursos: ","Total de profesores: ","Total de inscripciones en hrs. de oficina: ", "Cantidad de ingresos antes del año 2000: ", "Curso con mas estudiantes: ","Curso con menos estudiantes: "};
            string[] consultas = new string[7];
            consultas[0] = "select count(*) from estudiante;";
            consultas[1] = "select count(*) from curso;";
            consultas[2] = "select count(*) from profesor;";
            consultas[3] = "select count(*) as inscritos from estudiante_curso where  (cast(estudiante_curso.fecha_creacion as time) >= '14:30:00' and  cast(estudiante_curso.fecha_creacion as time) <= '18:30:00') or (cast(estudiante_curso.fecha_creacion as time) >= '08:00:00' and  cast(estudiante_curso.fecha_creacion as time) <= '12:30:00');";
            consultas[4] = "select count(*) from estudiante where fecha_ingreso < '2000-01-01';";
            consultas[5] = ("select vista. nombre_curso from(SELECT nombre_curso, count(*) as cantidad FROM estudiante_curso,curso where curso.id_curso =estudiante_curso.id_curso group by curso.id_curso order by cantidad desc limit 1) as vista ;");
            consultas[6] = ("select vista. nombre_curso from(SELECT nombre_curso, count(*) as cantidad FROM estudiante_curso,curso where curso.id_curso =estudiante_curso.id_curso group by curso.id_curso order by cantidad asc limit 1) as vista ;");
            for (int i = 0; i < 5; i++) {


                MySqlCommand micodigo = new MySqlCommand();
                MySqlConnection miconectar = Program.estamosconectados;
                miconectar.Open();
                micodigo.Connection = miconectar;
                micodigo.CommandText = consultas[i];
                //MessageBox.Show(micodigo.CommandText);
                MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
                DataTable dt = new DataTable();
                da1.Fill(dt);
                totales_e_c_p_h_a[i] = totales_e_c_p_h_a[i] + dt.Rows[0].ItemArray[0].ToString() + "\n";
                mensaje += totales_e_c_p_h_a[i];
                miconectar.Close();

            }

             //totales_e_c_p_h_a[0] + totales_e_c_p_h_a[1] + totales_e_c_p_h_a[2] + totales_e_c_p_h_a[3] + totales_e_c_p_h_a[4];

            // select nombre_curso top from curso where exists (select vista.id_curso, max(vista.cantidad) from (select id_curso, count(*) as cantidad from estudiante_curso group by id_curso) as vista where curso.id_curso = vista.id_curso ) limit 1;
            
            {
                MySqlCommand micodigo = new MySqlCommand();
                MySqlConnection miconectar = Program.estamosconectados;
                miconectar.Open();
                micodigo.Connection = miconectar;

                micodigo.CommandText = ("select nombre_curso top from curso where exists (select vista.id_curso, max(vista.cantidad) from (select id_curso, count(*) as cantidad from estudiante_curso group by id_curso) as vista where curso.id_curso = vista.id_curso ) limit 1;");
                MySqlDataReader leer = micodigo.ExecuteReader();
                if (leer.Read())
                {
                    for (int i = 5; i < 7; i++)
                    {
                        miconectar.Close();
                        miconectar.Open();
                        micodigo.Connection = miconectar;
                        micodigo.CommandText = consultas[i];
                        MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
                        DataTable dt = new DataTable();
                        da1.Fill(dt);
                        mensaje += totales_e_c_p_h_a[i] + dt.Rows[0].ItemArray[0].ToString() + "\n";
                    }   

                }
                else {
                    mensaje += totales_e_c_p_h_a[5] + "no hay cursos con estudiantes\n";
                    mensaje += totales_e_c_p_h_a[6] + "no hay cursos con estudiantes";
                }
                miconectar.Close();

            }
            MessageBox.Show(mensaje,"Estadisticas");

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using System.Configuration;

namespace Taller_02_base_de_datos
{
    public class BdComun
    {
        public static MySqlConnection Obtener_Conexion()
        {
            //nos conectamos a la base de datos
            // string base_de_datos = "server=127.0.0.1; database=sis_taller; Uid=root; pwd=admin;";
            // MySqlConnection Digi = new MySqlConnection(base_de_datos);
            MySqlConnection Digi = Program.estamosconectados;
            //abrimos la base de datos
            Digi.Open();
            return Digi;
        }

        internal static void llenarCombobox(ComboBox comboBox1, string consulta, string cboxValues, string display)
        {
            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Close();
            miconectar.Open();
            micodigo.Connection = miconectar;

            micodigo.CommandText = consulta;
            MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
                DataTable dt = new DataTable();
                da1.Fill(dt);

                comboBox1.ValueMember = cboxValues;
                comboBox1.DisplayMember = display;
                comboBox1.DataSource = dt;
           
            miconectar.Close();
            
        }
        public static int ejecutarConsulta(string consulta) {
            int i = 0;
            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;
            miconectar.Close();
            miconectar.Open();
            micodigo.Connection = miconectar;

            micodigo.CommandText = consulta;
            i = micodigo.ExecuteNonQuery();

            miconectar.Close();
            return i;
        }

        public static string getDatoUnico(string consulta)
        {
            MySqlCommand micodigo = new MySqlCommand();
            MySqlConnection miconectar = Program.estamosconectados;


            miconectar.Close();
            miconectar.Open();
            micodigo.Connection = miconectar;
            micodigo.CommandText = (consulta);
            //MessageBox.Show(micodigo.CommandText);
            MySqlDataAdapter da1 = new MySqlDataAdapter(micodigo);
            DataTable dt = new DataTable();
            da1.Fill(dt);

            miconectar.Close();
            return dt.Rows[0].ItemArray[0].ToString();



        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Taller_02_base_de_datos
{
    public class BdComun
    {
        public static MySqlConnection conectar = new MySqlConnection("server=127.0.0.1; database=sis_taller; Uid=root; pwd=admin;");
        // para probar que la conexion funcione
        public static void ProbarConexion()
        {
            try
            {
                conectar.Open();
                MessageBox.Show("Conectado");
                conectar.Close();
            }
            catch(Exception r)
            {
                MessageBox.Show(r.Message);
            }
            finally { conectar.Close(); }
        }

    
    }
}

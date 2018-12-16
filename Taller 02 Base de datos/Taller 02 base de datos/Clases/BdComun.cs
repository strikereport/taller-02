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
            string base_de_datos = "server=127.0.0.1; database=sis_taller; Uid=root; pwd=admin;";
            MySqlConnection Digi = new MySqlConnection(base_de_datos);
            //abrimos la base de datos
            Digi.Open();
            return Digi;
        }

    }
}

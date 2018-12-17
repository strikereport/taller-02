using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Taller_02_base_de_datos
{
    static class Program
    {

        public static MySqlConnection estamosconectados;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        [STAThread]


        static void Main()
        {
            estamosconectados = new MySqlConnection("server=localhost; database= mitaller2;Uid=root;pwd=092947411;SSL Mode=None;");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Inicio());
        }
    }
}

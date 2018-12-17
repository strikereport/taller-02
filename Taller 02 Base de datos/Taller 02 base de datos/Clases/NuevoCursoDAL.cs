using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_02_base_de_datos.Clases
{
    class NuevoCursoDAL
    {
        public static int Agregar(NuevoCurso pCurso)
        {
            int retorno = 0;
            using (MySqlConnection Conectar = BdComun.Obtener_Conexion())
            {
                MySqlCommand Comando = new MySqlCommand(String.Format("insert into curso (id_curso,nombre_curso,creditos,profesorrut,bono) values('{0}' , '{1}' , '{2}', '{3}', '{4}' )", pCurso.id_curso, pCurso.nombre_curso, pCurso.creditos, pCurso.profesorrut, pCurso.bono), Conectar);
                retorno = Comando.ExecuteNonQuery();
            }
            return retorno;

        }
    }
}

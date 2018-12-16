using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace Taller_02_base_de_datos.Clases
{
    public class Alumno_CursoDAL
    {
        public static int Agregar(Alumno_Curso pAlumno)
        {
            int retorno = 0;
            using(MySqlConnection Conectar = BdComun.Obtener_Conexion())
            {
                MySqlCommand Comando = new MySqlCommand(String.Format("insert into estudiante_curso (rut_estudiante,id_curso,fecha_creacion) values('{0}' , '{1}' , '2017/10/24 16:35:03' )", pAlumno.rut_estudiante, pAlumno.id_curso, pAlumno.fecha_creacion),Conectar);
                retorno = Comando.ExecuteNonQuery();
            }
            return retorno;
        }
    }
}

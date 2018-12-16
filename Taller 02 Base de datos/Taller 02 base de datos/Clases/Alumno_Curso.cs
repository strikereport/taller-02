using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_02_base_de_datos.Clases
{
    public class Alumno_Curso
    {
        public string rut_estudiante { get; set; }
        public int id_curso { get; set; }
        public DateTime fecha_creacion { get; set; }

        // creamos un constructor vacio
        public Alumno_Curso() { }

        //creamos un constructor con los 2 datos que nos piden

        public Alumno_Curso(string prut_estudiante, int pid_curso, DateTime pfecha_creacion)
        {
            this.rut_estudiante = prut_estudiante;
            this.id_curso = pid_curso;
            this.fecha_creacion = pfecha_creacion;
        }

    }

}

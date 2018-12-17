using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_02_base_de_datos.Clases
{
    class NuevoCurso
    {
        public int id_curso { get; set; }
        public string nombre_curso { get; set; }
        public int creditos { get; set; }
        public string profesorrut { get; set; }
        public int bono { get; set; }

        //creamos el construcotr vacio

        public NuevoCurso() { }

        //creamos el contructor con los atributos

        public NuevoCurso(int pid_curso, string pnombre_curso, int pcreditos, string pprofesorrut, int pbono) {

            this.id_curso = pid_curso;
            this.nombre_curso = pnombre_curso;
            this.creditos = pcreditos;
            this.profesorrut = pprofesorrut;
            this.bono = pbono;

        }



    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taller_02_base_de_datos
{
    public partial class Agregar01 : Form
    {
        public Agregar01()
        {
            InitializeComponent();
        }

        public static implicit operator Agregar01(Eliminar v)
        {
            throw new NotImplementedException();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //funcion para validar el rut
        public bool validarRut(string rut)
        {
            bool validacion = false;
            try
            {
                rut = rut.ToUpper();
                rut = rut.Replace(".", "");
                rut = rut.Replace("-", "");
                int rutAux = int.Parse(rut.Substring(0, rut.Length - 1));

                char dv = char.Parse(rut.Substring(rut.Length - 1, 1));

                int m = 0, s = 1;
                for (; rutAux != 0; rutAux /= 10)
                {
                    s = (s + rutAux % 10 * (9 - m++ % 6)) % 11;
                }
                if (dv == (char)(s != 0 ? s + 47 : 75))
                {
                    validacion = true;
                }
            }
            catch (Exception)
            {
            }
            return validacion;
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //validamos que sea un rut valido
            string rut = textBox1.Text;
            // ahora verificamos que sea rut valido
            bool respuesta = validarRut(rut);
            //verificamos que sea correcto el rut
            if (respuesta == false)
            {
                //si no es valido mandamos un aviso
                MessageBox.Show(" Rut no valido, Ingrese nuevamente");
                //borramos lo del texbox
                textBox1.Clear();
            }
            // validamos que sea un alumno 
            BdComun.ProbarConexion();

        }
    }
}

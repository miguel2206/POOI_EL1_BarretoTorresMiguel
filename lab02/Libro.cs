using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class Libro
    {
        /*nombre, fecha de registro, género
(policial, novela, ciencia ficción) y nombre de autor. */

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string FechaRegistro { get; set; }
        public string Genero { get; set; }
        public string Nombre_autor { get; set; }


        public String GenerarCod(int numero)
        {

            string correlativo = "LIB-";
            string codCorrelativo = "";
            if (numero < 10) 
            {
                codCorrelativo = correlativo + "0" + "0" + numero.ToString();
            }else if (numero < 100)
            {
                codCorrelativo = correlativo + "0" + numero.ToString();
            }
            else
            {
                codCorrelativo = correlativo + numero;
            }
            

            return codCorrelativo;
        }
    }
    
    


    
    
}

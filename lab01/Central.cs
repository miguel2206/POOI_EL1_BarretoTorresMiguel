using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{
    public class Central
    {
        // Definir atributos
        public string Modelo { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public string Sucursal { get; set; }

        public Central()
        {

        }

        // Método
        public virtual double CalcularSubTotal()
        {
            return Precio * Cantidad;
        }

        //Descuento
        public virtual double Descuento()
        {
            double descuento = 0.0;
            if (Cantidad > 10) descuento = CalcularSubTotal() * 10 / 100;
            return descuento;
        }
    }
}

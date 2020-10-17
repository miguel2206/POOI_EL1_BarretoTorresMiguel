using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{
    public class Cusco:Central
    {
        public double CalcularPrecio()
        {
            switch (Sucursal)
            {
                case "Cusco":
                    switch (Modelo)
                    {
                        case "Motorola One Macro":
                            Precio = 750.00;
                            break;
                        case "Samsung Galazy A30S":
                            Precio = 930.00;
                            break;
                        case "Huawei P40 Lite Negro":
                            Precio = 1050.00;
                            break;
                    }
                    break;
            }
            return Precio;
        }

        public override double CalcularSubTotal()
        {
            return base.CalcularSubTotal();
        }

        public override double Descuento()
        {
            switch (Sucursal)
            {
                case "Cusco":
                    if (CalcularSubTotal() <= 10000.00) return CalcularSubTotal() * 0.03;
                    else return CalcularSubTotal() * 0.10;
                    break;
            }
            return base.Descuento();
        }

        public double CalcularTotal()   
        {
            return CalcularSubTotal() - Descuento();
        }
    }
}

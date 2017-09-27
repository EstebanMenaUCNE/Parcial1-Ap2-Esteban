using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial1_Ap2_Esteban
{
    public class Utilidad
    {
        public static int ToInt(string texto)
        {
            int numero = 0;
            int.TryParse(texto, out numero);
            return numero;
        }

        public static double ToDouble(string texto)
        {
            double numero = 0;
            double.TryParse(texto, out numero);
            return numero;
        }

        public static DateTime ToDateTime(string texto)
        {
            DateTime fecha = new DateTime(1900, 1, 1);
            DateTime.TryParse(texto, out fecha);
            return fecha;
        }
    }
}
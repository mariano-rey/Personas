using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_Personas
{
    public class Utilidades
    {
        public static bool esNumerico(string texto)
        {
            double num;
            return double.TryParse(texto.Trim(), out num);
        }
    }
}

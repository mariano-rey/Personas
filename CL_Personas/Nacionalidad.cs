using CAD_Personas.DS_PersonasTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD_Personas
{
    public class Nacionalidad
    {
        private static NacionalidadesTableAdapter adapter = new NacionalidadesTableAdapter();

        public static DS_Personas.NacionalidadesDataTable GetNacionalidad(string Descripcion)
        {
            return adapter.GetNacionalidad(Descripcion);
        }

        public static bool ExisteNacionalidad(string Descripcion)
        {
            return adapter.ExisteNacionalidad(Descripcion) == 1;
        }

        public static bool ExisteIdNacionalidad(int idNacionalidad)
        {
            return adapter.ExisteIdNacionalidad(idNacionalidad) == 1;
        }

        public static string NuevaNacionalidad(string Descripcion)
        {
            int aux = adapter.Insert(Descripcion);
            if (aux == 0) return "No se pudo guardar la nacionalidad";
            else return "Nacionalidad guardada correctamente";
        }

        public static string ModificarNacionalidad(string Descripcion, int idNacionalidad)
        {
            int aux = adapter.ModificarNacionalidad(Descripcion, idNacionalidad);
            if (aux == 0) return "No se pudo modificar la nacionalidad";
            else return "Nacionalidad modificada correctamente";
        }

        public static string BorrarNacionalidad(int idNacionalidad)
        {
            int aux = adapter.BorrarNacionalidad(idNacionalidad);
            if (aux == 0) return "No se pudo borrar la nacionalidad";
            else return "Nacionalidad borrada correctamente";
        }
    }
}

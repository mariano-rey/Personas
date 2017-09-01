using CAD_Personas.DS_PersonasTableAdapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAD_Personas
{
    public class Persona
    {
        private static PersonasTableAdapter adapter = new PersonasTableAdapter();

        public static DS_Personas.PersonasDataTable GetPersona(int DNI)
        {
            return adapter.GetPersona(DNI);
        }

        public static bool ExistePersona(int DNI)
        {
            return adapter.ExistePersona(DNI) == 1;
        }

        public static bool ExistePersonaPorNacionalidad(int idNacionalidad)
        {
            return adapter.ExistePersonaPorNacionalidad(idNacionalidad) == 1;
        }

        public static bool ExisteNombre(string Nombres)
        {
            return adapter.ExisteNombre(Nombres) == 1;
        }
        public static bool ExisteApellido(string Apellido)
        {
            return adapter.ExisteApellido(Apellido) == 1;
        }

        public static string NuevaPersona(int DNI, string Nombres, string Apellidos, DateTime FechaNacimiento, int idNacionalidad)
        {
            int aux = adapter.Insert(DNI, Nombres, Apellidos, FechaNacimiento, idNacionalidad);
            if (aux == 0) return "No se pudo insertar el registro";
            else return "Registro guardado correctamente";
        }
        public static string ModificarPersona(string Nombres, string Apellidos, DateTime FechaNacimiento, int idNacionalidad, int DNI)
        {
            int aux = adapter.ModificarPersona(Nombres, Apellidos, FechaNacimiento, idNacionalidad, DNI);
            if (aux == 0) return "No se pudo modificar el registro";
            else return "Registro modificado correctamente";
        }

        public static string BorrarPersona(int DNI)
        {
            int aux = adapter.BorrarPersona(DNI);
            if (aux == 0) return "No se pudo borrar el registro";
            else return "Registro borrado correctamente";
        }
    }
}

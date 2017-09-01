using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABM_Personas.Vistas
{
    public partial class Personas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // Consultar si existe esa Persona
        protected void consultar_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                mensaje.Text = "Ingrese DNI";
                txtDNI.Focus();
                return;
            }

            int x = 0;
            Int32.TryParse(txtDNI.Text, out x);

            if (!CAD_Personas.Persona.ExistePersona(x))
            {
                mensaje.Text = "No existe la Persona";
                txtDNI.Focus();
                return;
            }

            CAD_Personas.DS_Personas.PersonasDataTable persona = CAD_Personas.Persona.GetPersona(x);
            foreach (DataRow row in persona)
            {
                txtNombres.Text = row["Nombres"].ToString();
                txtApellidos.Text = row["Apellidos"].ToString();
                txtNacionalidad.Text = row["idNacionalidad"].ToString();
                calendarioNacimiento.SelectedDate = Convert.ToDateTime(row["FechaNacimiento"]);

                mensaje.Text = "Datos de: " + row["Nombres"].ToString() + " " + row["Apellidos"].ToString();
            }
        }

        // Agregar Persona
        protected void agregarPersona_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                mensaje.Text = "Ingrese DNI";
                txtDNI.Focus();
                return;
            }

            if (!CL_Personas.Utilidades.esNumerico(txtDNI.Text))
            {
                mensaje.Text = "Ingrese un valor numérico";
                txtDNI.Focus();
                return;
            }

            if (Convert.ToInt32(txtDNI.Text) <= 0)
            {
                mensaje.Text = "El DNI tiene que ser mayor a 0 (cero)";
                txtDNI.Focus();
                return;
            }

            if (txtNombres.Text == "")
            {
                mensaje.Text = "Ingrese Nombres";
                txtNombres.Focus();
                return;
            }

            if (txtApellidos.Text == "")
            {
                mensaje.Text = "Ingrese Apellidos";
                txtApellidos.Focus();
                return;
            }

            if (txtNacionalidad.Text == "")
            {
                mensaje.Text = "Ingrese Nacionalidad";
                txtNacionalidad.Focus();
                return;
            }

            int x = 0;
            Int32.TryParse(txtDNI.Text, out x);

            if (CAD_Personas.Persona.ExistePersona(x))
            {
                mensaje.Text = "Ya existe una persona con ese DNI";
                txtDNI.Focus();
                return;
            }

            if (CAD_Personas.Persona.ExisteNombre(txtNombres.Text) && CAD_Personas.Persona.ExisteApellido(txtApellidos.Text))
            {
                mensaje.Text = "Ya existe una persona con ese nombre";
                txtNombres.Focus();
                return;
            }

            if (CL_Personas.Utilidades.esNumerico(txtNacionalidad.Text))
            {
                mensaje.Text = "Caracteres inválidos";
                txtDNI.Focus();
                return;
            }

            int id = 0;

            if (CAD_Personas.Nacionalidad.ExisteNacionalidad(txtNacionalidad.Text))
            {
                CAD_Personas.DS_Personas.NacionalidadesDataTable nacionalidad = CAD_Personas.Nacionalidad.GetNacionalidad(txtNacionalidad.Text);
                foreach (DataRow row in nacionalidad)
                {
                    id = Convert.ToInt32(row["idNacionalidad"]);
                }
            }
            else
            {
                mensajeNacionalidad.Text = CAD_Personas.Nacionalidad.NuevaNacionalidad(txtNacionalidad.Text);

                CAD_Personas.DS_Personas.NacionalidadesDataTable nacionalidad = CAD_Personas.Nacionalidad.GetNacionalidad(txtNacionalidad.Text);
                foreach (DataRow row in nacionalidad)
                {
                    id = Convert.ToInt32(row["idNacionalidad"]);
                }
            }

            mensaje.Text = CAD_Personas.Persona.NuevaPersona(Convert.ToInt32(txtDNI.Text), txtNombres.Text, txtApellidos.Text, calendarioNacimiento.SelectedDate, id);

            txtDNI.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtNacionalidad.Text = "";
            txtDNI.Focus();

            GV_Personas.DataBind();
        }

        // Limpiar formulario
        protected void limpiarPersonas_Click(object sender, EventArgs e)
        {
            txtDNI.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtNacionalidad.Text = "";
            txtDNI.Focus();
        }

        // Modificar Persona
        protected void modificarPersona_Click(object sender, EventArgs e)
        {
            if (txtDNI.Text == "")
            {
                mensaje.Text = "Ingrese DNI";
                txtDNI.Focus();
                return;
            }

            if (!CL_Personas.Utilidades.esNumerico(txtDNI.Text))
            {
                mensaje.Text = "Ingrese un valor numérico";
                txtDNI.Focus();
                return;
            }

            if (Convert.ToInt32(txtDNI.Text) <= 0)
            {
                mensaje.Text = "El DNI tiene que ser mayor a 0 (cero)";
                txtDNI.Focus();
                return;
            }

            if (txtNombres.Text == "")
            {
                mensaje.Text = "Ingrese Nombres";
                txtNombres.Focus();
                return;
            }

            if (txtApellidos.Text == "")
            {
                mensaje.Text = "Ingrese Apellidos";
                txtApellidos.Focus();
                return;
            }

            if (txtNacionalidad.Text == "")
            {
                mensaje.Text = "Ingrese Nacionalidad";
                txtNacionalidad.Focus();
                return;
            }

            if (!CAD_Personas.Persona.ExistePersona(Convert.ToInt32(txtDNI.Text)))
            {
                mensaje.Text = "No existe una persona con ese DNI";
                txtDNI.Focus();
                return;
            }

            int id = 0;

            if (CAD_Personas.Nacionalidad.ExisteNacionalidad(txtNacionalidad.Text))
            {
                CAD_Personas.DS_Personas.NacionalidadesDataTable nacionalidad = CAD_Personas.Nacionalidad.GetNacionalidad(txtNacionalidad.Text);
                foreach (DataRow row in nacionalidad)
                {
                    id = Convert.ToInt32(row["idNacionalidad"]);
                }
            }
            else
            {
                mensajeNacionalidad.Text = CAD_Personas.Nacionalidad.NuevaNacionalidad(txtNacionalidad.Text);

                CAD_Personas.DS_Personas.NacionalidadesDataTable nacionalidad = CAD_Personas.Nacionalidad.GetNacionalidad(txtNacionalidad.Text);
                foreach (DataRow row in nacionalidad)
                {
                    id = Convert.ToInt32(row["idNacionalidad"]);
                }
            }

            mensaje.Text = CAD_Personas.Persona.ModificarPersona(txtNombres.Text, txtApellidos.Text, calendarioNacimiento.SelectedDate, id, Convert.ToInt32(txtDNI.Text));

            txtDNI.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtNacionalidad.Text = "";
            txtDNI.Focus();

            GV_Personas.DataBind();
        }

        // Borrar Persona
        protected void borrarPersona_Click(object sender, EventArgs e)
        {
            if (!CAD_Personas.Persona.ExistePersona(Convert.ToInt32(txtDNI.Text)))
            {
                mensaje.Text = "No existe una persona con ese DNI";
                txtDNI.Focus();
                return;
            }

            if (txtDNI.Text == "")
            {
                mensaje.Text = "Ingrese DNI";
                txtDNI.Focus();
                return;
            }

            if (!CL_Personas.Utilidades.esNumerico(txtDNI.Text))
            {
                mensaje.Text = "Ingrese un valor numérico";
                txtDNI.Focus();
                return;
            }

            if (Convert.ToInt32(txtDNI.Text) <= 0)
            {
                mensaje.Text = "El DNI tiene que ser mayor a 0 (cero)";
                txtDNI.Focus();
                return;
            }

            mensaje.Text = CAD_Personas.Persona.BorrarPersona(Convert.ToInt32(txtDNI.Text));

            txtDNI.Text = "";
            txtNombres.Text = "";
            txtApellidos.Text = "";
            txtNacionalidad.Text = "";
            txtDNI.Focus();

            GV_Personas.DataBind();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ABM_Personas.Vistas
{
    public partial class Nacionalidades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // Consultar Nacionalidad
        protected void consultar_Click(object sender, EventArgs e)
        {
            if (txtNacionalidad.Text == "")
            {
                mensajeNacionalidad.Text = "Ingrese descripción";
                txtNacionalidad.Focus();
                return;
            }

            if (!CAD_Personas.Nacionalidad.ExisteNacionalidad(txtNacionalidad.Text))
            {
                mensajeNacionalidad.Text = "No existe la nacionalidad";
                txtID.Text = "";
                txtNacionalidad.Focus();
                return;
            }

            CAD_Personas.DS_Personas.NacionalidadesDataTable nacionalidad = CAD_Personas.Nacionalidad.GetNacionalidad(txtNacionalidad.Text);
            foreach (DataRow row in nacionalidad)
            {
                mensajeNacionalidad.Text = "La nacionalidad es: " + row["Descripcion"].ToString();
                txtID.Text = row["idNacionalidad"].ToString();
            }
        }

        // Agregar Nacionalidad
        protected void agregarNacionalidad_Click(object sender, EventArgs e)
        {
            if (txtNacionalidad.Text == "")
            {
                mensajeNacionalidad.Text = "Ingrese Nacionalidad";
                txtNacionalidad.Focus();
                return;
            }

            if (CL_Personas.Utilidades.esNumerico(txtNacionalidad.Text))
            {
                mensajeNacionalidad.Text = "Caracteres inválidos";
                txtNacionalidad.Focus();
                return;
            }

            if (CAD_Personas.Nacionalidad.ExisteNacionalidad(txtNacionalidad.Text))
            {
                mensajeNacionalidad.Text = "Ya existe esa nacionalidad";
                CAD_Personas.DS_Personas.NacionalidadesDataTable nacionalidad = CAD_Personas.Nacionalidad.GetNacionalidad(txtNacionalidad.Text);
                foreach (DataRow row in nacionalidad)
                {
                    txtID.Text = row["idNacionalidad"].ToString();
                }
                txtNacionalidad.Focus();
                return;
            }

            mensajeNacionalidad.Text = CAD_Personas.Nacionalidad.NuevaNacionalidad(txtNacionalidad.Text);

            txtID.Text = "";
            txtNacionalidad.Text = "";

            GV_Nacionalidades.DataBind();
        }

        // Modificar Nacionalidad
        protected void modificarNacionalidad_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                mensajeNacionalidad.Text = "Ingrese ID";
                txtID.Focus();
                return;
            }

            if (!CL_Personas.Utilidades.esNumerico(txtID.Text))
            {
                mensajeNacionalidad.Text = "Caracteres inválidos";
                txtNacionalidad.Focus();
                return;
            }

            mensajeNacionalidad.Text = CAD_Personas.Nacionalidad.ModificarNacionalidad(txtNacionalidad.Text, Convert.ToInt32(txtID.Text));

            txtID.Text = "";
            txtNacionalidad.Text = "";

            GV_Nacionalidades.DataBind();
        }

        // Borrar Nacionalidad
        protected void borrarNacionalidad_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                mensajeNacionalidad.Text = "Ingrese ID";
                txtID.Focus();
                return;
            }

            if (!CL_Personas.Utilidades.esNumerico(txtID.Text))
            {
                mensajeNacionalidad.Text = "Caracteres inválidos";
                txtID.Focus();
                return;
            }

            if (!CAD_Personas.Nacionalidad.ExisteIdNacionalidad(Convert.ToInt32(txtID.Text)))
            {
                mensajeNacionalidad.Text = "No existe la nacionalidad";
                txtID.Focus();
                return;
            }

            if (CAD_Personas.Persona.ExistePersonaPorNacionalidad(Convert.ToInt32(txtID.Text)))
            {
                mensajeNacionalidad.Text = "No se pudo elminiar, una persona tiene esa nacionalidad";
                txtID.Focus();
                return;
            }

            mensajeNacionalidad.Text = CAD_Personas.Nacionalidad.BorrarNacionalidad(Convert.ToInt32(txtID.Text));

            txtID.Text = "";
            txtNacionalidad.Text = "";

            GV_Nacionalidades.DataBind();
        }

        // Limpiar Nacionalidad
        protected void limpiarPersonas_Click(object sender, EventArgs e)
        {
            txtID.Text = "";
            txtNacionalidad.Text = "";
        }
    }
}

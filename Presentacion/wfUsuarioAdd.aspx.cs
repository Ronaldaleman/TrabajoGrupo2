using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfUsuarioAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombres.Text = "";
            txtCedula.Text = "";
            txtClave.Text = "";
            txtLogin.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Validar la cedula del usuario
                Negocio.webServicioNegocio ds = new Negocio.webServicioNegocio();
                string cedula = ds.ValidaCedula(txtCedula.Text.Trim());
                if (cedula == "1")
                    {
                        lblMensaje.Text = "Cedula correcta";
                    }
                else
                    {
                        lblMensaje.Text = "Cedula Incorrecta";
                    }

                Entidad.Usuarios u = new Entidad.Usuarios();
                u.Nombre = txtNombres.Text.Trim();
                u.Login = txtLogin.Text.Trim();
                u.Clave = txtClave.Text.Trim();
                u.Cedula = txtCedula.Text.Trim();
                u.FechaProceso = DateTime.Now;
                Negocio.usuariosNegocio dc = new Negocio.usuariosNegocio();
                
                dc.CrearUsuario(u);
                lblMensaje.Text = "El usuario se ha ingresado correctamente en la BD";
            }
            catch (Exception err)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = err.Message;
            }

        }
    }
}
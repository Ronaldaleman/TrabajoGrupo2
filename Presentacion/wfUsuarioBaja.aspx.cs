using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfUsuarioBaja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRecuperar_Click(object sender, EventArgs e)
        {

            Negocio.usuariosNegocio dc = new Negocio.usuariosNegocio();
            Entidad.Usuarios usuarios = dc.ConsultarUsuario(int.Parse(txtCodigo.Text.Trim()));
            
           
            if (usuarios != null)
            {
                txtLogin.Text = usuarios.Login;
                txtNombre.Text = usuarios.Nombre;
            }
            else
            {
                lblMensaje.Text = "Este usuario no existe... Por favor revise";
            }
         }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = "";
            txtLogin.Text = "";
            txtNombre.Text = "";
            lblMensaje.Text="";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Negocio.usuariosNegocio ds = new Negocio.usuariosNegocio();
            string user = ds.DarBajaUsuario(int.Parse(txtCodigo.Text.Trim()));
            if (user == "1")
            {
                lblMensaje.Text = "El usuario fue actualizado Exitosamente";
            }
            else
            {
                lblMensaje.Text = "Hubo problemas al actualizar el usuario, por favor revise";
            }

    }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfUsuarioActualizar : System.Web.UI.Page
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
                txtClave.Text = usuarios.Clave;
                txtCedula.Text = usuarios.Cedula;
                txtLogin.Enabled = true;
                txtNombre.Enabled = true;
                txtClave.Enabled = true;
                txtCedula.Enabled = true;
                Session["s_AlumnosAc"] = usuarios;
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
            txtCedula.Text = "";
            txtClave.Text = "";
            lblMensaje.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Entidad.Usuarios usuarios = new Entidad.Usuarios();
            usuarios = (Entidad.Usuarios)Session["s_AlumnosAc"];
            usuarios.Login = txtLogin.Text.Trim().ToUpper();
            usuarios.Nombre = txtNombre.Text.Trim().ToUpper();
            usuarios.Clave = txtClave.Text.Trim();
            usuarios.Cedula = txtCedula.Text.Trim().ToUpper();
            Negocio.usuariosNegocio dc = new Negocio.usuariosNegocio();
            Negocio.webServicioNegocio ds = new Negocio.webServicioNegocio();
            string cedula = ds.ValidaCedula(txtCedula.Text.Trim());
            if (cedula == "1")
            {
                dc.ActualizarUsuario(usuarios);
                lblMensaje.Text = "El usuario fue actualizado Exitosamente";
            }
            else
            {
                lblMensaje.Text = "La cédula es incorrecta por favor revisar";
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Session.Remove("s_AlumnosAc");
        }
    }
}
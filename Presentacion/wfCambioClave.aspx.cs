using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfCambioClave : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtEntrar_Click(object sender, EventArgs e)
        {
            Negocio.usuariosNegocio dc = new Negocio.usuariosNegocio();
            try
            {
                int idUsuario = (int)Session["sessionIDUsuario"];
                string password = txtNuevoPassword.Text.ToUpper().Trim(), passwordConfirmado = txtPasswordConf.Text.ToUpper().Trim();
                if (password == passwordConfirmado)
                {
                    string passEncriptado = dc.CreateMD5(passwordConfirmado);
                    Entidad.Usuarios usuario = dc.devolverUsuario(idUsuario);
                    usuario.Clave = passEncriptado;
                    dc.actualizarUsuario(usuario);
                    Response.Redirect("wfLogin.aspx");
                }
                else
                {
                    cvError.IsValid = false;
                    cvError.Text = "Claves no son iguales";
                }
            }
            catch (Exception err)
            {
                cvError.IsValid = false;
                cvError.Text = "Ocurrio un error, favor verifique";
            }
        }
    }
}
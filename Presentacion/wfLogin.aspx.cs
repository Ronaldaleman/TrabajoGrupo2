using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtEntrar_Click(object sender, EventArgs e)
        {//EVALUACION
            string login = txtLogin.Text.ToUpper().Trim(), password = txtPassword.Text.ToUpper().Trim();
            Negocio.CCryptorEngine dcE = new Negocio.CCryptorEngine();

            int existeUsuario = 1;

            //si usuario existe se procede a evaluar los datos del usuario
            if (existeUsuario == 1)
            {
                //evaluamos si la contraseña no es la generica
                if (password != "EVALUACION")
                {
                    string passEncriptado = dcE.Encriptar(password);
                    //se manda login y pass para validar traer la endidad del usuario logueado0o
                }
                else
                {
                    Response.Redirect("wfCambioClave.aspx");
                }
            }
            else
            {
                lblMensaje.Text = "Usuario no existe, favor verifique";
            }
        }
    }
}
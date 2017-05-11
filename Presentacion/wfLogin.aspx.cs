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
        {
            string login = txtLogin.Text.ToUpper().Trim(), password = txtPassword.Text.ToUpper().Trim();
            Negocio.usuariosNegocio dc = new Negocio.usuariosNegocio();
            try
            {
                int existeUsuario = dc.existeUsuario(login);

                switch (existeUsuario)
                {
                    //usuario no existe
                    case 0:
                        lblMensaje.Text = lblMensaje.Text = "Usuario no existe, favor verifique";
                        break;
                    //si existe se validan que los datos sean correctos
                    case 1:
                        evaluaDatos(password, login);
                        break;
                    //usuario esta inactivo
                    case 3:
                        lblMensaje.Text = "Usuario se encuentra inactivo";
                        break;
                    default:
                        break;
                }
            }
            catch (Exception err)
            {
                cvError.IsValid = false;
                cvError.Text = "Ocurrio un error, favor verifique*** ERR:" + err.Message;
            }


        }

        public void evaluaDatos(string password, string login)
        {
            Negocio.usuariosNegocio dc = new Negocio.usuariosNegocio();
            //evaluamos si la contraseña no es la generica
            try
            {
                if (password != "EVALUACION")
                {
                    string passEncriptado = dc.CreateMD5(password);
                    if (dc.validaDatos(login, passEncriptado) == 1)
                    {
                        Session.Add("sessionIDUsuario", dc.devolverID(login));
                        Response.Redirect("Default.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Usuario o contraseña incorrectos";
                    }
                }
                else
                {
                    if (dc.validaDatos(login, password) == 1)
                    {
                        Session.Add("sessionIDUsuario", dc.devolverID(login));
                        Response.Redirect("wfCambioClave.aspx");
                    }
                    else
                    {
                        lblMensaje.Text = "Usuario o contraseña incorrectos";
                    }
                }


            }
            catch (Exception err)
            {
                cvError.IsValid = false;
                cvError.Text = "Ocurrio un error, favor verifique*** ERR:" + err.Message;
            }

        }
    }

}
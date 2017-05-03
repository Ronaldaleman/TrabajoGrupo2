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
            txtCorreo.Text = "";
            txtUsuario.Text = "";
        }
    }
}
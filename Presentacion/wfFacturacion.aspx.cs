using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfFacturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string today;
            today = DateTime.Now.ToShortDateString();
            txtFecha.Text = today;
        }
    }
}
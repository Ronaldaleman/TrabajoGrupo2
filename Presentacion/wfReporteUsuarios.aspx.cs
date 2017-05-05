using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace Presentacion
{
    public partial class wfReporteUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["sessionIDUsuario"] != null)
                    cargarReporteUsuario();
                else
                    Response.Redirect("wfLogin.aspx");
            }
        }

        protected void cargarReporteUsuario()
        {
            Negocio.usuariosNegocio dc = new Negocio.usuariosNegocio();
            try
            {
                
                rptUsuario.LocalReport.ReportEmbeddedResource = "Presentacion.rptUsuarios.rdlc";
                rptUsuario.LocalReport.DataSources.Add(new ReportDataSource("dsUsuario", dc.listaUsuario()));
                rptUsuario.LocalReport.Refresh();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
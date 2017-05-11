using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfReporteProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["sessionIDUsuario"] != null)
                {
                    CargaProductos();
                }
                else
                {
                    Response.Redirect("wfLogin");
                }
            }

        }

        private void CargaProductos()
        {
            try
            {
                Negocio.ProductoNegocio dc = new Negocio.ProductoNegocio();
                List<Entidad.Productos> ListaProductos = dc.RetornaListaProductosNegocio();

                rvProductos.LocalReport.ReportEmbeddedResource = "Presentacion.rptProductos.rdlc";
                rvProductos.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("dsProductos",ListaProductos));
                rvProductos.LocalReport.Refresh();
            }
            catch (Exception excepcion)
            {
                cvMensaje.IsValid = false;
                cvMensaje.ErrorMessage = "ERROR: "+excepcion.Message;                
            }
        }
    }
}
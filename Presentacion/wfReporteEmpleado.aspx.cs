using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfReporteEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                ReporteEmpleado();
            }
            
        }

        protected void ReporteEmpleado()
        {
            rvReporteEmpleado.Reset();
            Negocio.EmpleadoNegocio dc = new Negocio.EmpleadoNegocio();
            rvReporteEmpleado.LocalReport.ReportEmbeddedResource = "Presentacion.rptEmpleado.rdlc";
            rvReporteEmpleado.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dc.ListaEmpleadoNegocio()));
            rvReporteEmpleado.Visible = true;
            rvReporteEmpleado.LocalReport.Refresh();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls; 




namespace Presentacion
{
    public partial class ReporteClientes : System.Web.UI.Page
    {
        public object rptUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                cargaReporteClientes();
        }
        protected void cargaReporteClientes()
        {
            Negocio.NegocioClientes dc = new Negocio.NegocioClientes();

            try
            {
                ReportViewer1.LocalReport.ReportEmbeddedResource="Presentacion.ReporteClientes.rdlc";
                ReportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WebForms.ReportDataSource("DataSet1", dc.GetlistclientesNegocio()));
                ReportViewer1.LocalReport.Refresh();



            }
            catch (Exception err)
            {


               
            }
        }

        }
    }

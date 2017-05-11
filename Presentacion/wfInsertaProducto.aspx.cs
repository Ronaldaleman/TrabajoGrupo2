using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfInsertaProducto : System.Web.UI.Page
    {
        private Negocio.ProductoNegocio dc = new Negocio.ProductoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["sessionIDUsuario"] != null)
                {
                    
                }
                else
                {
                    Response.Redirect("wfLogin");
                }
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Entidad.Productos producto = null;
            try
            {
                producto = new Entidad.Productos();
                producto.Descripcion = txtDescripcion.Text.Trim().ToUpper();
                producto.Existencia = int.Parse(txtExistencia.Text);
                producto.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text);
                producto.FechaProceso = DateTime.Now;
                producto.Estado = 1;

                if (dc.InsertaProductoNegocio(producto) > 0)
                {
                    cvMensaje.IsValid = false;
                    cvMensaje.Text = "EL PRODUCTO "+producto.Descripcion+" FUE GUARDADO EXITOSAMENTE";
                    cvMensaje.ErrorMessage = "EL PRODUCTO " + producto.Descripcion + " FUE GUARDADO SATISFACTORIAMENTE";
                    txtDescripcion.Text = "";
                    txtExistencia.Text = "";
                    txtPrecioUnitario.Text = "";
                }

            }
            catch (Exception excepcion)
            {
                cvMensaje.IsValid = false;
                cvMensaje.Text ="ERROR AL GUARDAR EL PRODUCTO "+producto.Descripcion+": "+excepcion.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfEditaProducto");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfEditaProductoIndividual : System.Web.UI.Page
    {
        Negocio.ProductoNegocio dc = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Entidad.Productos producto = (Entidad.Productos)Session["ObjetoProducto"];
                CargaDatos(producto);
            }
        }

        public void CargaDatos(Entidad.Productos producto)
        {
            try
            {
                txtDescripcion.Text = producto.Descripcion;
                txtExistencia.Text = producto.Existencia.ToString();
                txtPrecioUnitario.Text = producto.PrecioUnitario.ToString();
            }
            catch (Exception excepcion)
            {
                cvMensaje.IsValid = false;
                cvMensaje.ErrorMessage = "ERROR: "+excepcion.Message;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dc = new Negocio.ProductoNegocio();
                Entidad.Productos producto = null;
                producto = (Entidad.Productos)Session["ObjetoProducto"];
                producto.Descripcion = txtDescripcion.Text.Trim().ToUpper();
                producto.Existencia = int.Parse(txtExistencia.Text.Trim());
                producto.PrecioUnitario = decimal.Parse(txtPrecioUnitario.Text.Trim());
                producto.Estado = 1;
                producto.FechaProceso = DateTime.Now;
                producto.UsuarioProceso = 0;
                if (dc.EditaProductoNegocio(producto) > 0)
                {
                    txtDescripcion.Text = ""; txtDescripcion.ReadOnly = true; rfvDescripcion.Enabled = false;
                    txtExistencia.Text = "";  txtExistencia.ReadOnly = true; rfvExistencia.Enabled = false;
                    txtPrecioUnitario.Text = ""; txtPrecioUnitario.ReadOnly = true; rfvPrecioUnitario.Enabled = false;
                    btnGuardar.Visible = false; btnGuardar.Enabled = false; btnCancelar.Text = "Volver";                  
                    cvMensaje.IsValid = false;
                    cvMensaje.ErrorMessage = "EL PRODUCTO " + producto.Descripcion + " FUE EDITADO CORRECTAMENTE";
                }
                else
                {
                    throw new Exception("OCURRIO UN EEROR AL EDITAR EL ELEMENTO " + producto.Descripcion);
                }
            }
            catch (Exception excepcion)
            {
                cvMensaje.IsValid = false;
                cvMensaje.ErrorMessage = "ERROR: "+excepcion.Message;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("wfEditaProducto");
        }
    }
}
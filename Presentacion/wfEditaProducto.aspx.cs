using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfEditaProducto : System.Web.UI.Page
    {
        private Negocio.ProductoNegocio dc = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargaProductos();
            }
        }

        public void CargaProductos()
        {
            dc = new Negocio.ProductoNegocio();
            try
            {
                gvProductos.DataSource = dc.RetornaListaProductosNegocio();
                gvProductos.DataBind();
            }
            catch (Exception excepcion)
            {
                cvMensaje.IsValid = false;
                cvMensaje.ErrorMessage = "ERROR: " + excepcion.Message;
            }
        }

        #region/*PAGINACION GRIDVIEW*/
        protected void IraPag(object sender, EventArgs e)
        {
            TextBox _IraPag = (TextBox)sender;
            int _NumPag = 0;

            if (int.TryParse(_IraPag.Text, out _NumPag) && _NumPag > 0 && _NumPag <= this.gvProductos.PageCount)
            {
                if (int.TryParse(_IraPag.Text, out _NumPag) && _NumPag > 0 && _NumPag <= this.gvProductos.PageCount)
                {
                    this.gvProductos.PageIndex = _NumPag - 1;
                    CargaProductos();
                }
                else
                {
                    this.gvProductos.PageIndex = 0;
                    CargaProductos();
                }
            }

            this.gvProductos.SelectedIndex = -1;
        }

        private int getpageindex(GridView gv, string clave)
        {
            if (clave == "Firts")
            {
                return 0;
            }

            else if (clave == "Next")
            {
                return gv.PageIndex + 1;
            }

            if (clave == "Last")
            {
                return gv.PageCount - 1;
            }

            else if (clave == "Prev")
            {
                return gv.PageIndex - 1;
            }

            else
            {
                return gv.PageIndex;
            }
        }

        protected void gvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                //PAGINADO
                //TOTAL PAGINAS
                Label _TotalPags = (Label)e.Row.FindControl("lblTotalNumberOfPages");
                _TotalPags.Text = gvProductos.PageCount.ToString();
                // IR A PAGINA
                TextBox _IraPag = (TextBox)e.Row.FindControl("IraPag");
                _IraPag.Text = (gvProductos.PageIndex + 1).ToString();

                // ASIGNA AL DROPDOWNLIST COMO VALOR SELECCIONADO EL PAGESIZE ACTUAL
                DropDownList _DropDownList = (DropDownList)e.Row.FindControl("RegsPag");
                _DropDownList.SelectedValue = gvProductos.PageSize.ToString();
            }
            else if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // APLICA ESTILOS A EVENTOS ON MOUSE OVER Y OUT
                e.Row.Attributes.Add("OnMouseOut", "this.className = this.orignalclassName;");
                //e.Row.Attributes.Add("OnMouseOver", "this.orignalclassName = this.className;this.className = 'altoverow';");
            }
        }

        protected void RegsPag_SelectedIndexChanged(object sender, EventArgs e)
        {
            //CAMBIAR NUMERO DE FILAS A MOSTRAR
            //OBTIENE EL NUMERO ELEGIDO
            DropDownList _DropDownList = (DropDownList)sender;
            // CAMBIA EL PAGESIZE DEL GRID ASIGNANDO EL ELEGIDO
            gvProductos.PageSize = int.Parse(_DropDownList.SelectedValue);
            CargaProductos();
        }

        protected void gvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex >= 0)
            {
                gvProductos.PageIndex = e.NewPageIndex;
                CargaProductos();
            }
        }
        #endregion

        protected void gvProductos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            dc = new Negocio.ProductoNegocio();
            string identificador = e.CommandArgument.ToString();
            try
            {
                Entidad.Productos producto = new Entidad.Productos();
                producto.Id = int.Parse(identificador);
                producto = dc.RetornaProductoNegocio(producto);

                if (e.CommandName == "ELIMINAR")
                {   
                    producto.Estado = 0;
                    if (dc.EditaProductoNegocio(producto) > 0)
                    {
                        CargaProductos();
                        cvMensaje.IsValid = false;
                        cvMensaje.ErrorMessage = "EL ELEMENTO "+producto.Descripcion+" FUE DADO DE BAJA CORRECTAMENTE";
                    }
                    else
                    {
                        throw new Exception("NO SE PUDO DAR DE BAJA EL ELEMENTO "+producto.Descripcion);
                    }

                }
                else
                {
                    /*Codigo para editar*/
                    Session["ObjetoProducto"] = producto;
                    Response.Redirect("");

                }
            }
            catch (Exception excepcion)
            {
                cvMensaje.IsValid = false;
                cvMensaje.ErrorMessage = "ERROR: " + excepcion.Message;
            }
        }

    }
}
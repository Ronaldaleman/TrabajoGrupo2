using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

namespace Presentacion
{
    public partial class wfFacturacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*SE OBTIENE LA FECHA ACTUAL*/
                ObtenerFecha();
                /*SE CARGA LA LISTA DE LOS PRODUCTOS*/
                CargarProductos();
            }
        }
        public void ObtenerFecha()
        {
            string today;
            today = DateTime.Now.ToShortDateString();
            txtFecha.Text = today;
        }



        /*EVENTO ENCARGADO DE REALIZAR LA BUSQUEDA DEL CLIENTE*/
        protected void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                int CodCliente;
                CodCliente = int.Parse(txtCliente.Text.Trim());
                Entidad.Clientes cliente = null;
                Negocio.ClientesNegocio dc = new Negocio.ClientesNegocio();
                cliente = dc.ObtenerDatosCliente(CodCliente);
                if (cliente != null)
                {
                    txtNombre.Text = cliente.Nombre.Trim();
                }
                else
                {
                    cvDatos.IsValid = false;
                    cvDatos.CssClass = "alert-danger";
                    cvDatos.ErrorMessage = "No se encontraron datos del cliente. Favor verificar el código digitado.";
                }
                ObtenerFecha();
            }
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.CssClass = "alert-danger";
                cvDatos.ErrorMessage = err.Message;
                ObtenerFecha();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.ProductosNegocio pn = new Negocio.ProductosNegocio();
                Entidad.Productos pro = new Entidad.Productos();
                //List<Entidad.Factura_Detalle> fd = new List<Entidad.Factura_Detalle>();
               
                /*SE OBTIENEN LOS DATOS DEL PRODUCTO PARA ASI SABER SU PRECIO Y EXISTENCIA*/
                pro = pn.DatosProducto(int.Parse(ddlProducto.SelectedValue));
                /*VERIFICAMOS SI HAY PRODUCTO EN EXISTENCIA*/
                if (pro.Existencia == 0)
                {
                    cvDatos.IsValid = false;
                    cvDatos.CssClass = "alert-danger";
                    cvDatos.ErrorMessage = "No se puede despachar el producto porque no hay en existencia";
                } /*CIERRE IF EXISTENCIA*/
                else
                {
                    /*SE CREO UNA CLASE DEDICADA A ALMACENAR LOS DATOS DEL GRID*/
                    Negocio.Datos_Factura_Detalle df = new Negocio.Datos_Factura_Detalle();
                    List<Negocio.Datos_Factura_Detalle> dfd = new List<Negocio.Datos_Factura_Detalle>();

                    /*SI LA VARIABLE SESSION NO ESTA VACIA*/
                    if (Session["s_Detalle_Factura"] != null)
                    {
                        dfd = (List<Negocio.Datos_Factura_Detalle>)Session["s_Detalle_Factura"];
                        df.IdProducto = int.Parse(ddlProducto.SelectedValue.ToString());
                        df.Producto = ddlProducto.SelectedItem.ToString();
                        df.Cantidad = int.Parse(txtCantidad.Text);
                        df.PrecioUnitario = pro.PrecioUnitario;
                        df.Importe = (df.Cantidad * df.PrecioUnitario);
                        dfd.Add(df);
                        Session.Add("s_Detalle_Factura", dfd);
                        gvFactura.DataSource = dfd;
                        gvFactura.DataBind();
                        /*SE RECORRE LA LISTA DE REGISTRO EN EL GRID PARA OBTENER EL IMPORTE*/
                        decimal SumaImporte = 0;
                        foreach (var item in dfd)
                        {            
                            df.Cantidad = int.Parse(txtCantidad.Text);
                            df.PrecioUnitario = pro.PrecioUnitario;
                            df.Importe = (df.Cantidad * df.PrecioUnitario);
                            SumaImporte += Convert.ToInt32(item.Importe);  //aqui recorre las celdas y las va sumando
                            txtSubTotal.Text = SumaImporte.ToString();
                        } /*CIERRE FOREACH*/
                    }/*CIERRE DEL IF SI LA SESION O GRID NO ESTA VACIO*/
                    else
                    {
                        df.IdProducto = int.Parse(ddlProducto.SelectedValue.ToString());
                        df.Producto = ddlProducto.SelectedItem.ToString();
                        df.Cantidad = int.Parse(txtCantidad.Text);
                        df.PrecioUnitario = pro.PrecioUnitario;
                        df.Importe = (df.Cantidad * df.PrecioUnitario);                        
                        txtSubTotal.Text = df.Importe.ToString();
                        dfd.Add(df);
                        Session.Add("s_Detalle_Factura", dfd);
                        gvFactura.DataSource = dfd;
                        gvFactura.DataBind();
                    } /*CIERRE ELSE SI ES LA PRIMERA FILA A AGREGAR AL GRID*/                                   
                    /*CALCULAMOS EL IMPUESTO DE LA FACTURA*/
                    decimal Impuesto = 0;
                    Impuesto = (decimal.Parse(txtSubTotal.Text) * 15) / 100;
                    txtImpuesto.Text = Impuesto.ToString();
                    /*CALCULAMOS EL NETO DE LA FACTURA*/
                    decimal Total = 0;
                    Total = decimal.Parse(txtSubTotal.Text) + decimal.Parse(txtImpuesto.Text);
                    txtTotal.Text = Total.ToString();  
                } /*CIERRE DEL ELSE SI HAY EN EXISTENCIA PRODUCTO*/
            }
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.CssClass = "alert-danger";
                cvDatos.ErrorMessage = err.Message;
            }
        }

        /*METODO ENCARGADO DE LLENAR LA LISTA DE LOS PRODUCTOS A FACTURAR*/
        public void CargarProductos()
        {
            try
            {
                Negocio.ProductosNegocio dc = new Negocio.ProductosNegocio();
                List<Entidad.Productos> lista = dc.ListaProductos();
                if (lista.Count > 0)
                {
                    ListItem item = new ListItem();
                    item.Text = "Seleccione...";
                    item.Value = "0";
                    ddlProducto.Items.Add(item);
                    ddlProducto.DataSource = lista;
                    ddlProducto.DataTextField = "Descripcion";
                    ddlProducto.DataValueField = "Id";
                    ddlProducto.DataBind();
                }
                else
                {
                    cvDatos.IsValid = false;
                    cvDatos.CssClass = "alert-danger";
                    cvDatos.ErrorMessage = "No hay productos que mostrar."; ;
                }
            }
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.CssClass = "alert-danger";
                cvDatos.ErrorMessage = err.Message;
            }
        }

        /*EVENTO ENCARGADO DE REALIZAR LA FACTURACION*/
        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {              
                bool inserto = false;
                Negocio.FacturasNegocio factneg = new Negocio.FacturasNegocio();
                Entidad.Facturas f = new Entidad.Facturas();
                /*SE ASIGNAN LOS DATOS A LA ENTIDAD FACTURA*/
                f.IdCliente = int.Parse(txtCliente.Text);
                f.Fecha = DateTime.Now;
                f.Valor = decimal.Parse(txtTotal.Text);
                f.Impuesto = decimal.Parse(txtImpuesto.Text);
                f.Total = decimal.Parse(txtTotal.Text);
                f.Estado = 1;
                f.FechaProceso = DateTime.Now;
                f.UsuarioProceso = 1;
                List<Negocio.Datos_Factura_Detalle> dfd = (List<Negocio.Datos_Factura_Detalle>)Session["s_Detalle_Factura"];
                inserto = factneg.NuevaFactura(f, dfd);
                if (inserto == true)
                {
                    cvDatos.IsValid = false;
                    cvDatos.ErrorMessage = "La factura se guardo sin problemas.";
                    cvDatos.CssClass = "alert-success";
                }
                else
                {
                    cvDatos.IsValid = false;
                    cvDatos.ErrorMessage = "Hubo un error al facturar.";
                    cvDatos.CssClass = "alert-danger";
                }                
            }
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "Hubo un error al facturar, " + err.Message;
                cvDatos.CssClass = "alert-danger";
            }

        }

        /*ESTE EVENTO REALIZA EL RESETEO DE LOS CONTROLES DE LA VENTANA*/
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                limpiarControles();
            }
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "Hubo un error al limpiar los controles, " + err.Message;
                cvDatos.CssClass = "alert-danger";
            }
        }

        /*METODO ENCARGADO DE REALIZAR LA LIMPIEZA DE LOS CONTROLES*/
        public void limpiarControles()
        {
            try
            {
                Session.Remove("s_Detalle_Factura");
                ObtenerFecha();
                txtCliente.Text = "";
                txtNombre.Text = "";
                //ddlProducto.SelectedIndex = 0;
                ddlProducto.ClearSelection();
                txtCantidad.Text = "";
                gvFactura.DataSource = null;
                gvFactura.DataBind();
                txtSubTotal.Text = "";
                txtImpuesto.Text = "";
                txtTotal.Text = "";

            }
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "Hubo un error al limpiar los controles, " + err.Message;
                cvDatos.CssClass = "alert-danger";
            }
        }

        #region/*PAGINACION GRIDVIEW*/
        protected void IraPag(object sender, EventArgs e)
        {
            TextBox _IraPag = (TextBox)sender;
            int _NumPag = 0;

            if (int.TryParse(_IraPag.Text, out _NumPag) && _NumPag > 0 && _NumPag <= this.gvFactura.PageCount)
            {
                if (int.TryParse(_IraPag.Text, out _NumPag) && _NumPag > 0 && _NumPag <= this.gvFactura.PageCount)
                {
                    this.gvFactura.PageIndex = _NumPag - 1;
                    //cargarUsuarios();
                    gvFactura.DataSource = Session["s_Detalle_Factura"];
                    gvFactura.DataBind();
                }
                else
                {
                    this.gvFactura.PageIndex = 0;
                    //cargarUsuarios();
                    gvFactura.DataSource = Session["s_Detalle_Factura"];
                    gvFactura.DataBind();
                }
            }

            this.gvFactura.SelectedIndex = -1;
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

        protected void gvFactura_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Pager)
            {
                //PAGINADO
                //TOTAL PAGINAS
                Label _TotalPags = (Label)e.Row.FindControl("lblTotalNumberOfPages");
                _TotalPags.Text = gvFactura.PageCount.ToString();
                // IR A PAGINA
                TextBox _IraPag = (TextBox)e.Row.FindControl("IraPag");
                _IraPag.Text = (gvFactura.PageIndex + 1).ToString();

                // ASIGNA AL DROPDOWNLIST COMO VALOR SELECCIONADO EL PAGESIZE ACTUAL
                DropDownList _DropDownList = (DropDownList)e.Row.FindControl("RegsPag");
                _DropDownList.SelectedValue = gvFactura.PageSize.ToString();
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
            gvFactura.PageSize = int.Parse(_DropDownList.SelectedValue);
            //cargarUsuarios();
            gvFactura.DataSource = Session["s_Detalle_Factura"];
            gvFactura.DataBind();
        }

        protected void gvFactura_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex >= 0)
            {
                gvFactura.PageIndex = e.NewPageIndex;
                //cargarUsuarios();
                gvFactura.DataSource = Session["s_Detalle_Factura"];
                gvFactura.DataBind();
            }
        }
        #endregion
    }
}
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

        [WebMethod()]
        public string BuscarCliente(int ID)
        {
            Response.Write("<script language=javascript>alert('entre al metodo de busqueda de cliente');</script>");
            string nombre = "";
            try
            {
                /*int CodCliente;
                CodCliente = int.Parse(txtCliente.Text.Trim());*/
                Entidad.Clientes cliente = null;
                Negocio.ClientesNegocio dc = new Negocio.ClientesNegocio();
                cliente = dc.ObtenerDatosCliente(ID);
                if (cliente != null)
                {
                    txtNombre.Text = cliente.Nombre.Trim();
                    nombre = cliente.Nombre.Trim();
                    txtCliente.Enabled = false;
                    cvDatos.ErrorMessage = nombre;
                }
                else
                {
                    cvDatos.IsValid = false;
                    cvDatos.CssClass = "alert-danger";
                    cvDatos.ErrorMessage = "No se encontraron datos del cliente. Favor verificar el código digitado.";
                }
            }
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.CssClass = "alert-danger";
                cvDatos.ErrorMessage = err.Message;
            }
            return nombre;
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
                            /*if (ddlProducto.SelectedItem.Text == item.Producto)
                            {
                                cvDatos.IsValid = false;
                                cvDatos.ErrorMessage = "El producto ya fue seleccionado.";
                                cvDatos.CssClass = "alert-danger";
                            }*//*CIERRE IF VALIDACION DE LA SELECCION DEL PRODUCTO REPETIDO*/
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

        protected void btnFacturar_Click(object sender, EventArgs e)
        {
            try
            {
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
                factneg.NuevaFactura(f, dfd);


            }
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "Hubo un error al facturar, " + err.Message;
                cvDatos.CssClass = "alert-danger";
            }

        }
    }  
}


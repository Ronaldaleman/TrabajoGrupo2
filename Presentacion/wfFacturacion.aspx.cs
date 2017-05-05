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
            if(!IsPostBack)
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

                Session.Add("Detalle_Factura",);
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

        
    }
}
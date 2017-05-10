using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Modificar_Cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Actualizar_Click(object sender, EventArgs e)
        {

             
            Entidad.Clientes customer = new Entidad.Clientes();
            customer.Id = int.Parse(txt_Id.Text);
            customer.Nombre = txtNombres.Text.Trim();
            customer.Cedula = txtNumeroCedula.Text.Trim();
            customer.Direccion = txtDireccion.Text.Trim();
            customer.FechaProceso = DateTime.Now;
            customer.UsuarioProceso = 1;
            customer.Estado = 1;
            Negocio.NegocioClientes dc = new Negocio.NegocioClientes();
            Negocio.webservicenegocio ds = new Negocio.webservicenegocio();
            string cedula = ds.ValidaCedula(txtNumeroCedula.Text.Trim());
            if (cedula == "1")
            {
                dc.ActualizarClientes(customer);
                lblMessage.Text = "El usuario fue actualizado Exitosamente";
            }
                
                else
                lblMessage.Text = "El usuario no fue actualizado Exitosamente";



        }

        protected void btn_Recuperar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.NegocioClientes dc = new Negocio.NegocioClientes();
                Entidad.Clientes clientes = dc.RecuperarCliente(int.Parse(txt_Id.Text));
                if (clientes != null)
                {
                    txtNombres.Text = clientes.Nombre;
                    txtNumeroCedula.Text = clientes.Cedula;
                    txtDireccion.Text = clientes.Direccion;
                    
                }
                else
                {
                    lblMessage.Text = "No existe el cliente con este id.";
                }

            }
            catch (Exception err)
            {
                throw;
            }
        }

        protected void btn_Limpiar_Click(object sender, EventArgs e)
        {
            
            txt_Id.Text = "";
            txtNombres.Text = "";
            txtNumeroCedula.Text = "";
            txtDireccion.Text = "";
            lblMessage.Text = "";

        }
    }
}
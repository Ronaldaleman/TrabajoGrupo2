using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class BajaCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Recuperar_Click(object sender, EventArgs e)
        {

            try
            {
                Negocio.NegocioClientes dc = new Negocio.NegocioClientes();
                Entidad.Clientes clientes = dc.RecuperarCliente(int.Parse(txt_Id.Text));
                if (clientes != null)
                {

                    txt_Nombres.Text = clientes.Nombre;



                }

                else

                {
                    lblMessage.Text = "No existe el cliente con este id.";
                }


            }
            catch (Exception err)
            {

                throw err;
            }

        }

        protected void btn_Confirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad.Clientes customer = new Entidad.Clientes();
                customer.Id = int.Parse(txt_Id.Text);
                customer.Nombre = txt_Nombres.Text.Trim();
                customer.FechaProceso = DateTime.Now;
                customer.UsuarioProceso = 1;
                customer.Estado = 2;
                Negocio.NegocioClientes dc = new Negocio.NegocioClientes();
                dc.BajaCliente(customer);
                customer.Estado = 1;
                lblMessage.Text = "El usuario fue actualizado Exitosamente";
            }
            catch (Exception err)
            {

                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = err.Message;
            }

        }



        protected void btnLimpiar(object sender, EventArgs e)
        {
            txt_Id.Text = "";
            txt_Nombres.Text = "";

        }

        protected void btn_Cancelar(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class RegistrarClientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)

        { }

      

        protected void txtEntrar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocio.webservicenegocio dc = new Negocio.webservicenegocio();
                string respuesta = dc.ValidaCedula(txtNumeroCedula.Text.Trim());
                if (respuesta == "1")

                {
                    Entidad.Clientes a = new Entidad.Clientes();
                    a.Nombre = txtNombres.Text.Trim().ToUpper();
                    a.Cedula = txtNumeroCedula.Text.Trim().ToUpper();
                    a.Direccion = txtDireccion.Text;
                    a.FechaProceso = DateTime.Now;
                    a.UsuarioProceso = 1;
                    a.Estado = 1;
                    Negocio.NegocioClientes ac = new Negocio.NegocioClientes();
                    

                   ac.Agregar(a);

                    lblMessage.Text = "Cédula correcta, los datos se han guardado exitosamente en la BD.";


                }
                else
                {
                    lblMessage.Text = "Cédula Incorrecta";
                }


            }
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = err.Message;
                //throw err;
            }
        }

        protected void Btn_Limpiar_Click(object sender, EventArgs e)
        {
            
            txtNombres.Text = "";
            txtNumeroCedula.Text = "";
            txtDireccion.Text = "";
            lblMessage.Text = "";
        }
    }
}



    
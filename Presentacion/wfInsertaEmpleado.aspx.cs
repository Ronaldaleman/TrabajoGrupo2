using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfInsertaEmpleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Entidad.Empleados empleado = new Entidad.Empleados();
                empleado.Nombre = txtNombres.Text.Trim().ToUpper();
                empleado.Cedula = txtNumeroCedula.Text.Trim();
                empleado.Direccion = txtDireccion.Text.Trim();
                empleado.UsuarioProceso = 1;
                empleado.Estado = 1;
                Negocio.EmpleadoNegocio en = new Negocio.EmpleadoNegocio();
                if (en.InsertarEmpleadoNegocio(empleado)>0)
                {
                    // Enviar mensaje indicando se inserto el registro de empleado.
                }
                else
                {
                    // Enviar mensaje indicando no se inserto el registro de empleado.
                }
                  
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class wfEditaEmpleado : System.Web.UI.Page
    {
        private Negocio.EmpleadoNegocio dc = null;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dc = new Negocio.EmpleadoNegocio();
                int id_empl = int.Parse(txtIdEmpleado.Text.Trim());
                Entidad.Empleados empleado = dc.BuscaEmpleadoNegocio(id_empl);
                txtNombres.Text = empleado.Nombre;
                txtDireccion.Text = empleado.Direccion;
                txtNumeroCedula.Text = empleado.Cedula; 
            }
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "Error: " + err.Message;
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                dc = new Negocio.EmpleadoNegocio();
                Entidad.Empleados empleado = new Entidad.Empleados();
                empleado.Id = int.Parse(txtIdEmpleado.Text);
                empleado.Nombre = txtNombres.Text.Trim().ToUpper();
                empleado.Direccion = txtDireccion.Text.Trim().ToUpper();
                empleado.Cedula = txtNumeroCedula.Text.Trim().ToUpper();
                empleado.FechaProceso = DateTime.Now;
                empleado.Estado = 1;
                empleado.UsuarioProceso = 1;
                if(dc.EditaEmpleadoNegocio(empleado)>0)
                {
                    cvDatos.IsValid = false;
                    cvDatos.ErrorMessage = "Se editó el registro";
                }
                else
                {
                    cvDatos.IsValid = false;
                    cvDatos.ErrorMessage = "No se editó el registro";
                }
            }
            catch (Exception err)
            {
                cvDatos.IsValid = false;
                cvDatos.ErrorMessage = "Error: "+ err.Message;
            }
            

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}
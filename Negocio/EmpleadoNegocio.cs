using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class EmpleadoNegocio
    {
        private Datos.EmpleadoDatos dc = null;
        ServiceReference1.ServiciosUcaClient x = new ServiceReference1.ServiciosUcaClient();


        public int InsertarEmpleadoNegocio(Entidad.Empleados e)
        {
            int respuesta = 0;
            try
            {
                if (x.ValidarCedula(e.Cedula)=="1")
                {
                    dc = new Datos.EmpleadoDatos();
                    List<Entidad.Empleados> ListaEmpleados = new List<Entidad.Empleados>();
                    if (!ListaEmpleados.Exists(a => a.Cedula == e.Cedula))
                    {
                        respuesta = dc.InsertaEmpleadoDatos(e);
                    }
                    else
                    {
                        throw new Exception("Ya existe un registro con este número de cédula: "+e.Cedula);
                    }
                }
                
                return respuesta;
            }
            catch (Exception err)
            {
                throw err;
            }
        }
    }
}

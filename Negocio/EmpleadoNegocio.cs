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
                dc = new Datos.EmpleadoDatos();
                List<Entidad.Empleados> ListaEmpleados = ListaEmpleadoNegocio();
                if (!ListaEmpleados.Exists(a => a.Cedula == e.Cedula))
                {
                    if (x.ValidarCedula(e.Cedula) == "1")
                    {                    
                        respuesta = dc.InsertaEmpleadoDatos(e);
                    }
                    else
                    {
                        throw new Exception("Cédula " + e.Cedula + " no válida");
                    }
                }
                else
                {
                    throw new Exception("Cédula "+e.Cedula+" ya existe" );
                }
                return respuesta;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public int EditaEmpleadoNegocio(Entidad.Empleados e)
        {
            int respuesta = 0;
            try
            {
                dc = new Datos.EmpleadoDatos();
                List<Entidad.Empleados> ListaEmpleados = ListaEmpleadoNegocio();
                if (ListaEmpleados.Exists(a => a.Id == e.Id))
                {
                    respuesta = dc.EditaEmpleadoDatos(e);  
                }
                else
                {
                    throw new Exception("El Id de Empleado no existe");
                }
                return respuesta;
            }
            catch (Exception err)
            {
                throw err;
            }
            
        }

        public int EliminaEmpleadoNegocio(Entidad.Empleados e)
        {
            int respuesta = 0;
            try
            {
                dc = new Datos.EmpleadoDatos();
                List<Entidad.Empleados> ListaEmpleados = ListaEmpleadoNegocio();
                if (ListaEmpleados.Exists(a => a.Id == e.Id))
                {
                    respuesta = dc.EliminaEmpleadoDatos(e);
                }
                else
                {
                    throw new Exception("El Id de Empleado no existe");
                }
                return respuesta;
            }
            catch (Exception err)
            {
                throw err;
            }

        }

        public List<Entidad.Empleados> ListaEmpleadoNegocio()
        {
            try
            {
                dc = new Datos.EmpleadoDatos();
                return dc.ListaEmpleadoDatos();
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public Entidad.Empleados BuscaEmpleadoNegocio(int id)
        {
            Entidad.Empleados empl = null;
            try
            {
                List<Entidad.Empleados> ListaEmpleados = ListaEmpleadoNegocio();
                if(ListaEmpleados.Exists(a => a.Id == id))
                {
                    empl = ListaEmpleados.Where(a => a.Id == id).FirstOrDefault();
                }
                else
                {
                    throw new Exception("El empleado no existe");
                }
            }
            catch (Exception err)
            {  
                throw err;
            }
            return empl;
        }
    }
}

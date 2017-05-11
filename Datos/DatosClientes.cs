using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class DatosClientes
    {
        public List<Entidad.Clientes> GetlistclientesDatos()
        {
            Entidad.BD_EvaluacionEntities dc = null;
            List<Entidad.Clientes> cl = new List<Entidad.Clientes>();
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                cl = dc.Clientes.ToList();
                return cl;
             
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public void UpdateClientes(Entidad.Clientes a)
        {
            Entidad.BD_EvaluacionEntities dc = null;

            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                Entidad.Clientes cl = dc.Clientes.Where(aBD => aBD.Id == a.Id).FirstOrDefault();


                if (cl != null)
                {
                    cl.Nombre = a.Nombre;
                    cl.Cedula = a.Cedula;
                    cl.Direccion = a.Direccion;
                    cl.FechaProceso = a.FechaProceso;
                    cl.UsuarioProceso = a.UsuarioProceso;
                    cl.Estado = a.Estado;
                    dc.SaveChanges();


                }

            }
            catch (Exception err)
            {

                throw new Exception("Error al ejecutar update en Clientes////Detalle: " + err.Message);

            }
            finally
            {
                if (dc != null)
                    dc.Dispose();
            }

        }

        public void Insert(Entidad.Clientes c)
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                dc.Clientes.Add(c);
                dc.SaveChanges();

            }
            catch (Exception err)
            {

                throw err;
            }
        }

        //public void BajaCliente()
        //{
        //    throw new NotImplementedException();
        //}

        public Entidad.Clientes ConsultarCliente(int CodCliente)
        {
            Entidad.Clientes cl = new Entidad.Clientes();
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                cl = dc.Clientes.Where(aBD => aBD.Id == CodCliente).FirstOrDefault();
            }
            catch (Exception err)
            {
                throw new Exception("Error al recupear Clientes////Detalle: " + err.Message);
            }
            finally
            {
                if (dc != null)
                    dc.Dispose();
            }
            return cl;

        }


        public void BajaCliente(Entidad.Clientes a)
        {
            Entidad.BD_EvaluacionEntities dc = null;

            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                Entidad.Clientes cl = dc.Clientes.Where(aBD => aBD.Id == a.Id).FirstOrDefault();


                if (cl != null)
                {
                    //cl.Nombre = a.Nombre;
                    //cl.FechaProceso = a.FechaProceso;
                    //cl.UsuarioProceso = a.UsuarioProceso;
                    cl.Estado = a.Estado;
                    dc.SaveChanges();
                }

            }
            catch (Exception err)
            {

                throw new Exception("Error al ejecutar Baja del Clientes////Detalle: " + err.Message);

            }
            finally
            {
                if (dc != null)
                    dc.Dispose();
            }

        }

    }
}

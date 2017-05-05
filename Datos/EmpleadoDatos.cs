using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Datos
{
    public class EmpleadoDatos
    {
        Entidad.BD_EvaluacionEntities dc = null;

        public int InsertaEmpleadoDatos(Entidad.Empleados e)
        {
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                dc.Empleados.Add(e);
                return dc.SaveChanges();
            }
            catch (Exception err)
            {
                throw(err);
            }
        }

        public int EditaEmpleadoDatos(Entidad.Empleados e)
        {
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                // Utilizamos liqQ para encontrar el primer 
                Entidad.Empleados db_e = dc.Empleados.FirstOrDefault(a => a.Id == e.Id);
                if (db_e !=null)
                {
                    db_e.Nombre = e.Nombre;
                    db_e.Cedula = e.Cedula;
                    db_e.Direccion = e.Direccion;
                    db_e.FechaProceso = DateTime.Now;
                    db_e.UsuarioProceso = e.UsuarioProceso;
                    db_e.Estado = e.Estado;
                    
                }

                return dc.SaveChanges();
            }
            catch (Exception err)
            {
                throw(err);
            }
        }

        public List<Entidad.Empleados> ListaEmpleado()
        {
            dc = new Entidad.BD_EvaluacionEntities();
            try
            {
                return dc.Empleados.ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

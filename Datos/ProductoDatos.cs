using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProductoDatos
    {
        Entidad.BD_EvaluacionEntities dc = null;

        public int InsertaProdructoDatos(Entidad.Productos producto)
        {
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                dc.Productos.Add(producto);
                return dc.SaveChanges();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public int EditaProductoDatos(Entidad.Productos producto)
        {
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                dc.Productos.Attach(producto);
                return dc.SaveChanges();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public List<Entidad.Productos> RetornaListaProductosDatos()
        {
            dc = new Entidad.BD_EvaluacionEntities();
            return dc.Productos.ToList();
            throw new Exception();
        }    
    }
}

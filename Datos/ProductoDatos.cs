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

        public int EditaProductoDatos(Entidad.Productos ProductoEditado)
        {
            try
            {
                
                dc = new Entidad.BD_EvaluacionEntities();
                Entidad.Productos ProductoAEditar = dc.Productos.Where(p => p.Id == ProductoEditado.Id).FirstOrDefault();
                ProductoAEditar.Id = ProductoEditado.Id;
                ProductoAEditar.Descripcion = ProductoEditado.Descripcion;
                ProductoAEditar.Existencia = ProductoEditado.Existencia;
                ProductoAEditar.PrecioUnitario = ProductoEditado.PrecioUnitario;
                ProductoAEditar.FechaProceso = DateTime.Now;
                ProductoAEditar.Estado = ProductoEditado.Estado;
                ProductoAEditar.UsuarioProceso = 0;
                //dc.Productos.Attach(producto);
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
            List < Entidad.Productos > l = dc.Productos.ToList();
            dc.Dispose();
            return l;
            throw new Exception();
        }
    }
}

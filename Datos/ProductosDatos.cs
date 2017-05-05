using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ProductosDatos
    {
        /*METODO ENCARGADO DE OBTENER LA LISTA DE LOS PRODUCTOS*/
        public List<Entidad.Productos> ListaProductos()
        {
            Entidad.BD_EvaluacionEntities dc = null;
            List<Entidad.Productos> productos = new List<Entidad.Productos>();
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                productos = dc.Productos.ToList();
            }
            catch (Exception err)
            {
                throw(err);
            }
            return productos;
        }
    }
}

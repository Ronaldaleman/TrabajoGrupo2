using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductosNegocio
    {

        /*METODO ENCARGADO DE OBTENER LA LISTA DE LOS PRODUCTOS*/
        public List<Entidad.Productos> ListaProductos()
        {
            Datos.ProductosDatos dc = new Datos.ProductosDatos();
            List<Entidad.Productos> productos = new List<Entidad.Productos>();
            try
            {
                productos = dc.ListaProductos();
            }
            catch (Exception err)
            {
                throw (err);
            }
            return productos;
        }

        /*METODO ENCARGADO DE OBTENER LOS DATOS DEL PRODUCTOS*/
        public Entidad.Productos DatosProducto(int id)
        {
            Datos.ProductosDatos dc = null;
            Entidad.Productos p = new Entidad.Productos();
            try
            {
                dc = new Datos.ProductosDatos();
                p = dc.DatosProducto(id);
            }
            catch (Exception err)
            {
                throw (err);
            }
            return p;
        }
    }
}

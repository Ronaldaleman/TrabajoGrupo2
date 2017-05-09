using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ProductoNegocio
    {
        private ProductoDatos dc = null;

        public int InsertaProductoNegocio(Entidad.Productos producto)
        {
            try
            {
                dc = new ProductoDatos();
                if (RetornaProductoNegocio(producto)==null)
                {
                    return dc.InsertaProdructoDatos(producto);
                }
                else
                {
                    throw new Exception("EL PRODUCTO QUE INTENTÓ GRABAR, YA EXISTE.");
                }
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public int EditaProductoNegocio(Entidad.Productos producto)
        {
            try
            {
                dc = new ProductoDatos();
                return dc.EditaProductoDatos(producto);
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public List<Entidad.Productos> RetornaListaProductosNegocio()
        {
            try
            {
                dc = new ProductoDatos();
                return dc.RetornaListaProductosDatos();
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
        }

        public Entidad.Productos RetornaProductoNegocio(Entidad.Productos producto)
        {
            try
            {
                List<Entidad.Productos> listaProductos = RetornaListaProductosNegocio();
                
                if (listaProductos.Exists(lp => lp.Id == producto.Id))
                {
                    producto = listaProductos.Where(lp => lp.Id == producto.Id).FirstOrDefault();
                }
                else
                {
                    producto = null;                                            
                }
            }
            catch (Exception excepcion)
            {
                throw excepcion;
            }
            return producto;
        }
    }
}

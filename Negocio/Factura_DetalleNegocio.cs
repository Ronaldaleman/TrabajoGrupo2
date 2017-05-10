using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Factura_DetalleNegocio
    {
        /*METODO ENCARGADO DE INSERTAR EL DETALLE DE LA FACTURA*/
        public int InsertarDetalle(Entidad.Factura_Detalle fd)
        {
            int inserto = 0;            
            try
            {
                Datos.Factura_DetalleDatos dc = new Datos.Factura_DetalleDatos();
                dc.InsertarDetalle(fd);
                inserto = 1;
            }
            catch (Exception err)
            {
                throw (err);
            }
            return inserto;
        }
    }
}

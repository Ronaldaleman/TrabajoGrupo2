using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Factura_DetalleDatos
    {
        /*METODO ENCARGADO DE INSERTAR EL DETALLE DE LA FACTURA*/
        public int InsertarDetalle(Entidad.Factura_Detalle fd)
        {
            int inserto = 0;
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                dc.Factura_Detalle.Add(fd);
                dc.SaveChanges();
                inserto = 1;
            }
            catch (Exception err)
            {
                throw(err);
            }
            return inserto;
        }
    }
}

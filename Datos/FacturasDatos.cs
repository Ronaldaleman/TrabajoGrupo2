using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class FacturasDatos
    {
        /*METODO ENCARGADO DE INSERTAR EL ENCABEZADO DE LA FACTURA*/
        public int InsertarFactura(Entidad.Facturas f)
        {
            int inserto = 0;
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                dc.Facturas.Add(f);
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

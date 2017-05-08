using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Negocio
{
    public class FacturasNegocio
    {
        /*METODO DEDICADO A INSERTAR EL ENCABEZADO DE LA FACTURA*/
        public int InsertarFactura(Entidad.Facturas f)
        {
            int inserto = 0;           
            try
            {
                Datos.FacturasDatos dc = new Datos.FacturasDatos();
                dc.InsertarFactura(f);
                inserto = 1;
            }
            catch (Exception err)
            {
                throw (err);
            }
            return inserto;
        }

        /*METODO ENCARGADO DE INSERTAR EL MAESTRO Y EL DETALLE DE LA FACTURA*/
        public bool NuevaFactura(Entidad.Facturas f, List<Negocio.Datos_Factura_Detalle> p)
        {
            bool inserto = false;
            try
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    this.InsertarFactura(f);
                    Negocio.Factura_DetalleNegocio dc = new Factura_DetalleNegocio();
                    foreach (var item in p)
                    {
                        Entidad.Factura_Detalle df = new Entidad.Factura_Detalle();
                        df.IdFactura = f.Id;
                        //df.IdProducto = item.Id;
                        //df.Cantidad = item.ca
                        dc.InsertarDetalle(df);
                    }

                    ts.Complete();
                }
                

            }
            catch (Exception err)
            {
                throw(err);
            }
            return inserto;
        }
    }
}

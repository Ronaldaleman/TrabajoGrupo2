using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    /*CLASE DEDICADA A ALMACENAR LOS DATOS DEL DETALLE DE LA FACTURA*/
    public class Datos_Factura_Detalle
    {
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public string Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public decimal Valor { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Impuesto { get; set; }
        public decimal Total { get; set; }
        public DateTime Fechaproceso { get; set; }
        public int UsuarioProceso { get; set; }
    }
}

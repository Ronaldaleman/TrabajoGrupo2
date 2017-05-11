using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ClientesNegocio
    {
        /*METODO ENCARGADO DE REALIZAR LA BUSQUEDA DE LOS DATOS DEL CLIENTE*/
        public Entidad.Clientes ObtenerDatosCliente(int CodCliente)
        {
            Entidad.Clientes cliente = new Entidad.Clientes();
            Datos.ClientesDatos dc = new Datos.ClientesDatos();
            try
            {
                return cliente = dc.BuscarClienteById(CodCliente);
            }
            catch (Exception e) 
            {
                throw(e);
            }
            return cliente;
        }
    }
}

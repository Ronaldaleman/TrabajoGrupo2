using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class ClientesDatos
    {

        /*METODO ENCARGADO DE BUSCAR LOS DATOS DEL CLIENTE*/
        public Entidad.Clientes BuscarClienteById(int CodCliente)
        {
            Entidad.Clientes cli = new Entidad.Clientes();
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities(); 
                cli = dc.Clientes.Where(c => c.Id == CodCliente).FirstOrDefault();                
            }
            catch (Exception e)
            {
                throw(e);
            }
            return cli;
        }
    }
}

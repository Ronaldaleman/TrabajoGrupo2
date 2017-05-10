using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioClientes
    {
        public List<Entidad.Clientes> GetlistclientesNegocio()
        {
            try
            {
                Datos.DatosClientes dc = new Datos.DatosClientes();
                return dc.GetlistclientesDatos();
            }
            catch (Exception err)
            {

                throw err;
            }
        }

        public void Agregar(Entidad.Clientes clientes)

        {
            try
            {
                Datos.DatosClientes dc = new Datos.DatosClientes();
                dc.Insert(clientes);


            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarClientes(Entidad.Clientes clientes)
        {
            try
            {
                Datos.DatosClientes dc = new Datos.DatosClientes();
                dc.UpdateClientes(clientes);
            }
            catch (Exception err)
            {

                throw (err);
            }

        }


        public Entidad.Clientes RecuperarCliente (int  CodCliente)
        {
            Entidad.Clientes c = new Entidad.Clientes();
            try
            {
                Datos.DatosClientes dc = new Datos.DatosClientes();
                return c = dc.ConsultarCliente(CodCliente);
            }
            catch (Exception err)
            {
                throw (err);
            }
        }






    }
}

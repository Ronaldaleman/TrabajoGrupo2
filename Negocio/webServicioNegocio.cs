using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class webServicioNegocio
    {
        public string ValidaCedula(string numeroCedula)
        {
            ServiciosUca.ServiciosUcaClient ws = new ServiciosUca.ServiciosUcaClient();

            try
            {
                string resp = (ws.ValidarCedula(numeroCedula) == "1" ? "1" : "2");
                return resp;
            }
            catch (Exception err)
            {

                throw (err);
            }
        }

    }
}

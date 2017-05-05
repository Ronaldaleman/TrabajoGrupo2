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
            try
            {
                ServiciosUca.ServiciosUcaClient ws = new ServiciosUca.ServiciosUcaClient();
                string resp = ws.ValidarCedula(numeroCedula);
                return resp;
            }
            catch (Exception err)
            {

                throw (err);
            }

        }
    }
}

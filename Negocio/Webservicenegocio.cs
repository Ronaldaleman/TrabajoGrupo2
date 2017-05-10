using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class webservicenegocio
    {
        public string ValidaCedula(string numeroCedula)
        {
            try
            {

                Serviciosuca.ServiciosUcaClient ws = new Serviciosuca.ServiciosUcaClient();
                string resp = (ws.ValidarCedula(numeroCedula));

                if (resp == "1")
                {
                    resp = "1";
                }
                else
                {
                    resp = "2";
                }
                return resp;
            }
            catch (Exception err)
            {

                throw (err);
            }

        }



    }
}

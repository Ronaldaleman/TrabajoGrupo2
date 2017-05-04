using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Negocio
{
    public class usuariosNegocio
    {
        public string CrearUsuario(Entidad.Usuarios user)
        {
            string resp = "";
            try
            {
                Datos.usuariosDatos dc = new Datos.usuariosDatos();
                Entidad.Usuarios userBD = dc.GetUsuario(user.Login);
                
                if (userBD == null)
                {
                   // user.Clave = CreateMD5(user.Clave);
                    dc.Insertar(user);
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
        protected static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

    }
}

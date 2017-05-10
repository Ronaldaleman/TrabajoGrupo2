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
        /// <summary>
        /// Método para mandar a insertar el usuarios  en la tabla
        /// </summary>
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


        /// <summary>
        /// Método para mandar a dar de baja al usuarios  en la tabla
        /// </summary>
        public string DarBajaUsuario(int coduser)
        {
            string resp = "";
            try
            {
                Datos.usuariosDatos dc = new Datos.usuariosDatos();
                Entidad.Usuarios userBD = dc.GetCodUsuario(coduser);

                if (userBD != null)
                {
                    // user.Clave = CreateMD5(user.Clave);
                    dc.BajaUsuario(userBD);
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

        /// <summary>
        /// Método para mandar a consultar el usuarios  en la tabla
        /// </summary>
        public Entidad.Usuarios ConsultarUsuario(int codusu)
        {
            try
            {
                Datos.usuariosDatos dc = new Datos.usuariosDatos();
                return dc.GetCodUsuario(codusu);
            }
            catch (Exception err)
            {

                throw (err);
            }
        }




        /// <summary>
        /// Método para mandar a actualizar el usuarios  en la tabla
        /// </summary>
        public void ActualizarUsuario(Entidad.Usuarios alumno)
        {

            try
            {
                Datos.usuariosDatos dc = new Datos.usuariosDatos();
                dc.UpdateUsuario(alumno);

            }
            catch (Exception err)
            {

                throw (err);
            }
        }

    }
}

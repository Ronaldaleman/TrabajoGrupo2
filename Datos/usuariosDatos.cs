using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class usuariosDatos
    {
        /// <summary>
        /// Método para insertar los usuarios  en la tabla
        /// </summary>
      
        public void Insertar(Entidad.Usuarios a)
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                dc.Usuarios.Add(a);
                dc.SaveChanges();
            }
            catch (Exception err)
            {

                throw err;
            }
        }
        /// <summary>
        /// Método para actualizar los usuarios  en la tabla
        /// </summary>
        public void UpdateUsuario(Entidad.Usuarios a)
        {
         
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                Entidad.Usuarios usr = dc.Usuarios.Where(aBD => aBD.Usuarios1 == a.Usuarios1).FirstOrDefault();

                
                if (usr != null)
                {
                    usr.Login = a.Login;
                    usr.Nombre = a.Nombre;
                    usr.Clave = a.Clave;
                    usr.FechaProceso = a.FechaProceso;
                    usr.Cedula = a.Cedula;
                    usr.Estado = 1;
                    dc.SaveChanges();
                }
            }
            catch (Exception err)
            {

                throw new Exception("Error al ejecutar update en Usuarios////Detalle: " + err.Message);
            }
            finally
            {
                if (dc != null)
                    dc.Dispose();
            }
        }
        /// <summary>
        /// Método para dar de baja a los usuarios  en la tabla
        /// </summary>
        public void BajaUsuario(Entidad.Usuarios a)
        {
            Entidad.Usuarios usr = null;
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                usr = dc.Usuarios.Where(c => c.Usuarios1 == a.Usuarios1).FirstOrDefault();
                if (usr != null)
                {
                    usr.Estado = 2;
                    usr.FechaProceso = a.FechaProceso;
                    dc.SaveChanges();
                }
            }
            catch (Exception err)
            {

                throw new Exception("Error al ejecutar update en Usuarios////Detalle: " + err.Message);
            }
            finally
            {
                if (dc != null)
                    dc.Dispose();
            }
        }
        /// <summary>
        /// Método para obtener el usuario al enviar el codigo del usuario
        /// </summary>
        public Entidad.Usuarios GetUsuario(string userLogin)
        {
            Entidad.BD_EvaluacionEntities dc = null;
            Entidad.Usuarios user = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                user = dc.Usuarios.Where(u => u.Login == userLogin).FirstOrDefault();
                return user;
            }
            catch (Exception err)
            {
                throw (err);
            }
        }

        /// <summary>
        /// Método que genera una lista completa de los usuarios registrados en la tabla
        /// </summary>
        /// <returns>Lista de usuarios</returns>
        public List<Entidad.Usuarios> listUsuario()
        {
            Entidad.BD_EvaluacionEntities dc = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                List<Entidad.Usuarios> usersBD = new List<Entidad.Usuarios>();
                usersBD = dc.Usuarios.ToList();
                return usersBD;
            }
            catch (Exception err)
            {
                throw (err);
            }
        }


        public Entidad.Usuarios GetCodUsuario(int codUser)
        {
            Entidad.BD_EvaluacionEntities dc = null;
            Entidad.Usuarios user = null;
            try
            {
                dc = new Entidad.BD_EvaluacionEntities();
                user = dc.Usuarios.Where(u => u.Usuarios1 == codUser).FirstOrDefault();
                return user;
            }
            catch (Exception err)
            {

                throw (err);
            }
        }

       

    }
}

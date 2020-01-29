using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALO.Utilidades
{
    /// <summary>
    /// CLASE QUE PERMITE CREAR LAS CADENAS DE CONECCION POR MEDIO
    /// DE LA INFORMACIÓN QUE SE PREVEE EN EL WEBCONFIG DEL APLICATIVO WEB
    /// </summary>
    public class UConexionesADO
    {

        //=====================================================================
        // CONFIGURACION RESCATADAS DESDE EL WEBCONFIG
        //=====================================================================
        public string Servidor_C = System.Configuration.ConfigurationSettings.AppSettings["DB_SERVIDOR_C"];
        public string Usuario_C = System.Configuration.ConfigurationSettings.AppSettings["DB_USUARIO_C"];
        public string Password_C = System.Configuration.ConfigurationSettings.AppSettings["DB_PASSWORD_C"];
        public string BaseDatos_C = System.Configuration.ConfigurationSettings.AppSettings["DB_BASEDATOS_C"];
        public string AplicationName_C = System.Configuration.ConfigurationSettings.AppSettings["DB_APLICATION_NAME_C"];

        /// <summary>
        /// METODO QUE DEVUELVE LA CADENA CONECCIÓN AL MOTOR 
        /// EXTRAIDA DESDE EL WEBCONFIG DEL APLICATIVO WEB
        /// </summary>
        /// <returns></returns>
        public string ConexionDB()
        {

            string Retorno = "";

            try
            {

                //=============================================================
                // SE EXTRAEN REGISTROS DE CONEXION A BASE DE DATOS          ==
                //=============================================================
                string Usuario = this.Usuario_C;
                string Password = this.Password_C;
                string BaseDatos = this.BaseDatos_C;
                string Servidor = this.Servidor_C;
                string AplicationName = this.AplicationName_C;

                //=============================================================
                // RETORNA CADENA DE CONEXION                                ==
                //=============================================================
                return CadenaConexion(Usuario, Password, BaseDatos, Servidor, AplicationName);


            }
            catch
            {

                return Retorno;
            }

        }

       

        /// <summary>
        /// CONVIERTE LOS DATOS ENVIADOS EN UNA CADENA DE CONECCIÓN 
        /// </summary>
        /// <param name="Usuario"></param>
        /// <param name="Paswword"></param>
        /// <param name="BaseDatos"></param>
        /// <param name="Servidor"></param>
        /// <param name="AplicationName"></param>
        /// <returns></returns>
        public string CadenaConexion(string Usuario
                                           , string Paswword
                                           , string BaseDatos
                                           , string Servidor
                                           , string AplicationName)
        {

            string Retorno = "";
            try
            {

                //=============================================================
                // CADENA DE CONEXION                                        ==
                //=============================================================
                Retorno = @"User ID=" + Usuario + ";"
                        + "Password =" + Paswword + ";"
                        + "Initial Catalog =" + BaseDatos + ";"
                        + "Data Source=" + Servidor + ";"
                        + "Persist Security Info=True;"
                        + "Pooling=False;"
                        + "Connection Lifetime=5;"
                        + "Application Name= " + AplicationName ;


                return Retorno;

            }
            catch
            {
                return Retorno;
            }


        }


    }
}

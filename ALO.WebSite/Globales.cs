using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ALO.Entidades;

namespace ALO.WebSite
{
    public class Globales
    {

        public const string URL_Default = "../../Home";

        public static String Cookie = "CookLogCarga1Login";
        public static String CookieGlobal = "CookLogCarga1Globales";
        public static String FormatoFecha = "yyyy-MM-dd hh:mm:ss";

        


        /// <summary>
        /// DATOS DE COOKIES
        /// </summary>
        /// <returns></returns>
        public static COOK_DATOS DATOS_COOK()
        {

            COOK_DATOS Datos = new COOK_DATOS();

            try
            {

                int idUsuario = Convert.ToInt32(HttpContext.Current.Request.Cookies[CookieGlobal]["USER_ID_USUARIO"] ?? 0.ToString());
                string nombre = HttpContext.Current.Request.Cookies[CookieGlobal]["USER_NOMBRE"] ?? string.Empty.ToString();
                string login = HttpContext.Current.Request.Cookies[CookieGlobal]["USER_LOGIN"] ?? string.Empty.ToString();
              
                Datos.ID_USUARIO = idUsuario;
                Datos.NOMBRE_USUARIO = nombre;
                Datos.LOGIN = login;

                return Datos;

            }
            catch
            {
                throw;
            }

        }


    }
}
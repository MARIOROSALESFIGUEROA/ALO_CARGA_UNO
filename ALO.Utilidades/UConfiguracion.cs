using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALO.Utilidades
{
    public class UConfiguracion
    {

        //=====================================================================
        // CONFIGURACION RESCATADAS DESDE EL WEBCONFIG
        //=====================================================================
        public static string ServidorUrl_GET = System.Configuration.ConfigurationSettings.AppSettings["URL_RESTful_GET"];
        public static string ServidorUrl_POST = System.Configuration.ConfigurationSettings.AppSettings["URL_RESTful_POST"];
        public static string ServidorUrl_POST_INTERFAZ = System.Configuration.ConfigurationSettings.AppSettings["RF_DB_POST_INTERFAZ"];
        public static string ServidorUrl_POST_PARAMETROS = System.Configuration.ConfigurationSettings.AppSettings["RF_DB_POST_PARAMETROS"];
        public static string ServidorRest_Opcion = System.Configuration.ConfigurationSettings.AppSettings["URL_RESTful_OPCION"];
        public static string ServidorWCF = System.Configuration.ConfigurationSettings.AppSettings["URL_WCF"];
        public static string F_POST_UPLOAD_FILE = System.Configuration.ConfigurationSettings.AppSettings["F_POST_UPLOAD_FILE"];
        public static string F_POST_UPLOAD_FTP = System.Configuration.ConfigurationSettings.AppSettings["F_POST_UPLOAD_FTP"];
        public static string RutaLearning = System.Configuration.ConfigurationSettings.AppSettings["RUTA_LEARNING"];
        public static string RutaConector = System.Configuration.ConfigurationSettings.AppSettings["RUTA_CONECTOR"];
        public static string PATH_ROOT = System.Configuration.ConfigurationSettings.AppSettings["PATH_ROOT"];
    }
}

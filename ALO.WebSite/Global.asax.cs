using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ALO.WebSite
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

            RouteTable.Routes.MapPageRoute("Home", "Home", "~/Default.aspx");
            RouteTable.Routes.MapPageRoute("Login", "Login", "~/Account/Login.aspx");
            RouteTable.Routes.MapPageRoute("CambioPassword", "CambioPassword", "~/Account/CambioPassword.aspx");


            //==============================================
            // MANTENEDORES
            //==============================================
            RouteTable.Routes.MapPageRoute("CAR_INTERFAZ", "INTERFAZ/INTERFAZ", "~/Formularios/Interfaz/Interfaz.aspx");
            RouteTable.Routes.MapPageRoute("CAR_ASIGNACION", "INTERFAZ/ASIGNACION", "~/Formularios/Interfaz/AsignacionSalida.aspx");
            RouteTable.Routes.MapPageRoute("CAR_SALIDA", "INTERFAZ/SALIDA", "~/Formularios/Interfaz/FileSalida.aspx");

            //==============================================
            // OBJETOS
            //==============================================
            RouteTable.Routes.MapPageRoute("CAR_OBJETO", "OBJETO/OBJETO", "~/Formularios/Objetos/Objeto.aspx");
            RouteTable.Routes.MapPageRoute("CAR_OBJETO_INTERFAZ", "OBJETO/OBJETO_INTERFAZ", "~/Formularios/Objetos/AsignacionObjeto.aspx");

            //==============================================
            // EJECUCIONES
            //==============================================
            RouteTable.Routes.MapPageRoute("CAR_EJEC", "EJECUCION/EJECUCION", "~/Formularios/Ejecucion/Ejecucion.aspx");
            RouteTable.Routes.MapPageRoute("CAR_GRUPO_CAR", "GRUPO_CARGA/GRUPO_CARGA", "~/Formularios/Ejecucion/GrupoCarga.aspx");
            RouteTable.Routes.MapPageRoute("CAR_SOL", "EJECUCION/SOLICITUD", "~/Formularios/Ejecucion/EjecucionSolicitud.aspx");
            RouteTable.Routes.MapPageRoute("CAR_ASIG", "EJECUCION/ASIGNACION_PLANIFICACION", "~/Formularios/Ejecucion/AsignacionPlanificacion.aspx");

            //==============================================
            // GRUPO
            //==============================================
            RouteTable.Routes.MapPageRoute("CAR_GRUPO_LOGIN", "GRUPO/GRUPO_LOGIN", "~/Formularios/Grupo/GrupoLogin.aspx");
            RouteTable.Routes.MapPageRoute("CAR_GRUPO_CLUSTER", "GRUPO/GRUPO_CLUSTER", "~/Formularios/Grupo/GrupoCluster.aspx");

            //==============================================
            // GRUPO
            //==============================================
            RouteTable.Routes.MapPageRoute("CAR_WHO2", "PROCESO/WHO2", "~/Formularios/Proceso/ProcesoWho2.aspx");


            //==============================================
            // UPLOAD
            //==============================================
            RouteTable.Routes.MapPageRoute("CAR_UPLOAD", "INTERFAZ/UPLOAD", "~/Formularios/Interfaz/Upload.aspx");

            //==============================================
            // MANTENEDORES
            //==============================================
            RouteTable.Routes.MapPageRoute("CAR_CLUSTER", "MANTENEDORES/CLUSTER", "~/Formularios/Mantenedores/Cluster.aspx");

            //==============================================
            // DESCARGA DE ARCHIVOS DE CARGA
            //==============================================
            RouteTable.Routes.MapPageRoute("DOWN_ARCHI", "DOWNLOAD/ARCHIVO", "~/Formularios/Archivo/DescargaArchivo.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
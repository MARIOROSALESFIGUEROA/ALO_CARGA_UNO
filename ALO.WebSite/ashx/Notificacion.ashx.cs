using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace ALO.WebSite.ashx
{
    /// <summary>
    /// NOTIFICACIONES SignalR
    /// </summary>
    public class Notificacion : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {


                //===========================================================
                // VARIABLES QUERY STRING                                  ==
                //===========================================================  
                string LOGIN = "";
                string MENSAJE = "";
                string SISTEMA = "";


                //===========================================================
                // VARIABLES QUERY STRING                                  ==
                //===========================================================  
                LOGIN = context.Request.QueryString["LOGIN"];
                MENSAJE = context.Request.QueryString["MENSAJE"];
                SISTEMA = context.Request.QueryString["MENSAJE"];

                
                //===========================================================
                // EVALUACION
                //===========================================================  
                if (string.IsNullOrEmpty(LOGIN))
                {
                    throw new Exception("LOGIN ENVIADO ESTA VACIO");
                }

                if (string.IsNullOrEmpty(MENSAJE))
                {
                    throw new Exception("MENSAJE ENVIADO ESTA VACIO");
                }

                if (string.IsNullOrEmpty(SISTEMA))
                {
                    throw new Exception("SISTEMA ENVIADO ESTA VACIO");
                }

                //===========================================================
                // ENVIAR MENSAJE
                //=========================================================== 
                var CT = GlobalHost.ConnectionManager.GetHubContext<MessageHub>();
                CT.Clients.All.receivenotification(LOGIN, MENSAJE,SISTEMA);

                


                //===========================================================
                // RESPONDA POST                                           ==
                //=========================================================== 
                context.Response.ContentType = "text/plain";
                context.Response.Write("OK| " + "MENSAJE ENVIADO A USUARIO " + LOGIN);




            }
            catch (Exception e)
            {

                context.Response.Write("ERROR|" + e.Message);

            }


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
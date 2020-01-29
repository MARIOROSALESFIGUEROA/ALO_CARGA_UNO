using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ALO.Entidades;
using ALO.Servicio;
using ALO.Utilidades;

namespace ALO.WebSite.Account
{
    public partial class CambioPassword : System.Web.UI.Page
    {

        /// <summary>
        /// CARGAR PAGINA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {



        }



        /// <summary>
        /// MENSAJE LOG      
        /// </summary>
        /// <param name="Mensaje"></param>
        /// <param name="Titulo"></param>
        private void MensajeLOG(string Mensaje, string Titulo)
        {

            try
            {


                //===========================================================
                // CONTENIDO DIV CON RUNAT SERVER                       
                //===========================================================
                var DIV = (HtmlGenericControl)Page.Master.FindControl("LOG_MENSAJE_SERVER");
                DIV.InnerHtml = WebUtility.HtmlDecode(Mensaje);


                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("function FLOG(){");
                sb.Append("MensajeLOG('" + Titulo + "');");
                sb.Append("Sys.Application.remove_load(FLOG);}");
                sb.Append("Sys.Application.add_load(FLOG);");
                sb.Append("</script>");


                ScriptManager.RegisterStartupScript(this, typeof(Page), "PopupJS", sb.ToString(), false);



            }
            catch { }

        }

        /// <summary>
        /// CAMBIAR PASSWORD EN SISTEMA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_GUARDAR_PASSWORD_Click(object sender, EventArgs e)
        {

            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                string PASSWORD_NUEVA = "";
                string PASSWORD_CONFIRMAR = "";
                SMetodos Servicio = new SMetodos();



                //===========================================================
                // ASIGNA VALORES DE CAJA                                    
                //===========================================================
                PASSWORD_NUEVA = TXT_PASSWORD_NUEVA.Text;
                PASSWORD_CONFIRMAR = TXT_PASSWORD_CONFIRMAR.Text;


                //===========================================================
                // SI LOS VALORES SON DIDFERENTES                                   
                //===========================================================
                if (PASSWORD_NUEVA != PASSWORD_CONFIRMAR)
                {
                    MensajeLOG("LA NUEVA CONTRASEÑA Y LA CONFIRMACIÓN NO COINCIDEN", "FALLA ACTUALIZACION CLAVE");
                    return;

                }


                //===========================================================
                // PARAMETROS DE ENTRADA                                   
                //===========================================================
                iSP_UPDATE_PASSWORD ParametrosInput = new iSP_UPDATE_PASSWORD();
                ParametrosInput.ID_USUARIO = Globales.DATOS_COOK().ID_USUARIO;
                ParametrosInput.PASSWORD_ACTUAL = this.TXT_PASSWORD_ACTUAL.Text;
                ParametrosInput.PASSWORD_NUEVA = this.TXT_PASSWORD_NUEVA.Text;

                //===========================================================
                // LLAMADA DEL SERVICIO                                  
                //===========================================================
                oSP_RETURN_STATUS ObjetoRest = Servicio.SP_UPDATE_PASSWORD(ParametrosInput);

                if (ObjetoRest.RETURN_VALUE == -1)
                {

                    MensajeLOG("LA CLAVE ACTUAL NO CONCUERDA CON ESTE USUARIO", "FALLA ACTUALIZACION CLAVE");
                }

                if (ObjetoRest.RETURN_VALUE == 0)
                {

                    MensajeLOG("FALLÓ LA ACTUALIZACION DE LA CLAVE EN BASE DE DATOS", "FALLA ACTUALIZACION CLAVE");
                }

                if (ObjetoRest.RETURN_VALUE == 1)
                {

                    MensajeLOG("LA CLAVE FUE ACTUALIZADA EXITOSAMENTE", "CAMBIO DE CLAVE");
                }


                

            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOG(srv.Message, "ERRORES DE SERVICIO");
            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }




        }


    }
}
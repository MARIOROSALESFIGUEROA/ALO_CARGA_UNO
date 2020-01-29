using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALO.Entidades;
using ALO.Servicio;
using ALO.Utilidades;
using System.Web.UI.HtmlControls;
using System.Net;

namespace ALO.WebSite
{

    public partial class Default : System.Web.UI.MasterPage
    {



        /// <summary>
        /// CARGAR PAGINA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {



                //===========================================================
                // CULTURA
                //===========================================================
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-ES");



                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {

                    COOK_DATOS DATA = Globales.DATOS_COOK();

                    if (DATA.NOMBRE_USUARIO.ToString().Length <= 0)
                    {
                        Logout_Click(null, null);
                    }

                    LBL_Bienvenida.Text = DATA.NOMBRE_USUARIO;
                }

            }
            catch
            {
                Logout_Click(null, null);
            }

        }

        /// <summary>
        /// GENERACION DE JOB
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLearning_Click(object sender, EventArgs e)
        {
            try
            {

                //===================================================================================================
                // DECLARACION DE VARIABLES  (ID_SISTEMA=13 CORRESPONDE AL SISTEMA DE SOLICITUD CREADO EN PRODUCTOS)                     
                //===================================================================================================
                SMetodos Servicio = new SMetodos();
                String CODIGO = "ALO_CARGA";
                SRestfulAPI ServicioAPI = new SRestfulAPI();

                //===========================================================
                // ENVIA POST                         
                //===========================================================
                URLWeb(UConfiguracion.RutaLearning, CODIGO, "COLA", "ALO_LEARNING_FORM");

            }
            catch
            {
                MensajeLOG("NO SE PUEDE DIRECCIONAR AL SITIO DE AYUDA", "MENSAJE:");

            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnConector_Click(object sender, EventArgs e)
        {
            try
            {

                //===================================================================================================
                // DECLARACION DE VARIABLES 
                //===================================================================================================
                SMetodos Servicio = new SMetodos();
                String CODIGO = "ALO_CARGA";

                //===========================================================
                // ENVIA POST                         
                //===========================================================
                URLWeb(UConfiguracion.RutaConector, CODIGO, "COLA", "ALO_CONECTOR_FORM");

            }
            catch
            {
                MensajeLOG("NO SE PUEDE DIRECCIONAR AL SITIO CONECTORES", "MENSAJE:");

            }

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
        /// LLAMARA URL LEARNING
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="TOKEN"></param>
        /// <param name="COLA"></param>
        /// <param name="NameForm"></param>
        private void URLWeb(string URL, string CODIGO, string COLA, string NameForm)
        {

            try
            {
                //===========================================================
                // FABRICAR SENTENCIA                   
                //===========================================================
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("function FLea(){");
                sb.Append("Levantar_Page_Learning('" + URL + "'," + "'" + CODIGO + "'," + "'" + COLA + "','" + NameForm + "');");
                sb.Append("Sys.Application.remove_load(FLea);}");
                sb.Append("Sys.Application.add_load(FLea);");
                sb.Append("</script>");


                ScriptManager.RegisterStartupScript(this, typeof(Page), "PageLearning", sb.ToString(), false);



            }
            catch { }

        }

        /// <summary>
        /// LOGOUT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Logout_Click(Object sender, EventArgs e)
        {

            try
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
                Session.Clear();
                FormsAuthentication.RedirectToLoginPage();


            }
            catch { }

        }

        /// <summary>
        /// RESOLVER URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string ResolveURL(string url)
        {
            var resolvedURL = this.Page.ResolveClientUrl(url);
            return resolvedURL;
        }


        /// <summary>
        /// RESOLVER URL
        /// </summary>
        /// <param name="cssURL"></param>
        /// <returns></returns>
        public string Href(string cssURL)
        {
            return ResolveURL(cssURL);
        }


        /// <summary>
        /// RESOLVER URL CSS
        /// </summary>
        /// <param name="cssURL"></param>
        /// <returns></returns>
        public string CSSLink(string cssURL)
        {
            return string.Format("<link href='{0}' rel='stylesheet' type='text/css'/>",
                        ResolveURL(cssURL));
        }


        /// <summary>
        /// RESOLVER URL JS
        /// </summary>
        /// <param name="jsURL"></param>
        /// <returns></returns>
        public string JSLink(string jsURL)
        {
            return string.Format("<script src='{0}' type='text/javascript'></script>",
                        ResolveURL(jsURL));
        }


        /// <summary>
        /// RESOLVER URL IMAGEN
        /// </summary>
        /// <param name="IMGURL"></param>
        /// <returns></returns>
        public string IMGLink(string IMGURL)
        {
            return string.Format("<img src='{0}'></img>",
                        ResolveURL(IMGURL));
        }
    }
       
 
}
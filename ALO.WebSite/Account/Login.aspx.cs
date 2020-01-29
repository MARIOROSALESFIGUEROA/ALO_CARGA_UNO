using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALO.Entidades;
using ALO.Servicio;
using ALO.Utilidades;


namespace ALO.WebSite.Account
{
    public partial class Login : System.Web.UI.Page
    {


        /// <summary>
        /// AL INICIAR LA PAGINA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {



                if (!this.IsPostBack)
                {

                    BuscarPasswordCook();

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







        /// <summary>
        /// BUSCAR DATOS DEL PASSWORD EN COOKIES
        /// </summary>
        private void BuscarPasswordCook()
        {

            try
            {

                //===========================================================
                //  SI EXISTE LA COOKIE Y EL USUARIO SOLICITO RECORDAR     
                //===========================================================
                if (HttpContext.Current.Request.Cookies[Globales.Cookie] != null)
                {


                    string Checked = HttpContext.Current.Request.Cookies[Globales.Cookie]["Checked"] ?? 0.ToString();
                    string PASSWORD = UCryptorEngine.Desencriptar(HttpContext.Current.Request.Cookies[Globales.Cookie]["PASSWORD"]) ?? string.Empty;
                    string LOGIN = UCryptorEngine.Desencriptar(HttpContext.Current.Request.Cookies[Globales.Cookie]["LOGIN"]) ?? string.Empty;


                    //=======================================================
                    //  LLENAR OBJETOS                                     
                    //=======================================================
                    bool Recordar = Convert.ToBoolean(Convert.ToInt32(Checked));


                    if (Recordar == true)
                    {
                        TXT_LOGIN.Text = LOGIN;
                        RememberMe.Checked = Convert.ToBoolean(Convert.ToInt32(Checked));
                        TXT_PASSWORD.Attributes.Add("value", PASSWORD);


                    }

                }




            }
            catch
            {
                throw;
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
                LOG_MENSAJE_SERVER.InnerHtml = System.Net.WebUtility.HtmlDecode(Mensaje);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "PopupJS", "MensajeLOG('" + Titulo + "');", true);



            }
            catch { }


        }


        /// <summary>
        /// LOGIN DE USUARIO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_Login_Click(object sender, EventArgs e)
        {

            try
            {
                //===========================================================
                // ACCESO AL SERVICIO                                      
                //===========================================================
                SMetodos Servicio = new SMetodos();



                //===========================================================
                // VALIDACION DE CONTROLES                                 ==
                //===========================================================
                if (string.IsNullOrEmpty(TXT_LOGIN.Text) == true)
                {
                    MensajeLOG("NO HA INGRESADO LOGIN A VALIDAR", "VALIDACIÓN DE LOGIN");
                    return;
                }

                if (string.IsNullOrEmpty(TXT_PASSWORD.Text) == true)
                {
                    MensajeLOG("NO HA PASSWORD A VALIDAR", "VALIDACIÓN DE LOGIN");
                    return;
                }





                //===========================================================
                // ASIGNACION DE VALORES DE CREACION DE CUENTA             ==
                //===========================================================
                string LOGIN = TXT_LOGIN.Text;
                string PASSWORD = TXT_PASSWORD.Text;


                //===========================================================
                // ASIGNACION DE VALORES DE CREACION DE CUENTA             ==
                //===========================================================
                iSP_VALIDATE_USUARIO ParametrosInput = new iSP_VALIDATE_USUARIO();
                ParametrosInput.LOGIN = LOGIN;
                ParametrosInput.PASSWORD = PASSWORD;

                //===========================================================
                // LLAMADA DEL SERVICIO                                  
                //===========================================================
                oSP_RETURN_STATUS ObjetoRest = Servicio.SP_VALIDATE_USUARIO(ParametrosInput);




                //===========================================================
                // RESPUESTA SERVICIO                                    
                //===========================================================
                if (ObjetoRest.RETURN_VALUE == -4)
                {

                    MensajeLOG("INSTITUCIÓN NO EXISTE EN SISTEMA", "ERROR LOGIN");
                    return;
                }


                if (ObjetoRest.RETURN_VALUE == -3)
                {

                    MensajeLOG("INSTITUCIÓN NO ESTA VIGENTE EN SISTEMA", "ERROR LOGIN");
                    return;
                }

                if (ObjetoRest.RETURN_VALUE == -2)
                {

                    MensajeLOG("USUARIO NO EXISTE EN SISTEMA", "ERROR LOGIN");
                    return;
                }


                if (ObjetoRest.RETURN_VALUE == -1)
                {

                    MensajeLOG("USUARIO ENVIADO NO ESTA VINCULADO A INSTITUCIÓN", "ERROR LOGIN");
                    return;
                }


                if (ObjetoRest.RETURN_VALUE == 0)
                {

                    MensajeLOG("PASSWORD NO COINCIDE", "ERROR LOGIN");
                    return;
                }


                if (ObjetoRest.RETURN_VALUE == 1)
                {


                    HttpCookie cookie = new HttpCookie(Globales.Cookie);
                    Response.Cookies.Remove(Globales.Cookie);


                    cookie.Values.Add("LOGIN", UCryptorEngine.Encriptar(LOGIN));
                    cookie.Values.Add("PASSWORD", UCryptorEngine.Encriptar(PASSWORD));



                    if (RememberMe.Checked == true)
                    {
                        cookie.Values.Add("Checked", "1");
                        cookie.Expires = DateTime.Now.AddDays(365);

                    }
                    else
                    {
                        cookie.Values.Add("Checked", "0");
                        cookie.Expires = DateTime.Now.AddDays(-1D);

                    }

                    Response.Cookies.Add(cookie);
                    UsuariosSession(LOGIN);
                    FormsAuthentication.RedirectFromLoginPage(LOGIN, false);
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




        /// <summary>
        /// USUARIO POR LOGIN
        /// </summary>
        /// <param name="LOGIN"></param>
        /// <returns></returns>
        private bool UsuariosSession(string LOGIN)
        {

            try
            {



                //===========================================================
                // DECLARACION DE VARIABLES                                ==
                //===========================================================
                SMetodos Servicio = new SMetodos();
                List<oSP_READ_USUARIO_X_LOGIN> ListaRest = new List<oSP_READ_USUARIO_X_LOGIN>();


                //===========================================================
                // PARAMETROS INPUT                                        ==
                //===========================================================
                iSP_READ_USUARIO_X_LOGIN ParametrosInput = new iSP_READ_USUARIO_X_LOGIN();
                ParametrosInput.LOGIN = LOGIN;



                //===========================================================
                // LLAMADA DEL SERVICIO                                    ==
                //===========================================================
                ListaRest = Servicio.SP_READ_USUARIO_X_LOGIN(ParametrosInput);


                if (ListaRest == null)
                {
                    throw new EServiceRestFulException("SERVICIO NO DEVOLVIO INFORMACIÓN REFERENTE AL LOGIN");
                }



                if (ListaRest.Count > 0)
                {



                    HttpCookie miCookie = new HttpCookie(Globales.CookieGlobal);
                    Response.Cookies.Remove(Globales.CookieGlobal);

                    miCookie.Values.Add("USER_ID_USUARIO", ListaRest.First().ID_USUARIO.ToString());
                    miCookie.Values.Add("USER_NOMBRE", WebUtility.HtmlDecode(ListaRest.First().NOMBRE));
                    miCookie.Values.Add("USER_LOGIN", ListaRest.First().LOGIN);
                    Response.Cookies.Add(miCookie);




                }
                else
                {

                    throw new EServiceRestFulException("SERVICIO NO DEVOLVIO INFORMACIÓN REFERENTE AL LOGIN");
                }



                return true;
            }
            catch
            {
                throw;
            }


        }


        /// <summary>
        /// RESOLVER URL DINAMICA
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string ResolveURL(string url)
        {
            var resolvedURL = this.Page.ResolveClientUrl(url);
            return resolvedURL;
        }

        /// <summary>
        /// RESOLVER URL DINAMICA
        /// </summary>
        /// <param name="cssURL"></param>
        /// <returns></returns>
        public string Href(string cssURL)
        {
            return ResolveURL(cssURL);
        }

        /// <summary>
        /// RESOLVER URL DINAMICA
        /// </summary>
        /// <param name="cssURL"></param>
        /// <returns></returns>
        public string CSSLink(string cssURL)
        {
            return string.Format("<link href='{0}' rel='stylesheet' type='text/css'/>",
                        ResolveURL(cssURL));
        }



        /// <summary>
        /// RESOLVER URL DINAMICA
        /// </summary>
        /// <param name="jsURL"></param>
        /// <returns></returns>
        public string JSLink(string jsURL)
        {
            return string.Format("<script src='{0}' type='text/javascript'></script>",
                        ResolveURL(jsURL));
        }


        /// <summary>
        /// RESOLVER URL DINAMICA
        /// </summary>
        /// <param name="IMGURL"></param>
        /// <returns></returns>
        public string IMGLink(string IMGURL)
        {
            return string.Format("<img src='{0}' />",
                        ResolveURL(IMGURL));
        }


        /// <summary>
        /// RESOLVER URL DINAMICA
        /// </summary>
        /// <param name="jsURL"></param>
        /// <returns></returns>
        public string UrlWeb(string jsURL)
        {
            return ResolveURL(jsURL);
        }



    }
}
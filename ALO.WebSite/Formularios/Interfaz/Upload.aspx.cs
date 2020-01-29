using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALO.Servicio;
using ALO.Entidades;

namespace ALO.WebSite.Formularios.Interfaz
{
    public partial class Upload : System.Web.UI.Page
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


                if (!this.IsPostBack)
                {
                    BTN_VOLVER.Visible = false;
                    string OPCION = "";
                    string CODIGO_INTERFAZ = "";
                    int ID_INTERFAZ = 0;
                    int ID_GRUPO_CARGA = 0;                   

                    if ((Request.QueryString["OPCION"] != null) && (Request.QueryString["CODIGO_INTERFAZ"] != null) && (Request.QueryString["ID_INTERFAZ"] != null))
                    {
                        OPCION = Request.QueryString["OPCION"].ToString();
                        CODIGO_INTERFAZ = Request.QueryString["CODIGO_INTERFAZ"].ToString();
                        ID_INTERFAZ = Convert.ToInt32(Request.QueryString["ID_INTERFAZ"].ToString());

                        HD_OPCION.Value = OPCION;
                        HD_CODIGO_INTERFAZ.Value = CODIGO_INTERFAZ;
                        HD_ID_INTERFAZ.Value = ID_INTERFAZ.ToString();

                        if (OPCION.Equals("I"))
                        {
                            if (Request.QueryString["ID_GRUPO_CARGA"] != null)
                            {
                                ID_GRUPO_CARGA = Convert.ToInt32(Request.QueryString["ID_GRUPO_CARGA"].ToString());

                                HD_ID_GRUPO_CARGA.Value = ID_GRUPO_CARGA.ToString();
                            }
                        }

                        //SMetodos Negocio = new SMetodos();
                        //List<oSP_READ_INTERFAZ> ListaInterfaz = new List<oSP_READ_INTERFAZ>();

                        //oSP_READ_INTERFAZ INTERFAZ = new oSP_READ_INTERFAZ();

                        //ListaInterfaz = Negocio.SP_READ_INTERFAZ(new iSP_READ_INTERFAZ { ID_INTERFAZ = ID_INTERFAZ });


                        //if (ListaInterfaz == null && ListaInterfaz.Count <= 0)
                        //{
                        //    throw new Exception("NO EXISTEN DATOS DE LA INTERFAZ EN EL SISTEMA");
                        //}

                        //INTERFAZ = ListaInterfaz.First();
                        LBL_MENSAJE.Text = "SUBIDA DE ARCHIVOS PARA LA INTERFAZ CON CODIGO : " + CODIGO_INTERFAZ;
                        
                        
                        

                    }
                    else
                    {
                        LBL_MENSAJE.Text = "NO SE HA ENVIADO INFORMACION SOBRE LA INTERFAZ.";
                    }

                }



            }
            catch (System.Exception ex)
            {

                LBL_MENSAJE.Text = ALO.WebSite.Error.ThrowError.MensajeThrow(ex);
                //MensajeLOG(ALO.WebSite.Error.ThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");

            }
        }

        protected void BTN_VOLVER_Click(object sender, EventArgs e)
        {
            try
            {
                string OPCION = HD_OPCION.Value;

                if (OPCION.Equals("I"))
                {
                    Response.Redirect("~/EJECUCION/EJECUCION");
                }

                if (OPCION.Equals("P"))
                {
                    //Response.Write("<script> window.open('~/PROYECTO/PROYECTO','_blank'); </script>");
                    Response.Redirect("~/PROYECTO/PROYECTO");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
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
        /// RESOLVER URL RUTA 
        /// </summary>
        /// <param name="jsURL"></param>
        /// <returns></returns>
        public string UrlWeb(string jsURL)
        {
            return ResolveURL(jsURL);
        }



    }
}
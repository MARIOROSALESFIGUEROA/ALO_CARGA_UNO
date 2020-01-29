using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ALO.Entidades;
using ALO.Servicio;
using ALO.Utilidades;

namespace ALO.WebSite.Formularios.Proceso
{
    public partial class Proceso : System.Web.UI.Page
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

                GRDData.PreRender += new EventHandler(GRDData_PreRender);
                //===========================================================
                // POSTBACK                                               
                //===========================================================
                if (!this.IsPostBack)
                {


                    //======================================================
                    // FECHAS POR DEFECTO                                 
                    //======================================================
                    TXT_FECHA_INI.Text = DateTime.Now.ToString("dd/MM/yyyy");

                    tm.Enabled = false;
                    LeerTimer();
                    PNL_MENSAJE.Visible = false;

                    DibujarGrillaDatos();

                    //int ID_INSTITUCION = Globales.DATOS_COOK().ID_INSTITUCION;
                    //LEER_CAMPANA(ID_INSTITUCION);



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
        /// GRILLA PRERENDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDData_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRDData.UseAccessibleHeader = true;
                GRDData.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
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
                MSG_ALERTA.InnerHtml = WebUtility.HtmlDecode(Mensaje);
                PNL_MENSAJE.Visible = true;
            }
            catch { }
        }

        /// <summary>
        /// LEER TIMER
        /// </summary>
        private void LeerTimer()
        {
            try
            {
                //===========================================================
                // ESTADOS                                                       
                //===========================================================
                List<Item_Seleccion> Lista = new List<Item_Seleccion>();
                Lista.Add(new Item_Seleccion { Id = 0, Nombre = "SIN TIMER" });
                Lista.Add(new Item_Seleccion { Id = 5000, Nombre = "5 SEGUNDOS" });
                Lista.Add(new Item_Seleccion { Id = 10000, Nombre = "10 SEGUNDOS" });
                Lista.Add(new Item_Seleccion { Id = 15000, Nombre = "15 SEGUNDOS" });
                FuncionesGenerales.CDDLCombos(Lista, DDL_TIMER);
            }
            catch
            {
                throw;
            }


        }
        /// <summary>
        /// LEER PROCESOS
        /// </summary>
        //private void LeerProcesos()
        //{

        //    try
        //    {

        //        PNL_MENSAJE.Visible = false;

        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        List<oSP_READ_EJECUCION_X_PROCESO> LST_REST = new List<oSP_READ_EJECUCION_X_PROCESO>();
        //        SMetodos Servicio = new SMetodos();

        //        //===========================================================
        //        // PARAMETROS DE ENTRADA 
        //        //===========================================================
        //        iSP_READ_EJECUCION_X_PROCESO ParametrosInput = new iSP_READ_EJECUCION_X_PROCESO();
        //        ParametrosInput.NRO_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
        //        ParametrosInput.FECHA_CREACION = Convert.ToDateTime(TXT_FECHA_INI.Text);




        //        //===========================================================
        //        // LLAMADA DEL SERVICIO
        //        //===========================================================
        //        LST_REST = Servicio.SP_READ_EJECUCION_X_PROCESO(ParametrosInput);



        //        //===========================================================
        //        // EVALUAR RETORNO
        //        //===========================================================
        //        if (LST_REST == null)
        //        {
        //            DibujarGrillaDatos();
        //            return;
        //        }
        //        if (LST_REST.Count <= 0)
        //        {
        //            DibujarGrillaDatos();
        //            return;
        //        }


        //        FuncionesGenerales.Cargar_Grilla(LST_REST, GRDData);
        //    }
        //    catch (EServiceRestFulException srv)
        //    {
        //        MensajeLOG(srv.Message, "ERRORES DE SERVICIO");
        //    }
        //    catch (System.Exception ex)
        //    {
        //        MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
        //    }


        //}    

        /// <summary>
        /// LEER INTERFAZ POR CLUSTER
        /// </summary>
        private void LEER_INTERFAZ_X_CLUSTER(int ID_CLUSTER)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                SMetodos Servicio = new SMetodos();
                List<Item_Seleccion> Lista = new List<Item_Seleccion>();

                //===========================================================
                // TRAER LISTA DE EMPRESAS REGISTRADAS EN SISTEMA               
                //===========================================================
                List<oSP_READ_INTERFAZ_X_CLUSTER> ListaInterfazEmpresa = new List<oSP_READ_INTERFAZ_X_CLUSTER>();
                ListaInterfazEmpresa = Servicio.SP_READ_INTERFAZ_X_CLUSTER(new iSP_READ_INTERFAZ_X_CLUSTER { ID_CLUSTER = ID_CLUSTER });

                foreach (oSP_READ_INTERFAZ_X_CLUSTER item in ListaInterfazEmpresa)
                {
                    Lista.Add(new Item_Seleccion { Id = item.ID_INTERFAZ, Nombre = item.CODIGO_INTERFAZ });
                }

                FuncionesGenerales.CDDLCombos(Lista, DDL_INTERFAZ);

                DDL_INTERFAZ_SelectedIndexChanged(null, null);

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// DIBUJAR GRILLA DE DATOS
        /// </summary>
        private void DibujarGrillaDatos()
        {

            try
            {

                //List<oSP_READ_EJECUCION_X_PROCESO> Lista = new List<oSP_READ_EJECUCION_X_PROCESO>();
                //for (int i = 1; i <= 1; i++)
                //{
                //    Lista.Add(new oSP_READ_EJECUCION_X_PROCESO());
                //}
                //FuncionesGenerales.Cargar_Grilla(Lista, GRDData);


            }
            catch
            {

                throw;

            }




        }

        /// <summary>
        /// COMBO DE TIEMPOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_TIMER_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //===========================================================
                // OPCION                                                       
                //===========================================================
                int OPCION = -1;
                OPCION = Convert.ToInt32(DDL_TIMER.SelectedValue);

                //===========================================================
                //SI LA OPCION ES 0 DETENGO EL TIMER                            
                //===========================================================
                if (OPCION == 0)
                {
                    tm.Enabled = false;
                }
                else
                {
                    tm.Enabled = true;
                    tm.Interval = OPCION;
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
        /// BUSCAR CONSULTA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BNT_BUSCAR_Click(object sender, EventArgs e)
        {
            try
            {
                //LeerProcesos();
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
        /// AL SELECCIONAR CAMPAÑA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_CAMPANA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDL_CAMPANA.Items.Count > 0)
                {
                    int ID_CAMPANA = Convert.ToInt32(DDL_CAMPANA.SelectedValue);
                    
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
        /// AL SELECCIONAR INTERFAZ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_INTERFAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {


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
        /// TIMER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void tm_Tick(object sender, EventArgs e)
        {
            try
            {
                Thread.Sleep(1000);
                //LeerProcesos();

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
        /// URL WEB
        /// </summary>
        /// <param name="jsURL"></param>
        /// <returns></returns>
        public string UrlWeb(string jsURL)
        {
            return ResolveURL(jsURL);
        }

    }
}
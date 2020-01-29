using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ALO.Entidades;
using ALO.Servicio;
using ALO.Utilidades;

namespace ALO.WebSite.Formularios.Ejecucion
{
    public partial class Ejecucion : System.Web.UI.Page
    {
        /// <summary>
        /// AL INICIAR APLICACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {


                GRDData.PreRender += new EventHandler(GRDData_PreRender);
                GRDDataGrupo.PreRender += new EventHandler(GRDDataGrupo_PreRender);
                GRDDataDetalleGrupo.PreRender += new EventHandler(GRDDataDetalleGrupo_PreRender);
                GRD_PROCESOS.PreRender += new EventHandler(GRD_PROCESOS_PreRender);
                

                //===========================================================
                // POSTBACK                                               
                //===========================================================
                if (!this.IsPostBack)
                {
                    Establecer_Globales();

                    DibujarGrillaDatos();
                    DibujarGrillaDatosGrupo();
                    DibujarGrillaDatosDetalleGrupo();
                    CARGAR_COMBO_CLUSTER();
                    LEER_PROCESOS();

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
        /// CARGAR COMBO CLÚSTER
        /// </summary>
        private void CARGAR_COMBO_CLUSTER()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                int ID_USURIO = Globales.DATOS_COOK().ID_USUARIO;
                SMetodos Negocio = new SMetodos();
                List<oSP_READ_CLUSTER_VALIDACION> ListaCluster = new List<oSP_READ_CLUSTER_VALIDACION>();

                iSP_READ_CLUSTER_VALIDACION USUARIO = new iSP_READ_CLUSTER_VALIDACION();
                USUARIO.ID_USUARIO = ID_USURIO;


                //===========================================================
                // LLAMADA DEL SERVICIO                                    ==
                //===========================================================                
                ListaCluster = Negocio.SP_READ_CLUSTER_VALIDACION(USUARIO);


                if (ListaCluster == null)
                {
                    FuncionesGenerales.CDDLCombos(null, DDL_SELECT_CLUSTER);
                    return;
                }
                if (ListaCluster.Count <= 0)
                {
                    FuncionesGenerales.CDDLCombos(null, DDL_SELECT_CLUSTER);
                    return;
                }

                List<Item_Seleccion> Lista = new List<Item_Seleccion>();
                Lista = ListaCluster.OrderBy(p => p.ID_CLUSTER).Select(p => new Item_Seleccion { Id = p.ID_CLUSTER, Nombre = p.CODIGO }).ToList();

                Lista.Add(new Item_Seleccion { Id = 0, Nombre = "SELECCIONE VALOR" });
                Lista = Lista.OrderBy(x => x.Id).ToList();
                FuncionesGenerales.CDDLCombos(Lista, DDL_SELECT_CLUSTER);


            }
            catch
            {
                throw;
            }


        }


        /// <summary>
        /// AL SELECCIONAR CLUSTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_CLUSTER_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDL_SELECT_CLUSTER.Items.Count > 0)
                {
                    int ID_CLUSTER = Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue);
                    LEER_GRUPOS(ID_CLUSTER);
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
        /// VIEWSTATE PARA VARIABLES GLOBALES
        /// </summary>
        private void Establecer_Globales()
        {
            try
            {
                ViewState["GlobalesEjecucion"] = new GlobalesEjecucion();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// VIEWSTATE PARA VARIABLES GLOBALES
        /// </summary>
        /// <returns>Objeto que maneja todos las propiedades del ViewState</returns>
        private GlobalesEjecucion V_Global()
        {


            GlobalesEjecucion item = new GlobalesEjecucion();
            try
            {

                item = (GlobalesEjecucion)ViewState["GlobalesEjecucion"] ?? null;
                return item;
            }
            catch
            {
                return item;
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
        /// GRILLA PRERENDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDDataDetalleGrupo_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRDDataDetalleGrupo.UseAccessibleHeader = true;
                GRDDataDetalleGrupo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }

        /// <summary>
        /// GRILLA PRERENDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRD_PROCESOS_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRD_PROCESOS.UseAccessibleHeader = true;
                GRD_PROCESOS.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }

        /// <summary>
        /// GRILLA PRERENDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDDataGrupo_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRDDataGrupo.UseAccessibleHeader = true;
                GRDDataGrupo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }

        /// <summary>
        /// FORMULARIO JS
        /// </summary>
        /// <param name="CONTENEDOR">ID de la etiqueta que va contener el modal</param>
        /// <param name="DIV_INFO">ID de la etiqueta al cual se le va pasar el mensaje en caso positivo</param>
        /// <param name="DIV_ALERTA">ID de la etiqueta al cual se le va pasar el mensaje en caso de error</param>
        private void FormularioModalJS(string CONTENEDOR, string DIV_INFO, string DIV_ALERTA)
        {

            try
            {

                //===========================================================
                // LLAMAR MODAL POR OPCIONES                          
                //===========================================================
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("function FMOE(){");
                sb.Append("FormularioModalJS('" + CONTENEDOR + "','" + DIV_INFO + "','" + DIV_ALERTA + "');");
                sb.Append("Sys.Application.remove_load(FMOE);}");
                sb.Append("Sys.Application.add_load(FMOE);");
                sb.Append("</script>");


                ScriptManager.RegisterStartupScript(this, typeof(Page), "PopupJSEdit", sb.ToString(), false);



            }
            catch { }

        }


        /// <summary>
        /// MENSAJE LOG EDIT
        /// </summary>
        /// <param name="Opcion">I = informativo, A = Alerta</param>
        /// <param name="Mensaje">Mensaje a mostrar</param>
        /// <param name="DIV_INFO">ID de la etiqueta al cual se le va pasar el mensaje en caso positivo</param>
        /// <param name="DIV_ALERTA">ID de la etiqueta al cual se le va pasar el mensaje en caso de error</param>
        private void MensajeLOGEdit(string Opcion, string Mensaje, string DIV_INFO, string DIV_ALERTA)
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
                sb.Append("function FM(){");
                sb.Append("MensajeLOGEdit('" + Opcion + "','" + DIV_INFO + "','" + DIV_ALERTA + "');");
                sb.Append("Sys.Application.remove_load(FM);}");
                sb.Append("Sys.Application.add_load(FM);");
                sb.Append("</script>");


                ScriptManager.RegisterStartupScript(this, typeof(Page), "PopupJSEdit", sb.ToString(), false);



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
        /// DIBUJAR GRILLA DE DATOS
        /// </summary>
        private void DibujarGrillaDatos()
        {
            try
            {
                List<oSP_READ_EJECUCION_X_FILTRO> Lista = new List<oSP_READ_EJECUCION_X_FILTRO>();
                for (int i = 1; i <= 1; i++)
                {
                    Lista.Add(new oSP_READ_EJECUCION_X_FILTRO());
                }
                FuncionesGenerales.Cargar_Grilla(Lista, GRDData);
            }
            catch
            {

                throw;

            }
        }

        /// <summary>
        /// DIBUJAR GRILLA DE DATOS
        /// </summary>
        private void DibujarGrillaDatosProceso()
        {
            try
            {
                List<oSP_READ_EJECUCION_X_FILTRO> Lista = new List<oSP_READ_EJECUCION_X_FILTRO>();
                for (int i = 1; i <= 1; i++)
                {
                    Lista.Add(new oSP_READ_EJECUCION_X_FILTRO());
                }
                FuncionesGenerales.Cargar_Grilla(Lista, GRD_PROCESOS);
            }
            catch
            {

                throw;

            }
        }

        /// <summary>
        /// DIBUJAR GRILLA DE DATOS
        /// </summary>
        private void DibujarGrillaDatosDetalleGrupo()
        {
            try
            {
                List<oSP_READ_DETALLE_GRUPO_CARGA_WEB> Lista = new List<oSP_READ_DETALLE_GRUPO_CARGA_WEB>();
                for (int i = 1; i <= 1; i++)
                {
                    Lista.Add(new oSP_READ_DETALLE_GRUPO_CARGA_WEB());
                }
                FuncionesGenerales.Cargar_Grilla(Lista, GRDDataDetalleGrupo);
            }
            catch
            {

                throw;

            }
        }

        /// <summary>
        /// DIBUJAR GRILLA DE DATOS
        /// </summary>
        private void DibujarGrillaDatosGrupo()
        {
            try
            {
                List<oSP_READ_GRUPO_CARGA> Lista = new List<oSP_READ_GRUPO_CARGA>();
                for (int i = 1; i <= 1; i++)
                {
                    Lista.Add(new oSP_READ_GRUPO_CARGA());
                }
                FuncionesGenerales.Cargar_Grilla(Lista, GRDDataGrupo);
            }
            catch
            {

                throw;

            }
        }


        /// <summary>
        /// LEER GRUPOS DE CARGA
        /// </summary>
        private void LEER_GRUPOS(int ID_CLUSTER)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_GRUPO_CARGA> LST_REST = new List<oSP_READ_GRUPO_CARGA>();
                SMetodos Servicio = new SMetodos();

                //===========================================================
                // PARAMETROS DE ENTRADA 
                //===========================================================
                iSP_READ_GRUPO_CARGA ParametrosInput = new iSP_READ_GRUPO_CARGA();
                ParametrosInput.ID_CLUSTER = ID_CLUSTER;

                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                LST_REST = Servicio.SP_READ_GRUPO_CARGA(ParametrosInput);

                //===========================================================
                // EVALUAR RETORNO
                //===========================================================
                if (LST_REST == null)
                {
                    DibujarGrillaDatosGrupo();
                    return;
                }

                if (LST_REST.Count <= 0)
                {
                    DibujarGrillaDatosGrupo();
                    return;
                }

                FuncionesGenerales.Cargar_Grilla(LST_REST, GRDDataGrupo);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LEER GRUPOS DE CARGA
        /// </summary>
        private void LEER_DETALLE_GRUPOS(int ID_GRUPO_CARGA)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_DETALLE_GRUPO_CARGA_WEB> LST_REST = new List<oSP_READ_DETALLE_GRUPO_CARGA_WEB>();
                SMetodos Servicio = new SMetodos();

                //===========================================================
                // PARAMETROS DE ENTRADA 
                //===========================================================
                iSP_READ_DETALLE_GRUPO_CARGA_WEB ParametrosInput = new iSP_READ_DETALLE_GRUPO_CARGA_WEB();
                ParametrosInput.ID_GRUPO_CARGA = ID_GRUPO_CARGA;

                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                LST_REST = Servicio.SP_READ_DETALLE_GRUPO_CARGA(ParametrosInput);

                //===========================================================
                // EVALUAR RETORNO
                //===========================================================
                if (LST_REST == null && LST_REST.Count <= 0)
                {
                    V_Global().DetalleGrupo = new List<oSP_READ_DETALLE_GRUPO_CARGA_WEB>();                    
                }
                {                    
                    V_Global().DetalleGrupo = LST_REST;
                }

                

                FuncionesGenerales.Cargar_Grilla(LST_REST, GRDDataDetalleGrupo);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LEER DETALLES DE EJECUCION
        /// </summary>
        private void LEER_PROCESO_X_EJECUCION(int ID_EJECUCION)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_PROCESO_X_EJECUCION> LST_REST = new List<oSP_READ_PROCESO_X_EJECUCION>();
                SMetodos Servicio = new SMetodos();

                //===========================================================
                // PARAMETROS DE ENTRADA 
                //===========================================================
                iSP_READ_PROCESO_X_EJECUCION ParametrosInput = new iSP_READ_PROCESO_X_EJECUCION();
                ParametrosInput.ID_EJECUCION = ID_EJECUCION;

                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                LST_REST = Servicio.SP_READ_PROCESO_X_EJECUCION(ParametrosInput);

                //===========================================================
                // EVALUAR RETORNO
                //===========================================================
                if (LST_REST != null && LST_REST.Count > 0)
                {
                    V_Global().ListaEjecucion = LST_REST;
                }
                else
                {
                    V_Global().ListaEjecucion = new List<oSP_READ_PROCESO_X_EJECUCION>();
                }

            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// LEER DETALLES DE EJECUCION
        /// </summary>
        private void CARGAR_GRILLA_EJECUCIONES()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_PROCESO_X_EJECUCION> LST_REST = new List<oSP_READ_PROCESO_X_EJECUCION>();


                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                LST_REST = V_Global().ListaEjecucion;

                //===========================================================
                // EVALUAR RETORNO
                //===========================================================
                if (LST_REST == null)
                {
                    DibujarGrillaDatos();
                    return;
                }
                if (LST_REST.Count <= 0)
                {
                    DibujarGrillaDatos();
                    return;
                }

                //int ID_PROCESO = 0;

                //foreach (oSP_READ_PROCESO_X_EJECUCION item in LST_REST)
                //{
                //    if (item.ID_PROCESO == 0)
                //    {
                //        ID_PROCESO = 1;
                //        break;
                //    }
                //}

                //if (ID_PROCESO != 0)
                //{
                //    LST_REST = new List<oSP_READ_PROCESO_X_EJECUCION>();
                //}


                FuncionesGenerales.Cargar_Grilla(LST_REST, GRDData);
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// GRILLA ROWCOMMAND
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDDataGrupo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //===========================================================
                // ID                                                           
                //===========================================================          
                int ID_GRUPO_CARGA = Convert.ToInt32(e.CommandArgument);

                if (ID_GRUPO_CARGA == 0) { return; }

                //===========================================================
                // DECLARACION DE VARIAVLES 
                //=========================================================== 
                SMetodos Servicio = new SMetodos();

                //===========================================================
                // BUSCAR DETALLES                     
                //===========================================================
                if (e.CommandName == "BuscarDetalle")
                {
                    int ID_CLUSTER = 0;

                    if (Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue) > 0)
                    {
                        ID_CLUSTER = Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue);

                        LEER_GRUPOS(ID_CLUSTER);                        
                    }

                    LEER_DETALLE_GRUPOS(ID_GRUPO_CARGA);
                }

                //===========================================================
                // REINICIAR A EJECUCION                          
                //===========================================================
                if (e.CommandName == "Reinicia")
                {
                    //===========================================================
                    // DECLARACION DE VARIABLES
                    //===========================================================
                    List<oSP_READ_DETALLE_GRUPO_CARGA_WEB> ListaDetalle = new List<oSP_READ_DETALLE_GRUPO_CARGA_WEB>();
                    List<oSP_READ_EJECUCION_X_FILTRO> ListaEjecucion = new List<oSP_READ_EJECUCION_X_FILTRO>();
                    int ID_CLUSTER = 0;

                    //===========================================================
                    // VALIDACION DE SELECCION DE CLUSTER
                    //===========================================================
                    if (Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue) == 0)
                    {
                        MensajeLOG("DEBES SELECCIONAR UN CLUSTER", "EJECUCIÓN");
                        return;
                    }
                    else
                    {
                        ID_CLUSTER = Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue);
                    }

                    //===========================================================
                    // CONSTRUCCION DE OBJETO
                    //===========================================================
                    iSP_READ_DETALLE_GRUPO_CARGA_WEB ParametrosInput = new iSP_READ_DETALLE_GRUPO_CARGA_WEB();
                    ParametrosInput.ID_GRUPO_CARGA = ID_GRUPO_CARGA;


                    //===========================================================
                    // LLAMADA A SERVICIO 
                    //===========================================================
                    ListaDetalle = Servicio.SP_READ_DETALLE_GRUPO_CARGA(ParametrosInput);


                    //===========================================================
                    // RECORREMOS LA LISTA DE DETALLES DE GRUPO DE CARGA
                    //===========================================================
                    foreach (oSP_READ_DETALLE_GRUPO_CARGA_WEB item in ListaDetalle)
                    {
                        int ID_INTERFAZ = item.ID_INTERFAZ;

                        //=======================================================
                        // CONSTRUCCION DE OBJETO ESTADO_INTERFAZ
                        //=======================================================
                        iSP_UPDATE_ESTADO_PROCESO_X_EJECUCION ParametrosInputEstadoProceso = new iSP_UPDATE_ESTADO_PROCESO_X_EJECUCION();
                        ParametrosInputEstadoProceso.ID_EJECUCION = item.ID_EJECUCION;
                        ParametrosInputEstadoProceso.ID_ESTADO = (int)T_ESTADO_PROCESO.SIN_ESTADO;
                        ParametrosInputEstadoProceso.MENSAJE = " ";

                        //=======================================================
                        // LLAMADA A SERVICIO
                        //=======================================================
                        oSP_RETURN_STATUS ESTADO_PROCESO = Servicio.SP_UPDATE_ESTADO_PROCESO_X_EJECUCION(ParametrosInputEstadoProceso);

                        //===========================================================
                        // CONSTRUCCION DE OBJETO
                        //===========================================================
                        iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO ParametrosInputEstadoGrupo = new iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO();
                        ParametrosInputEstadoGrupo.ID_DETALLE_GRUPO_CARGA = item.ID_DETALLE_GRUPO_CARGA;
                        ParametrosInputEstadoGrupo.ID_ESTADO_CARGA = (int)T_ESTADO_GRUPO_CARGA.SIN_ESTADO;
                        ParametrosInputEstadoGrupo.MENSAJE = " ";

                        oSP_RETURN_STATUS ESTADO_GRUPO = Servicio.SP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO(ParametrosInputEstadoGrupo);

                        if (ESTADO_GRUPO.RETURN_VALUE == 1)
                        {
                            iSP_UPDATE_GRUPO_CARGA_ESTADO parametrosInputGrupo = new iSP_UPDATE_GRUPO_CARGA_ESTADO();
                            parametrosInputGrupo.ID_GRUPO_CARGA = item.ID_GRUPO_CARGA;
                            parametrosInputGrupo.ID_ESTADO_CARGA = (int)T_ESTADO_CARGA.SIN_ESTADO;
                            parametrosInputGrupo.MENSAJE = " ";

                            Servicio.SP_UPDATE_GRUPO_CARGA_ESTADO(parametrosInputGrupo);


                            //===========================================================
                            // CONSTRUCCION DE OBJETO
                            //===========================================================
                            iSP_DELETE_FIFO_CARGA ParametrosInputDeleteFifo = new iSP_DELETE_FIFO_CARGA();
                            ParametrosInputDeleteFifo.ID_DETALLE_GRUPO_CARGA = item.ID_DETALLE_GRUPO_CARGA;

                            //===========================================================
                            // LLAMADA A SERVICIO
                            //===========================================================
                            oSP_RETURN_STATUS ESTADO = Servicio.SP_DELETE_FIFO_CARGA(ParametrosInputDeleteFifo);

                            LEER_GRUPOS(ID_CLUSTER);
                            LEER_DETALLE_GRUPOS(ID_GRUPO_CARGA);
                            CARGAR_GRILLA_EJECUCIONES();
                            MensajeLOG("SE A REINICIADO EL PROCESO", "EJECUCIÓN");
                        }
                        else
                        {
                            MensajeLOG("NO SE A REINICIADO EL PROCESO", "EJECUCIÓN");
                        }
                    }

                }

                //===========================================================
                // ENVIAR A EJECUCION                          
                //===========================================================
                if (e.CommandName == "Play")
                {
                    //===========================================================
                    // DECLARACION DE VARIABLES                                
                    //===========================================================
                    List<oSP_READ_PROCESO_X_EJECUCION> LST_EJECUCIONES = new List<oSP_READ_PROCESO_X_EJECUCION>();
                    List<oSP_READ_DETALLE_GRUPO_CARGA_WEB> LST_DETALLE_GRUPO = new List<oSP_READ_DETALLE_GRUPO_CARGA_WEB>();

                    LEER_DETALLE_GRUPOS(ID_GRUPO_CARGA);

                    LST_DETALLE_GRUPO = V_Global().DetalleGrupo;

                    int CONTADOR = 0;
                    int EJECUCIONES = 0;

                    foreach (oSP_READ_DETALLE_GRUPO_CARGA_WEB item in LST_DETALLE_GRUPO)
                    {
                        LEER_PROCESO_X_EJECUCION(item.ID_EJECUCION);
                        EJECUCIONES++;

                        List<oSP_READ_PROCESO_X_EJECUCION> ListaEjecucion = V_Global().ListaEjecucion;

                        if (ListaEjecucion.Count > 0)
                        {
                            CONTADOR++;
                        }

                        foreach (oSP_READ_PROCESO_X_EJECUCION item2 in ListaEjecucion)
                        {
                            if (item2.ID_PROCESO != 0)
                            {
                                LST_EJECUCIONES.Add(item2);
                            }
                        }

                    }

                    //===========================================================
                    // EVALUAR RETORNO
                    //===========================================================
                    if (LST_EJECUCIONES == null || LST_EJECUCIONES.Count <= 0)
                    {
                        DibujarGrillaDatosProceso();
                        BTN_PROCESOS.Enabled = false;
                    }
                    else
                    {
                        if (EJECUCIONES == CONTADOR)
                        {
                            BTN_PROCESOS.Enabled = true;
                        }
                        else
                        {
                            DibujarGrillaDatosProceso();
                            BTN_PROCESOS.Enabled = false;
                        }
                    }


                    TXT_ID_GRUPO_CARGA.Text = ID_GRUPO_CARGA.ToString();
                    TXT_ID_DETALLE_GRUPO_CARGA.Text = "0";

                    FuncionesGenerales.Cargar_Grilla(LST_EJECUCIONES, GRD_PROCESOS);
                    FormularioModalJS("MODAL_PROCESOS", "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");
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
        /// GRILLA ROWCOMMAND
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDDataDetalleGrupo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //===========================================================
                // ID                                                           
                //===========================================================          
                int ID = Convert.ToInt32(e.CommandArgument);

                if (ID == 0) { return; }


                //===========================================================
                // BUSCAR EJECUCIONES
                //===========================================================
                if (e.CommandName == "BuscarEjecuciones")
                {
                    LEER_PROCESO_X_EJECUCION(ID);
                    CARGAR_GRILLA_EJECUCIONES();
                }

                //===========================================================
                // ASIGNAR PARALELISMO                                
                //===========================================================
                if (e.CommandName == "Paralelismo")
                {
                    LEER_PROCESO_X_EJECUCION(ID);

                    //===========================================================
                    // DECLARACION DE VARIABES
                    //===========================================================
                    SMetodos Servicio = new SMetodos();


                    //===========================================================
                    // CONSTRUCCION DE OBJETO
                    //===========================================================
                    iSP_READ_EJECUCION ParametrosInput = new iSP_READ_EJECUCION();
                    ParametrosInput.ID_EJECUCION = ID;

                    List<oSP_READ_EJECUCION> LST_EJECUCION = Servicio.SP_READ_EJECUCION(ParametrosInput);

                    if (LST_EJECUCION == null || LST_EJECUCION.Count <= 0)
                    {
                        MensajeLOG("LA EJECUCION NO CONTIENE ELEMENTOS", "MENSAJE DE APLICACIÓN");
                        return;
                    }

                    oSP_READ_EJECUCION EJECUCION = LST_EJECUCION.First();
                    FuncionesGenerales.BuscarIdCombo(DDL_PROCESO, 1);                    

                    TXT_ID_EJECUCION_PAR.Text = EJECUCION.ID_EJECUCION.ToString();
                    LBL_REGISTROS.Text = EJECUCION.ROW_TOTAL.ToString();

                    DDL_PROCESO_SelectedIndexChanged(null, null);
                    FormularioModalJS("MODAL_GRID_PROCESO", "MSG_INFO_PROCESO", "MSG_ALERTA_PROCESO");
                }

                //===========================================================
                // REINICIAR A EJECUCION                          
                //===========================================================
                if (e.CommandName == "Reinicia")
                {
                    //===========================================================
                    // DECLARACION DE VARIABLES
                    //===========================================================                    
                    SMetodos Servicio = new SMetodos();

                    //===========================================================
                    // CARGAMOS EL DETALLE DE GRUPO
                    //===========================================================
                    oSP_READ_DETALLE_GRUPO_CARGA_WEB DETALLE_GRUPO = V_Global().DetalleGrupo.Where(x => x.ID_DETALLE_GRUPO_CARGA == ID).First();

                    //=======================================================
                    // CONSTRUCCION DE OBJETO ESTADO_INTERFAZ
                    //=======================================================
                    iSP_UPDATE_ESTADO_PROCESO_X_EJECUCION ParametrosInputEstadoProceso = new iSP_UPDATE_ESTADO_PROCESO_X_EJECUCION();
                    ParametrosInputEstadoProceso.ID_EJECUCION = DETALLE_GRUPO.ID_EJECUCION;
                    ParametrosInputEstadoProceso.ID_ESTADO = (int)T_ESTADO_PROCESO.SIN_ESTADO;
                    ParametrosInputEstadoProceso.MENSAJE = " ";

                    //=======================================================
                    // LLAMADA A SERVICIO
                    //=======================================================
                    oSP_RETURN_STATUS ESTADO_PROCESO = Servicio.SP_UPDATE_ESTADO_PROCESO_X_EJECUCION(ParametrosInputEstadoProceso);

                    //===========================================================
                    // CONSTRUCCION DE OBJETO
                    //===========================================================
                    iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO ParametrosInputEstadoGrupo = new iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO();
                    ParametrosInputEstadoGrupo.ID_DETALLE_GRUPO_CARGA = DETALLE_GRUPO.ID_DETALLE_GRUPO_CARGA;
                    ParametrosInputEstadoGrupo.ID_ESTADO_CARGA = (int)T_ESTADO_CARGA.SIN_ESTADO;
                    ParametrosInputEstadoGrupo.MENSAJE = " ";

                    oSP_RETURN_STATUS ESTADO_GRUPO = Servicio.SP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO(ParametrosInputEstadoGrupo);

                    if (ESTADO_GRUPO.RETURN_VALUE == 1)
                    {
                        iSP_UPDATE_GRUPO_CARGA_ESTADO parametrosInputGrupo = new iSP_UPDATE_GRUPO_CARGA_ESTADO();
                        parametrosInputGrupo.ID_GRUPO_CARGA = DETALLE_GRUPO.ID_GRUPO_CARGA;
                        parametrosInputGrupo.ID_ESTADO_CARGA = (int)T_ESTADO_CARGA.SIN_ESTADO;
                        parametrosInputGrupo.MENSAJE = " ";

                        Servicio.SP_UPDATE_GRUPO_CARGA_ESTADO(parametrosInputGrupo);

                        //===========================================================
                        // CONSTRUCCION DE OBJETO
                        //===========================================================
                        iSP_DELETE_FIFO_CARGA ParametrosInputDeleteFifo = new iSP_DELETE_FIFO_CARGA();
                        ParametrosInputDeleteFifo.ID_DETALLE_GRUPO_CARGA = DETALLE_GRUPO.ID_DETALLE_GRUPO_CARGA;

                        //===========================================================
                        // LLAMADA A SERVICIO
                        //===========================================================
                        oSP_RETURN_STATUS ESTADO = Servicio.SP_DELETE_FIFO_CARGA(ParametrosInputDeleteFifo);

                        LEER_DETALLE_GRUPOS(DETALLE_GRUPO.ID_GRUPO_CARGA);
                        CARGAR_GRILLA_EJECUCIONES();

                        MensajeLOG("SE A REINICIADO EL PROCESO", "EJECUCIÓN");
                    }
                    else
                    {
                        MensajeLOG("NO SE A REINICIADO EL PROCESO", "EJECUCIÓN");
                    }

                }

                //===========================================================
                // ENVIAR A EJECUCION                          
                //===========================================================
                if (e.CommandName == "Play")
                {
                    //===========================================================
                    // DECLARACION DE VARIABLES                                
                    //===========================================================
                    List<oSP_READ_PROCESO_X_EJECUCION> LST_EJECUCIONES = new List<oSP_READ_PROCESO_X_EJECUCION>();

                    //===========================================================
                    // CARGAMOS EL DETALLE DE GRUPO
                    //===========================================================
                    oSP_READ_DETALLE_GRUPO_CARGA_WEB DETALLE_GRUPO = V_Global().DetalleGrupo.Where(x => x.ID_DETALLE_GRUPO_CARGA == ID).First();

                    int CONTADOR = 0;
                    int EJECUCIONES = 0;

                    LEER_PROCESO_X_EJECUCION(DETALLE_GRUPO.ID_EJECUCION);
                    EJECUCIONES++;

                    List<oSP_READ_PROCESO_X_EJECUCION> ListaEjecucion = V_Global().ListaEjecucion;

                    if (ListaEjecucion.Count > 0)
                    {
                        CONTADOR++;
                    }

                    foreach (oSP_READ_PROCESO_X_EJECUCION item2 in ListaEjecucion)
                    {
                        if (item2.ID_PROCESO != 0)
                        {
                            LST_EJECUCIONES.Add(item2);
                        }
                    }


                    //===========================================================
                    // EVALUAR RETORNO
                    //===========================================================
                    if (LST_EJECUCIONES == null || LST_EJECUCIONES.Count <= 0)
                    {
                        DibujarGrillaDatosProceso();
                        BTN_PROCESOS.Enabled = false;
                    }
                    else
                    {
                        if (EJECUCIONES == CONTADOR)
                        {
                            BTN_PROCESOS.Enabled = true;
                        }
                        else
                        {
                            DibujarGrillaDatosProceso();
                            BTN_PROCESOS.Enabled = false;
                        }
                    }


                    TXT_ID_GRUPO_CARGA.Text = "0";
                    TXT_ID_DETALLE_GRUPO_CARGA.Text = DETALLE_GRUPO.ID_DETALLE_GRUPO_CARGA.ToString();

                    FuncionesGenerales.Cargar_Grilla(LST_EJECUCIONES, GRD_PROCESOS);
                    FormularioModalJS("MODAL_PROCESOS", "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");
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
        /// BOTON PROCESO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_PROCESOS_Click(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================
                SMetodos Servicio = new SMetodos();
                int ID_GRUPO_CARGA = 0;
                int ID_DETALLE_GRUPO_CARGA = 0;

                List<oSP_READ_DETALLE_GRUPO_CARGA_WEB> ListaDetalle = new List<oSP_READ_DETALLE_GRUPO_CARGA_WEB>();
                List<oSP_READ_EJECUCION_X_FILTRO> ListaEjecucion = new List<oSP_READ_EJECUCION_X_FILTRO>();

                //===========================================================
                // VALIDACION DE SELECCION DE GRUPO DE CARGA                             
                //===========================================================
                if (string.IsNullOrWhiteSpace(TXT_ID_GRUPO_CARGA.Text))
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UN GRUPO DE CARGA", "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");
                    return;
                }
                else
                {
                    ID_GRUPO_CARGA = Convert.ToInt32(TXT_ID_GRUPO_CARGA.Text);
                }                

                //===========================================================
                // VALIDACION DE SELECCION DE INTERFAZ A PROCESAR                             
                //===========================================================
                if (string.IsNullOrWhiteSpace(TXT_ID_DETALLE_GRUPO_CARGA.Text))
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UNA INTERFAZ A PROCESAR VALIDA", "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");
                    return;
                }
                else
                {
                    ID_DETALLE_GRUPO_CARGA = Convert.ToInt32(TXT_ID_DETALLE_GRUPO_CARGA.Text);

                }

                if (ID_GRUPO_CARGA > 0)
                {
                    //===========================================================
                    // DECLARACION DE VARIABLES
                    //===========================================================
                    int ID_CLUSTER = 0;
                    string MENSAJE = "";
                    string OPCION = "";

                    //===========================================================
                    // CONSTRUCCION DE OBJETO
                    //===========================================================
                    iSP_READ_DETALLE_GRUPO_CARGA_WEB ParametrosInput = new iSP_READ_DETALLE_GRUPO_CARGA_WEB();
                    ParametrosInput.ID_GRUPO_CARGA = ID_GRUPO_CARGA;

                    //===========================================================
                    // LLAMADA A SERVICIO 
                    //===========================================================
                    ListaDetalle = Servicio.SP_READ_DETALLE_GRUPO_CARGA(ParametrosInput);                   

                    //===========================================================
                    // VALIDACION DE SELECCION DE CLUSTER
                    //===========================================================
                    if (Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue) == 0)
                    {
                        MensajeLOGEdit("A", "DEBES SELECCIONAR UN CLUSTER", "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");
                        return;
                    }
                    else
                    {
                        ID_CLUSTER = Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue);
                    }

                    //===========================================================
                    // RECORREMOS LA LISTA DE DETALLES DE GRUPO DE CARGA
                    //===========================================================
                    foreach (oSP_READ_DETALLE_GRUPO_CARGA_WEB item in ListaDetalle)
                    {

                        //=======================================================
                        // PARAMETROS DE ENTRADA 
                        //=======================================================
                        iSP_UPDATE_EJECUCION_PROCESO ParametrosInputProceso = new iSP_UPDATE_EJECUCION_PROCESO();
                        ParametrosInputProceso.ID_EJECUCION = item.ID_EJECUCION;
                        ParametrosInputProceso.ACCION = 1;

                        //=======================================================
                        // ENVIA 
                        //=======================================================
                        oSP_RETURN_STATUS Retorno = Servicio.SP_UPDATE_EJECUCION_PROCESO(ParametrosInputProceso);

                        if (Retorno.RETURN_VALUE != 1)
                        {
                            MENSAJE = "ENVIO A EJECUCIÓN NO FUE REALIZADO";
                            OPCION = "A";
                            //MensajeLOGEdit("A", "ENVIO A EJECUCIÓN NO FUE REALIZADO", "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");
                            continue;
                        }
                        else
                        {
                            //=======================================================
                            // CONSTRUCCION DE OBJETO ESTADO_INTERFAZ
                            //=======================================================
                            iSP_UPDATE_ESTADO_PROCESO_X_EJECUCION ParametrosInputEstadoProceso = new iSP_UPDATE_ESTADO_PROCESO_X_EJECUCION();
                            ParametrosInputEstadoProceso.ID_EJECUCION = item.ID_EJECUCION;
                            ParametrosInputEstadoProceso.ID_ESTADO = (int)T_ESTADO_PROCESO.EN_PROCESO;
                            ParametrosInputEstadoProceso.MENSAJE = "EN PROCESO";

                            //=======================================================
                            // LLAMADA A SERVICIO
                            //=======================================================
                            oSP_RETURN_STATUS ESTADO_PROCESO = Servicio.SP_UPDATE_ESTADO_PROCESO_X_EJECUCION(ParametrosInputEstadoProceso);

                            //===========================================================
                            // CONSTRUCCION DE OBJETO
                            //===========================================================
                            iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO ParametrosInputEstadoGrupo = new iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO();
                            ParametrosInputEstadoGrupo.ID_DETALLE_GRUPO_CARGA = item.ID_DETALLE_GRUPO_CARGA;
                            ParametrosInputEstadoGrupo.ID_ESTADO_CARGA = (int)T_ESTADO_GRUPO_CARGA.EN_PROCESO;
                            ParametrosInputEstadoGrupo.MENSAJE = "EN PROCESO";

                            //=======================================================
                            // LLAMADA A SERVICIO
                            //=======================================================
                            oSP_RETURN_STATUS ESTADO_GRUPO = Servicio.SP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO(ParametrosInputEstadoGrupo);

                            if (ESTADO_GRUPO.RETURN_VALUE == 1)
                            {
                                //===========================================================
                                // CONSTRUCCION DE OBJETO
                                //===========================================================
                                iSP_CREATE_FIFO_CARGA ParametrosInputFifo = new iSP_CREATE_FIFO_CARGA();
                                ParametrosInputFifo.ID_DETALLE_GRUPO_CARGA = item.ID_DETALLE_GRUPO_CARGA;

                                //=======================================================
                                // LLAMADA A SERVICIO
                                //=======================================================
                                oSP_RETURN_STATUS ESTADO_FIFO = Servicio.SP_CREATE_FIFO_CARGA(ParametrosInputFifo);

                                MENSAJE = "EL ENVIO A EJECUCIÓN FUE REALIZADO CON EXITO";
                                OPCION = "I";
                                //MensajeLOGEdit("A", "EL ENVIO A EJECUCIÓN FUE REALIZADO CON EXITO", "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");                                
                            }
                            else
                            {
                                MENSAJE = "EL ENVIO A EJECUCIÓN NO FUE REALIZADO";
                                OPCION = "A";
                                //MensajeLOGEdit("A", "EL ENVIO A EJECUCIÓN NO FUE REALIZADO", "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");                                
                            }
                        }
                    }

                    LEER_GRUPOS(ID_CLUSTER);
                    LEER_DETALLE_GRUPOS(ID_GRUPO_CARGA);
                    CARGAR_GRILLA_EJECUCIONES();

                    MensajeLOGEdit(OPCION, MENSAJE, "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");
                    return;
                }

                if (ID_DETALLE_GRUPO_CARGA > 0)
                {
                    //===========================================================
                    // RESCATAMOS EL DETALLE DE GRUPO DE CARGA
                    //===========================================================
                    oSP_READ_DETALLE_GRUPO_CARGA_WEB DETALLE_GRUPO = V_Global().DetalleGrupo.Where(x => x.ID_DETALLE_GRUPO_CARGA == ID_DETALLE_GRUPO_CARGA).First();

                    //int ID_CLUSTER = 0;

                    //=======================================================
                    // PARAMETROS DE ENTRADA 
                    //=======================================================
                    iSP_UPDATE_EJECUCION_PROCESO ParametrosInputProceso = new iSP_UPDATE_EJECUCION_PROCESO();
                    ParametrosInputProceso.ID_EJECUCION = DETALLE_GRUPO.ID_EJECUCION;
                    ParametrosInputProceso.ACCION = 1;

                    //=======================================================
                    // ENVIA 
                    //=======================================================
                    oSP_RETURN_STATUS Retorno = Servicio.SP_UPDATE_EJECUCION_PROCESO(ParametrosInputProceso);

                    if (Retorno.RETURN_VALUE != 1)
                    {
                        MensajeLOGEdit("A", "ENVIO A EJECUCIÓN NO FUE REALIZADO", "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");
                        return;
                    }
                    else
                    {
                        //=======================================================
                        // CONSTRUCCION DE OBJETO ESTADO_INTERFAZ
                        //=======================================================
                        iSP_UPDATE_ESTADO_PROCESO_X_EJECUCION ParametrosInputEstadoProceso = new iSP_UPDATE_ESTADO_PROCESO_X_EJECUCION();
                        ParametrosInputEstadoProceso.ID_EJECUCION = DETALLE_GRUPO.ID_EJECUCION;
                        ParametrosInputEstadoProceso.ID_ESTADO = (int)T_ESTADO_PROCESO.EN_PROCESO;
                        ParametrosInputEstadoProceso.MENSAJE = "EN PROCESO";

                        //=======================================================
                        // LLAMADA A SERVICIO
                        //=======================================================
                        oSP_RETURN_STATUS ESTADO_PROCESO = Servicio.SP_UPDATE_ESTADO_PROCESO_X_EJECUCION(ParametrosInputEstadoProceso);

                        //===========================================================
                        // CONSTRUCCION DE OBJETO
                        //===========================================================
                        iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO ParametrosInputEstadoGrupo = new iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO();
                        ParametrosInputEstadoGrupo.ID_DETALLE_GRUPO_CARGA = DETALLE_GRUPO.ID_DETALLE_GRUPO_CARGA;
                        ParametrosInputEstadoGrupo.ID_ESTADO_CARGA = (int)T_ESTADO_GRUPO_CARGA.EN_PROCESO;
                        ParametrosInputEstadoGrupo.MENSAJE = "EN PROCESO";

                        //=======================================================
                        // LLAMADA A SERVICIO
                        //=======================================================
                        oSP_RETURN_STATUS ESTADO_GRUPO = Servicio.SP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO(ParametrosInputEstadoGrupo);

                        if (ESTADO_GRUPO.RETURN_VALUE == 1)
                        {
                            //===========================================================
                            // CONSTRUCCION DE OBJETO
                            //===========================================================
                            iSP_CREATE_FIFO_CARGA ParametrosInputFifo = new iSP_CREATE_FIFO_CARGA();
                            ParametrosInputFifo.ID_DETALLE_GRUPO_CARGA = DETALLE_GRUPO.ID_DETALLE_GRUPO_CARGA;

                            //=======================================================
                            // LLAMADA A SERVICIO
                            //=======================================================
                            oSP_RETURN_STATUS ESTADO_FIFO = Servicio.SP_CREATE_FIFO_CARGA(ParametrosInputFifo);

                            LEER_DETALLE_GRUPOS(DETALLE_GRUPO.ID_GRUPO_CARGA);
                            CARGAR_GRILLA_EJECUCIONES();
                            MensajeLOGEdit("I", "EL ENVIO A EJECUCIÓN FUE REALIZADO CON EXITO", "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");
                            return;
                        }
                        else
                        {
                            MensajeLOGEdit("A", "EL ENVIO A EJECUCIÓN NO FUE REALIZADO", "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");
                            return;
                        }
                    }

                }



            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_PROCESOS", "MSG_ALERTA_PROCESOS");
            }

        }


        /// <summary>
        /// BOTON PROCESO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_PROCESO_Click(object sender, EventArgs e)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                        
                //===========================================================
                SMetodos Servicio = new SMetodos();
                int ID_EJECUCION = 0;
                List<LISTA_PROCESOS> Lista = new List<LISTA_PROCESOS>();

                //===========================================================
                // ID DE EJECUCION                        
                //===========================================================
                ID_EJECUCION = Convert.ToInt32(TXT_ID_EJECUCION_PAR.Text);

                //===========================================================
                // CALCULOS DE LISTA                    
                //===========================================================
                decimal NumeroProceso = Convert.ToDecimal(DDL_PROCESO.SelectedValue);
                decimal Registro = Convert.ToDecimal(LBL_REGISTROS.Text);
                decimal RowXProceso = Math.Truncate(Registro / NumeroProceso);

                //===========================================================
                // CALCULAR PROCESO
                //===========================================================
                Lista = CalculoProceso(RowXProceso, Registro);

                //===========================================================
                // CONSTRUCCION DE OBJETO
                //===========================================================
                iSP_DELETE_PROCESO ParametrosElimina = new iSP_DELETE_PROCESO();
                ParametrosElimina.ID_EJECUCION = ID_EJECUCION;

                //===========================================================
                // LLAMADA A SERVICIO
                //===========================================================
                oSP_RETURN_STATUS ESTADO = Servicio.SP_DELETE_PROCESO(ParametrosElimina);

                //===========================================================
                // CREACION DE PROCESOS
                //===========================================================
                CREACION_PROCESO(Lista, ID_EJECUCION);

                BNT_BUSCAR_Click(null, null);
                MensajeLOGEdit("I", "PROCESOS INGRESADOS CORRECTAMANTE", "MSG_INFO_PROCESO", "MSG_ALERTA_PROCESO");

            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_INFO_PROCESO", "MSG_ALERTA_PROCESO");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_PROCESO", "MSG_ALERTA_PROCESO");
            }

        }

        /// <summary>
        /// AL SELECCIONAR PROCESO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_PROCESO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES                                                        
                //===========================================================
                List<LISTA_PROCESOS> Lista = new List<LISTA_PROCESOS>();

                //===========================================================
                // EXTRAER NUMERO DE PROCESOS                                                           
                //===========================================================
                decimal NumeroProceso = Convert.ToDecimal(DDL_PROCESO.SelectedValue);
                decimal Registro = Convert.ToDecimal(LBL_REGISTROS.Text);

                decimal RowXProceso = Math.Truncate(Registro / NumeroProceso);

                Lista = CalculoProceso(RowXProceso, Registro);

                if (Lista == null)
                {
                    DibujarGrillaListaProceso();
                    return;
                }
                if (Lista.Count <= 0)
                {
                    DibujarGrillaListaProceso();
                    return;
                }

                FuncionesGenerales.Cargar_Grilla(Lista, GRDListaProceso);

            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_INFO_PROCESO", "MSG_ALERTA_PROCESO");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_PROCESO", "MSG_ALERTA_PROCESO");
            }
        }


        /// <summary>
        /// LEER PROCESOS
        /// </summary>
        private void LEER_PROCESOS()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<Item_Seleccion> Lista = new List<Item_Seleccion>();

                //===========================================================
                // ASIGNAR NUMERO DE PROCESOS                                
                //===========================================================
                Lista.Add(new Item_Seleccion { Id = 1, Nombre = "1" });
                Lista.Add(new Item_Seleccion { Id = 2, Nombre = "2" });
                Lista.Add(new Item_Seleccion { Id = 3, Nombre = "3" });
                Lista.Add(new Item_Seleccion { Id = 4, Nombre = "4" });
                Lista.Add(new Item_Seleccion { Id = 5, Nombre = "5" });
                Lista.Add(new Item_Seleccion { Id = 6, Nombre = "6" });
                Lista.Add(new Item_Seleccion { Id = 7, Nombre = "7" });
                Lista.Add(new Item_Seleccion { Id = 8, Nombre = "8" });
                Lista.Add(new Item_Seleccion { Id = 9, Nombre = "9" });
                Lista.Add(new Item_Seleccion { Id = 10, Nombre = "10" });

                //===========================================================
                // PASAR LISTA A COMBO 
                //===========================================================
                FuncionesGenerales.CDDLCombos(Lista, DDL_PROCESO);

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// CREACION DE PROCESO
        /// </summary>
        /// <param name="Proceso"></param>
        /// <param name="ID_EJECUCION"></param>
        private void CREACION_PROCESO(List<LISTA_PROCESOS> Proceso, int ID_EJECUCION)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_PROCESO> LST_PROCESO = new List<oSP_READ_PROCESO>();
                bool Ingresar = true;
                bool Existe = false;
                SMetodos Servicio = new SMetodos();


                //===========================================================
                // PARAMETROS DE ENTRADA 
                //===========================================================
                iSP_READ_PROCESO ParametrosInput = new iSP_READ_PROCESO();
                ParametrosInput.ID_EJECUCION = ID_EJECUCION;



                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                LST_PROCESO = Servicio.SP_READ_PROCESO(ParametrosInput);

                if (LST_PROCESO == null)
                {
                    Ingresar = false;

                }
                if (LST_PROCESO.Count <= 0)
                {
                    Ingresar = false;

                }

                //===========================================================
                // EVALUAR SI HAY ENVIO
                //===========================================================
                try
                {
                    Existe = LST_PROCESO.Exists(x => x.ENVIADO == true);

                    if (Existe == true)
                    {
                        Ingresar = false;
                    }
                    else
                    {
                        Ingresar = true;
                    }
                }
                catch
                {
                    Ingresar = false;
                }

                if (Ingresar == false)
                {

                    throw new Exception("EL ARCHIVO YA FUÉ PARTICIONADO PARA UNA EJECUCIÓN, PRIMERO DEBE BORRAR LAS PARTICIONES EXISTENTES");
                }

                //===========================================================
                // EVALUAR SI HAY EJECUCION
                //===========================================================
                try
                {
                    Existe = LST_PROCESO.Exists(x => x.EN_EJECUCION == true);

                    if (Existe == true)
                    {
                        Ingresar = false;
                    }
                    else
                    {
                        Ingresar = true;
                    }
                }
                catch
                {
                    Ingresar = false;
                }

                if (Ingresar == false)
                {
                    throw new Exception("EL ARCHIVO YA FUÉ PARTICIONADO PARA UNA EJECUCIÓN, PRIMERO DEBE BORRAR LAS PARTICIONES EXISTENTES");
                }

                //===========================================================
                // SI SE PUEDE INGRESAR SE PROCEDE A ELIMINAR
                //===========================================================
                if (Ingresar == true)
                {

                    iSP_DELETE_PROCESO ParametrosElimina = new iSP_DELETE_PROCESO();
                    ParametrosElimina.ID_EJECUCION = ID_EJECUCION;

                    Servicio.SP_DELETE_PROCESO(ParametrosElimina);

                    foreach (LISTA_PROCESOS item in Proceso)
                    {
                        iSP_CREATE_PROCESO ParametrosCrea = new iSP_CREATE_PROCESO();
                        ParametrosCrea.ID_EJECUCION = ID_EJECUCION;
                        ParametrosCrea.NUMERO_PROCESO = item.NUMERO_PROCESO;
                        ParametrosCrea.ROW_INICIO = item.INICIO;
                        ParametrosCrea.ROW_FIN = item.FIN;

                        Servicio.SP_CREATE_PROCESO(ParametrosCrea);
                    }
                }


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// DIBUJAR GRILLA DE DATOS
        /// </summary>
        private void DibujarGrillaListaProceso()
        {
            try
            {
                List<LISTA_PROCESOS> Lista = new List<LISTA_PROCESOS>();
                for (int i = 1; i <= 1; i++)
                {
                    Lista.Add(new LISTA_PROCESOS());
                }
                FuncionesGenerales.Cargar_Grilla(Lista, GRDListaProceso);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// CALCULO DE PROCESOS
        /// </summary>
        /// <param name="NRO_DIVISIONES"></param>
        /// <param name="ROW_TOTAL"></param>
        /// <returns></returns>
        private List<LISTA_PROCESOS> CalculoProceso(decimal NRO_DIVISIONES, decimal ROW_TOTAL)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<LISTA_PROCESOS> Proceso = new List<LISTA_PROCESOS>();
                decimal RegistroXProceso = NRO_DIVISIONES;
                decimal CantidadProceso = Math.Truncate(ROW_TOTAL / RegistroXProceso);
                decimal Modulo = Math.Truncate(ROW_TOTAL % RegistroXProceso);

                //===========================================================
                // ITERACION                             
                //===========================================================
                decimal RegistroIni = 1;
                decimal FIN = 0;
                for (int i = 0; i < CantidadProceso; i++)
                {
                    FIN = RegistroIni + (RegistroXProceso - 1);

                    if (i == (CantidadProceso - 1))
                    {
                        if (Modulo > 0)
                        {
                            FIN = FIN + (Modulo);
                        }
                    }


                    Proceso.Add(new LISTA_PROCESOS { INICIO = (Int32)RegistroIni, FIN = (Int32)FIN, NUMERO_PROCESO = i + 1 });
                    RegistroIni = RegistroIni + (RegistroXProceso);
                }
                //===========================================================
                // SALIDA DE REGISTRO
                //===========================================================
                return Proceso;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// AL SELECCIONAR INTERFAZ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_GRUPO_CARGA_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDL_SELECT_CLUSTER.Items.Count > 0)
                {
                    int ID_CLUSTER = Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue);
                    LEER_GRUPOS(ID_CLUSTER);
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
                if (DDL_SELECT_CLUSTER.Items.Count > 0)
                {
                    int ID_CLUSTER = Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue);
                    LEER_GRUPOS(ID_CLUSTER);
                    V_Global().ID_CLUSTER = ID_CLUSTER;

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

    [Serializable]
    public class GlobalesEjecucion
    {
        public List<oSP_READ_GRUPO_CARGA> Interfaces { get; set; }
        public List<oSP_READ_PROCESO_X_EJECUCION> ListaEjecucion { get; set; }
        public List<oSP_READ_DETALLE_GRUPO_CARGA_WEB> DetalleGrupo { get; set; }
        public Int32 ID_CLUSTER { get; set; }
    }
}
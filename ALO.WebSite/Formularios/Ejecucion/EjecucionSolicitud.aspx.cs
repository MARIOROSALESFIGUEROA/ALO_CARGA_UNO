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

namespace ALO.WebSite.Formularios.Ejecucion
{
    public partial class EjecucionSolicitud : System.Web.UI.Page
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
                GRDDataGrupo.PreRender += new EventHandler(GRDDataGrupo_PreRender);
                GRDDataDetalleGrupo.PreRender += new EventHandler(GRDDataDetalleGrupo_PreRender);


                //===========================================================
                // POSTBACK                                               
                //===========================================================
                if (!this.IsPostBack)
                {

                    Establecer_Globales();

                    DibujarGrillaDatosGrupo();
                    DibujarGrillaDatosDetalleGrupo();
                    CARGAR_COMBO_CLUSTER();

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
        /// CARGA CAMBO OBJETO
        /// </summary>
        private void CARGAR_COMBO_OBJETOS()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                ==
                //===========================================================
                SMetodos Servicio = new SMetodos();
                List<Item_Seleccion> items = new List<Item_Seleccion>();
                List<oSP_READ_OBJETO> LST_OBJETO = new List<oSP_READ_OBJETO>();

                LST_OBJETO = V_Global().Objeto;

                //===========================================================
                // PASAR LISTA A COMBO 
                //===========================================================
                items = LST_OBJETO.OrderBy(p => p.ID_OBJETO)
                                                     .Select(p => new Item_Seleccion { Id = p.ID_OBJETO, Nombre = p.DESCRIPCION_OBJETO })
                                                     .ToList();

                //===========================================================
                // CAMPO POR DEFECTO                                        
                //===========================================================                
                items.Add(new Item_Seleccion { Id = 0, Nombre = "SELECCIONE VALOR" });
                items = items.OrderBy(x => x.Id).ToList();


                FuncionesGenerales.CDDLCombos(items, DDL_OBJETOS);

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LEER OBJETO X CLUSTER
        /// </summary>
        private void LEER_OBJETO(int ID_CLUSTER)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                SMetodos Servicio = new SMetodos();
                List<oSP_READ_OBJETO> ListaIn = new List<oSP_READ_OBJETO>();

                //===========================================================
                // LLAMADA A SERVICIO         
                //===========================================================                
                ListaIn = Servicio.SP_READ_OBJETO(new iSP_READ_OBJETO { ID_CLUSTER = ID_CLUSTER });


                if (ListaIn == null)
                {
                    V_Global().Objeto = new List<oSP_READ_OBJETO>();
                }
                else
                {
                    V_Global().Objeto = ListaIn;
                }
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
                    LEER_OBJETO(ID_CLUSTER);
                    CARGAR_COMBO_OBJETOS();

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
                ViewState["GlobalesEjecucionSolicitud"] = new GlobalesEjecucionSolicitud();
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
        private GlobalesEjecucionSolicitud V_Global()
        {


            GlobalesEjecucionSolicitud item = new GlobalesEjecucionSolicitud();
            try
            {

                item = (GlobalesEjecucionSolicitud)ViewState["GlobalesEjecucionSolicitud"] ?? null;
                return item;
            }
            catch
            {
                return item;
            }

        }

        /// <summary>
        /// LINK SOBRE GRILLAS DE HIPERVINCULOS
        /// </summary>
        private void LINK_GRILLA_HIPERVINCULOS()
        {

            try
            {

                //=======================================================
                // RECORRER GRIDVIEW Y CAMBIAR OBJETOS
                //=======================================================
                int COLUMNA = GetColumnIndexByHeaderText(GRDDataDetalleGrupo, "LINK");
                if (COLUMNA != -1)
                {

                    GridView Grilla = GRDDataDetalleGrupo;


                    foreach (GridViewRow row in Grilla.Rows)
                    {

                        var CELDA = row.Cells[COLUMNA];
                        string Texto = "http://192.9.200.69:9107/SOL/CARGA?ID_SOLICITUD=" + CELDA.Text;

                        if (Texto.Trim().ToUpper().Length > 5)
                        {

                            HyperLink hp = new HyperLink();
                            hp.Target = "_blank";
                            hp.Text = "VER PROCESO DE EJECUCIÓN";
                            hp.NavigateUrl = Texto;
                            CELDA.Controls.Clear();
                            CELDA.Controls.Add(hp);
                        }
                    }

                }

                //=======================================================
                // RECORRER GRIDVIEW Y CAMBIAR OBJETOS
                //=======================================================
                int COLUMNA2 = GetColumnIndexByHeaderText(GRDDataDetalleGrupo, "LOG");
                if (COLUMNA2 != -1)
                {

                    GridView Grilla = GRDDataDetalleGrupo;


                    foreach (GridViewRow row in Grilla.Rows)
                    {

                        var CELDA = row.Cells[COLUMNA2];
                        string Texto = "http://192.9.200.69:9107/SOL/LOG?ID_SOLICITUD=" + CELDA.Text;

                        if (Texto.Trim().ToUpper().Length > 5)
                        {

                            HyperLink hp = new HyperLink();
                            hp.Target = "_blank";
                            hp.Text = "VER LOG";
                            hp.NavigateUrl = Texto;
                            CELDA.Controls.Clear();
                            CELDA.Controls.Add(hp);
                        }
                    }

                }


            }
            catch
            {

                throw;

            }

        }

        /// <summary>
        /// BUSCAR COLUMNA EN GRILLA
        /// </summary>
        /// <param name="grilla"></param>
        /// <param name="ColumnText"></param>
        /// <returns></returns>
        public int GetColumnIndexByHeaderText(GridView grilla, String ColumnText)
        {
            TableCell Cell;
            for (int Index = 0; Index < grilla.HeaderRow.Cells.Count; Index++)
            {
                Cell = grilla.HeaderRow.Cells[Index];
                if (Cell.Text.ToString().Trim().ToUpper() == ColumnText.Trim().ToUpper())
                    return Index;
            }
            return -1;
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
                LINK_GRILLA_HIPERVINCULOS();
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
                if (LST_REST == null)
                {
                    DibujarGrillaDatosDetalleGrupo();
                    V_Global().DetalleGrupo = new List<oSP_READ_DETALLE_GRUPO_CARGA_WEB>();
                    return;
                }

                if (LST_REST.Count <= 0)
                {
                    DibujarGrillaDatosDetalleGrupo();
                    V_Global().DetalleGrupo = new List<oSP_READ_DETALLE_GRUPO_CARGA_WEB>();
                    return;
                }

                V_Global().DetalleGrupo = LST_REST;

                FuncionesGenerales.Cargar_Grilla(LST_REST, GRDDataDetalleGrupo);
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
        protected void GRDDataDetalleGrupo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //===========================================================
                // ID                                                           
                //===========================================================                          
                int ID_DETALLE_GRUPO_CARGA = Convert.ToInt32(e.CommandArgument);

                if (ID_DETALLE_GRUPO_CARGA == 0) { return; }


                ////===========================================================
                //// BUSCAR EJECUCIONES
                ////===========================================================
                //if (e.CommandName == "BuscarObjetos")
                //{
                //    TXT_ID_INTERFAZ.Text = ID_INTERFAZ.ToString();
                //    TXT_ELIMINA_ID_INTERFAZ.Text = ID_INTERFAZ.ToString();
                //    LEER_OBJETOS_X_INTERFAZ(ID_INTERFAZ);
                //    CARGAR_GRILLA_OBJETO_X_INTERFAZ();
                //}

                //===========================================================
                // MANDAR A EJECUCION LA SOLICITUD
                //===========================================================
                if (e.CommandName == "CrearSolicitud")
                {

                    oSP_READ_DETALLE_GRUPO_CARGA_WEB DETALLE_GRUPO = V_Global().DetalleGrupo.Where(x => x.ID_DETALLE_GRUPO_CARGA == ID_DETALLE_GRUPO_CARGA).First();

                    List<oSP_READ_OBJETO_X_INTERFAZ> ListaObjetoInterfaz = new List<oSP_READ_OBJETO_X_INTERFAZ>();

                    LEER_OBJETOS_X_INTERFAZ(DETALLE_GRUPO.ID_INTERFAZ);
                    List<oSP_READ_OBJETO_X_INTERFAZ> ListaObjeto = V_Global().ObjetoInterfaz;
                    foreach (oSP_READ_OBJETO_X_INTERFAZ item2 in ListaObjeto)
                    {
                        if (!ListaObjetoInterfaz.Exists(x => x.CODIGO_OBJETO == item2.CODIGO_OBJETO && x.CODIGO_INTERFAZ == item2.CODIGO_INTERFAZ))
                        {
                            ListaObjetoInterfaz.Add(item2);
                        }

                    }


                    //===========================================================
                    // EVALUAR RETORNO
                    //===========================================================
                    if (ListaObjetoInterfaz == null || ListaObjetoInterfaz.Count <= 0)
                    {
                        BTN_OBJETOS.Enabled = false;
                    }
                    else
                    {
                        BTN_OBJETOS.Enabled = true;
                    }



                    TXT_ID_GRUPO_CARGA.Text = "0";
                    TXT_ID_DETALLE_GRUPO_CARGA.Text = DETALLE_GRUPO.ID_DETALLE_GRUPO_CARGA.ToString();

                    FuncionesGenerales.Cargar_Grilla(ListaObjetoInterfaz, GRD_ASIGNACION_OBJETO);
                    FormularioModalJS("MODAL_OBJETOS", "MSG_INFO_OBJETOS", "MSG_ALERTA_OBJETOS");

                }


                //===========================================================
                // ELIMINAR EJECUCION DE SOLICITUD
                //===========================================================
                if (e.CommandName == "EliminarSolicitud")
                {
                    //===========================================================
                    // DECLARACION DE VARIABLES
                    //===========================================================
                    SMetodos Servicio = new SMetodos();

                    //===========================================================
                    // VALIDACION DE SELECCION DE CLUSTER
                    //===========================================================
                    oSP_READ_DETALLE_GRUPO_CARGA_WEB DETALLE_GRUPO = V_Global().DetalleGrupo.Where(x => x.ID_DETALLE_GRUPO_CARGA == ID_DETALLE_GRUPO_CARGA).First();

                    //===========================================================
                    // CONSTRUCCION DE OBJETO
                    //===========================================================
                    iSP_DELETE_FIFO_SOLICITUD ParametrosInputDelete = new iSP_DELETE_FIFO_SOLICITUD();
                    ParametrosInputDelete.ID_DETALLE_GRUPO_CARGA = DETALLE_GRUPO.ID_DETALLE_GRUPO_CARGA;

                    //===========================================================
                    // LLAMADA A SERVICIO
                    //===========================================================
                    oSP_RETURN_STATUS ESTADO = Servicio.SP_DELETE_FIFO_SOLICITUD(ParametrosInputDelete);

                    //===========================================================
                    // VALIDACION DE RETORNO
                    //===========================================================
                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOG("NO ES POSIBLE REINICIAR LA EJECUCIÓN", "MENSAJE DE APLICACIÓN");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 1)
                    {
                        //===========================================================
                        // CONSTRUCCION DE OBJETO
                        //===========================================================
                        iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO parametrosInput = new iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO();
                        parametrosInput.ID_DETALLE_GRUPO_CARGA = DETALLE_GRUPO.ID_DETALLE_GRUPO_CARGA;
                        parametrosInput.ID_ESTADO_CARGA = (int)T_ESTADO_CARGA.CARGADO;
                        parametrosInput.MENSAJE = "CARGA FINALIZADA CORRECTAMENTE";

                        //===========================================================
                        // LLAMADA A SERVICIO
                        //===========================================================
                        Servicio.SP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO(parametrosInput);

                        //===========================================================
                        // CONSTRUCCION DE OBJETO
                        //===========================================================
                        iSP_UPDATE_GRUPO_CARGA_ESTADO parametrosInputGrupo = new iSP_UPDATE_GRUPO_CARGA_ESTADO();
                        parametrosInputGrupo.ID_GRUPO_CARGA = DETALLE_GRUPO.ID_GRUPO_CARGA;
                        parametrosInputGrupo.ID_ESTADO_CARGA = (int)T_ESTADO_CARGA.CARGADO;
                        parametrosInputGrupo.MENSAJE = "CARGA FINALIZADA CORRECTAMENTE";

                        //===========================================================
                        // LLAMADA A SERVICIO
                        //===========================================================
                        Servicio.SP_UPDATE_GRUPO_CARGA_ESTADO(parametrosInputGrupo);

                        //===========================================================
                        // CONSTRUCCION DE OBJETO
                        //===========================================================
                        iSP_UPDATE_DETALLE_GRUPO_CARGA_NRO_SOLICITUD ParametrosInputSol = new iSP_UPDATE_DETALLE_GRUPO_CARGA_NRO_SOLICITUD();
                        ParametrosInputSol.ID_DETALLE_GRUPO_CARGA = DETALLE_GRUPO.ID_DETALLE_GRUPO_CARGA;
                        ParametrosInputSol.NRO_SOLICITUD = 0;

                        //===========================================================
                        // LLAMADA A SERVICIO
                        //===========================================================
                        Servicio.SP_UPDATE_DETALLE_GRUPO_CARGA_NRO_SOLICITUD(ParametrosInputSol);

                        

                        LEER_DETALLE_GRUPOS(DETALLE_GRUPO.ID_DETALLE_GRUPO_CARGA);

                        MensajeLOG("SE A REINICIADO LA EJECUCIÓN", "MENSAJE DE APLICACIÓN");
                        return;
                    }
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
                // MANDAR A EJECUCION LA SOLICITUD
                //===========================================================
                if (e.CommandName == "CrearSolicitud")
                {
                    LEER_DETALLE_GRUPOS(ID_GRUPO_CARGA);

                    List<oSP_READ_DETALLE_GRUPO_CARGA_WEB> interfaces = V_Global().DetalleGrupo;
                    List<oSP_READ_OBJETO_X_INTERFAZ> ListaObjetoInterfaz = new List<oSP_READ_OBJETO_X_INTERFAZ>();

                    foreach (oSP_READ_DETALLE_GRUPO_CARGA_WEB item in interfaces)
                    {
                        LEER_OBJETOS_X_INTERFAZ(item.ID_INTERFAZ);
                        List<oSP_READ_OBJETO_X_INTERFAZ> ListaObjeto = V_Global().ObjetoInterfaz;
                        foreach (oSP_READ_OBJETO_X_INTERFAZ item2 in ListaObjeto)
                        {
                            if (!ListaObjetoInterfaz.Exists(x => x.CODIGO_OBJETO == item2.CODIGO_OBJETO && x.CODIGO_INTERFAZ == item2.CODIGO_INTERFAZ))
                            {
                                ListaObjetoInterfaz.Add(item2);
                            }

                        }

                    }

                    //===========================================================
                    // EVALUAR RETORNO
                    //===========================================================
                    if (ListaObjetoInterfaz == null || ListaObjetoInterfaz.Count <= 0)
                    {
                        BTN_OBJETOS.Enabled = false;
                    }
                    else
                    {
                        BTN_OBJETOS.Enabled = true;
                    }



                    TXT_ID_GRUPO_CARGA.Text = ID_GRUPO_CARGA.ToString();
                    TXT_ID_DETALLE_GRUPO_CARGA.Text = "0";

                    FuncionesGenerales.Cargar_Grilla(ListaObjetoInterfaz, GRD_ASIGNACION_OBJETO);
                    FormularioModalJS("MODAL_OBJETOS", "MSG_INFO_OBJETOS", "MSG_ALERTA_OBJETOS");

                }


                //===========================================================
                // ELIMINAR EJECUCION DE SOLICITUD
                //===========================================================
                if (e.CommandName == "EliminarSolicitud")
                {
                    //===========================================================
                    // DECLARACION DE VARIABLES
                    //===========================================================
                    List<oSP_READ_DETALLE_GRUPO_CARGA_WEB> ListaDetalle = new List<oSP_READ_DETALLE_GRUPO_CARGA_WEB>();
                    int ID_CLUSTER = 0;

                    //===========================================================
                    // VALIDACION DE SELECCION DE CLUSTER
                    //===========================================================
                    if (Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue) == 0)
                    {
                        MensajeLOG("DEBES TENER UN CLUSTER SELECCIONADO", "MENSAJE DE APLICACIÓN");
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
                        //===========================================================
                        // CONSTRUCCION DE OBJETO
                        //===========================================================
                        iSP_DELETE_FIFO_SOLICITUD ParametrosInputDelete = new iSP_DELETE_FIFO_SOLICITUD();
                        ParametrosInputDelete.ID_DETALLE_GRUPO_CARGA = item.ID_DETALLE_GRUPO_CARGA;

                        //===========================================================
                        // LLAMADA A SERVICIO
                        //===========================================================
                        oSP_RETURN_STATUS ESTADO = Servicio.SP_DELETE_FIFO_SOLICITUD(ParametrosInputDelete);

                        //===========================================================
                        // VALIDACION DE RETORNO
                        //===========================================================
                        if (ESTADO.RETURN_VALUE == 0)
                        {
                            MensajeLOG("NO ES POSIBLE REINICIAR LA EJECUCIÓN", "MENSAJE DE APLICACIÓN");
                            continue;
                        }

                        if (ESTADO.RETURN_VALUE == 1)
                        {
                            //===========================================================
                            // CONSTRUCCION DE OBJETO
                            //===========================================================
                            iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO parametrosInput = new iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO();
                            parametrosInput.ID_DETALLE_GRUPO_CARGA = item.ID_DETALLE_GRUPO_CARGA;
                            parametrosInput.ID_ESTADO_CARGA = (int)T_ESTADO_CARGA.CARGADO;
                            parametrosInput.MENSAJE = "CARGA FINALIZADA CORRECTAMENTE";

                            //===========================================================
                            // LLAMADA A SERVICIO
                            //===========================================================
                            Servicio.SP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO(parametrosInput);

                            //===========================================================
                            // CONSTRUCCION DE OBJETO
                            //===========================================================
                            iSP_UPDATE_GRUPO_CARGA_ESTADO parametrosInputGrupo = new iSP_UPDATE_GRUPO_CARGA_ESTADO();
                            parametrosInputGrupo.ID_GRUPO_CARGA = item.ID_GRUPO_CARGA;
                            parametrosInputGrupo.ID_ESTADO_CARGA = (int)T_ESTADO_CARGA.CARGADO;
                            parametrosInputGrupo.MENSAJE = "CARGA FINALIZADA CORRECTAMENTE";

                            //===========================================================
                            // LLAMADA A SERVICIO
                            //===========================================================
                            Servicio.SP_UPDATE_GRUPO_CARGA_ESTADO(parametrosInputGrupo);

                            //===========================================================
                            // CONSTRUCCION DE OBJETO
                            //===========================================================
                            iSP_UPDATE_DETALLE_GRUPO_CARGA_NRO_SOLICITUD ParametrosInputSol = new iSP_UPDATE_DETALLE_GRUPO_CARGA_NRO_SOLICITUD();
                            ParametrosInputSol.ID_DETALLE_GRUPO_CARGA = item.ID_DETALLE_GRUPO_CARGA;
                            ParametrosInputSol.NRO_SOLICITUD = 0;

                            //===========================================================
                            // LLAMADA A SERVICIO
                            //===========================================================
                            Servicio.SP_UPDATE_DETALLE_GRUPO_CARGA_NRO_SOLICITUD(ParametrosInputSol);


                        }
                    }

                    LEER_GRUPOS(ID_CLUSTER);

                    MensajeLOG("SE A REINICIADO LA EJECUCIÓN", "MENSAJE DE APLICACIÓN");
                    return;
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
        protected void GRD_ASIGNACION_OBJETO_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRD_ASIGNACION_OBJETO.UseAccessibleHeader = true;
                GRD_ASIGNACION_OBJETO.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }

        /// <summary>
        /// GRILLA ROWCOMMAND
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRD_ASIGNACION_OBJETO_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //===========================================================
                // ID                                                           
                //===========================================================          
                int ID_OBJETO_X_INTERFAZ = Convert.ToInt32(e.CommandArgument);

                if (ID_OBJETO_X_INTERFAZ == 0) { return; }

                oSP_READ_OBJETO_X_INTERFAZ objeto = V_Global().ObjetoInterfaz.Where(x => x.ID_OBJETO_X_INTERFAZ == ID_OBJETO_X_INTERFAZ).First();

                //===========================================================
                // ELIMINAR USUARIO                            
                //===========================================================
                if (e.CommandName == "EliminarObjeto")
                {
                    TXT_ID_ELIMINA_OBJETO_X_INTERFAZ.Text = objeto.ID_OBJETO_X_INTERFAZ.ToString();
                    TXT_ELIMINA_ID_INTERFAZ.Text = objeto.ID_INTERFAZ.ToString();
                    LBL_TITULO_MENSAJE_ELIMINA_OBJETO_X_INTERFAZ.Text = ("EL OBJETO " + objeto.DESCRIPCION_OBJETO + " SE ENCUENTRA ASIGNADO A ESTA INTERFAZ "
                                                                        + Environment.NewLine
                                                                        + "¿ DESEA ELIMINAR LA ASIGNACIÓN ?");

                    FormularioModalJS("MODAL_ELIMINA_OBJETO_X_INTERFAZ", "MSG_INFO_ELIMINA_OBJETO_X_INTERFAZ", "MSG_ALERTA_ELIMINA_OBJETO_X_INTERFAZ");
                }

                //===========================================================
                // EDITAR USUARIO                            
                //===========================================================
                if (e.CommandName == "EditarObjeto")
                {
                    LBL_TITULO_OBJETO_X_INTERFAZ.Text = "ACTUALIZAR ASIGNACIÓN DE OBJETO";
                    TXT_ID_OBJETO.Text = objeto.ID_OBJETO_X_INTERFAZ.ToString();
                    TXT_ID_INTERFAZ.Text = objeto.ID_INTERFAZ.ToString();
                    FuncionesGenerales.BuscarIdCombo(DDL_OBJETOS, objeto.ID_OBJETO);
                    TXT_VALOR.Text = objeto.VALOR;
                    BTN_OBJETO_X_INTERFAZ.Text = "ACTUALIZAR";
                    FormularioModalJS("MODAL_GRID_OBJETO_X_INTERFAZ", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
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
        /// LEER OBJETOS X INTERFAZ
        /// </summary>
        private void LEER_OBJETOS_X_INTERFAZ(int ID_INTERFAZ)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                SMetodos Servicio = new SMetodos();
                List<oSP_READ_OBJETO_X_INTERFAZ> ListaObjetoInterfaz = new List<oSP_READ_OBJETO_X_INTERFAZ>();

                //===========================================================
                // LLAMADA A SERVICIO
                //===========================================================                
                ListaObjetoInterfaz = Servicio.SP_READ_OBJETO_X_INTERFAZ(new iSP_READ_OBJETO_X_INTERFAZ { ID_INTERFAZ = ID_INTERFAZ });


                if (ListaObjetoInterfaz == null)
                {
                    V_Global().ObjetoInterfaz = new List<oSP_READ_OBJETO_X_INTERFAZ>();
                }
                else
                {
                    V_Global().ObjetoInterfaz = ListaObjetoInterfaz;
                }

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
        /// ELIMINA FILTRO DE ASIGNACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_ELIMINA_OBJETO_X_INTERFAZ_Click(object sender, EventArgs e)
        {
            try
            {
                //=====================================================================
                // DECLARACION DE VARIABLES
                //=====================================================================
                SMetodos Servicio = new SMetodos();
                int ID_OBJETO_X_INTERFAZ = 0;
                int ID_INTERFAZ = 0;

                //===========================================================
                // VALIDACION DE SELECCION DE INTERFAZ                             
                //===========================================================
                if (string.IsNullOrWhiteSpace(TXT_ELIMINA_ID_INTERFAZ.Text))
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UNA INTERFAZ", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
                    return;
                }
                else
                {
                    ID_INTERFAZ = Convert.ToInt32(TXT_ELIMINA_ID_INTERFAZ.Text);

                }

                //===========================================================
                // VALIDACION DE CONVERSION
                //===========================================================
                try
                {
                    ID_OBJETO_X_INTERFAZ = Convert.ToInt32(TXT_ID_ELIMINA_OBJETO_X_INTERFAZ.Text);
                }
                catch
                {
                    MensajeLOGEdit("A", "EL GRUPO NO ES VALIDO", "MSG_INFO_ELIMINA_OBJETO_X_INTERFAZ", "MSG_ALERTA_ELIMINA_OBJETO_X_INTERFAZ");
                    return;
                }


                //=====================================================================
                // CREACION DE OBJETO
                //=====================================================================
                iSP_DELETE_OBJETO_INTERFAZ parametrosInput = new iSP_DELETE_OBJETO_INTERFAZ();
                parametrosInput.ID_OBJETO_X_INTERFAZ = ID_OBJETO_X_INTERFAZ;

                //=====================================================================
                // LLAMADA A SERVICIO
                //=====================================================================
                oSP_RETURN_STATUS ESTADO = Servicio.SP_DELETE_OBJETO_INTERFAZ(parametrosInput);

                if (ESTADO.RETURN_VALUE == 0)
                {

                    MensajeLOGEdit("A", "EL OBJETO NO FUE ELIMINADO", "MSG_INFO_ELIMINA_OBJETO_X_INTERFAZ", "MSG_ALERTA_ELIMINA_OBJETO_X_INTERFAZ");
                    return;
                }

                if (ESTADO.RETURN_VALUE == 1)
                {
                    MensajeLOGEdit("I", "EL OBJETO FUE ELIMINADO CORRECTAMENTE", "MSG_INFO_ELIMINA_OBJETO_X_INTERFAZ", "MSG_ALERTA_ELIMINA_OBJETO_X_INTERFAZ");
                    LEER_OBJETOS_X_INTERFAZ(ID_INTERFAZ);
                    CARGAR_GRILLA_OBJETO_X_INTERFAZ();
                    return;
                }

            }
            catch (EServiceRestFulException svr)
            {
                MensajeLOGEdit("A", svr.Message, "MSG_INFO_ELIMINA_OBJETO_X_INTERFAZ", "MSG_ALERTA_ELIMINA_OBJETO_X_INTERFAZ");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_ELIMINA_OBJETO_X_INTERFAZ", "MSG_ALERTA_ELIMINA_OBJETO_X_INTERFAZ");
            }
        }
        /// <summary>
        /// MANDAR SOLICITUD A EJECUCION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_OBJETOS_Click(object sender, EventArgs e)
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

                //===========================================================
                // VALIDACION DE SELECCION DE INTERFAZ                             
                //===========================================================
                if (string.IsNullOrWhiteSpace(TXT_ID_GRUPO_CARGA.Text))
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UN GRUPO DE CARGA", "MSG_INFO_OBJETOS", "MSG_ALERTA_OBJETOS");
                    return;
                }
                else
                {
                    ID_GRUPO_CARGA = Convert.ToInt32(TXT_ID_GRUPO_CARGA.Text);
                }

                //===========================================================
                // VALIDACION DE SELECCION DE DETALLE GRUPO DE CARGA                             
                //===========================================================
                if (string.IsNullOrWhiteSpace(TXT_ID_DETALLE_GRUPO_CARGA.Text))
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UNA INTERFAZ A PROCESAR VALIDA", "MSG_INFO_OBJETOS", "MSG_ALERTA_OBJETOS");
                    return;
                }
                else
                {
                    ID_DETALLE_GRUPO_CARGA = Convert.ToInt32(TXT_ID_DETALLE_GRUPO_CARGA.Text);
                }

                if (ID_GRUPO_CARGA > 0)
                {
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
                        //===========================================================
                        // CONSTRUCCION DE OBJETO
                        //===========================================================
                        iSP_CREATE_FIFO_SOLICITUD ParametrosInput1 = new iSP_CREATE_FIFO_SOLICITUD();
                        ParametrosInput1.ID_DETALLE_GRUPO_CARGA = item.ID_DETALLE_GRUPO_CARGA;

                        //===========================================================
                        // LLAMADA A SERVICIO
                        //===========================================================
                        oSP_RETURN_STATUS ESTADO = Servicio.SP_CREATE_FIFO_SOLICITUD(ParametrosInput1);

                        //===========================================================
                        // VALIDACION DE RETORNO
                        //===========================================================
                        if (ESTADO.RETURN_VALUE == 0)
                        {
                            MensajeLOGEdit("A", "LA SOLICITUD NO FUE MANDADA A EJECUCIÓN", "MSG_INFO_OBJETOS", "MSG_ALERTA_OBJETOS");
                        }

                        if (ESTADO.RETURN_VALUE == -1)
                        {
                            MensajeLOGEdit("A", "LA SOLICITUD FUE YA ESTA EN EJECUCIÓN", "MSG_INFO_OBJETOS", "MSG_ALERTA_OBJETOS");
                        }

                        if (ESTADO.RETURN_VALUE == 1)
                        {
                            MensajeLOGEdit("I", "EL ENVIO A EJECUCIÓN FUE REALIZADO CON EXITO", "MSG_INFO_OBJETOS", "MSG_ALERTA_OBJETOS");
                        }
                    }
                   
                    return;
                }

                if (ID_DETALLE_GRUPO_CARGA > 0)
                {
                    //===========================================================
                    // CONSTRUCCION DE OBJETO
                    //===========================================================
                    oSP_READ_DETALLE_GRUPO_CARGA_WEB DETALLE_GRUPO = V_Global().DetalleGrupo.Where(x => x.ID_DETALLE_GRUPO_CARGA == ID_DETALLE_GRUPO_CARGA).First();

                    //===========================================================
                    // CONSTRUCCION DE OBJETO
                    //===========================================================
                    iSP_CREATE_FIFO_SOLICITUD ParametrosInput1 = new iSP_CREATE_FIFO_SOLICITUD();
                    ParametrosInput1.ID_DETALLE_GRUPO_CARGA = DETALLE_GRUPO.ID_DETALLE_GRUPO_CARGA;

                    //===========================================================
                    // LLAMADA A SERVICIO
                    //===========================================================
                    oSP_RETURN_STATUS ESTADO = Servicio.SP_CREATE_FIFO_SOLICITUD(ParametrosInput1);

                    //===========================================================
                    // VALIDACION DE RETORNO
                    //===========================================================
                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOGEdit("A", "LA SOLICITUD NO FUE MANDADA A EJECUCIÓN", "MSG_INFO_OBJETOS", "MSG_ALERTA_OBJETOS");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == -1)
                    {
                        MensajeLOGEdit("A", "LA SOLICITUD FUE YA ESTA EN EJECUCIÓN", "MSG_INFO_OBJETOS", "MSG_ALERTA_OBJETOS");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 1)
                    {
                        LEER_DETALLE_GRUPOS(DETALLE_GRUPO.ID_GRUPO_CARGA);
                        MensajeLOGEdit("I", "EL ENVIO A EJECUCIÓN FUE REALIZADO CON EXITO", "MSG_INFO_OBJETOS", "MSG_ALERTA_OBJETOS");
                        return;
                    }

                }



            }
            catch (EServiceRestFulException svr)
            {
                MensajeLOGEdit("A", svr.Message, "MSG_INFO_OBJETOS", "MSG_ALERTA_OBJETOS");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_OBJETOS", "MSG_ALERTA_OBJETOS");
            }
        }


        /// <summary>
        /// CREA UN NUEVA ASIGNACION DE OBJETOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_OBJETO_X_INTERFAZ_Click(object sender, EventArgs e)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================
                SMetodos Servicio = new SMetodos();
                int ID_INTERFAZ = 0;
                int ID_OBJETO = 0;
                string VALOR = "";


                //===========================================================
                // VALIDACION DE SELECCION DE INTERFAZ                             
                //===========================================================
                if (string.IsNullOrWhiteSpace(TXT_ID_INTERFAZ.Text))
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UNA INTERFAZ", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
                    return;
                }
                else
                {
                    ID_INTERFAZ = Convert.ToInt32(TXT_ID_INTERFAZ.Text);
                }

                //===========================================================
                // VALIDACION DE SELECCION DE OBJETOS                             
                //===========================================================
                if (Convert.ToInt32(DDL_OBJETOS.SelectedValue) == 0)
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UN OBJETO", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
                    return;
                }
                else
                {
                    ID_OBJETO = Convert.ToInt32(DDL_OBJETOS.SelectedValue);
                }

                //===========================================================
                // VALIDACION DE INGRESO DE DE VALOR                             
                //===========================================================
                if (string.IsNullOrWhiteSpace(TXT_VALOR.Text))
                {
                    MensajeLOGEdit("A", "DEBES INGRESAR UN VALOR PARA EL OBJETO", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
                    return;
                }
                else
                {
                    VALOR = TXT_VALOR.Text;
                }


                //===========================================================
                // INGRESAR ASIGNACION DE OBJETOS
                //===========================================================
                if (Convert.ToInt32(TXT_ID_OBJETO.Text) == 0)
                {
                    //===========================================================
                    // CONSTRUCCION DE OBJETO
                    //===========================================================
                    iSP_CREATE_OBJETO_X_INTERFAZ parametrosInput = new iSP_CREATE_OBJETO_X_INTERFAZ();
                    parametrosInput.ID_INTERFAZ = ID_INTERFAZ;
                    parametrosInput.ID_OBJETO = ID_OBJETO;
                    parametrosInput.VALOR = VALOR;

                    //===========================================================
                    // LLAMADA A SERVICIO
                    //===========================================================
                    oSP_RETURN_STATUS ESTADO = Servicio.SP_CREATE_OBJETO_X_INTERFAZ(parametrosInput);

                    //===========================================================
                    // RESPUESTA
                    //===========================================================
                    if (ESTADO.RETURN_VALUE == -1)
                    {
                        MensajeLOGEdit("A", "EL OBJETO YA EXISTE", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOGEdit("A", "EL OBJETO NO FUE INGRESADO", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 1)
                    {
                        MensajeLOGEdit("I", "EL OBJETO FUE INGRESADO CORRECTAMENTE", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
                        LEER_OBJETOS_X_INTERFAZ(ID_INTERFAZ);
                        CARGAR_GRILLA_OBJETO_X_INTERFAZ();
                        return;
                    }
                }

                if (Convert.ToInt32(TXT_ID_OBJETO.Text) > 0)
                {
                    //===========================================================
                    // CONSTRUCCION DE OBJETO
                    //===========================================================
                    iSP_UPDATE_OBJETO_X_INTERFAZ parametrosInput = new iSP_UPDATE_OBJETO_X_INTERFAZ();
                    parametrosInput.ID_OBJETO_X_INTERFAZ = Convert.ToInt32(TXT_ID_OBJETO.Text);
                    parametrosInput.ID_OBJETO = ID_OBJETO;
                    parametrosInput.VALOR = VALOR;

                    //===========================================================
                    // LLAMADA A SERVICIO
                    //===========================================================
                    oSP_RETURN_STATUS ESTADO = Servicio.SP_UPDATE_OBJETO_X_INTERFAZ(parametrosInput);

                    //===========================================================
                    // RESPUESTA
                    //===========================================================
                    if (ESTADO.RETURN_VALUE == -1)
                    {
                        MensajeLOGEdit("A", "EL OBJETO YA EXISTE", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOGEdit("A", "EL OBJETO NO FUE ACTUALIZADO", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 1)
                    {
                        MensajeLOGEdit("I", "EL OBJETO FUE ACTUALIZADO CORRECTAMENTE", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
                        LEER_OBJETOS_X_INTERFAZ(ID_INTERFAZ);
                        CARGAR_GRILLA_OBJETO_X_INTERFAZ();
                        return;
                    }
                }

            }
            catch (EServiceRestFulException svr)
            {
                MensajeLOGEdit("A", svr.Message, "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
            }
        }

        /// <summary>
        /// CARGAR GRILLA DE DATOS
        /// </summary>
        private void CARGAR_GRILLA_OBJETO_X_INTERFAZ()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================                
                List<oSP_READ_OBJETO_X_INTERFAZ> Lista = new List<oSP_READ_OBJETO_X_INTERFAZ>();


                //===========================================================
                // LLAMADA A SERVICIO            
                //===========================================================
                Lista = V_Global().ObjetoInterfaz;

                if (Lista == null)
                {
                    Lista = new List<oSP_READ_OBJETO_X_INTERFAZ>();
                }

                FuncionesGenerales.Cargar_Grilla(Lista, GRD_ASIGNACION_OBJETO);
            }
            catch
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
    public class GlobalesEjecucionSolicitud
    {

        public List<oSP_READ_DETALLE_GRUPO_CARGA_WEB> DetalleGrupo { get; set; }
        public List<oSP_READ_GRUPO_CARGA> Interfaces { get; set; }
        public List<oSP_READ_EJECUCION_X_FILTRO> ListaEjecucion { get; set; }
        public List<oSP_READ_OBJETO_X_INTERFAZ> ObjetoInterfaz { get; set; }
        public List<oSP_READ_OBJETO> Objeto { get; set; }
    }
}
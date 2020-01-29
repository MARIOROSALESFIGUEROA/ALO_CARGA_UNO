using System;
using System.Collections;
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

namespace ALO.WebSite.Formularios.Interfaz
{
    public partial class AsignacionSalida : System.Web.UI.Page
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

                //GRDData.PreRender += new EventHandler(GRDData_PreRender);
                //===========================================================
                // POSTBACK                                               
                //===========================================================
                if (!this.IsPostBack)
                {
                    Establecer_Globales();
                    CARGAR_COMBO_PROCESO_FILE();
                    CARGAR_COMBO_CLUSTER();
                    DIV_CAMPOS.Visible = false;

                    LEER_INTERFAZ_X_CLUSTER(0);

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
        /// DIBUJA EL GRIDVIEW CON EL DETALLE DE PROCESO FILE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void rpt_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    GridView gv = (GridView)e.Item.FindControl("GRDData");
                    if (gv != null)
                    {
                        oSP_READ_PROCESO_FILE drv = (oSP_READ_PROCESO_FILE)e.Item.DataItem;
                        LEER_DETALLE_PROCESO_FILE_X_INTERFAZ(drv.ID_INTERFAZ);
                        gv.DataSource = DETALLE_INTERFAZ_DATA_SOURCE(drv.ID_PROCESO_FILE);
                        gv.DataBind();
                    }
                }
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// PARA OBTENER EL DATASOURCE POR ID DE PROCESO FILE
        /// </summary>
        /// <param name="ID_INTERFAZ"></param>
        private List<oSP_READ_DETALLE_PROCESO_FILE> DETALLE_INTERFAZ_DATA_SOURCE(int ID_PROCESO_FILE)
        {
            try
            {
                List<oSP_READ_DETALLE_PROCESO_FILE> LISTA = V_Global().DetalleFile;

                LISTA = LISTA.Where(x => x.ID_PROCESO_FILE == ID_PROCESO_FILE).ToList();
                LISTA = LISTA.OrderBy(x => x.ORDEN).ToList();
                return LISTA;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// COMANDOS PARA REALIZAR ACCIONES EN ITEM DEL REPETIDOR
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void RPT_SALIDA_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES                                ==
                //===========================================================
                SMetodos Negocio = new SMetodos();


                //===========================================================
                // ID                                                           
                //===========================================================                

                int ID = Convert.ToInt32(e.CommandArgument);
                if (ID == 0) { return; }

                //===========================================================
                // ELIMINAR INTERFACE                                                 
                //===========================================================
                if (e.CommandName == "RecargarInterfaz")
                {
                }

                //===========================================================
                // INFORMACION HISTORIAL DE CARGA DE LA INTERFAZ                                                 
                //===========================================================
                if (e.CommandName == "InfoInterfaz")
                {


                }


                //===========================================================
                // ELIMINAR INTERFACE                                                 
                //===========================================================
                if (e.CommandName == "EliminarInterfaz")
                {

                }

                //===========================================================
                // NUEVO CAMPO DETALLE INTERFACE                                                 
                //===========================================================
                if (e.CommandName == "NuevoCampo")
                {

                }

                //===========================================================
                // EDITAR DETALLE INTERFACE                                                 
                //===========================================================
                if (e.CommandName == "EditarDetalle")
                {


                }
                //===========================================================
                // ELIMINAR DETALLE INTERFACE                                 
                //===========================================================
                if (e.CommandName == "EliminarDetalle")
                {

                }
            }
            catch (System.Exception ex)
            {
                MensajeLOG(ALO.WebSite.Error.ThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }
        }

        /// <summary>
        /// AL HACER CLICK EN LA NAVEGACION DE LA PAGINACION Y REDIBUJA LA DATA DEL REPEATER
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        protected void rptPaginado_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            try
            {
                PageNumber = Convert.ToInt32(e.CommandArgument) - 1;

                if (DDL_SELECT_CLUSTER.Items.Count > 0)
                {
                    int ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                    LEER_PROCESO_FILE(ID_INTERFAZ);
                    BindRepeater();
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// PARA SABER EL NUMERO DE LA PAGINA 
        /// </summary>
        public int PageNumber
        {
            get
            {
                if (ViewState["PageNumber"] != null)
                {
                    return Convert.ToInt32(ViewState["PageNumber"]);
                }
                else
                {
                    return 0;
                }
            }
            set { ViewState["PageNumber"] = value; }
        }

        /// <summary>
        /// DIBUJA DATOS EN EL REPEATER
        /// </summary>
        private void BindRepeater()
        {
            try
            {
                // RESCATAMOS LISTA DE INTERFACES
                List<oSP_READ_PROCESO_FILE> LISTA = V_Global().ProcesoFile;

                // CREACION DE PAGEDATASOURCE PARA SER USADO EN LA PAGINACION
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.DataSource = LISTA;
                pgitems.AllowPaging = true;

                //CONTROLAMOS LA CANTIDAD DE ELEMENTOS POR PAGINA Y AGREGAMOS LA NAVEGACION
                pgitems.PageSize = 3;
                pgitems.CurrentPageIndex = PageNumber;
                if (pgitems.Count == 0)
                {
                    RPT_PAGINADO.Visible = false;
                }
                else
                {
                    RPT_PAGINADO.Visible = true;
                }
                ArrayList pages = new ArrayList();
                for (int i = 0; i <= pgitems.PageCount - 1; i++)
                {
                    pages.Add((i + 1).ToString());
                }
                RPT_PAGINADO.DataSource = pages;
                RPT_PAGINADO.DataBind();

                //PASAMOS EL DATASOURCE CORRESPONDIENTE A LA PAGINA 
                RPT_SALIDA.DataSource = pgitems;
                RPT_SALIDA.DataBind();
            }
            catch
            {
                throw;
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

        private void CARGAR_COMBO_PROCESO_FILE()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                ==
                //===========================================================
                SMetodos Servicio = new SMetodos();
                List<Item_Seleccion> lista = new List<Item_Seleccion>();
                List<oSP_READ_PROCESO_FILE> LST_PROCESO_FILE = new List<oSP_READ_PROCESO_FILE>();

                //===========================================================
                // LLAMADA A SERVICIO
                //===========================================================
                LST_PROCESO_FILE = V_Global().ProcesoFile;

                if (LST_PROCESO_FILE != null && LST_PROCESO_FILE.Count > 0)
                {
                    foreach (oSP_READ_PROCESO_FILE item in LST_PROCESO_FILE.OrderBy(p => p.ID_PROCESO_FILE))
                    {
                        lista.Add(new Item_Seleccion { Id = item.ID_PROCESO_FILE, Nombre = item.DESCRIPCION_PROCESO_FILE });
                    }
                }

                //===========================================================
                // CAMPO POR DEFECTO                                        
                //===========================================================                
                lista.Add(new Item_Seleccion { Id = 0, Nombre = "SELECCIONE VALOR" });
                lista = lista.OrderBy(x => x.Id).ToList();

                FuncionesGenerales.CDDLCombos(lista, DDL_PROCESO_FILE);
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
                    LEER_INTERFAZ_X_CLUSTER(ID_CLUSTER);
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
        /// LEER DETALLE DE PROCESO
        /// </summary>
        private void LEER_PROCESO_FILE(int ID_INTERFAZ)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_PROCESO_FILE> LST_PRO_FILE = new List<oSP_READ_PROCESO_FILE>();
                SMetodos Servicio = new SMetodos();

                //===========================================================
                // PARAMETROS DE ENTRADA 
                //===========================================================
                iSP_READ_PROCESO_FILE ParametrosInput = new iSP_READ_PROCESO_FILE();
                ParametrosInput.ID_INTERFAZ = ID_INTERFAZ;

                LST_PRO_FILE = Servicio.SP_READ_PROCESO_FILE(ParametrosInput);

                if (LST_PRO_FILE != null && LST_PRO_FILE.Count > 0)
                {
                    V_Global().ProcesoFile = LST_PRO_FILE;
                }
                else
                {
                    V_Global().ProcesoFile = new List<oSP_READ_PROCESO_FILE>();
                }

            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// LEER DETALLE DE PROCESO
        /// </summary>
        private void LEER_DETALLE_PROCESO_FILE(int ID_PROCESO_FILE)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE> LST_DETALLE_PRO_FILE = new List<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE>();
                SMetodos Servicio = new SMetodos();

                //===========================================================
                // PARAMETROS DE ENTRADA 
                //===========================================================
                iSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE ParametrosInput = new iSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE();
                ParametrosInput.ID_PROCESO_FILE = ID_PROCESO_FILE;

                LST_DETALLE_PRO_FILE = Servicio.SP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE(ParametrosInput);

                if (LST_DETALLE_PRO_FILE != null && LST_DETALLE_PRO_FILE.Count > 0)
                {
                    V_Global().DetalleProcesoFile = LST_DETALLE_PRO_FILE;
                }
                else
                {
                    V_Global().DetalleProcesoFile = new List<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE>();
                }

            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// LEER DETALLE DE PROCESO
        /// </summary>
        private void LEER_DETALLE_PROCESO_FILE_X_INTERFAZ(int ID_INTERFAZ)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_DETALLE_PROCESO_FILE> LST_DETALLE_PRO_FILE = new List<oSP_READ_DETALLE_PROCESO_FILE>();
                SMetodos Servicio = new SMetodos();

                //===========================================================
                // PARAMETROS DE ENTRADA 
                //===========================================================
                iSP_READ_DETALLE_PROCESO_FILE ParametrosInput = new iSP_READ_DETALLE_PROCESO_FILE();
                ParametrosInput.ID_INTERFAZ = ID_INTERFAZ;

                LST_DETALLE_PRO_FILE = Servicio.SP_READ_DETALLE_PROCESO_FILE(ParametrosInput);

                if (LST_DETALLE_PRO_FILE != null && LST_DETALLE_PRO_FILE.Count > 0)
                {
                    V_Global().DetalleFile = LST_DETALLE_PRO_FILE;
                }
                else
                {
                    V_Global().DetalleFile = new List<oSP_READ_DETALLE_PROCESO_FILE>();
                }

            }
            catch
            {

                throw;
            }
        }


        /// <summary>
        /// LEER INTERFAZ POR CAMPANA
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

                //===========================================================
                // CAMPO POR DEFECTO                                        
                //===========================================================                
                Lista.Add(new Item_Seleccion { Id = 0, Nombre = "SELECCIONE VALOR" });
                Lista = Lista.OrderBy(x => x.Id).ToList();

                FuncionesGenerales.CDDLCombos(Lista, DDL_INTERFAZ);

                //DDL_INTERFAZ_SelectedIndexChanged(null, null);

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
        protected void DDL_INTERFAZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (DDL_INTERFAZ.Items.Count > 0)
                {
                    int ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                    LEER_PROCESO_FILE(ID_INTERFAZ);
                    CARGAR_COMBO_PROCESO_FILE();
                    BindRepeater();
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
        /// AL SELECCIONAR CLUSTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_PROCESO_FILE_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SMetodos Servicio = new SMetodos();
                int ID_INTERFAZ = 0;
                int ID_PROCESO_FILE = 0;

                if (DDL_INTERFAZ.Items.Count > 0)
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                }

                if (ID_INTERFAZ == 0)
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UNA INTERFAZ", "MSG_INFO_SALIDAS_X_INTERFAZ", "MSG_ALERTA_SALIDAS_X_INTERFAZ");
                    return;
                }

                if (DDL_PROCESO_FILE.Items.Count > 0)
                {
                    List<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE> LST_DETALLE_PRO_FILE = new List<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE>();

                    ID_PROCESO_FILE = Convert.ToInt32(DDL_PROCESO_FILE.SelectedValue);

                    LEER_DETALLE_PROCESO_FILE(ID_PROCESO_FILE);

                    oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE DETALLE = V_Global().DetalleProcesoFile.OrderBy(x => x.ORDEN).Where(z => z.ID_DETALLE_INTERFAZ == 0).FirstOrDefault();

                    if (DETALLE != null && DETALLE.ID_DETALLE_PROCESO_FILE != 0)
                    {
                        DIV_CAMPOS.Visible = true;
                        TXT_ID_DETALLE_PROCESO_FILE.Text = DETALLE.ID_DETALLE_PROCESO_FILE.ToString();
                        LBL_DETALLE_FILE.Text = "CAMPO " + DETALLE.CAMPO_DET_PROCESO_FILE;


                    }
                    else
                    {
                        DIV_CAMPOS.Visible = false;
                        TXT_ID_DETALLE_PROCESO_FILE.Text = "0";
                        LBL_DETALLE_FILE.Text = "";
                    }

                    CARGAR_GRILLA_DETALLE_PROCESO_FILE();
                    
                    LEER_DETALLE_PROCESO_FILE_X_INTERFAZ(ID_INTERFAZ);

                    LEER_DETALLE_INTERFAZ(ID_INTERFAZ, ID_PROCESO_FILE);
                    CARGAR_COMBO_DETALLE_INTERFAZ(ID_INTERFAZ);

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
        /// CARGA LISTA DETALLE_INTERFAZ
        /// </summary>
        private void CARGAR_COMBO_DETALLE_INTERFAZ(int ID_INTERFAZ)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                ==
                //===========================================================                
                List<Item_Seleccion> lista = new List<Item_Seleccion>();
                List<oSP_READ_INTERFAZ_DETALLE> ListaSalidas = new List<oSP_READ_INTERFAZ_DETALLE>();

                //===========================================================
                // LLAMADA A SERVICIO
                //===========================================================
                ListaSalidas = V_Global().DetalleInterfaz;


                //====================================================================
                // RECORREMOS LAS LISTAS PARA PARA CREAR LISTA DE TIPO Item_Seleccion                                          
                //====================================================================                          
                lista = ListaSalidas.OrderBy(p => p.ORDEN).Select(p => new Item_Seleccion { Id = p.ID_INTERFAZ_DETALLE, Nombre = p.CAMPO }).ToList();

                //===========================================================
                // CAMPO POR DEFECTO                                        
                //===========================================================                
                lista.Add(new Item_Seleccion { Id = 0, Nombre = "SELECCIONE VALOR" });
                lista = lista.OrderBy(x => x.Id).ToList();

                FuncionesGenerales.CDDLListbox(lista, DDL_CAMPOS_INTERFAZ);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// CARGAR GRILLA DE DATOS
        /// </summary>
        private void LEER_DETALLE_INTERFAZ(int ID_INTERFAZ, int ID_PROCESO_FILE)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================
                SMetodos Negocio = new SMetodos();
                List<oSP_READ_INTERFAZ_DETALLE> ListaDetalle = new List<oSP_READ_INTERFAZ_DETALLE>();


                //===========================================================
                // CONSTRUCCION DE OBJETO
                //===========================================================
                iSP_READ_INTERFAZ_DETALLE ParametrosInput = new iSP_READ_INTERFAZ_DETALLE();
                ParametrosInput.ID_INTERFAZ = ID_INTERFAZ;

                //===========================================================
                // LLAMADA A SERVICIO
                //===========================================================
                ListaDetalle = Negocio.SP_READ_INTERFAZ_DETALLE(ParametrosInput);

                if (ListaDetalle == null && ListaDetalle.Count <= 0)
                {
                    V_Global().DetalleInterfaz = new List<oSP_READ_INTERFAZ_DETALLE>();
                }
                else
                {
                    List<oSP_READ_DETALLE_PROCESO_FILE> LST_DETALLE = V_Global().DetalleFile.Where(x => x.ID_PROCESO_FILE == ID_PROCESO_FILE).ToList();

                    foreach (oSP_READ_DETALLE_PROCESO_FILE item in LST_DETALLE)
                    {
                        if (item.ID_DETALLE_INTERFAZ != 0)
                        {
                            ListaDetalle.RemoveAll(x => x.ID_INTERFAZ_DETALLE == item.ID_DETALLE_INTERFAZ);    
                        }
                        
                    }

                    V_Global().DetalleInterfaz = ListaDetalle;
                }


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// CARGAR GRILLA DE DATOS
        /// </summary>
        private void CARGAR_GRILLA_DETALLE_PROCESO_FILE()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                SMetodos Servicio = new SMetodos();

                //===========================================================
                // LLAMADA A VIEWSTATE
                //===========================================================
                List<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE> Lista = V_Global().DetalleProcesoFile;

                if (Lista == null)
                {
                    Lista = new List<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE>();
                }

                FuncionesGenerales.Cargar_Grilla(Lista, GRD_DETALLE_PROCESO_FILE);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// GRILLA PRERENDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDData_PreRender(object sender, EventArgs e)
        {
            //try
            //{
            //    GRDData.UseAccessibleHeader = true;
            //    GRDData.HeaderRow.TableSection = TableRowSection.TableHeader;
            //}
            //catch { }
        }


        /// <summary>
        /// GRILLA PRERENDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRD_DETALLE_PROCESO_FILE_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRD_DETALLE_PROCESO_FILE.UseAccessibleHeader = true;
                GRD_DETALLE_PROCESO_FILE.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }

        /// <summary>
        /// GRILLA SALIDA_X_INTERFAZ ROWCOMMAND
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDData_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //===========================================================
                // ID                                                           
                //===========================================================               
                string[] arg = new string[2];
                arg = e.CommandArgument.ToString().Split(';');
                int ID_INTERFAZ = Convert.ToInt32(arg[0]);
                int ID_PROCESO_FILE = Convert.ToInt32(arg[1]);


                if (ID_INTERFAZ == 0) { return; }
                if (ID_PROCESO_FILE == 0) { return; }


                //===========================================================
                // ELIMINAR SALIDA                                 
                //===========================================================
                if (e.CommandName == "EliminarSalida")
                {

                    //TXT_ELIMINA_ID_INTERFAZ.Text = ID_INTERFAZ.ToString();
                    //TXT_ELIMINA_ID_PROCESO_FILE.Text = ID_PROCESO_FILE.ToString();

                    //LBL_TITULO_MENSAJE_ELIMINA_SALIDA_X_INTERFAZ.Text = ("LA ASIGNACIÓN SE ENCUENTRA INGRESADA EN EL SISTEMA "
                    //                                                    + Environment.NewLine
                    //                                                    + "¿ DESEA ELIMINAR DE TODAS FORMAS ?");

                    //FormularioModalJS("MODAL_ELIMINA_SALIDA_X_INTERFAZ", "MSG_INFO_ELIMINA_SALIDA_X_INTERFAZ", "MSG_ALERTA_ELIMINA_SALIDA_X_INTERFAZ");
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
        protected void GRD_DETALLE_PROCESO_FILE_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //===========================================================
                // ID                                                           
                //===========================================================          
                int ID_DETALLE_FILE_SALIDA = Convert.ToInt32(e.CommandArgument);

                if (ID_DETALLE_FILE_SALIDA == 0) { return; }

                //===========================================================
                // DECLARACION DE VARIAVLES 
                //=========================================================== 
                oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE Objeto = V_Global().DetalleProcesoFile.Where(x => x.ID_DETALLE_FILE_SALIDA == ID_DETALLE_FILE_SALIDA).First();

                //===========================================================
                // SUBIR ARCHIVO                     
                //===========================================================
                if (e.CommandName == "EliminarSalida")
                {

                    //===========================================================
                    // DECLARACION DE VARIABLES
                    //===========================================================
                    SMetodos Servicio = new SMetodos();

                    //===========================================================
                    // CONSULTAMOS SI LA INTERFAZ TIENE ASOCIADA UNA EJECUCION
                    //===========================================================
                    iSP_READ_EJECUCION_X_INTERFAZ ParametrosInput = new iSP_READ_EJECUCION_X_INTERFAZ();
                    ParametrosInput.ID_INTERFAZ = Objeto.ID_INTERFAZ;

                    //===========================================================
                    // LLAMADA A SERVICIO
                    //===========================================================
                    List<oSP_READ_EJECUCION_X_INTERFAZ> LST_EJECUCION = Servicio.SP_READ_EJECUCION_X_INTERFAZ(ParametrosInput);

                    if (LST_EJECUCION.Count > 0)
                    {
                        TXT_ID_DETALLE_FILE_SALIDA.Text = Objeto.ID_DETALLE_FILE_SALIDA.ToString();
                        LBL_TITULO_MENSAJE_ELIMINA_SALIDA_X_INTERFAZ.Text = ("LA SALIDA " + Objeto.CODIGO
                                                                            + Environment.NewLine
                                                                            + ", TIENE EJECUCIONES ACTIVAS NO ES POSIBLE ELIMINAR");

                        BTN_ELIMINA_SALIDA_X_INTERFAZ.Visible = false;
                    }
                    else
                    {
                        TXT_ID_DETALLE_FILE_SALIDA.Text = Objeto.ID_DETALLE_FILE_SALIDA.ToString();
                        LBL_TITULO_MENSAJE_ELIMINA_SALIDA_X_INTERFAZ.Text = ("EL ITEM SE ENCUENTRA INGRESADO EN EL SISTEMA "
                                                                            + Environment.NewLine
                                                                            + "¿ DESEA ELIMINAR DE TODAS FORMAS ?");

                        BTN_ELIMINA_SALIDA_X_INTERFAZ.Visible = true;
                    }

                    

                    FormularioModalJS("MODAL_ELIMINA_SALIDA_X_INTERFAZ", "MSG_INFO_ELIMINA_SALIDA_X_INTERFAZ", "MSG_ALERTA_ELIMINA_SALIDA_X_INTERFAZ");
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
        /// LEVANTA MODAL PARA CREAR NUEVA ASIGNACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BNT_NUEVA_ASIGNACION_Click(object sender, EventArgs e)
        {
            try
            {
                FormularioModalJS("MODAL_SALIDAS_X_INTERFAZ", "MSG_INFO_SALIDAS_X_INTERFAZ", "MSG_ALERTA_SALIDAS_X_INTERFAZ");
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
        /// BOTON PARA CREAR SALIDAS_X_INTERFAZ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_SALIDAS_X_INTERFAZ_Click(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================
                SMetodos Negocio = new SMetodos();
                int ID_INTERFAZ = 0;
                int ID_PROCESO_FILE = 0;
                int ID_CAMPO_INTERFAZ = 0;



                //===========================================================
                // VALIDACION DE SELECCION DE INTERFAZ                             
                //===========================================================
                if (Convert.ToInt32(DDL_INTERFAZ.SelectedValue) == 0)
                {
                    MensajeLOGEdit("A", "DEBE SELECCIONAR UNA INTERFAZ", "MSG_INFO_SALIDAS_X_INTERFAZ", "MSG_ALERTA_SALIDAS_X_INTERFAZ");
                    return;
                }
                else
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                }

                //===========================================================
                // VALIDACION DE SELECCION DE PROCESO FILE                             
                //===========================================================
                if (Convert.ToInt32(DDL_PROCESO_FILE.SelectedValue) == 0)
                {
                    MensajeLOGEdit("A", "DEBE SELECCIONAR UN PROCESO FILE", "MSG_INFO_SALIDAS_X_INTERFAZ", "MSG_ALERTA_SALIDAS_X_INTERFAZ");
                    return;
                }
                else
                {
                    ID_PROCESO_FILE = Convert.ToInt32(DDL_PROCESO_FILE.SelectedValue);
                }

                //===========================================================
                // VALIDACION DE SELECCION DE CAMPOS INTERFAZ                           
                //===========================================================
                if (Convert.ToInt32(DDL_CAMPOS_INTERFAZ.SelectedValue) == 0)
                {
                    MensajeLOGEdit("A", "DEBE SELECCIONAR UN CAMPO DE INTERFAZ", "MSG_INFO_SALIDAS_X_INTERFAZ", "MSG_ALERTA_SALIDAS_X_INTERFAZ");
                    return;
                }
                else
                {
                    ID_CAMPO_INTERFAZ = Convert.ToInt32(DDL_CAMPOS_INTERFAZ.SelectedValue);
                }


                //===========================================================
                // INGRESAR SALIDAS_X_INTERFAZ
                //===========================================================

                //=======================================================
                // CONSTRUCCION DE OBJETO
                //=======================================================
                iSP_CREATE_DETALLE_FILE_SALIDA ParametrosInput = new iSP_CREATE_DETALLE_FILE_SALIDA();
                ParametrosInput.ID_DETALLE_PROCESO_FILE = Convert.ToInt32(TXT_ID_DETALLE_PROCESO_FILE.Text);
                ParametrosInput.ID_DETALLE_INTERFAZ = ID_CAMPO_INTERFAZ;

                //=======================================================
                // LLAMADA A NEGOCIO
                //=======================================================
                oSP_RETURN_STATUS ESTADO = Negocio.SP_CREATE_DETALLE_FILE_SALIDA(ParametrosInput);

                if (ESTADO.RETURN_VALUE == -1)
                {

                    MensajeLOGEdit("A", "LA ASIGNACIÓN YA EXISTE", "MSG_INFO_SALIDAS_X_INTERFAZ", "MSG_ALERTA_SALIDAS_X_INTERFAZ");
                    return;
                }


                if (ESTADO.RETURN_VALUE == 0)
                {

                    MensajeLOGEdit("A", "LA ASIGNACIÓN NO FUE INGRESADA", "MSG_INFO_SALIDAS_X_INTERFAZ", "MSG_ALERTA_SALIDAS_X_INTERFAZ");
                    return;
                }

                if (ESTADO.RETURN_VALUE == 1)
                {
                    BindRepeater();
                    MensajeLOGEdit("I", "LA ASIGNACIÓN FUE INGRESADA CORRECTAMENTE", "MSG_INFO_SALIDAS_X_INTERFAZ", "MSG_ALERTA_SALIDAS_X_INTERFAZ");


                    DDL_PROCESO_FILE_SelectedIndexChanged(null, null);
                    return;
                }


                //LEER_DETALLE_PROCESO_FILE(ID_PROCESO_FILE);
                //CARGAR_GRILLA_DETALLE_PROCESO_FILE();

            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_INFO_SALIDAS_X_INTERFAZ", "MSG_ALERTA_SALIDAS_X_INTERFAZ");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_SALIDAS_X_INTERFAZ", "MSG_ALERTA_SALIDAS_X_INTERFAZ");
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
                if (DDL_INTERFAZ.Items.Count > 0)
                {
                    int ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                    LEER_PROCESO_FILE(ID_INTERFAZ);
                    CARGAR_COMBO_PROCESO_FILE();
                    BindRepeater();
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
        /// BOTON PARA ELIMINAR UNA SALIDA_X_INTERFAZ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_ELIMINA_SALIDA_X_INTERFAZ_Click(object sender, EventArgs e)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================
                SMetodos Negocio = new SMetodos();

                int ID_DETALLE_FILE_SALIDA = 0;

                //===========================================================
                // VALIDACION DE SELECCION DE SALIDA                             
                //===========================================================
                if (Convert.ToInt32(TXT_ID_DETALLE_FILE_SALIDA.Text) == 0)
                {
                    MensajeLOGEdit("A", "SALIDA NO VALIDA", "MSG_INFO_ELIMINA_SALIDA_X_INTERFAZ", "MSG_ALERTA_ELIMINA_SALIDA_X_INTERFAZ");
                    return;
                }
                else
                {
                    ID_DETALLE_FILE_SALIDA = Convert.ToInt32(TXT_ID_DETALLE_FILE_SALIDA.Text);
                }

                //=======================================================
                // CONSTRUCCION DE OBJETO
                //=======================================================
                iSP_DELETE_DETALLE_FILE_SALIDA ParametrosInput = new iSP_DELETE_DETALLE_FILE_SALIDA();
                ParametrosInput.ID_DETALLE_FILE_SALIDA = ID_DETALLE_FILE_SALIDA;


                //=======================================================
                // LLAMADA A NEGOCIO
                //=======================================================
                oSP_RETURN_STATUS ESTADO_SISTEMA_X_INSTITUCION = Negocio.SP_DELETE_DETALLE_FILE_SALIDA(ParametrosInput);


                if (ESTADO_SISTEMA_X_INSTITUCION.RETURN_VALUE == 0)
                {

                    MensajeLOGEdit("I", "LA ASIGNACIÓN NO FUE ELIMINADA", "MSG_INFO_ELIMINA_SALIDA_X_INTERFAZ", "MSG_ALERTA_ELIMINA_SALIDA_X_INTERFAZ");
                    return;
                }

                if (ESTADO_SISTEMA_X_INSTITUCION.RETURN_VALUE == 1)
                {
                    MensajeLOGEdit("I", "LA ASIGNACIÓN FUE ELIMINADA CORRECTAMENTE", "MSG_INFO_ELIMINA_SALIDA_X_INTERFAZ", "MSG_ALERTA_ELIMINA_SALIDA_X_INTERFAZ");
                    BindRepeater();
                    DDL_PROCESO_FILE_SelectedIndexChanged(null, null);
                    return;
                }

            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_INFO_ELIMINA_SALIDA_X_INTERFAZ", "MSG_ALERTA_ELIMINA_SALIDA_X_INTERFAZ");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_ELIMINA_SALIDA_X_INTERFAZ", "MSG_ALERTA_ELIMINA_SALIDA_X_INTERFAZ");
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
                MSG_ALERTA.InnerHtml = WebUtility.HtmlDecode(Mensaje);
                PNL_MENSAJE.Visible = true;
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
        /// VIEWSTATE PARA VARIABLES GLOBALES
        /// </summary>
        private void Establecer_Globales()
        {
            try
            {
                ViewState["GlobalesSalidas"] = new GlobalesSalidas();
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
        private GlobalesSalidas V_Global()
        {


            GlobalesSalidas item = new GlobalesSalidas();
            try
            {

                item = (GlobalesSalidas)ViewState["GlobalesSalidas"] ?? null;
                return item;
            }
            catch
            {
                return item;
            }

        }


        [Serializable]
        public class GlobalesSalidas
        {
            public List<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE> DetalleProcesoFile { get; set; }
            public List<oSP_READ_DETALLE_PROCESO_FILE> DetalleFile { get; set; }
            public List<oSP_READ_PROCESO_FILE> ProcesoFile { get; set; }
            public List<oSP_READ_INTERFAZ_DETALLE> DetalleInterfaz { get; set; }
        }
    }
}
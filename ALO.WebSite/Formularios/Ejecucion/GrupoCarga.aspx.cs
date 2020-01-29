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
    public partial class GrupoCarga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // POSTBACK                                               
                //===========================================================
                if (!this.IsPostBack)
                {

                    Establecer_Globales();

                    CARGAR_COMBO_CLUSTER();

                    LEER_GRUPO_CARGA(0);
                    LEER_DETALLE_GRUPO_CARGA(0);
                    LINK_SUBIR_ARCHIVO.Visible = false;
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
        /// LEVANTA MODAL PARA CREAR NUEVO GRUPO DE CARGA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BNT_NUEVO_GRUPO_Click(object sender, EventArgs e)
        {
            try
            {
                TXT_ID_GRUPO_CARGA_MODAL.Text = "0";
                TXT_ID_CLUSTER_MODAL.Text = "0";
                TXT_DESCRIPCION.Text = "";
                TXT_LLAVE_EXPLOTACION.Text = "";
                TXT_LLAVE_NOTIFICACION.Text = "";
                TXT_LLAVE_VERIFICACION.Text = "";
                LBL_TITULO_GRUPO_CARGA.Text = "CREAR GRUPO DE CARGA";
                BTN_GRUPO_CARGA.Text = "CREAR";
                FormularioModalJS("MODAL_GRUPO_CARGA", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
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
        /// LEVANTA MODAL PARA CREAR NUEVO GRUPO DE CARGA
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_GRUPO_CARGA_Click(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================           
                SMetodos Servicio = new SMetodos();
                int ID_CLUSTER = 0;
                string DESCRIPCION = "";
                string LLAVE_EXPLOTACION = "";
                string LLAVE_NOTIFICACION = "";
                string LLAVE_VERIFICACION = "";

                //===========================================================
                // VALIDACION DE SELECCION DE CAMPANA
                //===========================================================   
                if (DDL_SELECT_CLUSTER.Items.Count > 0)
                {
                    ID_CLUSTER = Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue);
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UNA CLUSTER", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                    return;
                }

                //===========================================================
                // VALIDACION DE DESCRIPCION
                //===========================================================   
                if (!string.IsNullOrWhiteSpace(TXT_DESCRIPCION.Text))
                {
                    DESCRIPCION = TXT_DESCRIPCION.Text;
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES INGRESAR UNA DESCRIPCION", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                    return;
                }

                //===========================================================
                // VALIDACION DE LLAVE DE LISTA PARA EXPLOTACION
                //===========================================================   
                if (!string.IsNullOrWhiteSpace(TXT_LLAVE_EXPLOTACION.Text))
                {
                    LLAVE_EXPLOTACION = TXT_LLAVE_EXPLOTACION.Text;
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES INGRESAR UNA LLAVE PARA LA LISTA DE EXPLOTACIÓN", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                    return;
                }


                //===========================================================
                // VALIDACION DE LLAVE DE LISTA PARA NOTIFICACION
                //===========================================================   
                if (!string.IsNullOrWhiteSpace(TXT_LLAVE_NOTIFICACION.Text))
                {
                    LLAVE_NOTIFICACION = TXT_LLAVE_NOTIFICACION.Text;
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES INGRESAR UNA LLAVE PARA LA LISTA DE NOTIFICACIÓN", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                    return;
                }


                //===========================================================
                // VALIDACION DE LLAVE DE LISTA PARA VERIFICACION
                //===========================================================   
                if (!string.IsNullOrWhiteSpace(TXT_LLAVE_VERIFICACION.Text))
                {
                    LLAVE_VERIFICACION = TXT_LLAVE_VERIFICACION.Text;
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES INGRESAR UNA LLAVE PARA LA LISTA DE VERIFICACIÓN", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                    return;
                }


                if (Convert.ToInt32(TXT_ID_GRUPO_CARGA_MODAL.Text) == 0)
                {

                    //=======================================================
                    // CONSTRUCCION DE OBJETO
                    //=======================================================
                    iSP_CREATE_GRUPO_CARGA ParametrosInput = new iSP_CREATE_GRUPO_CARGA();
                    ParametrosInput.ID_CLUSTER = ID_CLUSTER;
                    ParametrosInput.DESCRIPCION = DESCRIPCION;
                    ParametrosInput.LLAVE_LISTA_EXPLOTADOR = LLAVE_EXPLOTACION;
                    ParametrosInput.LLAVE_LISTA_NOTIFICACION = LLAVE_NOTIFICACION;
                    ParametrosInput.LLAVE_LISTA_VERIFICACION = LLAVE_VERIFICACION;

                    //=======================================================
                    // LLAMADA A SERVICIO
                    //=======================================================
                    oSP_CREATE_GRUPO_CARGA GRUPO_CARGA = Servicio.SP_CREATE_GRUPO_CARGA(ParametrosInput);

                    if (GRUPO_CARGA.ID_GRUPO_CARGA == -1)
                    {
                        MensajeLOGEdit("A", "EL GRUPO DE CARGA YA SE ENCUENTRA EN EL SISTEMA", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                        return;
                    }

                    if (GRUPO_CARGA.ID_GRUPO_CARGA == 0)
                    {
                        MensajeLOGEdit("A", "EL GRUPO DE CARGA NO FUE INGRESADO", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                        return;
                    }

                    if (GRUPO_CARGA.ID_GRUPO_CARGA > 0)
                    {
                        MensajeLOGEdit("I", "EL GRUPO DE CARGA FUE INGRESADO CORRECTAMENTE", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                        LEER_GRUPO_CARGA(ID_CLUSTER);
                        LEER_DETALLE_GRUPO_CARGA(GRUPO_CARGA.ID_GRUPO_CARGA);
                        return;
                    }

                }

                if (Convert.ToInt32(TXT_ID_GRUPO_CARGA_MODAL.Text) > 0)
                {
                    int ID_GRUPO_CARGA = Convert.ToInt32(TXT_ID_GRUPO_CARGA_MODAL.Text);
                    //=======================================================
                    // CONSTRUCCION DE OBJETO
                    //=======================================================
                    iSP_UPDATE_GRUPO_CARGA ParametrosInput = new iSP_UPDATE_GRUPO_CARGA();
                    ParametrosInput.ID_GRUPO_CARGA = ID_GRUPO_CARGA;
                    ParametrosInput.ID_CLUSTER = ID_CLUSTER;
                    ParametrosInput.DESCRIPCION = DESCRIPCION;
                    ParametrosInput.LLAVE_LISTA_EXPLOTADOR = LLAVE_EXPLOTACION;
                    ParametrosInput.LLAVE_LISTA_NOTIFICACION = LLAVE_NOTIFICACION;
                    ParametrosInput.LLAVE_LISTA_VERIFICACION = LLAVE_VERIFICACION;


                    //=======================================================
                    // LLAMADA A SERVICIO
                    //=======================================================
                    oSP_RETURN_STATUS ESTADO = Servicio.SP_UPDATE_GRUPO_CARGA(ParametrosInput);

                    if (ESTADO.RETURN_VALUE == -1)
                    {
                        MensajeLOGEdit("A", "EL GRUPO DE CARGA YA SE ENCUENTRA EN EL SISTEMA", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOGEdit("A", "EL GRUPO DE CARGA NO FUE INGRESADO", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 1)
                    {
                        MensajeLOGEdit("I", "EL GRUPO DE CARGA FUE ACTUALIZADO CORRECTAMENTE", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                        LEER_GRUPO_CARGA(ID_CLUSTER);
                        LEER_DETALLE_GRUPO_CARGA(ID_GRUPO_CARGA);
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
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                //MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }
        }

        /// <summary>
        /// REDIRECCIONA PARA CARGAR ARCHIVO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_CARGA_ARCHIVO_Click(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================           
                SMetodos Servicio = new SMetodos();
                int ID_INTERFAZ = 0;
                int ID_GRUPO_CARGA = 0;
                int ID_CLUSTER = 0;
                string CODIGO_INTERFAZ = "";

                //===========================================================
                // VALIDACION DE SELECCION DE INTERFAZ
                //===========================================================   
                if (Convert.ToInt32(DDL_INTERFAZ.SelectedValue) > 0)
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                    CODIGO_INTERFAZ = DDL_INTERFAZ.SelectedItem.ToString();
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UNA INTERFAZ", "MSG_INFO_ARCHIVO", "MSG_ALERTA_ARCHIVO");
                    return;
                }

                //===========================================================
                // VALIDACION DE CLUSTER
                //===========================================================   
                if (!string.IsNullOrWhiteSpace(TXT_ID_CLUSTER.Text))
                {
                    try
                    {
                        ID_CLUSTER = Convert.ToInt32(TXT_ID_CLUSTER.Text);
                    }
                    catch
                    {
                        MensajeLOGEdit("A", "DEBES INGRESAR UN CLUSTER", "MSG_INFO_ARCHIVO", "MSG_ALERTA_ARCHIVO");
                        return;
                    }
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES INGRESAR UN CLUSTER", "MSG_INFO_ARCHIVO", "MSG_ALERTA_ARCHIVO");
                    return;
                }

                //===========================================================
                // VALIDACION DE GRUPO DE CARGA
                //===========================================================   
                if (!string.IsNullOrWhiteSpace(TXT_ID_GRUPO_CARGA.Text))
                {
                    try
                    {
                        ID_GRUPO_CARGA = Convert.ToInt32(TXT_ID_GRUPO_CARGA.Text);
                    }
                    catch
                    {
                        MensajeLOGEdit("A", "DEBES INGRESAR UN GRUPO DE CARGA", "MSG_INFO_ARCHIVO", "MSG_ALERTA_ARCHIVO");
                        return;
                    }
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES INGRESAR UN GRUPO DE CARGA", "MSG_INFO_ARCHIVO", "MSG_ALERTA_ARCHIVO");
                    return;

                }

                //===========================================================
                // REDIRECCIONAMOS 
                //=========================================================== 
                Response.Redirect("~/INTERFAZ/UPLOAD?OPCION=I" + "&CODIGO_INTERFAZ=" + CODIGO_INTERFAZ + "&ID_INTERFAZ=" + ID_INTERFAZ + "&ID_GRUPO_CARGA=" + ID_GRUPO_CARGA, "_blank");

            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(srv), "MSG_INFO_ARCHIVO", "MSG_ALERTA_ARCHIVO");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_ARCHIVO", "MSG_ALERTA_ARCHIVO");
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

                oSP_READ_GRUPO_CARGA GRUPO = V_Global().Grupos.Where(x => x.ID_GRUPO_CARGA == ID_GRUPO_CARGA).First();

                LEER_DETALLE_GRUPO_CARGA(ID_GRUPO_CARGA);


                //===========================================================
                // BUSCAR DETALLES                     
                //===========================================================
                if (e.CommandName == "BuscarDetalle")
                {
                    LEER_EJECUCIONES(ID_GRUPO_CARGA);
                }

                //===========================================================
                // EDITAR GRUPO                     
                //===========================================================
                if (e.CommandName == "EditarGrupo")
                {
                    //List<int> INTERFACES = new List<int>();

                    //List<oSP_READ_INTERFAZ_X_GRUPO> EJECUCIONES = V_Global().Interfaz_x_grupo.Where(x => x.ID_GRUPO_CARGA == ID_GRUPO_CARGA).ToList();

                    //foreach (oSP_READ_INTERFAZ_X_GRUPO item in EJECUCIONES)
                    //{
                    //    INTERFACES.Add(item.ID_INTERFAZ);
                    //}

                    TXT_ID_GRUPO_CARGA_MODAL.Text = GRUPO.ID_GRUPO_CARGA.ToString();
                    TXT_ID_CLUSTER_MODAL.Text = GRUPO.ID_CLUSTER.ToString();
                    TXT_DESCRIPCION.Text = GRUPO.DESCRIPCION;
                    TXT_LLAVE_EXPLOTACION.Text = GRUPO.LLAVE_LISTA_EXPLOTADOR;
                    TXT_LLAVE_NOTIFICACION.Text = GRUPO.LLAVE_LISTA_NOTIFICACION;
                    TXT_LLAVE_VERIFICACION.Text = GRUPO.LLAVE_LISTA_VERIFICACION;

                    LBL_TITULO_GRUPO_CARGA.Text = "ACTUALIZAR GRUPO DE CARGA";
                    BTN_GRUPO_CARGA.Text = "ACTUALIZAR";

                    //FuncionesGenerales.SeleccionarItemsListBox(LST_INTERFACES, INTERFACES);

                    FormularioModalJS("MODAL_GRUPO_CARGA", "MSG_INFO_GRUPO_CARGA", "MSG_ALERTA_GRUPO_CARGA");
                }

                //===========================================================
                // EDITAR GRUPO                     
                //===========================================================
                if (e.CommandName == "CargarArchivo")
                {
                    TXT_ID_GRUPO_CARGA.Text = GRUPO.ID_GRUPO_CARGA.ToString();
                    TXT_ID_CLUSTER.Text = GRUPO.ID_CLUSTER.ToString();

                    LBL_TITULO_ARCHIVO.Text = "SUBIR ARCHIVO ASOCIADO A INTERFAZ";

                    FormularioModalJS("MODAL_ARCHIVO", "MSG_INFO_ARCHIVO", "MSG_ALERTA_ARCHIVO");
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
        protected void GRD_INTERFAZ_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //===========================================================
                // ID                                                           
                //===========================================================          
                string[] IDS = e.CommandArgument.ToString().Split(';');
                int ID_INTERFAZ = Convert.ToInt32(IDS[0]);
                int ID_GRUPO_CARGA = Convert.ToInt32(IDS[1]);
                int ID_EJECUCION = Convert.ToInt32(IDS[2]);

                if (ID_INTERFAZ == 0) { return; }
                if (ID_GRUPO_CARGA == 0) { return; }
                if (ID_EJECUCION == 0) { return; }


                //===========================================================
                // DECLARACION DE VARIABLES 
                //=========================================================== 
                oSP_READ_INTERFAZ_X_CLUSTER ObjetoInterfaz = V_Global().Interfaces.Where(x => x.ID_INTERFAZ == ID_INTERFAZ).First();

                //===========================================================
                // SUBIR ARCHIVO                     
                //===========================================================
                if (e.CommandName == "subirArchivo")
                {
                    Response.Redirect("~/INTERFAZ/UPLOAD?OPCION=I" + "&CODIGO_INTERFAZ=" + ObjetoInterfaz.CODIGO_INTERFAZ + "&ID_INTERFAZ=" + ObjetoInterfaz.ID_INTERFAZ + "&ID_GRUPO_CARGA=" + ID_GRUPO_CARGA, "_blank");
                }

                //===========================================================
                // QUITAR ARCHIVO                     
                //===========================================================
                if (e.CommandName == "quitarArchivo")
                {
                    //===========================================================
                    // DECLARACION DE VARIABLES
                    //===========================================================
                    SMetodos Servicio = new SMetodos();

                    //===========================================================
                    // CONSTRUCCION DE OBJETO
                    //===========================================================
                    iSP_DELETE_DETALLE_GRUPO_CARGA_X_EJECUCION prametrosInput = new iSP_DELETE_DETALLE_GRUPO_CARGA_X_EJECUCION();
                    prametrosInput.ID_EJECUCION = ID_EJECUCION;

                    //===========================================================
                    // LLAMADA A SERVICIO
                    //===========================================================
                    Servicio.SP_DELETE_DETALLE_GRUPO_CARGA_X_EJECUCION(prametrosInput);



                    //===========================================================
                    // CONSTRUCCION DE OBJETO
                    //=========================================================== 
                    iSP_UPDATE_GRUPO_CARGA_ESTADO ParametrosInput = new iSP_UPDATE_GRUPO_CARGA_ESTADO();
                    ParametrosInput.ID_ESTADO_CARGA = (int)T_ESTADO_GRUPO_CARGA.SIN_ESTADO;
                    ParametrosInput.ID_GRUPO_CARGA = ID_GRUPO_CARGA;
                    ParametrosInput.MENSAJE = " ";

                    //===========================================================
                    // LLAMADA A SERVICIO
                    //=========================================================== 
                    Servicio.SP_UPDATE_GRUPO_CARGA_ESTADO(ParametrosInput);

                    LEER_DETALLE_GRUPO_CARGA(ID_GRUPO_CARGA);

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
        protected void GRD_INTERFAZ_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRD_INTERFAZ.UseAccessibleHeader = true;
                GRD_INTERFAZ.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }



        /// <summary>
        /// BOTON PROCESO
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
                    CARGAR_COMBO_INTERFAZ_X_CLUSTER(ID_CLUSTER);
                    LEER_GRUPO_CARGA(ID_CLUSTER);
                }

            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOG(srv.Message, "ERROR DE SERVICIO");
            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERROR DE APLICACIÓN");
            }

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
        /// CARGA COMBO DE  INTERFAZ POR CLUSTER
        /// </summary>
        private void CARGAR_COMBO_INTERFAZ_X_CLUSTER(int ID_CLUSTER)
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

                //===========================================================
                // QUITAMOS LAS INTERFACES QUE NO TENGA ARCHIVOS CARGADOS   
                //===========================================================
                //ListaInterfazEmpresa = ListaInterfazEmpresa.Where(x => x.ID_EJECUCION != 0).ToList();

                foreach (oSP_READ_INTERFAZ_X_CLUSTER item in ListaInterfazEmpresa)
                {
                    Lista.Add(new Item_Seleccion { Id = item.ID_INTERFAZ, Nombre = item.CODIGO_INTERFAZ });
                }


                if (ListaInterfazEmpresa == null || ListaInterfazEmpresa.Count <= 0)
                {
                    V_Global().Interfaces = new List<oSP_READ_INTERFAZ_X_CLUSTER>();
                    Lista.Add(new Item_Seleccion { Id = 0, Nombre = "NO HAY DATOS" });
                }
                else
                {
                    V_Global().Interfaces = ListaInterfazEmpresa;

                    Lista.Add(new Item_Seleccion { Id = 0, Nombre = "SELECCIONE VALOR" });
                    Lista = Lista.OrderBy(x => x.Id).ToList();
                }


                FuncionesGenerales.CDDLCombos(Lista, DDL_INTERFAZ);

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LEER GRUPOS DE CARGA
        /// </summary>
        private void LEER_DETALLE_GRUPO_CARGA(int ID_GRUPO_CARGA)
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
                else
                {
                    V_Global().DetalleGrupo = LST_REST;
                }

                FuncionesGenerales.Cargar_Grilla(LST_REST, GRD_INTERFAZ);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LEER GRUPO DE CARGA POR CAMPANA
        /// </summary>
        private void LEER_GRUPO_CARGA(int ID_CLUSTER)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                SMetodos Servicio = new SMetodos();

                //===========================================================
                // TRAER LISTA DE EMPRESAS REGISTRADAS EN SISTEMA               
                //===========================================================
                List<oSP_READ_GRUPO_CARGA> ListaGrupoCarga = new List<oSP_READ_GRUPO_CARGA>();
                ListaGrupoCarga = Servicio.SP_READ_GRUPO_CARGA(new iSP_READ_GRUPO_CARGA { ID_CLUSTER = ID_CLUSTER });


                if (ListaGrupoCarga == null)
                {
                    V_Global().Grupos = new List<oSP_READ_GRUPO_CARGA>();
                }
                else
                {
                    V_Global().Grupos = ListaGrupoCarga;
                }

                FuncionesGenerales.Cargar_Grilla(ListaGrupoCarga, GRDDataGrupo);

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
                    CARGAR_COMBO_INTERFAZ_X_CLUSTER(ID_CLUSTER);
                    LEER_GRUPO_CARGA(ID_CLUSTER);
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
                int ID_INTERFAZ = 0;

                if (DDL_INTERFAZ.Items.Count > 0)
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                }

                if (ID_INTERFAZ > 0)
                {
                    LINK_SUBIR_ARCHIVO.Visible = true;
                }
                else
                {
                    LINK_SUBIR_ARCHIVO.Visible = false;
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
        /// LEER INSTITUCIONES
        /// </summary>
        private void LEER_EJECUCIONES(int ID_GRUPO_CARGA)
        {
            try
            {
                //===============================================================================
                // DECLARACION DE VARIABLES
                //===============================================================================
                List<oSP_READ_EJECUCION_X_GRUPO_CARGA> LISTA_EJECUCION = new List<oSP_READ_EJECUCION_X_GRUPO_CARGA>();

                SMetodos Servicio = new SMetodos();

                //===============================================================================
                // CONSTRUCCION DE OBJETO
                //===============================================================================
                iSP_READ_EJECUCION_X_GRUPO_CARGA ParametrosInput = new iSP_READ_EJECUCION_X_GRUPO_CARGA();
                ParametrosInput.ID_GRUPO_CARGA = ID_GRUPO_CARGA;


                //===============================================================================
                // LLAMADA A SERVICIO
                //===============================================================================
                LISTA_EJECUCION = Servicio.SP_READ_EJECUCION_X_GRUPO_CARGA(ParametrosInput);

                //===============================================================================
                // VALIDACION DE OBTENSION DE DATOS
                //===============================================================================
                if (LISTA_EJECUCION != null && LISTA_EJECUCION.Count > 0)
                {
                    V_Global().ListaEjecucion = LISTA_EJECUCION;

                }
                else
                {
                    V_Global().ListaEjecucion = new List<oSP_READ_EJECUCION_X_GRUPO_CARGA>();
                }
            }
            catch
            {

                throw;
            }
        }

        ///// <summary>
        ///// AL SELECCIONAR INTERFAZ
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //protected void DDL_INTERFAZ_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int ID_INTERFAZ = 0;
        //        try
        //        {
        //            //===============================================================================
        //            // RESCATAMOS ID
        //            //===============================================================================
        //            ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
        //        }
        //        catch
        //        {
        //            throw new Exception("LA INTERFAZ SELECCIONADA NO ES UN NUMERO");
        //        }

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
        /// VIEWSTATE PARA VARIABLES GLOBALES
        /// </summary>
        private void Establecer_Globales()
        {
            try
            {
                ViewState["GlobalesGrupoCarga"] = new GlobalesGrupoCarga();
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
        private GlobalesGrupoCarga V_Global()
        {


            GlobalesGrupoCarga item = new GlobalesGrupoCarga();
            try
            {

                item = (GlobalesGrupoCarga)ViewState["GlobalesGrupoCarga"] ?? null;
                return item;
            }
            catch
            {
                return item;
            }

        }

        [Serializable]
        public class GlobalesGrupoCarga
        {
            public List<oSP_READ_INTERFAZ_X_CLUSTER> Interfaces { get; set; }
            public List<oSP_READ_DETALLE_GRUPO_CARGA_WEB> DetalleGrupo { get; set; }
            public List<oSP_READ_GRUPO_CARGA> Grupos { get; set; }
            public List<oSP_READ_EJECUCION_X_GRUPO_CARGA> ListaEjecucion { get; set; }
        }
    }
}
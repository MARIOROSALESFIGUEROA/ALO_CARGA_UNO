using ALO.Entidades;
using ALO.Servicio;
using ALO.Utilidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ALO.WebSite.Formularios.Ejecucion
{
    public partial class AsignacionPlanificacion : System.Web.UI.Page
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

                    LEER_INTERFAZ_X_CLUSTER(0);
                    CARGAR_COMBO_INTERFAZ_X_CLUSTER(0);

                    LEER_SP_PARAMETROS_X_SP("SP");
                    CARGAR_GRILLA_SP_PARAMETROS();

                    LEER_EJECUCIONES_X_INTERFAZ(0);
                    CARGAR_GRILLA_EJECUCIONES();

                    LEER_DETALLE_INTERFAZ(0);

                    CARGAR_COMBO_INTERFAZ_DETALLE();

                    DIV_TABLA_ASIGNACION.Visible = false;
                    DIV_PANEL.Visible = false;

                    //=========================================================================
                    // CARGAMOS COMBO DE TABLAS DE ASIGNACION CON VALOR POR DEFECTO
                    //=========================================================================
                    List<Item_Seleccion> Lista = new List<Item_Seleccion>();
                    Lista.Add(new Item_Seleccion { Id = 0, Nombre="SELECCIONE VALOR"});                    
                    FuncionesGenerales.CDDLCombos(Lista, DDL_TABLA_ASIGNACION);

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
        /// BOTON PARA ASIGAR CAMPOS A PARAMETROS DE PROCEDIMIENTO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LINK_Asignacion_Click(object sender, EventArgs e)
        {
            try
            {
                //===========================================================
                // RESCATAMOS LISTA DESDE VIEW STATE
                //===========================================================
                List<oSP_READ_SP_PARAMETRO_X_SP> lista = V_Global().ParametrosProcedimiento;

                //===========================================================
                // CONSULTAMOS CUAL ES EL PRIMER CAMPO PARA ASIGNAR
                //===========================================================
                oSP_READ_SP_PARAMETRO_X_SP PARAMETRO = lista.OrderBy(x => x.ORDEN_SP_PARAMETRO).Where(x => x.ORDEN_SP_PARAMETRO > 3 && x.CAMPO_INTERFAZ_DETALLE == " ").First();

                //===========================================================
                // SETEAMOS VALORES 
                //===========================================================
                LBL_DETALLE_CAMPO.Text = "CAMPO " + PARAMETRO.CAMPO_SP_PARAMETRO;
                TXT_ID_PARAMETRO_SP.Text = PARAMETRO.ID_SP_PARAMETRO.ToString();
                TXT_NAME_SP.Text = PARAMETRO.NAME_SP;

                CARGAR_GRILLA_SP_PARAMETROS();

                FormularioModalJS("MODAL_ASIGNACION_CAMPOS", "MSG_INFO_ASIGNACION_CAMPOS", "MSG_ALERTA_ASIGNACION_CAMPOS");
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
        /// BOTON PARA ASIGNAR CAMPOS DE INTERFAZ A PROCEDIMIENTO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_ASIGNACION_CAMPOS_Click(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================
                SMetodos Negocio = new SMetodos();
                int ID_INTERFAZ = 0;
                int ID_PARAMETRO_SP = 0;
                int ID_CAMPO_INTERFAZ = 0;
                string SP_NAME = "";

                //===========================================================
                // VALIDACION DE SELECCION DE INTERFAZ                             
                //===========================================================
                if (Convert.ToInt32(DDL_INTERFAZ.SelectedValue) == 0)
                {
                    MensajeLOGEdit("A", "DEBE SELECCIONAR UNA INTERFAZ", "MSG_INFO_ASIGNACION_CAMPOS", "MSG_ALERTA_ASIGNACION_CAMPOS");
                    return;
                }
                else
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                }

                //===========================================================
                // VALIDACION DE SELECCION DE SP
                //===========================================================
                if (string.IsNullOrWhiteSpace(TXT_ID_PARAMETRO_SP.Text))
                {
                    MensajeLOGEdit("A", "PARAMETRO NO VALIDO", "MSG_INFO_ASIGNACION_CAMPOS", "MSG_ALERTA_ASIGNACION_CAMPOS");
                    return;
                }
                else
                {
                    ID_PARAMETRO_SP = Convert.ToInt32(TXT_ID_PARAMETRO_SP.Text);
                }

                //===========================================================
                // VALIDACION DE SELECCION DE SP
                //===========================================================
                if (string.IsNullOrWhiteSpace(TXT_NAME_SP.Text))
                {
                    MensajeLOGEdit("A", "PARAMETRO NO VALIDO", "MSG_INFO_ASIGNACION_CAMPOS", "MSG_ALERTA_ASIGNACION_CAMPOS");
                    return;
                }
                else
                {
                    SP_NAME = TXT_NAME_SP.Text;
                }

                //===========================================================
                // VALIDACION DE SELECCION DE CAMPOS INTERFAZ                           
                //===========================================================
                if (Convert.ToInt32(DDL_INTERFAZ_DETALLE.SelectedValue) == 0)
                {
                    MensajeLOGEdit("A", "DEBE SELECCIONAR UN CAMPO DE INTERFAZ", "MSG_INFO_ASIGNACION_CAMPOS", "MSG_ALERTA_ASIGNACION_CAMPOS");
                    return;
                }
                else
                {
                    ID_CAMPO_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ_DETALLE.SelectedValue);
                }


                //===========================================================
                // INGRESAR SALIDAS_X_INTERFAZ
                //===========================================================

                //=======================================================
                // CONSTRUCCION DE OBJETO
                //=======================================================
                iSP_CREATE_INTERFAZ_DETALLE_X_SP_PARAMETRO ParametrosInput = new iSP_CREATE_INTERFAZ_DETALLE_X_SP_PARAMETRO();
                ParametrosInput.ID_SP_PARAMETRO = ID_PARAMETRO_SP;
                ParametrosInput.ID_INTERFAZ_DETALLE = ID_CAMPO_INTERFAZ;

                //=======================================================
                // LLAMADA A NEGOCIO
                //=======================================================
                oSP_RETURN_STATUS ESTADO = Negocio.SP_CREATE_INTERFAZ_DETALLE_X_SP_PARAMETRO(ParametrosInput);

                if (ESTADO.RETURN_VALUE == -1)
                {
                    MensajeLOGEdit("A", "LA ASIGNACIÓN YA EXISTE", "MSG_INFO_ASIGNACION_CAMPOS", "MSG_ALERTA_ASIGNACION_CAMPOS");
                    return;
                }


                if (ESTADO.RETURN_VALUE == 0)
                {

                    MensajeLOGEdit("A", "LA ASIGNACIÓN NO FUE INGRESADA", "MSG_INFO_ASIGNACION_CAMPOS", "MSG_ALERTA_ASIGNACION_CAMPOS");
                    return;
                }

                if (ESTADO.RETURN_VALUE == 1)
                {
                    //===========================================================
                    // LEEMOS LOS PARAMTROS ASIGNADOS
                    //===========================================================
                    LEER_SP_PARAMETROS_X_SP(SP_NAME);

                    //===========================================================================================
                    // ELIMINAMOS EL CAMPO DE INTERFAZ DETALLE QUE SE A ASIGNADO Y RECARGAMOS EL COMBO
                    //===========================================================================================
                    V_Global().DetalleInterfaz.RemoveAll(x => x.ID_INTERFAZ_DETALLE == ID_CAMPO_INTERFAZ);
                    CARGAR_COMBO_INTERFAZ_DETALLE();

                    //===========================================================
                    // RESCATAMOS LISTA DESDE VIEW STATE
                    //===========================================================
                    List<oSP_READ_SP_PARAMETRO_X_SP> lista = V_Global().ParametrosProcedimiento;

                    //===========================================================
                    // CONSULTAMOS CUAL ES EL PRIMER CAMPO PARA ASIGNAR
                    //===========================================================
                    oSP_READ_SP_PARAMETRO_X_SP PARAMETRO = lista.OrderBy(x => x.ORDEN_SP_PARAMETRO).Where(x => x.ORDEN_SP_PARAMETRO > 3 && x.CAMPO_INTERFAZ_DETALLE == " ").First();

                    //===========================================================
                    // SETEAMOS VALORES 
                    //===========================================================
                    LBL_DETALLE_CAMPO.Text = "CAMPO " + PARAMETRO.CAMPO_SP_PARAMETRO;
                    TXT_ID_PARAMETRO_SP.Text = PARAMETRO.ID_SP_PARAMETRO.ToString();

                    CARGAR_GRILLA_SP_PARAMETROS();

                    MensajeLOGEdit("I", "LA ASIGNACIÓN FUE INGRESADA CORRECTAMENTE", "MSG_INFO_ASIGNACION_CAMPOS", "MSG_ALERTA_ASIGNACION_CAMPOS");
                    return;
                }

            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_INFO_ASIGNACION_CAMPOS", "MSG_ALERTA_ASIGNACION_CAMPOS");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_ASIGNACION_CAMPOS", "MSG_ALERTA_ASIGNACION_CAMPOS");
            }
        }

        /// <summary>
        /// BOTON PARA ELIMINAR UNA ASIGNACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_ELIMINA_ASIGNACION_Click(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================
                SMetodos Negocio = new SMetodos();
                int ID_INTERFAZ = 0;
                int ID_PARAMETRO_SP = 0;
                int ID_CAMPO_INTERFAZ = 0;
                string SP_NAME = "";

                //===========================================================
                // VALIDACION DE SELECCION DE INTERFAZ                             
                //===========================================================
                if (Convert.ToInt32(DDL_INTERFAZ.SelectedValue) == 0)
                {
                    MensajeLOGEdit("A", "DEBE SELECCIONAR UNA INTERFAZ", "MSG_INFO_ELIMINA_ASIGNACION", "MSG_ALERTA_ELIMINA_ASIGNACION");
                    return;
                }
                else
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                }

                //===========================================================
                // VALIDACION DE SELECCION DE SP
                //===========================================================
                if (string.IsNullOrWhiteSpace(TXT_ID_SP_PARAMETRO_DELETE.Text))
                {
                    MensajeLOGEdit("A", "PARAMETRO NO VALIDO", "MSG_INFO_ELIMINA_ASIGNACION", "MSG_ALERTA_ELIMINA_ASIGNACION");
                    return;
                }
                else
                {
                    ID_PARAMETRO_SP = Convert.ToInt32(TXT_ID_SP_PARAMETRO_DELETE.Text);
                }

                //===========================================================
                // VALIDACION DE SELECCION DE SP
                //===========================================================
                if (string.IsNullOrWhiteSpace(TXT_NAME_SP_DELETE.Text))
                {
                    MensajeLOGEdit("A", "PARAMETRO NO VALIDO", "MSG_INFO_ELIMINA_ASIGNACION", "MSG_ALERTA_ELIMINA_ASIGNACION");
                    return;
                }
                else
                {
                    SP_NAME = TXT_NAME_SP_DELETE.Text;
                }

                //=======================================================
                // CONSTRUCCION DE OBJETO
                //=======================================================
                iSP_DELETE_INTERFAZ_DETALLE_X_SP_PARAMETRO ParametrosInput = new iSP_DELETE_INTERFAZ_DETALLE_X_SP_PARAMETRO();
                ParametrosInput.ID_SP_PARAMETRO = ID_PARAMETRO_SP;

                //=======================================================
                // LLAMADA A NEGOCIO
                //=======================================================
                oSP_RETURN_STATUS ESTADO = Negocio.SP_DELETE_INTERFAZ_DETALLE_X_SP_PARAMETRO(ParametrosInput);

                if (ESTADO.RETURN_VALUE == 0)
                {

                    MensajeLOGEdit("A", "LA ASIGNACIÓN NO FUE ELIMINADA", "MSG_INFO_ELIMINA_ASIGNACION", "MSG_ALERTA_ELIMINA_ASIGNACION");
                    return;
                }

                if (ESTADO.RETURN_VALUE == 1)
                {
                    //===========================================================
                    // LEEMOS LOS PARAMTROS ASIGNADOS
                    //===========================================================
                    LEER_SP_PARAMETROS_X_SP(SP_NAME);

                    //===========================================================================================
                    // ELIMINAMOS EL CAMPO DE INTERFAZ DETALLE QUE SE A ASIGNADO Y RECARGAMOS EL COMBO
                    //===========================================================================================
                    V_Global().DetalleInterfaz.RemoveAll(x => x.ID_INTERFAZ_DETALLE == ID_CAMPO_INTERFAZ);
                    CARGAR_COMBO_INTERFAZ_DETALLE();

                    //===========================================================
                    // RESCATAMOS LISTA DESDE VIEW STATE
                    //===========================================================
                    List<oSP_READ_SP_PARAMETRO_X_SP> lista = V_Global().ParametrosProcedimiento;

                    //===========================================================
                    // CONSULTAMOS CUAL ES EL PRIMER CAMPO PARA ASIGNAR
                    //===========================================================
                    oSP_READ_SP_PARAMETRO_X_SP PARAMETRO = lista.OrderBy(x => x.ORDEN_SP_PARAMETRO).Where(x => x.ORDEN_SP_PARAMETRO > 3 && x.CAMPO_INTERFAZ_DETALLE == " ").First();

                    //===========================================================
                    // SETEAMOS VALORES 
                    //===========================================================
                    LBL_DETALLE_CAMPO.Text = "CAMPO " + PARAMETRO.CAMPO_SP_PARAMETRO;
                    TXT_ID_PARAMETRO_SP.Text = PARAMETRO.ID_SP_PARAMETRO.ToString();

                    CARGAR_GRILLA_SP_PARAMETROS();

                    MensajeLOGEdit("I", "LA ASIGNACIÓN FUE ELIMINADA CORRECTAMENTE", "MSG_INFO_ELIMINA_ASIGNACION", "MSG_ALERTA_ELIMINA_ASIGNACION");
                    return;
                }
            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_INFO_ELIMINA_ASIGNACION", "MSG_ALERTA_ELIMINA_ASIGNACION");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_ELIMINA_ASIGNACION", "MSG_ALERTA_ELIMINA_ASIGNACION");
            }

        }
        /// <summary>
        /// BOTON PARA CARGAR COMBO DE TABLAS DE ASIGNACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BNT_CARGAR_TABLA_Click(object sender, EventArgs e)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================
                SMetodos Servicio = new SMetodos();
                List<Item_Seleccion> Lista = new List<Item_Seleccion>();
                List<oSP_READ_TABLAS_BD> TABLAS = new List<oSP_READ_TABLAS_BD>();
                string CARTERA = "";
                int CONTADOR = 2;

                //===========================================================
                // VALIDACION DE SELECCION DE CLUSTER
                //===========================================================
                if (string.IsNullOrWhiteSpace(TXT_CARTERA.Text))
	            {
		            MensajeLOG("DEBES SELECCIONAR UN CLUSTER", "ERRORES DE APLICACIÓN");
                    return;
	            }
                else
                {
                    CARTERA = TXT_CARTERA.Text;
                }

                //===========================================================
                // CONSTRUCCION DE OBJETO
                //===========================================================
                iSP_READ_TABLAS_BD ParametrosInput = new iSP_READ_TABLAS_BD();
                ParametrosInput.CARTERA = CARTERA;


                //===========================================================
                // LLAMADA A SERVICIO
                //===========================================================
                TABLAS = Servicio.SP_READ_TABLAS_BD(ParametrosInput);

                //===========================================================
                // VALORES POR DEFECTO
                //===========================================================
                Lista.Add(new Item_Seleccion { Id = 0, Nombre = "SELECCIONE VALOR" });
                Lista.Add(new Item_Seleccion { Id = 1, Nombre = "INGRESAR NUEVA TABLA" });


                //===========================================================
                // VALIDACION DE RESPUESTA
                //===========================================================
                if (TABLAS != null && TABLAS.Count > 0)
                {
                    //===========================================================
                    // ITERACION SOBRE RESULTADO
                    //===========================================================
                    foreach (oSP_READ_TABLAS_BD item in TABLAS)
                    {
                        Lista.Add(new Item_Seleccion { Id = CONTADOR, Nombre = item.TABLA });
                    }
                }

                //===========================================================
                // ORDENAMOS LA LISTA
                //===========================================================
                Lista = Lista.OrderBy(x => x.Id).ToList();

                //===========================================================
                // CARGAMOS EL COMBO
                //===========================================================
                FuncionesGenerales.CDDLCombos(Lista, DDL_TABLA_ASIGNACION);

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
        protected void GRD_PARAMETROS_SP_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //===========================================================
                // ID                                                           
                //===========================================================          
                int ID_SP_PARAMETRO = Convert.ToInt32(e.CommandArgument);

                if (ID_SP_PARAMETRO == 0) { return; }

                oSP_READ_SP_PARAMETRO_X_SP objeto = V_Global().ParametrosProcedimiento.Where(x => x.ID_SP_PARAMETRO == ID_SP_PARAMETRO).First();

                //===========================================================
                // ELIMINAR PROCESO FILE                     
                //===========================================================
                if (e.CommandName == "EliminarAsignacion")
                {
                    //===========================================================
                    // DECLARACION DE VARIABLES
                    //===========================================================
                    //SMetodos Servicio = new SMetodos();

                    ////===========================================================
                    //// CONSULTAMOS SI LA INTERFAZ TIENE ASOCIADA UNA EJECUCION
                    ////===========================================================
                    //iSP_DELETE_INTERFAZ_DETALLE_X_SP_PARAMETRO ParametrosInput = new iSP_DELETE_INTERFAZ_DETALLE_X_SP_PARAMETRO();
                    //ParametrosInput.ID_SP_PARAMETRO = ID_SP_PARAMETRO;

                    //===========================================================
                    // LLAMADA A SERVICIO
                    //===========================================================
                    //List<oSP_READ_EJECUCION_X_INTERFAZ> LST_EJECUCION = Servicio.SP_READ_EJECUCION_X_INTERFAZ(ParametrosInput);

                    //if (LST_EJECUCION.Count > 0)
                    //{
                    //    TXT_ID_ELIMINA_PROCESO_FILE.Text = objeto.ID_PROCESO_FILE.ToString();
                    //    LBL_TITULO_MENSAJE_ELIMINA_PROCESO_FILE.Text = ("EL PROCESO " + objeto.CODIGO_PROCESO_FILE + " QUE ESTA ASIGNADO A LA INTERFAZ " + objeto.CODIGO_INTERFAZ
                    //                                                        + Environment.NewLine
                    //                                                        + ", TIENE EJECUCIONES ACTIVAS NO ES POSIBLE ELIMINAR");

                    //    BTN_ELIMINA_PROCESO_FILE.Visible = false;
                    //}
                    //else
                    //{
                        TXT_ID_SP_PARAMETRO_DELETE.Text = objeto.ID_SP_PARAMETRO.ToString();

                        TXT_NAME_SP_DELETE.Text = objeto.NAME_SP;

                        LBL_TITULO_MENSAJE_ELIMINA_ASIGNACION.Text = ("EL CAMPO " + objeto.CAMPO_SP_PARAMETRO + " ESTA ASIGNADO AL CAMPO " + objeto.CAMPO_INTERFAZ_DETALLE
                                                                            + Environment.NewLine
                                                                            + "¿ DESEA ELIMINAR LA ASIGNACIÓN ?");

                        //BTN_ELIMINA_PROCESO_FILE.Visible = true;
                    //}

                        FormularioModalJS("MODAL_ELIMINA_ASIGNACION", "MSG_INFO_ELIMINA_ASIGNACION", "MSG_ALERTA_ELIMINA_ASIGNACION");
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
        protected void GRD_PARAMETROS_SP_2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //===========================================================
                // ID                                                           
                //===========================================================          
                int ID_SP_PARAMETRO = Convert.ToInt32(e.CommandArgument);

                if (ID_SP_PARAMETRO == 0) { return; }

                oSP_READ_SP_PARAMETRO_X_SP objeto = V_Global().ParametrosProcedimiento.Where(x => x.ID_SP_PARAMETRO == ID_SP_PARAMETRO).First();

                //===========================================================
                // EDITAR PROCESO FILE                     
                //===========================================================
                if (e.CommandName == "Asignar")
                {
                    //string TITULO = LBL_TITULO_ASIGNACION.Text;
                    //LBL_TITULO_ASIGNACION.Text = TITULO + " " + objeto.CAMPO_SP_PARAMETRO;
                    //FormularioModalJS("MODAL_ASIGNACION", "MSG_INFO_ASIGNACION", "MSG_ALERTA_ASIGNACION");
                }

                //===========================================================
                // ELIMINAR PROCESO FILE                     
                //===========================================================
                if (e.CommandName == "EliminarAsignacion")
                {
                    //===========================================================
                    // DECLARACION DE VARIABLES
                    //===========================================================
                    //SMetodos Servicio = new SMetodos();

                    ////===========================================================
                    //// CONSULTAMOS SI LA INTERFAZ TIENE ASOCIADA UNA EJECUCION
                    ////===========================================================
                    //iSP_DELETE_INTERFAZ_DETALLE_X_SP_PARAMETRO ParametrosInput = new iSP_DELETE_INTERFAZ_DETALLE_X_SP_PARAMETRO();
                    //ParametrosInput.ID_SP_PARAMETRO = ID_SP_PARAMETRO;

                    //===========================================================
                    // LLAMADA A SERVICIO
                    //===========================================================
                    //List<oSP_READ_EJECUCION_X_INTERFAZ> LST_EJECUCION = Servicio.SP_READ_EJECUCION_X_INTERFAZ(ParametrosInput);

                    //if (LST_EJECUCION.Count > 0)
                    //{
                    //    TXT_ID_ELIMINA_PROCESO_FILE.Text = objeto.ID_PROCESO_FILE.ToString();
                    //    LBL_TITULO_MENSAJE_ELIMINA_PROCESO_FILE.Text = ("EL PROCESO " + objeto.CODIGO_PROCESO_FILE + " QUE ESTA ASIGNADO A LA INTERFAZ " + objeto.CODIGO_INTERFAZ
                    //                                                        + Environment.NewLine
                    //                                                        + ", TIENE EJECUCIONES ACTIVAS NO ES POSIBLE ELIMINAR");

                    //    BTN_ELIMINA_PROCESO_FILE.Visible = false;
                    //}
                    //else
                    //{
                    TXT_ID_SP_PARAMETRO_DELETE.Text = objeto.ID_SP_PARAMETRO.ToString();

                    TXT_NAME_SP_DELETE.Text = objeto.NAME_SP;

                    LBL_TITULO_MENSAJE_ELIMINA_ASIGNACION.Text = ("EL CAMPO " + objeto.CAMPO_SP_PARAMETRO + " ESTA ASIGNADO AL CAMPO " + objeto.CAMPO_INTERFAZ_DETALLE
                                                                        + Environment.NewLine
                                                                        + "¿ DESEA ELIMINAR LA ASIGNACIÓN ?");

                    //BTN_ELIMINA_PROCESO_FILE.Visible = true;
                    //}

                    FormularioModalJS("MODAL_ELIMINA_ASIGNACION", "MSG_INFO_ELIMINA_ASIGNACION", "MSG_ALERTA_ELIMINA_ASIGNACION");
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
        protected void GRD_EJECUCIONES_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //===========================================================
                // ID                                                           
                //===========================================================          
                int ID_INTERFAZ = Convert.ToInt32(e.CommandArgument);

                if (ID_INTERFAZ == 0) { return; }

                //===========================================================
                // EDITAR PROCESO FILE                     
                //===========================================================
                if (e.CommandName == "Buscar")
                {
                    LEER_DETALLE_INTERFAZ(ID_INTERFAZ);

                    CARGAR_COMBO_INTERFAZ_DETALLE();

                    DIV_PANEL.Visible = true;
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
        protected void GRD_PARAMETROS_SP_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRD_PARAMETROS_SP.UseAccessibleHeader = true;
                GRD_PARAMETROS_SP.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }

        /// <summary>
        /// GRILLA PRERENDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRD_PARAMETROS_SP_2_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRD_PARAMETROS_SP_2.UseAccessibleHeader = true;
                GRD_PARAMETROS_SP_2.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }

        /// <summary>
        /// GRILLA PRERENDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRD_EJECUCIONES_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRD_EJECUCIONES.UseAccessibleHeader = true;
                GRD_EJECUCIONES.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }

        /// <summary>
        /// LEER PARAMETROS SP X SP_NAME
        /// </summary>
        private void CARGAR_GRILLA_SP_PARAMETROS()
        {
            try
            {
                //===========================================================
                // TRAER LISTA DE PARAMETROS DE PROCEDIMIENTO              
                //===========================================================
                List<oSP_READ_SP_PARAMETRO_X_SP> ListaParametros = V_Global().ParametrosProcedimiento;

                //===========================================================
                // CARGAMOS LAS GRILLAS
                //===========================================================
                FuncionesGenerales.Cargar_Grilla(ListaParametros, GRD_PARAMETROS_SP_2);
                FuncionesGenerales.Cargar_Grilla(ListaParametros, GRD_PARAMETROS_SP);
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// LEER PARAMETROS SP X SP_NAME
        /// </summary>
        private void LEER_SP_PARAMETROS_X_SP(string SP_NAME)
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
                List<oSP_READ_SP_PARAMETRO_X_SP> ListaParametros = new List<oSP_READ_SP_PARAMETRO_X_SP>();
                ListaParametros = Servicio.SP_READ_SP_PARAMETRO_X_SP(new iSP_READ_SP_PARAMETRO_X_SP { SP_NAME = SP_NAME });


                if (ListaParametros == null)
                {
                    V_Global().ParametrosProcedimiento = new List<oSP_READ_SP_PARAMETRO_X_SP>();
                }
                else
                {
                    foreach (oSP_READ_SP_PARAMETRO_X_SP item in ListaParametros)
                    {
                        if (item.CAMPO_SP_PARAMETRO.Equals("NRO_CARGA") || item.CAMPO_SP_PARAMETRO.Equals("NRO_REGISTRO") || item.CAMPO_SP_PARAMETRO.Equals("NRO_CICLO"))
                        {
                            item.TIPO_PARAMETRO = "PARAMETRO DE SISTEMA";
                        }
                        else 
                        {
                            item.TIPO_PARAMETRO = "PARAMETRO DE USUARIO";
                        }
                    }


                    V_Global().ParametrosProcedimiento = ListaParametros.OrderBy(x=> x.ORDEN_SP_PARAMETRO).ToList();
                }

            }
            catch
            {
                throw;
            }

        }
        
        /// <summary>
        /// CARGA GRILLA DE EJECUCIONES
        /// </summary>
        private void CARGAR_GRILLA_EJECUCIONES()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================                                
                List<oSP_READ_EJECUCION_X_INTERFAZ> ListaEjecuciones = new List<oSP_READ_EJECUCION_X_INTERFAZ>();

                //===========================================================
                // TRAER LISTA DE EJECUCIONES EN EL VIEW STATE
                //===========================================================                
                ListaEjecuciones = V_Global().Ejecuciones;

                //===========================================================
                // CAMPO POR DEFECTO                                        
                //===========================================================    
                FuncionesGenerales.Cargar_Grilla(ListaEjecuciones, GRD_EJECUCIONES);

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// CARGAR COMBO DE INTERFAZ POR CLUSTER
        /// </summary>
        /// <param name="ID_CLUSTER"></param>
        private void CARGAR_COMBO_INTERFAZ_X_CLUSTER(int ID_CLUSTER)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================                
                List<Item_Seleccion> Lista = new List<Item_Seleccion>();
                List<oSP_READ_INTERFAZ_X_CLUSTER> ListaInterfazEmpresa = new List<oSP_READ_INTERFAZ_X_CLUSTER>();

                //===========================================================
                // TRAER LISTA DE EMPRESAS REGISTRADAS EN SISTEMA               
                //===========================================================                
                ListaInterfazEmpresa = V_Global().Interfaces.Where(x => x.ID_CLUSTER == ID_CLUSTER).ToList();

                //===========================================================
                // CAMPO POR DEFECTO                                        
                //===========================================================                
                Lista.Add(new Item_Seleccion { Id = 0, Nombre = "SELECCIONE VALOR" });
                Lista = Lista.OrderBy(x => x.Id).ToList();

                if (ListaInterfazEmpresa.Count > 0)
                {
                    foreach (oSP_READ_INTERFAZ_X_CLUSTER item in ListaInterfazEmpresa)
                    {
                        Lista.Add(new Item_Seleccion { Id = item.ID_INTERFAZ, Nombre = item.CODIGO_INTERFAZ });
                    }
                }

                FuncionesGenerales.CDDLCombos(Lista, DDL_INTERFAZ);

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// CARGAR COMBO DE INTERFAZ DETALLE
        /// </summary>
        private void CARGAR_COMBO_INTERFAZ_DETALLE()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================                
                List<Item_Seleccion> Lista = new List<Item_Seleccion>();
                List<oSP_READ_INTERFAZ_DETALLE> ListaDetalle = new List<oSP_READ_INTERFAZ_DETALLE>();

                //===========================================================
                // TRAER LISTA DE EMPRESAS REGISTRADAS EN SISTEMA               
                //===========================================================                
                ListaDetalle = V_Global().DetalleInterfaz;

                //===========================================================
                // CAMPO POR DEFECTO                                        
                //===========================================================                
                Lista.Add(new Item_Seleccion { Id = 0, Nombre = "SELECCIONE VALOR" });
                Lista = Lista.OrderBy(x => x.Id).ToList();

                if (ListaDetalle.Count > 0)
                {
                    foreach (oSP_READ_INTERFAZ_DETALLE item in ListaDetalle)
                    {
                        Lista.Add(new Item_Seleccion { Id = item.ID_INTERFAZ_DETALLE, Nombre = item.CAMPO });
                    }
                }

                FuncionesGenerales.CDDLCombos(Lista, DDL_INTERFAZ_DETALLE);

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LEER INTERFAZ POR CLUSTER
        /// </summary>
        /// <param name="ID_CLUSTER"></param>
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


                if (ListaInterfazEmpresa == null)
                {
                    V_Global().Interfaces = new List<oSP_READ_INTERFAZ_X_CLUSTER>();
                }
                else
                {
                    ListaInterfazEmpresa.RemoveAll(x => x.ID_TIPO_CARGA != (int)T_TIPO_CARGA.ASIGNACION);

                    V_Global().Interfaces = ListaInterfazEmpresa;
                }

            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// LEER EJECUCIONES POR INTERFAZ
        /// </summary>
        /// <param name="ID_INTERFAZ"></param>
        private void LEER_EJECUCIONES_X_INTERFAZ(int ID_INTERFAZ)
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
                List<oSP_READ_EJECUCION_X_INTERFAZ> ListaInterfazEmpresa = new List<oSP_READ_EJECUCION_X_INTERFAZ>();
                ListaInterfazEmpresa = Servicio.SP_READ_EJECUCION_X_INTERFAZ(new iSP_READ_EJECUCION_X_INTERFAZ { ID_INTERFAZ = ID_INTERFAZ });

                if (ListaInterfazEmpresa == null)
                {
                    V_Global().Ejecuciones = new List<oSP_READ_EJECUCION_X_INTERFAZ>();
                }
                else
                {
                    V_Global().Ejecuciones = ListaInterfazEmpresa;
                }

            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// LEER DETALLE DE INTERFAZ
        /// </summary>
        /// <param name="ID_INTERFAZ"></param>
        private void LEER_DETALLE_INTERFAZ(int ID_INTERFAZ)
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
                List<oSP_READ_INTERFAZ_DETALLE> Lista = new List<oSP_READ_INTERFAZ_DETALLE>();
                Lista = Servicio.SP_READ_INTERFAZ_DETALLE(new iSP_READ_INTERFAZ_DETALLE { ID_INTERFAZ = ID_INTERFAZ });

                if (Lista == null)
                {
                    V_Global().DetalleInterfaz = new List<oSP_READ_INTERFAZ_DETALLE>();
                }
                else
                {
                    V_Global().DetalleInterfaz = Lista;
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
                    LEER_INTERFAZ_X_CLUSTER(ID_CLUSTER);

                    CARGAR_COMBO_INTERFAZ_X_CLUSTER(ID_CLUSTER);
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
                if (Convert.ToInt32(DDL_INTERFAZ.SelectedValue) > 0)
                {
                    int ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                    LEER_EJECUCIONES_X_INTERFAZ(ID_INTERFAZ);

                    CARGAR_GRILLA_EJECUCIONES();
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
        /// AL SELECCIONAR TABLA ASIGNACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_TABLA_ASIGNACION_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(DDL_TABLA_ASIGNACION.SelectedValue) == 1)
                {
                    DIV_TABLA_ASIGNACION.Visible = true;
                }
                else
                {
                    DIV_TABLA_ASIGNACION.Visible = false;
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
        /// VIEWSTATE PARA VARIABLES GLOBALES
        /// </summary>
        private void Establecer_Globales()
        {
            try
            {

                ViewState["GlobalesAsignacionPlanificacion"] = new GlobalesAsignacionPlanificacion();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// VIEWSTATE PARA VARIABLES GLOBALES
        /// </summary>
        private GlobalesAsignacionPlanificacion V_Global()
        {
            GlobalesAsignacionPlanificacion item = new GlobalesAsignacionPlanificacion();
            try
            {

                item = (GlobalesAsignacionPlanificacion)ViewState["GlobalesAsignacionPlanificacion"] ?? null;
                return item;
            }
            catch
            {
                return item;
            }

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
        /// URL WEB
        /// </summary>
        /// <param name="jsURL"></param>
        /// <returns></returns>
        public string UrlWeb(string jsURL)
        {
            return ResolveURL(jsURL);
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
               
    }

    [Serializable]
    public class GlobalesAsignacionPlanificacion
    {
        public List<oSP_READ_INTERFAZ_X_CLUSTER> Interfaces { get; set; }
        public List<oSP_READ_SP_PARAMETRO_X_SP> ParametrosProcedimiento { get; set; }
        public List<oSP_READ_EJECUCION_X_INTERFAZ> Ejecuciones { get; set; }
        public List<oSP_READ_INTERFAZ_DETALLE> DetalleInterfaz { get; set; }
    }
}
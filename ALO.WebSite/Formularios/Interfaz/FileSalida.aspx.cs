using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
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
    public partial class FileSalida : System.Web.UI.Page
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

                    LEER_PROCESO_FILE_X_INTERFAZ(0);
                    CARGAR_GRILLA_PROCESO_FILE();
                    LEER_INTERFAZ_X_CLUSTER(0);
                    CARGAR_COMBO_INTERFAZ_X_CLUSTER(0);
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
        /// LEVANTA MODAL PARA CREAR NUEVO PROCESO FILE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BNT_NUEVO_PROCESO_FILE_Click(object sender, EventArgs e)
        {
            try
            {
                LBL_TITULO_PROCESO_FILE.Text = "NUEVO PROCESO FILE";
                BTN_PROCESO_FILE.Text = "CREAR";
                TXT_ID_PROCESO_FILE.Text = "0";
                TXT_DESCRIPCION.Text = "";
                TXT_CODIGO.Text = "";
                TXT_PRIORIDAD.Text = "";
                CHK_ACTUALIZAR_PARAMETROS.Visible = false;
                LBL_ACTUALIZAR_PARAMETROS.Visible = false;
                FormularioModalJS("MODAL_GRID_PROCESO_FILE", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
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
        /// CREA UN NUEVO PROCESO FILE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_PROCESO_FILE_Click(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================           
                SMetodos Servicio = new SMetodos();
                int ID_INTERFAZ = 0;
                string SP = "";
                string DESCRIPCION = "";
                string CODIGO = "";
                List<OUTPUT_PARAMETROS> LST_REST = new List<OUTPUT_PARAMETROS>();
                string CODIGO_INTERFAZ = "";
                int PRIORIDAD = 0;
                bool ACTUALIZAR_PARAMETROS = false;

                //===========================================================
                // VALIDACION DE SELECCION DE INTERFAZ
                //===========================================================   
                if (Convert.ToInt32(DDL_INTERFAZ.SelectedValue) != 0)
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UNA INTERFAZ", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                    return;
                }

                //===========================================================
                // VALIDACION DE SELECCION DE SP
                //===========================================================   
                if (Convert.ToInt32(DDL_SP.SelectedValue) != 0)
                {
                    SP = DDL_SP.SelectedItem.Text;
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UN PROCEDIMIENTO ALMACENADO", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
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
                    MensajeLOGEdit("A", "DEBES INGRESAR UNA DESCRIPCION", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                    return;
                }


                //===========================================================
                // VALIDACION DE CODIGO
                //===========================================================   
                if (!string.IsNullOrWhiteSpace(TXT_CODIGO.Text))
                {
                    CODIGO = TXT_CODIGO.Text;
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES INGRESAR UN CODIGO", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                    return;
                }

                //===========================================================
                // VALIDACION DE PRIORIDAD
                //===========================================================   
                if (!string.IsNullOrWhiteSpace(TXT_PRIORIDAD.Text))
                {
                    try
                    {
                        PRIORIDAD = Convert.ToInt32(TXT_PRIORIDAD.Text);
                    }
                    catch
                    {
                        MensajeLOGEdit("A", "LA PRIORIDAD DEBE SER NUMERICA", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                        return;
                    }
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES INGRESAR UNA PRIORIDAD", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                    return;
                }


                //=======================================================
                // OBTENEMOS EL CODIGO DE INTERFAZ
                //=======================================================
                CODIGO_INTERFAZ = OBTENER_CODIGO_INTERFAZ(ID_INTERFAZ);

                //=======================================================
                // OBTENEMOS LA LISTA DE PARAMETROS
                //=======================================================
                if (!string.IsNullOrWhiteSpace(CODIGO_INTERFAZ))
                {
                    LST_REST = LEER_PARAMETROS_X_SP(CODIGO_INTERFAZ, SP);
                }

                //=======================================================
                // VALIDACION DE LISTA DE PARAMETROS
                //=======================================================
                if (LST_REST == null || LST_REST.Count <= 0)
                {
                    MensajeLOGEdit("A", "EL PROCEDIMIENTO ALMACENADO NO CONTIENE PARAMETROS", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                    return;
                }

                //=======================================================
                // AÑADIMOS PROCESO FILE Y SU DETALLE
                //=======================================================
                if (Convert.ToInt32(TXT_ID_PROCESO_FILE.Text) == 0)
                {

                    //=======================================================
                    // CONSTRUCCION DE OBJETO
                    //=======================================================
                    iSP_CREATE_PROCESO_FILE ParametrosInput = new iSP_CREATE_PROCESO_FILE();
                    ParametrosInput.ID_INTERFAZ = ID_INTERFAZ;
                    ParametrosInput.DESCRIPCION = DESCRIPCION;
                    ParametrosInput.SP = SP;
                    ParametrosInput.PRIORIDAD = PRIORIDAD;
                    ParametrosInput.CODIGO = CODIGO;

                    //=======================================================
                    // LLAMADA A SERVICIO
                    //=======================================================
                    oSP_CREATE_PROCESO_FILE PROCESO_FILE = Servicio.SP_CREATE_PROCESO_FILE(ParametrosInput);

                    if (PROCESO_FILE.ID_PROCESO_FILE == -1)
                    {
                        MensajeLOGEdit("A", "EL PROCESO FILE YA SE ENCUENTRA EN EL SISTEMA", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                        return;
                    }

                    if (PROCESO_FILE.ID_PROCESO_FILE == 0)
                    {
                        MensajeLOGEdit("A", "EL PROCESO FILE NO FUE INGRESADO", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                        return;
                    }

                    if (PROCESO_FILE.ID_PROCESO_FILE >= 1)
                    {
                        MensajeLOGEdit("I", "EL PROCESO FILE FUE INGRESADO CORRECTAMENTE", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");

                        //=======================================================
                        // INSERTAMOS EL DETALLE
                        //=======================================================
                        foreach (OUTPUT_PARAMETROS item in LST_REST)
                        {
                            if (item.NOMBRE.Equals("NRO_CARGA") || item.NOMBRE.Equals("NRO_REGISTRO") || item.NOMBRE.Equals("ID_SOLICITUD") || item.NOMBRE.Equals("NAME_FILE") || item.NOMBRE.Equals("NAME_ORIGINAL"))
                            {
                                continue;
                            }

                            int ID_TIPO_CAMPO = 0;

                            switch (item.TIPO_DATO)
                            {
                                case "SIN DEFINIR":
                                    ID_TIPO_CAMPO = (int)T_DATO.SIN_DEFINIR;
                                    break;
                                case "TEXTO":
                                    ID_TIPO_CAMPO = (int)T_DATO.TEXTO;
                                    break;
                                case "NUMERO":
                                    ID_TIPO_CAMPO = (int)T_DATO.NUMERICO;
                                    break;
                                case "FECHA":
                                    ID_TIPO_CAMPO = (int)T_DATO.FECHA;
                                    break;
                                case "BIT":
                                    ID_TIPO_CAMPO = (int)T_DATO.BIT;
                                    break;
                            }

                            //=======================================================
                            // CONSTRUCCION DE OBJETO
                            //=======================================================
                            iSP_CREATE_DETALLE_PROCESO_FILE ParametrosInputDetalle = new iSP_CREATE_DETALLE_PROCESO_FILE();
                            ParametrosInputDetalle.ID_PROCESO_FILE = PROCESO_FILE.ID_PROCESO_FILE;
                            ParametrosInputDetalle.CAMPO = item.NOMBRE;
                            ParametrosInputDetalle.ID_TIPO_CAMPO = ID_TIPO_CAMPO;
                            ParametrosInputDetalle.ORDEN = item.ORDEN;

                            //=======================================================
                            // LLAMADA A SERVICIO
                            //=======================================================
                            oSP_RETURN_STATUS ESTADO_DETALLE = Servicio.SP_CREATE_DETALLE_PROCESO_FILE(ParametrosInputDetalle);

                            //=======================================================
                            // VALIDACION DE RETORNO
                            //=======================================================
                            if (ESTADO_DETALLE.RETURN_VALUE == -1)
                            {
                                //=======================================================
                                // CONSTRUCCION DE OBJETO
                                //=======================================================
                                iSP_DELETE_DETALLE_PROCESO_FILE parametrosInputDeleteDetalle = new iSP_DELETE_DETALLE_PROCESO_FILE();
                                parametrosInputDeleteDetalle.ID_PROCESO_FILE = PROCESO_FILE.ID_PROCESO_FILE;

                                //=======================================================
                                // LLAMADA A SERVICIO
                                //=======================================================
                                Servicio.SP_DELETE_DETALLE_PROCESO_FILE(parametrosInputDeleteDetalle);

                                //=======================================================
                                // CONSTRUCCION DE OBJETO
                                //=======================================================
                                iSP_DELETE_PROCESO_FILE parametrosInputDeleteProceso = new iSP_DELETE_PROCESO_FILE();
                                parametrosInputDeleteProceso.ID_PROCESO_FILE = PROCESO_FILE.ID_PROCESO_FILE;

                                //=======================================================
                                // LLAMADA A SERVICIO
                                //=======================================================
                                Servicio.SP_DELETE_PROCESO_FILE(parametrosInputDeleteProceso);


                                MensajeLOGEdit("A", "EL PROCESO FILE YA SE ENCUENTRA EN EL SISTEMA", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                                continue;
                            }

                            if (ESTADO_DETALLE.RETURN_VALUE == 0)
                            {
                                //=======================================================
                                // CONSTRUCCION DE OBJETO
                                //=======================================================
                                iSP_DELETE_DETALLE_PROCESO_FILE parametrosInputDeleteDetalle = new iSP_DELETE_DETALLE_PROCESO_FILE();
                                parametrosInputDeleteDetalle.ID_PROCESO_FILE = PROCESO_FILE.ID_PROCESO_FILE;

                                //=======================================================
                                // LLAMADA A SERVICIO
                                //=======================================================
                                Servicio.SP_DELETE_DETALLE_PROCESO_FILE(parametrosInputDeleteDetalle);

                                //=======================================================
                                // CONSTRUCCION DE OBJETO
                                //=======================================================
                                iSP_DELETE_PROCESO_FILE parametrosInputDeleteProceso = new iSP_DELETE_PROCESO_FILE();
                                parametrosInputDeleteProceso.ID_PROCESO_FILE = PROCESO_FILE.ID_PROCESO_FILE;

                                //=======================================================
                                // LLAMADA A SERVICIO
                                //=======================================================
                                Servicio.SP_DELETE_PROCESO_FILE(parametrosInputDeleteProceso);
                                MensajeLOGEdit("A", "EL PROCESO FILE NO FUE INGRESADO", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                                continue;
                            }
                        }

                        LEER_PROCESO_FILE_X_INTERFAZ(ID_INTERFAZ);
                        CARGAR_GRILLA_PROCESO_FILE();
                        return;
                    }

                }

                if (Convert.ToInt32(TXT_ID_PROCESO_FILE.Text) > 0)
                {
                    int ID_PROCESO_FILE = Convert.ToInt32(TXT_ID_PROCESO_FILE.Text);

                    //=======================================================
                    // CONSTRUCCION DE OBJETO
                    //=======================================================
                    iSP_UPDATE_PROCESO_FILE ParametrosInput = new iSP_UPDATE_PROCESO_FILE();
                    ParametrosInput.ID_PROCESO_FILE = ID_PROCESO_FILE;
                    ParametrosInput.DESCRIPCION = DESCRIPCION;
                    ParametrosInput.SP = SP;
                    ParametrosInput.CODIGO = CODIGO;
                    ParametrosInput.PRIORIDAD = PRIORIDAD;

                    //=======================================================
                    // LLAMADA A SERVICIO
                    //=======================================================
                    oSP_RETURN_STATUS ESTADO = Servicio.SP_UPDATE_PROCESO_FILE(ParametrosInput);

                    if (ESTADO.RETURN_VALUE == -1)
                    {
                        MensajeLOGEdit("A", "EL PROCESO FILE YA SE ENCUENTRA EN EL SISTEMA", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOGEdit("A", "EL PROCESO FILE NO FUE ACTUALIZADO", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 1)
                    {
                        string OPCION = "";
                        string MENSAJE = "";

                        MENSAJE = "EL PROCESO FILE FUE ACTUALIZADO CORRECTAMENTE";
                        OPCION = "I";
                        //MensajeLOGEdit("I", "EL PROCESO FILE FUE ACTUALIZADO CORRECTAMENTE", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");

                        ACTUALIZAR_PARAMETROS = CHK_ACTUALIZAR_PARAMETROS.Checked;
                        if (ACTUALIZAR_PARAMETROS)
                        {


                            //=======================================================
                            // CONSTRUCCION DE OBJETO
                            //=======================================================
                            iSP_DELETE_DETALLE_PROCESO_FILE parametrosInputDelete = new iSP_DELETE_DETALLE_PROCESO_FILE();
                            parametrosInputDelete.ID_PROCESO_FILE = ID_PROCESO_FILE;

                            //=======================================================
                            // LLAMADA A SERVICIO
                            //=======================================================
                            Servicio.SP_DELETE_DETALLE_PROCESO_FILE(parametrosInputDelete);

                            //=======================================================
                            // INSERTAMOS EL DETALLE
                            //=======================================================
                            foreach (OUTPUT_PARAMETROS item in LST_REST)
                            {
                                if (item.NOMBRE.Equals("NRO_CARGA") || item.NOMBRE.Equals("NRO_REGISTRO") || item.NOMBRE.Equals("ID_SOLICITUD") || item.NOMBRE.Equals("NAME_FILE") || item.NOMBRE.Equals("NAME_ORIGINAL"))
                                {
                                    continue;
                                }

                                int ID_TIPO_CAMPO = 0;

                                switch (item.TIPO_DATO)
                                {
                                    case "SIN DEFINIR":
                                        ID_TIPO_CAMPO = (int)T_DATO.SIN_DEFINIR;
                                        break;
                                    case "TEXTO":
                                        ID_TIPO_CAMPO = (int)T_DATO.TEXTO;
                                        break;
                                    case "NUMERO":
                                        ID_TIPO_CAMPO = (int)T_DATO.NUMERICO;
                                        break;
                                    case "FECHA":
                                        ID_TIPO_CAMPO = (int)T_DATO.FECHA;
                                        break;
                                    case "BIT":
                                        ID_TIPO_CAMPO = (int)T_DATO.BIT;
                                        break;
                                }

                                //=======================================================
                                // CONSTRUCCION DE OBJETO
                                //=======================================================
                                iSP_CREATE_DETALLE_PROCESO_FILE ParametrosInputDetalle = new iSP_CREATE_DETALLE_PROCESO_FILE();
                                ParametrosInputDetalle.ID_PROCESO_FILE = ID_PROCESO_FILE;
                                ParametrosInputDetalle.CAMPO = item.NOMBRE;
                                ParametrosInputDetalle.ID_TIPO_CAMPO = ID_TIPO_CAMPO;
                                ParametrosInputDetalle.ORDEN = item.ORDEN;

                                //=======================================================
                                // LLAMADA A SERVICIO
                                //=======================================================
                                oSP_RETURN_STATUS ESTADO_DETALLE = Servicio.SP_CREATE_DETALLE_PROCESO_FILE(ParametrosInputDetalle);

                                //=======================================================
                                // VALIDACION DE RETORNO
                                //=======================================================
                                if (ESTADO_DETALLE.RETURN_VALUE == -1)
                                {
                                    //=======================================================
                                    // CONSTRUCCION DE OBJETO
                                    //=======================================================
                                    iSP_DELETE_DETALLE_PROCESO_FILE parametrosInputDeleteDetalle = new iSP_DELETE_DETALLE_PROCESO_FILE();
                                    parametrosInputDeleteDetalle.ID_PROCESO_FILE = ID_PROCESO_FILE;

                                    //=======================================================
                                    // LLAMADA A SERVICIO
                                    //=======================================================
                                    Servicio.SP_DELETE_DETALLE_PROCESO_FILE(parametrosInputDeleteDetalle);

                                    //=======================================================
                                    // CONSTRUCCION DE OBJETO
                                    //=======================================================
                                    iSP_DELETE_PROCESO_FILE parametrosInputDeleteProceso = new iSP_DELETE_PROCESO_FILE();
                                    parametrosInputDeleteProceso.ID_PROCESO_FILE = ID_PROCESO_FILE;

                                    //=======================================================
                                    // LLAMADA A SERVICIO
                                    //=======================================================
                                    Servicio.SP_DELETE_PROCESO_FILE(parametrosInputDeleteProceso);

                                    MENSAJE = "EL PROCESO FILE YA SE ENCUENTRA EN EL SISTEMA";
                                    OPCION = "A";
                                    //MensajeLOGEdit("A", "EL PROCESO FILE YA SE ENCUENTRA EN EL SISTEMA", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");

                                }

                                if (ESTADO_DETALLE.RETURN_VALUE == 0)
                                {
                                    //=======================================================
                                    // CONSTRUCCION DE OBJETO
                                    //=======================================================
                                    iSP_DELETE_DETALLE_PROCESO_FILE parametrosInputDeleteDetalle = new iSP_DELETE_DETALLE_PROCESO_FILE();
                                    parametrosInputDeleteDetalle.ID_PROCESO_FILE = ID_PROCESO_FILE;

                                    //=======================================================
                                    // LLAMADA A SERVICIO
                                    //=======================================================
                                    Servicio.SP_DELETE_DETALLE_PROCESO_FILE(parametrosInputDeleteDetalle);

                                    //=======================================================
                                    // CONSTRUCCION DE OBJETO
                                    //=======================================================
                                    iSP_DELETE_PROCESO_FILE parametrosInputDeleteProceso = new iSP_DELETE_PROCESO_FILE();
                                    parametrosInputDeleteProceso.ID_PROCESO_FILE = ID_PROCESO_FILE;

                                    //=======================================================
                                    // LLAMADA A SERVICIO
                                    //=======================================================
                                    Servicio.SP_DELETE_PROCESO_FILE(parametrosInputDeleteProceso);

                                    MENSAJE = "EL PROCESO FILE NO FUE ACTUALIZADO";
                                    OPCION = "A";
                                    //MensajeLOGEdit("A", "EL PROCESO FILE NO FUE ACTUALIZADO", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");

                                }

                            }

                        }

                        MensajeLOGEdit(OPCION, MENSAJE, "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                        LEER_PROCESO_FILE_X_INTERFAZ(ID_INTERFAZ);
                        CARGAR_GRILLA_PROCESO_FILE();
                        return;
                    }
                }
            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
            }
        }


        /// <summary>
        /// ELIMINA UN PROCESO FILE
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_ELIMINA_PROCESO_FILE_Click(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================           
                SMetodos Servicio = new SMetodos();
                int ID_INTERFAZ = 0;
                int ID_PROCESO_FILE = 0;

                //===========================================================
                // VALIDACION DE SELECCION DE INTERFAZ
                //===========================================================   
                if (Convert.ToInt32(DDL_INTERFAZ.SelectedValue) != 0)
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UNA INTERFAZ", "MSG_INFO_ELIMINA_PROCESO_FILE", "MSG_ALERTA_ELIMINA_PROCESO_FILE");
                    return;
                }

                //===========================================================
                // VALIDACION DE PRIORIDAD
                //===========================================================   
                if (!string.IsNullOrWhiteSpace(TXT_ID_ELIMINA_PROCESO_FILE.Text))
                {
                    ID_PROCESO_FILE = Convert.ToInt32(TXT_ID_ELIMINA_PROCESO_FILE.Text);
                }
                else
                {
                    MensajeLOGEdit("A", "PROCESO NO VALIDO", "MSG_INFO_ELIMINA_PROCESO_FILE", "MSG_ALERTA_ELIMINA_PROCESO_FILE");
                    return;
                }

                if (ID_PROCESO_FILE > 0)
                {
                    //=======================================================
                    // CONSTRUCCION DE OBJETO
                    //=======================================================
                    iSP_DELETE_DETALLE_PROCESO_FILE parametrosInputDelete = new iSP_DELETE_DETALLE_PROCESO_FILE();
                    parametrosInputDelete.ID_PROCESO_FILE = ID_PROCESO_FILE;

                    //=======================================================
                    // LLAMADA A SERVICIO
                    //=======================================================
                    Servicio.SP_DELETE_DETALLE_PROCESO_FILE(parametrosInputDelete);

                    iSP_DELETE_PROCESO_FILE ParametrosInput = new iSP_DELETE_PROCESO_FILE();
                    ParametrosInput.ID_PROCESO_FILE = ID_PROCESO_FILE;

                    oSP_RETURN_STATUS ESTADO = Servicio.SP_DELETE_PROCESO_FILE(ParametrosInput);

                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOGEdit("A", "EL PROCESO ASOCIADO A INTERFAZ NO FUE ELIMINADO", "MSG_INFO_ELIMINA_PROCESO_FILE", "MSG_ALERTA_ELIMINA_PROCESO_FILE");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 1)
                    {
                        MensajeLOGEdit("I", "EL PROCESO ASOCIADO A INTERFAZ ELIMINADO CORRECTAMENTE", "MSG_INFO_ELIMINA_PROCESO_FILE", "MSG_ALERTA_ELIMINA_PROCESO_FILE");
                        LEER_PROCESO_FILE_X_INTERFAZ(ID_INTERFAZ);
                        CARGAR_GRILLA_PROCESO_FILE();
                        return;
                    }

                }
                {
                    MensajeLOGEdit("A", "PROCESO NO VALIDO", "MSG_INFO_ELIMINA_PROCESO_FILE", "MSG_ALERTA_ELIMINA_PROCESO_FILE");
                    return;
                }
            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_INFO_ELIMINA_PROCESO_FILE", "MSG_ALERTA_ELIMINA_PROCESO_FILE");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_ELIMINA_PROCESO_FILE", "MSG_ALERTA_ELIMINA_PROCESO_FILE");
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
        /// AL SELECCIONAR CAMPAÑA
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
        /// VIEWSTATE PARA VARIABLES GLOBALES
        /// </summary>
        private void Establecer_Globales()
        {
            try
            {

                ViewState["GlobalesFileSalida"] = new GlobalesFileSalida();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// VIEWSTATE PARA VARIABLES GLOBALES
        /// </summary>
        private GlobalesFileSalida V_Global()
        {


            GlobalesFileSalida item = new GlobalesFileSalida();
            try
            {

                item = (GlobalesFileSalida)ViewState["GlobalesFileSalida"] ?? null;
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
        protected void GRD_PROCESO_FILE_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRD_PROCESO_FILE.UseAccessibleHeader = true;
                GRD_PROCESO_FILE.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }

        /// <summary>
        /// GRILLA ROWCOMMAND
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRD_PROCESO_FILE_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //===========================================================
                // ID                                                           
                //===========================================================          
                int ID_PROCESO_FILE = Convert.ToInt32(e.CommandArgument);

                if (ID_PROCESO_FILE == 0) { return; }

                oSP_READ_PROCESO_FILE objeto = V_Global().ProcesoFile.Where(x => x.ID_PROCESO_FILE == ID_PROCESO_FILE).First();

                //===========================================================
                // EDITAR PROCESO FILE                     
                //===========================================================
                if (e.CommandName == "EditarProcesoFile")
                {
                    LBL_TITULO_PROCESO_FILE.Text = "ACTUALIZAR PROCESO FILE";
                    BTN_PROCESO_FILE.Text = "ACTUALIZAR";
                    TXT_PRIORIDAD.Text = objeto.PRIORIDAD.ToString();
                    TXT_ID_PROCESO_FILE.Text = objeto.ID_PROCESO_FILE.ToString();
                    TXT_DESCRIPCION.Text = objeto.DESCRIPCION_PROCESO_FILE;
                    TXT_CODIGO.Text = objeto.CODIGO_PROCESO_FILE;
                    FuncionesGenerales.BuscarNombreCombo(DDL_SP, objeto.SP);
                    CHK_ACTUALIZAR_PARAMETROS.Visible = true;
                    LBL_ACTUALIZAR_PARAMETROS.Visible = true;
                    DDL_SP_SelectedIndexChanged(null, null);
                    FormularioModalJS("MODAL_GRID_PROCESO_FILE", "MSG_INFO_PROCESO_FILE", "MSG_ALERTA_PROCESO_FILE");
                }

                //===========================================================
                // ELIMINAR PROCESO FILE                     
                //===========================================================
                if (e.CommandName == "EliminarProcesoFile")
                {

                    //===========================================================
                    // DECLARACION DE VARIABLES
                    //===========================================================
                    SMetodos Servicio = new SMetodos();

                    //===========================================================
                    // CONSULTAMOS SI LA INTERFAZ TIENE ASOCIADA UNA EJECUCION
                    //===========================================================
                    iSP_READ_EJECUCION_X_INTERFAZ ParametrosInput = new iSP_READ_EJECUCION_X_INTERFAZ();
                    ParametrosInput.ID_INTERFAZ = objeto.ID_INTERFAZ;

                    //===========================================================
                    // LLAMADA A SERVICIO
                    //===========================================================
                    List<oSP_READ_EJECUCION_X_INTERFAZ> LST_EJECUCION = Servicio.SP_READ_EJECUCION_X_INTERFAZ(ParametrosInput);

                    if (LST_EJECUCION.Count > 0)
                    {
                        TXT_ID_ELIMINA_PROCESO_FILE.Text = objeto.ID_PROCESO_FILE.ToString();
                        LBL_TITULO_MENSAJE_ELIMINA_PROCESO_FILE.Text = ("EL PROCESO " + objeto.CODIGO_PROCESO_FILE + " QUE ESTA ASIGNADO A LA INTERFAZ " + objeto.CODIGO_INTERFAZ
                                                                            + Environment.NewLine
                                                                            + ", TIENE EJECUCIONES ACTIVAS NO ES POSIBLE ELIMINAR");

                        BTN_ELIMINA_PROCESO_FILE.Visible = false;
                    }
                    else
                    {
                        TXT_ID_ELIMINA_PROCESO_FILE.Text = objeto.ID_PROCESO_FILE.ToString();
                        LBL_TITULO_MENSAJE_ELIMINA_PROCESO_FILE.Text = ("EL PROCESO " + objeto.CODIGO_PROCESO_FILE + " ESTA ASIGNADO A LA INTERFAZ " + objeto.CODIGO_INTERFAZ
                                                                            + Environment.NewLine
                                                                            + "¿ DESEA ELIMINAR EL PROCESO ASOCIADO ?");

                        BTN_ELIMINA_PROCESO_FILE.Visible = true;
                    }

                    FormularioModalJS("MODAL_ELIMINA_PROCESO_FILE", "MSG_INFO_ELIMINA_PROCESO_FILE", "MSG_ALERTA_ELIMINA_PROCESO_FILE");
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
        /// MOSTRAR INTERFAZ
        /// </summary>
        private void ModalInterfaz()
        {
            try
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append("<script type='text/javascript'>");
                sb.Append("function f(){");
                sb.Append("ModalInterfaz();");
                sb.Append("Sys.Application.remove_load(f);}");
                sb.Append("Sys.Application.add_load(f);");
                sb.Append("</script>");

                ScriptManager.RegisterStartupScript(this, typeof(Page), "PopupModalJS", sb.ToString(), false);
            }
            catch { }

        }

        /// <summary>
        /// LEER SP X INTERFAZ
        /// </summary>
        private void LEER_SP_X_INTERFAZ(string CODIGO_INTERFAZ)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<OUTPUT_INTERFAZ> LST_REST = new List<OUTPUT_INTERFAZ>();
                List<Item_Seleccion> items = new List<Item_Seleccion>();
                SMetodos Servicio = new SMetodos();

                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                LST_REST = Servicio.SP_READ_SP_X_INTERFAZ(CODIGO_INTERFAZ);



                //===========================================================
                // PASAR LISTA A COMBO 
                //===========================================================
                int CONTADOR = 1;
                foreach (OUTPUT_INTERFAZ item in LST_REST)
                {
                    items.Add(new Item_Seleccion { Id = CONTADOR, Nombre = item.SP });
                    CONTADOR++;
                }


                //===========================================================
                // CAMPO POR DEFECTO                                        
                //===========================================================                
                items.Add(new Item_Seleccion { Id = 0, Nombre = "SELECCIONE VALOR" });
                items = items.OrderBy(x => x.Id).ToList();

                FuncionesGenerales.CDDLCombos(items, DDL_SP);



            }
            catch
            {

                throw;
            }
        }


        /// <summary>
        /// LEER SP X INTERFAZ
        /// </summary>
        private List<OUTPUT_PARAMETROS> LEER_PARAMETROS_X_SP(string CODIGO_INTERFAZ, string SP)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<OUTPUT_PARAMETROS> LST_REST = new List<OUTPUT_PARAMETROS>();
                SMetodos Servicio = new SMetodos();

                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                LST_REST = Servicio.SP_READ_PARAMETROS_X_SP(CODIGO_INTERFAZ, SP);

                if (LST_REST == null || LST_REST.Count <= 0)
                {
                    LST_REST = new List<OUTPUT_PARAMETROS>();
                }
                else
                {
                    foreach (OUTPUT_PARAMETROS item in LST_REST)
                    {
                        if (item.NOMBRE.Equals("NRO_CARGA") || item.NOMBRE.Equals("NRO_REGISTRO") || item.NOMBRE.Equals("ID_SOLICITUD") || item.NOMBRE.Equals("NAME_FILE") || item.NOMBRE.Equals("NAME_ORIGINAL"))
                        {
                            item.TIPO_PARAMETRO = "PARAMETRO DE SISTEMA";
                        }
                        else
                        {
                            item.TIPO_PARAMETRO = "PARAMETRO DE USUARIO";
                        }
                    }
                }
                return LST_REST;

            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LEER PROCESO FILE X INTERFAZ
        /// </summary>
        private void LEER_PROCESO_FILE_X_INTERFAZ(int ID_INTERFAZ)
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
                List<oSP_READ_PROCESO_FILE> ListaIn = new List<oSP_READ_PROCESO_FILE>();
                ListaIn = Servicio.SP_READ_PROCESO_FILE(new iSP_READ_PROCESO_FILE { ID_INTERFAZ = ID_INTERFAZ });


                if (ListaIn == null)
                {
                    V_Global().ProcesoFile = new List<oSP_READ_PROCESO_FILE>();
                }
                else
                {
                    V_Global().ProcesoFile = ListaIn;
                }

            }
            catch
            {
                throw;
            }


        }

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


                if (ListaInterfazEmpresa == null)
                {
                    V_Global().Interfaces = new List<oSP_READ_INTERFAZ_X_CLUSTER>();
                }
                else
                {
                    V_Global().Interfaces = ListaInterfazEmpresa;
                }

            }
            catch
            {
                throw;
            }


        }

        /// <summary>
        /// CARGAR COMBO DE INTERFAZ POR CLUSTER
        /// </summary>
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


                DDL_INTERFAZ_SelectedIndexChanged(null, null);

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// CARGAR GRILLA DE DATOS
        /// </summary>
        private void CARGAR_GRILLA_PROCESO_FILE()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================                
                List<oSP_READ_PROCESO_FILE> Lista = new List<oSP_READ_PROCESO_FILE>();


                //===========================================================
                // LLAMADA A SERVICIO            
                //===========================================================
                Lista = V_Global().ProcesoFile;

                if (Lista == null)
                {
                    Lista = new List<oSP_READ_PROCESO_FILE>();
                }

                FuncionesGenerales.Cargar_Grilla(Lista, GRD_PROCESO_FILE);
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
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                int ID_INTERFAZ = 0;

                if (DDL_INTERFAZ.Items.Count > 0)
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);

                }
                else
                {
                    ID_INTERFAZ = -1;
                }

                LEER_PROCESO_FILE_X_INTERFAZ(ID_INTERFAZ);
                CARGAR_GRILLA_PROCESO_FILE();

                //===========================================================
                // OBTENEMOS EL CODIGO DE INTERFAZ
                //===========================================================
                string CODIGO = OBTENER_CODIGO_INTERFAZ(ID_INTERFAZ);

                //===========================================================
                // SI EL CODIGO DE INTERFAZ NO ES NULO BUSCAMOS LOS SP
                //===========================================================
                if (CODIGO != null)
                {
                    LEER_SP_X_INTERFAZ(CODIGO);
                }

            }
            catch (EServiceRestFulException ex)
            {
                MensajeLOG(ex.Message, "ERRORES DE SERVICIO");
            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }
        }

        /// <summary>
        /// AL SELECCIONAR SP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_SP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                string SP = "";
                int ID_INTERFAZ = 0;

                if (DDL_SP.Items.Count > 0)
                {
                    SP = DDL_SP.SelectedItem.Text;
                }


                if (DDL_INTERFAZ.Items.Count > 0)
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                }
                else
                {
                    ID_INTERFAZ = -1;
                }

                //===========================================================
                // OBTENEMOS EL CODIGO DE INTERFAZ
                //===========================================================
                string CODIGO = OBTENER_CODIGO_INTERFAZ(ID_INTERFAZ);

                //===========================================================
                // SI EL CODIGO DE INTERFAZ NO ES NULO BUSCAMOS LOS SP
                //===========================================================
                if (!string.IsNullOrWhiteSpace(CODIGO) && !string.IsNullOrWhiteSpace(SP))
                {
                    List<OUTPUT_PARAMETROS> LST_REST = LEER_PARAMETROS_X_SP(CODIGO, SP);
                    FuncionesGenerales.Cargar_Grilla(LST_REST, GRD_PARAMETROS_SP);
                }

            }
            catch (EServiceRestFulException ex)
            {
                MensajeLOG(ex.Message, "ERRORES DE SERVICIO");
            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }
        }

        /// <summary>
        /// OBTENEMOS EL CODIGO DE INTERFAZ POR SU ID
        /// </summary>
        /// <param name="ID_INTERFAZ"></param>
        private string OBTENER_CODIGO_INTERFAZ(int ID_INTERFAZ)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                SMetodos Servicio = new SMetodos();
                List<oSP_READ_CODIGO_INTERFAZ> LST_CODIGO = new List<oSP_READ_CODIGO_INTERFAZ>();
                oSP_READ_CODIGO_INTERFAZ INTERFAZ = new oSP_READ_CODIGO_INTERFAZ();

                //===========================================================
                // CONSTRUCCION DE VARIABLES
                //===========================================================
                iSP_READ_CODIGO_INTERFAZ parametrosInput = new iSP_READ_CODIGO_INTERFAZ();
                parametrosInput.ID_INTERFAZ = ID_INTERFAZ;

                //===========================================================
                // LLAMADA A SERVICIO
                //===========================================================
                LST_CODIGO = Servicio.SP_READ_CODIGO_INTERFAZ(parametrosInput);

                if (LST_CODIGO != null && LST_CODIGO.Count > 0)
                {
                    INTERFAZ = LST_CODIGO.First();
                }

                return INTERFAZ.CODIGO_INTERFAZ;

            }
            catch
            {
                throw;
            }
        }        

    }

    [Serializable]
    public class GlobalesFileSalida
    {
        public List<oSP_READ_PROCESO_FILE> ProcesoFile { get; set; }
        public bool VALIDA_INTERFAZ { get; set; }
        public DataTable ListaExcel { get; set; }
        public List<InterfazExcel> ListaInterfaz { get; set; }
        public List<oSP_READ_INTERFAZ_X_CLUSTER> Interfaces { get; set; }
    }
}
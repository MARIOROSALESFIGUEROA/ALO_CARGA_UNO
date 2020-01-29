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

namespace ALO.WebSite.Formularios.Objetos
{
    public partial class Objeto : System.Web.UI.Page
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
                    LEER_OBJETO(0);
                    CARGAR_GRILLA_OBJETO();
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
        /// LEVANTA MODAL PARA CREAR NUEVO OBJETO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BNT_NUEVO_OBJETO_Click(object sender, EventArgs e)
        {
            try
            {
                LBL_TITULO_OBJETO.Text = "NUEVO OBJETO";
                BTN_OBJETO.Text = "CREAR";
                TXT_ID_OBJETO.Text = "0";
                TXT_DESCRIPCION.Text = "";
                TXT_CODIGO.Text = "";
                FormularioModalJS("MODAL_GRID_OBJETO", "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
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
        /// CREAR O ACTUALIZAR UN NUEVO OBJETO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_OBJETO_Click(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================           
                SMetodos Servicio = new SMetodos();
                int ID_CLUSTER = 0;
                string DESCRIPCION = "";
                string CODIGO = "";
                bool OBLIGATORIO = false;


                //===========================================================
                // VALIDACION DE SELECCION DE CLUSTER
                //===========================================================   
                if (DDL_SELECT_CLUSTER.Items.Count > 0)
                {
                    ID_CLUSTER = Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue);
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UN CLUSTER", "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
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
                    MensajeLOGEdit("A", "DEBES INGRESAR UNA DESCRIPCION", "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
                    return;
                }


                //===========================================================
                // VALIDACION DE DESCRIPCION
                //===========================================================   
                if (!string.IsNullOrWhiteSpace(TXT_CODIGO.Text))
                {
                    CODIGO = TXT_CODIGO.Text;
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES INGRESAR UN CODIGO", "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
                    return;
                }

                OBLIGATORIO = CHK_OBLIGATORIO.Checked;

                if (Convert.ToInt32(TXT_ID_OBJETO.Text) == 0)
                {

                    //=======================================================
                    // CONSTRUCCION DE OBJETO
                    //=======================================================
                    iSP_CREATE_OBJETO ParametrosInput = new iSP_CREATE_OBJETO();
                    ParametrosInput.ID_CLUSTER = ID_CLUSTER;
                    ParametrosInput.DESCRIPCION = DESCRIPCION;
                    ParametrosInput.OBLIGATORIO = OBLIGATORIO;
                    ParametrosInput.CODIGO = CODIGO;


                    //=======================================================
                    // LLAMADA A SERVICIO
                    //=======================================================
                    oSP_RETURN_STATUS ESTADO = Servicio.SP_CREATE_OBJETO(ParametrosInput);

                    if (ESTADO.RETURN_VALUE == -1)
                    {
                        MensajeLOGEdit("A", "EL OBJETO YA SE ENCUENTRA EN EL SISTEMA", "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOGEdit("A", "EL OBJETO NO FUE INGRESADO", "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 1)
                    {
                        MensajeLOGEdit("I", "EL OBJETO FUE INGRESADO CORRECTAMENTE", "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");

                        LEER_OBJETO(ID_CLUSTER);
                        CARGAR_GRILLA_OBJETO();
                        return;
                    }

                }

                if (Convert.ToInt32(TXT_ID_OBJETO.Text) > 0)
                {                    

                    //=======================================================
                    // CONSTRUCCION DE OBJETO
                    //=======================================================
                    iSP_UPDATE_OBJETO ParametrosInput = new iSP_UPDATE_OBJETO();
                    ParametrosInput.ID_OBJETO = Convert.ToInt32(TXT_ID_OBJETO.Text);
                    ParametrosInput.DESCRIPCION = DESCRIPCION;
                    ParametrosInput.OBLIGATORIO = OBLIGATORIO;
                    ParametrosInput.CODIGO = CODIGO;


                    //=======================================================
                    // LLAMADA A SERVICIO
                    //=======================================================
                    oSP_RETURN_STATUS ESTADO = Servicio.SP_UPDATE_OBJETO(ParametrosInput);

                    if (ESTADO.RETURN_VALUE == -1)
                    {
                        MensajeLOGEdit("A", "EL OBJETO YA SE ENCUENTRA EN EL SISTEMA", "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOGEdit("A", "EL OBJETO NO FUE INGRESADO", "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 1)
                    {
                        MensajeLOGEdit("I", "EL OBJETO FUE ACTUALIZADO CORRECTAMENTE", "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
                        
                        LEER_OBJETO(ID_CLUSTER);
                        CARGAR_GRILLA_OBJETO();

                        return;
                    }

                }
            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
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
                    LEER_OBJETO(ID_CLUSTER);
                    CARGAR_GRILLA_OBJETO();
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

                ViewState["GlobalesObjeto"] = new GlobalesObjeto();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// VIEWSTATE PARA VARIABLES GLOBALES
        /// </summary>
        private GlobalesObjeto V_Global()
        {


            GlobalesObjeto item = new GlobalesObjeto();
            try
            {

                item = (GlobalesObjeto)ViewState["GlobalesObjeto"] ?? null;
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
        protected void GRD_OBJETO_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRD_OBJETO.UseAccessibleHeader = true;
                GRD_OBJETO.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }

        /// <summary>
        /// GRILLA ROWCOMMAND
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRD_OBJETO_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //===========================================================
                // ID                                                           
                //===========================================================          
                int ID_OBJETO = Convert.ToInt32(e.CommandArgument);

                if (ID_OBJETO == 0) { return; }

                oSP_READ_OBJETO objeto = V_Global().Objeto.Where(x => x.ID_OBJETO == ID_OBJETO).First();

                //===========================================================
                // EDITAR OBJETO                   
                //===========================================================
                if (e.CommandName == "EditarObjeto")
                {
                    LBL_TITULO_OBJETO.Text = "ACTUALIZAR OBJETO";
                    BTN_OBJETO.Text = "ACTUALIZAR";
                    TXT_ID_OBJETO.Text = objeto.ID_OBJETO.ToString();
                    TXT_DESCRIPCION.Text = objeto.DESCRIPCION_OBJETO;
                    TXT_CODIGO.Text = objeto.CODIGO_OBJETO;
                    CHK_OBLIGATORIO.Checked = objeto.OBLIGATORIO;
                    FormularioModalJS("MODAL_GRID_OBJETO", "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
                }

                //===========================================================
                // ELIMINAR OBJETO                           
                //===========================================================
                if (e.CommandName == "EliminarObjeto")
                {
                    TXT_ID_ELIMINA_OBJETO.Text = objeto.ID_OBJETO.ToString();
                    LBL_TITULO_MENSAJE_ELIMINA_OBJETO.Text = ("EL OBJETO " + objeto.DESCRIPCION_OBJETO + " SE ENCUENTRA INGRESADO EN EL SISTEMA "
                                                                        + Environment.NewLine
                                                                        + "¿ DESEA ELIMINARLO ?");

                    FormularioModalJS("MODAL_ELIMINA_OBJETO", "MSG_INFO_ELIMINA_OBJETO", "MSG_ALERTA_ELIMINA_OBJETO");
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
        protected void BTN_ELIMINA_OBJETO_Click(object sender, EventArgs e)
        {
            try
            {
                //=====================================================================
                // DECLARACION DE VARIABLES
                //=====================================================================
                SMetodos Servicio = new SMetodos();
                int ID_OBJETO = 0;
                int ID_CLUSTER = 0;

                //===========================================================
                // VALIDACION DE SELECCION DE CLUSTER
                //===========================================================   
                if (DDL_SELECT_CLUSTER.Items.Count > 0)
                {
                    ID_CLUSTER = Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue);
                }
                else
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UN CLUSTER", "MSG_INFO_OBJETO", "MSG_ALERTA_OBJETO");
                    return;
                }


                //===========================================================
                // VALIDACION DE SELECCIÓN OBJETO
                //===========================================================
                try
                {
                    ID_OBJETO = Convert.ToInt32(TXT_ID_ELIMINA_OBJETO.Text);
                }
                catch
                {
                    MensajeLOGEdit("A", "EL OBJETO NO ES VÁLIDO", "MSG_INFO_ELIMINA_OBJETO", "MSG_ALERTA_ELIMINA_OBJETO");
                    return;
                }


                //=====================================================================
                // CREACION DE OBJETO
                //=====================================================================
                iSP_DELETE_OBJETO parametrosInput = new iSP_DELETE_OBJETO();
                parametrosInput.ID_OBJETO = ID_OBJETO;

                //=====================================================================
                // LLAMADA A SERVICIO
                //=====================================================================
                oSP_RETURN_STATUS ESTADO = Servicio.SP_DELETE_OBJETO(parametrosInput);

                if (ESTADO.RETURN_VALUE == 0)
                {

                    MensajeLOGEdit("A", "EL OBJETO NO FUE ELIMINADO", "MSG_INFO_ELIMINA_OBJETO", "MSG_ALERTA_ELIMINA_OBJETO");
                    return;
                }

                if (ESTADO.RETURN_VALUE == 1)
                {
                    MensajeLOGEdit("I", "EL OBJETO FUE ELIMINADO CORRECTAMENTE", "MSG_INFO_ELIMINA_OBJETO", "MSG_ALERTA_ELIMINA_OBJETO");
                    LEER_OBJETO(ID_CLUSTER);
                    CARGAR_GRILLA_OBJETO();
                    return;
                }

            }
            catch (EServiceRestFulException svr)
            {
                MensajeLOGEdit("A", svr.Message, "MSG_INFO_ELIMINA_OBJETO", "MSG_ALERTA_ELIMINA_OBJETO");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_ELIMINA_OBJETO", "MSG_ALERTA_ELIMINA_OBJETO");
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
        /// CARGAR GRILLA DE DATOS
        /// </summary>
        private void CARGAR_GRILLA_OBJETO()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================                
                List<oSP_READ_OBJETO> Lista = new List<oSP_READ_OBJETO>();


                //===========================================================
                // LLAMADA A SERVICIO            
                //===========================================================
                Lista = V_Global().Objeto;

                if (Lista == null)
                {
                    Lista = new List<oSP_READ_OBJETO>();
                }

                FuncionesGenerales.Cargar_Grilla(Lista, GRD_OBJETO);
            }
            catch
            {
                throw;
            }
        }


    }

    [Serializable]
    public class GlobalesObjeto
    {
        public List<oSP_READ_OBJETO> Objeto { get; set; }
    }
}
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
    public partial class AsignacionObjeto : System.Web.UI.Page
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
        /// LEVANTA MODAL PARA CREAR NUEVA ASIGNACION DE OBJETO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BNT_NUEVA_ASIGNACION_Click(object sender, EventArgs e)
        {
            try
            {
                LBL_TITULO_OBJETO_X_INTERFAZ.Text = "NUEVA ASIGNACIÓN DE OBJETOS";
                TXT_ID_OBJETO.Text = "0";
                TXT_VALOR.Text = "";
                BTN_OBJETO_X_INTERFAZ.Text = "CREAR";
                FormularioModalJS("MODAL_GRID_OBJETO_X_INTERFAZ", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
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
        /// CARGA LISTA PAISES
        /// </summary>
        private void CARGAR_LISTA_OBJETOS()
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
                                                     .Select(p => new Item_Seleccion { Id = p.ID_OBJETO, Nombre = p.CODIGO_OBJETO })
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
                // VALIDACION DE SELECCION DE PAIS                             
                //===========================================================
                if (Convert.ToInt32(DDL_INTERFAZ.SelectedValue) == 0)
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UNA INTERFAZ", "MSG_INFO_OBJETO_X_INTERFAZ", "MSG_ALERTA_OBJETO_X_INTERFAZ");
                    return;
                }
                else
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
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
                if (Convert.ToInt32(DDL_INTERFAZ.SelectedValue) == 0)
                {
                    MensajeLOGEdit("A", "DEBES SELECCIONAR UNA INTERFAZ", "MSG_INFO_ELIMINA_OBJETO_X_INTERFAZ", "MSG_ALERTA_ELIMINA_OBJETO_X_INTERFAZ");
                    return;
                }
                else
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
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
                    MensajeLOGEdit("A", "EL OBJETO NO ES VALIDO", "MSG_INFO_ELIMINA_OBJETO_X_INTERFAZ", "MSG_ALERTA_ELIMINA_OBJETO_X_INTERFAZ");
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
                    CARGAR_LISTA_OBJETOS();
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

                ViewState["GlobalesObjetoInterfaz"] = new GlobalesObjetoInterfaz();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// VIEWSTATE PARA VARIABLES GLOBALES
        /// </summary>
        private GlobalesObjetoInterfaz V_Global()
        {


            GlobalesObjetoInterfaz item = new GlobalesObjetoInterfaz();
            try
            {

                item = (GlobalesObjetoInterfaz)ViewState["GlobalesObjetoInterfaz"] ?? null;
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
                // ELIMINAR ASIGNACIÓN OBJETO                          
                //===========================================================
                if (e.CommandName == "EliminarObjeto")
                {
                    TXT_ID_ELIMINA_OBJETO_X_INTERFAZ.Text = objeto.ID_OBJETO_X_INTERFAZ.ToString();
                    LBL_TITULO_MENSAJE_ELIMINA_OBJETO_X_INTERFAZ.Text = ("EL OBJETO " + objeto.DESCRIPCION_OBJETO + " SE ENCUENTRA ASIGNADO A ESTA INTERFAZ "
                                                                        + Environment.NewLine
                                                                        + "¿ DESEA ELIMINAR LA ASIGNACIÓN ?");

                    FormularioModalJS("MODAL_ELIMINA_OBJETO_X_INTERFAZ", "MSG_INFO_ELIMINA_OBJETO_X_INTERFAZ", "MSG_ALERTA_ELIMINA_OBJETO_X_INTERFAZ");
                }

                //===========================================================
                // EDITAR ASIGNACIÓN OBJETO                    
                //===========================================================
                if (e.CommandName == "EditarObjeto")
                {
                    LBL_TITULO_OBJETO_X_INTERFAZ.Text = "ACTUALIZAR ASIGNACIÓN DE OBJETO";
                    TXT_ID_OBJETO.Text = objeto.ID_OBJETO_X_INTERFAZ.ToString();
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

                LEER_OBJETOS_X_INTERFAZ(ID_INTERFAZ);
                CARGAR_GRILLA_OBJETO_X_INTERFAZ();                
            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }
        }

    }

    [Serializable]
    public class GlobalesObjetoInterfaz
    {
        public List<oSP_READ_OBJETO> Objeto { get; set; }
        public List<oSP_READ_INTERFAZ_X_CLUSTER> Interfaces { get; set; }
        public List<oSP_READ_OBJETO_X_INTERFAZ> ObjetoInterfaz { get; set; }
    }
}
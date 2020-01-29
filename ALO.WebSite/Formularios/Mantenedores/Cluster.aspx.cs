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

namespace ALO.WebSite.Formularios.Mantenedores
{
    public partial class Cluster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                GRDCluster.PreRender += new EventHandler(GRDCluster_PreRender);


                if (!this.IsPostBack)
                {
                    Establecer_Globales();
                    LEER_PAIS();
                    LEER_CLUSTER();

                }

            }
            catch (EServiceRestFulException svr)
            {
                MensajeLOG(svr.Message, "ERRORES DE SERVICIO");
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
                ViewState["GlobalesCluster"] = new GlobalesCluster();
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// VIEWSTATE PARA VARIABLES GLOBALES
        /// </summary>
        /// <returns></returns>
        private GlobalesCluster V_Global()
        {
            GlobalesCluster item = new GlobalesCluster();
            try
            {
                item = (GlobalesCluster)ViewState["GlobalesCluster"] ?? null;
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
        /// GRILLA PRE-RENDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDCluster_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRDCluster.UseAccessibleHeader = true;
                GRDCluster.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }

        /// <summary>
        /// DIBUJAR GRILLA DE DATOS
        /// </summary>
        private void DibujarGrillaCluster()
        {
            try
            {
                List<oSP_READ_CLUSTER> Lista = new List<oSP_READ_CLUSTER>();
                for (int i = 1; i <= 1; i++)
                {
                    Lista.Add(new oSP_READ_CLUSTER());
                }
                FuncionesGenerales.Cargar_Grilla(Lista, GRDCluster);
            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// AGREGAR DATA DE CLUSTER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LINK_NuevoCluster_Click(Object sender, EventArgs e)
        {


            try
            {


                //===========================================================
                // SETEAR VALORES                                                           
                //===========================================================
                TXT_ID.Text ="0";
                TXT_CODIGO.Text = "";

                TXT_CODIGO.Enabled = true;
                CHK_OPCION.Checked = true;
                CHK_OPCION.Enabled = false;

                TXT_DESCRIPCION.Text = "";
                CHK_ESTADO.Checked = true;
                CHK_ESTADO.Enabled = false;


                LBL_TITULO_CLUSTER.Text = "AGREGAR NUEVO CLUSTER";
                FormularioModalJS("MODAL_CLUSTER", "MSG_CLUSTER_INFO", "MSG_CLUSTER_ALERTA");



            }
            catch (System.Exception ex)
            {

                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");

            }



        }


        /// <summary>
        /// GRILLA DE GRUPOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDCluster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {


                //===========================================================
                // ID                                                           
                //===========================================================
                int ID = Convert.ToInt32(e.CommandArgument);
                if (ID == 0) { return; }

                oSP_READ_CLUSTER Objeto = new oSP_READ_CLUSTER();
                Objeto = V_Global().ListaCluster.Where(p => p.ID_CLUSTER == ID).First();
                

                //===========================================================
                // EDITAR DATA                                                  
                //===========================================================
                if (e.CommandName == "EditarData")
                {


                    //===========================================================
                    // SETEAR VALORES                                                           
                    //===========================================================
                    TXT_ID.Text = Objeto.ID_CLUSTER.ToString();
                    FuncionesGenerales.BuscarIdCombo(DDL_PAIS, Objeto.ID_PAIS);
                    TXT_CODIGO.Text = Objeto.CODIGO;

                    TXT_CODIGO.Enabled = false;
                    CHK_OPCION.Checked = false;
                    CHK_OPCION.Enabled = true;


                    TXT_DESCRIPCION.Text = Objeto.DESCRIPCION;
                    CHK_ESTADO.Checked = Objeto.ESTADO;
                    CHK_ESTADO.Enabled = true;


                    LBL_TITULO_CLUSTER.Text = "MODIFICAR CLUSTER";
                    FormularioModalJS("MODAL_CLUSTER", "MSG_CLUSTER_INFO", "MSG_CLUSTER_ALERTA");



                }



                //===========================================================
                // ELIMINAR DATA                                                  
                //===========================================================
                if (e.CommandName == "EliminarData")
                {


                    LBL_ELIMINAR.Text = "ELIMINACIÓN DE CLUSTER";
                    string NOMBRE = Objeto.DESCRIPCION;


                    TXT_ID_ELIMINA.Text = ID.ToString();
                    LBL_MENSAJE_ELIMINA.Text = ("CLUSTER DESCRIPCIÓN: "
                                                        + NOMBRE
                                                        + " SE ENCUENTRA INGRESADO EN SISTEMA "
                                                        + Environment.NewLine
                                                        + "¿ DESEA ELIMINAR DE TODAS FORMAS ?");

                    FormularioModalJS("MODAL_GRID_ELIMINA", "MSG_INFO_ELIMINA", "MSG_ALERTA_ELIMINA");



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
        /// AL SELECCIONAR OPCION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CHK_OPCION_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {


                if (CHK_OPCION.Checked == true)
                {
                    TXT_CODIGO.Enabled = true;
                }
                else
                {
                    TXT_CODIGO.Enabled = false;
                }


            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_CLUSTER_INFO", "MSG_CLUSTER_ALERTA");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_CLUSTER_INFO", "MSG_CLUSTER_ALERTA");
            }

        }

        /// <summary>
        /// ACTUALIZAR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_EditGrilla_Click(object sender, EventArgs e)
        {


            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES                                                
                //===========================================================
                int ID_CLUSTER = 0;
                int ID_PAIS = 0;
                string CODIGO = "";
                string DESCRIPCION = "";
                bool ESTADO_CLUSTER = false;
                SMetodos Servicio = new SMetodos();






                //===========================================================
                // VALIDACION DE OBSERVACION                                                
                //===========================================================
                if (string.IsNullOrEmpty(TXT_ID.Text))
                {
                    throw new Exception("NO EXISTE ID VALIDO PARA CREAR Y TAMPOCO ACTUALIZAR");
                }
                else
                {

                    try
                    {
                        ID_CLUSTER = Convert.ToInt32(TXT_ID.Text);
                    }
                    catch 
                    {
                        throw new Exception("ID ESPECIFICADO NO ES UN NUMERO VALIDO");
                    }

                }

                //===========================================================
                // CODIGO                                                
                //===========================================================
                if (ID_CLUSTER > 0)
                {

                    if (CHK_OPCION.Checked == true)
                    {
                        if (string.IsNullOrEmpty(TXT_CODIGO.Text))
                        {
                            throw new Exception("NO EXISTE CODIGO VALIDO PARA CREAR Y TAMPOCO ACTUALIZAR");
                        }
                        else
                        {
                            CODIGO = TXT_CODIGO.Text;
                        }
                    }


                }
                else
                {

                    if (string.IsNullOrEmpty(TXT_CODIGO.Text))
                    {
                        throw new Exception("NO EXISTE CODIGO VALIDO PARA CREAR Y TAMPOCO ACTUALIZAR");
                    }
                    else
                    {
                        CODIGO = TXT_CODIGO.Text;
                    }

                }

                //===========================================================
                // VALIDACION DE OBSERVACION                                                
                //===========================================================
                if (string.IsNullOrEmpty(TXT_DESCRIPCION.Text))
                {
                    throw new Exception("DEBE INGRESAR UNA DESCRIPCION");
                }
                else
                {
                    DESCRIPCION = TXT_DESCRIPCION.Text;
                }
                //===========================================================
                // ESTADO                                                
                //===========================================================
                ESTADO_CLUSTER = CHK_ESTADO.Checked;

                //===========================================================
                // PAIS                                                
                //===========================================================
                if (DDL_PAIS.Items.Count > 0)
                {
                    ID_PAIS = Convert.ToInt32(DDL_PAIS.SelectedValue);
                }
                else
                {
                    throw new Exception("NO EXISTEN PAIS EN LISTA");

                }

                //===========================================================
                // VER SI ACTUALIZAMOS O INGRESAMOS                                                
                //===========================================================
                if (ID_CLUSTER == 0)
                {



                    iSP_CREATE_CLUSTER ParametrosInput = new iSP_CREATE_CLUSTER();
                    ParametrosInput.ID_PAIS = ID_PAIS;
                    ParametrosInput.CODIGO = CODIGO;
                    ParametrosInput.DESCRIPCION = DESCRIPCION;
                    ParametrosInput.ESTADO = ESTADO_CLUSTER;



                    //=======================================================
                    // LLAMADA A SERVICIO
                    //=======================================================
                    oSP_RETURN_STATUS ESTADO = Servicio.SP_CREATE_CLUSTER(ParametrosInput);

                    if (ESTADO.RETURN_VALUE == 1)
                    {
                        MensajeLOGEdit("I", "CLUSTER FUE CREADO CORRECTAMANTE", "MSG_CLUSTER_INFO", "MSG_CLUSTER_ALERTA");
                        LEER_CLUSTER();
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == -1)
                    {
                        MensajeLOGEdit("A", "CÓDIGO DE  CLUSTER YA EXISTE EN SISTEMA", "MSG_CLUSTER_INFO", "MSG_CLUSTER_ALERTA");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOGEdit("A", "CLUSTER NO FUE ACTUALIZADO", "MSG_CLUSTER_INFO", "MSG_CLUSTER_ALERTA");
                        return;
                    }


                }
                else
                {


                    iSP_UPDATE_CLUSTER ParametrosInput = new iSP_UPDATE_CLUSTER();
                    ParametrosInput.ID_CLUSTER = ID_CLUSTER;
                    ParametrosInput.ID_PAIS = ID_PAIS;
                    ParametrosInput.CODIGO = CODIGO;
                    ParametrosInput.DESCRIPCION = DESCRIPCION;
                    ParametrosInput.ESTADO = ESTADO_CLUSTER;
                    ParametrosInput.OPCION = CHK_OPCION.Checked;


                    //=======================================================
                    // LLAMADA A SERVICIO
                    //=======================================================
                    oSP_RETURN_STATUS ESTADO = Servicio.SP_UPDATE_CLUSTER(ParametrosInput);

                    if (ESTADO.RETURN_VALUE == 1)
                    {
                        MensajeLOGEdit("I", "CLUSTER FUE ACTUALIZADO CORRECTAMANTE", "MSG_CLUSTER_INFO", "MSG_CLUSTER_ALERTA");
                        LEER_CLUSTER();
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == -1)
                    {
                        MensajeLOGEdit("A", "YA EXISTE CLÚSTER CON ESE CÓDIGO", "MSG_CLUSTER_INFO", "MSG_CLUSTER_ALERTA");
                        LEER_CLUSTER();
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOGEdit("A", "CLUSTER NO FUE ACTUALIZADO", "MSG_CLUSTER_INFO", "MSG_CLUSTER_ALERTA");
                        return;
                    }


                }


            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_CLUSTER_INFO", "MSG_CLUSTER_ALERTA");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_CLUSTER_INFO", "MSG_CLUSTER_ALERTA");
            }
        }

        /// <summary>
        /// ELIMINAR SP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_ELIMINA_Click(object sender, EventArgs e)
        {


            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES                                          
                //===========================================================
                SMetodos Servicio = new SMetodos();


                //===========================================================
                // PARAMETROS                                           
                //===========================================================
                iSP_DELETE_CLUSTER ParametrosInput = new iSP_DELETE_CLUSTER();
                ParametrosInput.ID_CLUSTER = Convert.ToInt32(TXT_ID_ELIMINA.Text);



                //===========================================================
                // LLAMADA A SERVICIO                                           
                //===========================================================
                oSP_RETURN_STATUS ObjetoRest = Servicio.SP_DELETE_CLUSTER(ParametrosInput);

                if (ObjetoRest.RETURN_VALUE == 0)
                {

                    MensajeLOGEdit("A", "ELIMINACION DE CLUSTER NO FUE REALIZADA", "MSG_INFO_ELIMINA", "MSG_ALERTA_ELIMINA");
                    return;
                }

                if (ObjetoRest.RETURN_VALUE == 1)
                {

                    MensajeLOGEdit("I", "ELIMINACION DE CLUSTER FUE REALIZADA CORRECTAMANTE", "MSG_INFO_ELIMINA", "MSG_ALERTA_ELIMINA");
                    LEER_CLUSTER();
                    return;
                }




            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_INFO_ELIMINA", "MSG_ALERTA_ELIMINA");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_INFO_ELIMINA", "MSG_ALERTA_ELIMINA");
            }



        }
        /// <summary>
        /// LEER PAIS
        /// </summary>
        private void LEER_PAIS()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                SMetodos Negocio = new SMetodos();
                List<oSP_READ_PAIS> ListaPais = new List<oSP_READ_PAIS>();


                //===========================================================
                // LLAMADA DEL SERVICIO                                    ==
                //===========================================================                
                ListaPais = Negocio.SP_READ_PAIS();


                if (ListaPais == null)
                {
                    FuncionesGenerales.CDDLCombos(null, DDL_PAIS);
                    return;
                }
                if (ListaPais.Count <= 0)
                {
                    FuncionesGenerales.CDDLCombos(null, DDL_PAIS);
                    return;
                }

                List<Item_Seleccion> Lista = new List<Item_Seleccion>();
                Lista = ListaPais.OrderBy(p => p.ID_PAIS).Select(p => new Item_Seleccion { Id = p.ID_PAIS, Nombre = p.DESCRIPCION }).ToList();


                FuncionesGenerales.CDDLCombos(Lista, DDL_PAIS);


            }
            catch
            {
                throw;
            }


        }


        /// <summary>
        /// LEER GRUPO
        /// </summary>
        private void LEER_CLUSTER()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                SMetodos Negocio = new SMetodos();
                List<oSP_READ_CLUSTER> ListaCluster = new List<oSP_READ_CLUSTER>();




                //===========================================================
                // LLAMADA DEL SERVICIO                                    ==
                //===========================================================                
                ListaCluster = Negocio.SP_READ_CLUSTER();


                if (ListaCluster == null)
                {
                    DibujarGrillaCluster();
                    return;
                }
                if (ListaCluster.Count <= 0)
                {
                    DibujarGrillaCluster();
                    return;
                }

                FuncionesGenerales.Cargar_Grilla(ListaCluster, GRDCluster);
                V_Global().ListaCluster = ListaCluster;


            }
            catch
            {
                throw;
            }


        }

    }

    [Serializable]
    public class GlobalesCluster
    {

        public List<oSP_READ_CLUSTER> ListaCluster { get; set; }


    }
}
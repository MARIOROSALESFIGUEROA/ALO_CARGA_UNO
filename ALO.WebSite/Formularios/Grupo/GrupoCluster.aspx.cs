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

namespace ALO.WebSite.Formularios.Grupo
{
    public partial class GrupoCluster : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                GRDGrupo.PreRender += new EventHandler(GRDGrupo_PreRender);
                GRDCluster.PreRender += new EventHandler(GRDCluster_PreRender);


                if (!this.IsPostBack)
                {
                    Establecer_Globales();
                    DibujarGrillaGrupo();
                    DibujarGrillaCluster();
                    LEER_GRUPO();
                   
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
        /// <returns></returns>
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
        /// GRILLA PRE-RENDER
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDGrupo_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRDGrupo.UseAccessibleHeader = true;
                GRDGrupo.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            catch { }
        }

        /// <summary>
        /// DIBUJAR GRILLA DE DATOS
        /// </summary>
        private void DibujarGrillaGrupo()
        {
            try
            {
                List<oSP_READ_GRUPO> Lista = new List<oSP_READ_GRUPO>();
                for (int i = 1; i <= 1; i++)
                {
                    Lista.Add(new oSP_READ_GRUPO());
                }
                FuncionesGenerales.Cargar_Grilla(Lista, GRDGrupo);
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// DIBUJAR GRILLA DE DATOS
        /// </summary>
        private void DibujarGrillaCluster()
        {
            try
            {
                List<oSP_READ_GRUPO_X_CLUSTER> Lista = new List<oSP_READ_GRUPO_X_CLUSTER>();
                for (int i = 1; i <= 1; i++)
                {
                    Lista.Add(new oSP_READ_GRUPO_X_CLUSTER());
                }
                FuncionesGenerales.Cargar_Grilla(Lista, GRDCluster);
            }
            catch
            {
                throw;
            }
        }
        /// <summary>
        /// AGREGAR DATA DE GRUPO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void LINK_NuevoGrupo_Click(Object sender, EventArgs e)
        {


            try
            {


                //===========================================================
                // SETEAR VALORES                                                           
                //===========================================================
                TXT_ID.Text = "0";
                TXT_DESCRIPCION.Text = "";
                CHK_ESTADO.Checked = true;
                CHK_ESTADO.Enabled = false;

                LBL_TITULO_GRUPO.Text = "AGREGAR NUEVO GRUPO";
                FormularioModalJS("MODAL_GRUPO", "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");



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
        protected void GRDGrupo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {


                //===========================================================
                // ID                                                           
                //===========================================================
                int ID = Convert.ToInt32(e.CommandArgument);
                if (ID == 0) { return; }

                oSP_READ_GRUPO Objeto = new oSP_READ_GRUPO();
                Objeto = V_Global().ListaGrupo.Where(p => p.ID_GRUPO == ID).First();

                //===========================================================
                // EDITAR DATA                                                  
                //===========================================================
                if (e.CommandName == "EditarData")
                {


                    //===========================================================
                    // SETEAR VALORES                                                           
                    //===========================================================
                    TXT_ID.Text = Objeto.ID_GRUPO.ToString();
                    TXT_DESCRIPCION.Text = Objeto.DESCRIPCION;
                    CHK_ESTADO.Checked = Objeto.ESTADO;
                    CHK_ESTADO.Enabled = true;


                    LBL_TITULO_GRUPO.Text = "MODIFICAR GRUPO";
                    FormularioModalJS("MODAL_GRUPO", "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");



                }

                //===========================================================
                // LISTAR DATA                                                  
                //===========================================================
                if (e.CommandName == "TraerCluster")
                {
                    LEER_CLUSTER(ID);
                    
                }


                //===========================================================
                // ELIMINAR DATA                                                  
                //===========================================================
                if (e.CommandName == "EliminarData")
                {


                    LBL_ELIMINAR.Text = "ELIMINACIÓN DE GRUPO";
                    string NOMBRE = Objeto.DESCRIPCION;

                    TXT_ID_ELIMINA.Text = ID.ToString();
                    LBL_MENSAJE_ELIMINA.Text = ("EL GRUPO CON LA DESCRIPCIÓN: "
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
        /// GRILLA DE USUARIOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDCluster_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES                                                
                //===========================================================
                SMetodos Servicio = new SMetodos();


                //===========================================================
                // ID                                                           
                //===========================================================
                int ID = Convert.ToInt32(e.CommandArgument);
                if (ID == 0) { return; }


                //===========================================================
                // ASIGNACION                                                
                //===========================================================
                if (e.CommandName == "ASIGNAR")
                {

                    int ID_CLUSTER = ID;
                    int ID_GRUPO = V_Global().ListaCluster.Where(p => p.ID_CLUSTER == ID_CLUSTER).Select(p => p.ID_GRUPO).FirstOrDefault();
                    bool ENCONTRADO = V_Global().ListaCluster.Where(p => p.ID_CLUSTER == ID_CLUSTER).Select(p => p.ENCONTRADO).FirstOrDefault();



                    if (ENCONTRADO == false)
                    {

                        iSP_CREATE_GRUPO_X_CLUSTER ParametrosInput = new iSP_CREATE_GRUPO_X_CLUSTER();
                        ParametrosInput.ID_GRUPO = ID_GRUPO;
                        ParametrosInput.ID_CLUSTER = ID_CLUSTER;

                        

                        //=======================================================
                        // LLAMADA A SERVICIO
                        //=======================================================
                        oSP_RETURN_STATUS ESTADO = Servicio.SP_CREATE_GRUPO_X_CLUSTER(ParametrosInput);

                        if (ESTADO.RETURN_VALUE == -1)
                        {
                            MensajeLOG("CLUSER YA ESTA ASIGNADO", "ASIGNACIÓN DE USUARIOS");
                        }

                        if (ESTADO.RETURN_VALUE == 0)
                        {
                            MensajeLOG("CLUSER NO FUE ACTUALIZADO", "ASIGNACIÓN DE USUARIOS");
                        }



                    }
                    else
                    {

                        //=======================================================
                        // PARAMETROS DE ENTRADA 
                        //=======================================================
                        iSP_DELETE_GRUPO_X_CLUSTER ParametrosInput = new iSP_DELETE_GRUPO_X_CLUSTER();
                        ParametrosInput.ID_GRUPO = ID_GRUPO;
                        ParametrosInput.ID_CLUSTER = ID_CLUSTER;


                        //=======================================================
                        // LLAMADA A SERVICIO
                        //=======================================================
                        oSP_RETURN_STATUS ESTADO = Servicio.SP_DELETE_GRUPO_X_CLUSTER(ParametrosInput);

                        if (ESTADO.RETURN_VALUE == 0)
                        {
                            MensajeLOG("CLUSER NO FUE ACTUALIZADO", "ASIGNACIÓN DE USUARIOS");
                        }



                    }

                    //=======================================================
                    // REFRESCAR GRILLA                                
                    //=======================================================
                    LEER_CLUSTER(ID_GRUPO);




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
        /// ACTUALIZAR O INGRESAR INFORMACION DE GRUPOS
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
                string DESCRIPCION = "";
                bool ESTADO_GRUPO = false;
                int ID_GRUPO = 0;
                SMetodos Servicio = new SMetodos();
                oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();


                //===========================================================
                // VALIDACION DE OBSERVACION                                                
                //===========================================================
                if (string.IsNullOrEmpty(TXT_DESCRIPCION.Text))
                {
                    throw new Exception("DEBE INGRESAR UNA OBSERVACION");
                }

                //===========================================================
                // ASIGNACION                                                
                //===========================================================
                ESTADO_GRUPO = CHK_ESTADO.Checked;
                DESCRIPCION = TXT_DESCRIPCION.Text;


                //===========================================================
                // VALIDACION DE OBSERVACION                                                
                //===========================================================
                if (string.IsNullOrEmpty(TXT_ID.Text))
                {
                    throw new Exception("NO EXISTE ID VALIDO PARA CREAR Y TAMPOCO ACTUALIZAR");
                }

                //===========================================================
                // ID ASIGNADO                                                
                //===========================================================
                try
                {
                    ID_GRUPO = Convert.ToInt32(TXT_ID.Text);

                }
                catch
                {
                    throw new Exception("ID ENVIADO NO ES UN NUMERO VALIDO");

                }

                //===========================================================
                // VER SI ACTUALIZAMOS O INGRESAMOS                                                
                //===========================================================
                if (ID_GRUPO == 0)
                {

                    iSP_CREATE_GRUPO ParametrosInput = new iSP_CREATE_GRUPO();
                    ParametrosInput.ID_GRUPO = ID_GRUPO;
                    ParametrosInput.DESCRIPCION = DESCRIPCION;



                    //=======================================================
                    // LLAMADA A SERVICIO
                    //=======================================================
                    oSP_RETURN_STATUS ESTADO = Servicio.SP_CREATE_GRUPO(ParametrosInput);

                    if (ESTADO.RETURN_VALUE == -1)
                    {
                        MensajeLOGEdit("A", "GRUPO FUE INGRESADO CORRECTAMANTE", "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");
                        LEER_GRUPO();
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOGEdit("A", "GRUPO NO FUE ACTUALIZADO", "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");
                        return;
                    }


                }
                else
                {

                    iSP_UPDATE_GRUPO ParametrosInput = new iSP_UPDATE_GRUPO();
                    ParametrosInput.ID_GRUPO = ID_GRUPO;
                    ParametrosInput.DESCRIPCION = DESCRIPCION;
                    ParametrosInput.ESTADO = ESTADO_GRUPO;


                    //=======================================================
                    // LLAMADA A SERVICIO
                    //=======================================================
                    oSP_RETURN_STATUS ESTADO = Servicio.SP_UPDATE_GRUPO(ParametrosInput);

                   
                    if (ESTADO.RETURN_VALUE == 1)
                    {
                        MensajeLOGEdit("A", "GRUPO FUE ACTUALIZADO CORRECTAMANTE", "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");
                        LEER_GRUPO();
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == -1)
                    {
                        MensajeLOGEdit("A", "ERROR AL ACTUALIZAR, DESCRIPCIÓN YA EXISTE EN SISTEMA", "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");
                        return;
                    }

                    if (ESTADO.RETURN_VALUE == 0)
                    {
                        MensajeLOGEdit("A", "GRUPO NO FUE ACTUALIZADO", "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");
                        return;
                    }


                }





            }
            catch (EServiceRestFulException srv)
            {
                MensajeLOGEdit("A", srv.Message, "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");
            }
            catch (System.Exception ex)
            {
                MensajeLOGEdit("A", UThrowError.MensajeThrow(ex), "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");

            }





        }


        /// <summary>
        /// LEER GRUPO
        /// </summary>
        private void LEER_GRUPO()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                SMetodos Negocio = new SMetodos();
                List<oSP_READ_GRUPO> ListaGrupo = new List<oSP_READ_GRUPO>();

 
                //===========================================================
                // LLAMADA DEL SERVICIO                                    ==
                //===========================================================                
                ListaGrupo = Negocio.SP_READ_GRUPO();


                if (ListaGrupo == null)
                {
                    DibujarGrillaGrupo();
                    return;
                }
                if (ListaGrupo.Count <= 0)
                {
                    DibujarGrillaGrupo();
                    return;
                }

                FuncionesGenerales.Cargar_Grilla(ListaGrupo, GRDGrupo);
                V_Global().ListaGrupo = ListaGrupo;


            }
            catch
            {
                throw;
            }


        }

        /// <summary>
        /// LEER GRUPO
        /// </summary>
        private void LEER_CLUSTER(int ID_GRUPO)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                SMetodos Negocio = new SMetodos();
                List<oSP_READ_GRUPO_X_CLUSTER> ListaCluster = new List<oSP_READ_GRUPO_X_CLUSTER>();



                //===========================================================
                // PARAMETROS DE ENTRADA 
                //===========================================================
                iSP_READ_GRUPO_X_CLUSTER ParametrosInput = new iSP_READ_GRUPO_X_CLUSTER();
                ParametrosInput.ID_GRUPO = ID_GRUPO;

                //===========================================================
                // LLAMADA DEL SERVICIO                                    ==
                //===========================================================                
                ListaCluster = Negocio.SP_READ_GRUPO_X_CLUSTER(ParametrosInput);


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
                iSP_DELETE_GRUPO ParametrosInput = new iSP_DELETE_GRUPO();
                ParametrosInput.ID_GRUPO = Convert.ToInt32(TXT_ID_ELIMINA.Text);



                //===========================================================
                // LLAMADA A SERVICIO                                           
                //===========================================================
                oSP_RETURN_STATUS ObjetoRest = Servicio.SP_DELETE_GRUPO(ParametrosInput);

                if (ObjetoRest.RETURN_VALUE == 0)
                {

                    MensajeLOGEdit("A", "ELIMINACION DE GRUPO NO FUE REALIZADA", "MSG_INFO_ELIMINA", "MSG_ALERTA_ELIMINA");
                    return;
                }

                if (ObjetoRest.RETURN_VALUE == 1)
                {

                    MensajeLOGEdit("I", "ELIMINACION DE GRUPO FUE REALIZADA CORRECTAMANTE", "MSG_INFO_ELIMINA", "MSG_ALERTA_ELIMINA");
                    LEER_GRUPO();
                    DibujarGrillaCluster();
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

    }

    [Serializable]
    public class GlobalesGrupoCarga
    {

        public List<oSP_READ_GRUPO> ListaGrupo { get; set; }
        public List<oSP_READ_GRUPO_X_CLUSTER> ListaCluster { get; set; }

    }
}
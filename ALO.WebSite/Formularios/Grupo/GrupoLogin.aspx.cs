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
    public partial class GrupoLogin : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {

                GRDGrupo.PreRender += new EventHandler(GRDGrupo_PreRender);
                GRDUsuario.PreRender += new EventHandler(GRDUsuario_PreRender);


                if (!this.IsPostBack)
                {
                    Establecer_Globales();
                    DibujarGrillaGrupo();
                    DibujarGrillaUsuario();
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
                ViewState["GlobalesGrupoLogin"] = new GlobalesGrupoLogin();
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
        private GlobalesGrupoLogin V_Global()
        {
            GlobalesGrupoLogin item = new GlobalesGrupoLogin();
            try
            {
                item = (GlobalesGrupoLogin)ViewState["GlobalesGrupoLogin"] ?? null;
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
        protected void GRDUsuario_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRDUsuario.UseAccessibleHeader = true;
                GRDUsuario.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        private void DibujarGrillaUsuario()
        {
            try
            {
                List<oSP_READ_GRUPO_X_LOGIN> Lista = new List<oSP_READ_GRUPO_X_LOGIN>();
                for (int i = 1; i <= 1; i++)
                {
                    Lista.Add(new oSP_READ_GRUPO_X_LOGIN());
                }
                FuncionesGenerales.Cargar_Grilla(Lista, GRDUsuario);
            }
            catch
            {
                throw;
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




                //===========================================================
                // TRAER USUARIOS                                             
                //===========================================================
                if (e.CommandName == "TraerUsuario")
                {
                    LEER_USUARIO(ID);

                }

                //===========================================================
                // ASIGNAR USUARIOS                                                
                //===========================================================
                if (e.CommandName == "AsignaUsuario")
                {
                    //=======================================================
                    // SETEAR VALORES                                                           
                    //=======================================================
                    TXT_ID.Text = ID.ToString();
                    TXT_LOGIN.Text = "";
                    LBL_TITULO_GRUPO.Text = "AGREGAR USUARIO AL GRUPO";
                    FormularioModalJS("MODAL_GRUPO", "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");


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
        protected void GRDUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
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

                oSP_READ_GRUPO_X_LOGIN Objeto = V_Global().ListaUsuarios.Where(p => p.ID == ID).First();

                //===========================================================
                // ASIGNACION                                                
                //===========================================================
                if (e.CommandName == "EliminarData")
                {


                    LBL_ELIMINAR.Text = "ELIMINACIÓN DE USUARIO";
                    string NOMBRE = Objeto.NOMBRE_USUARIO;

                    TXT_ID_ELIMINA_1.Text = Objeto.ID_GRUPO.ToString();
                    TXT_ID_ELIMINA_2.Text = Objeto.NRO_USUARIO.ToString();
                    LBL_MENSAJE_ELIMINA.Text = ("EL USUARIO: "
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
                string LOGIN = "";
                int ID_GRUPO = 0;                
                SMetodos Servicio = new SMetodos();


                //===========================================================
                // VALIDACION DE OBSERVACION                                                
                //===========================================================
                if (string.IsNullOrEmpty(TXT_LOGIN.Text))
                {
                    throw new Exception("DEBE INGRESAR UN LOGIN");
                }

                //===========================================================
                // ASIGNACION                                                
                //===========================================================
                LOGIN = TXT_LOGIN.Text;


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
                // CONSTRUCCION DE OBJETO
                //===========================================================
                iSP_VALIDA_EXISTE_USUARIO ParametrosInputValida = new iSP_VALIDA_EXISTE_USUARIO();
                ParametrosInputValida.LOGIN = LOGIN;

                //===========================================================
                // LLAMADA ASERVICIO
                //===========================================================
                List<oSP_VALIDA_EXISTE_USUARIO> LST_LOGIN = Servicio.SP_VALIDA_EXISTE_USUARIO(ParametrosInputValida);

                //===========================================================
                // VALIDACION DE LISTA
                //===========================================================
                if (LST_LOGIN == null || LST_LOGIN.Count <= 0)
                {
                    MensajeLOGEdit("A", "EL LOGIN NO ES VALIDO", "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");
                    return;
                }


                //===========================================================
                // INGRESAR                                               
                //===========================================================
                iSP_CREATE_GRUPO_X_LOGIN ParametrosInput = new iSP_CREATE_GRUPO_X_LOGIN();
                ParametrosInput.ID_GRUPO = ID_GRUPO;
                ParametrosInput.NRO_USUARIO = LST_LOGIN.First().ID_USUARIO;
                ParametrosInput.NOMBRE = LST_LOGIN.First().NOMBRE;



                //===========================================================
                // LLAMADA A SERVICIO
                //===========================================================
                oSP_RETURN_STATUS ESTADO = Servicio.SP_CREATE_GRUPO_X_LOGIN(ParametrosInput);

                if (ESTADO.RETURN_VALUE == 1)
                {
                    MensajeLOGEdit("I", "LOGIN FUE INGRESADO CORRECTAMANTE", "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");
                    LEER_USUARIO(ID_GRUPO);
                    return;
                }

                if (ESTADO.RETURN_VALUE == 0)
                {
                    MensajeLOGEdit("A", "LOGIN NO FUE ACTUALIZADO", "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");
                    return;
                }

                if (ESTADO.RETURN_VALUE == -1)
                {
                    MensajeLOGEdit("A", "LOGIN YA ESTA INGRESADO", "MSG_GRUPO_INFO", "MSG_GRUPO_Alerta");
                    return;
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
        private void LEER_USUARIO(int ID_GRUPO)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                SMetodos Negocio = new SMetodos();
                List<oSP_READ_GRUPO_X_LOGIN> ListaCluster = new List<oSP_READ_GRUPO_X_LOGIN>();



                //===========================================================
                // PARAMETROS DE ENTRADA 
                //===========================================================
                iSP_READ_GRUPO_X_LOGIN ParametrosInput = new iSP_READ_GRUPO_X_LOGIN();
                ParametrosInput.ID_GRUPO = ID_GRUPO;

                //===========================================================
                // LLAMADA DEL SERVICIO                                    ==
                //===========================================================                
                ListaCluster = Negocio.SP_READ_GRUPO_X_LOGIN(ParametrosInput);


                if (ListaCluster == null)
                {
                    DibujarGrillaUsuario();
                    return;
                }
                if (ListaCluster.Count <= 0)
                {
                    DibujarGrillaUsuario();
                    return;
                }

                FuncionesGenerales.Cargar_Grilla(ListaCluster, GRDUsuario);
                V_Global().ListaUsuarios = ListaCluster;


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
                iSP_DELETE_GRUPO_X_LOGIN ParametrosInput = new iSP_DELETE_GRUPO_X_LOGIN();
                ParametrosInput.ID_GRUPO = Convert.ToInt32(TXT_ID_ELIMINA_1.Text);
                ParametrosInput.NRO_USUARIO = Convert.ToInt32(TXT_ID_ELIMINA_2.Text); 




                //===========================================================
                // LLAMADA A SERVICIO                                           
                //===========================================================
                oSP_RETURN_STATUS ObjetoRest = Servicio.SP_DELETE_GRUPO_X_LOGIN(ParametrosInput);

                if (ObjetoRest.RETURN_VALUE == 0)
                {

                    MensajeLOGEdit("A", "ELIMINACION DE LOGIN NO FUE REALIZADA", "MSG_INFO_ELIMINA", "MSG_ALERTA_ELIMINA");
                    return;
                }

                if (ObjetoRest.RETURN_VALUE == 1)
                {

                    MensajeLOGEdit("I", "ELIMINACION DE LOGIN FUE REALIZADA CORRECTAMANTE", "MSG_INFO_ELIMINA", "MSG_ALERTA_ELIMINA");
                    LEER_USUARIO(Convert.ToInt32(TXT_ID_ELIMINA_1.Text));
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
    public class GlobalesGrupoLogin
    {

        public List<oSP_READ_GRUPO> ListaGrupo { get; set; }
        public List<oSP_READ_GRUPO_X_LOGIN> ListaUsuarios { get; set; }

    }

}
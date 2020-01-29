using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ALO.Entidades;
using ALO.Servicio;
using ALO.Utilidades;

namespace ALO.WebSite.Formularios.Interfaz
{
    public partial class Interfaz : System.Web.UI.Page
    {

        static string RUTA_IMPORTAR = "~/Importar/";

        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {


                Page.Form.Attributes.Add("enctype", "multipart/form-data");
                GRDExcel.PreRender += new EventHandler(GRDExcel_PreRender);



                //===========================================================
                // POSTBACK                                               
                //===========================================================
                if (!this.IsPostBack)
                {

                    Establecer_Globales();


                    PNL_FILE.Visible = false;
                    LBL_ESTADO.Visible = false;
                    CHK_ESTADO.Visible = false;
                    LBL_TIPO_ARCHIVO.Visible = false;
                    DDL_TIPO_ARCHIVO.Visible = false;
                    LBL_TIPO_DELIMITADOR.Visible = false;
                    DDL_TIPO_DELIMITADOR.Visible = false;
                    LBL_DELIMITADOR.Visible = false;
                    TXT_DELIMITADOR.Visible = false;
                    LBL_ENCABEZADO.Visible = false;
                    CHK_ENCABEZADO.Visible = false;
                    LBL_MODIFICA_INTERFAZ.Visible = false;
                    CHK_MODIFICAR_INTERFAZ.Visible = false;
                    LBL_TipoFile.Visible = false;
                    DDL_TipoFileSystem.Visible = false;
                    LBL_EXTENSIONES.Visible = false;
                    LST_EXTENSIONES.Visible = false;

                    LBL_DESCRIPCION.Visible = false;
                    TXT_DESCRIPCION.Visible = false;
                    LBL_CODIGO_INTERFAZ.Visible = false;
                    TXT_CODIGO_INTERFAZ.Visible = false;
                    CHK_OPCION.Visible = false;
                    LBL_TIPO_CARGA.Visible = false;
                    DDL_TIPO_CARGA.Visible = false;

                    CARGAR_COMBO_CLUSTER();
                    LEER_TIPO_ARCHIVO();
                    LEER_TIPO_DELIMITADOR();
                    LEER_TIPO_FILE_SYSTEM();

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

                ViewState["GlobalesInterfaz"] = new GlobalesInterfaz();
            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// VIEWSTATE PARA VARIABLES GLOBALES
        /// </summary>
        private GlobalesInterfaz V_Global()
        {


            GlobalesInterfaz item = new GlobalesInterfaz();
            try
            {

                item = (GlobalesInterfaz)ViewState["GlobalesInterfaz"] ?? null;
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
        protected void GRDExcel_PreRender(object sender, EventArgs e)
        {
            try
            {
                GRDExcel.UseAccessibleHeader = true;
                GRDExcel.HeaderRow.TableSection = TableRowSection.TableHeader;
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
        /// LEER TIPO DE ARCHIVO
        /// </summary>
        private void LEER_TIPO_ARCHIVO()
        {
            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_TIPO_ARCHIVO> LST_REST = new List<oSP_READ_TIPO_ARCHIVO>();
                SMetodos Servicio = new SMetodos();




                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                LST_REST = Servicio.SP_READ_TIPO_ARCHIVO();



                //===========================================================
                // PASAR LISTA A COMBO 
                //===========================================================
                List<Item_Seleccion> items = LST_REST.OrderBy(p => p.ID_TIPO_ARCHIVO)
                                                     .Select(p => new Item_Seleccion { Id = p.ID_TIPO_ARCHIVO, Nombre = p.DESCRIPCION })
                                                     .ToList();


                FuncionesGenerales.CDDLCombos(items, DDL_TIPO_ARCHIVO);





            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// LEER TIPO DE FILE SYSTEM
        /// </summary>
        private void LEER_TIPO_FILE_SYSTEM()
        {
            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_TIPO_FILESYSTEM> LST_REST = new List<oSP_READ_TIPO_FILESYSTEM>();
                SMetodos Servicio = new SMetodos();




                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                LST_REST = Servicio.SP_READ_TIPO_FILESYSTEM();



                //===========================================================
                // PASAR LISTA A COMBO 
                //===========================================================
                List<Item_Seleccion> items = LST_REST.OrderBy(p => p.ID_TIPO_FILESYSTEM)
                                                     .Select(p => new Item_Seleccion { Id = p.ID_TIPO_FILESYSTEM, Nombre = p.DESCRIPCION })
                                                     .ToList();


                FuncionesGenerales.CDDLCombos(items, DDL_TipoFileSystem);





            }
            catch
            {

                throw;
            }
        }


        /// <summary>
        /// LEER TIPO DE DELIMITADOR
        /// </summary>
        private void LEER_TIPO_DELIMITADOR()
        {
            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_TIPO_DELIMITADOR> LST_REST = new List<oSP_READ_TIPO_DELIMITADOR>();
                SMetodos Servicio = new SMetodos();




                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                LST_REST = Servicio.SP_READ_TIPO_DELIMITADOR();



                //===========================================================
                // PASAR LISTA A COMBO 
                //===========================================================
                List<Item_Seleccion> items = LST_REST.OrderBy(p => p.ID_TIPO_DELIMITADOR)
                                                     .Select(p => new Item_Seleccion { Id = p.ID_TIPO_DELIMITADOR, Nombre = p.DESCRIPCION })
                                                     .ToList();


                FuncionesGenerales.CDDLCombos(items, DDL_TIPO_DELIMITADOR);





            }
            catch
            {

                throw;
            }
        }

        /// <summary>
        /// LEER TIPO DE CARGA
        /// </summary>
        private void LEER_TIPO_CARGA()
        {
            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES                                
                //===========================================================
                List<oSP_READ_TIPO_CARGA> LST_REST = new List<oSP_READ_TIPO_CARGA>();
                SMetodos Servicio = new SMetodos();




                //===========================================================
                // LLAMADA DEL SERVICIO
                //===========================================================
                LST_REST = Servicio.SP_READ_TIPO_CARGA();



                //===========================================================
                // PASAR LISTA A COMBO 
                //===========================================================
                List<Item_Seleccion> items = LST_REST.OrderBy(p => p.ID_TIPO_CARGA)
                                                     .Select(p => new Item_Seleccion { Id = p.ID_TIPO_CARGA, Nombre = p.DESCRIPCION })
                                                     .ToList();

                FuncionesGenerales.CDDLCombos(items, DDL_TIPO_CARGA);


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
                // LLENAR DATOS PREDEFINIDOS DEL COMBO                          
                //===========================================================
                if (ListaInterfazEmpresa.Count > 0)
                {
                    Lista.Add(new Item_Seleccion { Id = -1, Nombre = "SELECCIONE" });
                    Lista.Add(new Item_Seleccion { Id = 0, Nombre = "NUEVA INTERFAZ" });

                    foreach (oSP_READ_INTERFAZ_X_CLUSTER item in ListaInterfazEmpresa)
                    {
                        Lista.Add(new Item_Seleccion { Id = item.ID_INTERFAZ, Nombre = item.CODIGO_INTERFAZ });
                    }

                }
                else
                {
                    Lista.Add(new Item_Seleccion { Id = -1, Nombre = "SELECCIONE" });
                    Lista.Add(new Item_Seleccion { Id = 0, Nombre = "NUEVA INTERFAZ" });
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
        /// LEER DETALLES DE INTERFAZ 
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
                // LEER EXTENSIONES                                             
                //===========================================================
                LEER_EXTENCION(ID_INTERFAZ);


                //===========================================================
                // LEER TIPO_CARGA                                             
                //===========================================================
                LEER_TIPO_CARGA();


                //===========================================================
                // TRAER CABEZERA DE INTERFAZ                                   
                //===========================================================
                List<oSP_READ_INTERFAZ> ListaInterfaz = new List<oSP_READ_INTERFAZ>();
                ListaInterfaz = Servicio.SP_READ_INTERFAZ(new iSP_READ_INTERFAZ { ID_INTERFAZ = ID_INTERFAZ });


                if (ListaInterfaz.Count > 0)
                {
                    //CHK_ESTADO.Checked = (ListaInterfaz.First().ID_ESTADO == 0);
                    FuncionesGenerales.BuscarIdCombo(DDL_TIPO_ARCHIVO, ListaInterfaz.First().ID_TIPO_ARCHIVO);
                    FuncionesGenerales.BuscarIdCombo(DDL_TIPO_DELIMITADOR, ListaInterfaz.First().ID_TIPO_DELIMITADOR);
                    TXT_DESCRIPCION.Text = ListaInterfaz.First().DESCRIPCION;
                    TXT_CODIGO_INTERFAZ.Text = ListaInterfaz.First().CODIGO_INTERFAZ;
                    TXT_DELIMITADOR.Text = ListaInterfaz.First().CARACTER;
                    FuncionesGenerales.BuscarIdCombo(DDL_TipoFileSystem, ListaInterfaz.First().ID_TIPO_FILESYSTEM);
                    FuncionesGenerales.BuscarIdCombo(DDL_TIPO_CARGA, ListaInterfaz.First().ID_TIPO_CARGA);
                    CHK_ENCABEZADO.Checked = ListaInterfaz.First().HEADER;



                    LST_EXTENSIONES.Enabled = false;

                    if (ListaInterfaz.First().ID_TIPO_ARCHIVO == 2)
                    {

                        LBL_ENCABEZADO.Visible = true;
                        CHK_ENCABEZADO.Visible = true;

                        LBL_TIPO_DELIMITADOR.Visible = true;
                        DDL_TIPO_DELIMITADOR.Visible = true;

                        if (CHK_MODIFICAR_INTERFAZ.Checked == true)
                        {
                            DDL_TIPO_DELIMITADOR.Enabled = true;
                        }
                        else
                        {
                            DDL_TIPO_DELIMITADOR.Enabled = false;
                        }

                        if (ListaInterfaz.First().ID_TIPO_DELIMITADOR == 3)
                        {

                            LBL_DELIMITADOR.Visible = true;
                            TXT_DELIMITADOR.Visible = true;

                            if (CHK_MODIFICAR_INTERFAZ.Checked == true)
                            {
                                TXT_DELIMITADOR.Enabled = true;
                            }
                            else
                            {
                                TXT_DELIMITADOR.Enabled = false;

                            }
                        }
                        else
                        {
                            LBL_DELIMITADOR.Visible = false;
                            TXT_DELIMITADOR.Visible = false;
                            TXT_DELIMITADOR.Enabled = false;

                        }
                    }
                    else
                    {

                        LBL_ENCABEZADO.Visible = false;
                        CHK_ENCABEZADO.Visible = false;
                        LBL_TIPO_DELIMITADOR.Visible = false;
                        DDL_TIPO_DELIMITADOR.Visible = false;
                        DDL_TIPO_DELIMITADOR.Enabled = false;
                        LBL_DELIMITADOR.Visible = false;
                        TXT_DELIMITADOR.Visible = false;
                        TXT_DELIMITADOR.Enabled = false;
                    }
                    if (ListaInterfaz.First().ID_TIPO_ARCHIVO == 2 || ListaInterfaz.First().ID_TIPO_ARCHIVO == 3)
                    {
                        DDL_TipoFileSystem.Visible = true;
                        LBL_TipoFile.Visible = true;
                        DDL_TipoFileSystem.Enabled = false;
                    }
                    else
                    {
                        LBL_TipoFile.Visible = false;
                        DDL_TipoFileSystem.Visible = false;
                        DDL_TipoFileSystem.Enabled = false;

                    }
                }

                //===========================================================
                // TRAER LISTA DE DETALLE DE INTERFAZ                           
                //===========================================================
                List<oSP_READ_INTERFAZ_DETALLE> ListaDetalleInterfaz = new List<oSP_READ_INTERFAZ_DETALLE>();
                ListaDetalleInterfaz = Servicio.SP_READ_INTERFAZ_DETALLE(new iSP_READ_INTERFAZ_DETALLE { ID_INTERFAZ = ID_INTERFAZ });



                FuncionesGenerales.Cargar_Grilla(ListaDetalleInterfaz, GRDExcel);
                V_Global().ListaExcel = ListaDetalleInterfaz.ToDataSet<oSP_READ_INTERFAZ_DETALLE>().Tables[0];

                if (ListaDetalleInterfaz.Count > 0)
                {
                    LBL_Archivo.Text = "";
                }


            }
            catch
            {
                throw;
            }


        }


        /// <summary>
        /// LEER EXTENCION
        /// </summary>
        /// <param name="ID_INTERFAZ"></param>
        private void LEER_EXTENCION(int ID_INTERFAZ)
        {
            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                SMetodos Servivio = new SMetodos();


                //===========================================================
                // LISTA DE EXTENSIONES                                         
                //===========================================================
                List<oSP_READ_EXTENSION> ListaExtensiones = new List<oSP_READ_EXTENSION>();
                ListaExtensiones = Servivio.SP_READ_EXTENSION();



                //===========================================================
                // LISTA DE EXTENCIONES POR INTERFAZ                            
                //===========================================================
                List<oSP_READ_INTERFAZ_X_EXTENSION> ListaExtencionesInterfaz = new List<oSP_READ_INTERFAZ_X_EXTENSION>();
                ListaExtencionesInterfaz = Servivio.SP_READ_INTERFAZ_X_EXTENSION(new iSP_READ_INTERFAZ_X_EXTENSION { ID_INTERFAZ = ID_INTERFAZ });


                //===========================================================
                // LISTA DE EXTENCIONES POR INTERFAZ                            
                //===========================================================
                List<Item_Seleccion> Lista = new List<Item_Seleccion>();
                Lista = ListaExtensiones.OrderBy(p => p.ID_EXTENSION).Select(p => new Item_Seleccion { Id = p.ID_EXTENSION, Nombre = p.DESCRIPCION }).ToList();

                FuncionesGenerales.CDDLListbox(Lista, LST_EXTENSIONES);



                //===========================================================
                // VERIFICAR EXTENSIONES                                        
                //===========================================================
                if (ListaExtencionesInterfaz == null || ListaExtencionesInterfaz.Count <= 0)
                {
                    foreach (oSP_READ_EXTENSION item in ListaExtensiones)
                    {
                        item.CHEQUED = false;

                    }


                }
                else
                {

                    foreach (oSP_READ_INTERFAZ_X_EXTENSION item in ListaExtencionesInterfaz)
                    {

                        ListaExtensiones.Where(p => p.ID_EXTENSION == item.ID_EXTENSION).First().CHEQUED = true;
                    }

                }

                //===========================================================
                // VERIFICAR EXTENSIONES                                        
                //===========================================================
                int ID_EXTENSION = 0;
                bool CHEQUED = false;
                for (int i = 0; i < LST_EXTENSIONES.Items.Count; i++)
                {
                    ID_EXTENSION = Convert.ToInt32(LST_EXTENSIONES.Items[i].Value);
                    CHEQUED = ListaExtensiones.Where(p => p.ID_EXTENSION == ID_EXTENSION).First().CHEQUED;

                    if (CHEQUED == true)
                    {
                        LST_EXTENSIONES.Items[i].Selected = true;
                    }
                    else
                    {

                        LST_EXTENSIONES.Items[i].Selected = false;
                    }
                }








            }
            catch
            {
                throw;
            }


        }

        /// <summary>
        /// LEER INTERFAZ EXCEL
        /// </summary>
        private void LeerInterfazExcel()
        {
            try
            {

                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                List<InterfazExcel> Lista = new List<InterfazExcel>();

                Lista.Add(new InterfazExcel { NRO_CAMPO = 1, CAMPO = "ORDEN" });
                Lista.Add(new InterfazExcel { NRO_CAMPO = 2, CAMPO = "CAMPO" });
                Lista.Add(new InterfazExcel { NRO_CAMPO = 3, CAMPO = "DATO" });
                Lista.Add(new InterfazExcel { NRO_CAMPO = 4, CAMPO = "FORMATO" });
                Lista.Add(new InterfazExcel { NRO_CAMPO = 5, CAMPO = "LARGO" });
                Lista.Add(new InterfazExcel { NRO_CAMPO = 6, CAMPO = "MISCELANEOS" });

                //===========================================================
                // LISTA DE INTERFAZ                                            
                //===========================================================
                V_Global().ListaInterfaz = Lista;
                FuncionesGenerales.Cargar_Grilla(Lista, GRDInterfaz);


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
                SMetodos Servicio = new SMetodos();
                int ID_INTERFAZ = 0;

                if (DDL_INTERFAZ.Items.Count > 0)
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                }
                else
                {
                    ID_INTERFAZ = -1;
                }


                //===========================================================
                // HABILITAR PANELES SEGUN A INTERFAZ SELECCIONADA              
                //===========================================================
                if (ID_INTERFAZ > -1)
                {

                    if (ID_INTERFAZ == 0)
                    {

                        LBL_TIPO_ARCHIVO.Visible = true;
                        DDL_TIPO_ARCHIVO.Visible = true;
                        DDL_TIPO_ARCHIVO.Enabled = true;
                        LBL_TIPO_DELIMITADOR.Visible = true;
                        DDL_TIPO_DELIMITADOR.Visible = true;
                        DDL_TIPO_DELIMITADOR.Enabled = true;
                        LBL_ENCABEZADO.Visible = true;
                        CHK_ENCABEZADO.Visible = true;
                        PNL_FILE.Visible = true;
                        LBL_DESCRIPCION.Visible = true;
                        TXT_DESCRIPCION.Visible = true;
                        TXT_DESCRIPCION.Enabled = true;
                        LBL_CODIGO_INTERFAZ.Visible = true;
                        TXT_CODIGO_INTERFAZ.Visible = true;
                        TXT_CODIGO_INTERFAZ.Enabled = true;
                        CHK_OPCION.Visible = true;

                        LBL_EXTENSIONES.Visible = true;
                        LST_EXTENSIONES.Visible = true;
                        LBL_TIPO_CARGA.Visible = true;
                        DDL_TIPO_CARGA.Visible = true;
                        LBL_TipoFile.Visible = false;
                        DDL_TipoFileSystem.Visible = false;
                        CHK_OPCION.Enabled = false;
                        LBL_ESTADO.Visible = false;
                        CHK_ESTADO.Visible = false;
                        LBL_MODIFICA_INTERFAZ.Visible = false;
                        CHK_MODIFICAR_INTERFAZ.Visible = false;
                        CHK_MODIFICAR_INTERFAZ.Checked = false;
                        TXT_DESCRIPCION.Text = "";
                        TXT_CODIGO_INTERFAZ.Text = "";
                        TXT_DELIMITADOR.Text = "";
                        LBL_Archivo.Text = "";
                        CHK_ENCABEZADO.Enabled = true;
                        FuncionesGenerales.CDDLCombos(null, DDL_HOJA);


                        DDL_TIPO_ARCHIVO_SelectedIndexChanged(null, null);
                    }

                    if (ID_INTERFAZ > 0)
                    {                        

                        //===========================================================
                        // CONSULTAMOS SI LA INTERFAZ TIENE ASOCIADA UNA EJECUCION
                        //===========================================================
                        iSP_READ_EJECUCION_X_INTERFAZ ParametrosInput = new iSP_READ_EJECUCION_X_INTERFAZ();
                        ParametrosInput.ID_INTERFAZ = ID_INTERFAZ;

                        //===========================================================
                        // LLAMADA A SERVICIO
                        //===========================================================
                        List<oSP_READ_EJECUCION_X_INTERFAZ> LST_EJECUCION = Servicio.SP_READ_EJECUCION_X_INTERFAZ(ParametrosInput);

                        //===========================================================
                        // VALIDACION DE SELECCION
                        //===========================================================
                        if (LST_EJECUCION.Count > 0)
                        {
                            LBL_MODIFICA_INTERFAZ.Visible = false;
                            CHK_MODIFICAR_INTERFAZ.Visible = false;
                            CHK_MODIFICAR_INTERFAZ.Checked = false;
                            LinkbtnVerificar.Visible = false;
                            BTN_ACTUALIZAR.Visible = false;
                        }
                        else
                        {                            
                            LBL_MODIFICA_INTERFAZ.Visible = true;
                            CHK_MODIFICAR_INTERFAZ.Visible = true;
                            CHK_MODIFICAR_INTERFAZ.Checked = false;
                        }

                        LBL_TIPO_ARCHIVO.Visible = true;
                        DDL_TIPO_ARCHIVO.Visible = true;
                        LBL_TIPO_DELIMITADOR.Visible = true;
                        DDL_TIPO_DELIMITADOR.Visible = true;
                        LBL_ESTADO.Visible = true;
                        CHK_ESTADO.Visible = true;
                        
                        LBL_DESCRIPCION.Visible = true;
                        TXT_DESCRIPCION.Visible = true;
                        LBL_CODIGO_INTERFAZ.Visible = true;
                        TXT_CODIGO_INTERFAZ.Visible = true;
                        CHK_OPCION.Visible = true;
                        LBL_EXTENSIONES.Visible = true;
                        LST_EXTENSIONES.Visible = true;
                        LBL_TIPO_CARGA.Visible = true;
                        DDL_TIPO_CARGA.Visible = true;

                        LBL_ENCABEZADO.Visible = true;
                        CHK_ENCABEZADO.Visible = true;

                        PNL_FILE.Visible = false;

                        DDL_TIPO_ARCHIVO.Enabled = false;
                        DDL_TIPO_DELIMITADOR.Enabled = false;
                        TXT_DESCRIPCION.Enabled = false;
                        TXT_CODIGO_INTERFAZ.Enabled = false;
                        CHK_OPCION.Enabled = false;
                        CHK_ESTADO.Enabled = false;
                        CHK_ENCABEZADO.Enabled = false;
                        LBL_Archivo.Text = "";
                        TXT_DELIMITADOR.Text = "";
                        FuncionesGenerales.CDDLCombos(null, DDL_HOJA);


                        DDL_TIPO_ARCHIVO_SelectedIndexChanged(null, null);

                    }


                }
                else
                {

                    LBL_TIPO_ARCHIVO.Visible = false;
                    DDL_TIPO_ARCHIVO.Visible = false;
                    DDL_TIPO_ARCHIVO.Enabled = false;
                    LBL_TIPO_DELIMITADOR.Visible = false;
                    DDL_TIPO_DELIMITADOR.Visible = false;
                    DDL_TIPO_DELIMITADOR.Visible = false;
                    LBL_DELIMITADOR.Visible = false;
                    TXT_DELIMITADOR.Visible = false;
                    LBL_ENCABEZADO.Visible = false;
                    CHK_ENCABEZADO.Visible = false;
                    LBL_ESTADO.Visible = false;
                    CHK_ESTADO.Visible = false;
                    LBL_MODIFICA_INTERFAZ.Visible = false;
                    CHK_MODIFICAR_INTERFAZ.Visible = false;
                    CHK_MODIFICAR_INTERFAZ.Checked = false;
                    LBL_DESCRIPCION.Visible = false;
                    TXT_DESCRIPCION.Visible = false;
                    LBL_CODIGO_INTERFAZ.Visible = false;
                    TXT_CODIGO_INTERFAZ.Visible = false;
                    CHK_OPCION.Visible = false;

                    LBL_TipoFile.Visible = false;
                    DDL_TipoFileSystem.Visible = false;

                    LBL_EXTENSIONES.Visible = false;
                    LST_EXTENSIONES.Visible = false;
                    LBL_TIPO_CARGA.Visible = false;
                    DDL_TIPO_CARGA.Visible = false;



                    TXT_DESCRIPCION.Text = "";
                    TXT_CODIGO_INTERFAZ.Text = "";
                    LBL_Archivo.Text = "";
                    TXT_DELIMITADOR.Text = "";
                    FuncionesGenerales.CDDLCombos(null, DDL_HOJA);

                    PNL_FILE.Visible = false;
                    LinkbtnVerificar.Visible = false;
                    LinkbtnImportarDatos.Visible = false;
                    FuncionesGenerales.Cargar_Grilla(null, GRDExcel);
                    V_Global().ListaExcel = null;
                }


                LEER_DETALLE_INTERFAZ(ID_INTERFAZ);

            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }
        }

        /// <summary>
        /// AL SELECCIONAR TIPO DE ARCHIVO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_TIPO_ARCHIVO_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                LBL_TIPO_DELIMITADOR.Visible = false;
                DDL_TIPO_DELIMITADOR.Visible = false;
                LBL_DELIMITADOR.Visible = false;
                TXT_DELIMITADOR.Visible = false;
                LBL_ENCABEZADO.Visible = false;
                CHK_ENCABEZADO.Visible = false;


                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                if (DDL_TIPO_ARCHIVO.Items.Count > 0)
                {
                    int ID_TIPO_ARCHIVO = Convert.ToInt32(DDL_TIPO_ARCHIVO.SelectedValue);

                    if (ID_TIPO_ARCHIVO == 2)
                    {
                        LBL_TIPO_DELIMITADOR.Visible = true;
                        DDL_TIPO_DELIMITADOR.Visible = true;
                        LBL_DELIMITADOR.Visible = true;
                        TXT_DELIMITADOR.Visible = true;
                        LBL_ENCABEZADO.Visible = true;
                        CHK_ENCABEZADO.Visible = true;
                        DDL_TIPO_DELIMITADOR_SelectedIndexChanged(null, null);
                    }
                    else
                    {
                        LBL_TIPO_DELIMITADOR.Visible = false;
                        DDL_TIPO_DELIMITADOR.Visible = false;
                        LBL_DELIMITADOR.Visible = false;
                        TXT_DELIMITADOR.Visible = false;
                        LBL_ENCABEZADO.Visible = false;
                        CHK_ENCABEZADO.Visible = false;

                    }

                    if (ID_TIPO_ARCHIVO == 2 || ID_TIPO_ARCHIVO == 3)
                    {

                        LBL_TipoFile.Visible = true;
                        DDL_TipoFileSystem.Visible = true;
                        DDL_TipoFileSystem.Enabled = true;
                    }
                    else
                    {

                        LBL_TipoFile.Visible = false;
                        DDL_TipoFileSystem.Visible = false;
                    }






                }



            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }
        }

        /// <summary>
        /// MODIFICAR INTERFAZ 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CHK_MODIFICAR_INTERFAZ_OnCheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //=============================================================
                // DECLARACION DE VARIABLES
                //=============================================================
                SMetodos Servicio = new SMetodos();
                int ID_INTERFAZ = 0;


                //===========================================================
                // VALIDACION DE SELECCION DE INTERFAZ
                //===========================================================
                if (Convert.ToInt32(DDL_INTERFAZ.SelectedValue) <= 0)
                {
                    MensajeLOG("DEBES SELECCIONAR UNA INTERFAZ", "ERROR DE APLICACIÓN");
                    return;
                }
                else
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                }


                //===========================================================
                // DEFINIR SI SE MODIFICARA                                     
                //===========================================================
                if (CHK_MODIFICAR_INTERFAZ.Checked == true)
                {
                    DDL_TIPO_ARCHIVO.Enabled = true;
                    DDL_TIPO_DELIMITADOR.Enabled = true;
                    TXT_DESCRIPCION.Enabled = true;
                    TXT_CODIGO_INTERFAZ.Enabled = false;
                    TXT_DELIMITADOR.Enabled = true;
                    CHK_OPCION.Enabled = true;
                    PNL_FILE.Visible = true;
                    LinkbtnVerificar.Visible = true;
                    CHK_ESTADO.Enabled = true;
                    DDL_TipoFileSystem.Enabled = true;
                    LST_EXTENSIONES.Enabled = true;

                    LBL_ENCABEZADO.Enabled = true;
                    CHK_ENCABEZADO.Enabled = true;

                    //===========================================================
                    // CONSULTAMOS SI LA INTERFAZ TIENE ASOCIADA UNA EJECUCION
                    //===========================================================
                    iSP_READ_EJECUCION_X_INTERFAZ ParametrosInput = new iSP_READ_EJECUCION_X_INTERFAZ();
                    ParametrosInput.ID_INTERFAZ = ID_INTERFAZ;

                    //===========================================================
                    // LLAMADA A SERVICIO
                    //===========================================================
                    List<oSP_READ_EJECUCION_X_INTERFAZ> LST_EJECUCION = Servicio.SP_READ_EJECUCION_X_INTERFAZ(ParametrosInput);

                    //===========================================================
                    // VALIDACION DE SELECCION
                    //===========================================================
                    if (LST_EJECUCION.Count > 0)
                    {
                        BTN_ACTUALIZAR.Visible = false;
                    }
                    else
                    {
                        BTN_ACTUALIZAR.Visible = true;
                    }
                }
                else
                {
                    DDL_TIPO_ARCHIVO.Enabled = false;
                    DDL_TIPO_DELIMITADOR.Enabled = false;
                    TXT_DESCRIPCION.Enabled = false;
                    TXT_CODIGO_INTERFAZ.Enabled = false;
                    TXT_DELIMITADOR.Enabled = false;
                    PNL_FILE.Visible = false;
                    LinkbtnVerificar.Visible = false;
                    CHK_OPCION.Enabled = false;
                    CHK_OPCION.Checked = false;
                    CHK_ESTADO.Enabled = false;
                    CHK_ESTADO.Checked = false;
                    DDL_TipoFileSystem.Enabled = false;
                    LST_EXTENSIONES.Enabled = false;

                    LBL_ENCABEZADO.Enabled = false;
                    CHK_ENCABEZADO.Enabled = false;

                    BTN_ACTUALIZAR.Visible = false;

                    LEER_DETALLE_INTERFAZ(Convert.ToInt32(DDL_INTERFAZ.SelectedValue));

                }



            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }


        }

        /// <summary>
        /// AL SELECCIONAR TIPO DE DELIMITADOR
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void DDL_TIPO_DELIMITADOR_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                LBL_DELIMITADOR.Visible = false;
                TXT_DELIMITADOR.Visible = false;
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                if (DDL_TIPO_DELIMITADOR.Items.Count > 0)
                {
                    int ID_TIPO_DELIMITADOR = Convert.ToInt32(DDL_TIPO_DELIMITADOR.SelectedValue);

                    if (ID_TIPO_DELIMITADOR == 3)
                    {
                        LBL_DELIMITADOR.Visible = true;
                        TXT_DELIMITADOR.Visible = true;
                        TXT_DELIMITADOR.Enabled = true;
                    }
                }





            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }



        }

        /// <summary>
        /// CHECKED DE OPCION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void CHK_OPCION_OnCheckedChanged(object sender, EventArgs e)
        {

            try
            {

                //===========================================================
                // DEFINIR SI SE MODIFICARA                                     
                //===========================================================
                if (CHK_OPCION.Checked == true)
                {
                    TXT_CODIGO_INTERFAZ.Enabled = true;


                }
                else
                {
                    TXT_CODIGO_INTERFAZ.Enabled = false;

                }



            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }

        }

        /// <summary>
        /// MOSTRAR INTERFACES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnInterfaces_Click(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // MOSTRAR INTERFAZ                                             
                //===========================================================
                LeerInterfazExcel();
                ModalInterfaz();

            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }

        }

        /// <summary>
        /// UPLOAD EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnUploadExcel_Click(object sender, EventArgs e)
        {

            LBL_Archivo.Text = "";
            LinkbtnImportarDatos.Visible = false;
            LinkbtnVerificar.Visible = false;
            FuncionesGenerales.Cargar_Grilla(null, GRDExcel);
            FuncionesGenerales.CDDLCombos(null, DDL_HOJA);
            V_Global().ListaExcel = null;


            string FilePath = Server.MapPath(RUTA_IMPORTAR);

            try
            {


                //===========================================================
                // SE LEE EL DIRECTORIO DE EL ARCHIVO                           
                //===========================================================
                //try
                //{
                //    DirectoryInfo Directorio = new DirectoryInfo(FilePath);

                //    foreach (var fi in Directorio.GetFiles("*" + V_Global().Usuario + "*"))
                //    {
                //        File.Delete(fi.FullName);
                //    }
                //}
                //catch { }



                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================

                string filename = string.Empty;
                List<HojaExcel> Hojas = new List<HojaExcel>();



                //===========================================================
                // COMPROBAR SI EL ARCHIVO ESTA SELECCIONADO                    
                //===========================================================
                if (FileUploadToServer.HasFile)
                {
                    try
                    {



                        string[] allowdFile = { ".xls", ".xlsx" };
                        string FileExt = System.IO.Path.GetExtension(FileUploadToServer.PostedFile.FileName);
                        bool isValidFile = allowdFile.Contains(FileExt);



                        if (!isValidFile)
                        {

                            MensajeLOG("SOLO SE PERMITEN ARCHIVOS EXCEL", "SUBIR ARCHIVO");
                            return;
                        }
                        else
                        {

                            int FileSize = FileUploadToServer.PostedFile.ContentLength;
                            if (FileSize <= 31457280) // 30 MB
                            {




                                string Usuario = Globales.DATOS_COOK().ID_USUARIO.ToString() + "_";
                                filename = Path.GetFileName(Server.MapPath(FileUploadToServer.FileName));
                                string filePath = FilePath + Usuario + "_" + filename;


                                FileUploadToServer.SaveAs(filePath);
                                HojasExcel(filePath, out Hojas);


                                List<Item_Seleccion> Lista = new List<Item_Seleccion>();
                                Lista = Hojas.Select(p => new Item_Seleccion { Id = p.Hoja, Nombre = p.HojaStr }).ToList();


                                FuncionesGenerales.CDDLCombos(Lista, DDL_HOJA);

                                FileInfo FileInfo = new FileInfo(filePath);
                                LBL_Archivo.Text = FileInfo.Name;


                            }
                            else
                            {
                                MensajeLOG("ARCHIVO ADJUNTO NO PUEDE SUPERAR 30 MB!", "SUBIR ARCHIVO");
                                return;
                            }
                        }



                    }
                    catch (Exception ex)
                    {

                        throw new Exception("ADVERTENCIAS MIENTRAS SE PROCESABA ARCHIVO :" + ex.Message);
                    }
                }
                else
                {

                    MensajeLOG("FAVOR SELECCIONE UN ARCHIVO", "SUBIR ARCHIVO");
                    return;
                }


                MensajeLOG("EXCEL CARGADO CORRECTAMANTE EN DIRECTORIO", "SUBIR ARCHIVO");
            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }


        }

        /// <summary>
        /// LEER EXCEL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnLeerExcel_Click(object sender, EventArgs e)
        {

            try
            {

                //===========================================================
                // VALIDACION DE CENA                                           
                //===========================================================
                if (DDL_HOJA.Items.Count <= 0)
                {
                    MensajeLOG("ARCHIVO NO PRESENTA HOJAS", "EXCEL");
                    return;
                }

                //===========================================================
                // LEER EXCEL Y MOSTRAR DATOS EN GRILLA                         
                //===========================================================
                LinkbtnImportarDatos.Visible = false;
                LinkbtnVerificar.Visible = false;
                string Hoja = DDL_HOJA.SelectedItem.Text;
                string FilePath = Server.MapPath(RUTA_IMPORTAR + LBL_Archivo.Text);

                DataTable dt = LeerExcel(FilePath, DDL_HOJA.SelectedItem.Text, 0);

                FuncionesGenerales.Cargar_Grilla(dt, GRDExcel);
                V_Global().ListaExcel = dt;
                LinkbtnVerificar.Visible = true;


            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }

        }

        /// <summary>
        /// GRILLA PAGINACION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void GRDExcel_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GRDExcel.PageIndex = e.NewPageIndex;
                FuncionesGenerales.Cargar_Grilla(V_Global().ListaExcel, GRDExcel);


            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }


        }



        /// <summary>
        /// VERIFICAR CONTENIDO DE ARCHIVO VS INTERFAZ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnVerificar_Click(object sender, EventArgs e)
        {

            try
            {

                btnInterfaces_Click(null, null);
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                DataTable TablaComparacion = new DataTable();
                LinkbtnImportarDatos.Visible = false;

                //===========================================================
                // TABLA EXCEL                                                  
                //===========================================================
                DataTable TablaExcel = V_Global().ListaExcel;
                List<InterfazExcel> ListaInterfaz = V_Global().ListaInterfaz;

                //===========================================================
                // COMPARACION DE INTERFAZ                                      
                //===========================================================
                TablaComparacion = ComparacionInterfaz(TablaExcel, ListaInterfaz);


                //===========================================================
                // VALIDACION DE INTERFAZ                                       
                //===========================================================
                V_Global().VALIDA_INTERFAZ = true;
                foreach (DataRow Fila in TablaComparacion.Rows)
                {
                    if (Fila[4].ToString().Trim() == "X")
                    {
                        V_Global().VALIDA_INTERFAZ = false;
                        break;
                    }
                }

                //===========================================================
                // CARGAR TABLA DE COMPARACION                                  
                //===========================================================
                FuncionesGenerales.Cargar_Grilla(TablaComparacion, GRDInterfaz);


                ModalInterfaz();


                //===========================================================
                // MOSTRAR EL BOTON GUARDAR                                     
                //===========================================================
                if (V_Global().VALIDA_INTERFAZ == true)
                {

                    LinkbtnImportarDatos.Visible = true;
                    BTN_ACTUALIZAR.Visible = false;
                }
                else
                {
                    LinkbtnImportarDatos.Visible = false;
                    BTN_ACTUALIZAR.Visible = true;
                }

            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }



        }

        /// <summary>
        /// LLEVAR CONTENIDO A TABLA DE DATOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnImportarDatos_Click(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACON DE VARIABLES                                      
                //===========================================================
                int ID_CLUSTER = 0;
                int ID_INTERFAZ = 0;
                int ID_TIPO_CARGA = 0;
                int ID_TIPO_ARCHIVO = 0;
                int ID_TIPO_DELIMITADOR = 0;
                int ID_TIPO_FILESYSTEM = 0;
                bool HEADER = false;
                string CARACTER = "";
                string DESCRIPCION = "";
                string CODIGO_INTERFAZ = "";
                List<iSP_CREATE_INTERFAZ_DETALLE> DETALLES = new List<iSP_CREATE_INTERFAZ_DETALLE>();
                SMetodos Servicio = new SMetodos();
                DataTable dt;
                string FilePath = "";
                //===========================================================
                // LEVANTAR DATATABLE                                           
                //===========================================================
                if (string.IsNullOrEmpty(LBL_Archivo.Text) == false)
                {
                    FilePath = Server.MapPath(RUTA_IMPORTAR + LBL_Archivo.Text);
                    dt = LeerExcel(FilePath, DDL_HOJA.SelectedItem.Text, 1);
                }
                else
                {

                    if (V_Global().ListaExcel != null)
                    {
                        dt = V_Global().ListaExcel;
                    }
                    else
                    {
                        MensajeLOG("ESTRUCTURA DE ARCHIVO NO RECONOCIDA", "GRABACIÓN");
                    }

                }


                //===========================================================
                // CAMPAÑA                                                      
                //===========================================================
                try
                {
                    ID_CLUSTER = Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue);
                }
                catch
                {
                    MensajeLOG("CAMPAÑA NO SELECCIONADA", "GRABACIÓN");
                    return;
                }

                //===========================================================
                // INTERFAZ                                                     
                //===========================================================
                try
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                }
                catch
                {
                    MensajeLOG("INTERFAZ NO SELECCIONADA", "GRABACIÓN");
                    return;
                }

                if (ID_INTERFAZ == -1)
                {
                    MensajeLOG("DEBE SELECCIONAR LA INTERFAZ", "GRABACIÓN");
                    return;

                }

                //===========================================================
                // TIPO DE ARCHIVO                                              
                //===========================================================
                try
                {
                    ID_TIPO_ARCHIVO = Convert.ToInt32(DDL_TIPO_ARCHIVO.SelectedValue);
                }
                catch
                {
                    MensajeLOG("TIPO DE ARCHIVO SIN SELECCIONAR", "GRABACIÓN");
                    return;
                }

                //===========================================================
                // TIPO DE ARCHIVO                                              
                //===========================================================
                try
                {
                    ID_TIPO_CARGA = Convert.ToInt32(DDL_TIPO_CARGA.SelectedValue);
                }
                catch
                {
                    MensajeLOG("TIPO DE CARGA SIN SELECCIONAR", "GRABACIÓN");
                    return;
                }

                //===========================================================
                // DELIMITADOR                                                  
                //===========================================================
                if (ID_TIPO_ARCHIVO == 2)
                {


                    HEADER = CHK_ENCABEZADO.Checked;

                    try
                    {
                        ID_TIPO_DELIMITADOR = Convert.ToInt32(DDL_TIPO_DELIMITADOR.SelectedValue);
                    }
                    catch
                    {
                        MensajeLOG("TIPO DE DELIMITADOR SIN SELECCIONAR", "GRABACIÓN");
                        return;
                    }

                    if (ID_TIPO_DELIMITADOR == 0)
                    {

                        MensajeLOG("DEBE ASIGNAR UN DELIMITADOR", "GRABACIÓN");
                        return;
                    }



                    if (ID_TIPO_DELIMITADOR == 3)
                    {

                        CARACTER = TXT_DELIMITADOR.Text;

                        if (string.IsNullOrEmpty(CARACTER))
                        {
                            MensajeLOG("DEBE ASIGNAR UN DELIMITADOR", "GRABACIÓN");
                            return;
                        }
                        else
                        {
                            if (CARACTER.Length != 1)
                            {
                                MensajeLOG("EL DELIMITADOR SOLO PUEDE SER UN CARACTER", "GRABACIÓN");
                                return;
                            }

                        }


                    }
                    else
                    {
                        CARACTER = "";

                    }



                }
                else
                {
                    ID_TIPO_DELIMITADOR = 0;
                    CARACTER = "";
                    HEADER = false;
                }
                //===========================================================
                // ARCHIVOS DE TEXTO                                            
                //===========================================================
                if (ID_TIPO_ARCHIVO == 2 || ID_TIPO_ARCHIVO == 3)
                {
                    try
                    {
                        ID_TIPO_FILESYSTEM = Convert.ToInt32(DDL_TipoFileSystem.SelectedValue);
                    }
                    catch
                    {
                        MensajeLOG("TIPO DE ARCHIVO FILE SYSTEM NO SE ENCUENTRA CON DATOS", "GRABACIÓN");
                        return;
                    }

                }
                else
                {
                    ID_TIPO_FILESYSTEM = 0;
                }


                //===========================================================
                // DESCRIPCION                                                  
                //===========================================================
                DESCRIPCION = TXT_DESCRIPCION.Text;

                if (string.IsNullOrEmpty(DESCRIPCION))
                {
                    MensajeLOG("DEBE ASIGNAR UNA DESCRIPCIÓN", "GRABACIÓN");
                    return;
                }

                //===========================================================
                // CODIGO INTERFAZ                                              
                //===========================================================
                CODIGO_INTERFAZ = TXT_CODIGO_INTERFAZ.Text;

                if (string.IsNullOrEmpty(CODIGO_INTERFAZ))
                {
                    MensajeLOG("DEBE ASIGNAR UN CODIGO DE INTERFAZ", "GRABACIÓN");
                    return;
                }
                else
                {

                    string[] Array;
                    Array = CODIGO_INTERFAZ.Split(" ".ToCharArray());

                    if (Array.Count() > 1)
                    {
                        MensajeLOG("CODIGO DE INTERFAZ NO DEBE TENER ESPACIOS", "GRABACIÓN");
                        return;
                    }

                    if (CODIGO_INTERFAZ.Length > 50)
                    {
                        MensajeLOG("CODIGO DE INTERFAZ NO DEBE TENER MAS DE 50 CARACTERES", "GRABACIÓN");
                        return;
                    }

                }

                //===========================================================
                // DTERMINAR REGISTROS DE DATA                                  
                //===========================================================
                DataTable TB = V_Global().ListaExcel;

                if (TB.Rows.Count > 0)
                {
                    int Fila = 1;
                    string TIPO_DATO = "";
                    foreach (DataRow row in TB.Rows)
                    {
                        iSP_CREATE_INTERFAZ_DETALLE Entidad = new iSP_CREATE_INTERFAZ_DETALLE();



                        try
                        {

                            Entidad.ORDEN = Convert.ToInt32(row[0].ToString().Trim());

                        }
                        catch
                        {
                            MensajeLOG("NUMERO DE CAMPO DE FILA : " + Fila + " NO ES UN NUMERO", "GRABACIÓN");
                            return;
                        }

                        if (Fila != Entidad.ORDEN)
                        {
                            MensajeLOG("CAMPO DE ORDEN DE COLUMNA NO SIGUE LA NUMERACIÓN LOGICA : " + Fila + " EXCEL", "GRABACIÓN");
                            return;
                        }


                        if (!string.IsNullOrEmpty(row[1].ToString().Trim()))
                        {
                            Entidad.CAMPO = row[1].ToString().Trim();
                            //Entidad.CAMPO= Regex.Replace(Entidad.CAMPO, @"[^a-zA-Z0-9 ]+", "");
                            //Entidad.CAMPO = Entidad.CAMPO.Replace(" ", "_");

                            //transformación UNICODE
                            Entidad.CAMPO = Entidad.CAMPO.Normalize(NormalizationForm.FormD);
                            //coincide todo lo que no sean letras y números ascii o espacio
                            //y lo reemplazamos por una cadena vacía.
                            Regex reg = new Regex("[^a-zA-Z0-9 _]");
                            Entidad.CAMPO = reg.Replace(Entidad.CAMPO, "");
                            Entidad.CAMPO = Entidad.CAMPO.Replace(" ", "_");
                            Entidad.CAMPO = Entidad.CAMPO.ToUpper();



                        }
                        else
                        {
                            MensajeLOG("EL NOMBRE DEL CAMPO EN LA FILA : " + Fila + " NO DEBE ESTAR VACIO", "GRABACIÓN");
                            return;
                        }

                        try
                        {

                            if (!string.IsNullOrEmpty(row[2].ToString().Trim()))
                            {
                                TIPO_DATO = row[2].ToString().Trim();

                                switch (TIPO_DATO)
                                {
                                    case "SIN DEFINIR":
                                        Entidad.ID_TIPO_CAMPO = (int)T_DATO.SIN_DEFINIR;
                                        break;
                                    case "TEXTO":
                                        Entidad.ID_TIPO_CAMPO = (int)T_DATO.TEXTO;
                                        break;
                                    case "NUMERICO":
                                        Entidad.ID_TIPO_CAMPO = (int)T_DATO.NUMERICO;
                                        break;
                                    case "FECHA":
                                        Entidad.ID_TIPO_CAMPO = (int)T_DATO.FECHA;
                                        break;
                                    default:
                                        MensajeLOG("EL CAMPO DATO EN LA FILA : " + Fila + " DEBE SER (SIN DEFINIR, TEXTO, NUMERICO O FECHA)", "GRABACIÓN");
                                        return;
                                }
                            }
                            else
                            {
                                MensajeLOG("EL CAMPO DATO EN LA FILA : " + Fila + " NO DEBE ESTAR VACIO, DEBE SER (SIN DEFINIR, TEXTO, NUMERICO O FECHA)", "GRABACIÓN");
                                return;
                            }

                        }
                        catch
                        {
                            MensajeLOG("EL CAMPO DATO EN LA FILA : " + Fila + " NO DEBE ESTAR VACIO, DEBE SER (SIN DEFINIR, TEXTO, NUMERICO O FECHA)", "GRABACIÓN");
                            return;
                        }

                        //if (!string.IsNullOrEmpty(row[3].ToString().Trim()))
                        //{
                        Entidad.FORMATO = row[3].ToString().Trim();
                        //}
                        //else
                        //{
                        //    MensajeLOG("EL CAMPO FORMATO EN LA FILA : " + Fila + " NO DEBE ESTAR VACIO", "GRABACIÓN");
                        //    return;
                        //}

                        try
                        {

                            Entidad.LARGO = Convert.ToInt32(row[4].ToString().Trim());

                        }
                        catch
                        {
                            MensajeLOG("CAMPO LARGO DE FILA : " + Fila + " NO ES UN NUMERO", "GRABACIÓN");
                            return;
                        }

                        try
                        {

                            Entidad.MISCELANEOS = Convert.ToInt32(row[5].ToString().Trim());

                        }
                        catch
                        {
                            MensajeLOG("CAMPO MISCELANEOS DE FILA : " + Fila + " DEBE SER UN NUMERO", "GRABACIÓN");
                            return;
                        }

                        try
                        {

                            if ((Entidad.MISCELANEOS >= 0 && Entidad.MISCELANEOS <= 1) == false)
                            {

                                MensajeLOG("CAMPO MISCELANEOS DE FILA : " + Fila + " DEBE SER UN NUMERO ENTRE 0 Y 1", "GRABACIÓN");
                                return;
                            }



                        }
                        catch
                        {
                            MensajeLOG("CAMPO MISCELANEOS DE FILA : " + Fila + " DEBE SER UN NUMERO", "GRABACIÓN");
                            return;
                        }


                        if (ID_TIPO_ARCHIVO == 3)
                        {
                            if (Entidad.LARGO <= 0)
                            {
                                MensajeLOG("SI LA CONFIGURACÓN ES FIXED SU LARGO DEBE SER MAYOR A CERO : " + Fila + " EXCEL", "GRABACIÓN");
                                return;
                            }
                        }
                        if (ID_TIPO_ARCHIVO == 1 || ID_TIPO_ARCHIVO == 2)
                        {

                            if (Entidad.LARGO != 0)
                            {
                                MensajeLOG("SI LA CONFIGURACÓN ES EXCEL O DELIMITADO SU LARGO DEBE SER IGUAL CERO : " + Fila + " EXCEL", "GRABACIÓN");
                                return;
                            }
                        }



                        DETALLES.Add(Entidad);

                        Fila++;

                    }

                }
                else
                {
                    MensajeLOG("NO EXISTEN DATOS A LEVANTAR EN INTERFAZ", "GRABACIÓN");
                    return;
                }


                //===========================================================
                // LISTA DE EXTENCIONES                                         
                //===========================================================
                List<iSP_CREATE_INTERFAZ_X_EXTENSION> LISTA_EXTENSIONES = new List<iSP_CREATE_INTERFAZ_X_EXTENSION>();
                foreach (ListItem item in LST_EXTENSIONES.Items)
                {
                    if (item.Selected)
                    {
                        LISTA_EXTENSIONES.Add(new iSP_CREATE_INTERFAZ_X_EXTENSION { ID_EXTENSION = Convert.ToInt32(item.Value), ID_INTERFAZ = ID_INTERFAZ });
                    }
                }



                //===========================================================
                // CREACION DE INTERFAZ                                         
                //===========================================================
                if (ID_INTERFAZ == 0)
                {

                    iSP_CREATE_INTERFAZ CABEZERA = new iSP_CREATE_INTERFAZ();
                    CABEZERA.ID_CLUSTER = ID_CLUSTER;
                    CABEZERA.DESCRIPCION = DESCRIPCION;
                    CABEZERA.CODIGO_INTERFAZ = CODIGO_INTERFAZ;
                    CABEZERA.ID_TIPO_CARGA = ID_TIPO_CARGA;
                    CABEZERA.ID_TIPO_ARCHIVO = ID_TIPO_ARCHIVO;
                    CABEZERA.ID_TIPO_FILESYSTEM = ID_TIPO_FILESYSTEM;
                    CABEZERA.ID_TIPO_DELIMITADOR = ID_TIPO_DELIMITADOR;
                    CABEZERA.CARACTER = CARACTER;
                    CABEZERA.HEADER = HEADER;
                    CABEZERA.ID_INTERFAZ = 0;


                    oSP_CREATE_INTERFAZ OBJETO_INTERFAZ = Servicio.SP_CREATE_INTERFAZ(CABEZERA);

                    if (OBJETO_INTERFAZ == null)
                    {

                        MensajeLOG("CARGA DE INTERFAZ NO DEVOLVIO CODIGO NUMERICO DE RELACIÓN", "GRABACIÓN");
                        return;
                    }

                    if (OBJETO_INTERFAZ.ID_INTERFAZ <= 0)
                    {

                        MensajeLOG("CARGA DE INTERFAZ NO DEVOLVIO CODIGO NUMERICO DE RELACIÓN", "GRABACIÓN");
                        return;
                    }


                    //=======================================================
                    // CREACIÓN DE DETALLE
                    //=======================================================
                    foreach (iSP_CREATE_INTERFAZ_DETALLE item in DETALLES)
                    {
                        item.ID_INTERFAZ = OBJETO_INTERFAZ.ID_INTERFAZ;

                        oSP_RETURN_STATUS Retorno = Servicio.SP_CREATE_INTERFAZ_DETALLE(item);

                        if (Retorno.RETURN_VALUE == 0)
                        {

                            MensajeLOG("DETALLE DE INTERFAZ PARA EL CAMPO " + item.ORDEN + " PROVOCO ERRORES", "GRABACIÓN");
                            Servicio.SP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ(new iSP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ { ID_INTERFAZ = item.ID_INTERFAZ });
                            Servicio.SP_DELETE_INTERFAZ(new iSP_DELETE_INTERFAZ { ID_INTERFAZ = item.ID_INTERFAZ });
                            return;

                        }


                    }

                    //=======================================================
                    // CREACIÓN DE EXTENCIONES
                    //=======================================================
                    foreach (iSP_CREATE_INTERFAZ_X_EXTENSION item in LISTA_EXTENSIONES)
                    {
                        item.ID_INTERFAZ = OBJETO_INTERFAZ.ID_INTERFAZ;

                        oSP_RETURN_STATUS Retorno = Servicio.SP_CREATE_INTERFAZ_X_EXTENSION(item);

                        if (Retorno.RETURN_VALUE == 0)
                        {

                            MensajeLOG("EXTENCIONES DE INTERFAZ PARA LA EXTENCIÓN " + item.ID_EXTENSION + " PROVOCO ERRORES", "GRABACIÓN");
                            Servicio.SP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ(new iSP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ { ID_INTERFAZ = item.ID_INTERFAZ });
                            Servicio.SP_DELETE_INTERFAZ_X_EXTENSION(new iSP_DELETE_INTERFAZ_X_EXTENSION { ID_INTERFAZ = item.ID_INTERFAZ });
                            Servicio.SP_DELETE_INTERFAZ(new iSP_DELETE_INTERFAZ { ID_INTERFAZ = item.ID_INTERFAZ });
                            return;

                        }

                    }

                }

                //===========================================================
                // MODIFICAR DE INTERFAZ                                        
                //===========================================================
                if (ID_INTERFAZ > 0 && CHK_MODIFICAR_INTERFAZ.Checked == true)
                {

                    iSP_UPDATE_INTERFAZ CABEZERA = new iSP_UPDATE_INTERFAZ();
                    CABEZERA.ID_INTERFAZ = ID_INTERFAZ;
                    CABEZERA.ID_CLUSTER = ID_CLUSTER;
                    CABEZERA.DESCRIPCION = DESCRIPCION;
                    CABEZERA.CODIGO_INTERFAZ = CODIGO_INTERFAZ;
                    CABEZERA.ID_TIPO_CARGA = ID_TIPO_CARGA;
                    CABEZERA.ID_TIPO_ARCHIVO = ID_TIPO_ARCHIVO;
                    CABEZERA.ID_TIPO_FILESYSTEM = ID_TIPO_FILESYSTEM;
                    CABEZERA.ID_TIPO_DELIMITADOR = ID_TIPO_DELIMITADOR;
                    CABEZERA.CARACTER = CARACTER;
                    CABEZERA.ESTADO = CHK_ESTADO.Checked;
                    CABEZERA.OPCION = true;
                    CABEZERA.HEADER = HEADER;

                    //=======================================================
                    // ACTUALIZA CABEZERA
                    //=======================================================
                    oSP_RETURN_STATUS Retorno = Servicio.SP_UPDATE_INTERFAZ(CABEZERA);

                    if (Retorno.RETURN_VALUE == 1)
                    {

                        Servicio.SP_DELETE_DETALLE_FILE_SALIDA_X_INTERFAZ(new iSP_DELETE_DETALLE_FILE_SALIDA_X_INTERFAZ { ID_INTERFAZ = CABEZERA.ID_INTERFAZ });
                        Servicio.SP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ(new iSP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ { ID_INTERFAZ = CABEZERA.ID_INTERFAZ });
                        Servicio.SP_DELETE_INTERFAZ_X_EXTENSION(new iSP_DELETE_INTERFAZ_X_EXTENSION { ID_INTERFAZ = CABEZERA.ID_INTERFAZ });


                        foreach (iSP_CREATE_INTERFAZ_DETALLE item in DETALLES)
                        {
                            item.ID_INTERFAZ = CABEZERA.ID_INTERFAZ;

                            oSP_RETURN_STATUS RetornoDetalle = Servicio.SP_CREATE_INTERFAZ_DETALLE(item);

                            if (RetornoDetalle.RETURN_VALUE == 0)
                            {

                                MensajeLOG("DETALLE DE INTERFAZ PARA EL CAMPO " + item.ORDEN + " PROVOCO ERRORES AL ACTUALIZAR", "GRABACIÓN");
                                Servicio.SP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ(new iSP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ { ID_INTERFAZ = item.ID_INTERFAZ });
                                return;

                            }


                        }


                        foreach (iSP_CREATE_INTERFAZ_X_EXTENSION item in LISTA_EXTENSIONES)
                        {
                            item.ID_INTERFAZ = CABEZERA.ID_INTERFAZ;

                            oSP_RETURN_STATUS RetornoExtencion = Servicio.SP_CREATE_INTERFAZ_X_EXTENSION(item);

                            if (RetornoExtencion.RETURN_VALUE == 0)
                            {

                                MensajeLOG("EXTENCIONES DE INTERFAZ PARA LA EXTENCIÓN " + item.ID_EXTENSION + " PROVOCO ERRORES", "GRABACIÓN");
                                Servicio.SP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ(new iSP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ { ID_INTERFAZ = item.ID_INTERFAZ });
                                Servicio.SP_DELETE_INTERFAZ_X_EXTENSION(new iSP_DELETE_INTERFAZ_X_EXTENSION { ID_INTERFAZ = CABEZERA.ID_INTERFAZ });
                                Servicio.SP_DELETE_INTERFAZ(new iSP_DELETE_INTERFAZ { ID_INTERFAZ = item.ID_INTERFAZ });
                                return;

                            }

                        }

                    }


                }




                //===========================================================
                // ELIMINAR ARCHIVO                                             
                //===========================================================
                try
                {
                    if (!string.IsNullOrEmpty(FilePath))
                    {
                        System.IO.File.Delete(FilePath);
                    }
                }
                catch
                {
                    throw new Exception("NO ES POSIBLE ELIMINAR EL ARCHIVO EN LA RUTA: " + FilePath);
                }


                //===========================================================
                // OCULTAMOS CAMPOS Y RECARGAMOS EL DETALLE
                //===========================================================
                DDL_TIPO_ARCHIVO.Enabled = false;
                DDL_TIPO_DELIMITADOR.Enabled = false;
                TXT_DESCRIPCION.Enabled = false;
                TXT_CODIGO_INTERFAZ.Enabled = false;
                TXT_DELIMITADOR.Enabled = false;
                PNL_FILE.Visible = false;

                CHK_OPCION.Enabled = false;
                CHK_OPCION.Checked = false;
                CHK_ESTADO.Enabled = false;
                CHK_ESTADO.Checked = false;
                DDL_TipoFileSystem.Enabled = false;
                LST_EXTENSIONES.Enabled = false;
                LinkbtnImportarDatos.Visible = false;
                LinkbtnVerificar.Visible = false;
                LBL_ENCABEZADO.Enabled = false;
                CHK_ENCABEZADO.Enabled = false;
                CHK_MODIFICAR_INTERFAZ.Checked = false;


                MensajeLOG("CARGA DE DATOS INGRESADA CORRECTAMANTE", "GRABACIÓN");


            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }


        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_ACTUALIZAR_Click(object sender, EventArgs e)
        {
            try
            {

                //===========================================================
                // DECLARACON DE VARIABLES                                      
                //===========================================================
                int ID_CLUSTER = 0;
                int ID_INTERFAZ = 0;
                int ID_TIPO_CARGA = 0;
                int ID_TIPO_ARCHIVO = 0;
                int ID_TIPO_DELIMITADOR = 0;
                int ID_TIPO_FILESYSTEM = 0;
                bool HEADER = false;
                string CARACTER = "";
                string DESCRIPCION = "";
                string CODIGO_INTERFAZ = "";
                List<iSP_CREATE_INTERFAZ_DETALLE> DETALLES = new List<iSP_CREATE_INTERFAZ_DETALLE>();
                SMetodos Servicio = new SMetodos();
                DataTable dt;
                string FilePath = "";
                //===========================================================
                // LEVANTAR DATATABLE                                           
                //===========================================================
                if (string.IsNullOrEmpty(LBL_Archivo.Text) == false)
                {
                    FilePath = Server.MapPath(RUTA_IMPORTAR + LBL_Archivo.Text);
                    dt = LeerExcel(FilePath, DDL_HOJA.SelectedItem.Text, 1);
                }
                else
                {

                    if (V_Global().ListaExcel != null)
                    {
                        dt = V_Global().ListaExcel;
                    }
                    else
                    {
                        MensajeLOG("ESTRUCTURA DE ARCHIVO NO RECONOCIDA", "GRABACIÓN");
                    }

                }


                //===========================================================
                // CAMPAÑA                                                      
                //===========================================================
                try
                {
                    ID_CLUSTER = Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue);
                }
                catch
                {
                    MensajeLOG("CAMPAÑA NO SELECCIONADA", "GRABACIÓN");
                    return;
                }

                //===========================================================
                // INTERFAZ                                                     
                //===========================================================
                try
                {
                    ID_INTERFAZ = Convert.ToInt32(DDL_INTERFAZ.SelectedValue);
                }
                catch
                {
                    MensajeLOG("INTERFAZ NO SELECCIONADA", "GRABACIÓN");
                    return;
                }

                if (ID_INTERFAZ == -1)
                {
                    MensajeLOG("DEBE SELECCIONAR LA INTERFAZ", "GRABACIÓN");
                    return;

                }

                //===========================================================
                // TIPO DE ARCHIVO                                              
                //===========================================================
                try
                {
                    ID_TIPO_ARCHIVO = Convert.ToInt32(DDL_TIPO_ARCHIVO.SelectedValue);
                }
                catch
                {
                    MensajeLOG("TIPO DE ARCHIVO SIN SELECCIONAR", "GRABACIÓN");
                    return;
                }

                //===========================================================
                // TIPO DE ARCHIVO                                              
                //===========================================================
                try
                {
                    ID_TIPO_CARGA = Convert.ToInt32(DDL_TIPO_CARGA.SelectedValue);
                }
                catch
                {
                    MensajeLOG("TIPO DE CARGA SIN SELECCIONAR", "GRABACIÓN");
                    return;
                }

                //===========================================================
                // DELIMITADOR                                                  
                //===========================================================
                if (ID_TIPO_ARCHIVO == 2)
                {


                    HEADER = CHK_ENCABEZADO.Checked;

                    try
                    {
                        ID_TIPO_DELIMITADOR = Convert.ToInt32(DDL_TIPO_DELIMITADOR.SelectedValue);
                    }
                    catch
                    {
                        MensajeLOG("TIPO DE DELIMITADOR SIN SELECCIONAR", "GRABACIÓN");
                        return;
                    }

                    if (ID_TIPO_DELIMITADOR == 0)
                    {

                        MensajeLOG("DEBE ASIGNAR UN DELIMITADOR", "GRABACIÓN");
                        return;
                    }



                    if (ID_TIPO_DELIMITADOR == 3)
                    {

                        CARACTER = TXT_DELIMITADOR.Text;

                        if (string.IsNullOrEmpty(CARACTER))
                        {
                            MensajeLOG("DEBE ASIGNAR UN DELIMITADOR", "GRABACIÓN");
                            return;
                        }
                        else
                        {
                            if (CARACTER.Length != 1)
                            {
                                MensajeLOG("EL DELIMITADOR SOLO PUEDE SER UN CARACTER", "GRABACIÓN");
                                return;
                            }

                        }


                    }
                    else
                    {
                        CARACTER = "";

                    }



                }
                else
                {
                    ID_TIPO_DELIMITADOR = 0;
                    CARACTER = "";
                    HEADER = false;
                }
                //===========================================================
                // ARCHIVOS DE TEXTO                                            
                //===========================================================
                if (ID_TIPO_ARCHIVO == 2 || ID_TIPO_ARCHIVO == 3)
                {
                    try
                    {
                        ID_TIPO_FILESYSTEM = Convert.ToInt32(DDL_TipoFileSystem.SelectedValue);
                    }
                    catch
                    {
                        MensajeLOG("TIPO DE ARCHIVO FILE SYSTEM NO SE ENCUENTRA CON DATOS", "GRABACIÓN");
                        return;
                    }

                }
                else
                {
                    ID_TIPO_FILESYSTEM = 0;
                }


                //===========================================================
                // DESCRIPCION                                                  
                //===========================================================
                DESCRIPCION = TXT_DESCRIPCION.Text;

                if (string.IsNullOrEmpty(DESCRIPCION))
                {
                    MensajeLOG("DEBE ASIGNAR UNA DESCRIPCIÓN", "GRABACIÓN");
                    return;
                }

                //===========================================================
                // CODIGO INTERFAZ                                              
                //===========================================================
                CODIGO_INTERFAZ = TXT_CODIGO_INTERFAZ.Text;

                if (string.IsNullOrEmpty(CODIGO_INTERFAZ))
                {
                    MensajeLOG("DEBE ASIGNAR UN CODIGO DE INTERFAZ", "GRABACIÓN");
                    return;
                }
                else
                {

                    string[] Array;
                    Array = CODIGO_INTERFAZ.Split(" ".ToCharArray());

                    if (Array.Count() > 1)
                    {
                        MensajeLOG("CODIGO DE INTERFAZ NO DEBE TENER ESPACIOS", "GRABACIÓN");
                        return;
                    }

                    if (CODIGO_INTERFAZ.Length > 50)
                    {
                        MensajeLOG("CODIGO DE INTERFAZ NO DEBE TENER MAS DE 50 CARACTERES", "GRABACIÓN");
                        return;
                    }

                }


                //===========================================================
                // LISTA DE EXTENCIONES                                         
                //===========================================================
                List<iSP_CREATE_INTERFAZ_X_EXTENSION> LISTA_EXTENSIONES = new List<iSP_CREATE_INTERFAZ_X_EXTENSION>();
                foreach (ListItem item in LST_EXTENSIONES.Items)
                {
                    if (item.Selected)
                    {
                        LISTA_EXTENSIONES.Add(new iSP_CREATE_INTERFAZ_X_EXTENSION { ID_EXTENSION = Convert.ToInt32(item.Value), ID_INTERFAZ = ID_INTERFAZ });
                    }
                }

                //===========================================================
                // MODIFICAR DE INTERFAZ                                        
                //===========================================================
                if (ID_INTERFAZ > 0 && CHK_MODIFICAR_INTERFAZ.Checked == true)
                {

                    iSP_UPDATE_INTERFAZ CABEZERA = new iSP_UPDATE_INTERFAZ();
                    CABEZERA.ID_INTERFAZ = ID_INTERFAZ;
                    CABEZERA.ID_CLUSTER = ID_CLUSTER;
                    CABEZERA.DESCRIPCION = DESCRIPCION;
                    CABEZERA.CODIGO_INTERFAZ = CODIGO_INTERFAZ;
                    CABEZERA.ID_TIPO_CARGA = ID_TIPO_CARGA;
                    CABEZERA.ID_TIPO_ARCHIVO = ID_TIPO_ARCHIVO;
                    CABEZERA.ID_TIPO_FILESYSTEM = ID_TIPO_FILESYSTEM;
                    CABEZERA.ID_TIPO_DELIMITADOR = ID_TIPO_DELIMITADOR;
                    CABEZERA.CARACTER = CARACTER;
                    CABEZERA.ESTADO = CHK_ESTADO.Checked;
                    CABEZERA.OPCION = true;
                    CABEZERA.HEADER = HEADER;

                    //=======================================================
                    // ACTUALIZA CABEZERA
                    //=======================================================
                    oSP_RETURN_STATUS Retorno = Servicio.SP_UPDATE_INTERFAZ(CABEZERA);

                    if (Retorno.RETURN_VALUE == 1)
                    {
                        Servicio.SP_DELETE_INTERFAZ_X_EXTENSION(new iSP_DELETE_INTERFAZ_X_EXTENSION { ID_INTERFAZ = CABEZERA.ID_INTERFAZ });

                        foreach (iSP_CREATE_INTERFAZ_X_EXTENSION item in LISTA_EXTENSIONES)
                        {
                            item.ID_INTERFAZ = CABEZERA.ID_INTERFAZ;

                            oSP_RETURN_STATUS RetornoExtencion = Servicio.SP_CREATE_INTERFAZ_X_EXTENSION(item);

                            if (RetornoExtencion.RETURN_VALUE == 0)
                            {

                                MensajeLOG("EXTENCIONES DE INTERFAZ PARA LA EXTENCIÓN " + item.ID_EXTENSION + " PROVOCO ERRORES", "GRABACIÓN");
                                return;

                            }

                        }

                    }


                }

                //===========================================================
                // OCULTAMOS CAMPOS Y RECARGAMOS EL DETALLE
                //===========================================================

                DDL_TIPO_ARCHIVO.Enabled = false;
                DDL_TIPO_DELIMITADOR.Enabled = false;
                TXT_DESCRIPCION.Enabled = false;
                TXT_CODIGO_INTERFAZ.Enabled = false;
                TXT_DELIMITADOR.Enabled = false;
                PNL_FILE.Visible = false;
                LinkbtnVerificar.Visible = false;
                LinkbtnImportarDatos.Visible = false;
                CHK_OPCION.Enabled = false;
                CHK_OPCION.Checked = false;
                CHK_ESTADO.Enabled = false;
                CHK_ESTADO.Checked = false;
                DDL_TipoFileSystem.Enabled = false;
                LST_EXTENSIONES.Enabled = false;
                LBL_ENCABEZADO.Enabled = false;
                CHK_ENCABEZADO.Enabled = false;
                CHK_MODIFICAR_INTERFAZ.Checked = false;

                CHK_MODIFICAR_INTERFAZ_OnCheckedChanged(null, null);
                BTN_ACTUALIZAR.Visible = false;


                LEER_DETALLE_INTERFAZ(Convert.ToInt32(DDL_INTERFAZ.SelectedValue)); MensajeLOG("INTERFAZ ACTUALIZA CORRECTAMANTE", "GRABACIÓN");


            }
            catch (System.Exception ex)
            {
                MensajeLOG(UThrowError.MensajeThrow(ex), "ERRORES DE APLICACIÓN");
            }


        }


        /// <summary>
        /// LEER HOJA EXCEL
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="HojaExcel"></param>
        /// <returns></returns>
        private bool HojasExcel(string filePath, out List<HojaExcel> HojaExcel)
        {
            try
            {

                //---------------------------------------------------------
                // DECLARACION DE VARIABLES                                
                //---------------------------------------------------------
                OleDbConnection con = null;
                List<HojaExcel> Hojas = new List<HojaExcel>();
                HojaExcel = new List<HojaExcel>();


                //---------------------------------------------------------
                // LECTURA DE HOJAS                                        
                //---------------------------------------------------------

                try
                {

                    con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filePath + ";Extended Properties=Excel 8.0;");
                    con.Open();

                }
                catch
                {

                    con = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=Excel 12.0;");
                    con.Open();

                }


                DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);


                //---------------------------------------------------------
                // HOJAS DEL LIBRO EXCEL                                   
                //---------------------------------------------------------
                int Contador = 1;
                foreach (DataRow row in dt.Rows)
                {
                    string Hoja = row["TABLE_NAME"].ToString();

                    if (Hoja.Right(1) == "$")
                    {
                        HojaExcel Entidad = new HojaExcel();
                        Entidad.Hoja = Contador;
                        Entidad.HojaStr = Hoja;
                        Hojas.Add(Entidad);
                        Contador++;
                    }

                }

                HojaExcel = Hojas;

                con.Close();
                con = null;

                return true;

            }
            catch
            {
                throw;
            }

        }


        /// <summary>
        /// LECTURA DE EXCEL A DATASET 
        /// </summary>
        /// <param name="RutaExcel"></param>
        /// <param name="Hoja"></param>
        /// <param name="Opcion"></param>
        /// <returns></returns>
        private DataTable LeerExcel(string RutaExcel, string Hoja, int Opcion)
        {




            DataTable TB = new DataTable();

            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                string FileName = RutaExcel;
                OleDbConnection con = null;
                FileInfo InfoPath;
                DataSet ExcelDataSet = new DataSet();




                //===========================================================
                // INFORMACION DEL ARCHIVO                                      
                //===========================================================
                InfoPath = new FileInfo(FileName);


                //===========================================================
                // SI EXISTE EL ARCHIVO ESTE OPERARA                            
                //===========================================================
                if (File.Exists(FileName))
                {


                    try
                    {

                        con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + FileName + ";Extended Properties=Excel 8.0;");
                        con.Open();

                    }
                    catch
                    {
                        con = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + FileName +
                               ";Mode=ReadWrite;Extended Properties=\"Excel 12.0 Xml;HDR=NO;IMEX=1;TypeGuessRows=0;ImportMixedTypes=Text\"");

                        con.Open();

                    }


                    string Query = string.Format("SELECT  * FROM [{0}]", Hoja);
                    OleDbCommand ExcelCommand = new OleDbCommand(Query, con);

                    OleDbDataAdapter ExcelAdapter = new OleDbDataAdapter(ExcelCommand);
                    ExcelAdapter.Fill(ExcelDataSet);
                    con.Close();



                }




                con = null;
                ExcelDataSet.Tables[0].TableName = Hoja;


                //===========================================================
                // COMO EXISTEN PROBLEMAS CON EL IMEX SE DEJA LA CONEXION       
                // QUE NO VIENEN LOS ENCABEZADOS ,PERO REALMENTE LOS TOMA LA    
                // COLUMNA 1 ,ESTO AYUDA A QUE COMO ES UNA CELDA DE TEXO LOS    
                // MAXSCAN DE LAS PRIMERAS 8 FILAS NO LOS TOMARA                
                //===========================================================
                int Fila = 0;
                DataTable Tabla = ExcelDataSet.Tables[0];
                DataTable NuevaTabla = new DataTable();
                foreach (DataRow row in Tabla.Rows)
                {

                    if (Fila == 0)
                    {

                        foreach (DataColumn column in Tabla.Columns)
                        {
                            DataColumn NewColumna = new DataColumn(row[column].ToString());
                            NuevaTabla.Columns.Add(NewColumna);
                        }


                    }
                    else
                    {

                        DataRow NewFila;
                        NewFila = NuevaTabla.NewRow();
                        int Columna = 0;
                        foreach (DataColumn column in Tabla.Columns)
                        {

                            NewFila[Columna] = row[column].ToString();
                            Columna++;
                        }

                        if (!string.IsNullOrEmpty(NewFila[0].ToString()))
                        {
                            NuevaTabla.Rows.Add(NewFila);
                        }

                    }
                    Fila++;



                    if (Fila == 256 && Opcion == 0)
                    {
                        break;

                    }


                }


                return NuevaTabla;


            }
            catch
            {

                throw;

            }


        }

        /// <summary>
        /// COMPARACION DE INTERFACES 
        /// </summary>
        /// <param name="Tabla"></param>
        /// <param name="Lista"></param>
        /// <returns></returns>
        private DataTable ComparacionInterfaz(DataTable Tabla, List<InterfazExcel> Lista)
        {
            try
            {

                //---------------------------------------------------------
                // DECLARACION DE VARIABLES                                
                //---------------------------------------------------------
                DataTable DT = new DataTable();


                //---------------------------------------------------------
                // CREACION DE NUEVO DATATABLE                             
                //---------------------------------------------------------
                DT.Columns.Add(new DataColumn("NRO_CAMPO_SISTEMA", typeof(string)));
                DT.Columns.Add(new DataColumn("CAMPO_SISTEMA", typeof(string)));
                DT.Columns.Add(new DataColumn("NRO_CAMPO_ARCHIVO", typeof(string)));
                DT.Columns.Add(new DataColumn("CAMPO_ARCHIVO", typeof(string)));
                DT.Columns.Add(new DataColumn("VALIDAR", typeof(string)));




                //---------------------------------------------------------
                // LISTA DE LA INTERFAZ                                    
                //---------------------------------------------------------
                if (Tabla.Columns.Count > Lista.Count)
                {

                    foreach (DataColumn Columnas in Tabla.Columns)
                    {
                        DataRow Fila = DT.NewRow();
                        Fila["NRO_CAMPO_SISTEMA"] = "";
                        Fila["CAMPO_SISTEMA"] = "";
                        Fila["NRO_CAMPO_ARCHIVO"] = "";
                        Fila["CAMPO_ARCHIVO"] = "";
                        Fila["VALIDAR"] = "";
                        DT.Rows.Add(Fila);


                    }

                }
                else
                {

                    foreach (InterfazExcel Detalles in Lista)
                    {
                        DataRow Fila = DT.NewRow();
                        Fila["NRO_CAMPO_SISTEMA"] = "";
                        Fila["CAMPO_SISTEMA"] = "";
                        Fila["NRO_CAMPO_ARCHIVO"] = "";
                        Fila["CAMPO_ARCHIVO"] = "";
                        Fila["VALIDAR"] = "";
                        DT.Rows.Add(Fila);

                    }

                }

                //---------------------------------------------------------
                // SE INGRESAN REGISTROS DE LISTA                          
                //---------------------------------------------------------
                int Contador = 0;
                foreach (InterfazExcel Detalles in Lista)
                {
                    DT.Rows[Contador][0] = Contador + 1;
                    DT.Rows[Contador][1] = Detalles.CAMPO;
                    Contador++;

                }

                //---------------------------------------------------------
                // SE INGRESAN REGISTROS DE TABLA                          
                //---------------------------------------------------------
                Contador = 0;
                foreach (DataColumn Columnas in Tabla.Columns)
                {
                    DT.Rows[Contador][2] = Contador + 1;
                    DT.Rows[Contador][3] = Columnas.ColumnName;
                    Contador++;

                }

                //---------------------------------------------------------
                // COMPARAR IGUALDAD                                       
                //---------------------------------------------------------
                Contador = 0;
                foreach (DataColumn Columnas in Tabla.Columns)
                {
                    if (DT.Rows[Contador][1].ToString().Trim() == DT.Rows[Contador][3].ToString().Trim())
                    {
                        DT.Rows[Contador][4] = "OK";
                    }
                    else
                    {
                        DT.Rows[Contador][4] = "X";
                    }

                    Contador++;
                }


                return DT;

            }
            catch
            {
                throw;
            }


        }

    }

    [Serializable]
    public class GlobalesInterfaz
    {
        public bool VALIDA_INTERFAZ { get; set; }
        public DataTable ListaExcel { get; set; }
        public List<InterfazExcel> ListaInterfaz { get; set; }
        public List<oSP_READ_INTERFAZ_X_CLUSTER> Interfaces { get; set; }
    }
}
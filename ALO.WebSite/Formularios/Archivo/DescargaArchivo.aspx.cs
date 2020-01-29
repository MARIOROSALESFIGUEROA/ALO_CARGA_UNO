using ALO.Entidades;
using ALO.Servicio;
using ALO.Utilidades;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ALO.WebSite.Formularios.Archivo
{
    public partial class DescargaArchivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            try
            {
                TREE_ARCHIVO.Attributes.Add("onclick", "postBack()");

                //===========================================================
                // POSTBACK                                               
                //===========================================================
                if (!this.IsPostBack)
                {

                    Establecer_Globales();
                    CARGAR_COMBO_CLUSTER();
                    LEER_INTERFAZ_X_CLUSTER(0);
                    TXT_FECHA_INI.Text = DateTime.Now.ToShortDateString();
                    TXT_FECHA_FIN.Text = DateTime.Now.ToShortDateString();
                    LBL_TITULO_SELECCION.Visible = false;
                    BTN_DESCARGA.Visible = false;

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
        /// BOTON DESCAR ARCHIVOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BTN_DESCARGA_Click(object sender, EventArgs e)
        {
            try
            {
                string RUTA = "";
                string CODIGO_CLUSTER = "";
                string CODIGO_INTERFAZ = "";
                string NOMBRE_FINAL = "";

                //===================================================================
                // VALIDACION DE SELECCION DE CLUSTER
                //===================================================================
                if (Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue) >= 0)
                {
                    CODIGO_CLUSTER = DDL_SELECT_CLUSTER.SelectedItem.ToString();
                }
                else
                {
                    MensajeLOG("DEBES SELECCIONAR UN CLUSTER", "ERRORES DE APLICACIÓN");
                    return;
                }

                //===================================================================
                // VALIDACION DE SELECCION DE INTERFAZ
                //===================================================================
                if (Convert.ToInt32(DDL_INTERFAZ.SelectedValue) > 0)
                {
                    CODIGO_INTERFAZ = DDL_INTERFAZ.SelectedItem.ToString();
                }
                else
                {
                    MensajeLOG("DEBES SELECCIONAR UNA INTERFAZ", "ERRORES DE APLICACIÓN");
                    return;
                }

                //=======================================================
                // CONSTRUIMOS RUTA
                //=======================================================
                RUTA = UConfiguracion.PATH_ROOT + CODIGO_CLUSTER + @"\" + CODIGO_INTERFAZ;

                //=======================================================
                // VERIFICAMOS QUE EXISTA LA CARPETA
                //=======================================================
                if (!Directory.Exists(RUTA))
                {
                    MensajeLOG("NO EXISTEN ARCHIVOS PARA LA INTERFAZ SELECCIONADA", "ERRORES DE APLICACIÓN");
                    return;
                }


                //=======================================================
                // CREACION DE RUTA DE PASO
                //=======================================================
                string RUTA_DESTINO = Server.MapPath("~/archivoDescarga/");

                //=======================================================
                // VERIFICAMOS QUE EXISTA LA CARPETA
                //=======================================================
                if (!Directory.Exists(RUTA_DESTINO))
                {
                    Directory.CreateDirectory(RUTA_DESTINO);
                }

                //=======================================================
                // RECUPERAMOS LISTA DE ARCHIVOS SELECCIONADOS
                //=======================================================
                List<string> seleccionados = V_Global().Archivos;
                StringBuilder archivos = new StringBuilder();
                seleccionados = seleccionados.OrderBy(x => x).ToList();

                //=======================================================
                // ITERACION SOBRE ARCHIVOS SELECCIONADOS
                //=======================================================
                foreach (string item in seleccionados)
                {
                    string[] split = item.Split('\\');
                    string anterior = "";
                    if (split[1] != anterior)
                    {
                        anterior = split[1];
                        archivos.Append('"' + RUTA + @"\" + item + '"' + " ");
                    }

                }

                //=======================================================
                // NOMBRE DE ZIP DE DESCARGA
                //=======================================================
                NOMBRE_FINAL = RUTA_DESTINO + Guid.NewGuid().ToString() + ".zip";

                //=======================================================
                // SE COMPRIME LOS ARCHIVOS SELECCIONADOS
                //=======================================================
                try
                {
                    ProcessStartInfo pro = new ProcessStartInfo();
                    pro.WindowStyle = ProcessWindowStyle.Hidden;
                    pro.FileName = '"' + @"C:\Program Files\7-Zip\7zG.exe" + '"';
                    pro.Arguments = " a " + '"' + NOMBRE_FINAL + '"' + " " + archivos.ToString();
                    pro.UseShellExecute = false;
                    pro.RedirectStandardOutput = true;
                    pro.RedirectStandardError = true;

                    using (Process proc = new Process())
                    {
                        proc.StartInfo = pro;
                        proc.ErrorDataReceived += P_CaptureError;
                        proc.Start();
                        proc.WaitForExit();
                    }
                }
                catch
                {
                    throw new Exception("PROBLEMAS AL COMPRIMIR EL ARCHIVO " + NOMBRE_FINAL);
                }

                //=======================================================
                // DESCARGAR ZIP
                //=======================================================
                string Archivo = NOMBRE_FINAL;
                FileInfo FileZip = new FileInfo(Archivo);

                try
                {

                    byte[] bytes = System.IO.File.ReadAllBytes(Archivo);

                    Response.ContentType = "application/octet-stream";
                    Response.AppendHeader("Content-Disposition", "attachment;filename=" + FileZip.Name);
                    Response.OutputStream.Write(bytes, 0, bytes.Length);
                    Response.End();

                }
                catch
                {
                    //===========================================================
                    // SI ALGO SALE MAL ELIMINAMOS ARCHIVO EN LA RUTA TEMPORAL
                    //===========================================================
                    FileZip.Delete();
                }


                //===========================================================
                // ELIMINAMOS ARCHIVO EN LA RUTA TEMPORAL
                //===========================================================
                try
                {
                    FileZip.Delete();
                }
                catch
                {
                    throw new Exception("NO EXISTE EL ARCHIVO ZIP " + FileZip.Name + " EN LA RUTA TEMPORAL");
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
        /// BUSCAR ARCHIVOS
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BNT_BUSCAR_Click(object sender, EventArgs e)
        {
            try
            {
                //===================================================================
                // DECLARACION DE VARIABLES
                //===================================================================
                string CODIGO_CLUSTER = "";
                string CODIGO_INTERFAZ = "";
                DateTime FECHA_INI = new DateTime(1900, 01, 01);
                DateTime FECHA_FIN = new DateTime(1900, 01, 01);

                //===================================================================
                // VALIDACION DE SELECCION DE CLUSTER
                //===================================================================
                if (Convert.ToInt32(DDL_SELECT_CLUSTER.SelectedValue) >= 0)
                {
                    CODIGO_CLUSTER = DDL_SELECT_CLUSTER.SelectedItem.ToString();
                }
                else
                {
                    MensajeLOG("DEBES SELECCIONAR UN CLUSTER", "ERRORES DE APLICACIÓN");
                    return;
                }

                //===================================================================
                // VALIDACION DE SELECCION DE INTERFAZ
                //===================================================================
                if (Convert.ToInt32(DDL_INTERFAZ.SelectedValue) > 0)
                {
                    CODIGO_INTERFAZ = DDL_INTERFAZ.SelectedItem.ToString();
                }
                else
                {
                    MensajeLOG("DEBES SELECCIONAR UNA INTERFAZ", "ERRORES DE APLICACIÓN");
                    return;
                }

                //===================================================================
                // VALIDACION DE INGRESO DE FECHA DE INICIO
                //===================================================================
                if (!string.IsNullOrWhiteSpace(TXT_FECHA_INI.Text))
                {
                    try
                    {
                        FECHA_INI = Convert.ToDateTime(TXT_FECHA_INI.Text);
                    }
                    catch
                    {
                        MensajeLOG("FORMATO DE FECHA NO VALIDO EN PERIODO INICIO", "ERRORES DE APLICACIÓN");
                        return;
                    }
                }

                //===================================================================
                // VALIDACION DE INGRESO DE FECHA DE FIN
                //===================================================================
                if (!string.IsNullOrWhiteSpace(TXT_FECHA_FIN.Text))
                {
                    try
                    {
                        FECHA_FIN = Convert.ToDateTime(TXT_FECHA_FIN.Text);
                    }
                    catch
                    {
                        MensajeLOG("FORMATO DE FECHA NO VALIDO EN PERIODO FIN", "ERRORES DE APLICACIÓN");
                        return;
                    }
                }

                if (FECHA_INI > FECHA_FIN)
                {
                    MensajeLOG("RANGO DE FECHAS NO VALIDO", "ERRORES DE APLICACIÓN");
                    return;
                }

                //===================================================================
                // CREAMOS ARBOL 
                //===================================================================  
                CREAR_LISTA_SELECCIONADOS();
                CARGAR_ARBOL(UConfiguracion.PATH_ROOT, CODIGO_CLUSTER, CODIGO_INTERFAZ, FECHA_INI, FECHA_FIN);
                CARGAR_LISTA_SELECCIONADOS();

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
        /// CAPTURA ERRORES
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void P_CaptureError(object sender, DataReceivedEventArgs e)
        {
            try
            {
                throw new Exception("ERROR AL COMPRIMIR: " + e.Data);
            }
            catch (Exception)
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
                SMetodos Servicio = new SMetodos();
                List<oSP_READ_CLUSTER_VALIDACION> ListaCluster = new List<oSP_READ_CLUSTER_VALIDACION>();

                iSP_READ_CLUSTER_VALIDACION USUARIO = new iSP_READ_CLUSTER_VALIDACION();
                USUARIO.ID_USUARIO = ID_USURIO;


                //===========================================================
                // LLAMADA DEL SERVICIO                                    ==
                //===========================================================                
                ListaCluster = Servicio.SP_READ_CLUSTER_VALIDACION(USUARIO);


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

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// GENERA ARBOL DE DIRECTORIOS Y ARCHIVOS
        /// </summary>
        /// <param name="RUTA_ROOT"></param>
        /// <param name="CODIGO_CLUSTER"></param>
        /// <param name="CODIGO_INTERFAZ"></param>
        /// <param name="FECHA_INICIO"></param>
        /// <param name="FECHA_FIN"></param>
        private void CARGAR_ARBOL(string RUTA_ROOT, string CODIGO_CLUSTER, string CODIGO_INTERFAZ, DateTime FECHA_INICIO, DateTime FECHA_FIN)
        {
            try
            {
                //=============================================================================
                // LIMPIAMOS ARBOL
                //=============================================================================
                TREE_ARCHIVO.Nodes.Clear();

                //=============================================================================
                // DECLARACION DE VARIABLES
                //=============================================================================
                string grupo = "";
                int CONTADOR_DIRECTORIO = 0;
                int CONTADOR = 0;

                //=============================================================================
                // CREACION DE RUTA DE DIRECTORIOS
                //=============================================================================
                string RUTA = RUTA_ROOT + CODIGO_CLUSTER + @"\" + CODIGO_INTERFAZ;


                //=============================================================================
                // VALIDACION DE EXISTENCIA DE DIRECTORIOS
                //=============================================================================
                if (!Directory.Exists(RUTA))
                {
                    MensajeLOG("NO EXISTEN ARCHIVOS PARA LA INTERFAZ SELECCIONADA", "ERRORES DE APLICACIÓN");
                    return;
                }

                //=============================================================================
                // OBTENEMOS INFORMACION SOBRE LOS DIRECTORIOS
                //=============================================================================
                DirectoryInfo direc = new DirectoryInfo(RUTA);               

                //=============================================================================
                // RECORREMOS LOS DIRECTORIOS PARA CONTAR LOS QUE PASAN EL FILTRO DE FECHAS
                //=============================================================================
                foreach (var fi in direc.GetDirectories().OrderBy(fi => fi.Name))
                {
                    DateTime FECHA_DIRECTORIO = Convert.ToDateTime(fi.Name.Substring(0, 10));

                    if (FECHA_DIRECTORIO >= FECHA_INICIO && FECHA_DIRECTORIO <= FECHA_FIN)
                    {
                        CONTADOR_DIRECTORIO++;
                    }
                }

                //=============================================================================
                // GENERAMOS ARREGLO DE DIRECTORIOS 
                //=============================================================================
                DirectoryInfo[] DIRECTORIOS = new DirectoryInfo[CONTADOR_DIRECTORIO];

                //=============================================================================
                // LLENAMOS EL ARREGLO CON LOS DIRECTORIOS QUE CUMPLEN EL FILTRO DE FECHAS
                //=============================================================================
                foreach (var fi in direc.GetDirectories().OrderBy(fi => fi.Name))
                {
                    DateTime FECHA_DIRECTORIO = Convert.ToDateTime(fi.Name.Substring(0, 10));

                    if (FECHA_DIRECTORIO >= FECHA_INICIO && FECHA_DIRECTORIO <= FECHA_FIN)
                    {
                        DirectoryInfo di = new DirectoryInfo(fi.FullName);
                        DIRECTORIOS[CONTADOR] = di;
                        CONTADOR++;
                    }
                }

                //=============================================================================
                // ITERACION SOBRE DIRECTORIOS QUE CUMPLEN EL FILTRO DE FECHAS
                //=============================================================================
                foreach (var fi in DIRECTORIOS.OrderBy(fi => fi.Name))
                {
                    if (grupo != fi.Name)
                    {

                        grupo = fi.Name;

                        //=============================================================================
                        // CREAMOS EL NODO PADRE
                        //=============================================================================
                        TreeNode nodoPadre = new TreeNode(grupo, fi.Name);

                        //=============================================================================
                        // MODIFICAMOS ACCION DE SELECCION
                        //=============================================================================
                        nodoPadre.SelectAction = TreeNodeSelectAction.Expand;

                        //=============================================================================
                        // ITERACION SOBRE RUTA DE NODO PADRE PARA SABER SUS ARCHIVOS
                        //=============================================================================
                        DirectoryInfo di = new DirectoryInfo(fi.FullName);
                        foreach (var fa in di.GetFiles().OrderBy(fa => fa.Name))
                        {
                            //=============================================================================
                            // CREAMOS EL NODO HIJO
                            //=============================================================================
                            TreeNode nodoHijo = new TreeNode(fa.Name, fa.Name);

                            //=============================================================================
                            // MODIFICAMOS ACCION DE SELECCION
                            //=============================================================================                            
                            nodoHijo.SelectAction = TreeNodeSelectAction.None;

                            nodoPadre.ChildNodes.Add(nodoHijo);
                        }

                        //=============================================================================
                        // AÑADIMOS NODO PADRE AL ARBOL
                        //=============================================================================
                        TREE_ARCHIVO.Nodes.Add(nodoPadre);
                    }
                }

                //=============================================================================
                // EXPANDIMOS TODO EL ARBOL
                //=============================================================================
                TREE_ARCHIVO.ExpandAll();                
            }
            catch
            {
                throw;
            }

        }

        /// <summary>
        /// AÑADE NODOS SELECCIONADOS A LISTA 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void TREE_ARCHIVO_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            try
            {
                //============================================================================
                // CAPTURAMOS EL NODO SELECCIONADO
                //============================================================================
                TreeNode NODO = e.Node;
                bool seleccionado = NODO.Checked;

                //============================================================================
                // VALIDA SI ESTA SELECCIONADO O NO
                //============================================================================
                if (seleccionado)
                {
                    int CONTADOR = 0;
                    string ANTERIOR = "";

                    for (int i = 0; i < NODO.ChildNodes.Count; i++)
                    {
                        //============================================================================
                        // ITERACION PARA SABER SI EL NODO ESTABA AGREGADO
                        //============================================================================
                        foreach (string item in V_Global().Archivos)
                        {
                            string[] split = item.Split('\\');

                            if (split[1].Equals(NODO.ChildNodes[i].Value.ToString()))
                            {
                                ANTERIOR = item;
                                CONTADOR++;

                                TreeNode NODO_ANTERIOR = TREE_ARCHIVO.FindNode(split[0]);
                                NODO_ANTERIOR.Checked = false;
                            }
                        }

                        //============================================================================
                        // VALIDACION DE NODOS AGREGADOS
                        //============================================================================
                        if (CONTADOR == 0)
                        {
                            V_Global().Archivos.Add(NODO.Value.ToString() + @"\" + NODO.ChildNodes[i].Value.ToString());
                        }
                        else 
                        {
                            //============================================================================
                            // SI ESTA AGREGADO ELIMINAMOS EL ANTERIOR Y AGREGAMOS EL NUEVO
                            //============================================================================
                            V_Global().Archivos.Remove(ANTERIOR);
                            V_Global().Archivos.Add(NODO.Value.ToString() + @"\" + NODO.ChildNodes[i].Value.ToString());
                        }
                    }
                    
                }
                else
                {
                    //============================================================================
                    // ITERACION PARA ELIMINACION DE NODOS NO SELECCIONADOS
                    //============================================================================
                    for (int i = 0; i < NODO.ChildNodes.Count; i++)
                    {
                        V_Global().Archivos.Remove(NODO.Value.ToString() + @"\" + NODO.ChildNodes[i].Value.ToString());
                    }
                }

                //============================================================================
                // ACTUALIZA LA LISTA DE NODOS SELECCIONADOS
                //============================================================================
                CARGAR_LISTA_SELECCIONADOS();
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
        /// CARGA LISTA DE ARCHIVOS SELECCINADOS
        /// </summary>
        private void CARGAR_LISTA_SELECCIONADOS()
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES                                     
                //===========================================================
                Label etiqueta;

                List<string> seleccionados = V_Global().Archivos;

                //===========================================================
                // VALIDACION DE ITEMS EN LISTA DE SELECCIONADOS
                //===========================================================
                if (seleccionados == null || seleccionados.Count <= 0)
                {
                    seleccionados = new List<string>();
                    LBL_TITULO_SELECCION.Visible = false;
                    BTN_DESCARGA.Visible = false;
                }
                else
                {
                    LBL_TITULO_SELECCION.Visible = true;
                    BTN_DESCARGA.Visible = true;
                }

                //===========================================================
                // ITERACION PARA CONSTRUIR LISTA DE SELECCIONADOS
                //===========================================================
                foreach (string item in seleccionados)
                {
                    etiqueta = new Label();
                    etiqueta.CssClass = "col-md-12";
                    etiqueta.Text = item.Substring(20);

                    DIV_SELECCIONADOS.Controls.Add(etiqueta);
                }

            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// CARGA LISTA DE ARCHIVOS SELECCINADOS
        /// </summary>
        private void CREAR_LISTA_SELECCIONADOS()
        {
            try
            {
                //===========================================================
                // GENERA NUEVA LISTA DE SELECCIONADOS
                //===========================================================   
                V_Global().Archivos = new List<string>();

            }
            catch
            {
                throw;
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
                ViewState["GlobalesArchivo"] = new GlobalesArchivo();
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
        private GlobalesArchivo V_Global()
        {


            GlobalesArchivo item = new GlobalesArchivo();
            try
            {

                item = (GlobalesArchivo)ViewState["GlobalesArchivo"] ?? null;
                return item;
            }
            catch
            {
                return item;
            }

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
    public class GlobalesArchivo
    {
        public List<string> Archivos { get; set; }
    }
}
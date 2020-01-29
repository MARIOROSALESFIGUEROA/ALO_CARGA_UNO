using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using ALO.Entidades;
using ALO.Servicio;
using ALO.Utilidades;
using System.Threading;

namespace ALO.WebSite.ashx
{
    /// <summary>
    /// Descripción breve de FileUploadHandler
    /// </summary>
    public class FileUploadHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string FILA = context.Request["FILA"];

            string FECHA_HORA = context.Request["FECHA_HORA"];
            try
            {
                //=======================================================
                // DECLARACION DE VARIABLES
                //=======================================================    
                SMetodos Servicio = new SMetodos();
                List<oSP_READ_INTERFAZ> ListaInterfaz = new List<oSP_READ_INTERFAZ>();
                oSP_READ_INTERFAZ INTERFAZ = new oSP_READ_INTERFAZ();


                string OPCION = context.Request["OPCION"];

                //=======================================================
                // VALIDACION DE DATOS                                  
                //=======================================================                    
                string CODIGO_INTERFAZ = context.Request["CODIGO_INTERFAZ"];

                int ID_GRUPO_CARGA;
                int ID_INTERFAZ;

                try
                {
                    ID_INTERFAZ = Convert.ToInt32(context.Request["ID_INTERFAZ"]);
                }
                catch (Exception)
                {
                    ID_INTERFAZ = 0;
                }

                try
                {
                    ID_GRUPO_CARGA = Convert.ToInt32(context.Request["ID_GRUPO_CARGA"]);
                }
                catch (Exception)
                {
                    ID_GRUPO_CARGA = 0;
                }

                if (string.IsNullOrEmpty(CODIGO_INTERFAZ))
                {
                    throw new Exception("CODIGO DE INTERFAZ NO ENVIADO");
                }

                if (ID_INTERFAZ == 0)
                {
                    throw new Exception("ID DE INTERFAZ NO ENVIADO");
                }

                iSP_READ_INTERFAZ ParametrosInputInterfaz = new iSP_READ_INTERFAZ();
                ParametrosInputInterfaz.ID_INTERFAZ = ID_INTERFAZ;

                ListaInterfaz = Servicio.SP_READ_INTERFAZ(ParametrosInputInterfaz);

                if (ListaInterfaz == null && ListaInterfaz.Count <= 0)
                {
                    throw new Exception("LA INTERFAZ CON EL ID " + ID_INTERFAZ + " NO EXISTE");
                }

                INTERFAZ = ListaInterfaz.First();

                if (OPCION.Equals("I"))
                {
                    //===========================================================
                    // DECLARACION DE VARIABLES
                    //===========================================================
                    string KEY_ZIP = "RUTA_7_ZIP";// @"C:\Program Files\7-Zip\7zG.exe";
                    string KEY_ZIP_POWER_SHELL = "RUTA_POWER_SHELL";

                    oSP_READ_RUTAS_CONFIGURACION_X_LLAVE RUTA_ZIP = RUTA_CONFIGURACION(KEY_ZIP);
                    oSP_READ_RUTAS_CONFIGURACION_X_LLAVE RUTA_POWER_SHELL = RUTA_CONFIGURACION(KEY_ZIP_POWER_SHELL);


                    if (ID_GRUPO_CARGA == 0)
                    {
                        throw new Exception("GRUPO DE CARGA NO ENVIADO");
                    }
                    string RUTA = context.Server.MapPath("~/archivoCarga/");

                    //=======================================================
                    // VERIFICAMOS QUE EXISTA LA CARPETA
                    //=======================================================
                    if (!Directory.Exists(RUTA))
                    {
                        Directory.CreateDirectory(RUTA);
                    }

                    //===========================================================
                    // LECTURA DE ARCHIVOS                         
                    //===========================================================
                    if (context.Request.Files.Count > 0)
                    {

                        //=======================================================
                        // RESCATAMOS EL ARCHIVO
                        //=======================================================
                        HttpPostedFile file = context.Request.Files[0];


                        //=======================================================
                        // VERIFICAMOS LA EXTENSION DEL ARCHIVO
                        //=======================================================
                        string EXTENSION = System.IO.Path.GetExtension(file.FileName);

                        if (!EXTENSION.ToLower().Equals(".txt") && !EXTENSION.ToLower().Equals(".csv"))
                        {
                            throw new Exception("DEBE SELECCIONAR UN ARCHIVO CON EXTENSION .txt o .csv");
                        }

                        //=======================================================
                        // SETEAMOS EL NUEVO NOMBRE DEL ARCHIVO
                        //=======================================================
                        string NOMBRE_ARCHIVO = Path.GetFileNameWithoutExtension(file.FileName);

                        //Entidad.CAMPO= Regex.Replace(Entidad.CAMPO, @"[^a-zA-Z0-9 ]+", "");
                        //Entidad.CAMPO = Entidad.CAMPO.Replace(" ", "_");

                        //transformación UNICODE
                        NOMBRE_ARCHIVO = NOMBRE_ARCHIVO.Normalize(NormalizationForm.FormD);
                        //coincide todo lo que no sean letras y números ascii o espacio
                        //y lo reemplazamos por una cadena vacía.
                        Regex reg = new Regex("[^a-zA-Z0-9 _]");
                        NOMBRE_ARCHIVO = reg.Replace(NOMBRE_ARCHIVO, "");
                        NOMBRE_ARCHIVO = NOMBRE_ARCHIVO.Replace(" ", "_");
                        NOMBRE_ARCHIVO = NOMBRE_ARCHIVO.ToUpper();

                        //=======================================================
                        // GUARDAMOS EL ARCHIVO
                        //=======================================================
                        string ORIGEN = RUTA + NOMBRE_ARCHIVO + EXTENSION;
                        file.SaveAs(ORIGEN);

                        //string RUTA_DIRECTORIO = CREA_DIRECTORIO(INTERFAZ);

                        string DESTINO = RUTA + NOMBRE_ARCHIVO + ".zip";

                        //=======================================================
                        // SE DESCOMPRIME EL PROYECTO Y SE ALMACENA 
                        //=======================================================
                        try
                        {
                            ProcessStartInfo pro = new ProcessStartInfo();
                            pro.WindowStyle = ProcessWindowStyle.Hidden;
                            pro.FileName = '"' + RUTA_ZIP.RUTA + '"';
                            pro.Arguments = " a " + '"' + DESTINO + '"' + " " + '"' + ORIGEN + '"';
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
                            throw new Exception("PROBLEMAS AL COMPRIMIR EL ARCHIVO " + file.FileName);
                        }

                        //=======================================================================================
                        // DECLARACION DE VARIABLES
                        //=======================================================================================
                        oSP_READ_RUTAS_X_FTP_X_LLAVE RUTA_FTP = new oSP_READ_RUTAS_X_FTP_X_LLAVE();
                        oSP_READ_FTP_X_LLAVE FTP = new oSP_READ_FTP_X_LLAVE();

                        //=======================================================================================
                        // OBTENEMOS DATOS DEL FTP
                        //=======================================================================================
                        FTP = LEER_FTP();

                        //=======================================================================================
                        // OBTENEMOS DATOS DE LAS RUTAS
                        //=======================================================================================
                        RUTA_FTP = LEER_RUTA_FTP(FTP.ID_FTP);

                        bool ESTADO;

                        //=======================================================================================
                        // MANDAMOS EL ARCHIVO AL SFTP
                        //=======================================================================================                          
                        INPUT_FTP_JSON_ALO ObjetoInput_UP = new INPUT_FTP_JSON_ALO();
                        ObjetoInput_UP.R_FTP.KEY = FTP.KEY_SSH;
                        ObjetoInput_UP.R_FTP.SERVIDOR = FTP.SERVIDOR;
                        ObjetoInput_UP.R_FTP.USUARIO = FTP.USUARIO;
                        ObjetoInput_UP.R_FTP.PASSWORD = FTP.PASSWORD;

                        ObjetoInput_UP.R_FILE_FTP.FILE = NOMBRE_ARCHIVO + ".zip";
                        ObjetoInput_UP.R_FILE_FTP.RUTA = RUTA_FTP.RUTA;

                        ObjetoInput_UP.R_FILE_LOCAL.FILE = NOMBRE_ARCHIVO + ".zip";
                        ObjetoInput_UP.R_FILE_LOCAL.RUTA = RUTA;

                        using (UHttpFileServer HttpU = new UHttpFileServer())
                        {
                            HttpU.UploadFile(UConfiguracion.F_POST_UPLOAD_FILE, UConfiguracion.F_POST_UPLOAD_FTP, ObjetoInput_UP);
                            ESTADO = true;
                        }

                        if (ESTADO)
                        {
                            //=======================================================
                            // CONSTRUCCION DE OBJETO TABLA_CARGA
                            //=======================================================
                            iSP_CREATE_TABLA_CARGA ParametrosInputTablaCarga = new iSP_CREATE_TABLA_CARGA();
                            ParametrosInputTablaCarga.ID_INTERFAZ = ID_INTERFAZ;
                            ParametrosInputTablaCarga.COMPRESION = "ZIP";
                            ParametrosInputTablaCarga.FILENAME = NOMBRE_ARCHIVO + EXTENSION;
                            ParametrosInputTablaCarga.RUTA_FISICA = " ";
                            ParametrosInputTablaCarga.NOMBRE_TABLA = "FILE_" + CODIGO_INTERFAZ + "_" + FECHA_HORA + "_" + ID_INTERFAZ;
                            ParametrosInputTablaCarga.ID_EJECUCION = 0;

                            //=======================================================
                            // LLAMADA A SERVICIO
                            //=======================================================
                            oSP_CREATE_TABLA_CARGA TABLA_CARGA = Servicio.SP_CREATE_TABLA_CARGA(ParametrosInputTablaCarga);

                            if (TABLA_CARGA.ID_EJECUCION != 0 || TABLA_CARGA.ID_EJECUCION != -1)
                            {
                                //=======================================================
                                // CONSTRUCCION DE OBJETO DETALLE_GRUPO_CARGA
                                //=======================================================
                                iSP_CREATE_DETALLE_GRUPO_CARGA ParametrosInputGrupoCarga = new iSP_CREATE_DETALLE_GRUPO_CARGA();
                                ParametrosInputGrupoCarga.ID_EJECUCION = TABLA_CARGA.ID_EJECUCION;
                                ParametrosInputGrupoCarga.ID_GRUPO_CARGA = ID_GRUPO_CARGA;

                                //=======================================================
                                // LLAMADA A SERVICIO
                                //=======================================================
                                oSP_RETURN_STATUS ESTADO_DETALLE_GRUPO = Servicio.SP_CREATE_DETALLE_GRUPO_CARGA(ParametrosInputGrupoCarga);


                                if (ESTADO_DETALLE_GRUPO.RETURN_VALUE == 1)
                                {
                                    //=======================================================
                                    // CONSTRUCCION DE OBJETO ESTADO_INTERFAZ
                                    //=======================================================
                                    iSP_UPDATE_ESTADO_INTERFAZ ParametrosInputEstadoInterfaz = new iSP_UPDATE_ESTADO_INTERFAZ();
                                    ParametrosInputEstadoInterfaz.ID_INTERFAZ = ID_INTERFAZ;
                                    ParametrosInputEstadoInterfaz.ID_ESTADO_INTERFAZ = (int)T_ESTADO_INTERFAZ.COPIADA;

                                    //=======================================================
                                    // LLAMADA A SERVICIO
                                    //=======================================================
                                    oSP_RETURN_STATUS ESTADO_INTERFAZ = Servicio.SP_UPDATE_ESTADO_INTERFAZ(ParametrosInputEstadoInterfaz);
                                }
                            }
                            else
                            {
                                throw new Exception("NO SE A GENERADO EL PROCESO");
                            }

                            //===============================================================================
                            // ACTUALIZACION DE CANTIDAD DE REGISTROS 
                            //===============================================================================

                            int CONTADOR = 0;
                            using (StreamReader sr = new StreamReader(ORIGEN, System.Text.Encoding.Default))
                            {
                                if (INTERFAZ.HEADER)
                                {
                                    sr.ReadLine();
                                }

                                string line = String.Empty;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    CONTADOR++;
                                }
                            }

                            iSP_UPDATE_ROW_EJECUCION ParametrosInputRow = new iSP_UPDATE_ROW_EJECUCION();
                            ParametrosInputRow.ID_EJECUCION = TABLA_CARGA.ID_EJECUCION;
                            ParametrosInputRow.ROW_TOTAL = CONTADOR;

                            Servicio.SP_UPDATE_ROW_EJECUCION(ParametrosInputRow);


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

                            //===========================================================
                            // ELIMINAMOS ARCHIVO EN LA RUTA TEMPORAL
                            //===========================================================
                            try
                            {
                                FileInfo INFO = new FileInfo(ORIGEN);
                                INFO.Delete();
                            }
                            catch
                            {
                                throw new Exception("NO EXISTE EL ARCHIVO EN LA RUTA TEMPORAL: " + ORIGEN);
                            }

                            //===========================================================
                            // ELIMINAMOS ARCHIVO EN LA RUTA TEMPORAL
                            //===========================================================
                            try
                            {
                                FileInfo INFO = new FileInfo(DESTINO);
                                INFO.Delete();
                            }
                            catch
                            {
                                throw new Exception("NO EXISTE EL ARCHIVO EN LA RUTA TEMPORAL: " + DESTINO);
                            }
                        }
                        else
                        {
                            throw new Exception("NO SE A GUARDADO EL ARCHIVO " + NOMBRE_ARCHIVO + " EN LA RUTA DE RESPALDO ");
                        }


                        context.Response.ContentType = "text/plain";
                        context.Response.Write("OK|" + FILA + "|" + "ARCHIVO SUBIDO EXITOSAMANTE.");

                    }
                }


            }
            catch (Exception e)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write("ERROR|" + FILA + "|" + e.Message);
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

        private oSP_READ_RUTAS_CONFIGURACION_X_LLAVE RUTA_CONFIGURACION(string LLAVE_RUTA)
        {
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES
                //===========================================================
                SMetodos Servicio = new SMetodos();
                List<oSP_READ_RUTAS_CONFIGURACION_X_LLAVE> ListaRutas = new List<oSP_READ_RUTAS_CONFIGURACION_X_LLAVE>();
                oSP_READ_RUTAS_CONFIGURACION_X_LLAVE RUTA = new oSP_READ_RUTAS_CONFIGURACION_X_LLAVE();

                //===========================================================
                // CONSTRUCCION DE OBJETO 
                //===========================================================
                iSP_READ_RUTAS_CONFIGURACION_X_LLAVE ParametrosInput = new iSP_READ_RUTAS_CONFIGURACION_X_LLAVE();
                ParametrosInput.LLAVE = LLAVE_RUTA;


                //===========================================================
                // LLAMADA A SERVICIO
                //===========================================================
                ListaRutas = Servicio.SP_READ_RUTAS_CONFIGURACION_X_LLAVE(ParametrosInput);


                //===========================================================
                // VALIDACION DE RECEPCION
                //===========================================================
                if (ListaRutas == null && ListaRutas.Count <= 0)
                {
                    throw new Exception("LA LLAVE " + LLAVE_RUTA + " NO ARROJO RESULTADOS");
                }

                RUTA = ListaRutas.First();

                return RUTA;

            }
            catch
            {
                throw;
            }
        }

        private oSP_READ_FTP_X_LLAVE LEER_FTP()
        {

            //=======================================================================================
            // DECLARACION DE VARIABLES
            //=======================================================================================
            SMetodos Servicio = new SMetodos();
            List<oSP_READ_FTP_X_LLAVE> LISTA_FTP = new List<oSP_READ_FTP_X_LLAVE>();
            oSP_READ_FTP_X_LLAVE FTP = new oSP_READ_FTP_X_LLAVE();

            try
            {

                //=======================================================================================
                // CONSTRUCCION DE OBJETO
                //=======================================================================================
                iSP_READ_FTP_X_LLAVE ParametrosInput = new iSP_READ_FTP_X_LLAVE();
                ParametrosInput.LLAVE = "FTP_APL";

                //=======================================================================================
                // LLAMADA A SERVICIO
                //=======================================================================================
                LISTA_FTP = Servicio.SP_READ_FTP_X_LLAVE(ParametrosInput);

                //=======================================================================================
                // VALIDACION DE OBTENSION DE DATOS
                //=======================================================================================
                if (LISTA_FTP == null || LISTA_FTP.Count <= 0)
                {
                    throw new Exception("NO EXISTE CONFIGURACION DE SFTP");
                }

                //=======================================================================================
                // OBTENEMOS EL PRIMERN VALOR
                //=======================================================================================
                FTP = LISTA_FTP.First();

                return FTP;
            }
            catch
            {
                throw;
            }
        }

        private oSP_READ_RUTAS_X_FTP_X_LLAVE LEER_RUTA_FTP(int ID_FTP)
        {
            //=======================================================================================
            // DECLARACION DE VARIABLES
            //=======================================================================================
            SMetodos Servicio = new SMetodos();
            List<oSP_READ_RUTAS_X_FTP_X_LLAVE> LISTA_RUTA_FTP = new List<oSP_READ_RUTAS_X_FTP_X_LLAVE>();
            oSP_READ_RUTAS_X_FTP_X_LLAVE RUTA_FTP = new oSP_READ_RUTAS_X_FTP_X_LLAVE();

            try
            {

                //=======================================================================================
                // CONSTRUCCION DE OBJETO    
                //=======================================================================================
                iSP_READ_RUTAS_X_FTP_X_LLAVE ParametrosInput = new iSP_READ_RUTAS_X_FTP_X_LLAVE();
                ParametrosInput.ID_FTP = ID_FTP;
                ParametrosInput.LLAVE = "CAR_ARCHI";


                //=======================================================================================
                // LLAMADA A SERVICIO
                //=======================================================================================
                LISTA_RUTA_FTP = Servicio.SP_READ_RUTAS_X_FTP_X_LLAVE(ParametrosInput);


                //=======================================================================================
                // VALIDACION DE OBTENSION DE DATOS
                //=======================================================================================
                if (LISTA_RUTA_FTP == null || LISTA_RUTA_FTP.Count <= 0)
                {
                    throw new Exception("NO EXISTE CONFIGURACION DE SFTP");
                }

                RUTA_FTP = LISTA_RUTA_FTP.First();

                return RUTA_FTP;
            }
            catch
            {
                throw;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
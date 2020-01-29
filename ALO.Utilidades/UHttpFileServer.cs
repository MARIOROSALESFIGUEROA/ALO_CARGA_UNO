using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ALO.Entidades;
using System.IO;
using System.Net;
using System.IO.Compression;

namespace ALO.Utilidades
{
    public class UHttpFileServer : IDisposable
    {

        /// <summary>
        /// DESTRUCTOR
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// SUBIR ARCHIVO VIA FTP
        /// </summary>
        /// <param name="URL_1"></param>
        /// <param name="URL_2"></param>
        /// <param name="ObjetoInput"></param>
        public void UploadFile(string URL_1, string URL_2, INPUT_FTP_JSON_ALO ObjetoInput)
        {
            try
            {


                //=============================================================
                // DECLARACION DE VARIABLES
                //=============================================================
                string JsonReturn;
                string Token = "";






                //=============================================================
                // VERIFICAR CARPETA                                    
                //=============================================================
                if (Directory.Exists(ObjetoInput.R_FILE_LOCAL.RUTA) == false)
                {
                    throw new Exception("RUTA DE CARPETA NO EXISTE");

                }

                //=============================================================
                // COMBINAR RUTAS                             
                //=============================================================
                string[] paths = { ObjetoInput.R_FILE_LOCAL.RUTA, ObjetoInput.R_FILE_LOCAL.FILE };
                string LocalFilename = Path.Combine(paths);




                //=============================================================
                // SE PREPARA OBJETO PARA SUBIR ARCHIVO
                //=============================================================
                using (WebClient Cliente = new WebClient())
                {

                    Cliente.Proxy = null;
                    Cliente.Headers[HttpRequestHeader.AcceptEncoding] = "gzip";
                    byte[] ResponseArray = Cliente.UploadFile(URL_1, LocalFilename);
                    byte[] ReturnByte = Decompress(ResponseArray);

                    JsonReturn = System.Text.Encoding.ASCII.GetString(ReturnByte);



                }


                //=============================================================
                // SE DEBE DESERIALIZAR RESULTADOS                           
                //=============================================================
                RETURN_JSON_APL Retorno = new RETURN_JSON_APL();
                using (UObjetoJson ObjetoRetorno = new UObjetoJson())
                {
                    Retorno = ObjetoRetorno.Deserialize<RETURN_JSON_APL>(JsonReturn);

                }

                //=============================================================
                // COMPROBAR LA EJECUCION                                    
                //=============================================================
                int ESTADO = Retorno.HEADER.ESTADO;

                if (ESTADO == 1)
                {


                    Mensaje Objeto = Retorno.RESULT_HTTP.DETALLES;
                    Token = Objeto.MSG;

                }
                else
                {

                    throw new Exception(Retorno.ERRORES.Mensaje);

                }


                //=============================================================
                // REEMPLAZAR OBJETO DE TOKEM                                        
                //=============================================================
                FileInfo InfoFile = new FileInfo(LocalFilename);
                string NombreFile = NameFile(LocalFilename);
                ObjetoInput.R_FILE_LOCAL.FILE = InfoFile.Name.Replace(NombreFile, Token);



                //=============================================================
                // SI EXISTE TOKEN ENTONCES DEBEMOS INVOKAR EL SEGUNDO
                // METODO CON LOS PARAMETROS             
                //=============================================================
                string Json;
                using (UObjetoJson ObjetoParametros = new UObjetoJson())
                {
                    Json = ObjetoParametros.Serialize(ObjetoInput);
                }


                //=============================================================
                // DATOS JSON EN URL                                         
                //=============================================================
                Json = "json=" + Json;



                //=============================================================
                // DATOS JSON EN URL                                         ==
                //=============================================================
                byte[] data = Encoding.ASCII.GetBytes(Json);




                //=============================================================
                // SERVICIO RESTFUL                                          ==
                //=============================================================
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL_2);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = data.Length;
                myRequest.Accept = "application/json";
                myRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");


                myRequest.AllowAutoRedirect = false;
                myRequest.KeepAlive = false;
                myRequest.ProtocolVersion = HttpVersion.Version11;

                myRequest.Timeout = -1;
                myRequest.ReadWriteTimeout = 10000;
                myRequest.Proxy = null;
                myRequest.ServicePoint.ConnectionLimit = 1000000;


                //=============================================================
                // PASAR POST
                //=============================================================
                using (var stream = myRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }




                //=============================================================
                // RESCATO VALORES                                           ==
                //=============================================================
                JsonReturn = "";

                using (var resp = (HttpWebResponse)myRequest.GetResponse())
                {
                    using (Stream Str = resp.GetResponseStream())
                    {


                        Stream Compresion = Str;

                        if (resp.ContentEncoding.ToLower().Contains("gzip"))
                        {
                            Compresion = new GZipStream(Compresion, CompressionMode.Decompress);
                        }
                        else
                        {
                            if (resp.ContentEncoding.ToLower().Contains("deflate"))
                            {
                                Compresion = new DeflateStream(Compresion, CompressionMode.Decompress);
                            }
                        }


                        StreamReader rd = new StreamReader(Compresion);
                        JsonReturn = rd.ReadToEnd();
                        Str.Close();
                    }
                    resp.Close();
                }


                myRequest = null;


                //=============================================================
                // SE DEBE DESERIALIZAR RESULTADOS                           ==
                //=============================================================
                using (UObjetoJson ObjetoRetorno = new UObjetoJson())
                {
                    Retorno = ObjetoRetorno.Deserialize<RETURN_JSON_APL>(JsonReturn);

                }


                ESTADO = Retorno.HEADER.ESTADO;

                if (ESTADO == 1)
                {

                    Mensaje Objeto = Retorno.RESULT_HTTP.DETALLES;
                    Console.WriteLine(Objeto.MSG);


                }
                else
                {

                    throw new Exception(Retorno.ERRORES.Mensaje);

                }

            }
            catch
            {
                throw;
            }



        }


        /// <summary>
        /// ELIMINAR ARCHIVO FTP
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="ObjetoInput"></param>
        public void DeleteFile(string URL, INPUT_FTP_JSON_ALO ObjetoInput)
        {
            try
            {


                //=============================================================
                // DECLARACION DE VARIABLES
                //=============================================================
                string JsonReturn;
                RETURN_JSON_APL Retorno = new RETURN_JSON_APL();
                int ESTADO = 0;


                //=============================================================
                // SI EXISTE TOKEN ENTONCES DEBEMOS INVOKAR EL SEGUNDO
                // METODO CON LOS PARAMETROS             
                //=============================================================
                string Json;
                using (UObjetoJson ObjetoParametros = new UObjetoJson())
                {
                    Json = ObjetoParametros.Serialize(ObjetoInput);
                }



                //=============================================================
                // DATOS JSON EN URL                                         ==
                //=============================================================
                Json = "json=" + Json;
                byte[] data = Encoding.ASCII.GetBytes(Json);




                //=============================================================
                // SERVICIO RESTFUL                                          ==
                //=============================================================
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = data.Length;
                myRequest.Accept = "application/json";
                myRequest.Headers.Add(HttpRequestHeader.AcceptEncoding, "gzip, deflate");


                myRequest.AllowAutoRedirect = false;
                myRequest.KeepAlive = false;
                myRequest.ProtocolVersion = HttpVersion.Version11;

                myRequest.Timeout = -1;
                myRequest.ReadWriteTimeout = 10000;
                myRequest.Proxy = null;
                myRequest.ServicePoint.ConnectionLimit = 1000000;


                //=============================================================
                // PASAR POST
                //=============================================================
                using (var stream = myRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }


                //=============================================================
                // RESCATO VALORES                                           ==
                //=============================================================
                JsonReturn = "";

                using (var resp = (HttpWebResponse)myRequest.GetResponse())
                {
                    using (Stream Str = resp.GetResponseStream())
                    {


                        Stream Compresion = Str;

                        if (resp.ContentEncoding.ToLower().Contains("gzip"))
                        {
                            Compresion = new GZipStream(Compresion, CompressionMode.Decompress);
                        }
                        else
                        {
                            if (resp.ContentEncoding.ToLower().Contains("deflate"))
                            {
                                Compresion = new DeflateStream(Compresion, CompressionMode.Decompress);
                            }
                        }


                        StreamReader rd = new StreamReader(Compresion);
                        JsonReturn = rd.ReadToEnd();
                        Str.Close();
                    }
                    resp.Close();
                }


                myRequest = null;


                //=============================================================
                // SE DEBE DESERIALIZAR RESULTADOS                           ==
                //=============================================================
                using (UObjetoJson ObjetoRetorno = new UObjetoJson())
                {
                    Retorno = ObjetoRetorno.Deserialize<RETURN_JSON_APL>(JsonReturn);

                }


                ESTADO = Retorno.HEADER.ESTADO;

                if (ESTADO == 1)
                {


                    Mensaje Objeto = Retorno.RESULT_HTTP.DETALLES;
                    Console.WriteLine(Objeto.MSG);


                }
                else
                {

                    throw new Exception(Retorno.ERRORES.Mensaje);

                }










            }
            catch
            {
                throw;
            }



        }

        /// <summary>
        /// DESCARGAR ARCHIVO
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="ObjetoInput"></param>
        /// <returns></returns>
        public void DownloadFile(string URL, INPUT_FTP_JSON_ALO ObjetoInput)
        {

            try
            {


                //=============================================================
                // DECLARACION DE VARIABLES
                //=============================================================
                string Json;
                using (UObjetoJson ObjetoParametros = new UObjetoJson())
                {
                    Json = ObjetoParametros.Serialize(ObjetoInput);
                }

                //=============================================================
                // DATOS JSON EN URL                                         
                //=============================================================
                Json = "json=" + Json;
                byte[] data = Encoding.ASCII.GetBytes(Json);


                //=============================================================
                // VERIFICAR CARPETA                                    
                //=============================================================
                if (Directory.Exists(ObjetoInput.R_FILE_LOCAL.RUTA) == false)
                {
                    throw new Exception("RUTA DE CARPETA NO EXISTE");

                }

                //=============================================================
                // COMBINAR RUTAS                             
                //=============================================================
                string[] paths = { ObjetoInput.R_FILE_LOCAL.RUTA, ObjetoInput.R_FILE_LOCAL.FILE };
                string LocalFilename = Path.Combine(paths);



                //=============================================================
                // DECLARACION DE VARIABLES                            
                //=============================================================
                Stream LocalStream = null;
                int BytesProcessed = 0;


                //=============================================================
                // SERVICIO RESTFUL                                          
                //=============================================================
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(URL);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = data.Length;
                myRequest.Accept = "application/json";


                myRequest.AllowAutoRedirect = false;
                myRequest.KeepAlive = false;
                myRequest.ProtocolVersion = HttpVersion.Version11;

                myRequest.Timeout = -1;
                myRequest.ReadWriteTimeout = 10000;
                myRequest.Proxy = null;
                myRequest.ServicePoint.ConnectionLimit = 1000000;


                //=============================================================
                // PASAR POST
                //=============================================================
                using (var stream = myRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }


                //=============================================================
                // RESCATO VALORES                                           ==
                //=============================================================
                using (HttpWebResponse resp = (HttpWebResponse)myRequest.GetResponse())
                {


                    Stream RemoteStream = resp.GetResponseStream();



                    LocalStream = File.Create(LocalFilename);
                    byte[] buffer = new byte[1024];
                    int bytesRead;


                    do
                    {

                        bytesRead = RemoteStream.Read(buffer, 0, buffer.Length);

                        LocalStream.Write(buffer, 0, bytesRead);

                        BytesProcessed += bytesRead;
                    } while (bytesRead > 0);



                    LocalStream.Close();
                    RemoteStream.Close();
                    resp.Close();
                }


                myRequest = null;





            }
            catch
            {
                throw;
            }



        }

        /// <summary>
        /// DESCOMPRIMIR DATOS ZIP
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static byte[] Decompress(byte[] data)
        {
            using (var compressedStream = new MemoryStream(data))
            using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
            using (var resultStream = new MemoryStream())
            {
                zipStream.CopyTo(resultStream);
                return resultStream.ToArray();
            }
        }

        /// <summary>
        /// NOMBRE DE ARCHIVO
        /// </summary>
        /// <param name="FullPath"></param>
        /// <returns></returns>
        private string NameFile(string FullPath)
        {
            try
            {

                FileInfo FILE_EXE = new FileInfo(FullPath);


                char Separador = Convert.ToChar(".");
                string[] PathSplit = FILE_EXE.Name.Split(Separador);



                if (PathSplit.Length > 1)
                {

                    return PathSplit[0].ToString();

                }
                else
                {

                    throw new Exception("NO SE PUDO DETERMINAR NOMBRE DE ARCHIVO");
                }


            }
            catch
            {
                throw;
            }

        }
    }
}

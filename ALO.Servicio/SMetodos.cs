using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ALO.Entidades;
using ALO.Utilidades;

namespace ALO.Servicio
{
    public class SMetodos
    {
        string SISTEMA = "ALO_CARGA";

        /// <summary>
        /// LECTURA DE METODOS RESTSP_UPDATE_ESTADO_PROCESO
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_VALIDATE_USUARIO(iSP_VALIDATE_USUARIO Input)
        {


            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_VALIDATE_USUARIO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_CLUSTER_X_GRUPO> SP_READ_CLUSTER_X_GRUPO(iSP_READ_CLUSTER_X_GRUPO Input)
        {


            List<oSP_READ_CLUSTER_X_GRUPO> ListaRest = new List<oSP_READ_CLUSTER_X_GRUPO>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_CLUSTER_X_GRUPO>("SP_READ_CLUSTER_X_GRUPO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_CLUSTER_X_GRUPO>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_USUARIO_X_LOGIN> SP_READ_USUARIO_X_LOGIN(iSP_READ_USUARIO_X_LOGIN Input)
        {


            List<oSP_READ_USUARIO_X_LOGIN> ListaRest = new List<oSP_READ_USUARIO_X_LOGIN>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_USUARIO_X_LOGIN>("SP_READ_USUARIO_X_LOGIN", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_USUARIO_X_LOGIN>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_PASSWORD(iSP_UPDATE_PASSWORD Input)
        {


            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_PASSWORD", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_INTERFAZ_X_CLUSTER> SP_READ_INTERFAZ_X_CLUSTER(iSP_READ_INTERFAZ_X_CLUSTER Input)
        {
            List<oSP_READ_INTERFAZ_X_CLUSTER> ListaRest = new List<oSP_READ_INTERFAZ_X_CLUSTER>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_INTERFAZ_X_CLUSTER>("SP_READ_INTERFAZ_X_CLUSTER", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_INTERFAZ_X_CLUSTER>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_INTERFAZ> SP_READ_INTERFAZ(iSP_READ_INTERFAZ Input)
        {
            List<oSP_READ_INTERFAZ> ListaRest = new List<oSP_READ_INTERFAZ>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_INTERFAZ>("SP_READ_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_INTERFAZ>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_INTERFAZ_DETALLE> SP_READ_INTERFAZ_DETALLE(iSP_READ_INTERFAZ_DETALLE Input)
        {
            List<oSP_READ_INTERFAZ_DETALLE> ListaRest = new List<oSP_READ_INTERFAZ_DETALLE>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();            

                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_INTERFAZ_DETALLE>("SP_READ_INTERFAZ_DETALLE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_INTERFAZ_DETALLE>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <returns></returns>
        public List<oSP_READ_EXTENSION> SP_READ_EXTENSION()
        {
            List<oSP_READ_EXTENSION> ListaRest = new List<oSP_READ_EXTENSION>();

            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_EXTENSION>("SP_READ_EXTENSION", SISTEMA, new object(), new object());


                //===========================================================
                // EVALUACIÓN DE CABEZERA 
                //===========================================================
                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_EXTENSION>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_INTERFAZ_X_EXTENSION> SP_READ_INTERFAZ_X_EXTENSION(iSP_READ_INTERFAZ_X_EXTENSION Input)
        {
            List<oSP_READ_INTERFAZ_X_EXTENSION> ListaRest = new List<oSP_READ_INTERFAZ_X_EXTENSION>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_INTERFAZ_X_EXTENSION>("SP_READ_INTERFAZ_X_EXTENSION", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_INTERFAZ_X_EXTENSION>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <returns></returns>
        public List<oSP_READ_TIPO_ARCHIVO> SP_READ_TIPO_ARCHIVO()
        {
            List<oSP_READ_TIPO_ARCHIVO> ListaRest = new List<oSP_READ_TIPO_ARCHIVO>();

            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_TIPO_ARCHIVO>("SP_READ_TIPO_ARCHIVO", SISTEMA, new object(), new object());


                //===========================================================
                // EVALUACIÓN DE CABEZERA 
                //===========================================================
                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_TIPO_ARCHIVO>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <returns></returns>
        public List<oSP_READ_TIPO_FILESYSTEM> SP_READ_TIPO_FILESYSTEM()
        {
            List<oSP_READ_TIPO_FILESYSTEM> ListaRest = new List<oSP_READ_TIPO_FILESYSTEM>();

            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_TIPO_FILESYSTEM>("SP_READ_TIPO_FILESYSTEM", SISTEMA, new object(), new object());


                //===========================================================
                // EVALUACIÓN DE CABEZERA 
                //===========================================================
                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_TIPO_FILESYSTEM>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <returns></returns>
        public List<oSP_READ_TIPO_DELIMITADOR> SP_READ_TIPO_DELIMITADOR()
        {
            List<oSP_READ_TIPO_DELIMITADOR> ListaRest = new List<oSP_READ_TIPO_DELIMITADOR>();

            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_TIPO_DELIMITADOR>("SP_READ_TIPO_DELIMITADOR", SISTEMA, new object(), new object());


                //===========================================================
                // EVALUACIÓN DE CABEZERA 
                //===========================================================
                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_TIPO_DELIMITADOR>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_CREATE_INTERFAZ SP_CREATE_INTERFAZ(iSP_CREATE_INTERFAZ Input)
        {
            oSP_CREATE_INTERFAZ ObjetoRest = new oSP_CREATE_INTERFAZ();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_CREATE_INTERFAZ>("SP_CREATE_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_CREATE_INTERFAZ)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

       

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_INTERFAZ_DETALLE(iSP_CREATE_INTERFAZ_DETALLE Input)
        {

            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_INTERFAZ_DETALLE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_INTERFAZ_X_EXTENSION(iSP_CREATE_INTERFAZ_X_EXTENSION Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_INTERFAZ_X_EXTENSION", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_INTERFAZ(iSP_DELETE_INTERFAZ Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ(iSP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_INTERFAZ(iSP_UPDATE_INTERFAZ Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_INTERFAZ_X_EXTENSION(iSP_DELETE_INTERFAZ_X_EXTENSION Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_INTERFAZ_X_EXTENSION", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <returns></returns>
        //public List<oSP_READ_SP> SP_READ_SP()
        //{
        //    List<oSP_READ_SP> ListaRest = new List<oSP_READ_SP>();

        //    try
        //    {


        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_READ_SP>("SP_READ_SP", SISTEMA, new object(), new object());


        //        //===========================================================
        //        // EVALUACIÓN DE CABEZERA 
        //        //===========================================================
        //        if (ESTADO == 1)
        //        {
        //            ListaRest = (List<oSP_READ_SP>)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ListaRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public List<oSP_READ_SP_PARAMETRO> SP_READ_SP_PARAMETRO(iSP_READ_SP_PARAMETRO Input)
        //{
        //    List<oSP_READ_SP_PARAMETRO> ListaRest = new List<oSP_READ_SP_PARAMETRO>();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_READ_SP_PARAMETRO>("SP_READ_SP_PARAMETRO", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ListaRest = (List<oSP_READ_SP_PARAMETRO>)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ListaRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public List<oSP_READ_PARAMETROS_INPUT> SP_READ_PARAMETROS_INPUT(iSP_READ_PARAMETROS_INPUT Input)
        //{
        //    List<oSP_READ_PARAMETROS_INPUT> ListaRest = new List<oSP_READ_PARAMETROS_INPUT>();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_READ_PARAMETROS_INPUT>("SP_READ_PARAMETROS_INPUT", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ListaRest = (List<oSP_READ_PARAMETROS_INPUT>)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ListaRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public oSP_RETURN_STATUS SP_READ_EXISTE_SP(iSP_READ_EXISTE_SP Input)
        //{
        //    oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_READ_EXISTE_SP", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ObjetoRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public oSP_RETURN_STATUS SP_DELETE_SP(iSP_DELETE_SP Input)
        //{
        //    oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_SP", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ObjetoRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public oSP_RETURN_STATUS SP_CREATE_SP(iSP_CREATE_SP Input)
        //{
        //    oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_SP", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ObjetoRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public oSP_RETURN_STATUS SP_UPDATE_SP(iSP_UPDATE_SP Input)
        //{

        //    oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_SP", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ObjetoRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public List<oSP_READ_SP_X_CODIGO> SP_READ_SP_X_CODIGO(iSP_READ_SP_X_CODIGO Input)
        //{
        //    List<oSP_READ_SP_X_CODIGO> ListaRest = new List<oSP_READ_SP_X_CODIGO>();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_READ_SP_X_CODIGO>("SP_READ_SP_X_CODIGO", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ListaRest = (List<oSP_READ_SP_X_CODIGO>)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ListaRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public oSP_RETURN_STATUS SP_CREATE_SP_PARAMETRO(iSP_CREATE_SP_PARAMETRO Input)
        //{
        //    oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_SP_PARAMETRO", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ObjetoRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public List<oSP_READ_INTERFAZ_OBJETO> SP_READ_INTERFAZ_OBJETO(iSP_READ_INTERFAZ_OBJETO Input)
        //{
        //    List<oSP_READ_INTERFAZ_OBJETO> ListaRest = new List<oSP_READ_INTERFAZ_OBJETO>();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_READ_INTERFAZ_OBJETO>("SP_READ_INTERFAZ_OBJETO", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ListaRest = (List<oSP_READ_INTERFAZ_OBJETO>)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ListaRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public oSP_RETURN_STATUS SP_DELETE_INTERFAZ_OBJETO(iSP_DELETE_INTERFAZ_OBJETO Input)
        //{
        //    oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_INTERFAZ_OBJETO", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ObjetoRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public oSP_RETURN_STATUS SP_CREATE_INTERFAZ_OBJETO(iSP_CREATE_INTERFAZ_OBJETO Input)
        //{
        //    oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_INTERFAZ_OBJETO", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ObjetoRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public oSP_RETURN_STATUS SP_UPDATE_INTERFAZ_OBJETO(iSP_UPDATE_INTERFAZ_OBJETO Input)
        //{
        //    oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_INTERFAZ_OBJETO", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ObjetoRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_TIPO_CARGA> SP_READ_TIPO_CARGA()
        {
            List<oSP_READ_TIPO_CARGA> ListaRest = new List<oSP_READ_TIPO_CARGA>();

            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_TIPO_CARGA>("SP_READ_TIPO_CARGA", SISTEMA, new object(), new object());


                //===========================================================
                // EVALUACIÓN DE CABEZERA 
                //===========================================================
                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_TIPO_CARGA>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_INTERFAZ_X_PROCESO_FILE> SP_READ_INTERFAZ_X_PROCESO_FILE(iSP_READ_INTERFAZ_X_PROCESO_FILE Input)
        {
            List<oSP_READ_INTERFAZ_X_PROCESO_FILE> ListaRest = new List<oSP_READ_INTERFAZ_X_PROCESO_FILE>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_INTERFAZ_X_PROCESO_FILE>("SP_READ_INTERFAZ_X_PROCESO_FILE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_INTERFAZ_X_PROCESO_FILE>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_INTERFAZ_X_PROCESO_FILE(iSP_DELETE_INTERFAZ_X_PROCESO_FILE Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_INTERFAZ_X_PROCESO_FILE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_PROCESO_FILE> SP_READ_PROCESO_FILE(iSP_READ_PROCESO_FILE Input)
        {
            List<oSP_READ_PROCESO_FILE> ListaRest = new List<oSP_READ_PROCESO_FILE>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_PROCESO_FILE>("SP_READ_PROCESO_FILE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_PROCESO_FILE>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_FTP_X_LLAVE> SP_READ_FTP_X_LLAVE(iSP_READ_FTP_X_LLAVE Input)
        {
            List<oSP_READ_FTP_X_LLAVE> ListaRest = new List<oSP_READ_FTP_X_LLAVE>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_FTP_X_LLAVE>("SP_READ_FTP_X_LLAVE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_FTP_X_LLAVE>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_RUTAS_X_FTP_X_LLAVE> SP_READ_RUTAS_X_FTP_X_LLAVE(iSP_READ_RUTAS_X_FTP_X_LLAVE Input)
        {
            List<oSP_READ_RUTAS_X_FTP_X_LLAVE> ListaRest = new List<oSP_READ_RUTAS_X_FTP_X_LLAVE>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_RUTAS_X_FTP_X_LLAVE>("SP_READ_RUTAS_X_FTP_X_LLAVE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_RUTAS_X_FTP_X_LLAVE>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_ESTADO_INTERFAZ(iSP_UPDATE_ESTADO_INTERFAZ Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_ESTADO_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_CREATE_TABLA_CARGA SP_CREATE_TABLA_CARGA(iSP_CREATE_TABLA_CARGA Input)
        {
            oSP_CREATE_TABLA_CARGA ObjetoRest = new oSP_CREATE_TABLA_CARGA();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_CREATE_TABLA_CARGA>("SP_CREATE_TABLA_CARGA", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_CREATE_TABLA_CARGA)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }
        

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_EJECUCION_X_FILTRO> SP_READ_EJECUCION_X_FILTRO(iSP_READ_EJECUCION_X_FILTRO Input)
        {
            List<oSP_READ_EJECUCION_X_FILTRO> ListaRest = new List<oSP_READ_EJECUCION_X_FILTRO>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_EJECUCION_X_FILTRO>("SP_READ_EJECUCION_X_FILTRO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_EJECUCION_X_FILTRO>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_PROCESO_X_EJECUCION> SP_READ_PROCESO_X_EJECUCION(iSP_READ_PROCESO_X_EJECUCION Input)
        {
            List<oSP_READ_PROCESO_X_EJECUCION> ListaRest = new List<oSP_READ_PROCESO_X_EJECUCION>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_PROCESO_X_EJECUCION>("SP_READ_PROCESO_X_EJECUCION", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_PROCESO_X_EJECUCION>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }

        }
        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_EJECUCION_PROCESO(iSP_UPDATE_EJECUCION_PROCESO Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_EJECUCION_PROCESO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_PROCESO_EJECUTAR(iSP_UPDATE_PROCESO_EJECUTAR Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_PROCESO_EJECUTAR", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_RUTAS_CONFIGURACION_X_LLAVE> SP_READ_RUTAS_CONFIGURACION_X_LLAVE(iSP_READ_RUTAS_CONFIGURACION_X_LLAVE Input)
        {
            List<oSP_READ_RUTAS_CONFIGURACION_X_LLAVE> ListaRest = new List<oSP_READ_RUTAS_CONFIGURACION_X_LLAVE>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_RUTAS_CONFIGURACION_X_LLAVE>("SP_READ_RUTAS_CONFIGURACION_X_LLAVE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_RUTAS_CONFIGURACION_X_LLAVE>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_PROCESO(iSP_CREATE_PROCESO Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_PROCESO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_ESTADO_PROCESO(iSP_UPDATE_ESTADO_PROCESO Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_ESTADO_PROCESO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_ESTADO_PROCESO_X_EJECUCION(iSP_UPDATE_ESTADO_PROCESO_X_EJECUCION Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_ESTADO_PROCESO_X_EJECUCION", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }

        }
        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_HOJA_INTERFAZ(iSP_UPDATE_HOJA_INTERFAZ Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_HOJA_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        ///// <summary>
        ///// LECTURA DE METODOS REST
        ///// </summary>
        ///// <param name="Input"></param>
        ///// <returns></returns>
        //public List<oSP_READ_INTERFAZ_ENTRADA_X_CODIGO> SP_READ_INTERFAZ_ENTRADA_X_CODIGO(iSP_READ_INTERFAZ_ENTRADA_X_CODIGO Input)
        //{
        //    List<oSP_READ_INTERFAZ_ENTRADA_X_CODIGO> ListaRest = new List<oSP_READ_INTERFAZ_ENTRADA_X_CODIGO>();

        //    try
        //    {
        //        //===========================================================
        //        // DECLARACION DE VARIABLES 
        //        //===========================================================
        //        SRestFul Servicio = new SRestFul();


        //        //===========================================================
        //        // LLAMADA DEL SERVICIO  
        //        //===========================================================
        //        int ESTADO = Servicio.Solicitar<oSP_READ_INTERFAZ_ENTRADA_X_CODIGO>("SP_READ_INTERFAZ_ENTRADA_X_CODIGO", SISTEMA, Input, new object());


        //        if (ESTADO == 1)
        //        {
        //            ListaRest = (List<oSP_READ_INTERFAZ_ENTRADA_X_CODIGO>)Servicio.ObjetoRest;
        //        }
        //        else
        //        {
        //            ErroresException Error = (ErroresException)Servicio.ObjetoRest;
        //            throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
        //        }


        //        return ListaRest;


        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_CREATE_GRUPO_CARGA SP_CREATE_GRUPO_CARGA(iSP_CREATE_GRUPO_CARGA Input)
        {
            oSP_CREATE_GRUPO_CARGA ObjetoRest = new oSP_CREATE_GRUPO_CARGA();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_CREATE_GRUPO_CARGA>("SP_CREATE_GRUPO_CARGA", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_CREATE_GRUPO_CARGA)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_GRUPO_CARGA> SP_READ_GRUPO_CARGA(iSP_READ_GRUPO_CARGA Input)
        {
            List<oSP_READ_GRUPO_CARGA> ListaRest = new List<oSP_READ_GRUPO_CARGA>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_GRUPO_CARGA>("SP_READ_GRUPO_CARGA", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_GRUPO_CARGA>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_DETALLE_GRUPO_CARGA_WEB> SP_READ_DETALLE_GRUPO_CARGA(iSP_READ_DETALLE_GRUPO_CARGA_WEB Input)
        {
            List<oSP_READ_DETALLE_GRUPO_CARGA_WEB> ListaRest = new List<oSP_READ_DETALLE_GRUPO_CARGA_WEB>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_DETALLE_GRUPO_CARGA_WEB>("SP_READ_DETALLE_GRUPO_CARGA_WEB", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_DETALLE_GRUPO_CARGA_WEB>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_DETALLE_GRUPO_CARGA(iSP_CREATE_DETALLE_GRUPO_CARGA Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_DETALLE_GRUPO_CARGA", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_PROCESO> SP_READ_PROCESO(iSP_READ_PROCESO Input)
        {
            List<oSP_READ_PROCESO> ListaRest = new List<oSP_READ_PROCESO>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();

                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_PROCESO>("SP_READ_PROCESO", SISTEMA, Input, new object());

                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_PROCESO>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }

                return ListaRest;

            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_PROCESO(iSP_DELETE_PROCESO Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();
            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();

                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_PROCESO", SISTEMA, Input, new object());

                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }

                return ObjetoRest;
            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_DETALLE_GRUPO_CARGA(iSP_DELETE_DETALLE_GRUPO_CARGA Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_DETALLE_GRUPO_CARGA", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }





        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_GRUPO_CARGA_ESTADO(iSP_UPDATE_GRUPO_CARGA_ESTADO Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_GRUPO_CARGA_ESTADO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO(iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }

        }
        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_FIFO_CARGA(iSP_CREATE_FIFO_CARGA Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_FIFO_CARGA", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_FIFO_CARGA(iSP_UPDATE_FIFO_CARGA Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_FIFO_CARGA", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_FIFO_CARGA(iSP_DELETE_FIFO_CARGA Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_FIFO_CARGA", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_EJECUCION_X_GRUPO_CARGA> SP_READ_EJECUCION_X_GRUPO_CARGA(iSP_READ_EJECUCION_X_GRUPO_CARGA Input)
        {
            List<oSP_READ_EJECUCION_X_GRUPO_CARGA> ListaRest = new List<oSP_READ_EJECUCION_X_GRUPO_CARGA>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_EJECUCION_X_GRUPO_CARGA>("SP_READ_EJECUCION_X_GRUPO_CARGA", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_EJECUCION_X_GRUPO_CARGA>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_EJECUCION> SP_READ_EJECUCION(iSP_READ_EJECUCION Input)
        {
            List<oSP_READ_EJECUCION> ListaRest = new List<oSP_READ_EJECUCION>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_EJECUCION>("SP_READ_EJECUCION", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_EJECUCION>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_GRUPO_CARGA(iSP_UPDATE_GRUPO_CARGA Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_GRUPO_CARGA", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_GRUPO> SP_READ_GRUPO()
        {
            List<oSP_READ_GRUPO> ListaRest = new List<oSP_READ_GRUPO>();

            try
            {


                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_READ_GRUPO>("SP_READ_GRUPO", SISTEMA, new object(), new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ListaRest = (List<oSP_READ_GRUPO>)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_LOGIN_X_GRUPO> SP_READ_LOGIN_X_GRUPO(iSP_READ_LOGIN_X_GRUPO Input)
        {
            List<oSP_READ_LOGIN_X_GRUPO> ListaRest = new List<oSP_READ_LOGIN_X_GRUPO>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_LOGIN_X_GRUPO>("SP_READ_LOGIN_X_GRUPO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_LOGIN_X_GRUPO>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <returns></returns>
        public List<oSP_READ_CLUSTER> SP_READ_CLUSTER()
        {
            List<oSP_READ_CLUSTER> ListaRest = new List<oSP_READ_CLUSTER>();

            try
            {


                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_READ_CLUSTER>("SP_READ_CLUSTER", SISTEMA, new object(), new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ListaRest = (List<oSP_READ_CLUSTER>)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_LOGIN_X_GRUPO_X_NRO_USURIO> SP_READ_LOGIN_X_GRUPO_X_NRO_USURIO(iSP_READ_LOGIN_X_GRUPO_X_NRO_USURIO Input)
        {
            List<oSP_READ_LOGIN_X_GRUPO_X_NRO_USURIO> ListaRest = new List<oSP_READ_LOGIN_X_GRUPO_X_NRO_USURIO>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_LOGIN_X_GRUPO_X_NRO_USURIO>("SP_READ_LOGIN_X_GRUPO_X_NRO_USURIO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_LOGIN_X_GRUPO_X_NRO_USURIO>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_GRUPO(iSP_CREATE_GRUPO Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_GRUPO", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_GRUPO(iSP_UPDATE_GRUPO Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_GRUPO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_VALIDA_EXISTE_USUARIO> SP_VALIDA_EXISTE_USUARIO(iSP_VALIDA_EXISTE_USUARIO Input)
        {
            List<oSP_VALIDA_EXISTE_USUARIO> ListaRest = new List<oSP_VALIDA_EXISTE_USUARIO>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_VALIDA_EXISTE_USUARIO>("SP_VALIDA_EXISTE_USUARIO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_VALIDA_EXISTE_USUARIO>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <returns></returns>
        public List<oSP_READ_PAIS> SP_READ_PAIS()
        {
            List<oSP_READ_PAIS> ListaRest = new List<oSP_READ_PAIS>();

            try
            {


                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_READ_PAIS>("SP_READ_PAIS", SISTEMA, new object(), new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ListaRest = (List<oSP_READ_PAIS>)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE> SP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE(iSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE Input)
        {
            List<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE> ListaRest = new List<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE>("SP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_DETALLE_FILE_SALIDA(iSP_CREATE_DETALLE_FILE_SALIDA Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_DETALLE_FILE_SALIDA", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_DETALLE_FILE_SALIDA(iSP_DELETE_DETALLE_FILE_SALIDA Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_DETALLE_FILE_SALIDA", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_CREATE_PROCESO_FILE SP_CREATE_PROCESO_FILE(iSP_CREATE_PROCESO_FILE Input)
        {
            oSP_CREATE_PROCESO_FILE ObjetoRest = new oSP_CREATE_PROCESO_FILE();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_CREATE_PROCESO_FILE>("SP_CREATE_PROCESO_FILE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_CREATE_PROCESO_FILE)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_DETALLE_PROCESO_FILE(iSP_CREATE_DETALLE_PROCESO_FILE Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_DETALLE_PROCESO_FILE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_DETALLE_PROCESO_FILE(iSP_DELETE_DETALLE_PROCESO_FILE Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_DETALLE_PROCESO_FILE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_DETALLE_PROCESO_FILE> SP_READ_DETALLE_PROCESO_FILE(iSP_READ_DETALLE_PROCESO_FILE Input)
        {
            List<oSP_READ_DETALLE_PROCESO_FILE> ListaRest = new List<oSP_READ_DETALLE_PROCESO_FILE>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_DETALLE_PROCESO_FILE>("SP_READ_DETALLE_PROCESO_FILE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_DETALLE_PROCESO_FILE>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_ROW_EJECUCION(iSP_UPDATE_ROW_EJECUCION Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_ROW_EJECUCION", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_OBJETO(iSP_CREATE_OBJETO Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_OBJETO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_OBJETO> SP_READ_OBJETO(iSP_READ_OBJETO Input)
        {
            List<oSP_READ_OBJETO> ListaRest = new List<oSP_READ_OBJETO>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_OBJETO>("SP_READ_OBJETO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_OBJETO>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_OBJETO(iSP_UPDATE_OBJETO Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_OBJETO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_OBJETO_X_INTERFAZ(iSP_CREATE_OBJETO_X_INTERFAZ Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_OBJETO_X_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_OBJETO_X_INTERFAZ> SP_READ_OBJETO_X_INTERFAZ(iSP_READ_OBJETO_X_INTERFAZ Input)
        {
            List<oSP_READ_OBJETO_X_INTERFAZ> ListaRest = new List<oSP_READ_OBJETO_X_INTERFAZ>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_OBJETO_X_INTERFAZ>("SP_READ_OBJETO_X_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_OBJETO_X_INTERFAZ>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_OBJETO_X_INTERFAZ(iSP_DELETE_OBJETO_X_INTERFAZ Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_OBJETO_X_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_OBJETO_INTERFAZ(iSP_DELETE_OBJETO_INTERFAZ Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_OBJETO_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_OBJETO(iSP_DELETE_OBJETO Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_OBJETO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<OUTPUT_INTERFAZ> SP_READ_SP_X_INTERFAZ(string interfaz)
        {
            List<OUTPUT_INTERFAZ> ListaRest = new List<OUTPUT_INTERFAZ>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();

                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.SolicitarPostInterfaz<OUTPUT_INTERFAZ>(interfaz);


                if (ESTADO == 1)
                {
                    ListaRest = (List<OUTPUT_INTERFAZ>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }

                return ListaRest;

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<OUTPUT_PARAMETROS> SP_READ_PARAMETROS_X_SP(string interfaz, string sp)
        {
            List<OUTPUT_PARAMETROS> ListaRest = new List<OUTPUT_PARAMETROS>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();

                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.SolicitarPostParametros<OUTPUT_PARAMETROS>(interfaz, sp);


                if (ESTADO == 1)
                {
                    ListaRest = (List<OUTPUT_PARAMETROS>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }

                return ListaRest;

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_CODIGO_INTERFAZ> SP_READ_CODIGO_INTERFAZ(iSP_READ_CODIGO_INTERFAZ Input)
        {
            List<oSP_READ_CODIGO_INTERFAZ> ListaRest = new List<oSP_READ_CODIGO_INTERFAZ>();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_CODIGO_INTERFAZ>("SP_READ_CODIGO_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_CODIGO_INTERFAZ>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_OBJETO_X_INTERFAZ(iSP_UPDATE_OBJETO_X_INTERFAZ Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_OBJETO_X_INTERFAZ", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_PROCESO_FILE(iSP_DELETE_PROCESO_FILE Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_PROCESO_FILE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_PROCESO_FILE(iSP_UPDATE_PROCESO_FILE Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_PROCESO_FILE", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_FIFO_SOLICITUD(iSP_CREATE_FIFO_SOLICITUD Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_FIFO_SOLICITUD", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_FIFO_SOLICITUD(iSP_DELETE_FIFO_SOLICITUD Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_FIFO_SOLICITUD", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_WHO2> SP_READ_WHO2()
        {
            List<oSP_READ_WHO2> ListaRest = new List<oSP_READ_WHO2>();

            try
            {


                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_READ_WHO2>("SP_READ_WHO2", SISTEMA, new object(), new object());


                //===========================================================
                // EVALUACIÓN DE CABEZERA 
                //===========================================================
                if (ESTADO == 1)
                {
                    ListaRest = (List<oSP_READ_WHO2>)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_DETALLE_GRUPO_CARGA_X_EJECUCION(iSP_DELETE_DETALLE_GRUPO_CARGA_X_EJECUCION Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_DETALLE_GRUPO_CARGA_X_EJECUCION", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_GRUPO_X_CLUSTER> SP_READ_GRUPO_X_CLUSTER(iSP_READ_GRUPO_X_CLUSTER Input)
        {
            List<oSP_READ_GRUPO_X_CLUSTER> ListaRest = new List<oSP_READ_GRUPO_X_CLUSTER>();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_READ_GRUPO_X_CLUSTER>("SP_READ_GRUPO_X_CLUSTER", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ListaRest = (List<oSP_READ_GRUPO_X_CLUSTER>)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_GRUPO_X_CLUSTER(iSP_CREATE_GRUPO_X_CLUSTER Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_GRUPO_X_CLUSTER", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_GRUPO_X_CLUSTER(iSP_DELETE_GRUPO_X_CLUSTER Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_GRUPO_X_CLUSTER", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_GRUPO_X_LOGIN> SP_READ_GRUPO_X_LOGIN(iSP_READ_GRUPO_X_LOGIN Input)
        {
            List<oSP_READ_GRUPO_X_LOGIN> ListaRest = new List<oSP_READ_GRUPO_X_LOGIN>();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_READ_GRUPO_X_LOGIN>("SP_READ_GRUPO_X_LOGIN", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ListaRest = (List<oSP_READ_GRUPO_X_LOGIN>)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_GRUPO_X_LOGIN(iSP_CREATE_GRUPO_X_LOGIN Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_GRUPO_X_LOGIN", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_GRUPO_X_LOGIN(iSP_DELETE_GRUPO_X_LOGIN Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_GRUPO_X_LOGIN", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_GRUPO(iSP_DELETE_GRUPO Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_GRUPO", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_CLUSTER_VALIDACION> SP_READ_CLUSTER_VALIDACION(iSP_READ_CLUSTER_VALIDACION Input)
        {
            List<oSP_READ_CLUSTER_VALIDACION> ListaRest = new List<oSP_READ_CLUSTER_VALIDACION>();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_READ_CLUSTER_VALIDACION>("SP_READ_CLUSTER_VALIDACION", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ListaRest = (List<oSP_READ_CLUSTER_VALIDACION>)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_CLUSTER(iSP_CREATE_CLUSTER Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_CLUSTER", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }


        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_CLUSTER(iSP_UPDATE_CLUSTER Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_CLUSTER", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_CLUSTER(iSP_DELETE_CLUSTER Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_CLUSTER", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_DETALLE_FILE_SALIDA_X_INTERFAZ(iSP_DELETE_DETALLE_FILE_SALIDA_X_INTERFAZ Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_DETALLE_FILE_SALIDA_X_INTERFAZ", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }

                return ObjetoRest;

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_UPDATE_DETALLE_GRUPO_CARGA_NRO_SOLICITUD(iSP_UPDATE_DETALLE_GRUPO_CARGA_NRO_SOLICITUD Input)
        {
            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_UPDATE_DETALLE_GRUPO_CARGA_NRO_SOLICITUD", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }

                return ObjetoRest;

            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_EJECUCION_X_INTERFAZ> SP_READ_EJECUCION_X_INTERFAZ(iSP_READ_EJECUCION_X_INTERFAZ Input)
        {
            List<oSP_READ_EJECUCION_X_INTERFAZ> ListaRest = new List<oSP_READ_EJECUCION_X_INTERFAZ>();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_READ_EJECUCION_X_INTERFAZ>("SP_READ_EJECUCION_X_INTERFAZ", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ListaRest = (List<oSP_READ_EJECUCION_X_INTERFAZ>)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }



        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_SP_PARAMETRO_X_SP> SP_READ_SP_PARAMETRO_X_SP(iSP_READ_SP_PARAMETRO_X_SP Input)
        {
            List<oSP_READ_SP_PARAMETRO_X_SP> ListaRest = new List<oSP_READ_SP_PARAMETRO_X_SP>();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_READ_SP_PARAMETRO_X_SP>("SP_READ_SP_PARAMETRO_X_SP", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ListaRest = (List<oSP_READ_SP_PARAMETRO_X_SP>)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }




        /// <summary>
        /// LECTURA DE METODOS RESTSP_UPDATE_ESTADO_PROCESO
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_DELETE_INTERFAZ_DETALLE_X_SP_PARAMETRO(iSP_DELETE_INTERFAZ_DETALLE_X_SP_PARAMETRO Input)
        {


            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_DELETE_INTERFAZ_DETALLE_X_SP_PARAMETRO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// LECTURA DE METODOS RESTSP_UPDATE_ESTADO_PROCESO
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public oSP_RETURN_STATUS SP_CREATE_INTERFAZ_DETALLE_X_SP_PARAMETRO(iSP_CREATE_INTERFAZ_DETALLE_X_SP_PARAMETRO Input)
        {


            oSP_RETURN_STATUS ObjetoRest = new oSP_RETURN_STATUS();

            try
            {
                //===========================================================
                // DECLARACION DE VARIABLES 
                //===========================================================
                SRestFul Servicio = new SRestFul();


                //===========================================================
                // LLAMADA DEL SERVICIO  
                //===========================================================
                int ESTADO = Servicio.Solicitar<oSP_RETURN_STATUS>("SP_CREATE_INTERFAZ_DETALLE_X_SP_PARAMETRO", SISTEMA, Input, new object());


                if (ESTADO == 1)
                {
                    ObjetoRest = (oSP_RETURN_STATUS)Servicio.ObjetoRest;
                }
                else
                {
                    ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                    throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                }


                return ObjetoRest;


            }
            catch
            {
                throw;
            }
        }




        /// <summary>
        /// LECTURA DE METODO REST
        /// </summary>
        /// <param name="Input"></param>
        /// <returns></returns>
        public List<oSP_READ_TABLAS_BD> SP_READ_TABLAS_BD(iSP_READ_TABLAS_BD Input)
        {
            List<oSP_READ_TABLAS_BD> ListaRest = new List<oSP_READ_TABLAS_BD>();

            try
            {
                //===========================================================
                // SERVICIO REST 
                //===========================================================
                using (SRestFul Servicio = new SRestFul())
                {


                    //=======================================================
                    // LLAMADA DEL SERVICIO  
                    //=======================================================
                    int ESTADO = Servicio.Solicitar<oSP_READ_TABLAS_BD>("SP_READ_TABLAS_BD", SISTEMA, Input, new object());


                    //=======================================================
                    // EVALUACIÓN DE CABEZERA 
                    //=======================================================
                    if (ESTADO == 1)
                    {
                        ListaRest = (List<oSP_READ_TABLAS_BD>)Servicio.ObjetoRest;
                    }
                    else
                    {
                        ErroresException Error = (ErroresException)Servicio.ObjetoRest;
                        throw new EServiceRestFulException(UThrowError.MensajeThrow(Error));
                    }
                }


                return ListaRest;


            }
            catch
            {
                throw;
            }
        }
    
    
    
    
    
    }
}

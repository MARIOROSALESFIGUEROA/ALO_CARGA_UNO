using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALO.Entidades
{
    //===================================================================
    /// <summary>
    /// ESTRUCTURA PARAMETROS
    /// </summary>
    public class R_METODO
    {
        public String SP { get; set; }
        public String SISTEMA { get; set; }
    }

    //===================================================================
    /// <summary>
    /// ESTRUCTURA PARAMETROS
    /// </summary>
    public class R_PARAM
    {

        public object PARAMETROS { get; set; }
    }


    //===================================================================
    /// <summary>
    /// ESTRUCTURA PARAMETROS
    /// </summary>
    public class R_FILTRO
    {

        public object PARAMETROS { get; set; }

    }

    //===================================================================
    /// <summary>
    /// INPUT JSON DEL APLICATIVO
    /// </summary>
    public class INPUT_JSON_ALO
    {



        public R_METODO R_METODO;
        public R_PARAM R_PARAM;
        public R_FILTRO R_FILTRO;

        //===========================================================
        // CONTRUCTOR                                              ==
        //===========================================================
        public INPUT_JSON_ALO()
        {
            R_METODO = new R_METODO();
            R_PARAM = new R_PARAM();
            R_FILTRO = new R_FILTRO();
        }



    }


    //===================================================================
    /// <summary>
    /// ENTIDAD DE ERRORES PROVOCADOS POR EL APLICATIVO
    /// </summary>
    public class ErroresException
    {

        public string NombreMetodo { get; set; }
        public string Clase { get; set; }
        public string NameSpace { get; set; }
        public string Mensaje { get; set; }
        public List<Secuencia> Eventos { get; set; }


        public ErroresException()
        {
            NombreMetodo = "";
            Clase = "";
            NameSpace = "";
            Mensaje = "";
            Eventos = new List<Secuencia>();
        }

    }
    //===================================================================
    /// <summary>
    /// SECUENCIA DE METODOS QUE PROVOCARON LA CAIDA
    /// </summary>
    public class Secuencia
    {

        public string Item { get; set; }

        public Secuencia()
        {
            Item = "";
        }
    }
    //===================================================================
    /// <summary>
    /// ESTADO BINARIO DEL APLICATIVO AL CONTESTAR
    /// </summary>
    public class Header
    {

        public int ESTADO { get; set; }
        public int ID_TIPO_RETORNO { get; set; }

    }
    //===================================================================
    /// <summary>
    /// RESULTADOS GENERICOS DEL SISTEMA
    /// </summary>
    public class Resultados
    {

        public object DETALLES { get; set; }

        public Resultados()
        {
            DETALLES = new object();
        }

    }
    //===================================================================
    /// <summary>
    /// RESULTADOS JSON DEL APLICATIVO
    /// </summary>
    public class OUTUT_JSON_ALO
    {



        public Header HEADER;
        public ErroresException ERRORES;
        public Resultados RESULT;

        //===========================================================
        // CONTRUCTOR                                              ==
        //===========================================================
        public OUTUT_JSON_ALO()
        {
            HEADER = new Header();
            ERRORES = new ErroresException();
            RESULT = new Resultados();
        }
    }

    //===================================================================
    /// <summary>
    /// ESTRUCTURA PARAMETROS
    /// </summary>
    public class INPUT_INTERFAZ
    {
        public string INTERFAZ { get; set; }
    }

    //===================================================================
    /// <summary>
    /// ESTRUCTURA PARAMETROS
    /// </summary>
    public class OUTPUT_INTERFAZ
    {
        public string SP { get; set; }
    }

    //===================================================================
    /// <summary>
    /// ESTRUCTURA PARAMETROS
    /// </summary>
    public class INPUT_PARAMETROS
    {
        public string SP { get; set; }
        public string INTERFAZ { get; set; }
    }


    //===================================================================
    /// <summary>
    /// ESTRUCTURA PARAMETROS
    /// </summary>
    public class OUTPUT_PARAMETROS
    {
        public Int32 ID_METODO { get; set; }
        public Int32 ORDEN { get; set; }
        public String NOMBRE { get; set; }
        public Int32 ID_SQLDBTYPE { get; set; }
        public String TIPO { get; set; }
        public Int32 ENTRADA { get; set; }
        public Int32 LARGO { get; set; }
        public String TIPO_DATO { get; set; }
        public String TIPO_PARAMETRO { get; set; }
    }

    //===================================================================
    /// <summary>
    /// INPUT JSON DEL APLICATIVO
    /// </summary>


    public class INPUT_FTP_JSON_ALO
    {
        public R_FTP R_FTP;
        public R_FILE_FTP R_FILE_FTP;
        public R_FILE_LOCAL R_FILE_LOCAL;

        //===========================================================
        // CONTRUCTOR                                              ==
        //===========================================================
        public INPUT_FTP_JSON_ALO()
        {
            R_FTP = new R_FTP();
            R_FILE_FTP = new R_FILE_FTP();
            R_FILE_LOCAL = new R_FILE_LOCAL();
        }
    }

    //===================================================================
    /// <summary>
    /// ESTRUCTURA PARAMETROS
    /// </summary>
    public class R_FTP
    {
        public String SERVIDOR { get; set; }
        public String USUARIO { get; set; }
        public String PASSWORD { get; set; }
        public String KEY { get; set; }

        public R_FTP()
        {
            SERVIDOR = "";
            USUARIO = "";
            PASSWORD = "";
            KEY = "";
        }

    }

    //===================================================================
    /// <summary>
    /// ESTRUCTURA PARAMETROS
    /// </summary>
    public class R_FILE_FTP
    {
        public String RUTA { get; set; }
        public String FILE { get; set; }

        public R_FILE_FTP()
        {
            RUTA = "";
            FILE = "";
        }
    }

    //===================================================================
    /// <summary>
    /// ESTRUCTURA PARAMETROS
    /// </summary>
    public class R_FILE_LOCAL
    {
        public String RUTA { get; set; }
        public String FILE { get; set; }

        public R_FILE_LOCAL()
        {
            RUTA = "";
            FILE = "";
        }

    }

    //===================================================================
    /// <summary>
    /// RESULTADOS JSON DEL APLICATIVO
    /// </summary>
    public class RETURN_JSON_APL
    {


        public Header HEADER;
        public ErroresException ERRORES;
        public RESULT_HTTP RESULT_HTTP;

        //===========================================================
        // CONTRUCTOR                                              ==
        //===========================================================
        public RETURN_JSON_APL()
        {
            HEADER = new Header();
            ERRORES = new ErroresException();
            RESULT_HTTP = new RESULT_HTTP();
        }
    }

    //===================================================================
    /// <summary>
    /// RESULTADOS GENERICOS DEL SISTEMA
    /// </summary>
    public class RESULT_HTTP
    {

        public Mensaje DETALLES { get; set; }

        public RESULT_HTTP()
        {
            DETALLES = new Mensaje();
        }

    }

    //===================================================================
    /// <summary>
    /// ESTRUCTURA MENSAJE
    /// </summary>
    public class Mensaje
    {
        public String MSG { get; set; }

    }

}

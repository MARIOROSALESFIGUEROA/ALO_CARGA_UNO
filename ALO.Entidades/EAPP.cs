using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALO.Entidades
{


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class Item_Seleccion
    {
        public int Id { get; set; }
        public string IdStr { get; set; }
        public string Nombre { get; set; }
        public string Orden { get; set; }

    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class COOK_DATOS
    {
        public int ID_USUARIO { get; set; }
        public string LOGIN { get; set; }
        public string NOMBRE_USUARIO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_RETURN_STATUS
    {
        public Decimal RETURN_VALUE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_INSTITUCION
    {
        public Int32 ID_INSTITUCION { get; set; }
        public String LLAVE { get; set; }
        public String DESCRIPCION { get; set; }
        public Int32 ID_PAIS { get; set; }
        public String PAIS { get; set; }
        public Int32 ID_ESTADO { get; set; }
        public String ESTADO { get; set; }
        public String CODIGO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_VALIDATE_USUARIO
    {
        public Int32 ID_INSTITUCION { get; set; }
        public String LOGIN { get; set; }
        public String PASSWORD { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_USUARIO_X_LOGIN
    {
        public String LOGIN { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_USUARIO_X_LOGIN
    {
        public Int32 ID_USUARIO { get; set; }
        public String NOMBRE { get; set; }
        public String LOGIN { get; set; }
        public String LOGIN_DISCADOR { get; set; }
        public Boolean ESTADO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_PASSWORD
    {
        public Int32 ID_USUARIO { get; set; }
        public String PASSWORD_ACTUAL { get; set; }
        public String PASSWORD_NUEVA { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class InterfazExcel
    {
        public int NRO_CAMPO { get; set; }
        public string CAMPO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class HojaExcel
    {
        public int Hoja { get; set; }
        public string HojaStr { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_INTERFAZ_X_CLUSTER
    {
        public Int32 ID_CLUSTER { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_INTERFAZ_X_CLUSTER
    {
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ID_CLUSTER { get; set; }
        public String DESCRIPCION { get; set; }
        public String CODIGO_INTERFAZ { get; set; }
        public Int32 ID_TIPO_CARGA { get; set; }
        public Int32 ID_TIPO_ARCHIVO { get; set; }
        public Int32 ID_TIPO_DELIMITADOR { get; set; }
        public String CARACTER { get; set; }
        public Int32 ID_ESTADO_INTERFAZ { get; set; }
        public Int32 ID_TIPO_FILESYSTEM { get; set; }
        public Boolean HEADER { get; set; }
        //public Int32 ID_EJECUCION { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_INTERFAZ
    {
        public Int32 ID_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_INTERFAZ
    {
        public Int32 ID_CLUSTER { get; set; }
        public String DESCRIPCION { get; set; }
        public String CODIGO_INTERFAZ { get; set; }
        public Int32 ID_TIPO_CARGA { get; set; }
        public Int32 ID_TIPO_ARCHIVO { get; set; }
        public Int32 ID_TIPO_DELIMITADOR { get; set; }
        public String CARACTER { get; set; }
        public Int32 ID_ESTADO_INTERFAZ { get; set; }
        public Int32 ID_TIPO_FILESYSTEM { get; set; }
        public Boolean HEADER { get; set; }
        public String CODIGO_CLUSTER { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_INTERFAZ_DETALLE
    {
        public Int32 ID_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_INTERFAZ_DETALLE
    {
        public Int32 ID_INTERFAZ_DETALLE { get; set; }
        public Int32 ORDEN { get; set; }
        public String CAMPO { get; set; }
        public String DATO { get; set; }
        public String FORMATO { get; set; }
        public Int32 LARGO { get; set; }
        public Int32 MISCELANEOS { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_EXTENSION
    {
        public Int32 ID_EXTENSION { get; set; }
        public String DESCRIPCION { get; set; }

        public bool CHEQUED { get; set; }

    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_INTERFAZ_X_EXTENSION
    {
        public Int32 ID_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_INTERFAZ_X_EXTENSION
    {
        public Int32 ID_EXTENSION { get; set; }
        public String DESCRIPCION { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_TIPO_ARCHIVO
    {
        public Int16 ID_TIPO_ARCHIVO { get; set; }
        public String DESCRIPCION { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_TIPO_FILESYSTEM
    {
        public Int16 ID_TIPO_FILESYSTEM { get; set; }
        public String DESCRIPCION { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_TIPO_DELIMITADOR
    {
        public Int16 ID_TIPO_DELIMITADOR { get; set; }
        public String DESCRIPCION { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_INTERFAZ
    {
        public Int32 ID_CLUSTER { get; set; }
        public String DESCRIPCION { get; set; }
        public String CODIGO_INTERFAZ { get; set; }
        public Int32 ID_TIPO_CARGA { get; set; }
        public Int32 ID_TIPO_ARCHIVO { get; set; }
        public Int32 ID_TIPO_FILESYSTEM { get; set; }
        public Int32 ID_TIPO_DELIMITADOR { get; set; }
        public String CARACTER { get; set; }
        public Boolean HEADER { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_CREATE_INTERFAZ
    {
        public Int32 ID_INTERFAZ { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_INTERFAZ_DETALLE
    {
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ORDEN { get; set; }
        public String CAMPO { get; set; }
        public Int16 ID_TIPO_CAMPO { get; set; }
        public String FORMATO { get; set; }
        public Int32 LARGO { get; set; }
        public Int32 MISCELANEOS { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_INTERFAZ_X_EXTENSION
    {
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ID_EXTENSION { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_INTERFAZ
    {
        public Int32 ID_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_INTERFAZ_DETALLE_X_INTERFAZ
    {
        public Int32 ID_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_INTERFAZ
    {
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ID_CLUSTER { get; set; }
        public String DESCRIPCION { get; set; }
        public String CODIGO_INTERFAZ { get; set; }
        public Int32 ID_TIPO_CARGA { get; set; }
        public Int32 ID_TIPO_ARCHIVO { get; set; }
        public Int32 ID_TIPO_FILESYSTEM { get; set; }
        public Int32 ID_TIPO_PROCESO { get; set; }
        public Int32 ID_TIPO_DELIMITADOR { get; set; }
        public String CARACTER { get; set; }
        public Boolean ESTADO { get; set; }
        public Boolean HEADER { get; set; }
        public Boolean OPCION { get; set; }


    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_INTERFAZ_X_EXTENSION
    {
        public Int32 ID_INTERFAZ { get; set; }
    }



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_SP
    {
        public Int32 ID_SP { get; set; }
        public String NAME { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean ESTADO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_SP_PARAMETRO
    {
        public Int32 ID_SP { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_SP_PARAMETRO
    {
        public Int32 ID_SP_PARAMETRO { get; set; }
        public Int32 ID_SP { get; set; }
        public String NAME_SP { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean ESTADO { get; set; }
        public String NAME { get; set; }
        public Int32 TIPO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_PARAMETROS_INPUT
    {
        public String NOMBRE_SP { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_PARAMETROS_INPUT
    {
        public String SP { get; set; }
        public Int32 ID { get; set; }
        public String PARAMETRO { get; set; }
        public String TIPO { get; set; }
        public Int16 LARGO { get; set; }
        public Boolean OUTP { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_EXISTE_SP
    {
        public String NOMBRE_SP { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_SP
    {
        public Int32 ID_SP { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_SP
    {
        public String NAME { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean ESTADO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_SP
    {
        public Int32 ID_SP { get; set; }
        public String NAME { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean ESTADO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_SP_X_CODIGO
    {
        public String CODIGO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_SP_X_CODIGO
    {
        public Int32 ID_SP { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_SP_PARAMETRO
    {
        public Int32 ID_SP { get; set; }
        public String NAME { get; set; }
        public Int32 TIPO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_INTERFAZ_OBJETO
    {
        public Int32 ID_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_INTERFAZ_OBJETO
    {
        public Int32 ID_INTERFAZ_OBJETO { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
        public String CLAVE { get; set; }
        public String VALOR { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_INTERFAZ_OBJETO
    {
        public Int32 ID_INTERFAZ_OBJETO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_INTERFAZ_OBJETO
    {
        public Int32 ID_INTERFAZ { get; set; }
        public String CLAVE { get; set; }
        public String VALOR { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_INTERFAZ_OBJETO
    {
        public Int32 ID_INTERFAZ_OBJETO { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
        public String CLAVE { get; set; }
        public String VALOR { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class VARIABLES_CODIGO
    {
        public Int32 ID { get; set; }
        public string NOMBRE { get; set; }
        public string TIPO { get; set; }

    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class OUTPUT_FILE
    {
        public Int32 ID { get; set; }
        public string NOMBRE { get; set; }
        public string TIPO { get; set; }

    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class ARBOL_CODIGO
    {
        public Int32 ID_ARBOL_CODIGO { get; set; }
        public Int32 PADRE { get; set; }
        public string TEXTO { get; set; }


        public Int32 ID { get; set; }
        public Int32 PARENTID { get; set; }

    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_TIPO_CARGA
    {
        public Int16 ID_TIPO_CARGA { get; set; }
        public String DESCRIPCION { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_INTERFAZ_X_PROCESO_FILE
    {
        public Int32 ID_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_INTERFAZ_X_PROCESO_FILE
    {
        public Int32 ID_INTERFAZ { get; set; }
        public String DESCRIPCION_INTERFAZ { get; set; }
        public String CODIGO_INTERFAZ { get; set; }
        public Int32 ID_PROCESO_FILE { get; set; }
        public String DESCRIPCION_PROCESO_FILE { get; set; }
        public String CODIGO_INTERFAZ_SALIDA { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_INTERFAZ_X_PROCESO_FILE
    {
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ID_PROCESO_FILE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/

    public class iSP_READ_PROCESO_FILE
    {
        public Int32 ID_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_PROCESO_FILE
    {
        public Int32 ID_PROCESO_FILE { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ID_CLUSTER { get; set; }
        public String DESCRIPCION_PROCESO_FILE { get; set; }
        public String SP { get; set; }
        public String CODIGO_INTERFAZ { get; set; }
        public String DESCRIPCION_INTERFAZ { get; set; }
        public String CODIGO_PROCESO_FILE { get; set; }
        public Int32 PRIORIDAD { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_FTP_X_LLAVE
    {
        public String LLAVE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_FTP_X_LLAVE
    {
        public Int32 ID_FTP { get; set; }
        public String SERVIDOR { get; set; }
        public String USUARIO { get; set; }
        public String PASSWORD { get; set; }
        public String KEY_SSH { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_RUTAS_X_FTP_X_LLAVE
    {
        public Int32 ID_FTP { get; set; }
        public String LLAVE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_RUTAS_X_FTP_X_LLAVE
    {
        public String RUTA { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_ESTADO_INTERFAZ
    {
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ID_ESTADO_INTERFAZ { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_TABLA_CARGA
    {
        public Int32 ID_INTERFAZ { get; set; }
        public String FILENAME { get; set; }
        public String COMPRESION { get; set; }
        public String RUTA_FISICA { get; set; }
        public String NOMBRE_TABLA { get; set; }
        public Int32 ID_EJECUCION { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_CREATE_TABLA_CARGA
    {
        public Int32 ID_EJECUCION { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_EJECUCION_X_FILTRO
    {
        public Int32 ID_INTERFAZ { get; set; }
        //public DateTime FECHA_CRE_INI { get; set; }
        //public DateTime FECHA_CRE_FIN { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_EJECUCION_X_FILTRO
    {
        public Int32 ID_EJECUCION { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
        public String CODIGO_INTERFAZ { get; set; }
        public Int32 ID_INTERFAZ_ARCHIVO { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public Int32 ROW_TOTAL { get; set; }
        public String TABLA { get; set; }
        public Int32 ID_TIPO_ARCHIVO { get; set; }
        public Int32 ID_PROCESO { get; set; }
        public Int32 ROW_INICIO { get; set; }
        public Int32 ROW_FIN { get; set; }
        public Int32 ROW_PROCESADO { get; set; }
        public Int32 ID_ESTADO_PROCESO { get; set; }
        public String MENSAJE { get; set; }
        public String ESTADO_PROCESO { get; set; }
        public String FILENAME { get; set; }
        public String RUTA_FISICA { get; set; }
    }



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_EJECUCION_PROCESO
    {
        public Int32 ID_EJECUCION { get; set; }
        public Int32 ACCION { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_PROCESO_EJECUTAR
    {
        public Int32 ID_PROCESO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_RUTAS_CONFIGURACION_X_LLAVE
    {
        public String LLAVE { get; set; }
    }



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_RUTAS_CONFIGURACION_X_LLAVE
    {
        public Int32 ID_RUTAS_CONFIGURACION { get; set; }
        public String LLAVE { get; set; }
        public String DESCRIPCION { get; set; }
        public String TIPO { get; set; }
        public String RUTA { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_PROCESO
    {
        public Int32 ID_EJECUCION { get; set; }
        public Int32 NUMERO_PROCESO { get; set; }
        public Int32 ROW_INICIO { get; set; }
        public Int32 ROW_FIN { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_ESTADO_PROCESO
    {
        public Int32 ID_PROCESO { get; set; }
        public Int32 ID_ESTADO { get; set; }
        public String MENSAJE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_ESTADO_PROCESO_X_EJECUCION
    {
        public Int32 ID_EJECUCION { get; set; }
        public Int32 ID_ESTADO { get; set; }
        public String MENSAJE { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_HOJA_INTERFAZ
    {
        public Int32 ID_INTERFAZ { get; set; }
        public String HOJA_EXCEL { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_INTERFAZ_ENTRADA_X_CODIGO
    {
        public String CODIGO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_INTERFAZ_ENTRADA_X_CODIGO
    {
        public Int32 ORDEN { get; set; }
        public String NOMBRE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_GRUPO_CARGA
    {
        public Int32 ID_CLUSTER { get; set; }
        public String DESCRIPCION { get; set; }
        public String LLAVE_LISTA_EXPLOTADOR { get; set; }
        public String LLAVE_LISTA_NOTIFICACION { get; set; }
        public String LLAVE_LISTA_VERIFICACION { get; set; }
        public Int32 ID_GRUPO_CARGA { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_CREATE_GRUPO_CARGA
    {
        public Int32 ID_GRUPO_CARGA { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_GRUPO_CARGA
    {
        public Int32 ID_GRUPO_CARGA { get; set; }
        public Int32 ID_CLUSTER { get; set; }
        public String DESCRIPCION { get; set; }
        public String LLAVE_LISTA_EXPLOTADOR { get; set; }
        public String LLAVE_LISTA_NOTIFICACION { get; set; }
        public String LLAVE_LISTA_VERIFICACION { get; set; }
    }




    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_GRUPO_CARGA
    {
        public Int32 ID_GRUPO_CARGA { get; set; }
        public Int32 ID_CLUSTER { get; set; }
        public String DESCRIPCION { get; set; }
        public String LLAVE_LISTA_EXPLOTADOR { get; set; }
        public String LLAVE_LISTA_NOTIFICACION { get; set; }
        public String LLAVE_LISTA_VERIFICACION { get; set; }
        public Int32 ID_ESTADO_CARGA { get; set; }
        public String MENSAJE { get; set; }
        public String ESTADO_GRUPO { get; set; }
        public Int32 NRO_SOLICITUD { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_DETALLE_GRUPO_CARGA_WEB
    {
        public Int32 ID_GRUPO_CARGA { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_DETALLE_GRUPO_CARGA_WEB
    {
        public Int32 ID_DETALLE_GRUPO_CARGA { get; set; }
        public Int32 ID_GRUPO_CARGA { get; set; }
        public Int32 ID_EJECUCION { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
        public String CODIGO_INTERFAZ { get; set; }
        public Int32 ID_INTERFAZ_ARCHIVO { get; set; }
        public String FILENAME { get; set; }
        public String COMPRESION { get; set; }
        public String RUTA_FISICA { get; set; }
        public String TABLA { get; set; }
        public Int32 NRO_SOLICITUD { get; set; }
        public Int32 ID_ESTADO_CARGA { get; set; }
        public String MENSAJE { get; set; }
        public String DESCRIPCION { get; set; }



        //public Int32 ID_DETALLE_GRUPO_CARGA { get; set; }
        //public Int32 ID_GRUPO_CARGA { get; set; }
        //public Int32 ID_CLUSTER { get; set; }
        //public String DESCRIPCION { get; set; }
        //public Int32 ORDEN { get; set; }
        //public Int32 ID_EJECUCION { get; set; }
        //public Int32 ID_INTERFAZ { get; set; }
        //public String DESCRIPCION_INTERFAZ { get; set; }
        //public String CODIGO_INTERFAZ { get; set; }
        //public Int32 ID_TIPO_ARCHIVO { get; set; }
        //public Int32 ID_TIPO_FILESYSTEM { get; set; }
        //public Int32 ID_TIPO_CARGA { get; set; }
        //public Int32 ID_TIPO_DELIMITADOR { get; set; }
        //public String CARACTER { get; set; }
        //public Int32 ID_ESTADO_INTERFAZ { get; set; }
        //public Int32 ID_INTERFAZ_ARCHIVO { get; set; }
        //public DateTime FECHA_CREACION { get; set; }
        //public Int32 ROW_TOTAL { get; set; }
        //public String TABLA { get; set; }
        //public String FILENAME { get; set; }
        //public String RUTA_FISICA { get; set; }
        //public String COMPRESION { get; set; }
        //public Int32 ID_ESTADO_CARGA_DETALLE_INTERFAZ { get; set; }
        //public String DESCRIPCION_ESTADO_DETALLE_INTERFAZ { get; set; }
        //public Int32 NRO_SOLICITUD { get; set; }

    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_DETALLE_GRUPO_CARGA
    {
        public Int32 ID_GRUPO_CARGA { get; set; }
        public Int32 ID_EJECUCION { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class LISTA_PROCESOS
    {
        public int NUMERO_PROCESO { get; set; }
        public int INICIO { get; set; }
        public int FIN { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_PROCESO
    {
        public Int32 ID_EJECUCION { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_PROCESO
    {
        public Int32 ID_PROCESO { get; set; }
        public Int32 ID_EJECUCION { get; set; }
        public Int32 NUMERO_PROCESO { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public Int32 ROW_PROCESADO { get; set; }
        public Int32 ROW_INICIO { get; set; }
        public Int32 ROW_FIN { get; set; }
        public DateTime FECHA_EJECUCION { get; set; }
        public Boolean EN_EJECUCION { get; set; }
        public Boolean ENVIADO { get; set; }
        public DateTime FECHA_ENVIO { get; set; }
        public DateTime FECHA_TERMINO { get; set; }
        public Int32 ID_ESTADO_PROCESO { get; set; }
        public String ESTADO { get; set; }
        public String MENSAJE { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_PROCESO
    {
        public Int32 ID_EJECUCION { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_DETALLE_GRUPO_CARGA
    {
        public Int32 ID_DETALLE_GRUPO_CARGA { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_GRUPO_CARGA_ESTADO
    {
        public Int32 ID_GRUPO_CARGA { get; set; }
        public Int32 ID_ESTADO_CARGA { get; set; }
        public String MENSAJE { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_DETALLE_GRUPO_CARGA_ESTADO
    {
        public Int32 ID_DETALLE_GRUPO_CARGA { get; set; }
        public Int32 ID_ESTADO_CARGA { get; set; }
        public String MENSAJE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_FIFO_CARGA
    {
        public Int32 ID_DETALLE_GRUPO_CARGA { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_FIFO_CARGA
    {
        public Int32 ID_GRUPO_CARGA { get; set; }
        public Boolean COLA { get; set; }
        public Boolean EN_EJECUCION { get; set; }
        public Int32 ID_ESTADO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_FIFO_CARGA
    {
        public Int32 ID_DETALLE_GRUPO_CARGA { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_EJECUCION_X_GRUPO_CARGA
    {
        public Int32 ID_GRUPO_CARGA { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_EJECUCION_X_GRUPO_CARGA
    {
        public Int32 ID_EJECUCION { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ID_INTERFAZ_ARCHIVO { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public Int32 ROW_TOTAL { get; set; }
        public String TABLA { get; set; }
        public Int32 ID_TIPO_ARCHIVO { get; set; }
        public String FILENAME { get; set; }
        public String RUTA_FISICA { get; set; }
        public Int32 ID_GRUPO_CARGA { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_GRUPO
    {
        public Int32 ID_GRUPO { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean ESTADO { get; set; }
        public String STR_ESTADO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_GRUPO
    {
        public Int32 ID_PAIS { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_LOGIN_X_GRUPO
    {
        public Int32 ID_GRUPO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_LOGIN_X_GRUPO
    {
        public Int32 ID_LOGIN_X_GRUPO { get; set; }
        public Int32 ID_GRUPO { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean ESTADO { get; set; }
        public Int32 NRO_USUARIO { get; set; }
        public String NOMBRE_USUARIO { get; set; }
    }



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_CLUSTER
    {
        public Int32 ID_CLUSTER { get; set; }
        public Int32 ID_PAIS { get; set; }
        public String PAIS { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean ESTADO { get; set; }
        public String STR_ESTADO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_LOGIN_X_GRUPO_X_NRO_USURIO
    {
        public Int32 NRO_USURIO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_LOGIN_X_GRUPO_X_NRO_USURIO
    {
        public Int32 ID_LOGIN_X_GRUPO { get; set; }
        public Int32 ID_GRUPO { get; set; }
        public Int32 ID_PAIS { get; set; }
        public Int32 NRO_USUARIO { get; set; }
        public String NOMBRE_USUARIO { get; set; }
    }
    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_CLUSTER_X_GRUPO
    {
        public Int32 ID_CLUSTER_X_GRUPO { get; set; }
        public Int32 ID_GRUPO { get; set; }
        public Int32 ID_CLUSTER { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean ESTADO_GRUPO { get; set; }

    }
    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/

    public class iSP_READ_CLUSTER_X_GRUPO
    {
        public Int32 ID_GRUPO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_GRUPO
    {
        public String DESCRIPCION { get; set; }
        public Int32 ID_GRUPO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_CREATE_GRUPO
    {
        public Int32 ID_GRUPO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_GRUPO
    {
        public Int32 ID_GRUPO { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean ESTADO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_VALIDA_EXISTE_USUARIO
    {
        public String LOGIN { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_VALIDA_EXISTE_USUARIO
    {
        public Int32 ID_USUARIO { get; set; }
        public String NOMBRE { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_PAIS
    {
        public Int32 ID_PAIS { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean ESTADO { get; set; }
    }



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE
    {
        public Int32 ID_PROCESO_FILE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_DETALLE_PROCESO_FILE_X_PROCESO_FILE
    {
        public Int32 ID_DETALLE_PROCESO_FILE { get; set; }
        public Int32 ID_PROCESO_FILE { get; set; }
        public String DESCRIPCION_PROCESO_FILE { get; set; }
        public String CODIGO { get; set; }
        public String CAMPO_DET_PROCESO_FILE { get; set; }
        public Int32 ORDEN { get; set; }
        public Int32 ID_TIPO_CAMPO { get; set; }
        public String DESCRIPCION_DATO { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ID_DETALLE_INTERFAZ { get; set; }
        public Int32 ID_DETALLE_FILE_SALIDA { get; set; }
        public String CAMPO_DET_INTERFAZ { get; set; }
    }



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_DETALLE_FILE_SALIDA
    {
        public Int32 ID_DETALLE_PROCESO_FILE { get; set; }
        public Int32 ID_DETALLE_INTERFAZ { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_DETALLE_FILE_SALIDA
    {
        public Int32 ID_DETALLE_FILE_SALIDA { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_PROCESO_FILE
    {
        public Int32 ID_INTERFAZ { get; set; }
        public String DESCRIPCION { get; set; }
        public String SP { get; set; }
        public String CODIGO { get; set; }
        public Int32 PRIORIDAD { get; set; }
        public Int32 ID_PROCESO_FILE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_CREATE_PROCESO_FILE
    {
        public Int32 ID_PROCESO_FILE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_DETALLE_PROCESO_FILE
    {
        public Int32 ID_PROCESO_FILE { get; set; }
        public String CAMPO { get; set; }
        public Int32 ORDEN { get; set; }
        public Int32 ID_TIPO_CAMPO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_DETALLE_PROCESO_FILE
    {
        public Int32 ID_PROCESO_FILE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_DETALLE_PROCESO_FILE
    {
        public Int32 ID_INTERFAZ { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_DETALLE_PROCESO_FILE
    {
        public Int32 ID_DETALLE_PROCESO_FILE { get; set; }
        public Int32 ID_PROCESO_FILE { get; set; }
        public String DESCRIPCION_PROCESO_FILE { get; set; }
        public String CODIGO { get; set; }
        public String CAMPO_DET_PROCESO_FILE { get; set; }
        public Int32 ORDEN { get; set; }
        public Int32 ID_TIPO_CAMPO { get; set; }
        public String DESCRIPCION_DATO { get; set; }
        public Int32 ID_DETALLE_INTERFAZ { get; set; }
        public Int32 ID_DETALLE_FILE_SALIDA { get; set; }
        public String CAMPO_DET_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_ROW_EJECUCION
    {
        public Int32 ID_EJECUCION { get; set; }
        public Int32 ROW_TOTAL { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_OBJETO
    {
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean OBLIGATORIO { get; set; }
        public Int32 ID_CLUSTER { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_OBJETO
    {
        public Int32 ID_CLUSTER { get; set; }
    }



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_OBJETO
    {
        public Int32 ID_OBJETO { get; set; }
        public String CODIGO_OBJETO { get; set; }
        public String DESCRIPCION_OBJETO { get; set; }
        public Boolean OBLIGATORIO { get; set; }
        public Int32 ID_CLUSTER { get; set; }
        public Int32 ID_PAIS { get; set; }
        public String CODIGO_CLUSTER { get; set; }
        public String DESCRIPCION_CLUSTER { get; set; }
        public Boolean ESTADO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_OBJETO
    {
        public Int32 ID_OBJETO { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean OBLIGATORIO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_OBJETO_X_INTERFAZ
    {
        public Int32 ID_OBJETO { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
        public String VALOR { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_OBJETO_X_INTERFAZ
    {
        public Int32 ID_INTERFAZ { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_OBJETO_X_INTERFAZ
    {
        public Int32 ID_OBJETO_X_INTERFAZ { get; set; }
        public Int32 ID_OBJETO { get; set; }
        public String CODIGO_OBJETO { get; set; }
        public String DESCRIPCION_OBJETO { get; set; }
        public String VALOR { get; set; }
        public Int32 ID_CLUSTER_OBJETO { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ID_CLUSTER_INTERFZ { get; set; }
        public String DESCRIPCION_INTERFAZ { get; set; }
        public String CODIGO_INTERFAZ { get; set; }
        public Int32 ID_TIPO_CARGA { get; set; }
        public Int32 ID_TIPO_ARCHIVO { get; set; }
        public Int32 ID_TIPO_FILESYSTEM { get; set; }
        public Int32 ID_TIPO_DELIMITADOR { get; set; }
        public String CARACTER { get; set; }
        public Int32 ID_ESTADO_INTERFAZ { get; set; }
        public Boolean HEADER { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_OBJETO_X_INTERFAZ
    {
        public Int32 ID_INTERFAZ { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_OBJETO_INTERFAZ
    {
        public Int32 ID_OBJETO_X_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_OBJETO
    {
        public Int32 ID_OBJETO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_CODIGO_INTERFAZ
    {
        public Int32 ID_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_CODIGO_INTERFAZ
    {
        public String CODIGO_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_OBJETO_X_INTERFAZ
    {
        public Int32 ID_OBJETO_X_INTERFAZ { get; set; }
        public Int32 ID_OBJETO { get; set; }
        public String VALOR { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_PROCESO_FILE
    {
        public Int32 ID_PROCESO_FILE { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_PROCESO_FILE
    {
        public Int32 ID_PROCESO_FILE { get; set; }
        public String DESCRIPCION { get; set; }
        public String SP { get; set; }
        public String CODIGO { get; set; }
        public Int32 PRIORIDAD { get; set; } 
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_FIFO_SOLICITUD
    {
        public Int32 ID_DETALLE_GRUPO_CARGA { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_FIFO_SOLICITUD
    {
        public Int32 ID_DETALLE_GRUPO_CARGA { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_WHO2
    {
        public Int32 SPID { get; set; }
        public String STATUS { get; set; }
        public String LOGIN { get; set; }
        public String HOSTNAME { get; set; }
        public String BLKBY { get; set; }
        public String DBNAME { get; set; }
        public String COMMAND { get; set; }
        public Decimal CPUTIME { get; set; }
        public Decimal DISKIO { get; set; }
        public String LASTBATCH { get; set; }
        public String PROGRAMNAME { get; set; }
        public Int32 SPID_2 { get; set; }
        public Int32 REQUESTID { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_DETALLE_GRUPO_CARGA_X_EJECUCION
    {
        public Int32 ID_EJECUCION { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_GRUPO_X_CLUSTER
    {
        public Int32 ID_GRUPO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_GRUPO_X_CLUSTER
    {
        public Int32 ID_CLUSTER { get; set; }
        public Int32 ID_GRUPO { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public String ASIGNACION { get; set; }
        public Boolean ENCONTRADO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_GRUPO_CARGA
    {
        public Int32 ID_CLUSTER { get; set; }
    }
    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_GRUPO_X_CLUSTER
    {
        public Int32 ID_GRUPO { get; set; }
        public Int32 ID_CLUSTER { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/

    public class iSP_DELETE_GRUPO_X_CLUSTER
    {
        public Int32 ID_GRUPO { get; set; }
        public Int32 ID_CLUSTER { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_GRUPO_X_LOGIN
    {
        public Int32 ID_GRUPO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_GRUPO_X_LOGIN
    {
        public Int64 ID { get; set; }
        public Int32 ID_GRUPO { get; set; }
        public Int32 NRO_USUARIO { get; set; }
        public String NOMBRE_USUARIO { get; set; }
    }

    public class iSP_CREATE_GRUPO_X_LOGIN
    {
        public Int32 ID_GRUPO { get; set; }
        public Int32 NRO_USUARIO { get; set; }
        public String NOMBRE { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_GRUPO_X_LOGIN
    {
        public Int32 ID_GRUPO { get; set; }
        public Int32 NRO_USUARIO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_GRUPO
    {
        public Int32 ID_GRUPO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_CLUSTER_VALIDACION
    {
        public Int32 ID_USUARIO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_CLUSTER_VALIDACION
    {
        public Int32 ID_CLUSTER { get; set; }
        public String CODIGO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_CLUSTER
    {
        public Int32 ID_PAIS { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean ESTADO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_CLUSTER
    {
        public Int32 ID_CLUSTER { get; set; }
        public Int32 ID_PAIS { get; set; }
        public String CODIGO { get; set; }
        public String DESCRIPCION { get; set; }
        public Boolean ESTADO { get; set; }
        public Boolean OPCION { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_CLUSTER
    {
        public Int32 ID_CLUSTER { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_PROCESO_X_EJECUCION
    {
        public Int32 ID_EJECUCION { get; set; }
    }



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_PROCESO_X_EJECUCION
    {
        public Int32 ID_PROCESO { get; set; }
        public Int32 ID_EJECUCION { get; set; }
        public Int32 NUMERO_PROCESO { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public Int32 ROW_PROCESADO { get; set; }        
        public Int32 ROW_INICIO { get; set; }
        public Int32 ROW_FIN { get; set; }
        public DateTime FECHA_EJECUCION { get; set; }
        public Boolean EN_EJECUCION { get; set; }
        public Boolean ENVIADO { get; set; }
        public DateTime FECHA_ENVIO { get; set; }
        public DateTime FECHA_TERMINO { get; set; }
        public String FILENAME { get; set; }
        public Int32 ID_ESTADO_PROCESO { get; set; }
        public String ESTADO_PROCESO { get; set; }
        public String MENSAJE { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_EJECUCION
    {
        public Int32 ID_EJECUCION { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_EJECUCION
    {
        public Int32 ID_EJECUCION { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ID_INTERFAZ_ARCHIVO { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public Int32 ROW_TOTAL { get; set; }
        public String TABLA { get; set; }
        public Int32 ID_TIPO_ARCHIVO { get; set; }
        public Boolean HEADER { get; set; }
        public String FILENAME { get; set; }
        public String RUTA_FISICA { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_DETALLE_FILE_SALIDA_X_INTERFAZ
    {
        public Int32 ID_INTERFAZ { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_UPDATE_DETALLE_GRUPO_CARGA_NRO_SOLICITUD
    {
        public Int32 ID_DETALLE_GRUPO_CARGA { get; set; }
        public Int32 NRO_SOLICITUD { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_EJECUCION_X_INTERFAZ
    {
        public Int32 ID_INTERFAZ { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_EJECUCION_X_INTERFAZ
    {
        public Int32 ID_EJECUCION { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ID_INTERFAZ_ARCHIVO { get; set; }
        public DateTime FECHA_CREACION { get; set; }
        public Int32 ROW_TOTAL { get; set; }
        public String TABLA { get; set; }
        public String CODIGO_INTERFAZ { get; set; }
        public String DESCRIPCION_INTERFAZ { get; set; }
        public String FILENAME { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_SP_PARAMETRO_X_SP
    {
        public String SP_NAME { get; set; } 
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    [Serializable]
    public class oSP_READ_SP_PARAMETRO_X_SP
    {
        public Int32 ID_SP { get; set; }
        public Int32 ID_SP_PARAMETRO { get; set; }
        public String CAMPO_SP_PARAMETRO { get; set; }
        public Int32 ORDEN_SP_PARAMETRO { get; set; }
        public Int32 ID_TIPO_CAMPO_SP_PARAMETRO { get; set; }
        public String NAME_SP { get; set; }
        public Int32 ID_INTERFAZ_DETALLE { get; set; }
        public Int32 ID_INTERFAZ { get; set; }
        public Int32 ORDEN_INTERFAZ_DETALLE { get; set; }
        public String CAMPO_INTERFAZ_DETALLE { get; set; }
        public Int32 ID_TIPO_CAMPO_INTERFAZ_DETALLE { get; set; }
        public String TIPO_PARAMETRO { get; set; }
    }

    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_DELETE_INTERFAZ_DETALLE_X_SP_PARAMETRO
    {
        public Int32 ID_SP_PARAMETRO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_CREATE_INTERFAZ_DETALLE_X_SP_PARAMETRO
    {
        public Int32 ID_INTERFAZ_DETALLE { get; set; }
        public Int32 ID_SP_PARAMETRO { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class iSP_READ_TABLAS_BD
    {
        public String CARTERA { get; set; }
    }



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/
    public class oSP_READ_TABLAS_BD
    {
        public String TABLA { get; set; }
    }


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/


    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/



    /*----------------------------------------------------------------------------*/
    /*----------------------------------------------------------------------------*/



}


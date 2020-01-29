using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALO.Entidades
{
    //-------------------------------------------------------------------------------*/
    //  NUMERACION DE CONEXIONES                                                     
    //-------------------------------------------------------------------------------*/
    public enum T_Conexiones
    {
        CONEXION_DB = 1
    }


    //-------------------------------------------------------------------------------*/
    //  NUMERACION DE TIPO DE DATO                                                     
    //-------------------------------------------------------------------------------*/
    public enum T_DATO
    {
        SIN_DEFINIR = 0,
        TEXTO = 1,
        NUMERICO = 2,
        FECHA = 3,
        BIT = 4
    }

    //-------------------------------------------------------------------------------*/
    //  NUMERACION DE ESTADO_INTERFAZ
    //-------------------------------------------------------------------------------*/
    public enum T_ESTADO_INTERFAZ
    {
        SIN_ESTADO = 0,
        COPIADA = 1,
        EN_PROCESO = 2,
        CARGADA = 3,
        ERROR = 4
    }

    //-------------------------------------------------------------------------------*/
    //  NUMERACION DE ESTADO_PROCESO
    //-------------------------------------------------------------------------------*/
    public enum T_ESTADO_PROCESO
    {
        SIN_ESTADO = 0,
        EN_PROCESO = 1,
        TERMINO = 2,
        ERROR = 3
    }

    //-------------------------------------------------------------------------------*/
    //  NUMERACION DE ESTADO_CARGA
    //-------------------------------------------------------------------------------*/
    public enum T_ESTADO_CARGA
    {
        SIN_ESTADO = 0,
        EN_PROCESO = 1,
        CARGADO = 2,
        TERMINO = 3,
        ERROR = 4
    }

    //-------------------------------------------------------------------------------*/
    //  NUMERACION DE ESTADO_GRUPO_CARGA
    //-------------------------------------------------------------------------------*/
    public enum T_ESTADO_GRUPO_CARGA
    {
        SIN_ESTADO = 0,
        EN_PROCESO = 1,
        TERMINO = 2,
        ERROR = 3
    }

    //-------------------------------------------------------------------------------*/
    //  NUMERACION DE TIPO DE CARGA
    //-------------------------------------------------------------------------------*/
    public enum T_TIPO_CARGA
    {
        ASIGNACION = 1,
        FLUJO = 2,
        PAGOS = 3
    }


    //-------------------------------------------------------------------------------*/
    //  NUMERACION DE TIPO DE ARCHIVO
    //-------------------------------------------------------------------------------*/
    public enum T_ARCHIVO
    {
        TEXTO_DELIMITADO = 2,
        TEXTO_FIXED = 3
    }


}

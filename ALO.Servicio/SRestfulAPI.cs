using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ALO.Entidades;
using ALO.Utilidades;

namespace ALO.Servicio
{
    public class SRestfulAPI : IDisposable
    {

        public object ObjetoRest;


        /// <summary>
        /// DESTRUCTOR
        /// </summary>
        public void Dispose()
        {
            ObjetoRest = null;
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// CONSTRUCTOR
        /// </summary>
        public SRestfulAPI()
        {

            System.Net.ServicePointManager.DefaultConnectionLimit = 1000;
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.UseNagleAlgorithm = false;
            WebRequest.DefaultWebProxy = null;
        }




    }
}

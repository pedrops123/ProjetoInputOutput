using System;
using System.IO;
using System.Net;

namespace ProjetoInputOutput.WbClient{
    public static class WebClientData
    {

        ///<summary>
        /// Metodo para coletar dados de web site
        ///</summary>
        public static string GetDataWebSite(string url){
            string retorno = "";
            try
            {
                WebClient client = new WebClient();
                retorno = client.DownloadString(Path.Combine("https://",url));
            }
            catch(Exception e)
            {
                throw e;
            }
            return retorno;
        }

    }
}
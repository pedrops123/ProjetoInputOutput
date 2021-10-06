using System;
using System.IO;
using System.Reflection;
using ProjetoInputOutput.Interfaces;

namespace ProjetoInputOutput.ActionRepository {


    ///<summary>
    /// Classe que contem as ações necessarias para o projeto  (Input de dados e output de dados)
    ///</summary>
    public class ActionIO : IActionIO<string>
    {
        public string InternalPath { 
            get { return Path.Combine(Assembly.GetExecutingAssembly().Location.Replace("\\bin\\Debug\\net5.0","").Replace("\\ProjetoInputOutput.dll",""),"RootFolder"); } 
        }         

        private static System.Text.Encoding  EncodingText =  System.Text.Encoding.UTF8; 

        ///<summary>
        /// Construtor da classe
        ///</summary>
        public ActionIO(){ 
            prepareDirectory();
        } 

        ///<summary>
        /// Faz leitura de um arquivo ja existente  e retorna com seu valor
        ///</summary>
        ///<param name="nameFile">Nome do arquivo a ser lido</param>
        public string ReadDataDynamic(string nameFile)
        {
            string TextoArquivo = "";
            string caminhoArquivo = Path.Combine(this.InternalPath,nameFile);
            try
            {
                using(StreamReader reader = new StreamReader(caminhoArquivo)){
                    while(!reader.EndOfStream){
                        TextoArquivo += " " + reader.ReadLine();
                    }
                }
            }
            catch(Exception e){
                throw e;
            }
            return TextoArquivo;
        }

        ///<summary>
        /// Salva dados digitados via sistema em arquivo txt gerado automaticamente.
        ///</summary>
        ///<param name="texto">Conteudo a ser incluido no arquivo TXT</param>
        public string SaveDataDynamic(string texto)
        {
            string arquivo = Path.Combine(InternalPath,"ArquivoTextoOutput.txt");

            try
            {
                if(!File.Exists(arquivo)) 
                { 
                    File.Create(arquivo).Dispose();
                }
                else 
                {
                    File.Delete(arquivo);
                    File.Create(arquivo).Dispose();
                }

                using (StreamWriter wr = new StreamWriter(arquivo,false,EncodingText)){
                    wr.WriteLine(texto);
                }

            }
            catch(Exception e){
                throw e;
            }

            return texto;
        }



        ///<summary>
        /// Metodo para validar se a pasta de arquivos principal esta criado ou não.
        ///</summary>
        private void prepareDirectory(){
            try
            {
                if(!Directory.Exists(InternalPath)){
                    Directory.CreateDirectory(InternalPath);
                }
            }
            catch(Exception e){
                throw e;
            }
        }


    }
}
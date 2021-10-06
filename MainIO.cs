using System;
using ProjetoInputOutput.ActionRepository;
using ProjetoInputOutput.WbClient;

namespace ProjetoInputOutput
{

     ///<summary>
     /// Classe principal do sistema
     ///</summary>
    class MainIO
    {
        ///<summary>
        /// Funçao para limpar o console.
        ///</summary>
        private static void LimparConsole() => Console.Clear();


        ///<summary>
        /// Funçao principal do sistema - Ponto de entrada principal.
        ///</summary>
        ///<param name="args">Argumentos iniciais do ponto de entrada</param>
        static void Main(string[] args)
        {
            LabelTop:;
            ActionIO actions = new ActionIO();
            int escolha;
            Console.WriteLine("               ##################### SISTEMA INPUT OUTPUT ######################## \n  "); 
            Console.WriteLine("1 - Input  -> Faz leitura de um arquivo TXT e inclui dentro do sistema \n ");
            Console.WriteLine("2 - Output ->  Coleta alguma informação dentro do sistema e exporta para um arquivo TXT \n");
            Console.WriteLine("0 - Sair \n");
            Console.WriteLine("Faça sua escolha: \n");

            try
            {
                escolha = int.Parse(Console.ReadLine().ToString());
            }
            catch(Exception){
                Console.WriteLine("Sua escolha deve ser somente numeros inteiros !");
                goto LabelTop;
            }

            switch(escolha){

                
                case 1:
                    LimparConsole();
                    Console.WriteLine("Por favor digite o nome do arquivo : \n");
                    string nomeArquivo = Console.ReadLine().ToString();
                    Console.WriteLine(actions.ReadDataDynamic(nomeArquivo));
                    goto LabelTop;
                break;

                case 2:
                    LimparConsole();
                    lblEscolhaOutput:;
                    string textoPassado = "";
                    Console.WriteLine("Voce deseja : \n \n 1 - incluir um texto manualmente \n \n 2 - gerar um texto de um Web Site ");
                    int opcao;

                    try
                    {
                         opcao =  int.Parse(Console.ReadLine().ToString());
                    }
                    catch(Exception){
                        Console.WriteLine("Opcao invalida , nao corresponde a um numero inteiro ! \n Favor escolher somente numeros inteiros.");
                        goto lblEscolhaOutput;
                    }
                   
                    if(opcao == 1){
                        Console.WriteLine("Favor digitar o texto : \n");
                        textoPassado = Console.ReadLine();
                        actions.SaveDataDynamic(textoPassado);
                    }
                    else if(opcao == 2){
                        Console.WriteLine("Favor digitar uma url valida para coleta de string: \n");
                        var urlText = Console.ReadLine();
                        textoPassado =  WebClientData.GetDataWebSite(urlText);
                        actions.SaveDataDynamic(textoPassado);
                    }
                    else 
                    {
                          Console.WriteLine("Opção invalida , favor somente digitar as opções informadas: \n");
                          goto lblEscolhaOutput;
                    }

                    Console.WriteLine(String.Format("Arquivo gerado em {0}", actions.InternalPath));
                    goto LabelTop;
                break;

                case 0:
                    Environment.Exit(-1);
                break;

                default:
                    Console.WriteLine("Opção nao existente , favor escolher novamente !");
                    goto LabelTop;
                break;
            }


            

        }



    }
}

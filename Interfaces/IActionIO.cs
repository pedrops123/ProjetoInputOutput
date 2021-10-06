using System;

namespace ProjetoInputOutput.Interfaces
{
    ///<summary>
    /// Interface para padronização de metodos das ações do programa.
    /// T -> tipo dinamico para retorno dos metodos.
    ///<summary/>
    public interface IActionIO<T>{

        ///<summary>
        /// Metodo de leitura de arquivo dinamico
        ///<summary/>
        T ReadDataDynamic(string nameFile);

        ///<summary>
        /// Metodo Criação de arquivo dinamico
        ///<summary/>
        T SaveDataDynamic(string texto);
    }
}
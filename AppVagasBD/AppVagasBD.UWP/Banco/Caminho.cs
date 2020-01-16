using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; //E PRECISO TER ESTA BIBLIOTECA 
using Xamarin.Forms;//Primeiro instanciar a biblioteca Xamarin.Forms, pq nesta biblioteca tem o DependecyService
using AppVagasBD.Banco;//Segundo chamar a pasta do BancoDeDados
using AppVagasBD.UWP.Banco;//É preciso colocar o Namespace
using Windows.Storage;//E preciso chamar a bibloteca de armazenamento
[assembly: Dependency(typeof(Caminho))]//é depois chamar este assembly

namespace AppVagasBD.UWP.Banco
{
    public class Caminho : ICaminho //Terceiro colocar a classe como publica e depois chamar a interface ICaminho
    {
        /// <summary>
        /// Aqui vamos criar o caminho do banco de dados para o UWP
        /// </summary>
        public string ObeterCaminho(string NomeArquivoBanco)//Quarto criar um metodo que implemente o caminho, OBS deve ser o mesmo nome do metodo da interface ICaminho
        {
            string CaminhoDaPastaUWP = ApplicationData.Current.LocalFolder.Path;//Aqui estamos achando a pasta para
            //Salva o banco de dados
            string CaminhoBanco = Path.Combine(CaminhoDaPastaUWP, NomeArquivoBanco);//Penultimo passo chamar a pasta para nosso banco de dados, para que o caminho se junte ao banco
            return CaminhoBanco; //Ultimo passo retorna o caminho especifico para o banco
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using System.IO; //E PRECISO TER ESTA BIBLIOTECA 
using Xamarin.Forms;//Primeiro instanciar a biblioteca Xamarin.Forms, pq nesta biblioteca tem o DependecyService
using AppVagasBD.Banco;//Segundo chamar a pasta do BancoDeDados
using AppVagasBD.iOS.Banco;//É preciso colocar o Namespace
[assembly: Dependency(typeof(Caminho))]//é depois chamar este assembly

namespace AppVagasBD.iOS.Banco
{
    /// <summary>
    /// Aqui vamos criar o caminho do banco de dados para o ios
    /// </summary>
    public class Caminho : ICaminho //Terceiro colocar a classe como publico, depois chamar o Icaminho
    {
        public string ObeterCaminho(string NomeArquivoBanco)//Quarto criar um metodo que implemente o caminho, OBS deve ser o mesmo nome do metodo da interface ICaminho
        {
            string CaminhoDaPastadoios = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);//Sexto retorna um metodo ate determinada pasta 
            //System.Environment.SpecialFolder.Personal;//Aqui vamos pegar a pasta especifica chamada Personal, ou seja
            // uma pasta pessoal e dentro dela que vamos colocar nosso banco, vamos o  System.Environment.SpecialFolder.Personal colocarmos no parametro do GetFolderPath
            string CaminhoDaBilbioteca = Path.Combine(CaminhoDaPastadoios, "..", "Library");//Aqui estou voltando de pasta
            string CaminhoBanco = Path.Combine(CaminhoDaBilbioteca, NomeArquivoBanco);//Penultimo passo chamar a pasta para nosso banco de dados, para que o caminho se junte ao banco
            return CaminhoBanco;//Ultimo passo retorna o caminho especifico para o banco
        }
    }
}
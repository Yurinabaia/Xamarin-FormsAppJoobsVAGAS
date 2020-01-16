using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SQLite;//Primeiro devemos importa a biblioteca do banco de dados 
using Xamarin.Forms;//Primeiro devemos importa a biblioteca do XamarinForms
using AppVagasBD.Modelos;//Quarta parte chamar a classe com elementos que iram para banco de dados
namespace AppVagasBD.Banco
{
    
    class AcessoBancoDeDados
    {
        private SQLiteConnection _conexao;//Segundo chamar o SQLiteConnection
        public AcessoBancoDeDados()//Construtor
        { 
            ///apenas criar este var dep depois de ter passado pelos Dez passos adiantes
            var dep = DependencyService.Get<ICaminho>();//O ultimo passo, instanciar o DependencyService.Get<ICaminho>();
            string caminho = dep.ObeterCaminho("database.sqlite");//Está string ira para os parametros do SQLiteConnection
            ///NÃO ESQUE ESTA PARTE DE CIMA E A ULTIMA PARTE, POR ISSO É IMPORTANTE VER ELA POR ULTIMO

            //O new SQLiteConnection(); é preciso intanciar o caminho para o banco de dados.
            //Porem a cada sistema operacional tem um caminho especifico
            //é preciso utiliza a DepedencyService;
            _conexao = new SQLiteConnection(caminho);//Terceiro criar um contrutor para chamar o metodo SQLiteConnection

            ///Aqui vamos criar a tabela Vaga, depois de ter feitos os dez passos

            _conexao.CreateTable<Vagas>();//Criamos a tabela para o banco de dados
        }
        public void Cadastro(Vagas vagas) //Quinta parte criar um metodo para receber os valores da classe importada no quarto passo
        {

            _conexao.Insert(vagas);//Aqui ira fazer o cadastro da vaga
        }
        public void Exclusao(Vagas vagas)//Sexto passo metodo de exlusão para o Banco de dados, o id vai referenciar o objeto a ser excluido
        {
            _conexao.Delete(vagas);//Aqui vai deletar a vaga
        }
        public void Atualizacao(Vagas vaga)//Setimo passar, criar um metodo de atualização do BD
        {
            _conexao.Update(vaga);//Aqui vai atualizar a vaga
        }
        public List<Vagas> Consultar() //Oitavo criar um metodo de consulta para Banco de dados
        {
            ///CRIANDO A CONSULTA DEPOIS DE TER FEITO OS DEZ PASSOS
          //  _conexao.Table<Vagas>().ToList();//Aqui estamos pegando todos as informações do nosso banco
            return _conexao.Table<Vagas>().ToList();
        }
        public Vagas ObterVagaPorId(int ID)//Nono passo criar um metodo que ira consulta a vaga especifica 
        {
            return _conexao.Table<Vagas>().ToList().Where(x => x.Id == ID).FirstOrDefault();//Aqui criamos 
            //Uma labda para busca no Banco com Where o valor do id deve ser o mesmo para o ID que ira receber
        } 
        public List<Vagas> PesquisaPorNome(string Palavra)//Nono passo criar um metodo que ira consulta a vaga especifica 
        {
            return _conexao.Table<Vagas>().ToList().Where(x => x.NomeVagas.Contains(Palavra)).ToList(); //Aqui criamos 
            //Uma labda para busca no Banco com Where o valor do id deve ser o mesmo para o ID que ira receber
        }
        //Decimo passo criar a Inteface ICaminho, para criar um metodo 
        //Que retorne o caminho que pode ser salvo ou que está salvo nosso banco de dados
    }
}

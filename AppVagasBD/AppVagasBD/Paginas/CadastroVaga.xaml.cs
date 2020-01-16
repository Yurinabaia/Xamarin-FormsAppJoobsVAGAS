using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVagasBD.Banco;
using AppVagasBD.Modelos;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVagasBD.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroVaga : ContentPage
    {
        public CadastroVaga()//Vagas vaga = null Isso faz com que este parametro seja opcional, quando colocamos = Null
        {
            InitializeComponent();
        }
        public void SALVACADASTRO(object sender, EventArgs args) 
        {
            //TODO - validar dados de cadastro
            Vagas vaga = new Vagas();
            vaga.NomeVagas = VAGA.Text;
            vaga.Empresa = EMPRESA.Text;
            vaga.Quantidade = short.Parse(QUANTIDADE.Text);
            vaga.Cidade = CIDADE.Text;
            vaga.Salario = double.Parse(SALARIO.Text);
            vaga.Descricao = DESCICAO.Text;
            vaga.TipoDeContato = (TIPOCONTRATACAO.IsToggled) ? "PJ" : "CLT";
            vaga.Telefone = TELEFONE.Text;
            vaga.Email = EMAIL.Text;

            AcessoBancoDeDados banco = new AcessoBancoDeDados();
            banco.Cadastro(vaga);
            //TODO - voltar tela de pesquisa
            App.Current.MainPage = new NavigationPage(new ConsultaVagas());
            ///O TODO FAZ COM QUE APAREÇAR INFORMAÇÕES A SER APRESENTADA NO PROGRAMA, NO LISTA DE TAREFAS VC PODE ACOMPANHAR
        }
    }
}
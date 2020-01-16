using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVagasBD.Modelos;
using AppVagasBD.Banco;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppVagasBD.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarVagas : ContentPage
    {
        private Vagas vaga { get; set; }
        public EditarVagas(Vagas vaga)
        {
            InitializeComponent();
            this.vaga = vaga;
            VAGA.Text = vaga.NomeVagas;
            EMPRESA.Text = vaga.Empresa;
            QUANTIDADE.Text = vaga.Quantidade.ToString();
            CIDADE.Text = vaga.Cidade;
            SALARIO.Text = vaga.Salario.ToString();
            DESCICAO.Text = vaga.Descricao;
            TIPOCONTRATACAO.IsToggled = (vaga.TipoDeContato == "PJ") ? false : true;
            TELEFONE.Text = vaga.Telefone;
            EMAIL.Text = vaga.Email;
        }
        public void SALVAEDITADO(object sender, EventArgs args) 
        {
            vaga.NomeVagas = VAGA.Text;
            vaga.Empresa = EMPRESA.Text;
            vaga.Quantidade = short.Parse(QUANTIDADE.Text);
            vaga.Cidade = CIDADE.Text;
            vaga.Salario = double.Parse(SALARIO.Text);
            vaga.Descricao = DESCICAO.Text;
            vaga.TipoDeContato = (TIPOCONTRATACAO.IsToggled) ? "CLT" : "PJ";
            vaga.Telefone = TELEFONE.Text;
            vaga.Email = EMAIL.Text;


            AcessoBancoDeDados banco = new AcessoBancoDeDados();
            banco.Atualizacao(vaga);


            App.Current.MainPage = new NavigationPage(new MinhasVagasCadastrada());
            //TODO - ATUALIZAR BANCO DE DADOS
        }
    }
}
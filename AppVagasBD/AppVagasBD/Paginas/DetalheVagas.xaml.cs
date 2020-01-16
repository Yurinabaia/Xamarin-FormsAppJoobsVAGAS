using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AppVagasBD.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalheVagas : ContentPage
    {
        public DetalheVagas(Modelos.Vagas vagas)
        {
            InitializeComponent();
            BindingContext = vagas;//Apenas isso para carregas nossas pagina de vaga. kk
            TEXTOPRINCIPAL.Text = "Vaga de " + vagas.NomeVagas;
            NomeEMPRESA.Text = "Empresa: " + vagas.NomeVagas;
            QUANTIDADE.Text = "Quantidades de vagas: " + vagas.Quantidade;
            CIDADE.Text = "Cidade: " + vagas.Cidade;
            SALARIO.Text = "Salario: " + vagas.Salario;
            DESCRICAO.Text = "Requisitos: " + vagas.Descricao;
            TIPODEVAGA.Text = "Tipo de vaga: " + vagas.TipoDeContato;
            TELEFONE.Text = "Telefone de contato: " + vagas.Telefone;
            EMAIL.Text = "Email do contato: " + vagas.Email;
        }
    }
}
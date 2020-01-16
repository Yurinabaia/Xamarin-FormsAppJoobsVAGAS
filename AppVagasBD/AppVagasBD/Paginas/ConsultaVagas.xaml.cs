using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppVagasBD.Banco;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppVagasBD.Modelos;

namespace AppVagasBD.Paginas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaVagas : ContentPage
    {
        List<Vagas> listando { get; set; }
        public ConsultaVagas()
        {
            InitializeComponent();
            AcessoBancoDeDados banco = new AcessoBancoDeDados();
            listando = banco.Consultar();
            LISTAVAGA.ItemsSource = listando;
            LBLCUNT.Text = "Quantidade de vagas " + listando.Count.ToString();
        }
        public void IrPaginasVagas(object sender, EventArgs args) //Todo botão possuir object sender, EventArgs args 
        {
            Navigation.PushAsync( new CadastroVaga());
        } 
        public void IrMinhasVagas(object sender, EventArgs args) //Todo botão possuir object sender, EventArgs args 
        {
            Navigation.PushAsync( new MinhasVagasCadastrada());
        }
        public void IrMaisDetalhes(object sender, EventArgs args) //Todo botão possuir object sender, EventArgs args 
        {
            Label lblDetalhe = (Label)sender;
            TapGestureRecognizer tapgest = (TapGestureRecognizer)lblDetalhe.GestureRecognizers[0];//Aqui estamos pegando o toque na label
            Vagas vaga = tapgest.CommandParameter as Vagas;//Aqui estamos pegando a propriedade dela que e uma Vagas e colocando para ser um botão
            Navigation.PushAsync( new DetalheVagas(vaga));//Aqui estamos fazendo a ação do GestureRecognizer
        }
        public void FiltraVaga(object sender, TextChangedEventArgs args) //Todo TextChanged="FiltraVaga"  
            //possuir um object sender, TextChangedEventArgs args;
        {
            LISTAVAGA.ItemsSource =  listando.Where(x => x.NomeVagas.Contains(args.NewTextValue)).ToList();
        }
    }
}
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

    public partial class MinhasVagasCadastrada : ContentPage
    {
        List<Vagas> listando { get; set; }
        public MinhasVagasCadastrada()
        {
            InitializeComponent();
            ConsultaVaga();
        }
        private void ConsultaVaga() 
        {
            AcessoBancoDeDados banco = new AcessoBancoDeDados();
            listando = banco.Consultar();
            LISTAVAGA.ItemsSource = listando;
            LBLCUNT.Text = "Quantidade de vagas " + listando.Count.ToString();
        }
        public void EditarVaga(object sender, EventArgs args) //Todo botão possuir um object sender, EventArgs args
        {
            Label lblEditar = (Label)sender;
            TapGestureRecognizer tapgest = (TapGestureRecognizer)lblEditar.GestureRecognizers[0];//Aqui estamos pegando o toque na label
            Vagas vaga = tapgest.CommandParameter as Vagas;//Aqui estamos pegando a propriedade dela que e uma Vagas e colocando para ser um botão
            Navigation.PushAsync(new EditarVagas(vaga));//Aqui estamos fazendo a ação do GestureRecognizer
        }
        public void ExcluirVaga(object sender, EventArgs args) //Todo botão possuir um object sender, EventArgs args
        {
            Label lblExcluir = (Label)sender;
            TapGestureRecognizer tapgest = (TapGestureRecognizer)lblExcluir.GestureRecognizers[0];//Aqui estamos pegando o toque na label
            Vagas vaga = tapgest.CommandParameter as Vagas;//Aqui estamos pegando a propriedade dela que e uma Vagas e colocando para ser um botão
            AcessoBancoDeDados banco = new AcessoBancoDeDados();
            banco.Exclusao(vaga);
            ConsultaVaga();
        }
               
        public void FiltraVaga(object sender, TextChangedEventArgs args) //Todo TextChanged="FiltraVaga"  
            //possuir um object sender, TextChangedEventArgs args;
        {
            LISTAVAGA.ItemsSource =  listando.Where(x => x.NomeVagas.Contains(args.NewTextValue)).ToList();
        }
    }
}
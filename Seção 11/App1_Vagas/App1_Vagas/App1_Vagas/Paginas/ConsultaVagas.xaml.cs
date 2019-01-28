using App1_Vagas.Banco;
using App1_Vagas.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Vagas.Paginas
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConsultaVagas : ContentPage
	{
		public ConsultaVagas ()
		{
			InitializeComponent ();

            
            Database database = new Database();
            ListaVagas.ItemsSource =  database.consultar();

            var Lista = database.consultar();
            

            lblCount.Text = Lista.Count.ToString(); 
		}

        public void GoCadastro(object sender, EventArgs args)
        {
            Navigation.PushAsync(new CadastroVaga());
        }

        public void GoMinhasVagas(object sender,EventArgs args)
        {
            Navigation.PushAsync(new MinhasVagasCadastradas());
        }

        public void MaisDetalheAction(object sender,EventArgs args)
        {
            Label lblDetalhe = (Label)sender;
            TapGestureRecognizer tapGest = (TapGestureRecognizer)lblDetalhe.GestureRecognizers[0];
            Vaga vaga = tapGest.CommandParameter as Vaga;
            Navigation.PushAsync(new DetalheVaga(vaga));
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ControleEstoque.View;
using ControleEstoque.Services;
using ControleEstoque;

namespace ControleEstoque
{
	public partial class MainPage : MasterDetailPage
    {
        EstoqueService inventario =  new EstoqueService();
        public int idEmpresa = 0;

		public MainPage(int idEmpresa)
		{
            InitializeComponent();

            this.idEmpresa = idEmpresa;

            ButtonA.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new GraficoEntrada(this.idEmpresa));
            };

            ButtonB.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new GraficoSaida(this.idEmpresa));
            };

            ButtonC.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new GraficoEstoque(this.idEmpresa));
            };
        }
    }
}

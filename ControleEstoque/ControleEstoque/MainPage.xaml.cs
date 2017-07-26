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

		public MainPage()
		{
            InitializeComponent();

            ButtonA.Clicked += async (sender, e) =>
            {
                await Navigation.PushAsync(new GraficoEstoque());
            };
        }

        //private void Button1_OnClicked(object sender, EventArgs e)
        //{
        //    Detail = (new Detail());
        //}

        //private void Button2_OnClicked(object sender, EventArgs e)
        //{
        //    App.MasterDetail.Detail.Navigation.PushAsync(new GraficoEstoque());
        //    Detail = new NavigationPage(new GraficoEstoque());
        //}

        private void Button3_OnClicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ListProduto());
        }
    }
}

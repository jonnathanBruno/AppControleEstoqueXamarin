using ControleEstoque.Models;
using Xamarin.Forms;
using ControleEstoque.Services;
using Java.Lang;

namespace ControleEstoque.View
{
    public partial class ListProduto : ContentPage
    {
        EstoqueService inventario = new EstoqueService();

        public ListProduto()
        {
            InitializeComponent();
            inventario.BuscarInventario();


            MessagingCenter.Subscribe<Produto[]>(this, "SucessoBuscarProduto",
                (produtos) =>
                {
                    this.BindingContext = new ListagemProdutos(produtos);
                });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            AssinarMensagens();
        }

        private void AssinarMensagens()
        {
            MessagingCenter.Subscribe<Produto>(this, "ProdutoSelecionado",
            (produto) =>
            {
                Navigation.PushAsync(new DetalheProduto(produto));
            });


            MessagingCenter.Subscribe<Exception>(this, "FalhaListagem",
                (msg) =>
                {
                    DisplayAlert("Erro", "Ocorreu um erro ao obter a listagem de Produtos.", "Ok");
                });
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            CancelarAssinatura();
        }

        private void CancelarAssinatura()
        {
            MessagingCenter.Unsubscribe<Produto>(this, "ProdutoSelecionado");
            MessagingCenter.Unsubscribe<Exception>(this, "FalhaListagem");
        }
    }
}

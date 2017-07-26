using ControleEstoque.ViewModel;
using ControleEstoque.Models;
using Xamarin.Forms;


namespace ControleEstoque.View
{

    public partial class DetalheProduto : ContentPage
    {
        public Produto Produto { get; private set; }

        public DetalheProduto(Produto produto)
        {
            InitializeComponent();
            this.Produto = produto;
            this.BindingContext = new DetalheProdutoViewModel(produto);
        }
    }
}
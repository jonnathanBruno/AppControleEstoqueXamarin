using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleEstoque.View;
using ControleEstoque.Models;
using Xamarin.Forms;

namespace ControleEstoque.Models
{
    public class ListagemProdutos
    {

        public List<Produto> produtos { get; set; }

        public ListagemProdutos(Produto[] produto)
        {
            produtos = new List<Produto>();

            foreach (var prod in produto)
            {
                produtos.Add(prod);
            }
        }

        Produto produtoSelecionado;
        public Produto ProdutoSelecionado
        {
            get
            {
                return produtoSelecionado;
            }
            set
            {
                produtoSelecionado = value;
                if (value != null)
                    MessagingCenter.Send(produtoSelecionado, "ProdutoSelecionado");
            }
        }

    }
}

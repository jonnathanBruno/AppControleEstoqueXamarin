using System;
using System.Collections.Generic;
using System.Text;
using ControleEstoque.Models;

namespace ControleEstoque.ViewModel
{
    class DetalheProdutoViewModel
    {
        public Produto Produto { get; set; }

        public DetalheProdutoViewModel(Produto produto)
        {
            this.Produto = produto;
        }

        public string TextoNomeProduto
        {
            get
            {
                return "Nome do Produto: " + this.Produto.Produto_Quimico1;
            }
        }

        public string TextoEstoqueMinimo
        {
            get
            {
                return "Estoque Mínimo: " + this.Produto.estoqueMinimo;
            }
        }

        public string TextoEstoqueGerado
        {
            get
            {
                return "Quantidade Estoque: " + this.Produto.estoqueGerado;
            }
        }

        public string TextoUnidade
        {
            get
            {
                return "Unidade: " + this.Produto.Unidade;
            }
        }

        public string TextoValorEstoque
        {
            get
            {
                return "Total Estoque: " + this.Produto.valorRealEstoque;
            }
        }
    }
}

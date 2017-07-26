using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoque.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        public string d { get; set; }
        public string Unidade { get; set; }
        public string nomeFornecedor { get; set; }
        public string Valor_Produto_Unidade { get; set; }
        public string Produto_Quimico1 { get; set; }
        public int estoqueGerado { get; set; }
        public int idItemEntrada { get; set; }
        public int Id_Produto_Quimico { get; set; }
        public int estoqueMinimo { get; set; }
        public double valorRealEstoque { get; set; }
    }
}

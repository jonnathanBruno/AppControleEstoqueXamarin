using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ControleEstoque.Models;
using Xamarin.Forms;


namespace ControleEstoque.Services
{
    class EstoqueService
    {
        const string URL = "http://teste-ipragas.uni5.net/Sistema/Logica_Estoque/ControleEstoque.asmx/pegarDadosProdutoEstoque";

        public async Task BuscarInventario(int idEmpresa)
        {
            HttpClient cliente = new HttpClient();

            string json = JsonConvert.SerializeObject(new
            {
                Id_Empresa = idEmpresa
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync(URL, content);
            if (response.IsSuccessStatusCode)
            {
                var JsonResult = response.Content.ReadAsStringAsync();
                Produto d = JsonConvert.DeserializeObject<Produto>(JsonResult.Result.ToString());
                Produto[] produtos = JsonConvert.DeserializeObject<Produto[]>(d.d);

                MessagingCenter.Send<Produto[]>(produtos, "SucessoBuscarProduto");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaBuscarProduto");
            }
        }
    }
}

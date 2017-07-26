using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ControleEstoque.Models;
using Xamarin.Forms;

namespace ControleEstoque.Services
{
    class DadosEntradaSaidaService
    {
        const string URLEntrada = "http://teste-ipragas.uni5.net/Sistema/Logica_Estoque/ControleEstoque.asmx/pesquisarQntEstoqueEntrada";
        const string URLSaida = "http://teste-ipragas.uni5.net/Sistema/Logica_Estoque/ControleEstoque.asmx/pesquisarQntEstoqueSaida";

        public async Task BuscarEntradaPorAno()
        {
            HttpClient cliente = new HttpClient();

            string json = JsonConvert.SerializeObject(new
            {
                Id_Empresa = 3,
                ano = "2017"
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync(URLEntrada, content);
            if (response.IsSuccessStatusCode)
            {
                var JsonResult = response.Content.ReadAsStringAsync();
                MesEstoque d = JsonConvert.DeserializeObject<MesEstoque>(JsonResult.Result.ToString());
                MesEstoque entrada = JsonConvert.DeserializeObject<MesEstoque>(d.d);

                MessagingCenter.Send<MesEstoque>(entrada, "SucessoBuscarEntradaMes");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaBuscarEntradaMes");
            }
        }

        public async Task BuscarSaidaPorAno()
        {
            HttpClient cliente = new HttpClient();

            string json = JsonConvert.SerializeObject(new
            {
                Id_Empresa = 3,
                ano = "2017"
            });

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync(URLSaida, content);
            if (response.IsSuccessStatusCode)
            {
                var JsonResult = response.Content.ReadAsStringAsync();
                MesEstoque d = JsonConvert.DeserializeObject<MesEstoque>(JsonResult.Result.ToString());
                MesEstoque saida = JsonConvert.DeserializeObject<MesEstoque>(d.d);

                MessagingCenter.Send<MesEstoque>(saida, "SucessoBuscarSaidaMes");
            }
            else
            {
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaBuscarSaidaMes");
            }
        }
    }
}

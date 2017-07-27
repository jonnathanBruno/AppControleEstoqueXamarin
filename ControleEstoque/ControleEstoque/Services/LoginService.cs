using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ControleEstoque.Models;
using ControleEstoque;
using Xamarin.Forms;
using System.Xml;
using System.Net.Http.Headers;
namespace ControleEstoque.Services
{
    class LoginService
    {
        const string URL = "http://teste-ipragas.uni5.net/Sistema/Logica_Login/Login.asmx/fazerLogin";

        public async Task FazerLogin(Login login)
        {
            HttpClient cliente = new HttpClient();

            string json = JsonConvert.SerializeObject(new
            {
                dominio = login.dominio,
                email = login.email,
                senha = login.senha
            });

            string postData = JsonConvert.SerializeObject(new
            {
                entrada = json
            });

            var content = new StringContent(postData, Encoding.UTF8, "application/json");

            var response = await cliente.PostAsync(URL, content);
            if (response.IsSuccessStatusCode)
            {
                var JsonResult = response.Content.ReadAsStringAsync();
                Empresa d = JsonConvert.DeserializeObject<Empresa>(JsonResult.Result.ToString());

                if (d.d != "Inativo")
                {
                    Empresa[] empresa = JsonConvert.DeserializeObject<Empresa[]>(d.d);
                    MessagingCenter.Send<Empresa[]>(empresa, "SucessoLogin");
                }
                else
                {
                    MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaLogin");
                }
            }
            else { 
                MessagingCenter.Send<ArgumentException>(new ArgumentException(), "FalhaLogin");
            }

        }
    }
}

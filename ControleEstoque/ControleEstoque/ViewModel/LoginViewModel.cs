using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ControleEstoque.Services;
using ControleEstoque.Models;
using Xamarin.Forms;

namespace ControleEstoque.ViewModel
{
    class LoginViewModel
    {
        private string usuario;
        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set
            {
                senha = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }

        private string dominio;
        public string Dominio
        {
            get { return dominio; }
            set
            {
                dominio = value;
                ((Command)EntrarCommand).ChangeCanExecute();
            }
        }



        public ICommand EntrarCommand { get; private set; }

        public LoginViewModel()
        {
            EntrarCommand = new Command(async () =>
            {
                var loginService = new LoginService();
                await loginService.FazerLogin(new Login(usuario, senha, dominio));
            }, () =>
            {
                return !string.IsNullOrEmpty(usuario)
                        && !string.IsNullOrEmpty(senha)
                         && !string.IsNullOrEmpty(dominio);
            });
        }
    }
}

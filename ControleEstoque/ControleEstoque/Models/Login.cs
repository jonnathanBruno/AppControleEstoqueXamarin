using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Models
{
    class Login
    {
        public string email { get; private set; }
        public string senha { get; private set; }
        public string dominio { get; private set; }


        public Login(string email, string senha, string dominio)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException(nameof(email));

            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException(nameof(senha));

            if (string.IsNullOrEmpty(dominio))
                throw new ArgumentException(nameof(dominio));

            this.email = email;
            this.senha = senha;
            this.dominio = dominio;
        }
    }
}

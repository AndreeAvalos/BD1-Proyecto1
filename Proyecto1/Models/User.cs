using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class User
    {
        private string usuario, password;
        private int tipo;

        public User(string usuario, string password, int tipo)
        {
            this.usuario = usuario;
            this.password = password;
            this.tipo = tipo;
        }

        public string Usuario { get => usuario; set => usuario = value; }
        public string Password { get => password; set => password = value; }
        public int Tipo { get => tipo; set => tipo = value; }
    }
}

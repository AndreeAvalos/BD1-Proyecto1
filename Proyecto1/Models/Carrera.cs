using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Carrera
    {
        private string nombre, admin;

        public Carrera(string nombre, string admin)
        {
            this.nombre = nombre;
            this.admin = admin;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Admin { get => admin; set => admin = value; }
    }
}

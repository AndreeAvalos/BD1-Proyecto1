using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Carrera
    {
        private int id_carrera;
        private string nombre, admin;

        public Carrera(int id_carrera, string nombre, string admin)
        {
            this.id_carrera = id_carrera;
            this.nombre = nombre;
            this.admin = admin;
        }

        public int Id_carrera { get => id_carrera; set => id_carrera = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Admin { get => admin; set => admin = value; }
    }
}

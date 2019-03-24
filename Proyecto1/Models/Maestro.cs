using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Maestro
    {
        private string nombres, telefono, direccion, correo, fecha_nacimiento, password;
        private int dpi;

        public Maestro(string nombres, string telefono, string direccion, string correo, string fecha_nacimiento, string password, int dpi)
        {
            this.nombres = nombres;
            this.telefono = telefono;
            this.direccion = direccion;
            this.correo = correo;
            this.fecha_nacimiento = fecha_nacimiento;
            this.password = password;
            this.dpi = dpi;
        }

        public string Nombres { get => nombres; set => nombres = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public string Password { get => password; set => password = value; }
        public int Dpi { get => dpi; set => dpi = value; }
    }
}

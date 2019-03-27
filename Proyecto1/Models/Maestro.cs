using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Maestro
    {
        private int id_maestro;
        private string nombres, telefono, direccion, correo, fecha_nacimiento, password, ciclo, dpi, admin;
        private byte[] foto;

        public Maestro(int id_maestro, string nombres, string telefono, string direccion, string correo, string fecha_nacimiento, string dpi, byte[] foto, string password, string ciclo, string admin)
        {
            this.id_maestro = id_maestro;
            this.nombres = nombres;
            this.telefono = telefono;
            this.direccion = direccion;
            this.correo = correo;
            this.fecha_nacimiento = fecha_nacimiento;
            this.password = password;
            this.dpi = dpi;
            this.foto = foto;
            this.ciclo = ciclo;
            this.admin = admin;
        }

        public string Nombres { get => nombres; set => nombres = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public string Password { get => password; set => password = value; }
        public string Dpi { get => dpi; set => dpi = value; }
        public byte[] Foto { get => foto; set => foto = value; }
        public string Ciclo { get => ciclo; set => ciclo = value; }
        public string Admin { get => admin; set => admin = value; }
        public int Id_maestro { get => id_maestro; set => id_maestro = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Alumno
    {
        private string nombre, apellido, telefono, tel_tutor, direccion, correo, fecha_nacimiento, password;
        private int Partida_nacimiento;

        public Alumno(string nombre, string apellido, string telefono, string tel_tutor, string direccion, string correo, string fecha_nacimiento, string password, int partida_nacimiento)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
            this.tel_tutor = tel_tutor;
            this.direccion = direccion;
            this.correo = correo;
            this.fecha_nacimiento = fecha_nacimiento;
            this.password = password;
            Partida_nacimiento = partida_nacimiento;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Tel_tutor { get => tel_tutor; set => tel_tutor = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
        public string Password { get => password; set => password = value; }
        public int Partida_nacimiento1 { get => Partida_nacimiento; set => Partida_nacimiento = value; }
    }
}

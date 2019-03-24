using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Respuesta
    {
        private string opcion, estado;

        public Respuesta(string opcion, string estado)
        {
            this.opcion = opcion;
            this.estado = estado;
        }

        public string Opcion { get => opcion; set => opcion = value; }
        public string Estado { get => estado; set => estado = value; }
    }
}

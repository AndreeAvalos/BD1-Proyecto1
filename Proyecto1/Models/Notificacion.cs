using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Notificacion
    {
        private string titulo, contenido, fecha;

        public Notificacion(string titulo, string contenido, string fecha)
        {
            this.titulo = titulo;
            this.contenido = contenido;
            this.fecha = fecha;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Contenido { get => contenido; set => contenido = value; }
        public string Fecha { get => fecha; set => fecha = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Actividad
    {
        private string titulo, descripcion, fecha_publicacion, fecha_entrega;
        private int ponderacion, id_maestro, id_materia;

        public Actividad(string titulo, string descripcion, string fecha_publicacion, string fecha_entrega, int ponderacion, int id_maestro, int id_materia)
        {
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fecha_publicacion = fecha_publicacion;
            this.fecha_entrega = fecha_entrega;
            this.ponderacion = ponderacion;
            this.id_maestro = id_maestro;
            this.id_materia = id_materia;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Fecha_publicacion { get => fecha_publicacion; set => fecha_publicacion = value; }
        public string Fecha_entrega { get => fecha_entrega; set => fecha_entrega = value; }
        public int Ponderacion { get => ponderacion; set => ponderacion = value; }
        public int Id_maestro { get => id_maestro; set => id_maestro = value; }
        public int Id_materia { get => id_materia; set => id_materia = value; }
    }
}

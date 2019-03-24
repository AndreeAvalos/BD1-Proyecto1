using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class MaterialApoyo
    {
        private string titulo, fecha, enlace, descripcion;
        private int id_maestro, id_materia;

        public MaterialApoyo(string titulo, string fecha, string enlace, string descripcion, int id_maestro, int id_materia)
        {
            this.titulo = titulo;
            this.fecha = fecha;
            this.enlace = enlace;
            this.descripcion = descripcion;
            this.id_maestro = id_maestro;
            this.id_materia = id_materia;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public string Enlace { get => enlace; set => enlace = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Id_maestro { get => id_maestro; set => id_maestro = value; }
        public int Id_materia { get => id_materia; set => id_materia = value; }
    }
}

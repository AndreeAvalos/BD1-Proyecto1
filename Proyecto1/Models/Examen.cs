using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Examen
    {
        private string fecha_publicacion, hora_inicio, hora_fin;
        private int d_maestro, id_materia;

        public Examen(string fecha_publicacion, string hora_inicio, string hora_fin, int d_maestro, int id_materia)
        {
            this.fecha_publicacion = fecha_publicacion;
            this.hora_inicio = hora_inicio;
            this.hora_fin = hora_fin;
            this.d_maestro = d_maestro;
            this.id_materia = id_materia;
        }

        public string Fecha_publicacion { get => fecha_publicacion; set => fecha_publicacion = value; }
        public string Hora_inicio { get => hora_inicio; set => hora_inicio = value; }
        public string Hora_fin { get => hora_fin; set => hora_fin = value; }
        public int D_maestro { get => d_maestro; set => d_maestro = value; }
        public int Id_materia { get => id_materia; set => id_materia = value; }
    }
}

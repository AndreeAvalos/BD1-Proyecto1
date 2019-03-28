using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Examen
    {
        private int id_examen;
        private string fecha_publicacion, hora_inicio, hora_fin;
        private int id_maestro, id_materia;
        private string titulo, descripcion;
        private List<int> lst_asignados;

        public Examen(int id_examen, string fecha_publicacion, string hora_inicio, string hora_fin, int id_maestro, int id_materia, string titulo, string descripcion, List<int> lst_asignados)
        {
            this.id_examen = id_examen;
            this.fecha_publicacion = fecha_publicacion;
            this.hora_inicio = hora_inicio;
            this.hora_fin = hora_fin;
            this.id_maestro = id_maestro;
            this.id_materia = id_materia;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.lst_asignados = lst_asignados;
        }

        public int Id_examen { get => id_examen; set => id_examen = value; }
        public string Fecha_publicacion { get => fecha_publicacion; set => fecha_publicacion = value; }
        public string Hora_inicio { get => hora_inicio; set => hora_inicio = value; }
        public string Hora_fin { get => hora_fin; set => hora_fin = value; }
        public int Id_maestro { get => id_maestro; set => id_maestro = value; }
        public int Id_materia { get => id_materia; set => id_materia = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public List<int> Lst_asignados { get => lst_asignados; set => lst_asignados = value; }
    }
}

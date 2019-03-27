using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Actividad
    {
        private string titulo, descripcion, fecha_publicacion, fecha_entrega;
        private int  id_maestro, id_materia, id_actividad;
        private double ponderacion;
        private List<int> lst_asignados;

        public Actividad(int id_actividad, string titulo, string descripcion, string fecha_publicacion, string fecha_entrega, double ponderacion, int id_maestro, int id_materia, List<int> lst)
        {
            this.id_actividad = id_actividad;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fecha_publicacion = fecha_publicacion;
            this.fecha_entrega = fecha_entrega;
            this.ponderacion = ponderacion;
            this.id_maestro = id_maestro;
            this.id_materia = id_materia;
            this.lst_asignados = lst;
        }

        public Actividad(int id_actividad, string titulo, string descripcion, string fecha_publicacion, string fecha_entrega, double ponderacion, int id_maestro, int id_materia)
        {
            this.id_actividad = id_actividad;
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
        public double Ponderacion { get => ponderacion; set => ponderacion = value; }
        public int Id_maestro { get => id_maestro; set => id_maestro = value; }
        public int Id_materia { get => id_materia; set => id_materia = value; }
        public int Id_actividad { get => id_actividad; set => id_actividad = value; }
        public List<int> Lst_asignados { get => lst_asignados; set => lst_asignados = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Publicacion
    {
        private int id_publicacion;
        private string titulo, descripcion, fecha;
        private int id_maestro,id_calificacion,id_examen,id_actividad,id_material, id_tipo;

        public Publicacion(int id_publicacion, string titulo, string descripcion, string fecha, int id_maestro, int id_calificacion, int id_examen, int id_actividad, int id_material, int id_tipo)
        {
            this.id_publicacion = id_publicacion;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.fecha = fecha;
            this.id_maestro = id_maestro;
            this.id_calificacion = id_calificacion;
            this.id_examen = id_examen;
            this.id_actividad = id_actividad;
            this.id_material = id_material;
            this.id_tipo = id_tipo;
        }



        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int Id_maestro { get => id_maestro; set => id_maestro = value; }
        public int Id_calificacion { get => id_calificacion; set => id_calificacion = value; }
        public int Id_examen { get => id_examen; set => id_examen = value; }
        public int Id_actividad { get => id_actividad; set => id_actividad = value; }
        public int Id_material { get => id_material; set => id_material = value; }
        public int Id_tipo { get => id_tipo; set => id_tipo = value; }
        public int Id_publicacion { get => id_publicacion; set => id_publicacion = value; }
    }
}

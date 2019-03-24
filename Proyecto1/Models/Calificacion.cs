using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Calificacion
    {
        private string descripcion;
        private int nota, id_asignacion_examen, id_asignacion_actividad, id_tipo;

        public Calificacion(string descripcion, int nota, int id_asignacion_examen, int id_asignacion_actividad, int id_tipo)
        {
            this.descripcion = descripcion;
            this.nota = nota;
            this.id_asignacion_examen = id_asignacion_examen;
            this.id_asignacion_actividad = id_asignacion_actividad;
            this.id_tipo = id_tipo;
        }

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Nota { get => nota; set => nota = value; }
        public int Id_asignacion_examen { get => id_asignacion_examen; set => id_asignacion_examen = value; }
        public int Id_asignacion_actividad { get => id_asignacion_actividad; set => id_asignacion_actividad = value; }
        public int Id_tipo { get => id_tipo; set => id_tipo = value; }
    }
}

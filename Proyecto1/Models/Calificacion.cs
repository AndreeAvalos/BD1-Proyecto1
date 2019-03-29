using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Calificacion
    {
        private int id_calificacion;
        private string descripcion;
        private double nota;
        private int id_asignacion_examen, id_asignacion_actividad, id_tipo;

        public Calificacion(int id_calificacion, string descripcion, double nota, int id_asignacion_examen, int id_asignacion_actividad, int id_tipo)
        {
            this.id_calificacion = id_calificacion;
            this.descripcion = descripcion;
            this.nota = nota;
            this.id_asignacion_examen = id_asignacion_examen;
            this.id_asignacion_actividad = id_asignacion_actividad;
            this.id_tipo = id_tipo;
        }

        public int Id_calificacion { get => id_calificacion; set => id_calificacion = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Nota { get => nota; set => nota = value; }
        public int Id_asignacion_examen { get => id_asignacion_examen; set => id_asignacion_examen = value; }
        public int Id_asignacion_actividad { get => id_asignacion_actividad; set => id_asignacion_actividad = value; }
        public int Id_tipo { get => id_tipo; set => id_tipo = value; }
    }
}


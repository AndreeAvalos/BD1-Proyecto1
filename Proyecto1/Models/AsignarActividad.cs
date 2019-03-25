using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class AsignarActividad
    {
        private string titulo, descripcion, observacion, estado, nombre;
        private int id_actividad;
        private double nota, ponderacion;

        public AsignarActividad(int id_actividad, string titulo, string descripcion, double ponderacion, string nombre, double nota, string observacion, string estado)
        {
            this.id_actividad = id_actividad;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.ponderacion = ponderacion;
            this.nombre = nombre;
            this.nota = nota;
            this.observacion = observacion;
            this.estado = estado;
        }

        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Observacion { get => observacion; set => observacion = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id_actividad { get => id_actividad; set => id_actividad = value; }
        public double Ponderacion { get => ponderacion; set => ponderacion = value; }
        public double Nota { get => nota; set => nota = value; }
    }
}

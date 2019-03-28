using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class AsignarExamen
    {

        private int id_AE, id_examen;
        private string titulo, descripcion, nombre;
        private double nota;

        public AsignarExamen(int id_AE, int id_examen, string titulo, string descripcion, string nombre, double nota)
        {
            this.id_AE = id_AE;
            this.id_examen = id_examen;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.nombre = nombre;
            this.nota = nota;
        }

        public int Id_AE { get => id_AE; set => id_AE = value; }
        public int Id_examen { get => id_examen; set => id_examen = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public double Nota { get => nota; set => nota = value; }
    }
}

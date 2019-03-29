using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class MostrarNota
    {
        private int carnet, id_materia;
        private string titulo;
        private double nota;
        private string descripcion;

        public MostrarNota(int carnet, int id_materia, string titulo, double nota, string descripcion)
        {
            this.carnet = carnet;
            this.id_materia = id_materia;
            this.titulo = titulo;
            this.nota = nota;
            this.descripcion = descripcion;
        }

        public int Carnet { get => carnet; set => carnet = value; }
        public int Id_materia { get => id_materia; set => id_materia = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public double Nota { get => nota; set => nota = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
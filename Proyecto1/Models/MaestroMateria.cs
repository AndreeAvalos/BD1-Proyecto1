using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class MaestroMateria
    {
        private int id_asignacionActividad, carnet;
        private string titulo, archivo;

        public MaestroMateria(int id_asignacionActividad, int carnet, string titulo, string archivo)
        {
            this.id_asignacionActividad = id_asignacionActividad;
            this.carnet = carnet;
            this.titulo = titulo;
            this.archivo = archivo;
        }

        public int Id_asignacionActividad { get => id_asignacionActividad; set => id_asignacionActividad = value; }
        public int Carnet { get => carnet; set => carnet = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Archivo { get => archivo; set => archivo = value; }
    }
}

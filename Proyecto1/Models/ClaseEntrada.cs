using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class ClaseEntrada
    {
        private int carnet, id_examen_actividad;

        public ClaseEntrada(int carnet, int id_examen_actividad)
        {
            this.carnet = carnet;
            this.id_examen_actividad = id_examen_actividad;
        }

        public int Carnet { get => carnet; set => carnet = value; }
        public int Id_examen_actividad { get => id_examen_actividad; set => id_examen_actividad = value; }
    }
}
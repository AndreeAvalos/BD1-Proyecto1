using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class AsignarExamen
    {
        private int id_examen, carnet;

        public AsignarExamen(int id_examen, int carnet)
        {
            this.id_examen = id_examen;
            this.carnet = carnet;
        }

        public int Id_examen { get => id_examen; set => id_examen = value; }
        public int Carnet { get => carnet; set => carnet = value; }
    }
}

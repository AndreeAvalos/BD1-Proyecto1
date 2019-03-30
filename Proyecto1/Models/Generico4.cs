using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Generico4
    {
        private int registro, materia;

        public Generico4(int registro, int materia)
        {
            this.registro = registro;
            this.materia = materia;
        }

        public int Registro { get => registro; set => registro = value; }
        public int Materia { get => materia; set => materia = value; }
    }
}

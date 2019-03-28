using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class AsignacionC
    {
        private string profesor, grado, carrera, ciclo;

        public AsignacionC(string profesor, string grado, string carrera, string ciclo
            )
        {
            this.profesor = profesor;
            this.grado = grado;
            this.carrera = carrera;
            this.ciclo = ciclo;
        }

        public string Profesor { get => profesor; set => profesor = value; }
        public string Grado { get => grado; set => grado = value; }
        public string Carrera { get => carrera; set => carrera = value; }
        public string Ciclo { get => ciclo; set => ciclo = value; }
    }
}

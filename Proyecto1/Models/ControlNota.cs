using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class ControlNota
    {
        private string nombreMateria, fecha;
        private int nota;

        public ControlNota(string nombreMateria, string fecha, int nota)
        {
            this.nombreMateria = nombreMateria;
            this.fecha = fecha;
            this.nota = nota;
        }

        public string NombreMateria { get => nombreMateria; set => nombreMateria = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public int Nota { get => nota; set => nota = value; }
    }
}

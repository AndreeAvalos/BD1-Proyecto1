using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class AsignacionCarrera
    {
        private string admin, ciclo;
        private int id_carrera, id_grado, id_maestro;

        public AsignacionCarrera(string admin, string ciclo, int id_carrera, int id_grado, int id_maestro)
        {
            this.admin = admin;
            this.ciclo = ciclo;
            this.id_carrera = id_carrera;
            this.id_grado = id_grado;
            this.id_maestro = id_maestro;
        }

        public string Admin { get => admin; set => admin = value; }
        public string Ciclo { get => ciclo; set => ciclo = value; }
        public int Id_carrera { get => id_carrera; set => id_carrera = value; }
        public int Id_grado { get => id_grado; set => id_grado = value; }
        public int Id_maestro { get => id_maestro; set => id_maestro = value; }
    }
}

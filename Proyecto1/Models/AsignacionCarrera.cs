using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class AsignacionCarrera
    {
        private int id_AC;
        private string ciclo;
        private int id_maestro, id_carrera, id_grado;
        private string id_admin;

        public AsignacionCarrera(int id_AC, string ciclo, int id_maestro, int id_carrera, int id_grado, string id_admin)
        {
            this.id_AC = id_AC;
            this.ciclo = ciclo;
            this.id_maestro = id_maestro;
            this.id_carrera = id_carrera;
            this.id_grado = id_grado;
            this.id_admin = id_admin;
        }

        public int Id_AC { get => id_AC; set => id_AC = value; }
        public string Ciclo { get => ciclo; set => ciclo = value; }
        public int Id_maestro { get => id_maestro; set => id_maestro = value; }
        public int Id_carrera { get => id_carrera; set => id_carrera = value; }
        public int Id_grado { get => id_grado; set => id_grado = value; }
        public string Id_admin { get => id_admin; set => id_admin = value; }
    }
}

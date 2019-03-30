using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class ControlNota
    {
        private int id_control_nota;
        private string fecha;
        private double nota;
        private int carnet, idmateria;

        public ControlNota(int id_control_nota, string fecha, double nota, int carnet, int idmateria)
        {
            this.id_control_nota = id_control_nota;
            this.fecha = fecha;
            this.nota = nota;
            this.carnet = carnet;
            this.idmateria = idmateria;
        }

        public int Id_control_nota { get => id_control_nota; set => id_control_nota = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public double Nota { get => nota; set => nota = value; }
        public int Carnet { get => carnet; set => carnet = value; }
        public int Idmateria { get => idmateria; set => idmateria = value; }
    }
}

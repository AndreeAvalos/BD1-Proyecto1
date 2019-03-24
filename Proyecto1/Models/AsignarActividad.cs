using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class AsignarActividad
    {
        private string observacion, estado, archivo;
        private int id_actividad, carnet;

        public AsignarActividad(string observacion, string estado, string archivo, int id_actividad, int carnet)
        {
            this.observacion = observacion;
            this.estado = estado;
            this.archivo = archivo;
            this.id_actividad = id_actividad;
            this.carnet = carnet;
        }

        public string Observacion { get => observacion; set => observacion = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Archivo { get => archivo; set => archivo = value; }
        public int Id_actividad { get => id_actividad; set => id_actividad = value; }
        public int Carnet { get => carnet; set => carnet = value; }
    }
}

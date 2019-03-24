using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Pregunta
    {
        private string descripcion;
        private int id_examen;
        private List<Respuesta> lst_respuestas;

        public Pregunta(string descripcion, int id_examen)
        {
            this.descripcion = descripcion;
            this.id_examen = id_examen;
            this.lst_respuestas = new List<Respuesta>();
        }

        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Id_examen { get => id_examen; set => id_examen = value; }
        public List<Respuesta> Lst_respuestas { get => lst_respuestas; set => lst_respuestas = value; }
    }
}

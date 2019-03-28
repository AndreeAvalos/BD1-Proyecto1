using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Pregunta
    {
        private int id_pregunta;
        private string descripcion;
        private int id_examen;
        private List<Respuesta> lst_respuestas;

        public Pregunta(int id_pregunta, string descripcion, int id_examen, List<Respuesta> lst_respuestas)
        {
            this.id_pregunta = id_pregunta;
            this.descripcion = descripcion;
            this.id_examen = id_examen;
            this.lst_respuestas = lst_respuestas;
        }

        public int Id_pregunta { get => id_pregunta; set => id_pregunta = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Id_examen { get => id_examen; set => id_examen = value; }
        public List<Respuesta> Lst_respuestas { get => lst_respuestas; set => lst_respuestas = value; }
    }
}

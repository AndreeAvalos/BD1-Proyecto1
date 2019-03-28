using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class Respuesta
    {
        private int id_respuesta;
        private string opcion, estado;
        private int id_pregunta;
        private string respuestaP;

        public Respuesta(int id_respuesta, string opcion, string estado, int id_pregunta, string respuesta)
        {
            this.id_respuesta = id_respuesta;
            this.opcion = opcion;
            this.estado = estado;
            this.id_pregunta = id_pregunta;
            this.respuestaP = respuesta;
        }

        public int Id_respuesta { get => id_respuesta; set => id_respuesta = value; }
        public string Opcion { get => opcion; set => opcion = value; }
        public string Estado { get => estado; set => estado = value; }
        public int Id_pregunta { get => id_pregunta; set => id_pregunta = value; }
        public string RespuestaP { get => respuestaP; set => respuestaP = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class RespuestaAlumno
    {
        private int id_RA;
        private string respuesta;
        private int id_AE, id_pregunta;

        public RespuestaAlumno(int id_RA, string respuesta, int id_AE, int id_pregunta)
        {
            this.id_RA = id_RA;
            this.respuesta = respuesta;
            this.id_AE = id_AE;
            this.id_pregunta = id_pregunta;
        }

        public int Id_RA { get => id_RA; set => id_RA = value; }
        public string Respuesta { get => respuesta; set => respuesta = value; }
        public int Id_AE { get => id_AE; set => id_AE = value; }
        public int Id_pregunta { get => id_pregunta; set => id_pregunta = value; }
    }
}

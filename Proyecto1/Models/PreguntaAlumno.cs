using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Models
{
    public class PreguntaAlumno
    {
        private int id_pregunta;
        private List<RespuestaAlumno> lst_reespuestas_alumno;

        public PreguntaAlumno(int id_pregunta, List<RespuestaAlumno> lst_reespuestas_alumno)
        {
            this.id_pregunta = id_pregunta;
            this.lst_reespuestas_alumno = lst_reespuestas_alumno;
        }

        public int Id_pregunta { get => id_pregunta; set => id_pregunta = value; }
        public List<RespuestaAlumno> Lst_reespuestas_alumno { get => lst_reespuestas_alumno; set => lst_reespuestas_alumno = value; }
    }
}

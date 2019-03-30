using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;

namespace Proyecto1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionExamenController : ControllerBase
    {

        // POST: api/CalificacionExamen
        [HttpPost]
        public bool Post(Calificacion entrada)
        {
            try
            {
                
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("@nota", entrada.Nota, 4),
                    new Generico("@descripcion", entrada.Descripcion, 2),
                    new Generico("@idasignacionexamen", entrada.Id_asignacion_examen,1),
                    new Generico("@idasignacionactividad", entrada.Id_asignacion_actividad, 5),
                    new Generico("@idtipo", 4, 1)
                };
                bool salida = false;
                DateTime currentTime = DateTime.Now;
                String hora = (TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time")).ToString("HH:mm:ss");
                string fecha_actual = (TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time")).ToString();

                salida = conn.metodo_proc("CalificacionInsert", lst);

                string query = "select carnet from asignacionexamen where idasignacionexamen = " + entrada.Id_asignacion_examen + "; ";
                List<Generico2> lst1 = conn.metodo_consulta(query, 1);
                int id_maestro = Convert.ToInt32(lst1[0].Lst[0].Parametro);

                try
                {

                    lst = new List<Generico>
                {
                    new Generico("@titulo", "Calificacion-Examen", 2),
                    new Generico("@contenido", entrada.Descripcion, 2),
                    new Generico("@fecha", fecha_actual, 3),
                    new Generico("@carnet", id_maestro, 1),
                    new Generico("@idasignacionactividad", entrada.Id_asignacion_actividad, 5),
                    new Generico("@idasignacionexamen", entrada.Id_asignacion_examen, 1)
                };

                    salida = conn.metodo_proc("NotificacionInsert", lst);

                }
                catch
                {
                    return false;
                }
                return salida;
            }
            catch
            {
                return false;

            }
        }

        // PUT: api/CalificacionExamen/5
        [HttpPut("{id}")]
        public bool Put(int id, Calificacion entrada)
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                Conexion conn = new Conexion();
                entrada.Id_calificacion = id;
                List<Generico> lst = new List<Generico>
                {
                    new Generico("@idcalificacion",entrada.Id_calificacion,1),
                    new Generico("@nota", entrada.Nota, 4),
                    new Generico("@descripcion", entrada.Descripcion, 2),
                    new Generico("@idasignacionexamen", entrada.Id_asignacion_examen,1),
                    new Generico("@idasignacionactividad", entrada.Id_asignacion_actividad, 5),
                    new Generico("@idtipo", entrada.Id_tipo, 1)
                };
                return conn.metodo_proc("CalificacionUpdate", lst);
            }
            catch
            {
                return false;
            }

        }
    }
}

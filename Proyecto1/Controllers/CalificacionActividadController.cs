using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Proyecto1.Models;

namespace Proyecto1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionActividadController : ControllerBase
    {

        // GET: api/CalificacionActividad/5
        //[HttpGet("{id}", Name = "Get12")]
        //public string Get(int id)
        //{
        //    try
        //    {
        //        string query = "select asignacionactividad.carnet, actividad.idmateria, actividad.titulo ,calificacion.nota, calificacion.descripcion from calificacion  " +
        //            "inner join asignacionactividad on " +
        //            "asignacionactividad.idasignacionactividad = calificacion.idasignacionactividad " +
        //            "inner join actividad on " +
        //            "actividad.idactividad = asignacionactividad.idactividad " +
        //            "where asignacionactividad.carnet =" +entrada.Carnet+" and actividad.idmateria = "+entrada.Id_materia+";";
        //        Conexion conn = new Conexion();
        //        List<Generico2> lst1 = conn.metodo_consulta(query, 5);
        //        List<MostrarNota> lstAlumno = new List<MostrarNota>();
        //        for (int i = 0; i < lst1.Count; i++)
        //        {
        //            MostrarNota nuevo = new MostrarNota(
        //                Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
        //                Convert.ToInt32(lst1[i].Lst[1].Parametro.ToString()),
        //                lst1[i].Lst[2].Parametro.ToString(),
        //                Convert.ToDouble(lst1[i].Lst[3].Parametro.ToString()),
        //                lst1[i].Lst[4].Parametro.ToString()
        //               );
        //            lstAlumno.Add(nuevo);
        //        }

        //        return JsonConvert.SerializeObject(lstAlumno);
        //    }
        //    catch { return "NO EXISTEN DATOS"; }
        //}

        // POST: api/CalificacionActividad
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
                    new Generico("@idasignacionexamen", entrada.Id_asignacion_examen,5),
                    new Generico("@idasignacionactividad", entrada.Id_asignacion_actividad, 1),
                    new Generico("@idtipo", 4, 1)
                };
                bool salida = false;
                DateTime currentTime = DateTime.Now;
                String hora = (TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time")).ToString("HH:mm:ss");
                string fecha_actual = (TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time")).ToString();
                salida = conn.metodo_proc("CalificacionInsert", lst);

                string query = "select carnet from asignacionactividad where idasignacionactividad = "+ entrada.Id_asignacion_actividad + "; ";
                List<Generico2> lst1 = conn.metodo_consulta(query, 1);
                int id_maestro = Convert.ToInt32(lst1[0].Lst[0].Parametro);

                try
                {
                    
                    lst = new List<Generico>
                {
                    new Generico("@titulo", "Calificacion-Actividad", 2),
                    new Generico("@contenido", entrada.Descripcion, 2),
                    new Generico("@fecha", fecha_actual, 3),
                    new Generico("@carnet", id_maestro, 1),
                    new Generico("@idasignacionactividad", entrada.Id_asignacion_actividad, 1),
                    new Generico("@idasignacionexamen", 1, 5)
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

        // PUT: api/CalificacionActividad/5
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
                    new Generico("@idasignacionexamen", entrada.Id_asignacion_examen,5),
                    new Generico("@idasignacionactividad", entrada.Id_asignacion_actividad, 1),
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

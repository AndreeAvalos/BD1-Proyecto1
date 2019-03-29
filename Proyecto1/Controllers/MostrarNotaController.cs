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
    public class MostrarNotaController : ControllerBase
    {
        // POST: api/MostrarNota
        [HttpPost]
        public string Post(MostrarNota entrada)
        {
            try
            {
                string query = "(select asignacionactividad.carnet, actividad.idmateria, actividad.titulo ,calificacion.nota, calificacion.descripcion from calificacion \n" +
                    "inner join asignacionactividad on \n" +
                    "asignacionactividad.idasignacionactividad = calificacion.idasignacionactividad \n" +
                    "inner join actividad on \n" +
                    "actividad.idactividad = asignacionactividad.idactividad \n" +
                    "where asignacionactividad.carnet = " + entrada.Carnet + " and actividad.idmateria =" + entrada.Id_materia + " \n" +
                    ")\n" +
                    "union\n" +
                    "(select asignacionexamen.carnet,examen.idmateria, examen.titulo,calificacion.nota, calificacion.descripcion from calificacion \n" +
                    "inner join asignacionexamen on\n" +
                    "asignacionexamen.idasignacionexamen= calificacion.idasignacionexamen\n" +
                    "inner join examen on\n" +
                    "examen.idexamen = asignacionexamen.idexamen\n" +
                    "where asignacionexamen.carnet =" + entrada.Carnet + "\n" +
                    "and examen.idmateria =" + entrada.Id_materia + "\n" +
                    ");\n";
                Conexion conn = new Conexion();
                List<Generico2> lst1 = conn.metodo_consulta(query, 5);
                List<MostrarNota> lstAlumno = new List<MostrarNota>();
                for (int i = 0; i < lst1.Count; i++)
                {
                    MostrarNota nuevo = new MostrarNota(
                        Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                         Convert.ToInt32(lst1[i].Lst[1].Parametro.ToString()),
                        lst1[i].Lst[2].Parametro.ToString(),
                        Convert.ToDouble(lst1[i].Lst[3].Parametro.ToString()),
                        lst1[i].Lst[4].Parametro.ToString()
                       );
                    lstAlumno.Add(nuevo);
                }

                return JsonConvert.SerializeObject(lstAlumno);
            }
            catch {
                return "NO HAY DATOS";
            }
        }
    }
}

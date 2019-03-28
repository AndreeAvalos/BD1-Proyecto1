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
    public class ExamenController : ControllerBase
    {
        // GET: api/Examen/5
        [HttpGet("{id}", Name = "Get5")]
        public string Get(int id)
        {
            //MaterialApoyo nuevo = new MaterialApoyo("", "", "", "", 1, 1);
            string query = "select asignacionexamen.idasignacionexamen, asignacionexamen.idexamen,examen.titulo, examen.descripcion, materia.nombre, asignacionexamen.nota from asignacionexamen \n" +
                    "inner join examen on \n" +
                    "examen.idexamen=asignacionexamen.idexamen \n" +
                    "inner join materia on\n" +
                    "examen.idmateria=materia.idmateria \n" +
                    "where asignacionexamen.carnet = " + id + ";";
            Conexion conn = new Conexion();
            List<Generico2> lst1 = conn.metodo_consulta(query, 6);
            List<AsignarExamen> lst = new List<AsignarExamen>();
            for (int i = 0; i < lst1.Count; i++)
            {
                AsignarExamen nuevo = new AsignarExamen(
                    Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                    Convert.ToInt32(lst1[i].Lst[1].Parametro.ToString()),
                    lst1[i].Lst[2].Parametro.ToString(),
                    lst1[i].Lst[3].Parametro.ToString(),
                    lst1[i].Lst[4].Parametro.ToString(),
                    Convert.ToDouble(lst1[i].Lst[5].Parametro.ToString())
                    );
                lst.Add(nuevo);
            }

            return JsonConvert.SerializeObject(lst);
        }

        // POST: api/Examen
        [HttpPost]
        public bool Post(Examen entrada)
        {
            bool salida = false;
            DateTime currentTime = DateTime.Now;
            String hora = (TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time")).ToString("HH:mm:ss");
            string fecha_actual = (TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time")).ToString();
            int cod = 0;
            try
            {
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("titulo", entrada.Titulo, 2),
                    new Generico("fechapublicacion", fecha_actual, 3),
                    new Generico("horainicio", entrada.Hora_inicio, 3),
                    new Generico("horafinal", entrada.Hora_fin, 3),
                    new Generico("descripcion", entrada.Descripcion, 2),
                    new Generico("registro", entrada.Id_maestro, 1),
                    new Generico("idmateria", entrada.Id_materia, 1)
                };
                cod = conn.Post("ExamenInsert", lst);
                salida = true;
            }
            catch
            {
                return false;

            }
            try
            {
                if (cod != -1)
                {
                    Conexion conn = new Conexion();
                    for (int i = 0; i < entrada.Lst_asignados.Count; i++)
                    {
                        List<Generico> lst = new List<Generico>
                        {
                            new Generico("nota", 0.0, 4),
                            new Generico("idexamen", cod, 1),
                            new Generico("carnet", entrada.Lst_asignados[i], 1)
                        };
                        salida = conn.metodo_proc("AsignacionExamenInsert", lst);
                    }
                }
                else
                    salida = false;
            }
            catch
            {
                salida = false;
            }

            try
            {
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("titulo", entrada.Titulo, 2),
                    new Generico("texto", entrada.Descripcion, 2),
                    new Generico("fecha", fecha_actual, 3),
                    new Generico("registro", entrada.Id_maestro, 1),
                    new Generico("idtipo", 1, 1)
                };
                lst.Add(new Generico("idcalificacion", 1, 5));
                lst.Add(new Generico("idexamen", cod, 1));
                lst.Add(new Generico("idactividad", 1, 5));
                lst.Add(new Generico("idmaterialapoyo", 1, 1));

                salida = conn.metodo_proc("PublicacionInsert", lst);
               
            }
            catch
            {
                return false;
            }
            return salida;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Conexion conn = new Conexion();
            List<Generico> lst = new List<Generico>
            {
                new Generico("idmaterialapoyo", id, 1)
            };
            return conn.metodo_proc("ExamenEliminar", lst);
        }
    }
}

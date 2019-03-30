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
    public class ControlNotaController : ControllerBase
    {


        // GET: api/ControlNota/5
        [HttpGet("{id}", Name = "Get90")]
        public string Get(int id)
        {
            try
            {

                string query = "select * from controlnota  where carnet = " + id + ";";
                Conexion conn = new Conexion();
                List<Generico2> lst1 = conn.metodo_consulta(query, 5);
                List<ControlNota> lst = new List<ControlNota>();
                for (int i = 0; i < lst1.Count; i++)
                {
                    ControlNota nuevo = new ControlNota(   
                        Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),  
                        lst1[i].Lst[1].Parametro.ToString(),  
                        Convert.ToDouble(lst1[i].Lst[2].Parametro.ToString()),  
                        Convert.ToInt32(lst1[i].Lst[3].Parametro.ToString()),     
                        Convert.ToInt32(lst1[i].Lst[4].Parametro.ToString())
                        );
                    lst.Add(nuevo);
                }



                return JsonConvert.SerializeObject(lst);
            }
            catch { return "NO EXISTEN DATOS"; }

        }

        // POST: api/ControlNota
        [HttpPost]
        public bool Post(ControlNota entrada)
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                String hora = (TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time")).ToString("HH:mm:ss");
                string fecha_actual = (TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time")).ToString();

                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("@fecha", fecha_actual, 3),
                    new Generico("@nota", entrada.Nota, 4),
                    new Generico("@carnet", entrada.Carnet, 1),
                    new Generico("@idmateria", entrada.Idmateria,1)
                };
                return conn.metodo_proc("ControlNotaInsert", lst);
            }
            catch
            {
                return false;

            }
        }

        // PUT: api/ControlNota/5
        [HttpPut("{id}")]
        public bool Put(int id, ControlNota entrada)
        {
            try
            {
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("@idcontrolnota", id, 1),
                    new Generico("@nota", entrada.Nota, 4),
                };
                return conn.metodo_proc("ControlNotaUpdate", lst);
            }
            catch
            {
                return false;

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

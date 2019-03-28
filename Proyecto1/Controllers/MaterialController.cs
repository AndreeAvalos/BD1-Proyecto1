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
    public class MaterialController : ControllerBase
    {

        // GET: api/Material/5
        [HttpGet("{id}", Name = "Get6")]
        public string Get(int id)
        {
            //MaterialApoyo nuevo = new MaterialApoyo("", "", "", "", 1, 1);
            string query = "Select * from materialapoyo\n" +
                "where registro = " + id + ";";
            Conexion conn = new Conexion();
            List<Generico2> lst1 = conn.metodo_consulta(query, 8);
            List<MaterialApoyo> lst = new List<MaterialApoyo>();
            for (int i = 0; i < lst1.Count; i++)
            {
                MaterialApoyo nuevo = new MaterialApoyo(
                    Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                    lst1[i].Lst[1].Parametro.ToString(),
                    lst1[i].Lst[2].Parametro.ToString(),
                    lst1[i].Lst[3].Parametro.ToString(),
                    lst1[i].Lst[5].Parametro.ToString(),
                    Convert.ToInt32(lst1[i].Lst[6].Parametro.ToString()),
                    Convert.ToInt32(lst1[i].Lst[7].Parametro.ToString())
                    );
                lst.Add(nuevo);
            }

            return JsonConvert.SerializeObject(lst);
        }

        // POST: api/Material
        [HttpPost]
        public int Post(MaterialApoyo entrada)
        {
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
                    new Generico("fecha", fecha_actual, 3),
                    new Generico("enlace", entrada.Enlace, 2),
                    new Generico("descripcion", entrada.Descripcion, 2),
                    new Generico("registro", entrada.Id_maestro, 1),
                    new Generico("idmateria", entrada.Id_materia, 1)
                };
                cod = conn.Post("MaterialApoyoInsert", lst);

            }
            catch
            {
                return -1;

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
                lst.Add(new Generico("idexamen", 1, 5));
                lst.Add(new Generico("idactividad", 1, 5));
                lst.Add(new Generico("idmaterialapoyo", cod, 1));

                conn.metodo_proc("PublicacionInsert", lst);
                return cod;
            }
            catch
            {
                return -1;
            }

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
            return conn.metodo_proc("MaterialApoyoEliminar", lst);

        }
    }
}

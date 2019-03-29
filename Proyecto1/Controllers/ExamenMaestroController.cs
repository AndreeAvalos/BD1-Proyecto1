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
    public class ExamenMaestroController : ControllerBase
    {

        // GET: api/ExamenMaestro/5
        [HttpGet("{id}", Name = "Get16")]
        public string Get(int id)
        {
            string query = "select * from examen where registro ="+id+"";
            try
            {
                Conexion conn = new Conexion();
                List<Generico2> lst1 = conn.metodo_consulta(query, 8);
                List<Examen> lst = new List<Examen>();
                for (int i = 0; i < lst1.Count; i++)
                {
                    Examen nuevo = new Examen(
                        Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                        lst1[i].Lst[1].Parametro.ToString(),
                        lst1[i].Lst[2].Parametro.ToString(),
                        lst1[i].Lst[3].Parametro.ToString(),
                        Convert.ToInt32(lst1[i].Lst[4].Parametro.ToString()),
                        Convert.ToInt32(lst1[i].Lst[5].Parametro.ToString()),
                        lst1[i].Lst[6].Parametro.ToString(),
                        lst1[i].Lst[7].Parametro.ToString(), 
                        null
                        );
                    lst.Add(nuevo);
                }

                return JsonConvert.SerializeObject(lst);

            }
            catch {
                return "NO HAY DATOS";
            }
        }
    }
}

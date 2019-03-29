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
    public class NotificacionController : ControllerBase
    {

        // GET: api/Notificacion/5
        [HttpGet("{id}", Name = "Get30")]
        public string Get(int id)
        {
            string query = "select titulo,contenido,fecha from notificacion where carnet = " + id + ";";
            Conexion conn = new Conexion();
            List<Generico2> lst1 = conn.metodo_consulta(query, 3);
            List<Notificacion> lst = new List<Notificacion>();
            for (int i = 0; i < lst1.Count; i++)
            {
                Notificacion nuevo = new Notificacion(
                    lst1[i].Lst[0].Parametro.ToString(),
                    lst1[i].Lst[1].Parametro.ToString(),
                    lst1[i].Lst[2].Parametro.ToString()
                    );
                lst.Add(nuevo);
            }

            return JsonConvert.SerializeObject(lst);
        }
    }
}

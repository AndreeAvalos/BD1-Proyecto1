using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    public class ActividadMaestroController : ControllerBase
    {
        private string cadenaconexion = "Server=tcp:serverp1.database.windows.net,1433;Initial Catalog=Proyecto1;Persist Security Info=False;User ID=bases1;Password=2019DBp1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";


        // GET: api/ActividadMaestro/5
        [HttpGet("{id}", Name = "Get11")]
        public string Get(int id)
        {
            try {
                Conexion conn = new Conexion();
                string query = "select * from actividad where registro=" + id + ";";
                List<Generico2> lst1 = conn.metodo_consulta(query, 9);
                List<Actividad> lst = new List<Actividad>();
                for (int i = 0; i < lst1.Count; i++)
                {
                    Actividad nuevo = new Actividad(Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                        lst1[i].Lst[1].Parametro.ToString(),
                        lst1[i].Lst[2].Parametro.ToString(),
                        lst1[i].Lst[3].Parametro.ToString(),
                        lst1[i].Lst[6].Parametro.ToString(),
                        Convert.ToDouble(lst1[i].Lst[5].Parametro.ToString()),
                        Convert.ToInt32(lst1[i].Lst[7].Parametro.ToString()),
                        Convert.ToInt32(lst1[i].Lst[8].Parametro.ToString()),
                        null
                        );
                    lst.Add(nuevo);
                }
                return JsonConvert.SerializeObject(lst);
            } catch {
                return "NULL";
            }
        }
    }
}

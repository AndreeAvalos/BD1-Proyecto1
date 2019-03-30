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
    public class ActividadesMaestroMateriaController : ControllerBase
    {
        // GET: api/ActividadesMaestroMateria
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ActividadesMaestroMateria/5
        [HttpGet("{id}", Name = "Get50")]
        public string Get(int id)
        {
            Generico4 nuevo = new Generico4(1,1);
            return JsonConvert.SerializeObject(nuevo);
        }

        // POST: api/ActividadesMaestroMateria
        [HttpPost]
        public string Post(Generico4 entrada)
        {
            try { 
            string query = "select asignacionactividad.idasignacionactividad, asignacionactividad.carnet, actividad.titulo, asignacionactividad.archivo from asignacionactividad " +
                "inner join actividad on " +
                "actividad.idactividad = asignacionactividad.idactividad " +
                "where actividad.registro =" + entrada.Registro + " " +
                "and actividad.idmateria =" + entrada.Materia + ";";
            Conexion conn = new Conexion();
            List<Generico2> lst1 = conn.metodo_consulta(query, 4);
            List<MaestroMateria> lstAlumno = new List<MaestroMateria>();
            for (int i = 0; i < lst1.Count; i++)
            {
                MaestroMateria nuevo = new MaestroMateria(
                    Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                     Convert.ToInt32(lst1[i].Lst[1].Parametro.ToString()),
                    lst1[i].Lst[2].Parametro.ToString(),
                    lst1[i].Lst[3].Parametro.ToString()
                   );
                lstAlumno.Add(nuevo);
            }

            return JsonConvert.SerializeObject(lstAlumno);
        }
            catch {
                return "NO HAY DATOS";
            
            }
}

    // PUT: api/ActividadesMaestroMateria/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE: api/ApiWithActions/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
}

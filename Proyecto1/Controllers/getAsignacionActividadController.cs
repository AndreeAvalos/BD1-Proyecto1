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
    public class getAsignacionActividadController : ControllerBase
    {

        // POST: api/getAsignacionActividad
        [HttpPost]
        public int Post(ClaseEntrada entrada)
        {
            string query = "select idasignacionactividad from asignacionactividad \n" +
                " where carnet = " + entrada.Carnet + " and idactividad = " + entrada.Id_examen_actividad + ";";
            try
            {
                Conexion conn = new Conexion();
                List<Generico2> lst1 = conn.metodo_consulta(query, 1);
                return Convert.ToInt32(lst1[0].Lst[0].Parametro.ToString());
            }
            catch
            {
                return -1;
            }
        }


    }
}

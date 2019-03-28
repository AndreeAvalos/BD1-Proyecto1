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
    public class AsignacionCarreraController : ControllerBase
    {
        // GET: api/AsignacionCarrera
        [HttpGet]
        public string Get()
        {
            try
            {
                string query = "select maestro.nombres,grado.nombre, carrera.nombre, asignacioncarrera.ciclo from asignacioncarrera " +
                    " inner join maestro on" +
                    " maestro.registro = asignacioncarrera.registro " +
                    "inner join grado on " +
                    "grado.idgrado = asignacioncarrera.idgrado" +
                    " inner join carrera on " +
                    "carrera.idcarrera = asignacioncarrera.idcarrera ;";
                Conexion conn = new Conexion();
                List<Generico2> lst1 = conn.metodo_consulta(query, 4);
                List<AsignacionC> lstAlumno = new List<AsignacionC>();
                for (int i = 0; i < lst1.Count; i++)
                {
                    AsignacionC nuevo = new AsignacionC(
                        lst1[i].Lst[0].Parametro.ToString(),
                        lst1[i].Lst[1].Parametro.ToString(),
                        lst1[i].Lst[2].Parametro.ToString(),
                        lst1[i].Lst[3].Parametro.ToString()
                       );
                    lstAlumno.Add(nuevo);
                }

                return JsonConvert.SerializeObject(lstAlumno);
            }
            catch { return "NO EXISTEN DATOS"; }
        }

        // POST: api/AsignacionCarrera
        [HttpPost]
        public bool Post(AsignacionCarrera entrada)
        {
            try
            {
                DateTime currentTime = DateTime.Now;
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("ciclo", currentTime.Year.ToString(), 2),
                    new Generico("idadmin", entrada.Id_admin, 2),
                    new Generico("registro", entrada.Id_maestro,1),
                    new Generico("idgrado", entrada.Id_grado, 1),
                    new Generico("idcarrera", entrada.Id_carrera, 1)

                };

                return conn.metodo_proc("AsignacionCarreraInsert", lst);
            }
            catch
            {
                return false;

            }
        }

    }
}

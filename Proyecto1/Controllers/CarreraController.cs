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
    public class CarreraController : ControllerBase
    {
        // GET: api/Carrera
        [HttpGet]
        public string Get()
        {
            try
            {
                string query = "select * from carrera ;";
                Conexion conn = new Conexion();
                List<Generico2> lst1 = conn.metodo_consulta(query, 4);
                List<Carrera> lstAlumno = new List<Carrera>();
                for (int i = 0; i < lst1.Count; i++)
                {
                    Carrera nuevo = new Carrera(
                        Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                        lst1[i].Lst[1].Parametro.ToString(),
                        lst1[i].Lst[3].Parametro.ToString()
                       );
                    lstAlumno.Add(nuevo);
                }

                return JsonConvert.SerializeObject(lstAlumno);
            }
            catch { return "NO EXISTEN DATOS"; }
        }

        // GET: api/Carrera/5
        [HttpGet("{id}", Name = "Get8")]
        public string Get(int id)
        {
            try
            {
                string query = "select * from carrera " +
                    "where idcarrera ="+id+";";
                Conexion conn = new Conexion();
                List<Generico2> lst1 = conn.metodo_consulta(query, 4);
                int i = 0;
                Carrera nuevo = new Carrera(
                    Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                    lst1[i].Lst[1].Parametro.ToString(),
                    lst1[i].Lst[3].Parametro.ToString()
                   );


                return JsonConvert.SerializeObject(nuevo);
            }
            catch { return "NO EXISTEN DATOS"; }
        }

        // POST: api/Carrera
        [HttpPost]
        public bool Post(Carrera entrada)
        {
            try
            {
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("nombre", entrada.Nombre, 2),
                    new Generico("idadmin", entrada.Admin, 2),

                };

                return conn.metodo_proc("CarreraInsert", lst);
            }
            catch
            {
                return false;

            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            Conexion conn = new Conexion();
            List<Generico> lst = new List<Generico>
            {
                new Generico("idcarrera", id, 1)
            };
            return conn.metodo_proc("CarreraEliminar", lst);
        }
    }
}

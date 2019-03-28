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
    public class AlumnoController : ControllerBase
    {
        // GET: api/Alumno
        [HttpGet]
        public string Get()
        {
            try
            {
                string query = "Select * from alumno;";
                Conexion conn = new Conexion();
                List<Generico2> lst1 = conn.metodo_consulta(query, 11);
                List<Alumno> lstAlumno = new List<Alumno>();
                for (int i = 0; i < lst1.Count; i++)
                {
                    Alumno nuevo = new Alumno(
                        Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                        lst1[i].Lst[1].Parametro.ToString(),
                        lst1[i].Lst[2].Parametro.ToString(),
                        lst1[i].Lst[3].Parametro.ToString(),
                        lst1[i].Lst[4].Parametro.ToString(),
                        lst1[i].Lst[5].Parametro.ToString(),
                        lst1[i].Lst[6].Parametro.ToString(),
                        lst1[i].Lst[7].Parametro.ToString(),
                        lst1[i].Lst[8].Parametro.ToString(),
                        lst1[i].Lst[9].Parametro.ToString(),
                        lst1[i].Lst[10].Parametro.ToString()
                        );
                    lstAlumno.Add(nuevo);
                }

                return JsonConvert.SerializeObject(lstAlumno);
            }
            catch { return "NO EXISTEN DATOS"; }

        }

        // GET: api/Alumno/5
        [HttpGet("{id}", Name = "Get3")]
        public string Get(int id)
        {
            try
            {
                string query = "Select * from alumno\n" +
                    "where carnet=" + id + ";";
                Conexion conn = new Conexion();
                List<Generico2> lst1 = conn.metodo_consulta(query, 11);
                int i = 0;
                Alumno nuevo = new Alumno(
                    Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                    lst1[i].Lst[1].Parametro.ToString(),
                    lst1[i].Lst[2].Parametro.ToString(),
                    lst1[i].Lst[3].Parametro.ToString(),
                    lst1[i].Lst[4].Parametro.ToString(),
                    lst1[i].Lst[5].Parametro.ToString(),
                    lst1[i].Lst[6].Parametro.ToString(),
                    lst1[i].Lst[7].Parametro.ToString(),
                    lst1[i].Lst[8].Parametro.ToString(),
                    lst1[i].Lst[9].Parametro.ToString(),
                    lst1[i].Lst[10].Parametro.ToString()
                    );

                return JsonConvert.SerializeObject(nuevo);
            }
            catch { return "NO EXISTEN DATOS"; }

        }

        // POST: api/Alumno
        [HttpPost]
        public int Post(Alumno entrada)
        {
            try
            {
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("nombres", entrada.Nombre, 2),
                    new Generico("telefono", entrada.Telefono, 2),
                    new Generico("direccion", entrada.Direccion, 2),
                    new Generico("email", entrada.Correo, 2),
                    new Generico("fechanacimiento", entrada.Fecha_nacimiento, 3),
                    new Generico("nopartidanac", entrada.Partida_nacimiento, 2),
                    new Generico("foto","", 2),
                    new Generico("password", entrada.Password, 2),
                    new Generico("apellidos", entrada.Apellido, 2),
                    new Generico("telefonotutor", entrada.Tel_tutor, 2)
                };

                return conn.Post("AlumnoInsert", lst);
            }
            catch
            {
                return -1;

            }
        }

        // PUT: api/Alumno/5
        [HttpPut("{id}")]
        public bool Put(int id, Alumno entrada)
        {
            entrada.Carnet = id;
            try
            {
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("carnet",entrada.Carnet,1),
                    new Generico("nombres", entrada.Nombre, 2),
                    new Generico("telefono", entrada.Telefono, 2),
                    new Generico("direccion", entrada.Direccion, 2),
                    new Generico("email", entrada.Correo, 2),
                    new Generico("fechanacimiento", entrada.Fecha_nacimiento, 3),
                    new Generico("nopartidanac", entrada.Partida_nacimiento, 2),
                    new Generico("foto", "", 2),
                    new Generico("password", entrada.Password, 2),
                    new Generico("apellidos", entrada.Apellido, 2),
                    new Generico("telefonotutor", entrada.Tel_tutor, 2)
                };

                return conn.metodo_proc("AlumnoUpdate", lst);
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
                new Generico("carnet", id, 1)
            };
            return conn.metodo_proc("AlumnnoEliminar", lst);
        }
    }
}

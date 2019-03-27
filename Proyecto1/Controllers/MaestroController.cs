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
    public class MaestroController : ControllerBase
    {
        // GET: api/Maestro
        [HttpGet]
        public string Get()
        {
            string query = "Select * from maestro;";
            Conexion conn = new Conexion();
            byte[] foto = { 0, 1, 1, 1, 1, 1, 1, 1, 1 };
            List<Generico2> lst1 = conn.metodo_consulta(query, 11);
            List<Maestro> lstmaestro = new List<Maestro>();
            for (int i = 0; i < lst1.Count; i++)
            {
                Maestro nuevo = new Maestro(
                    Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                    lst1[i].Lst[1].Parametro.ToString(),
                    lst1[i].Lst[2].Parametro.ToString(),
                    lst1[i].Lst[3].Parametro.ToString(),
                    lst1[i].Lst[4].Parametro.ToString(),
                    lst1[i].Lst[5].Parametro.ToString(),
                    lst1[i].Lst[6].Parametro.ToString(),
                    foto,
                    lst1[i].Lst[8].Parametro.ToString(),
                    lst1[i].Lst[9].Parametro.ToString(),
                    lst1[i].Lst[10].Parametro.ToString()
                    );
                lstmaestro.Add(nuevo);
            }

            return JsonConvert.SerializeObject(lstmaestro);
        }

        // GET: api/Maestro/5
        [HttpGet("{id}", Name = "Get2")]
        public string Get(int id)
        {
            byte[] foto = { 0, 1, 1, 1, 1, 1, 1, 1, 1 };

            string query = "Select * from maestro\n" +
                "where registro = " + id + ";";
            Conexion conn = new Conexion();
            List<Generico2> lst1 = conn.metodo_consulta(query, 11);
            Maestro nuevo = new Maestro(
                Convert.ToInt32(lst1[0].Lst[0].Parametro.ToString()),
                lst1[0].Lst[1].Parametro.ToString(),
                lst1[0].Lst[2].Parametro.ToString(),
                lst1[0].Lst[3].Parametro.ToString(),
                lst1[0].Lst[4].Parametro.ToString(),
                lst1[0].Lst[5].Parametro.ToString(),
                lst1[0].Lst[6].Parametro.ToString(),
                foto,
                lst1[0].Lst[8].Parametro.ToString(),
                lst1[0].Lst[9].Parametro.ToString(),
                lst1[0].Lst[10].Parametro.ToString()
                );
            return JsonConvert.SerializeObject(nuevo);

        }

        // POST: api/Maestro
        [HttpPost]
        public int Post(Maestro entrada)
        {
            try
            {
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>();
                lst.Add(new Generico("nombres", entrada.Nombres, 2));
                lst.Add(new Generico("telefono", entrada.Telefono, 2));
                lst.Add(new Generico("direccion", entrada.Direccion, 2));
                lst.Add(new Generico("email", entrada.Correo, 2));
                lst.Add(new Generico("fechanac", entrada.Fecha_nacimiento, 3));
                lst.Add(new Generico("dpi", entrada.Dpi, 2));
                //lst.Add(new Generico("foto", entrada.Foto, 5));
                lst.Add(new Generico("password", entrada.Password, 2));
                lst.Add(new Generico("ciclo", entrada.Ciclo, 2));
                lst.Add(new Generico("idadmin", entrada.Admin, 2));

                return conn.Post("MaestroInsert", lst);
            }
            catch
            {
                return -1;

            }
        }

        // PUT: api/Maestro/5
        [HttpPut("{id}")]
        public bool Put(int id, Maestro entrada)
        {
            entrada.Id_maestro = id;

            try
            {
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("registro", id, 1),
                    new Generico("nombres", entrada.Nombres, 2),
                    new Generico("telefono", entrada.Telefono, 2),
                    new Generico("direccion", entrada.Direccion, 2),
                    new Generico("mail", entrada.Correo, 2),
                    new Generico("fechanac", entrada.Fecha_nacimiento, 3),
                    new Generico("dpi", entrada.Dpi, 2),
                    //lst.Add(new Generico("foto", entrada.Foto, 5));
                    new Generico("password", entrada.Password, 2),
                    new Generico("ciclo", entrada.Ciclo, 2),
                    new Generico("idadmin", entrada.Admin, 2)
                };

                return conn.metodo_proc("MaestroUpdate", lst);
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
                new Generico("registro", id, 1)
            };
            return conn.metodo_proc("MaestroEliminar", lst);

        }
    }
}

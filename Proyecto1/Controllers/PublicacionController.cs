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
    public class PublicacionController : ControllerBase
    {
        // GET: api/Publicacion

        // GET: api/Publicacion/5
        [HttpGet("{id}", Name = "Get4")]
        public string Get(int id)
        {
            try
            {
                string query = "select * from publicacion \n" +
                    "where registro = " + id + "; ";
                Conexion conn = new Conexion();
                List<Generico2> lst1 = conn.metodo_consulta(query, 10);
                List<Publicacion> lstAlumno = new List<Publicacion>();
                for (int i = 0; i < lst1.Count; i++)
                {
                    Publicacion nuevo = new Publicacion(
                        Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                        lst1[i].Lst[1].Parametro.ToString(),
                        lst1[i].Lst[2].Parametro.ToString(),
                        lst1[i].Lst[3].Parametro.ToString(),
                        0,0,0,0,0,
                        Convert.ToInt32(lst1[i].Lst[9].Parametro.ToString())
                        );
                    lstAlumno.Add(nuevo);
                }

                return JsonConvert.SerializeObject(lstAlumno);

            }
            catch
            {
                return "NO HAy PUBLICACIONES";
            }
        }


        // POST: api/Publicacion
        [HttpPost]
        public bool Post(Publicacion entrada)
        {

            try
            {
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("titulo", entrada.Titulo, 2),
                    new Generico("texto", entrada.Descripcion, 2),
                    new Generico("fecha", entrada.Fecha, 3),
                    new Generico("registro", entrada.Id_maestro, 1),
                    new Generico("idtipo", entrada.Id_tipo, 2)
                };
                switch (entrada.Id_tipo)
                {
                    case 1:
                        lst.Add(new Generico("idcalificacion",entrada.Id_calificacion,5));
                        lst.Add(new Generico("idexamen", entrada.Id_examen,5));
                        lst.Add(new Generico("idactividad", entrada.Id_actividad,1));
                        lst.Add(new Generico("idmaterialapoyo", entrada.Id_material,5));
                        break;
                    case 2:
                        lst.Add(new Generico("idcalificacion", entrada.Id_calificacion, 5));
                        lst.Add(new Generico("idexamen", entrada.Id_examen, 1));
                        lst.Add(new Generico("idactividad", entrada.Id_actividad, 5));
                        lst.Add(new Generico("idmaterialapoyo", entrada.Id_material, 5));
                        break;
                    case 3:
                        lst.Add(new Generico("idcalificacion", entrada.Id_calificacion, 1));
                        lst.Add(new Generico("idexamen", entrada.Id_examen, 5));
                        lst.Add(new Generico("idactividad", entrada.Id_actividad, 5));
                        lst.Add(new Generico("idmaterialapoyo", entrada.Id_material, 5));
                        break;
                    case 4:
                        lst.Add(new Generico("idcalificacion", entrada.Id_calificacion, 5));
                        lst.Add(new Generico("idexamen", entrada.Id_examen, 5));
                        lst.Add(new Generico("idactividad", entrada.Id_actividad, 5));
                        lst.Add(new Generico("idmaterialapoyo", entrada.Id_material, 1));
                        break;
                    case 5:
                        lst.Add(new Generico("idcalificacion", entrada.Id_calificacion, 5));
                        lst.Add(new Generico("idexamen", entrada.Id_examen, 5));
                        lst.Add(new Generico("idactividad", entrada.Id_actividad, 5));
                        lst.Add(new Generico("idmaterialapoyo", entrada.Id_material, 5));
                        break;
                    default:
                        break;
                }

                return conn.metodo_proc("PublicacionInsert", lst);
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
                new Generico("idpublicacion", id, 1)
            };
            return conn.metodo_proc("PublicacionEliminar", lst);
        }
    }
}

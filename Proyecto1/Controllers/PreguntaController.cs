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
    public class PreguntaController : ControllerBase
    {

        // GET: api/Pregunta/5
        [HttpGet("{id}", Name = "Get10")]
        public string Get(int id)
        {
            //List<Respuesta> lst = new List<Respuesta>();
            //lst.Add(new Respuesta(0, "A", "false", 1, "EXCEL 2018"));
            //lst.Add(new Respuesta(0, "B", "false", 1, "WORD 2018"));
            //lst.Add(new Respuesta(0, "C", "true", 1, "SQL SERVER"));
            //lst.Add(new Respuesta(0, "D", "true", 1, "MYSQL"));
            //lst.Add(new Respuesta(0, "E", "true", 1, "POSTGRESQL"));
            //Pregunta nuevo = new Pregunta(0,"Gestores de Bases de Datos",1,lst);

            try
            {


                string query = "select * from pregunta  " +
                    "where idexamen =" + id + ";";
                Conexion conn = new Conexion();


                List<Generico2> lst1 = conn.metodo_consulta(query, 4);
                List<Pregunta> lst = new List<Pregunta>();

                for (int i = 0; i < lst1.Count; i++)
                {
                    int cod = Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString());
                    string query2 = "select * from respuesta " +
                        "where idpregunta =" + cod + ";";

                    List<Generico2> lst2 = conn.metodo_consulta(query2, 5);

                    List<Respuesta> lstRespuesta = new List<Respuesta>();
                    for (int j = 0; j < lst2.Count; j++)
                    {
                        Respuesta aux = new Respuesta(
                            Convert.ToInt32(lst2[j].Lst[0].Parametro.ToString()),
                            lst2[j].Lst[1].Parametro.ToString(),
                            lst2[j].Lst[2].Parametro.ToString(),
                            Convert.ToInt32(lst2[j].Lst[3].Parametro.ToString()),
                            lst2[j].Lst[4].Parametro.ToString()
                            );
                        lstRespuesta.Add(aux);
                    }

                    Pregunta nuevo = new Pregunta(
                        Convert.ToInt32(lst1[i].Lst[0].Parametro.ToString()),
                        lst1[i].Lst[1].Parametro.ToString(),
                        Convert.ToInt32(lst1[i].Lst[2].Parametro.ToString()),
                        lstRespuesta
                        );
                    lst.Add(nuevo);
                }

                return JsonConvert.SerializeObject(lst);
            }
            catch { return "NO EXISTEN DATOS"; }

        }

        // POST: api/Pregunta
        [HttpPost]
        public bool Post(Pregunta entrada)
        {
            bool salida = false;
            int cod = -1;
            try
            {
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("descripcion", entrada.Descripcion, 2),
                    new Generico("idexamen", entrada.Id_examen, 1)
                };
                cod = conn.Post("PreguntaInsert", lst);
                salida = false;
            }
            catch
            {
                return false;

            }

            try
            {
                Conexion conn = new Conexion();
                for (int i = 0; i < entrada.Lst_respuestas.Count; i++)
                {
                    Respuesta aux = entrada.Lst_respuestas[i];
                    aux.Id_pregunta = cod;
                    List<Generico> lst = new List<Generico>
                {
                        new Generico("idpregunta", aux.Id_pregunta, 1),
                        new Generico("opcion", aux.Opcion, 2),
                        new Generico("estado", aux.Estado, 2),
                        new Generico("respuesta", aux.RespuestaP, 2)
                };
                    salida = conn.metodo_proc("RespuestaInsert", lst);
                }
                return salida;
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

            string query = "delete from respuesta  " +
                "where idpregunta = " + id + ";";
            conn.ExecQuery(query);

            List<Generico> lst = new List<Generico>
            {
                new Generico("idpregunta", id, 1)
            };
            return conn.metodo_proc("PreguntaEliminar", lst);

        }
    }
}

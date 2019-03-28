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
    public class CalificarExamenController : ControllerBase
    {
        // POST: api/CalificarExamen
        [HttpPost]
        public bool Post(PreguntaAlumno entrada)
        {

            try
            {
                string query = "select respuesta.idrespuesta, respuesta.idpregunta, respuesta.opcion,respuesta.estado from Respuesta \n" +
                    "inner join pregunta on \n" +
                    "pregunta.idpregunta = respuesta.idpregunta \n" +
                    "where pregunta.idpregunta =" + entrada.Id_pregunta + " \n " +
                    "and respuesta.estado = 'true';";
                Conexion conn = new Conexion();
                List<Generico2> lst2 = conn.metodo_consulta(query, 4);
                List<RespuestaAlumno> lst_aux = entrada.Lst_reespuestas_alumno;
                List<Respuesta> lst_correcta = new List<Respuesta>();
                for (int j = 0; j < lst2.Count; j++)
                {
                    Respuesta aux = new Respuesta(
                        Convert.ToInt32(lst2[j].Lst[0].Parametro.ToString()),
                        lst2[j].Lst[2].Parametro.ToString(),
                        lst2[j].Lst[3].Parametro.ToString(),
                        Convert.ToInt32(lst2[j].Lst[1].Parametro.ToString()),
                        "----"
                        );
                    lst_correcta.Add(aux);
                }

                bool salida = false;

                if (lst_correcta.Count == lst_aux.Count)
                {
                    for (int i = 0; i < lst_correcta.Count; i++)
                    {
                        string correcta = lst_correcta[i].Opcion;
                        for (int j = 0; j < lst_aux.Count; j++)
                        {
                            string R_Alumno = lst_aux[j].Respuesta;
                            if (correcta.Equals(R_Alumno))
                            {
                                salida = true;
                                break;
                            }
                            else {
                                salida = false;
                            }
                        }
                        if (salida == false) {
                            break;
                        }
                    }
                    return salida;
                }
                else
                {
                    return false;
                }
            }
            catch { return false; }
        }
    }
}

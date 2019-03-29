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
    public class ActividadController : ControllerBase
    {
        private string cadenaconexion = "Server=tcp:serverp1.database.windows.net,1433;Initial Catalog=Proyecto1;Persist Security Info=False;User ID=bases1;Password=2019DBp1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        // GET: api/Actividad
        [HttpGet]
        public string Get()
        {
            try
            {
                string query = "select * from actividad;";
                Conexion conn = new Conexion();
                List<Generico2> lst = conn.metodo_consulta(query, 9);
                List<Actividad> lstActidad = new List<Actividad>();
                for (int i = 0; i < lst.Count; i++)
                {
                    Actividad nuevo = new Actividad(
                        Convert.ToInt32(lst[i].Lst[0].Parametro.ToString()),
                        lst[i].Lst[1].Parametro.ToString(),
                        lst[i].Lst[2].Parametro.ToString(),
                        lst[i].Lst[3].Parametro.ToString(),
                        lst[i].Lst[6].Parametro.ToString(),
                        Convert.ToDouble(lst[i].Lst[5].Parametro.ToString()),
                        Convert.ToInt32(lst[i].Lst[7].Parametro.ToString()),
                        Convert.ToInt32(lst[i].Lst[8].Parametro.ToString()), null);
                    lstActidad.Add(nuevo);
                }


                string json = JsonConvert.SerializeObject(lstActidad);
                return json;

            }
            catch { return "NO HAY ACTIVIDADES"; }

        }

        // GET: api/Actividad/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            try
            {
                SqlDataReader reader = null;
                SqlConnection conexion = new SqlConnection
                {
                    ConnectionString = cadenaconexion
                };
                string query = "select actividad.idactividad, actividad.titulo, actividad.descripcion, actividad.valor, materia.nombre, asignacionactividad.nota, asignacionactividad.observacion, asignacionactividad.estado from asignacionactividad \n" +
                    "inner join actividad on \n" +
                    "actividad.idactividad = asignacionactividad.idactividad \n" +
                    "inner join materia on\n" +
                    "actividad.idmateria = materia.idmateria \n" +
                    "where asignacionactividad.carnet = " + id + ";";

                SqlCommand cmd = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = query,
                    Connection = conexion
                };
                conexion.Open();

                reader = cmd.ExecuteReader();
                string json = "";

                try
                {
                    List<AsignarActividad> lstActividades = new List<AsignarActividad>();

                    while (reader.Read())
                    {
                        AsignarActividad nuevo = new AsignarActividad(
                            Convert.ToInt32(reader.GetValue(0).ToString()),
                            reader.GetValue(1).ToString(),
                            reader.GetValue(2).ToString(),
                            Convert.ToDouble(reader.GetValue(3).ToString()),
                            reader.GetValue(4).ToString(),
                            Convert.ToDouble(reader.GetValue(5).ToString()),
                            reader.GetValue(6).ToString(),
                            reader.GetValue(7).ToString()
                            );
                        lstActividades.Add(nuevo);
                    }
                    json = JsonConvert.SerializeObject(lstActividades);

                }
                catch
                {
                    json = "No existen datos";
                }

                conexion.Close();
                return json;
            }
            catch { return "NULL"; }
        }

        // POST: api/Actividad
        [HttpPost]
        public bool Post(Actividad entrada)
        {
            int cod = -1;
            bool salida = false;
            DateTime currentTime = DateTime.Now;
            String hora = (TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time")).ToString("HH:mm:ss");
            string fecha_actual = (TimeZoneInfo.ConvertTimeBySystemTimeZoneId(currentTime, TimeZoneInfo.Local.Id, "Central Standard Time")).ToString();
            SqlConnection conexion = new SqlConnection
            {
                ConnectionString = cadenaconexion
            };
            conexion.Open();
            try
            {
                Actividad nuevo = entrada;
                SqlCommand cmd = new SqlCommand("ActividadInsert", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter paramCodRetorno = new SqlParameter("Identity", SqlDbType.Int);
                paramCodRetorno.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramCodRetorno);

                cmd.Parameters.AddWithValue("titulo", nuevo.Titulo);
                cmd.Parameters.AddWithValue("descripcion", nuevo.Descripcion);
                cmd.Parameters.AddWithValue("fechapublicacion", Convert.ToDateTime(fecha_actual));
                cmd.Parameters.AddWithValue("asignados", nuevo.Lst_asignados.Count);
                cmd.Parameters.AddWithValue("valor", nuevo.Ponderacion);
                cmd.Parameters.AddWithValue("fechaentrega", Convert.ToDateTime(nuevo.Fecha_entrega));
                cmd.Parameters.AddWithValue("registro", nuevo.Id_maestro);
                cmd.Parameters.AddWithValue("idmateria", nuevo.Id_materia);

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    cod = Convert.ToInt32(cmd.Parameters["Identity"].Value);
                }
                else
                    cod = -1;

                salida = true;
            }
            catch (Exception)
            {
                salida = false;
            }
            conexion.Close();
            // "VALOR DE ASIGNACION: " + cod;
            //Console.WriteLine("VALOR DE ASIGNACION: " + cod);
            try
            {
                if (cod != -1)
                {
                    Conexion conn = new Conexion();
                    for (int i = 0; i < entrada.Lst_asignados.Count; i++)
                    {
                        List<Generico> lst = new List<Generico>();
                        lst.Add(new Generico("nota", 0.0, 4));
                        lst.Add(new Generico("observacion", "", 2));
                        lst.Add(new Generico("fechasubida", fecha_actual, 3));
                        lst.Add(new Generico("archivo", "", 2));
                        lst.Add(new Generico("estado", "Pendiente", 2));
                        lst.Add(new Generico("idactividad", cod, 1));
                        lst.Add(new Generico("carnet", entrada.Lst_asignados[i], 1));
                        salida = conn.metodo_proc("AsignacionActividadInsert", lst);
                    }
                }
                else
                    salida = false;
            }
            catch
            {
                salida = false;
            }

            try
            {
                Conexion conn = new Conexion();
                List<Generico> lst = new List<Generico>
                {
                    new Generico("titulo", entrada.Titulo, 2),
                    new Generico("texto", entrada.Descripcion, 2),
                    new Generico("fecha", fecha_actual, 3),
                    new Generico("registro", entrada.Id_maestro, 1),
                    new Generico("idtipo", 1, 1)
                };
                lst.Add(new Generico("idcalificacion", 1, 5));
                lst.Add(new Generico("idexamen", 1, 5));
                lst.Add(new Generico("idactividad", cod, 1));
                lst.Add(new Generico("idmaterialapoyo", 1, 5));

                salida = conn.metodo_proc("PublicacionInsert", lst);
            }
            catch {
                salida = false;
            }

                return salida;

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public bool DeleteActividad(int id)
        {
            bool salida = false;
            SqlConnection conexion = new SqlConnection
            {
                ConnectionString = cadenaconexion
            };
            conexion.Open();
            try
            {

                SqlCommand cmd = new SqlCommand("ActividadEliminar", conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("idactividad", id);


                //Medicion nue = new Medicion(1, nuevo.Tipo, nuevo.Carnet, nuevo.Valor_medicion, fecha_actual, hora, nuevo.Latitud, nuevo.Longitud, nuevo.Unidad);
                cmd.ExecuteNonQuery();
                salida = true;

            }
            catch (Exception)
            {
                salida = false;
            }
            conexion.Close();


            return salida;
        }
    }
}

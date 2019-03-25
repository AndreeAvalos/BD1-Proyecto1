using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto1.Models;

namespace Proyecto1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private string cadenaconexion = "Server=tcp:serverp1.database.windows.net,1433;Initial Catalog=Proyecto1;Persist Security Info=False;User ID=bases1;Password=2019DBp1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        // GET: api/Login
        [HttpGet]
        public Boolean Get(User usuario)
        {
            try
            {
                    SqlDataReader reader = null;
                    SqlConnection conexion = new SqlConnection
                    {
                        ConnectionString = cadenaconexion
                    };
                    string query = "";
                    if (usuario.Tipo == 1)
                        query = "SELECT contrasena from Admin where idadmin=\'" + usuario.Usuario+"\'";
                    else if (usuario.Tipo == 2)
                        query = "SELECT password from Maestro where registro=" + usuario.Usuario ;
                    else if (usuario.Tipo == 3)
                        query = "SELECT password from Alumno where carnet=" + usuario.Usuario;

                    SqlCommand cmd = new SqlCommand
                    {
                        CommandType = CommandType.Text,
                        CommandText = query,
                        Connection = conexion
                    };
                    conexion.Open();
                    reader = cmd.ExecuteReader();
                    string passAux = "";
                    try
                    {
                        while (reader.Read())
                        {
                            passAux = reader.GetValue(0).ToString();
                        }

                        if (passAux.Equals(usuario.Password))
                        {
                            conexion.Close();
                            return true;
                        }

                    }
                    catch (Exception)
                    {
                        conexion.Close();
                        return false;
                    }
                    conexion.Close();
                    return false;
                }
            catch { return false; }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto1.Models
{
    public class Conexion
    {
        private string cadenaconexion = "Server=tcp:serverp1.database.windows.net,1433;Initial Catalog=Proyecto1;Persist Security Info=False;User ID=bases1;Password=2019DBp1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        public bool metodo_proc(string nombre_proc, List<Generico> lstcmd)
        {
            bool salida = false;
            SqlConnection conexion = new SqlConnection
            {
                ConnectionString = cadenaconexion
            };
            conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(nombre_proc, conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };

                for (int i = 0; i < lstcmd.Count; i++)
                {

                    if (lstcmd[i].Tipo == 1)
                        cmd.Parameters.AddWithValue(lstcmd[i].Titulo, Convert.ToInt32(lstcmd[i].Parametro));
                    else if (lstcmd[i].Tipo == 2)
                        cmd.Parameters.AddWithValue(lstcmd[i].Titulo, lstcmd[i].Parametro.ToString());
                    else if (lstcmd[i].Tipo == 3)
                        cmd.Parameters.AddWithValue(lstcmd[i].Titulo, Convert.ToDateTime(lstcmd[i].Parametro));
                    else if (lstcmd[i].Tipo == 4)
                        cmd.Parameters.AddWithValue(lstcmd[i].Titulo, Convert.ToDouble(lstcmd[i].Parametro));
                    else if (lstcmd[i].Tipo == 5)
                        cmd.Parameters.AddWithValue(lstcmd[i].Titulo, DBNull.Value);
                }

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
        public bool ExecQuery(string query)
        {
            try
            {
                SqlConnection conexion = new SqlConnection
                {
                    ConnectionString = cadenaconexion
                };
                SqlCommand cmd = new SqlCommand
                {
                    CommandType = CommandType.Text,
                    CommandText = query,
                    Connection = conexion
                };
                conexion.Open();
                cmd.ExecuteReader();
                conexion.Close();
                return true;

            }
            catch { }

            return false;
        }

        public int Post(string nombre_proc, List<Generico> lstcmd)
        {
            int cod = -1;
            SqlConnection conexion = new SqlConnection
            {
                ConnectionString = cadenaconexion
            };
            conexion.Open();
            try
            {
                SqlCommand cmd = new SqlCommand(nombre_proc, conexion)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter paramCodRetorno = new SqlParameter("Identity", SqlDbType.Int);
                paramCodRetorno.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(paramCodRetorno);

                for (int i = 0; i < lstcmd.Count; i++)
                {

                    if (lstcmd[i].Tipo == 1)
                        cmd.Parameters.AddWithValue(lstcmd[i].Titulo, Convert.ToInt32(lstcmd[i].Parametro));
                    else if (lstcmd[i].Tipo == 2)
                        cmd.Parameters.AddWithValue(lstcmd[i].Titulo, lstcmd[i].Parametro.ToString());
                    else if (lstcmd[i].Tipo == 3)
                        cmd.Parameters.AddWithValue(lstcmd[i].Titulo, Convert.ToDateTime(lstcmd[i].Parametro));
                    else if (lstcmd[i].Tipo == 4)
                        cmd.Parameters.AddWithValue(lstcmd[i].Titulo, Convert.ToDouble(lstcmd[i].Parametro));
                    else if (lstcmd[i].Tipo == 5)
                        cmd.Parameters.AddWithValue(lstcmd[i].Titulo, Convert.ToByte(lstcmd[i].Parametro));
                }

                int rowsAffected = cmd.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    cod = Convert.ToInt32(cmd.Parameters["Identity"].Value);
                }
                else
                    cod = -1;
                conexion.Close();
                return cod;
            }
            catch (Exception)
            {
                return cod;
            }
        }

        public List<Generico2> metodo_consulta(string query, int num_datos)
        {
            SqlDataReader reader = null;
            SqlConnection conexion = new SqlConnection
            {
                ConnectionString = cadenaconexion
            };

            SqlCommand cmd = new SqlCommand
            {
                CommandType = CommandType.Text,
                CommandText = query,
                Connection = conexion
            };
            conexion.Open();

            reader = cmd.ExecuteReader();
            List<Generico2> lstGenerica = new List<Generico2>();
            Generico2 nuevo;
            try
            {
                while (reader.Read())
                {
                    nuevo = new Generico2();
                    for (int i = 0; i < num_datos; i++)
                    {
                        nuevo.Lst.Add(new Generico("" + i, reader.GetValue(i).ToString()));
                    }
                    lstGenerica.Add(nuevo);
                }

            }
            catch (Exception)
            {

            }

            conexion.Close();
            return lstGenerica;
        }
    }

}

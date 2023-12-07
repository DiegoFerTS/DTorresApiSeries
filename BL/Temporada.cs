using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Temporada
    {
        public static ML.Informacion Add(ML.Temporada temporada)
        {
            temporada.Informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "TemporadaAdd";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[6];

                    collection[0] = new SqlParameter("@IdSerie", System.Data.SqlDbType.Int);
                    collection[0].Value = temporada.Serie.Id;
                    collection[1] = new SqlParameter("@NumeroTemporada", System.Data.SqlDbType.Int);
                    collection[1].Value = temporada.NumeroTemporada;
                    collection[2] = new SqlParameter("@NumeroCapitulos", System.Data.SqlDbType.Int);
                    collection[2].Value = temporada.NumeroCapitulos;
                    collection[3] = new SqlParameter("@IdEstatus", System.Data.SqlDbType.Int);
                    collection[3].Value = temporada.Estatus.Id;
                    collection[4] = new SqlParameter("@Sinopsis", System.Data.SqlDbType.VarChar);
                    collection[4].Value = temporada.Sinopsis;
                    collection[5] = new SqlParameter("@Imagen", System.Data.SqlDbType.VarChar);
                    collection[5].Value = temporada.Imagen;

                    command.Parameters.AddRange(collection);

                    command.Connection.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        temporada.Informacion.Estatus = true;
                        temporada.Informacion.Mensaje = "Se registro la temporada con exito.";
                    }
                    else
                    {
                        temporada.Informacion.Estatus = false;
                        temporada.Informacion.Mensaje = "No se registro la temporada.";
                    }
                }
            }
            catch (Exception ex)
            {
                temporada.Informacion.Estatus = false;
                temporada.Informacion.Mensaje = ex.Message;
            }

            return temporada.Informacion;
        }


        public static ML.Informacion Update(ML.Temporada temporada)
        {
            temporada.Informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "TemporadaUpdate";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[7];
                    collection[0] = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    collection[0].Value = temporada.Id;
                    collection[1] = new SqlParameter("@IdSerie", System.Data.SqlDbType.Int);
                    collection[1].Value = temporada.Serie.Id;
                    collection[2] = new SqlParameter("@NumeroTemporada", System.Data.SqlDbType.Int);
                    collection[2].Value = temporada.NumeroTemporada;
                    collection[3] = new SqlParameter("@NumeroCapitulos", System.Data.SqlDbType.Int);
                    collection[3].Value = temporada.NumeroCapitulos;
                    collection[4] = new SqlParameter("@IdEstatus", System.Data.SqlDbType.Int);
                    collection[4].Value = temporada.Estatus.Id;
                    collection[5] = new SqlParameter("@Sinopsis", System.Data.SqlDbType.VarChar);
                    collection[5].Value = temporada.Sinopsis;
                    collection[6] = new SqlParameter("@Imagen", System.Data.SqlDbType.VarChar);
                    collection[6].Value = temporada.Imagen;

                    command.Parameters.AddRange(collection);

                    command.Connection.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        temporada.Informacion.Estatus = true;
                        temporada.Informacion.Mensaje = "Se actualizo la temporada con exito.";
                    }
                    else
                    {
                        temporada.Informacion.Estatus = false;
                        temporada.Informacion.Mensaje = "No se actualizo la temporada.";
                    }
                }
            }
            catch (Exception ex)
            {
                temporada.Informacion.Estatus = false;
                temporada.Informacion.Mensaje = ex.Message;
            }

            return temporada.Informacion;
        }


        public static ML.Informacion Delete(int idTemporada)
        {
            ML.Informacion informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "TemporadaDelete";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    command.Parameters["@Id"].Value = idTemporada;

                    command.Connection.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        informacion.Estatus = true;
                        informacion.Mensaje = "La temporada se elimino exitosamente.";
                    }
                    else
                    {
                        informacion.Estatus = false;
                        informacion.Mensaje = "No se elimino la temporada.";
                    }
                }
            }
            catch (Exception ex)
            {
                informacion.Estatus = false;
                informacion.Mensaje = ex.Message;
            }

            return informacion;
        }


        public static ML.Temporada GetByIdSerie(int idSerie)
        {
            ML.Temporada temporada = new ML.Temporada();
            temporada.Informacion = new ML.Informacion();
            temporada.Temporadas = new List<ML.Temporada>();

            using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
            {
                string query = "TemporadaGetAll";

                SqlCommand command = new SqlCommand(query, conexion);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@IdSerie", System.Data.SqlDbType.Int);
                command.Parameters["@IdSerie"].Value = idSerie;

                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable tablaTemporada = new DataTable();

                adapter.Fill(tablaTemporada);

                if (tablaTemporada.Rows.Count > 0)
                {

                    foreach (DataRow row in tablaTemporada.Rows)
                    {
                        ML.Temporada temporadaResult = new ML.Temporada();
                        temporadaResult.Serie = new ML.Serie();
                        temporadaResult.Estatus = new ML.Estatus();

                        temporadaResult.Id = int.Parse(row[0].ToString());
                        temporadaResult.Serie.Id = int.Parse(row[1].ToString());
                        temporadaResult.Serie.Titulo = row[2].ToString();
                        temporadaResult.NumeroTemporada = int.Parse(row[3].ToString());
                        temporadaResult.NumeroCapitulos = int.Parse(row[4].ToString());
                        temporadaResult.Estatus.Id = int.Parse(row[5].ToString());
                        temporadaResult.Estatus.Nombre = row[6].ToString();
                        temporadaResult.Sinopsis = row[7].ToString();
                        temporadaResult.Imagen = row[8].ToString();

                        temporada.Temporadas.Add(temporadaResult);

                    }

                    temporada.Informacion.Estatus = true;
                    temporada.Informacion.Mensaje = "Se encontraron " + temporada.Temporadas.Count() + " resultados.";

                }
                else
                {
                    temporada.Informacion.Estatus = false;
                    temporada.Informacion.Mensaje = "No se encontraron temporadas.";
                }

            }
            return temporada;
        }


        public static ML.Temporada GetById(int idTemporada)
        {
            ML.Temporada temporada = new ML.Temporada();
            temporada.Serie = new ML.Serie();
            temporada.Estatus = new ML.Estatus();
            temporada.Informacion = new ML.Informacion();

            using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
            {
                string query = "TemporadaGetById";

                SqlCommand command = new SqlCommand(query, conexion);

                command.CommandType = System.Data.CommandType.StoredProcedure;

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                command.Parameters["@Id"].Value = idTemporada;

                command.Connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable tablaTemporada = new DataTable();

                adapter.Fill(tablaTemporada);

                if (tablaTemporada.Rows.Count > 0)
                {

                    temporada.Id = int.Parse(tablaTemporada.Rows[0][0].ToString());
                    temporada.Serie.Id = int.Parse(tablaTemporada.Rows[0][1].ToString());
                    temporada.Serie.Titulo = tablaTemporada.Rows[0][2].ToString();
                    temporada.NumeroTemporada = int.Parse(tablaTemporada.Rows[0][3].ToString());
                    temporada.NumeroCapitulos = int.Parse(tablaTemporada.Rows[0][4].ToString());
                    temporada.Estatus.Id = int.Parse(tablaTemporada.Rows[0][5].ToString());
                    temporada.Estatus.Nombre = tablaTemporada.Rows[0][6].ToString();
                    temporada.Sinopsis = tablaTemporada.Rows[0][7].ToString();
                    temporada.Imagen = tablaTemporada.Rows[0][8].ToString();

                    temporada.Informacion.Estatus = true;
                    temporada.Informacion.Mensaje = "Se encontro la temporada.";

                }
                else
                {
                    temporada.Informacion.Estatus = false;
                    temporada.Informacion.Mensaje = "No se encontraron temporadas.";
                }

            }
            return temporada;
        }
    }
}

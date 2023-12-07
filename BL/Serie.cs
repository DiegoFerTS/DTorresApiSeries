using Microsoft.Data.SqlClient;
using ML;
using System.Data;
using System.Globalization;

namespace BL
{
    public class Serie
    {
        public static ML.Informacion Add(ML.Serie serie)
        {
            Informacion resultado = new ML.Informacion();
       
            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "SerieAdd";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[9];
                    collection[0] = new SqlParameter("@Titulo", System.Data.SqlDbType.VarChar);
                    collection[0].Value = serie.Titulo;
                    collection[1] = new SqlParameter("@Temporadas", System.Data.SqlDbType.Int);
                    collection[1].Value = serie.Temporadas;
                    collection[2] = new SqlParameter("@Sinopsis", System.Data.SqlDbType.VarChar);
                    collection[2].Value = serie.Sinopsis;
                    collection[3] = new SqlParameter("@IdGenero", System.Data.SqlDbType.Int);
                    collection[3].Value = serie.Genero.Id;
                    collection[4] = new SqlParameter("@IdTipoPublico", System.Data.SqlDbType.Int);
                    collection[4].Value = serie.TipoPublico.Id;
                    collection[5] = new SqlParameter("@FechaInicio", System.Data.SqlDbType.Date);
                    collection[5].Value = serie.FechaInicio;
                    collection[6] = new SqlParameter("@FechaFin", System.Data.SqlDbType.Date);
                    collection[6].Value = serie.FechaFin;
                    collection[7] = new SqlParameter("@IdEstatus", System.Data.SqlDbType.Int);
                    collection[7].Value = serie.Estatus.Id;
                    collection[8] = new SqlParameter("@Imagen", System.Data.SqlDbType.VarChar);
                    collection[8].Value = serie.Imagen;

                    command.Parameters.AddRange(collection);
                    command.Connection.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        resultado.Estatus = true;
                        resultado.Mensaje = "Se registro la serie con exito.";
                    } else
                    {
                        resultado.Estatus = false;
                        resultado.Mensaje = "No se registro la serie.";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Estatus = false;
                resultado.Mensaje = ex.Message;
            }
            return resultado;
        }

        public static ML.Informacion Update(ML.Serie serie)
        {
            Informacion resultado = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "SerieUpdate";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[10];
                    collection[0] = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    collection[0].Value = serie.Id;
                    collection[1] = new SqlParameter("@Titulo", System.Data.SqlDbType.VarChar);
                    collection[1].Value = serie.Titulo;
                    collection[2] = new SqlParameter("@Temporadas", System.Data.SqlDbType.Int);
                    collection[2].Value = serie.Temporadas;
                    collection[3] = new SqlParameter("@Sinopsis", System.Data.SqlDbType.VarChar);
                    collection[3].Value = serie.Sinopsis;
                    collection[4] = new SqlParameter("@IdGenero", System.Data.SqlDbType.Int);
                    collection[4].Value = serie.Genero.Id;
                    collection[5] = new SqlParameter("@IdTipoPublico", System.Data.SqlDbType.Int);
                    collection[5].Value = serie.TipoPublico.Id;
                    collection[6] = new SqlParameter("@FechaInicio", System.Data.SqlDbType.Date);
                    collection[6].Value = serie.FechaInicio;
                    collection[7] = new SqlParameter("@FechaFin", System.Data.SqlDbType.Date);
                    collection[7].Value = serie.FechaFin;
                    collection[8] = new SqlParameter("@IdEstatus", System.Data.SqlDbType.Int);
                    collection[8].Value = serie.Estatus.Id;
                    collection[9] = new SqlParameter("@Imagen", System.Data.SqlDbType.VarChar);
                    collection[9].Value = serie.Imagen;

                    command.Parameters.AddRange(collection);
                    command.Connection.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        resultado.Estatus = true;
                        resultado.Mensaje = "Se actualizo la serie " + serie.Titulo + " con exito.";
                    }
                    else
                    {
                        resultado.Estatus = false;
                        resultado.Mensaje = "No se registro la serie.";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Estatus = false;
                resultado.Mensaje = ex.Message;
            }
            return resultado;
        }


        public static ML.Informacion Delete(int idSerie)
        {
            Informacion resultado = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "SerieDelete";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    command.Parameters["@Id"].Value = idSerie;

                    command.Connection.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        resultado.Estatus = true;
                        resultado.Mensaje = "Se elimino la serie con Id:" + idSerie + ".";
                    }
                    else
                    {
                        resultado.Estatus = false;
                        resultado.Mensaje = "No se elimino la serie.";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado.Estatus = false;
                resultado.Mensaje = ex.Message;
            }
            return resultado;
        }


        public static ML.Serie GetByTitle(string? titulo)
        {
            ML.Serie serie = new ML.Serie();
            serie.Genero = new ML.Genero();
            serie.TipoPublico = new ML.TipoPublico();
            serie.Estatus = new ML.Estatus();
            serie.Informacion = new ML.Informacion();
            serie.Series = new List<ML.Serie>();

            if (titulo == null)
            {
                titulo = "";
            }

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "SerieGetAll";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@Titulo", System.Data.SqlDbType.VarChar, 100);
                    command.Parameters["@Titulo"].Value = titulo;

                    command.Connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable tablaSerie = new DataTable();

                    adapter.Fill(tablaSerie);

                    if (tablaSerie.Rows.Count > 0)
                    {
                        int registrosEncontrados = tablaSerie.Rows.Count;

                        foreach (DataRow row in tablaSerie.Rows)
                        {
                            ML.Serie serieResult = new ML.Serie();
                            serieResult.Genero = new ML.Genero();
                            serieResult.TipoPublico = new ML.TipoPublico();
                            serieResult.Estatus = new ML.Estatus();

                            serieResult.Id = int.Parse(row[0].ToString());
                            serieResult.Titulo = row[1].ToString();
                            serieResult.Temporadas = int.Parse(row[2].ToString());
                            serieResult.Sinopsis = row[3].ToString();
                            serieResult.Genero.Id = int.Parse(row[4].ToString());
                            serieResult.Genero.Nombre = row[5].ToString();
                            serieResult.TipoPublico.Id = int.Parse(row[6].ToString());
                            serieResult.TipoPublico.Nombre = row[7].ToString();
                            serieResult.FechaInicio = DateTime.ParseExact(row[8].ToString().Split(" ")[0].Replace("/", "-"), "M-d-yyyy", CultureInfo.InvariantCulture);
                            serieResult.FechaFin = DateTime.ParseExact(row[9].ToString().Split(" ")[0].Replace("/", "-"), "M-d-yyyy", CultureInfo.InvariantCulture);
                            serieResult.Estatus.Id = int.Parse(row[10].ToString());
                            serieResult.Estatus.Nombre = row[11].ToString();
                            serieResult.Imagen = row[12].ToString();

                            serie.Series.Add(serieResult);
                        }

                        serie.Informacion.Estatus = true;
                        serie.Informacion.Mensaje = "Se encontraron " + registrosEncontrados + " registros.";
                    } else
                    {
                        serie.Informacion.Estatus = false;
                        serie.Informacion.Mensaje = "No se encontraron resultados.";
                    }

                }
            }
            catch (Exception ex)
            {
                serie.Informacion.Estatus = false;
                serie.Informacion.Mensaje = ex.Message;
            }

            return serie;
        }

        public static ML.Serie GetById(int idSerie)
        {
            ML.Serie serie = new ML.Serie();
            serie.Genero = new ML.Genero();
            serie.TipoPublico = new ML.TipoPublico();
            serie.Estatus = new ML.Estatus();
            serie.Informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "SerieGetById";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    command.Parameters["@Id"].Value = idSerie;

                    command.Connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable tablaSerie = new DataTable();

                    adapter.Fill(tablaSerie);

                    if (tablaSerie.Rows.Count > 0)
                    {
                        serie.Id = int.Parse(tablaSerie.Rows[0][0].ToString());
                        serie.Titulo = tablaSerie.Rows[0][1].ToString();
                        serie.Temporadas = int.Parse(tablaSerie.Rows[0][2].ToString());
                        serie.Sinopsis = tablaSerie.Rows[0][3].ToString();
                        serie.Genero.Id = int.Parse(tablaSerie.Rows[0][4].ToString());
                        serie.Genero.Nombre = tablaSerie.Rows[0][5].ToString();
                        serie.TipoPublico.Id = int.Parse(tablaSerie.Rows[0][6].ToString());
                        serie.TipoPublico.Nombre = tablaSerie.Rows[0][7].ToString();
                        serie.FechaInicio = DateTime.ParseExact(tablaSerie.Rows[0][8].ToString().Split(" ")[0].Replace("/", "-"), "M-d-yyyy", CultureInfo.InvariantCulture);
                        serie.FechaFin = DateTime.ParseExact(tablaSerie.Rows[0][9].ToString().Split(" ")[0].Replace("/", "-"), "M-d-yyyy", CultureInfo.InvariantCulture);
                        serie.Estatus.Id = int.Parse(tablaSerie.Rows[0][10].ToString());
                        serie.Estatus.Nombre = tablaSerie.Rows[0][11].ToString();
                        serie.Imagen = tablaSerie.Rows[0][12].ToString();


                        serie.Informacion.Estatus = true;
                        serie.Informacion.Mensaje = "Se encontro la serie.";
                    }
                    else
                    {
                        serie.Informacion.Estatus = false;
                        serie.Informacion.Mensaje = "No se encontraron resultados.";
                    }

                }
            }
            catch (Exception ex)
            {
                serie.Informacion.Estatus = false;
                serie.Informacion.Mensaje = ex.Message;
            }

            return serie;
        }
    }
}
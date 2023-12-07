using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Capitulo
    {
        public static ML.Informacion Add(ML.Capitulo capitulo)
        {
            capitulo.Informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion =  new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "CapituloAdd";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[4];
                    collection[0] = new SqlParameter("@Titulo", System.Data.SqlDbType.VarChar);
                    collection[0].Value = capitulo.Titulo;
                    collection[1] = new SqlParameter("@UrlVideo", System.Data.SqlDbType.VarChar);
                    collection[1].Value = capitulo.UrlVideo;
                    collection[2] = new SqlParameter("@Duracion", System.Data.SqlDbType.DateTime);
                    collection[2].Value = capitulo.Duracion;
                    collection[3] = new SqlParameter("@IdTemporada", System.Data.SqlDbType.Int);
                    collection[3].Value = capitulo.Temporada.Id;

                    command.Parameters.AddRange(collection);

                    command.Connection.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        capitulo.Informacion.Estatus = true;
                        capitulo.Informacion.Mensaje = "Se registro el capitulo con exito.";
                    } else
                    {
                        capitulo.Informacion.Estatus = false;
                        capitulo.Informacion.Mensaje = "No se registro el capitulo.";
                    }
                }
            }
            catch (Exception ex)
            {
                capitulo.Informacion.Estatus = false;
                capitulo.Informacion.Mensaje = ex.Message;
            }
            
            return capitulo.Informacion;
        }


        public static ML.Informacion Update(ML.Capitulo capitulo)
        {
            capitulo.Informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "CapituloUpdate";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[5];
                    collection[0] = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                    collection[0].Value = capitulo.Id;
                    collection[1] = new SqlParameter("@Titulo", System.Data.SqlDbType.VarChar);
                    collection[1].Value = capitulo.Titulo;
                    collection[2] = new SqlParameter("@UrlVideo", System.Data.SqlDbType.VarChar);
                    collection[2].Value = capitulo.UrlVideo;
                    collection[3] = new SqlParameter("@Duracion", System.Data.SqlDbType.DateTime);
                    collection[3].Value = capitulo.Duracion;
                    collection[4] = new SqlParameter("@IdTemporada", System.Data.SqlDbType.Int);
                    collection[4].Value = capitulo.Temporada.Id;

                    command.Parameters.AddRange(collection);

                    command.Connection.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        capitulo.Informacion.Estatus = true;
                        capitulo.Informacion.Mensaje = "Se actualizo el capitulo con exito.";
                    }
                    else
                    {
                        capitulo.Informacion.Estatus = false;
                        capitulo.Informacion.Mensaje = "No se actualizo el capitulo.";
                    }
                }
            }
            catch (Exception ex)
            {
                capitulo.Informacion.Estatus = false;
                capitulo.Informacion.Mensaje = ex.Message;
            }

            return capitulo.Informacion;
        }

        public static ML.Informacion Delete(int idCapitulo)
        {
            ML.Informacion informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "CapituloDelete";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    command.Parameters["@Id"].Value = idCapitulo;

                    command.Connection.Open();

                    int filasAfectadas = command.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        informacion.Estatus = true;
                        informacion.Mensaje = "Se elimino el capitulo con exito.";
                    }
                    else
                    {
                        informacion.Estatus = false;
                        informacion.Mensaje = "No se elimino el capitulo.";
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

        public static ML.Capitulo GetByIdTemporada(int idTemporada)
        {
            ML.Capitulo capitulo = new ML.Capitulo();
            capitulo.Temporada = new ML.Temporada();
            capitulo.Informacion = new ML.Informacion();
            capitulo.Capitulos = new List<ML.Capitulo>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "CapituloGetByIdTemporada";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@idTemporada", System.Data.SqlDbType.Int);
                    command.Parameters["@idTemporada"].Value = idTemporada;

                    command.Connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable tablaCapitulo = new DataTable();

                    adapter.Fill(tablaCapitulo);

                    if (tablaCapitulo.Rows.Count > 0)
                    {
                        foreach (DataRow row in tablaCapitulo.Rows)
                        {
                            ML.Capitulo capituloResult = new ML.Capitulo();
                            capituloResult.Temporada = new ML.Temporada();
                            capituloResult.Temporada.Serie = new ML.Serie();

                            capituloResult.Id = int.Parse(row[0].ToString());
                            capituloResult.Titulo = row[1].ToString();
                            capituloResult.UrlVideo = row[2].ToString();
                            capituloResult.Duracion = DateTime.ParseExact(row[3].ToString(), "h:m:s", null, DateTimeStyles.None);
                            capituloResult.Temporada.Id = int.Parse(row[4].ToString());
                            capituloResult.Temporada.Serie.Id = int.Parse(row[5].ToString());
                            capituloResult.Temporada.Serie.Titulo = row[6].ToString();
                            capituloResult.Temporada.NumeroTemporada = int.Parse(row[7].ToString());

                            capitulo.Capitulos.Add(capituloResult);
                            
                        }

                        capitulo.Informacion.Estatus = true;
                        capitulo.Informacion.Mensaje = "Se encontraron " + tablaCapitulo.Rows.Count + " capitulos.";
                    }
                    else
                    {
                        capitulo.Informacion.Estatus = false;
                        capitulo.Informacion.Mensaje = "No se encontraron datos.";
                    }
                }
            }
            catch (Exception ex)
            {
                capitulo.Informacion.Estatus = false;
                capitulo.Informacion.Mensaje = ex.Message;
            }

            return capitulo;
        }


        public static ML.Capitulo GetById(int idCapitulo)
        {
            ML.Capitulo capitulo = new ML.Capitulo();
            capitulo.Temporada = new ML.Temporada();
            capitulo.Temporada.Serie = new ML.Serie();
            capitulo.Informacion = new ML.Informacion();

            try
            {
                using (SqlConnection conexion = new SqlConnection(DL.Conexion.GetConnectionString()))
                {
                    string query = "CapituloGetById";

                    SqlCommand command = new SqlCommand(query, conexion);

                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.Add("@Id", System.Data.SqlDbType.Int);
                    command.Parameters["@Id"].Value = idCapitulo;

                    command.Connection.Open();

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable tablaCapitulo = new DataTable();

                    adapter.Fill(tablaCapitulo);

                    if (tablaCapitulo.Rows.Count > 0)
                    {

                        capitulo.Id = int.Parse(tablaCapitulo.Rows[0][0].ToString());
                        capitulo.Titulo = tablaCapitulo.Rows[0][1].ToString();
                        capitulo.UrlVideo = tablaCapitulo.Rows[0][2].ToString();
                        capitulo.Duracion = DateTime.ParseExact(tablaCapitulo.Rows[0][3].ToString(), "h:mm:ss", null, DateTimeStyles.None);
                        capitulo.Temporada.Id = int.Parse(tablaCapitulo.Rows[0][4].ToString());
                        capitulo.Temporada.Serie.Id = int.Parse(tablaCapitulo.Rows[0][5].ToString());
                        capitulo.Temporada.Serie.Titulo = tablaCapitulo.Rows[0][6].ToString();
                        capitulo.Temporada.NumeroTemporada = int.Parse(tablaCapitulo.Rows[0][7].ToString());

                        capitulo.Informacion.Estatus = true;
                        capitulo.Informacion.Mensaje = "Se encontro el capitulo.";
                    }
                    else
                    {
                        capitulo.Informacion.Estatus = false;
                        capitulo.Informacion.Mensaje = "No se encontraron datos.";
                    }
                }
            }
            catch (Exception ex)
            {
                capitulo.Informacion.Estatus = false;
                capitulo.Informacion.Mensaje = ex.Message;
            }

            return capitulo;
        }
    }
}

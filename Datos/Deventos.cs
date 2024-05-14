using System.Data;
using System.Data.SqlClient;
using ApiEventos.Conexion;
using ApiEventos.Modelo;

namespace ApiEventos.Datos
{
    public class Deventos
    { 
        Conexionbd cn = new Conexionbd();
        public async Task <List<Meventos>> Mostrareventos()
        {
            var lista = new List<Meventos>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("viewEvent",sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync())
                        {
                            var meventos = new Meventos();
                            meventos.id = (int)item["id"];
                            meventos.fecha = (string)item["fecha"];
                            meventos.descripcion = (string)item["descripcion"];
                            meventos.lugar = (string)item["lugar"];
                            meventos.precio = (decimal)item["precio"];
                            lista.Add(meventos);
                        }
                    }
                }
            }
            return lista;
        }

        public async Task InsertarEvento(Meventos parametros)
        {
            using(var sql=new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insetEvent", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fecha", parametros.fecha);
                    cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);
                    cmd.Parameters.AddWithValue("@lugar", parametros.lugar);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    cmd.Parameters.AddWithValue("@estado", parametros.estado);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task EditarEvento(Meventos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editEvent", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    cmd.Parameters.AddWithValue("@fecha", parametros.fecha);
                    cmd.Parameters.AddWithValue("@descripcion", parametros.descripcion);
                    cmd.Parameters.AddWithValue("@lugar", parametros.lugar);
                    cmd.Parameters.AddWithValue("@precio", parametros.precio);
                    cmd.Parameters.AddWithValue("@estado", parametros.estado);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }


        public async Task EliminarEvento(Meventos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("deletelogEvent", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", parametros.id);
                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}

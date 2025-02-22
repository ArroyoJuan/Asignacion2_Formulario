
using Microsoft.Data.SqlClient;

namespace Asignacion2_Formulario.Models
{
    public class AccesoDatos
    {
        private readonly string _conexion;
        public AccesoDatos(IConfiguration configuration)
        {
            _conexion = configuration.GetConnectionString("Conexion");
        }
        //Metodo que busca crear el usuario
        public void AgregarUsuario(Productos nuevoProducto)
        {
            using (SqlConnection con = new SqlConnection(_conexion))
            {
                try
                {
                    string query = "Exec spInsertarProducto @Nombre, @Descripcion, @Precio, @Stock";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Nombre", nuevoProducto.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", nuevoProducto.Descripcion);
                        cmd.Parameters.AddWithValue("@Precio", nuevoProducto.Precio);
                        cmd.Parameters.AddWithValue("@Stock", nuevoProducto.Stock);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al registrar el usuario" + ex.Message);
                }
            }
        }
    }
}

using System.Data.SqlClient;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ApiId.Controllers
{
    [Route("api/[controller]")]
    public class Example : ControllerBase
    {
        // public IConfiguration _config;

        // public Example(IConfiguration config)
        // {
        //     _config = config;
        // }
    
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
             Guid uuid = Guid.NewGuid();

            // Convertir el UUID a su representación en cadena
            string uuidString = uuid.ToString() + new DateTime().ToString();

            // Conectar a la base de datos SQL Server
            // string connectionString = _config.GetConnectionString("DatabaseContext");
            string connectionString = "Server=(local);Database=TestDb;Integrated Security=True;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión
                connection.Open();

                // Ejemplo de inserción en una tabla llamada 'TuTabla'
                string query = "INSERT INTO TestTable (Id, UserName) VALUES (@Id, @UserName)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Parámetros
                    command.Parameters.AddWithValue("@Id", uuidString);
                    command.Parameters.AddWithValue("@UserName", "Eliseo");

                    // Ejecutar la consulta
                    int rowsAffected = command.ExecuteNonQuery();

                    // Verificar si la inserción fue exitosa
                    if (rowsAffected > 0)
                    {
                        return Ok("Awebi");
                    }
                    else
                    {
                        return BadRequest(":c");
                    }
                }
            }
        }
    }
}
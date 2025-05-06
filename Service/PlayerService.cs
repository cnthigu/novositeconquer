using MySqlConnector;

namespace ConquerSite.Service
{
    public class PlayerService
    {
        private readonly IConfiguration _configuration;

        public PlayerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int GetOnlinePlayersCount()
        {
            string connectionString = _configuration.GetConnectionString("DefaultConnection");
            using var connection = new MySqlConnection(connectionString);
            connection.Open();

            // Modifica a query para multiplicar Online por 2
            string query = "SELECT Online * 2 FROM onlineplayers LIMIT 1";
            using var command = new MySqlCommand(query, connection);
            var result = command.ExecuteScalar();

            // Verifica se o resultado é nulo e converte para inteiro
            return result != null ? Convert.ToInt32(result) : 0;
        }
    }
}

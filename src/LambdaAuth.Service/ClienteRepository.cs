using LambdaAuth.BusinessObjects;
using Npgsql;

namespace LambdaAuth.Data
{
    public class ClienteRepository
    {
        public Cliente GetByCpf(string cpf)
        {
            Cliente cliente = new Cliente();

            var connectionString = @"Host=;Port=5432;Pooling=true;Database=;User Id=;Password=;Include Error Detail=true;";

            NpgsqlConnection conn = new NpgsqlConnection(connectionString);
            var dataSource = NpgsqlDataSource.Create(connectionString);
            

            conn.Open();

            var cmd = dataSource.CreateCommand("SELECT id, cpf FROM clientes WHERE cpf = @cpf");
            cmd.Parameters.AddWithValue("cpf",cpf);

            var reader = cmd.ExecuteReader();
            while (reader.Read()) {
                cliente.Id = new Guid((string)reader["id"].ToString());
                cliente.Cpf = reader["cpf"].ToString();
            }
            reader.Close();

            cmd.Dispose();
            conn.Close();

            return cliente;
        }
    }
}
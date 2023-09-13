using System.Data.SqlClient;
using Dapper;

namespace Project_with_Login.Data
{
    public class Employee_DepNameService
    {
        private readonly string _connectionString;

        public Employee_DepNameService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Employee_DepName>> GetEmployeeAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Employee_DepName"; // assuming your view is named Employee_DepName 
                return await connection.QueryAsync<Employee_DepName>(sql);
                
            }
        }
    }
}
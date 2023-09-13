using Dapper;
using Microsoft.EntityFrameworkCore;
using Project_with_Login.Data;
using System.Data.SqlClient;

namespace Project_with_Login.Data
{
    public class DepartmentService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly string _connectionString;

        public DepartmentService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        //List of Department
        public async Task<List<Department>> GetAllDepartment()
        {
            return await _applicationDbContext.Departments.ToListAsync();
        }

        //Add  Department
        public async Task<bool> InsertDepartment(Department department)
        {
            await _applicationDbContext.Departments.AddAsync(department);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        //Get Department By Id  
        public async Task<Department> GetDepartmentById(int id)
        {
            Department department = await _applicationDbContext.Departments.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return department;
        }

        //Update Department
        public async Task<bool> UpdateDepartment(Department department)
        {
            _applicationDbContext.Departments.Update(department);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }

        //Delete Department
        public async Task<bool> DeleteDepartment(Department department)
        {
            _applicationDbContext.Departments.Remove(department);
            await _applicationDbContext.SaveChangesAsync();
            return true;
        }
      
        
        public DepartmentService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Department>> GetDepartmentAsync()
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Departments"; // assuming your view is named Employee_DepName 
                return await connection.QueryAsync<Department>(sql);

            }
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Project_with_Login.Data;


namespace Project_with_Login.Data
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public EmployeeService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        //Get All Employee List
        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _applicationDbContext.Employees.ToListAsync();
              
        }

        //Add New Employee Record
        public async Task<bool> AddNeEmployee(Employee employee)
        {
            await _applicationDbContext.Employees.AddAsync(employee);
            await _applicationDbContext.SaveChangesAsync();
            return true;

        }

        //Get Employee Record By Id
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _applicationDbContext.Employees
                .Include(e => e.Department)
                .FirstOrDefaultAsync(e => e.Id == id);
            

        }
        //Update Employee Data
        public async Task<bool> UpdateEmployeeDetails(Employee employee)
        {
            _applicationDbContext.Employees.Update(employee);
            await _applicationDbContext.SaveChangesAsync(true);
            return true;
        }

        //Delete Employee Data
        public async Task<bool> DeleteEmployee(Employee employee)
        {
            _applicationDbContext.Employees.Remove(employee);
            await _applicationDbContext.SaveChangesAsync(true);
            return true;
        }
    }
}

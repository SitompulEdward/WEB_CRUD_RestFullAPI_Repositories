using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_CRUD_API.Context;
using WEB_CRUD_API.Models;

namespace WEB_CRUD_API.Repositories
{
    public class EmployeeRepository
    {
        private readonly AppDbContext _context;
        public EmployeeRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployee()
        {
            return _context.Employee.ToList();
        }

        public async Task<bool> CreateEmployee(Employee employee)
        {
            employee.EmployeeId = new Guid();
            _context.Employee.Add(employee);
            await _context.SaveChangesAsync();
            
            return true;
        }

        public Employee GetEmployeeById(Guid id)
        {
            return _context.Employee.SingleOrDefault(x => x.EmployeeId == id);
        }

        public async Task<bool> DeleteEmploye(Employee employee)
        {
            _context.Employee.Remove(employee);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UpdateEmployee(Employee employee)
        {
            var getData = _context.Employee.SingleOrDefault(x => x.EmployeeId == employee.EmployeeId);

            getData.EmployeeName = employee.EmployeeName;
            getData.EmployeeAddress = employee.EmployeeAddress;
            getData.EmployeeTelp = employee.EmployeeTelp;
            getData.EmployeeSalary = employee.EmployeeSalary;
            getData.EmployeeImage = employee.EmployeeImage;

            _context.Update(getData);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

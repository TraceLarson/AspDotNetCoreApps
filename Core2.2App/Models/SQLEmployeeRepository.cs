using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2._2App.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {

        private readonly AppDbContext appDbContext;
        public SQLEmployeeRepository(AppDbContext context)
        {
            appDbContext = context; 
        }

        public Employee Add(Employee employee)
        {
            appDbContext.Employees.Add(employee);
            appDbContext.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            Employee employee = appDbContext.Employees.Find(Id);
            if (employee != null)
            {
                appDbContext.Remove(employee);
                appDbContext.SaveChanges();
            }

            return employee; 
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return appDbContext.Employees;
        }

        public Employee GetEmployee(int Id)
        {
            return appDbContext.Employees.Find(Id);
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = appDbContext.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDbContext.SaveChanges();

            return employeeChanges;
        }

    }
}

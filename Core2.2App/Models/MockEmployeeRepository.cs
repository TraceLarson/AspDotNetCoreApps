﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2._2App.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;


        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Mary", Department = Dept.HR, Email = "mary@tcp.com"},
                new Employee() {Id = 2, Name = "John", Department = Dept.IT, Email = "john@tcp.com"},
                new Employee() {Id = 3, Name = "Sam", Department = Dept.IT, Email = "sam@tcp.com"},

            };  
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id); 
        }

        public Employee Add(Employee employee)
        {
           employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return employee;
        }

        
    }
}

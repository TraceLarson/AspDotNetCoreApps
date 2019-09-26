﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2._2App.Models
{
    public class MockEmployeeRepository : IEmployeeRespository
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee() {Id = 1, Name = "Mary", Department = "HR", Email = "mary@tcp.com"},
                new Employee() {Id = 2, Name = "John", Department = "IT", Email = "john@tcp.com"},
                new Employee() {Id = 3, Name = "Sam", Department = "IT", Email = "sam@tcp.com"},

            };  
        }
        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id); 
        }
    }
}

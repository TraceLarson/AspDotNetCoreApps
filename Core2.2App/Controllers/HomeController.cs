using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core2._2App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Core2._2App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRespository _employeeRepository;

        public HomeController(IEmployeeRespository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public string Index()
        {
            return _employeeRepository.GetEmployee(1).Name;
        }
            
        public ViewResult Details()
        {
            Employee model = _employeeRepository.GetEmployee(1);
            return View("../../MyViews/Test");
 
        }
    }
}

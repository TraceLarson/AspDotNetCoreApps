using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core2._2App.Models;
using Core2._2App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Core2._2App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);

        }
            
        public ViewResult Details(int id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                 Employee = _employeeRepository.GetEmployee(id),
                 PageTitle =  "Employee Details"
            };

            return View(homeDetailsViewModel);
        }
    }
}

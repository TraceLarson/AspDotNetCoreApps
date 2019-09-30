using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core2._2App.Models;
using Core2._2App.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Core2._2App.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("~/Home")]
        [Route("~/")]
        public ViewResult Index()
        {
            var model = _employeeRepository.GetAllEmployees();
            return View(model);

        }

        [Route("{id?}")]
        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                 Employee = _employeeRepository.GetEmployee(id??1),
                 PageTitle =  "Employee Details"
            };

            return View(homeDetailsViewModel);
        }
    }
}

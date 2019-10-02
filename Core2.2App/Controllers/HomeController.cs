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

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                 Employee = _employeeRepository.GetEmployee(id??1),
                 PageTitle =  "Employee Details"
            };

            return View(homeDetailsViewModel);
        }
        
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("Details", new {id = newEmployee.Id});
            }

            return View();
        }

//        public RedirectToActionResult Delete(int id)
//        {
//            Employee selectedEmployee = _employeeRepository.GetEmployee(id);
//            _employeeRepository.Delete(selectedEmployee);
//            return RedirectToAction("Index");
//        }

//        [HttpGet]
//        public ViewResult Edit(int id)
//        {
//            HomeEditViewModel homeEditViewModel = new HomeEditViewModel()
//            {
//                Employee = _employeeRepository.GetEmployee(id),
//                PageTitle = "Edit Details"
//            };
//
//            return View(homeEditViewModel);
//        }

//        [HttpPut]
//        public RedirectToActionResult Edit(Employee employee)
//        {
//            Employee editedEmployee = _employeeRepository.Update(employee);
//            return RedirectToAction("Details", new {id = editedEmployee.Id});
//        }
    }
}

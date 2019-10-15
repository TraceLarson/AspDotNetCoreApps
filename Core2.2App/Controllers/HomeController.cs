using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Core2._2App.Models;
using Core2._2App.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Core2._2App.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _hostingEnvironment = hostingEnvironment;
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
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null )
                {
                        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                        model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    
                }
                Employee newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqueFileName
                };
                _employeeRepository.Add(newEmployee);
                return RedirectToAction("details", new {id = newEmployee.Id});
            }

            return View();
        }

//        public RedirectToActionResult Delete(int id)
//        {
//            Employee selectedEmployee = _employeeRepository.GetEmployee(id);
//            _employeeRepository.Delete(selectedEmployee);
//            return RedirectToAction("Index");
//        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

//        [HttpPut]
//        public RedirectToActionResult Edit(Employee employee)
//        {
//            Employee editedEmployee = _employeeRepository.Update(employee);
//            return RedirectToAction("Details", new {id = editedEmployee.Id});
//        }
    }
}

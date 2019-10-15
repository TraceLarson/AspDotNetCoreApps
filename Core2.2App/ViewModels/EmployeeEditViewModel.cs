using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core2._2App.Models;

namespace Core2._2App.ViewModels
{
    public class EmployeeEditViewModel : EmployeeCreateViewModel
    {
        public int Id { get; set; }
        public string ExistingPhotoPath { get; set; }

    }
}

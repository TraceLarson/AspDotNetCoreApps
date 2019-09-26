using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core2._2App.Models
{
    interface IEmployeeRespository
    {
        Employee GetEmployee(int Id);
    }
}

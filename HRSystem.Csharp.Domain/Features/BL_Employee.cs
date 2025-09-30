using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Csharp.Domain.Models;
using HRSystem.Csharp.Shared;

namespace HRSystem.Csharp.Domain.Features
{
    public class BL_Employee
    {
        private readonly DA_Employee _daEmployee;

        public BL_Employee(DA_Employee daEmployee)
        {
            _daEmployee = daEmployee;
        }

        public Result<List<Employee>> GetAllEmployees()
        {
            var employees = _daEmployee.GetAllEmployees();
            var response = Result<List<Employee>>.Success(employees.Data);
            return response;
        }
    }
}

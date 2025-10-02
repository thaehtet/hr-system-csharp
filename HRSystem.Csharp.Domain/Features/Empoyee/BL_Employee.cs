using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Csharp.Domain.Models.Employee;
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

        public async Task<Result<EmployeeResponseModel>> CreateEmployee(EmployeeRequestModel emp)
        {
            var employee =await _daEmployee.CreateEmployee(emp);
            var response = Result<EmployeeResponseModel>.Success(employee.Data);
            return response;
        }

        public async Task<Result<List<EmployeeResponseModel>>> GetAllEmployees()
        {
            var employees = await _daEmployee.GetAllEmployees();
            var response = Result<List<EmployeeResponseModel>>.Success(employees.Data);
            return response;
        }
    }
}

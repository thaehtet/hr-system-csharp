using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Csharp.Domain.Models;
using HRSystem.Csharp.Shared;

namespace HRSystem.Csharp.Domain.Features
{
    public class DA_Employee
    {
        private readonly AppDbContext _appDbContext;

        public DA_Employee(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Result<List<Employee>> GetAllEmployees()
        {
            try
            {
                var emp_list = _appDbContext.TblEmployees
                    .Select(r => new Employee
                    {
                        Name = r.Name
                    })
                    .ToList();
                return Result<List<Employee>>.Success(emp_list);
            }
            catch (Exception ex)
            {
                return Result<List<Employee>>.Error($"An error occurred while retrieving roles: {ex.Message}");
            }
        }
    }
}

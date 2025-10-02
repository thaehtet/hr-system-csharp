using HRSystem.Csharp.Domain.Features;
using HRSystem.Csharp.Domain.Models.Employee;
using Microsoft.AspNetCore.Mvc;

namespace HRSystem.Csharp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly BL_Employee _blEmployee;
        public EmployeeController(BL_Employee blEmployee)
        {
            _blEmployee = blEmployee;
        }

        [HttpGet("get-all-employee")]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await _blEmployee.GetAllEmployees();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }

        [HttpPost("create-employee")]
        public async Task<IActionResult> CreateEmployee([FromBody]EmployeeRequestModel emp)
        {
            var result = await _blEmployee.CreateEmployee(emp);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
    }
}

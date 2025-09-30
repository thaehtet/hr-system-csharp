using HRSystem.Csharp.Database.AppDbContextModels;
using HRSystem.Csharp.Domain.Features;
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
        [HttpGet("GetAllRoles")]
        public IActionResult GetAllRoles()
        {
            var result = _blEmployee.GetAllEmployees();
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result);
        }
    }
}

using System;

namespace HRSystem.Csharp.Domain.Models.Employee
{
    public class EmployeeFilterModel
    {
        public string? Name { get; set; }
        public string? Role{ get; set; }
        public string? Department { get; set; }
        public string? Position { get; set; }
        public DateTime? HireDateFrom { get; set; }
        public DateTime? HireDateTo { get; set; }
        public bool? IsActive { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HRSystem.Csharp.Domain.Models.Employee
{
    public class EmployeeRequestModel
    {
        public string? EmployeeId { get; set; } = null!;

        public string? EmployeeCode { get; set; } = null!;

        public string? RoleCode { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public int? WrongPasswordCount { get; set; }

        public bool? IsFirstTime { get; set; }

        public bool? IsLocked { get; set; }

        public string? PhoneNo { get; set; }

        public string? ProfileImage { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? ResignDate { get; set; }

        public DateTime? CreatedAt { get; set; }

        public string? CreatedBy { get; set; }

        public DateTime? ModifiedAt { get; set; }

        public string? ModifiedBy { get; set; }

        public bool? DeleteFlag { get; set; }
    }
}

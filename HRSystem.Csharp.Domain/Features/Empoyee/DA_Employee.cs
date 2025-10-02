using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRSystem.Csharp.Domain.Models.Employee;
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

        public async Task<Result<List<EmployeeResponseModel>>> GetAllEmployees(EmployeeFilterModel filter)
        {
            try
            {
                var emp_list = await _appDbContext.TblEmployees
                    .Select(r => new EmployeeResponseModel
                    {
                        EmployeeId = r.EmployeeId,
                        EmployeeCode = r.EmployeeCode,
                        RoleCode = r.RoleCode,
                        Email = r.Email,
                        Password = r.Password,
                        WrongPasswordCount = r.WrongPasswordCount,
                        IsFirstTime = r.IsFirstTime,
                        IsLocked = r.IsLocked,
                        PhoneNo = r.PhoneNo,
                        ProfileImage = r.ProfileImage,
                        StartDate = r.StartDate,
                        ResignDate = r.ResignDate,
                        CreatedAt = r.CreatedAt,
                        CreatedBy = r.CreatedBy,
                        ModifiedAt = r.ModifiedAt,
                        ModifiedBy = r.ModifiedBy,
                        DeleteFlag = r.DeleteFlag
                    })
                    .ToListAsync();
                return Result<List<EmployeeResponseModel>>.Success(emp_list);
            }
            catch (Exception ex)
            {
                return Result<List<EmployeeResponseModel>>.Error($"An error occurred while retrieving employees: {ex.Message}");
            }
        }

        public async Task<Result<EmployeeResponseModel>> CreateEmployee(EmployeeRequestModel e)
        {
            try
            {
                var employee =new TblEmployee
                {
                    EmployeeId = Guid.NewGuid().ToString(),
                    EmployeeCode = e.EmployeeCode,
                    Name = e.Name,
                    RoleCode = e.RoleCode,
                    Email = e.Email,
                    Password = e.Password,
                    WrongPasswordCount = e.WrongPasswordCount,
                    IsFirstTime = e.IsFirstTime,
                    IsLocked = e.IsLocked,
                    PhoneNo = e.PhoneNo,
                    ProfileImage = e.ProfileImage,
                    StartDate = e.StartDate,
                    ResignDate = e.ResignDate,
                    CreatedAt = e.CreatedAt,
                    CreatedBy = e.CreatedBy,
                    ModifiedAt = e.ModifiedAt,
                    ModifiedBy = e.ModifiedBy,
                    DeleteFlag = e.DeleteFlag
                };
                await _appDbContext.TblEmployees.AddAsync(employee);
                await _appDbContext.SaveChangesAsync();

                return Result<EmployeeResponseModel>.Success(new EmployeeResponseModel
                {
                    Name = employee.Name,
                    EmployeeCode = employee.EmployeeCode
                }, "Employee created successfully.");
            }
            catch (Exception ex)
            {
                return Result<EmployeeResponseModel>.Error($"An error occurred while creating employee: {ex.Message}");
            }
        }
    }
}

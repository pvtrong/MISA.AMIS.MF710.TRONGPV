using MISA.Common.Models;
using MISA.DataLayer;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Text;
using MISA.Service.Interface;
using MISA.DataLayer.Interface;

namespace MISA.Service
{
    public class EmployeeService : BaseService<Employee>, IEmployeeService
    {
        public EmployeeService(IDbContext<Employee> _dbContext) : base(_dbContext)
        {

        }

        #region Method
        // Validate Data
        protected override bool ValidateData(Employee employee, ErrorMsg errorMsg = null, string mode = "add")
        {
            var employeeContext = new EmployeeContext();
            // Validate dữ liệu:
            var isValid = true;
            // Check trường bắt buộc nhập:
            var employeeCode = employee.employeeCode;
            if (string.IsNullOrEmpty(employeeCode))
            {
                if(errorMsg != null)
                    errorMsg.UserMsg.Add( MISA.Common.Properties.Resources.ErrorService_EmptyEmployeeCode.ToString());
                isValid = false;
            }
            
            var fullName = employee.fullName;
            if (string.IsNullOrEmpty(fullName))
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_EmptyEmployeeFullName.ToString());
                isValid = false;
            }
            var departmentId = employee.departmentId.ToString();
            if (departmentId == "00000000-0000-0000-0000-000000000000")
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_EmptyDepartment.ToString());
                isValid = false;
            }

            // Check trùng mã:
            var isExis = employeeContext.CheckEmployeeCodeExis(employeeCode);

            if (isExis > 1 && mode == "edit")
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeCode.ToString());
                isValid = false;
            }
            else if (isExis > 0 && mode == "add")
            {
                if (errorMsg != null)
                    errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeCode.ToString());
                isValid = false;
            }

            if(employee.identifyNumber != null)
            {
                isExis = employeeContext.CheckEmployeePhoneNumberExis(employee.identifyNumber);

                if (isExis > 1 && mode == "edit")
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeIdentifyNumber.ToString());
                    isValid = false;
                }
                if (isExis > 0 && mode == "add")
                {
                    if (errorMsg != null)
                        errorMsg.UserMsg.Add(MISA.Common.Properties.Resources.ErrorService_DuplicateEmployeeIdentifyNumber.ToString());
                    isValid = false;
                }
            }
            // Check trùng số chứng minh thư:
            
            return isValid;
        }
        // Sửa thông tin nhân viên:

        // Xóa nhân viên:



        #endregion
    }
}

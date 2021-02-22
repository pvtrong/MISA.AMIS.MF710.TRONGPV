using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace MISA.DataLayer
{
    public class EmployeeContext : DbContext<Employee>, IEmployeeContext
    {
        #region Method
        // Check trùng mã:
        /// <summary>
        /// Lấy nhân viên theo mã nhân viên
        /// </summary>
        /// <param name="employeeCode">Mã nhân viên</param>
        /// <returns>nhân viên đó nếu có còn ko thì trả về null</returns>
        /// CreatedBy PVTRONG (7/2/2021)
        public int CheckEmployeeCodeExis(string employeeCode)
        {
            var res = _dbConnection.Query<Employee>($"SELECT PhoneNumber FROM Employee AS E WHERE E.EmployeeCode = '{employeeCode}'").FirstOrDefault();
            if (res != null)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// Kiểm tra số chứng minh thư đã tồn tại hay chưa
        /// </summary>
        /// <param name="identifyNumber">số chứng minh thư</param>
        /// <returns>Đã tồn tại hay chưa (true: đã tồn tại, false: chưa tồn tại)</returns>
        /// CreatedBy PVTRONG (7/2/2021)
        public int CheckEmployeePhoneNumberExis(string identifyNumber)
        {
            var res = _dbConnection.Query<Employee>($"SELECT IdentifyNumber FROM Employee AS E WHERE E.IdentifyNumber = '{identifyNumber}'").FirstOrDefault();
            if(res != null)
            {
                return 1;
            }
            return 0;
        }

        // Sửa thông tin nhân viên: 

        // Xóa nhân viên theo khóa chính:
        #endregion
    }
}

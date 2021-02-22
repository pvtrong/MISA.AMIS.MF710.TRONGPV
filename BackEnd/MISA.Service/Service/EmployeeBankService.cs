using MISA.Common.Models;
using MISA.DataLayer.Interface;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Service
{
    public class EmployeeBankService : BaseService<EmployeeBank>, IEmployeeBankService
    {
        public EmployeeBankService(IDbContext<EmployeeBank> _dbContext) : base(_dbContext)
        {

        }
        #region Method
        #endregion
    }
}

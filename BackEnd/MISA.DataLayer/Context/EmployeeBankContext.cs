using MISA.Common.Models;
using MISA.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.DataLayer.Context
{
    public class EmployeeBankContext :DbContext<EmployeeBank>, IEmployeeBankContext
    {
    }
}

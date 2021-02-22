using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DEMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeBanksController : BaseController<EmployeeBank>
    {
        public EmployeeBanksController(IBaseService<EmployeeBank> employeeBankService) : base(employeeBankService)
        {
            
        }
    }
}

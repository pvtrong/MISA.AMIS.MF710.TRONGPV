using Dapper;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.Service;
using MISA.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MISA.Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MISA.DEMO.API.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : BaseController<Employee>
    {
        
        public EmployeesController(IEmployeeService _employeeService) : base(_employeeService)
        {

        }
    }
}

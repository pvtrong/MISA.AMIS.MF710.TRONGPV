using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Common.Models;
using MISA.Service;
using MISA.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.DEMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<MISAEntity> : ControllerBase
    {
        #region Declare
        IBaseService<MISAEntity> _baseService;
        #endregion

        #region Constructor
        public BaseController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }
        #endregion

        #region Method
        /// <summary>
        /// Hàm lấy dữ liệu từ Service trả về
        /// </summary>
        /// <returns>Dữ liệu lấy được</returns>
        /// CreatedBy PVTRONG (8/2/2021)
        [HttpGet]
        public IActionResult Get([FromQuery] string employeeCode = null, [FromQuery] string employeeId = null,  [FromQuery] string keyword = null,  [FromQuery] string departmentId = null, [FromQuery] string limitParam = null, [FromQuery] string offsetParam = null)
        {
            var serviceResult = _baseService.GetData();
            var param = new Param();

            if (keyword == null && limitParam == null && offsetParam == null && employeeId == null && employeeCode == null)
            {
                serviceResult = _baseService.GetData();
            }
            else
            {
                param.employeeId = employeeId;
                param.employeeCode = employeeCode;
                param.keyword = keyword;
                if (limitParam == null) param.LimitParam = 1000;
                else param.LimitParam = int.Parse(limitParam);
                if (offsetParam == null) param.LimitParam = 0;
                else param.OffsetParam = int.Parse(offsetParam);
                serviceResult = _baseService.GetData(param);
            }
            var entities = serviceResult.Data as List<MISAEntity>;
            if (entities.Count() == 0)
                return StatusCode(204, serviceResult.Data);
            return StatusCode(200, serviceResult.Data);

        }



        /// <summary>
        /// Hàm lấy mã số lớn nhất của đối tượng
        /// </summary>
        /// <returns>Mã số lớn nhất</returns>
        /// CreatedBy PVTRONG (19/02/2021)
        [HttpGet("CodeMax")]
        public IActionResult GetCodeMax()
        {
            var serviceResult = _baseService.GetCodeMax();
            var entities = serviceResult.Data as List<MISAEntity>;
            if (entities.Count() == 0)
                return StatusCode(204, serviceResult.Data);
            return StatusCode(200, serviceResult.Data);
        }

        /// <summary>
        /// PVTRONG 31/12/2020
        /// </summary>
        /// <param name="misaEntity">Đối tượng được thêm</param>
        /// <returns>Trả về tình trạng thêm</returns>
        /// CreatedBy PVTRONG (8/2/2021)
        [HttpPost]
        public IActionResult Post([FromBody] MISAEntity misaEntity)
        {

            var serviceResult = _baseService.Insert(misaEntity);
            if (serviceResult.Success == false)
            {
                return StatusCode(400, serviceResult.Data);
            }
            else if (serviceResult.Success == true && (int)serviceResult.Data > 0) return StatusCode(201, serviceResult.Data);
            else return StatusCode(200, serviceResult.Data);

        }

        /// <summary>
        /// Hàm chỉnh sửa dữ liệu đối tượng
        /// </summary>
        /// <param name="misaEntity">Đối tượng cần chỉnh sửa</param>
        /// <returns>Số bản ghi được chính sửa</returns>
        /// CreatedBy PVTRONG (08/02/2021)
        [HttpPut]
        public IActionResult Put([FromBody] MISAEntity misaEntity)
        {

            var serviceResult = _baseService.Update(misaEntity);
            if (serviceResult.Success == false)
            {
                return StatusCode(400, serviceResult.Data);
            }
            else if (serviceResult.Success == true && (int)serviceResult.Data > 0) return StatusCode(201, serviceResult.Data);
            else return StatusCode(200, serviceResult.Data);

        }


        /// <summary>
        /// PVTRONG 31/12/2020
        /// </summary>
        /// <param name="employeeIds">ID của nhân viên được xóa</param>
        /// <returns>Trả về tình trạng xóa</returns>
        /// CreatedBY PVTRONG (20/02/2021)
        [HttpDelete]
        public IActionResult Delete([FromBody] string[] ids)
        {
            var serviceResult = _baseService.Delete(ids);
            if ((int)serviceResult.Data == 0)
            {
                return StatusCode(204, serviceResult.Data);
            } 
            else return StatusCode(200, serviceResult.Data);
        }
        #endregion
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using System.Data;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore;
using MISA.Entity;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using MISA.ApplicationCore.Constants;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Api Danh sách nhân viên
    /// Created By: NTTan (24/7/2021)
    /// </summary>
    [Route("api/v1/Employees")]
    [ApiController]
    public class EmployeeController : BaseEntityController<Employee>
    {
        #region Field
        /// <summary>
        /// Đói tượng thông báo lỗi trả về
        /// </summary>
        IEmployeeService _employeeService;
        ServiceResult _serviceResult = new ServiceResult();
        #endregion
        #region constructor
        /// <summary>
        /// Hàm khởi tạo
        /// Created By: NTTan (26/7/2021)
        /// </summary>
        public EmployeeController(IEmployeeService employeeService) : base(employeeService)
        {
            _employeeService = employeeService;
        }
        #endregion
        #region Methods
        [HttpGet("filter")]
        public IActionResult GetEmployeeFilterPaging(string employeeFilter, Guid? departmentId, Guid? positionId, int pageIndex, int pageSize)
        {
            var result = _employeeService.GetEmployeeFilterPaging(employeeFilter, departmentId, positionId, pageIndex, pageSize);
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }
        [HttpGet("NewEmployeeCode")]
        public IActionResult GetNewEmployeeCode()
        {
            var result = _employeeService.GetNewEmployeeCode();
            if (result != null)
                return Ok(result);
            return NoContent();
        }
        #endregion
    }
}

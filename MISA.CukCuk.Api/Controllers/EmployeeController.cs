using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using System.Data;
//using MISA.CukCuk.Api.Service;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore;
using MISA.Entity.Model;
using MISA.Entity;

namespace MISA.CukCuk.Api.Controllers
{
     /// <summary>
     /// Api Danh sách nhân viên
     /// Created By: NTTan (24/7/2021)
     /// </summary>
    [Route("api/v1/Employees")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        #region Field
        /// <summary>
        /// Đói tượng thông báo lỗi trả về
        /// </summary>
        ResponseError _responseError = new ResponseError();
     
        #endregion
        #region constructor
        /// <summary>
        /// Hàm khởi tạo
        /// Created By: NTTan (26/7/2021)
        /// </summary>
        
        #endregion
        #region Methods
        /// <summary>
        /// Lấy toàn bộ danh sách nhân viên
        /// </summary>
        /// <returns>danh sách nhân viên</returns>
        [HttpGet]
        public IActionResult GetAllEmployee()
        {
            try
            {
                var employeeService = new EmployeeService();
                var employees = employeeService.GetAllEmployee();
                //trả về kết quả
                if (employees.Count() > 0)
                    return Ok(employees);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                _responseError.ErrorCode = Properties.Resources.ErrorCode001;
                _responseError.UserMsg = Properties.Resources.Error_Exception;
                _responseError.DevMsg = e.Message;
                return StatusCode(500, _responseError);
            }
        }
        /// <summary>
        /// Láy danh sách nhân viên theo id
        /// </summary>
        /// <param name="employeeId">id của nhân viên</param>
        /// <returns>Nhân viên</returns>
        [HttpGet("{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            try
            {
                var employeeService = new EmployeeService();
                var employee = employeeService.GetEmployee(id);
                //trả về kết quả
                if (employee != null)
                    return Ok(employee);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                _responseError.ErrorCode = Properties.Resources.ErrorCode001;
                _responseError.UserMsg = Properties.Resources.Error_Exception;
                _responseError.DevMsg = e.Message;
                return StatusCode(500, _responseError);
            }

        }
        /// <summary>
        /// Thêm mới nhân viên
        /// </summary>
        /// <param name="employee">một đối tượng employee </param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostEmployee(Employee employee)
        {
            try
            {
                var employeeService = new EmployeeService();
                var serviceResult = employeeService.PostEmployee(employee);
                //trả về kết quả
                if (serviceResult.MISACode == MISACode.NotValid)
                {
                    return BadRequest(serviceResult.Data);
                }
                if (serviceResult.MISACode == MISACode.IsValid && (int)serviceResult.Data > 0)
                    return StatusCode(201,serviceResult);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                _responseError.ErrorCode = Properties.Resources.ErrorCode001;
                _responseError.UserMsg = Properties.Resources.Error_Exception;
                _responseError.DevMsg = e.Message;
                return StatusCode(500, _responseError);
            }
        }
        /// <summary>
        /// Sửa thông tin nhân viên
        /// </summary>
        /// <param name="employee">Đối tượng nhân viên cần sửa</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult PutEmployee(Employee employee, Guid id)
        {
            try
            {
                var employeeService = new EmployeeService();
                var rowEmployee = employeeService.PutEmployee(employee,id);
                //trả về kết quả
                if (rowEmployee > 0)
                    return Ok(rowEmployee);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                _responseError.ErrorCode = Properties.Resources.ErrorCode001;
                _responseError.UserMsg = Properties.Resources.Error_Exception;
                _responseError.DevMsg = e.Message;               
                return StatusCode(500, _responseError);
            }
        }
        /// <summary>
        /// Xóa nhân viên theo Id
        /// </summary>
        /// <param name="employeeId">Id của nhân viên</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            try
            {
                var employeeService = new EmployeeService();
                var rowEmployee = employeeService.DeleteEmployee(id);

                if (rowEmployee == 1)
                    return Ok();
                return StatusCode(500);
            }
            catch (Exception e)
            {
                _responseError.ErrorCode = Properties.Resources.ErrorCode001;
                _responseError.DevMsg = e.Message;
                _responseError.UserMsg = Properties.Resources.Error_Exception;
                return StatusCode(500, _responseError);
            }
        }
        #endregion
    }
}

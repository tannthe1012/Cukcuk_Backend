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
    }
}

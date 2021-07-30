using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using MISA.Entity;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/Departments")]
    [ApiController]
    public class DepartmentController : BaseEntityController<Department>
    {
        #region Field
        /// <summary>
        /// Đói tượng thông báo lỗi trả về
        /// </summary>
        IDepartmentService _departmentService;
        #endregion
        #region constructor
        /// <summary>
        /// Hàm khởi tạo
        /// Created By: NTTan (26/7/2021)
        /// </summary>
        public DepartmentController(IDepartmentService departmentService) : base(departmentService)
        {
            _departmentService = departmentService;
        }
        #endregion     
    }
}

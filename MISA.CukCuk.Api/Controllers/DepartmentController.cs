using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.Entity.Model;
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
    public class DepartmentController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách phòng ban
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllDepartment()
        {
            try
            {
                var connectionString = "" +
                    "Host=localhost;" +
                    "Port=3306;" +
                    "Database=MISA.CukCuk_Demo_NVMANH;" +
                    "User Id=root;" +
                    "Password= thetan123";
                IDbConnection dbConnection = new MySqlConnection(connectionString);
                var sqlCommand = "SELECT * FROM Department";

                // Thực hiện lấy dữ liệu với Dapper:
                var departments = dbConnection.Query<Department>(sqlCommand);
                //trả về kết quả
                if (departments.Count() > 0)
                    return Ok(departments);
                else
                    return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        /// <summary>
        /// Lấy phòng ban theo ID
        /// </summary>
        /// <param name="departmentId">Id của phòng ban</param>
        /// <returns>kết quả theo các status code</returns>
        [HttpGet("{departmentId}")]
        public IActionResult GetDepartment(Guid departmentId) 
        {
            try
            {
                // Thiết lập kết nối DB
                var connectionString = "" +
                    "Host=localhost;" +
                    "Port=3306;" +
                    "Database=MISA.CukCuk_Demo_NVMANH;" +
                    "User Id=root;" +
                    "Password= thetan123";
                // Khởi tạo kết nối
                IDbConnection dbConnection = new MySqlConnection(connectionString);
                // Lấy dữ liệu trong database
                // Lưu ý chuyển từ GUID sang String
                var sqlCommand = $"SELECT * FROM Department WHERE departmentId = '{departmentId.ToString()}'";
                var department = dbConnection.QueryFirstOrDefault<Department>(sqlCommand);
                //trả về kết quả
                if (department != null)
                    return Ok(department);
                else
                    return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "đã lỗi");
            }
        }
        /// <summary>
        /// Thêm mới phòng ban
        /// </summary>
        /// <param name="department">phòng ban</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostDepartment(Department department)
        {
            try
            {
                /// Thiết lập kết nối
                var connectionString = "" +
                    "Host=localhost;" +
                    "Port=3306;" +
                    "Database=MISA.CukCuk_Demo_NVMANH;" +
                    "User Id=root;" +
                    "Password= thetan123";
                // Khởi tạo kết nối
                IDbConnection dbConnection = new MySqlConnection(connectionString);
                department.DepartmentId = Guid.NewGuid();

                var sqlCommand = "INSERT INTO Department(DepartmentId, DepartmentCode, DepartmentName, Description)" + 
                    $" VALUES ('{department.DepartmentId}', '{department.DepartmentCode}', '{department.DepartmentName}', '{department.Description}');";
                var rowDepartment = dbConnection.Execute(sqlCommand);
                //trả về kết quả
                if (rowDepartment > 0)
                    return  Created("đã tạo thành công", rowDepartment);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        /// <summary>
        /// Sửa thông tin phòng ban
        /// </summary>
        /// <param name="department">Đối tượng phòng ban</param>
        /// <returns></returns>
        [HttpPut("{departmentId}")]
        public IActionResult PutDepartment(Department department, Guid departmentId)
        {
            try
            {
                /// Thiết lập kết nối
                var connectionString = "" +
                    "Host=localhost;" +
                    "Port=3306;" +
                    "Database=MISA.CukCuk_Demo_NVMANH;" +
                    "User Id=root;" +
                    "Password= thetan123";
                // Khởi tạo kết nối
                IDbConnection dbConnection = new MySqlConnection(connectionString);

                var sqlCommand = $"UPDATE department SET " +
                   $"DepartmentCode = '{department.DepartmentCode}', " +
                   $"DepartmentName = '{department.DepartmentName}', " +
                   $"Description = '{department.Description}' " +
                   $"WHERE DepartmentId = '{departmentId}'";

                var rowDepartment = dbConnection.Execute(sqlCommand);
                //trả về kết quả
                if (rowDepartment > 0)
                    return Ok(rowDepartment);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        /// <summary>
        /// Xóa nhân viên theo Id
        /// </summary>
        /// <param name="departmentId">Id của phòng ban</param>
        /// <returns></returns>
        [HttpDelete("{departmentId}")]
        public IActionResult DeleteDepertment(Guid departmentId)
        {
            try
            {
                var connectionString = "" +
                   "Host=localhost;" +
                   "Port=3306;" +
                   "Database=MISA.CukCuk_Demo_NVMANH;" +
                   "User Id=root;" +
                   "Password= thetan123";
                // Khởi tạo kết nối
                IDbConnection dbConnection = new MySqlConnection(connectionString);
                // Khai báo lệnh truy vấn dữ liệu
                var sqlCommand = $"DELETE FROM Department WHERE DepartmentId = '{departmentId}'";
                var rowDepartment = dbConnection.Execute(sqlCommand);
                if (rowDepartment == 1)
                    return Ok("Xóa thành công !");
                return StatusCode(500, "xóa thất bại");
               
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}

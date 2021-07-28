using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using MySqlConnector;
using System.Data;
using MISA.Entity.Model;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/Positions")]
    [ApiController]
    public class PositionController : ControllerBase
    {
        /// <summary>
        /// Lấy danh sách vị trí
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllPostions()
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
                var sqlCommand = "SELECT * FROM Positions";

                // Thực hiện lấy dữ liệu với Dapper:
                var positions = dbConnection.Query<Position>(sqlCommand);
                //trả về kết quả
                if (positions.Count() > 0)
                    return Ok(positions);
                else
                    return NoContent();

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        /// <summary>
        /// Lấy vị trí theo ID
        /// </summary>
        /// <param name="positionsId">Id của vi tri</param>
        /// <returns>kết quả theo các status code</returns>
        [HttpGet("{positionId}")]
        public IActionResult GetPosition(Guid positionId)
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
                var sqlCommand = $"SELECT * FROM positions WHERE PositionId = '{positionId.ToString()}'";
                var position = dbConnection.QueryFirstOrDefault<Position>(sqlCommand);
                //trả về kết quả
                if (position != null)
                    return Ok(position);
                else
                    return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500, "đã lỗi");
            }
        }

        /// <summary>
        /// Thêm mới vị trí
        /// </summary>
        /// <param name="position">vị trí</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult PostPosition(Position position)
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
                position.PositionId = Guid.NewGuid();

                var sqlCommand = "INSERT INTO Positions(PositionId, PositionCode, PositionName, Description)" +
                    $" VALUES ('{position.PositionId}', '{position.PositionCode}', '{position.PositionName}', '{position.Description}');";
                var rowPosition = dbConnection.Execute(sqlCommand);
                //trả về kết quả
                if (rowPosition > 0)
                    return Ok(rowPosition);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
        /// <summary>
        /// Sửa thông tin vị trí
        /// </summary>
        /// <param name="position">Dối tượng Vị trị cần sửa</param>
        /// <returns></returns>
        [HttpPut("{positionId}")]
        public IActionResult PutPosition(Position position, Guid positionId)
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

                var sqlCommand = $"UPDATE Positions SET " +
                   $"PositionCode = '{position.PositionCode}', " +
                   $"PositionName = '{position.PositionName}', " +
                   $"Description = '{position.Description}' " +
                   $"WHERE PositionId = '{positionId}'";
                var rowPosition = dbConnection.Execute(sqlCommand);
                //trả về kết quả
                if (rowPosition > 0)
                    return Ok(rowPosition);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }


        /// <summary>
        /// Xóa vị trí theo Id
        /// </summary>
        /// <param name="positionId">Id của vị trí</param>
        /// <returns></returns>
        [HttpDelete("{positionId}")]
        public IActionResult DeletePosition(Guid positionId)
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
                var sqlCommand = $"DELETE FROM Positions WHERE positionId = '{positionId}'";
                var rowPosition = dbConnection.Execute(sqlCommand);
                if (rowPosition == 1)
                    return Ok("Xóa thành công vị trí !");
                return StatusCode(500, "xóa thất bại vị trí");

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}

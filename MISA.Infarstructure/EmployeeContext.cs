using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using MISA.Entity.Model;
using MySqlConnector;

namespace MISA.Infarstructure
{
    public class EmployeeContext
    {
        //#region Field
        //IDbConnection _dbConnection;
        //string _connectionString;
        //#endregion

        //#region Constructor
        //public EmployeeContext()
        //{
        //    // Khai báo thông tin kết nối:
        //    _connectionString = "" +
        //        "Host=47.241.69.179;" +
        //        "Port=3306;" +
        //        "Database=MISA.CukCuk_Demo_NVMANH;" +
        //        "User Id=dev;" +
        //        "Password=12345678";
        //    // Khởi tạo kết nối:
        //    _dbConnection = new MySqlConnection(_connectionString);
        //}
        //#endregion
        #region Method
        // Lấy toàn bộ thông tin nhân viên
        public IEnumerable<Employee> GetAllEmployee()
        {
            var connectionString = "" +
                   "Host=localhost;" +
                   "Port=3306;" +
                   "Database=MISA.CukCuk_Demo_NVMANH;" +
                   "User Id=root;" +
                   "Password= thetan123";
            // Khởi tạo kết nối
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            // Khởi tạo các commandText
            var sqlCommand = "SELECT * FROM Employee";
            var employees = dbConnection.Query<Employee>(sqlCommand);
            // trả về dữ liệu
            return employees;
        }
        // Lấy thông tin nhân viên theo id
        public Employee GetEmployee(Guid id)
        {
            var connectionString = "" +
                  "Host=localhost;" +
                  "Port=3306;" +
                  "Database=MISA.CukCuk_Demo_NVMANH;" +
                  "User Id=root;" +
                  "Password= thetan123";
            // Khởi tạo kết nối
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", id);
            var sqlCommand = $"SELECT * FROM Employee WHERE employeeId = @EmployeeId";
            var employee = dbConnection.QueryFirstOrDefault<Employee>(sqlCommand, param: parameters);
            return employee;
        }

        // Thêm mới nhân viên
        public int PostEmployee(Employee employee)
        {
            var connectionString = "" +
                  "Host=localhost;" +
                  "Port=3306;" +
                  "Database=MISA.CukCuk_Demo_NVMANH;" +
                  "User Id=root;" +
                  "Password= thetan123";
            // Khởi tạo kết nối
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            employee.EmployeeId = Guid.NewGuid();
            var sqlCommand = "INSERT INTO Employee(EmployeeId, EmployeeCode, FullName, Gender)" +
                $" VALUES ('{employee.EmployeeId}', '{employee.EmployeeCode}', '{employee.FullName}', '{employee.Gender}');";
            var rowEmployee = dbConnection.Execute(sqlCommand);
            // Kêt quả là số bản ghi thêm mới được
            return rowEmployee;
        }
        // Sửa thông tin nhân viên
        public int PutEmployee(Employee employee, Guid id)
        {
            var connectionString = "" +
                  "Host=localhost;" +
                  "Port=3306;" +
                  "Database=MISA.CukCuk_Demo_NVMANH;" +
                  "User Id=root;" +
                  "Password= thetan123";
            // Khởi tạo kết nối
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var sqlCommand = $"UPDATE employee SET " +
                   $"EmployeeCode = '{employee.EmployeeCode}', " +
                   $"FullName = '{employee.FullName}', " +
                   $"Gender = '{employee.Gender}' " +
                   $"WHERE EmployeeId = @EmployeeId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", id);
            var rowEmployee = dbConnection.Execute(sqlCommand, param: parameters);
            return rowEmployee;
        }
        // Xóa nhân viên
        public int DeleteEmployee(Guid id)
        {
            var connectionString = "" +
                  "Host=localhost;" +
                  "Port=3306;" +
                  "Database=MISA.CukCuk_Demo_NVMANH;" +
                  "User Id=root;" +
                  "Password= thetan123";
            // Khởi tạo kết nối
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var sqlCommand = $"DELETE FROM Employee WHERE employeeId = @EmployeeId";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", id);
            var rowEmployee = dbConnection.Execute(sqlCommand, param: parameters);
            return rowEmployee;
        }

        /// <summary>
        /// Hàm kiếm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>true mã đã tồn tại</returns>
        /// Created By: NTTan (26/7/2021)
        public String GetEmployeeByCode(string employeeCode)
        {
            var connectionString = "" +
                  "Host=localhost;" +
                  "Port=3306;" +
                  "Database=MISA.CukCuk_Demo_NVMANH;" +
                  "User Id=root;" +
                  "Password= thetan123";
            // Khởi tạo kết nối
            IDbConnection dbConnection = new MySqlConnection(connectionString);
            var sqlCommand = "SELECT EmployeeCode FROM Employee WHERE EmployeeCode = @EmployeeCode";
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeCode", employeeCode);
            var rowAffects = dbConnection.QueryFirstOrDefault<string>(sqlCommand, param: parameters);
            return rowAffects;
        }

        #endregion
    }
}

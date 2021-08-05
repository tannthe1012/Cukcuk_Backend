using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using MySqlConnector;

namespace MISA.Infarstructure
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public object GetEmployeeFilterPaging(string employeeFilter, Guid? departmentId, Guid? positionId, int pageIndex, int pageSize)
        {
            DynamicParameters parameters = new DynamicParameters();
            var totalRecord = 0;
            var totalPage = 0;
            parameters.Add("@EmployeeFilter", employeeFilter);
            parameters.Add("@DepartmentId", departmentId, DbType.String);
            parameters.Add("@PositionId", positionId, DbType.String);
            parameters.Add("@PageIndex", pageIndex);
            parameters.Add("@PageSize", pageSize);
            parameters.Add("@TotalPage", totalPage, DbType.Int32, ParameterDirection.Output);
            parameters.Add("@TotalRecord", totalRecord, DbType.Int32, ParameterDirection.Output);
            var employees = _dbConnection.Query<Employee>("Proc_GetEmployeesFilterPaging", parameters, commandType: CommandType.StoredProcedure).ToList();
            var result = new
            {
                ToltalPage = parameters.Get<int>("@TotalPage"),
                TotalRecord = parameters.Get<int>("@TotalRecord"),
                Data = employees
            };
            return result;
        }
        public string GetNewEmployeeCode()
        {
            var result = _dbConnection.QueryFirstOrDefault<string>("Proc_GetNewEmployeeCode", commandType: CommandType.StoredProcedure);
            return result;
        }


    }
}

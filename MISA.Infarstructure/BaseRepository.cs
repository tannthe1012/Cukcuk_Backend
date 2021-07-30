using Dapper;
using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Interface;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Infarstructure
{
    public class BaseRepository<MISAEntity>: IBaseRepository<MISAEntity>
    {
        #region Field
        // khởi tạo đối tượng kết nối database
        protected IDbConnection DBConnection;
        // các config kết nối
        string _connectionString;
        string className;
        IConfiguration _configuration;
        #endregion
        #region Constructor
        /// <summary>
        /// Hàm khởi tạo truyền vào 1 chuỗi kết nối
        /// </summary>
        /// <param name="configuration"></param>
        public BaseRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("CukCukConnectionString");
            DBConnection = new MySqlConnection(_connectionString);
            className = typeof(MISAEntity).Name;

        }
        #endregion
        #region Methods
        /// <summary>
        /// Hàm lấy tất cả
        /// </summary>
        /// <returns></returns>
        /// Created By: NTTan(26/7/2021)
        public IEnumerable<MISAEntity> GetAll()
        {
            var entities = DBConnection.Query<MISAEntity>($"Proc_Get{className}s",commandType:CommandType.StoredProcedure);
            return entities;
        }
        /// <summary>
        /// Hàm lấy đối tượng theo id
        /// </summary>
        /// <param name="id">id của đối tượng</param>
        /// <returns>Đối tượng với id tương ứng</returns>
        /// Created By: NTTan (26/7/2021)
        public MISAEntity GetById(Guid id)
        {
            var className = typeof(MISAEntity).Name;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{className}Id", id);
            var sqlCommand = $"SELECT * FROM {className} WHERE {className}Id = @{className}Id";
            var entity = DBConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameters);
            return entity;
        }
        /// <summary>
        /// hàm xóa theo id của đối tượng
        /// </summary>
        /// <param name="id">id của đối tượng</param>
        /// <returns>Số cột bị xóa</returns>
        /// Created By: NTTan (26/7/2021)
        public int Delete(Guid id)
        {
            var className = typeof(MISAEntity).Name;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{className}Id", id);
            var sqlCommand = $"DELETE FROM {className} WHERE {className}Id = @{className}Id";
            var rowEmployee = DBConnection.Execute(sqlCommand, param: parameters);
            return rowEmployee;
        }
        /// <summary>
        /// Hàm kiếm tra mã đối tượng đã tồn tại hay chưa
        /// </summary>
        /// <param name="employeeCode"></param>
        /// <returns>true mã đã tồn tại</returns>
        /// Created By: NTTan (26/7/2021)
        public MISAEntity GetByCode(string ObjCode)
        {
            var className = typeof(MISAEntity).Name;
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add($"@{className}Code", ObjCode);
            var sqlCommand = $"SELECT * FROM {className} WHERE {className}Code = @{className}Code";
            var entity = DBConnection.QueryFirstOrDefault<MISAEntity>(sqlCommand, param: parameters);
            return entity;
        }
        /// <summary>
        /// Hàm thêm mới dối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm mới</param>
        /// <returns>Số bản ghi thay đổi trong DB</returns>
        public int Insert(MISAEntity entity)
        {
            var className = typeof(MISAEntity).Name;
            var parameters = MappingDbType(entity);
            var rowEntity = DBConnection.Execute($"Proc_Insert{className}", parameters,commandType:CommandType.StoredProcedure);
            return rowEntity;
        }
        /// <summary>
        /// Sửa đổi dữ liệu của đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần sửa đổi</param>
        /// <param name="id">id của đối tượng</param>
        /// <returns>Số bản ghi thay đổi</returns>
        public int Update(MISAEntity entity, Guid id)
        {
            var className = typeof(MISAEntity).Name;
            var parameters = MappingDbType(entity);
            var rowEntity = DBConnection.Execute($"Proc_Update{className}", parameters, commandType: CommandType.StoredProcedure);
            return rowEntity;
        }
        /// <summary>
        /// Hàm để Map các thuộc tính
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        public DynamicParameters MappingDbType<TEntity>(TEntity entity)
        {
            var properties = entity.GetType().GetProperties();
            var parameters = new DynamicParameters();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity);
                var propertyType = property.PropertyType;
                if (propertyType == typeof(Guid) || propertyType == typeof(Guid?))
                {
                    parameters.Add($"@{propertyName}", propertyValue, DbType.String);
                }
                else
                {
                    parameters.Add($"@{propertyName}", propertyValue);
                }
            }

            return parameters;
        }

        public MISAEntity GetEntityByProperty(string propertyName, object propertyValue)
        {
            var query = $"SELECT * FROM {className} WHERE {propertyName} = '{propertyValue}'";
            var entity = DBConnection.QueryFirstOrDefault<MISAEntity>(query, commandType: CommandType.Text);
            return entity;
        }
        #endregion
    }
}

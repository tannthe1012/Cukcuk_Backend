using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Service
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity> where MISAEntity:BaseEntity 
    {
        #region Field
        IBaseRepository<MISAEntity> _baseRepository;
        public  ServiceResult _serviceResult;
        #endregion
        #region Constructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
            _serviceResult = new ServiceResult() { isValid = true };
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
            var entities = _baseRepository.GetAll();
            return entities;
        }
        /// <summary>
        /// hàm xóa theo id của đối tượng
        /// </summary>
        /// <param name="id">id của đối tượng</param>
        /// <returns>Số cột bị xóa</returns>
        /// Created By: NTTan (26/7/2021)
        public MISAEntity GetById(Guid id)
        {
            var entity = _baseRepository.GetById(id);
            return entity;
        }
        /// <summary>
        /// Hàm thêm mới dối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần thêm mới</param>
        /// <returns>Số bản ghi thay đổi trong DB</returns>
        public virtual ServiceResult Insert(MISAEntity entity)
        {

            entity.EntityState = EntityState.AddNew;
            // Thực hiện validate
            var isValidate = Validate(entity);
            if (isValidate == true)
            {

                var rowEntity = _baseRepository.Insert(entity);
                _serviceResult.Data = rowEntity;
                _serviceResult.UserMsg = Properties.Resources.InsertSuccess;         
            } 
            return _serviceResult;

        }
        /// <summary>
        /// Sửa đổi dữ liệu của đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần sửa đổi</param>
        /// <param name="id">id của đối tượng</param>
        /// <returns>Số bản ghi thay đổi</returns>
        public ServiceResult Update(MISAEntity entity)
        {
            entity.EntityState = EntityState.Update;
            var isValidate = Validate(entity); 
            if (isValidate == true)
            {
                var rowEntity = _baseRepository.Update(entity);
                _serviceResult.Data = rowEntity;
                _serviceResult.UserMsg = Properties.Resources.InsertSuccess;
            }          
            return _serviceResult;
        }
        /// <summary>
        /// hàm xóa theo id của đối tượng
        /// </summary>
        /// <param name="id">id của đối tượng</param>
        /// <returns>Số cột bị xóa</returns>
        /// Created By: NTTan (26/7/2021)
        public int Delete(Guid id)
        {
            var rowEntity = _baseRepository.Delete(id);
            return rowEntity;
        }
        /// <summary>
        /// Hàm để validate dữ liệu theo property
        /// </summary>
        /// <param name="entity">đối tượng</param>
        /// <returns></returns>
        private bool Validate(MISAEntity entity)
        {
            var isValidate = true;
            //đọc các property
            var properties = entity.GetType().GetProperties();
            foreach (var property in properties)
            {
                DisplayNameAttribute dp = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().SingleOrDefault();
                
                // kiểm tra xem có attribute cần phải validate không
                if (property.IsDefined(typeof(Required),false))
                {
                    //check bắt buộc nhập:
                    var propertyValue = property.GetValue(entity);
                    if (propertyValue == null)
                    {
                        _serviceResult.UserMsg = string.Format(Properties.Resources.ValidateError_Empty, dp.DisplayName);
                        _serviceResult.isValid = false;
                        isValidate = false;
                     
                    }
                }
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    //check trung dữ liệu
                    var entityDuplicate = _baseRepository.GetEntityByProperty(entity, property);
                    if (entityDuplicate!=null)
                    {
                        _serviceResult.UserMsg = string.Format(Properties.Resources.ValidateError_Exist, dp.DisplayName);
                        _serviceResult.isValid = false;
                        isValidate = false;
                       
                    }
                }
                if (property.IsDefined(typeof(MaxLength), false))
                {
                    // Lấy độ dài đã khai báo
                    var propertyValue = property.GetValue(entity);
                    var attributeMaxlength = property.GetCustomAttributes(typeof(MaxLength), true)[0];
                    var length = (attributeMaxlength as MaxLength).Value; // MAxlength(20,msg)
                 
                    if (propertyValue.ToString().Trim().Length > length)
                    {
                        _serviceResult.UserMsg = string.Format(Properties.Resources.ValidateError_MaxLength, dp.DisplayName);
                        _serviceResult.isValid = false;
                        isValidate = false;
                    }

                }

            }
            if (isValidate == true)
            {
                isValidate = ValidateCustom(entity);
            }
            return isValidate;
        }
        /// <summary>
        /// Hàm kiểm tra dữ liệu nghiệp vụ
        /// 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected virtual bool ValidateCustom(MISAEntity entity)
        {
            return true;
        }
        #endregion
    }
}

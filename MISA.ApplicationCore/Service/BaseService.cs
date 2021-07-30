using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Service
{
    public class BaseService<MISAEntity> : IBaseService<MISAEntity>
    {
        #region Field
        IBaseRepository<MISAEntity> _baseRepository;
        #endregion
        #region Constructor
        public BaseService(IBaseRepository<MISAEntity> baseRepository)
        {
            _baseRepository = baseRepository;
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
            var serviceResult = new ServiceResult();
            // Thực hiện validate
            var isValidate = Validate(entity);
            if (isValidate == true)
            {
                
                var rowEntity = _baseRepository.Insert(entity);
                if (rowEntity > 0)
                {
                    serviceResult.isValid = true;
                    serviceResult.Data = rowEntity;
                }
                return serviceResult;
            } else
            {
                serviceResult.isValid = false;
                return serviceResult;
            }
            
        }
        /// <summary>
        /// Sửa đổi dữ liệu của đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng cần sửa đổi</param>
        /// <param name="id">id của đối tượng</param>
        /// <returns>Số bản ghi thay đổi</returns>
        public int Update(MISAEntity entity, Guid id)
        {
            var rowEntity = _baseRepository.Update(entity, id);
            return rowEntity;
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
                // kiểm tra xem có attribute cần phải validate không
                if (property.IsDefined(typeof(Required),false))
                {
                    //check bắt buộc nhập:
                    var propertyValue = property.GetValue(entity);
                    if (propertyValue == null)
                    {
                        isValidate = false;
                    }
                }
                if (property.IsDefined(typeof(CheckDuplicate), false))
                {
                    //check trung dữ liệu
                    var entityDuplicate = _baseRepository.GetEntityByProperty(property.Name, property.GetValue(entity));
                    if (entityDuplicate!=null)
                    {
                        isValidate = false;
                    }
                } 
            }
            return isValidate;
        }
        #endregion
    }
}

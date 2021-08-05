using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Constants;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using MISA.ApplicationCore;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BaseEntityController<MISAEntity> : ControllerBase
    {
        #region Field
        ServiceResult _serviceResult = new ServiceResult();
        IBaseService<MISAEntity> _baseService;
        #endregion
        #region Constructor
        public BaseEntityController(IBaseService<MISAEntity> baseService)
        {
            _baseService = baseService;
        }
        #endregion
        #region Methods
        /// <summary>
        /// Lấy toàn bộ danh sách đối tượng
        /// </summary>
        /// <returns>danh sách đối tượng</returns>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var entities = _baseService.GetAll();
                //trả về kết quả
                if (entities.Count() > 0)
                    return Ok(entities);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                _serviceResult.MISACode = MISAConstants.MISAErrorException;
                _serviceResult.UserMsg = ApplicationCore.Properties.Resources.Error_Exception;
                _serviceResult.DevMsg = e.Message;
                return StatusCode(500, _serviceResult);
            }
        }
        /// <summary>
        /// Láy danh sách đối tượng theo id
        /// </summary>
        /// <param name="entityId">id của đối tượng</param>
        /// <returns>đối tượng</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var entity = _baseService.GetById(id);
                //trả về kết quả
                if (entity != null)
                    return Ok(entity);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                _serviceResult.MISACode = MISAConstants.MISAErrorException;
                _serviceResult.UserMsg = ApplicationCore.Properties.Resources.Error_Exception;
                _serviceResult.DevMsg = e.Message;
                return StatusCode(500, _serviceResult);
            }

        }
        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity">một đối tượng entity </param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Insert(MISAEntity entity)
        {
            try
            {
                var serviceResult = _baseService.Insert(entity);
                //trả về kết quả
                if (serviceResult.isValid == false)
                {
                    return BadRequest(serviceResult);
                }
                if (serviceResult.isValid == true && (int)serviceResult.Data > 0)
                    return StatusCode(201, serviceResult);
                else
                    return NoContent();
            }
            catch (Exception e)
            {
                _serviceResult.MISACode = MISAConstants.MISAErrorException;
                _serviceResult.UserMsg = ApplicationCore.Properties.Resources.Error_Exception;
                _serviceResult.DevMsg = e.Message;
                return StatusCode(500, _serviceResult);
            }
        }
        /// <summary>
        /// Sửa thông tin đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng đối tượng cần sửa</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(MISAEntity entity, string id)
        {
            try
            {
                var keyProperty = entity.GetType().GetProperty($"{typeof(MISAEntity).Name}Id");
                if (keyProperty.PropertyType == typeof(Guid))
                {
                    keyProperty.SetValue(entity, Guid.Parse(id));
                }
                else if (keyProperty.PropertyType == typeof(int))
                {
                    keyProperty.SetValue(entity, int.Parse(id));
                }
                else
                {
                    keyProperty.SetValue(entity, id);
                }

                var serviceResult = _baseService.Update(entity);
                //trả về kết quả
                if (serviceResult.isValid == false)
                {
                    return BadRequest(serviceResult);
                }
                if (serviceResult.isValid == true && (int)serviceResult.Data > 0)
                    return StatusCode(201, serviceResult);
                else
                    return NoContent();


            }
            catch (Exception e)
            {
                _serviceResult.MISACode = MISAConstants.MISAErrorException;
                _serviceResult.UserMsg = ApplicationCore.Properties.Resources.Error_Exception;
                _serviceResult.DevMsg = e.Message;
                return StatusCode(500, _serviceResult);
            }
        }
        /// <summary>
        /// Xóa đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var rowEntity = _baseService.Delete(id);
                if (rowEntity == 1)
                    return Ok();
                return NoContent();
            }
            catch (Exception e)
            {
                _serviceResult.MISACode = MISAConstants.MISAErrorException;
                _serviceResult.UserMsg = ApplicationCore.Properties.Resources.Error_Exception;
                _serviceResult.DevMsg = e.Message;
                return StatusCode(500, _serviceResult);
            }
        }
        #endregion
    }
}

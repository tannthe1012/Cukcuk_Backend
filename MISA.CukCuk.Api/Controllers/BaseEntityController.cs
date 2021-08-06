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
        public async Task<IActionResult> GetAll()
        {
            var entities = await _baseService.GetAll();
            //trả về kết quả
            if (entities.Count() > 0)
                return Ok(entities);
            else
                return NoContent();
        }
        /// <summary>
        /// Láy danh sách đối tượng theo id
        /// </summary>
        /// <param name="entityId">id của đối tượng</param>
        /// <returns>đối tượng</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var entity = await _baseService.GetById(id);
            //trả về kết quả
            if (entity != null)
                return Ok(entity);
            else
                return NoContent();
        }
        /// <summary>
        /// Thêm mới đối tượng
        /// </summary>
        /// <param name="entity">một đối tượng entity </param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Insert(MISAEntity entity)
        {
            var serviceResult = await _baseService.Insert(entity);
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
        /// <summary>
        /// Sửa thông tin đối tượng
        /// </summary>
        /// <param name="entity">Đối tượng đối tượng cần sửa</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(MISAEntity entity, string id)
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
            var serviceResult = await _baseService.Update(entity);
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
        /// <summary>
        /// Xóa đối tượng theo Id
        /// </summary>
        /// <param name="entityId">Id của đối tượng</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var rowEntity = await _baseService.Delete(id);
            if (rowEntity == 1)
                return Ok();
            return NoContent();
        }
        #endregion
    }
}

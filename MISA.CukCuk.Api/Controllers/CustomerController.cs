using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Controllers
{
    /// <summary>
    /// Api Danh sách khách hàng
    /// Created By: NTTan (24/7/2021)
    /// </summary>
    [Route("api/v1/Customers")]
    [ApiController]
    public class CustomerController : BaseEntityController<Customer>
    {
        #region Field
        /// <summary>
        /// Đói tượng thông báo lỗi trả về
        /// </summary>
        ICustomerService _customerService;

        #endregion
        #region constructor
        /// <summary>
        /// Hàm khởi tạo
        /// Created By: NTTan (26/7/2021)
        /// </summary>
        public CustomerController(ICustomerService customerService) : base(customerService)
        {
            _customerService = customerService;
        }
        #endregion     
    }
}


using Microsoft.AspNetCore.Http;
using MISA.ApplicationCore.Constants;
using MISA.ApplicationCore.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MISA.CukCuk.Api.Middlewares
{
    /// <summary>
    /// Xử lý lỗi
    /// </summary>
    /// CreatedBy: NTTan (02/08/2021)
    public class ErrorHandlingMiddleware
    {

        #region DECLARE
        private readonly RequestDelegate next;
        #endregion

        #region Constructor
        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        #endregion

        #region Methods
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(context, e);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception e)
        {
            // Trả về 500 nếu có lỗi, kết quả không như mong đợi
            var code = HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(
                new ServiceResult
                {
                    MISACode = MISAConstants.MISAErrorException,
                    UserMsg = ApplicationCore.Properties.Resources.Error_Exception,
                    DevMsg = e.Message,
        });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
        #endregion
    }
}
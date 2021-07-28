using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Entity.Model
{ 
    public class ResponseError
    {
        public string DevMsg { get; set; } = string.Empty;
        public string UserMsg { get; set; } = string.Empty;
        public string ErrorCode { get; set; } = string.Empty;
    }
}

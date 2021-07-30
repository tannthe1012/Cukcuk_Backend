using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    public class ServiceResult
    {
        public Boolean isValid { get; set; }
        public object Data { get; set; }
        public string DevMsg { get; set; } = string.Empty;
        public string UserMsg { get; set; } = string.Empty;
        public string MISACode { get; set; }
    }
}

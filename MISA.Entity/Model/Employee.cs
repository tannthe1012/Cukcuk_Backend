
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Entity.Model
{
    /// <summary>
    /// Nhân viên
    /// </summary>
    /// Created By: NTTan (21/7/2021)
    public class Employee
    {
        #region Property
        /// <summary>
        /// Id nhân viên (khóa chính)
        /// </summary>                          
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        ///// <summary>
        ///// Ngày sinh
        ///// </summary>
        //public DateTime DateOfBirth { get; set; }
        #endregion

        
    }
}

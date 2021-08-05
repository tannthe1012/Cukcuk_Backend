using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    /// <summary>
    /// phòng ban
    /// Created By: NTTan (24/7/2021)
    /// </summary>
    public class Department:BaseEntity
    {
        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        [PrimaryKey]
        public Guid DepartmentId { get; set; }

        /// <summary>
        /// Mã phòng ban
        /// </summary>
        [Required]
        [CheckDuplicate]
        [DisplayName("Mã phòng ban")]
        public string DepartmentCode { get; set; }

        /// <summary>
        /// Tên phòng ban
        /// </summary>
        public string DepartmentName { get; set; }

        /// <summary>
        /// Mô tả phòng ban
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Ngày tạo
        /// </summary>
  
        #endregion                                                         
    }
}

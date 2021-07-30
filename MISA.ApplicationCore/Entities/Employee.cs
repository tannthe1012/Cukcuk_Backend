
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
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
        [PrimaryKey]
        public Guid EmployeeId { get; set; }
        /// <summary>
        /// Mã nhân viên
        /// </summary>
        [CheckDuplicate]
        [Required]
        public string EmployeeCode { get; set; }
        /// <summary>
        /// Họ của nhân viên
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Tên của nhân viên
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Họ và tên
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// Giới tính
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Số CMND
        /// </summary>
        public string IdentityNumber { get; set; }
        /// <summary>
        /// Ngày cấp CMND
        /// </summary>
        public DateTime? IdentityDate { get; set; }
        /// <summary>
        /// Nơi cấp
        /// </summary>
        public string IdentityPlace { get; set; }
        /// <summary>
        /// Ngày tham gia công ty
        /// </summary>
        public DateTime? JoinDate { get; set; }
        /// <summary>
        /// Tình trạng hôn nhân
        /// </summary>
        public int? MartialStatus { get; set; }
        /// <summary>
        /// Trình độ học vấn
        /// </summary>
        public int? EducationalBackground { get; set; }
        /// <summary>
        /// Trình độ chuyên môn
        /// </summary>
        public Guid? QualificationId { get; set; }
        /// <summary>
        /// Mã phòng ban của nhân viên
        /// </summary>
        public Guid? DepartmentId { get; set; }
        /// <summary>
        /// Mã vị trí của nhân viên
        /// </summary>
        public Guid? PositionId { get; set; }
        /// <summary>
        /// Tình trạng công việc
        /// </summary>
        public int? WorkStatus { get; set; }
        /// <summary>
        /// Mã số thuế
        /// </summary>
        public string PersonalTaxCode { get; set; }
        /// <summary>
        /// Mức Lương cơ bản
        /// </summary>
        public Double? Salary { get; set; }
        #endregion


    }
}

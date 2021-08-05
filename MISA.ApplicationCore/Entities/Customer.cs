using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Entities
{
    public class Customer:BaseEntity
    {
        #region Property
        /// <summary>
        /// Id khách hàng (khóa chính)
        /// </summary>                          
        [PrimaryKey]
        public Guid CustomerId { get; set; }
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        [CheckDuplicate]
        [Required]
        [DisplayName("Mã khách hàng")]
        public string CustomerCode { get; set; }
        /// <summary>
        /// Họ của khách hàng
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Tên của khách hàng
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
        /// Địa chỉ
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime? DateOfBirth { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
       /// id nhóm khách hàng
       /// </summary>
        public Guid? CustomerGroupId { get; set; }
        /// <summary>
        /// Số tiền nợ
        /// </summary>
        public Double? DebitAmount { get; set; }
        /// <summary>
        /// mã thẻ thành viên
        /// </summary>
        [DisplayName("Mã thẻ thành viên")]
        public string MemberCardCode { get; set; }
        /// <summary>
        /// Tên công ty
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// Mã số thuế công ty
        /// </summary>
        public string CompanyTaxCode { get; set; }
        /// <summary>
        /// trạng thái theo dõi
        /// </summary>
        public int IsStopFollow { get; set; }
        #endregion

    }
}

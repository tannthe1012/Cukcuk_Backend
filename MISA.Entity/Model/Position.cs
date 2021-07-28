using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISA.Entity.Model
{
    /// <summary>
    /// Vị trí
    /// Created BY: NTTan (24/7/2021)
    /// </summary>
    public class Position
    {
        #region Properties
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid PositionId { get; set; }

        /// <summary>
        /// Mã vị trí
        /// </summary>
        public string PositionCode { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string PositionName { get; set; }

        /// <summary>
        /// Mô tả vị trí
        /// </summary>
        public string Description { get; set; }
       
        #endregion
    }
}

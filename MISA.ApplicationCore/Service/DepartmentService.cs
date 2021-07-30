using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using MISA.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Service
{
    public class DepartmentService : BaseService<Department>, IDepartmentService
    {
        #region Field
       
        IDepartmentRepository _dempartmentRepository;
        #endregion
        #region Constructor
        public DepartmentService(IDepartmentRepository dempartmentRepository) : base(dempartmentRepository)
        {
            _dempartmentRepository = dempartmentRepository;
        }
        #endregion
        #region Method
        public override ServiceResult Insert(Department department)
        {
            var serviceResult = new ServiceResult();

            if (string.IsNullOrEmpty(department.DepartmentCode))
            {
                serviceResult.isValid = false;
                serviceResult.UserMsg = Properties.Resources.ValidateError_DepartmentCode_Empty;
                return serviceResult;
            }
            //2.Mã nhân viên có trung hay không? không được phép trùng

            var res = _dempartmentRepository.GetByCode(department.DepartmentCode);
            if (res != null)
            {
     
                serviceResult.UserMsg = Properties.Resources.ValidateError_DepartmentCode_Exist;
                serviceResult.isValid = false;
                return serviceResult;
            }
            //3.Email có đúng định dạng hay không

            var rowAffects = _dempartmentRepository.Insert(department);
            serviceResult.isValid = true;
            serviceResult.Data = rowAffects;
            serviceResult.UserMsg = Properties.Resources.InsertSuccess;
            return serviceResult;
        }
        #endregion
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using MISA.ApplicationCore.Service;
using MISA.Entity;


namespace MISA.ApplicationCore
{
    public class EmployeeService: BaseService<Employee>,IEmployeeService
    {
        #region Field
        IEmployeeRepository _employeeRepository;
        #endregion
        #region Constructor
        public EmployeeService(IEmployeeRepository employeeRepository) : base(employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<Employee> GetEmployeePaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Method
        //public override ServiceResult Insert(Employee employee)
        //{
        //    var serviceResult = new ServiceResult();
            
        //    if (string.IsNullOrEmpty(employee.EmployeeCode))
        //    {
        //        serviceResult.isValid = false;
        //        serviceResult.UserMsg = Properties.Resources.ValidateError_EmployeeCode_Empty;
        //        return serviceResult;
        //    }
        //    //2.Mã nhân viên có trung hay không? không được phép trùng
            
        //    var res = _employeeRepository.GetByCode(employee.EmployeeCode);
        //    if (res != null)
        //    {
               
        //        serviceResult.UserMsg = Properties.Resources.ValidateError_EmployeeCode_Exist;
        //        serviceResult.isValid = false;
        //        return serviceResult;
        //    }
        //    //3.Email có đúng định dạng hay không

        //    var rowAffects = _employeeRepository.Insert(employee);
        //    serviceResult.isValid = true;
        //    serviceResult.Data = rowAffects;
        //    serviceResult.UserMsg = Properties.Resources.InsertSuccess;
        //    return serviceResult;
        //}
        #endregion
    }
}

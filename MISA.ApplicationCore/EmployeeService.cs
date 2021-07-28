using MISA.Infarstructure;
using MISA.Entity.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MISA.ApplicationCore.Entities;
using MISA.Entity;

namespace MISA.ApplicationCore
{
    public class EmployeeService
    {
        #region Field
        ResponseError _responseError = new ResponseError();
        #endregion
        #region Method
        // Lấy danh sách nhân viên
        public IEnumerable<Employee> GetAllEmployee()
        {
            var employeeContext = new EmployeeContext();
            var employees = employeeContext.GetAllEmployee();
            return employees;
        }

        //lấy nhân viên theo id
        public Employee GetEmployee(Guid id)
        {
            var employeeContext = new EmployeeContext();
            var employee = employeeContext.GetEmployee(id);
            return employee;
        }
        //thêm mới nhân viên
        public ServiceResult PostEmployee(Employee employee)
        {
            var serviceResult = new ServiceResult();
            var employeeContext = new EmployeeContext();
            if (string.IsNullOrEmpty(employee.EmployeeCode))
            {
                _responseError.ErrorCode = Properties.Resources.ErrorCode001;
                _responseError.DevMsg = null;
                _responseError.UserMsg = Properties.Resources.ValidateError_EmployeeCode_Empty;
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Data = _responseError;
                return serviceResult;
            }
            //2.Mã nhân viên có trung hay không? không được phép trùng
            
            var res = employeeContext.GetEmployeeByCode(employee.EmployeeCode);
            if (res != null)
            {
                _responseError.ErrorCode = Properties.Resources.ErrorCode001;
                _responseError.DevMsg = null;
                _responseError.UserMsg = Properties.Resources.ValidateError_EmployeeCode_Exist;
                serviceResult.MISACode = MISACode.NotValid;
                serviceResult.Data = _responseError;
                return serviceResult;
            }
            //3.Email có đúng định dạng hay không

            var rowAffects = employeeContext.PostEmployee(employee);
            serviceResult.MISACode = MISACode.IsValid;
            serviceResult.Data = rowAffects;
            serviceResult.Message = "Thêm Thành công";
            return serviceResult;
        }

        // sửa đổi nhân viên

        public int PutEmployee(Employee employee, Guid id)
        {
            var employeeContext = new EmployeeContext();
            var rowEmployee = employeeContext.PutEmployee(employee, id);
            return rowEmployee;
        }
        // xóa nhân viên nhân viên
        public int DeleteEmployee(Guid id)
        {
            var employeeContext = new EmployeeContext();
            var rowEmployee = employeeContext.DeleteEmployee(id);
            return rowEmployee;
        }

  
        #endregion
    }
}


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
        #endregion
        #region Method
        public object GetEmployeeFilterPaging(string employeeFilter, Guid? departmentId, Guid? positionId, int pageIndex, int pageSize)
        {
            return _employeeRepository.GetEmployeeFilterPaging(employeeFilter, departmentId, positionId, pageIndex, pageSize);
        }

        public string GetNewEmployeeCode()
        {
            return _employeeRepository.GetNewEmployeeCode();
        }

        #endregion
    }
}

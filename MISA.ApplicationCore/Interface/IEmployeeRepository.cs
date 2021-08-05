using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interface
{
    public interface IEmployeeRepository:IBaseRepository<Employee>
    {
        object GetEmployeeFilterPaging(string employeeFilter, Guid? departmentId, Guid? positionId, int pageIndex, int pageSize );
        public string GetNewEmployeeCode();
    }
}

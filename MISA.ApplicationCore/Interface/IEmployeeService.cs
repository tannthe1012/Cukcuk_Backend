using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interface
{
    public interface IEmployeeService: IBaseService<Employee>
    {
        IEnumerable<Employee> GetEmployeePaging(int limit, int offset);
    }
}

using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interface
{
    public interface ICustomerService : IBaseService<Customer>
    {
        IEnumerable<Customer> GetCustomerPaging(int limit, int offset);
    }
}

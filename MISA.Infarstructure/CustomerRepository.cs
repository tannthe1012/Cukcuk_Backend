using Microsoft.Extensions.Configuration;
using MISA.ApplicationCore.Entities;
using MISA.ApplicationCore.Interface;
using MISA.Infarstructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Reponsitory
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IConfiguration configuration) : base(configuration)
        {
        }
        public IEnumerable<Customer> GetCustomerPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }
    }
}

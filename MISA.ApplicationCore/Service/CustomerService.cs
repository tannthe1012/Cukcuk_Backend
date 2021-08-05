
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
    public class CustomerService : BaseService<Customer>, ICustomerService
    {
        #region Field
        ICustomerRepository _customerRepository;
        #endregion
        #region Constructor
        public CustomerService(ICustomerRepository customerRepository) : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public IEnumerable<Customer> GetCustomerPaging(int limit, int offset)
        {
            throw new NotImplementedException();
        }
        #endregion
           
    }
}

using MISA.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interface
{
    public interface IBaseService<MISAEntity>
    {
         Task<IEnumerable<MISAEntity>> GetAll();
         Task<MISAEntity> GetById(Guid id);
         Task<int> Delete(Guid id);
         Task<ServiceResult> Insert(MISAEntity entity);
         Task<ServiceResult> Update(MISAEntity entity);
    }
}

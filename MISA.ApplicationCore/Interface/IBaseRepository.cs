using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ApplicationCore.Interface
{
    public interface IBaseRepository<MISAEntity>
    {
        Task<IEnumerable<MISAEntity>> GetAll();
        Task<MISAEntity> GetById(Guid id);
        Task<int> Delete(Guid id);
        Task<MISAEntity> GetByCode(string Code);
        Task<int> Insert(MISAEntity entity);
        Task<int> Update(MISAEntity entity);
        Task<MISAEntity> GetEntityByProperty(MISAEntity entity, PropertyInfo property);
    }
}

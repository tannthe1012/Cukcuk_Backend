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
        IEnumerable<MISAEntity> GetAll();
        MISAEntity GetById(Guid id);
        int Delete(Guid id);
        MISAEntity GetByCode(string Code);
        int Insert(MISAEntity entity);
        int Update(MISAEntity entity);
        MISAEntity GetEntityByProperty(MISAEntity entity, PropertyInfo property);
    }
}

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
        public IEnumerable<MISAEntity> GetAll();
        public MISAEntity GetById(Guid id);
        public int Delete(Guid id);
        public MISAEntity GetByCode(string Code);
        public int Insert(MISAEntity entity);
        public int Update(MISAEntity entity, Guid id);
        public MISAEntity GetEntityByProperty(string propertyName, object propertyValue);
    }
}

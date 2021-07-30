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
        public IEnumerable<MISAEntity> GetAll();
        public MISAEntity GetById(Guid id);
        public int Delete(Guid id);
        public ServiceResult Insert(MISAEntity entity);
        public int Update(MISAEntity entity, Guid id);
    }
}

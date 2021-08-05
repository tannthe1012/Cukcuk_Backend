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
         IEnumerable<MISAEntity> GetAll();
         MISAEntity GetById(Guid id);
         int Delete(Guid id);
         ServiceResult Insert(MISAEntity entity);
         ServiceResult Update(MISAEntity entity);
    }
}

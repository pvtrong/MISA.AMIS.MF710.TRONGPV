using MISA.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Service.Interface
{
    public interface IBaseService<MISAEntity>
    {
        ServiceResult GetData(Param param = null);
         ServiceResult GetCodeMax();
        ServiceResult Insert(MISAEntity misaEntity);
        ServiceResult Update(MISAEntity entity);
        public  ServiceResult Delete(string[] ids);

    }
}

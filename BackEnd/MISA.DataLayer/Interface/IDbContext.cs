﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer.Interface
{
    public interface IDbContext<MISAEntity>
    {
        #region Method
        IEnumerable<MISAEntity> GetData(string sqlCommand = null, object parameter = null, CommandType commandType = CommandType.StoredProcedure);
         IEnumerable<MISAEntity> GetCodeMax(string sqlCommand = null, CommandType commandType = CommandType.StoredProcedure);
        int InsertObject(MISAEntity entities);
        int UpdateObject(MISAEntity entities);
        public int DeleteObject(string[] ids);
        #endregion
    }
}

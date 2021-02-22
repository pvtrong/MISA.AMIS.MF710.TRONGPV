using Dapper;
using MISA.DataLayer.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace MISA.DataLayer
{
    public class DbContext<MISAEntity> : IDbContext<MISAEntity>
    {
        #region DECLARE
        /// <summary>
        ///  Khởi tạo kết nối cơ sở dữ liệu
        /// </summary>
        protected string _connectionString = "User Id=dev;Host=47.241.69.179;port=3306;password=12345678;Database=MF710_TRONGPV_AMIS;Character Set=utf8";
        protected IDbConnection _dbConnection;
        #endregion

        #region Constructor
        public DbContext()
        {
            _dbConnection = new MySqlConnector.MySqlConnection(_connectionString);
        }
        #endregion



        #region Method 
        /// <summary>
        /// Hàm lấy dữ liệu theo nhiều tiêu chí khác nhau
        /// </summary>
        /// <typeparam name="TEntity">Kiểu dữ liệu lấy</typeparam>
        /// <param name="sqlCommand">Câu lệnh truy vấn</param>
        /// <param name="parameter">Bộ tiêu chí</param>
        /// <param name="commandType">loại kiểu câu lệnh truy vấn</param>
        /// <returns>Dữ liệu thỏa mãn bộ tiêu chí</returns>
        /// CreatedBy PVTRONG (7/2/2021)
        public IEnumerable<MISAEntity> GetData(string sqlCommand = null, object parameter = null, CommandType commandType = CommandType.StoredProcedure)
        {
            if (sqlCommand == null)
            {
                var className = typeof(MISAEntity).Name;
                sqlCommand = $"Proc_GetAll{className}";
            }

            // Khởi tạo các CommandText
            var entities = _dbConnection.Query<MISAEntity>(sqlCommand, param: parameter, commandType: commandType);

            // Trả về dữ liệu 
            return entities;
        }

        /// <summary>
        /// Hàm lấy mã số lớn nhất của đối tượng
        /// </summary>
        /// <param name="sqlCommand">câu lệnh truy vấn</param>
        /// <param name="commandType">loại lệnh truy vấn</param>
        /// <returns>Mã lớn nhất của đối tượng</returns>
        /// CreatedBy PVTRONG (19/02/2021)
        public IEnumerable<MISAEntity> GetCodeMax(string sqlCommand = null, CommandType commandType = CommandType.StoredProcedure)
        {
            if(sqlCommand == null)
            {
                var className = typeof(MISAEntity).Name;
                sqlCommand = $"Proc_GetCodeMax{className}";
            }
            // Khởi tạo các CommandText
            var entities = _dbConnection.Query<MISAEntity>(sqlCommand, commandType: commandType);

            // Trả về dữ liệu 
            return entities;
        }


        // Lấy thông tin nhân viên theo mã nhân viên:

        // Thêm mới object:
        /// <summary>
        /// Thêm mới object
        /// </summary>
        /// <param name="entities">entities</param>
        /// <returns>Số bản ghi được thêm mới</returns>
        /// CreatedBy PVTRONG (7/2/2021)
        public int InsertObject(MISAEntity entities)
        {
            var className = typeof(MISAEntity).Name;
            var res = _dbConnection.Execute($"Proc_Insert{className}", param: entities, commandType: CommandType.StoredProcedure);
            // Trả về số bản ghi được thêm mới
            return res;
        }

        // Sửa thông tin object
        /// <summary>
        /// Hàm chỉnh sửa thông tin đối tượng
        /// </summary>
        /// <param name="entities">Đối tượng cần chỉnh sửa</param>
        /// <returns>Số bản ghi được chỉnh sửa</returns>
        /// CreatedBy PVTRONG (08/02/2021)
        public int UpdateObject(MISAEntity entities)
        {
            var className = typeof(MISAEntity).Name;
            var res = _dbConnection.Execute($"Proc_Update{className}", param: entities, commandType: CommandType.StoredProcedure);
            // Trả về số bản ghi được sửa
            return res;
        }

        /// <summary>
        /// Hàm xóa các đối tượng
        /// </summary>
        /// <param name="ids">Mảng Id của các đối tượng đó</param>
        /// <returns>Số lượng bản ghi được xóa</returns>
        /// CreatedBy PVTRONG (17/02/2021)
        public int DeleteObject(string[] ids)
        {
            var className = typeof(MISAEntity).Name;
            var res = 0;
            foreach (string id in ids)
            {
                if(className == "Employee")
                {
                    _dbConnection.Execute($"Proc_Delete{className}", new { EmployeeId = id.ToString() }, commandType: CommandType.StoredProcedure);
                    res++;
                }
                else
                {
                    _dbConnection.Execute($"Proc_Delete{className}", new { EmployeeBankId = id }, commandType: CommandType.StoredProcedure);
                    res++;
                }
                
            }
                
            // Trả về số bản ghi được sửa
            return res;
        }

        #endregion
    }
}

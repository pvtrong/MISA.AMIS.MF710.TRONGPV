using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class EmployeeBank
    {
        /// <summary>
        /// Khóa chính
        /// </summary>
        public Guid employeeBankId { get; set; }


        /// <summary>
        /// Khóa ngoại
        /// </summary>
        public Guid employeeId { get; set; }

        /// <summary>
        /// Số tài khoản
        /// </summary>
        public string bankNumber { get; set; }


        /// <summary>
        /// Tên ngân hàng
        /// </summary>
        public string bankName { get; set; }

        /// <summary>
        /// Chi nhánh
        /// </summary>
        public string branch { get; set; }

        /// <summary>
        /// Ngân hàng của tỉnh/thành phố
        /// </summary>
        public string bankCity { get; set; }

        /// <summary>
        /// Tình trạng tài khoản (0: đang sử dụng, 1: ngừng sử dụng)
        /// </summary>
        public int status { get; set; }


        
    }
}

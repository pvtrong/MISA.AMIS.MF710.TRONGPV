using System;
using System.Collections.Generic;
using System.Text;

namespace MISA.Common.Models
{
    public class Param
    {
        public string employeeId { get; set; }
        public string employeeCode { get; set; }
        public string keyword { get; set; }
        public int LimitParam { get; set; }
        public int OffsetParam { get; set; }
    }
}

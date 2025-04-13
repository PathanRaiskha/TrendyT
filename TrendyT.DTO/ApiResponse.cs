using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrendyT.DTO
{
    public class ApiResponse
    {
        public Object? Result { get; set; }
        public String Message { get; set; }
        public bool IsSuccess { get; set; }
        public ApiResponse()
        {
            Result = null;
            Message = "";
            IsSuccess = false;
        }
        public ApiResponse(Object? obj,string msg, bool isSuccess)
        {
            Result=obj;
            Message = msg;
            IsSuccess = isSuccess;
        }
    }
}

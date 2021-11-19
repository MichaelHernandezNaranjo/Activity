using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }
        public BusinessException(string message, System.Net.HttpStatusCode error_type = System.Net.HttpStatusCode.BadRequest) : base(message.Contains(Constant.General.Split) ? message : error_type.GetHashCode() + Constant.General.Split + error_type.ToString() + Constant.General.Split + message)
        {

        }
    }
}

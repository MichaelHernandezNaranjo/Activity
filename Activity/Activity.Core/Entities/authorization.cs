using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Entities
{
    public class authorization
    {
        public string UserName { get; set; }
    }

    public class authorizationRequest : authorization
    {
        public string Password { get; set; }
    }
    public class authorizationResponse : authorization
    {
        public int ApplicationId { get; set; }
        public int AuthorizationId { get; set; }

    }

}

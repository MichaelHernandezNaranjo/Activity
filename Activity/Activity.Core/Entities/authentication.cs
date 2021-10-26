using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Entities
{
    public class authentication
    {
        public int CompanyId { get; set; }
        public string Email { get; set; }
    }

    public class authenticationRequest : authentication
    {
        public string Password { get; set; }
    }
    public class authenticationResponse : authentication
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}

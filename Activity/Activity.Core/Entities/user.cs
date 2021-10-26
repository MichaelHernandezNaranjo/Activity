using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Entities
{

    public class user
    {
        public int CompanyId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public int  CreationUserId { get; set; }
    }
    public class userRequest : user
    {

    }
    public class userResponse : user
    {
        public string RoleName { get; set; }
    }
}

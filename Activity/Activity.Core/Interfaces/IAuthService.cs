using Activity.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Interfaces
{
    public interface IAuthService
    {
        //Task<user> Authenticate(string userId, string password);
        Task<authorization> Authorization(string userName, string password);
    }
}

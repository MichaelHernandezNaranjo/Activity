using Activity.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Interfaces
{
    public interface IAuthRepository /*: IRepository<authorization>*/
    {
        Task<authorization> Authorization(string userName, string password);
    }

}

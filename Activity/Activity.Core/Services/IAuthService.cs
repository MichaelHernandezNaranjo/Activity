using Activity.Core.Entities;
using Activity.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Services
{
    public class authService : IAuthService
    {
        private readonly IAuthRepository _authRepository;

        public authService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        //public async Task<user> Authenticate(string userId, string password)
        //{
        //    return await _authRepository.Authenticate(userId, password);
        //}

        public async Task<authorization> Authorization(string userName, string password)
        {
            return await _authRepository.Authorization(userName, securityService.Encrypt(password));
        }
    }

}

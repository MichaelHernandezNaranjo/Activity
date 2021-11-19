using Activity.Core.Entities;
using Activity.Core.Exceptions;
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

        public async Task<authenticationResponse> Authentication(authenticationRequest _authenticationRequest)
        {
            _authenticationRequest.Password = securityService.Encrypt(_authenticationRequest.Password);
            var res = await _authRepository.Authentication(_authenticationRequest);
            if (res == null) throw new BusinessException("Usuario y/o contraseña incorrecto");
            return res;
        }

    }

}

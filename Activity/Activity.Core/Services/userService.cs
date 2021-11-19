using Activity.Core.Entities;
using Activity.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Services
{
    public class userService : IService2<userRequest, userResponse>
    {
        private readonly IRepository2<userRequest, userResponse> _userRepository;
        public userService(IRepository2<userRequest, userResponse> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<List<userResponse>> GetAll(int CompanyId)
        {
            return await _userRepository.GetAll(CompanyId);
        }

        public async Task<userResponse> GetById(int CompanyId, int UserId)
        {
            return await _userRepository.GetById(CompanyId, UserId);
        }

        public async Task<int> Add(userRequest entity)
        {
            return await _userRepository.Add(entity);
        }

        public async Task<bool> Delete(int CompanyId, int UserId)
        {
            return await _userRepository.Delete(CompanyId, UserId);
        }

        public async Task<bool> Update(userRequest entity)
        {
            return await _userRepository.Update(entity);
        }
    }
}

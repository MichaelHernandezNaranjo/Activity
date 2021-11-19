using Activity.Core.Entities;
using Activity.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Services
{
    public class companyService : IService<companyRequest, companyResponse>
    {
        private readonly IRepository<companyRequest, companyResponse> _companyRepository;
        public companyService(IRepository<companyRequest, companyResponse> companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<List<companyResponse>> GetAll()
        {
            return await _companyRepository.GetAll();
        }

        public async Task<companyResponse> GetById(int id)
        {
            return await _companyRepository.GetById(id);
        }

        public async Task<int> Add(companyRequest entity)
        {
            return await _companyRepository.Add(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _companyRepository.Delete(id);
        }

        public async Task<bool> Update(companyRequest entity)
        {
            return await _companyRepository.Update(entity);
        }
    }
}

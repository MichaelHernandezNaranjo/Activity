using Activity.Core.Entities;
using Activity.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Services
{
    public class sprintService : IService3<sprintRequest, sprintResponse>
    {
        private readonly IRepository3<sprintRequest, sprintResponse> _sprintRepository;
        public sprintService(IRepository3<sprintRequest, sprintResponse> sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }

        public async Task<List<sprintResponse>> GetAll(int CompanyId, int ProjecId)
        {
            return await _sprintRepository.GetAll(CompanyId, ProjecId);
        }

        public async Task<sprintResponse> GetById(int CompanyId, int ProjecId, int SprintId)
        {
            return await _sprintRepository.GetById(CompanyId, ProjecId, SprintId);
        }

        public async Task<int> Add(sprintRequest entity)
        {
            return await _sprintRepository.Add(entity);
        }

        public async Task<bool> Delete(int CompanyId, int ProjecId, int SprintId)
        {
            return await _sprintRepository.Delete(CompanyId, ProjecId, SprintId);
        }

        public async Task<bool> Update(sprintRequest entity)
        {
            return await _sprintRepository.Update(entity);
        }

        public Task<List<sprintResponse>> GetWhere(int id, int id2, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

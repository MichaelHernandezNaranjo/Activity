using Activity.Core.Entities;
using Activity.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Services
{
    public class taskStatusService : IService3<taskStatusRequest,taskStatusResponse>
    {
        private readonly IRepository3<taskStatusRequest,taskStatusResponse> _taskStatusRepository;
        public taskStatusService(IRepository3<taskStatusRequest,taskStatusResponse> taskStatusRepository)
        {
            _taskStatusRepository = taskStatusRepository;
        }

        public async Task<List<taskStatusResponse>> GetAll(int CompanyId, int ProjecId)
        {
            return await _taskStatusRepository.GetAll(CompanyId, ProjecId);
        }

        public async Task<taskStatusResponse> GetById(int CompanyId, int ProjecId, int TaskStatusId)
        {
            return await _taskStatusRepository.GetById(CompanyId, ProjecId,TaskStatusId);
        }

        public async Task<int> Add(taskStatusRequest entity)
        {
            return await _taskStatusRepository.Add(entity);
        }

        public async Task<bool> Delete(int CompanyId, int ProjecId, int TaskStatusId)
        {
            return await _taskStatusRepository.Delete(CompanyId, ProjecId,TaskStatusId);
        }

        public async Task<bool> Update(taskStatusRequest entity)
        {
            return await _taskStatusRepository.Update(entity);
        }

        public Task<List<taskStatusResponse>> GetWhere(int id, int id2, string Where)
        {
            throw new NotImplementedException();
        }
    }
}

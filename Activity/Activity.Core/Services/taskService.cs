using Activity.Core.Entities;
using Activity.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Services
{
    public class taskService : IService3<taskRequest, taskResponse>
    {
        private readonly IRepository3<taskRequest, taskResponse> _taskRepository;
        public taskService(IRepository3<taskRequest, taskResponse> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async Task<List<taskResponse>> GetAll(int CompanyId, int ProjecId)
        {
            return await _taskRepository.GetAll(CompanyId, ProjecId);
        }

        public async Task<List<taskResponse>> GetWhere(int CompanyId, int ProjecId, string Where)
        {
            Where = Where.Replace(":","=");
            List<string> lstWhere = Where.Split(",").ToList();
            return await _taskRepository.GetWhere(CompanyId, ProjecId, lstWhere);
        }

        public async Task<taskResponse> GetById(int CompanyId, int ProjecId, int TaskId)
        {
            return await _taskRepository.GetById(CompanyId, ProjecId, TaskId);
        }

        public async Task<int> Add(taskRequest entity)
        {
            return await _taskRepository.Add(entity);
        }

        public async Task<bool> Delete(int CompanyId, int ProjecId, int TaskId)
        {
            return await _taskRepository.Delete(CompanyId, ProjecId, TaskId);
        }

        public async Task<bool> Update(taskRequest entity)
        {
            return await _taskRepository.Update(entity);
        }

       
    }
}

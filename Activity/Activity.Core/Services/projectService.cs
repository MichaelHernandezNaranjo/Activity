using Activity.Core.Entities;
using Activity.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Core.Services
{
    public class projectService : IService2<projectRequest, projectResponse>
    {
        private readonly IRepository2<projectRequest, projectResponse> _projectRepository;
        public projectService(IRepository2<projectRequest, projectResponse> projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<List<projectResponse>> GetAll(int CompanyId)
        {
            return await _projectRepository.GetAll(CompanyId);
        }

        public async Task<projectResponse> GetById(int CompanyId, int ProjectId)
        {
            return await _projectRepository.GetById(CompanyId, ProjectId);
        }

        public async Task<int> Add(projectRequest entity)
        {
            return await _projectRepository.Add(entity);
        }

        public async Task<bool> Delete(int CompanyId, int ProjectId)
        {
            return await _projectRepository.Delete(CompanyId, ProjectId);
        }

        public async Task<bool> Update(projectRequest entity)
        {
            return await _projectRepository.Update(entity);
        }
    }
}

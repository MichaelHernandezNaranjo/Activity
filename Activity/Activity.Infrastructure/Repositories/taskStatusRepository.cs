using Activity.Core.Entities;
using Activity.Core.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Activity.Infrastructure.Repositories
{
    public class taskStatusRepository : BaseRepository, IRepository3<taskStatusRequest, taskStatusResponse>
    {
        public taskStatusRepository(IConfiguration configuration)
            : base(configuration)
        { }
        public async Task<List<taskStatusResponse>> GetAll(int CompanyId, int ProjectId)
        {
            var query = "select * from [TaskStatus] where CompanyId = @CompanyId and ProjectId=@ProjectId order by TaskStatusId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("ProjectId", ProjectId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryAsync<taskStatusResponse>(query, parameters);
                return res.ToList();
            }
        }

        public async Task<taskStatusResponse> GetById(int CompanyId, int ProjetId, int TaskStatusId)
        {
            var query = "select * from [TaskStatus] where CompanyId=@CompanyId and ProjetId = @ProjetId and TaskStatusId=@TaskStatusId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("ProjetId", ProjetId, DbType.Int32);
            parameters.Add("TaskStatusId", TaskStatusId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryFirstAsync<taskStatusResponse>(query, parameters);
                return res;
            }
        }

        public async Task<int> Add(taskStatusRequest entity)
        {
            var query = "declare @Consecutivo int set @Consecutivo = (select isnull(max(TaskStatusId),0) + 1 from [TaskStatus] where CompanyId = @CompanyId and ProjetId = @ProjetId);";
            query += "insert into [TaskStatus] OUTPUT Inserted.TaskStatusId values (@CompanyId,@ProjetId,@Consecutivo,@TaskStatusName,@Active,getdate(),@CreationUserId);";
            var parameters = new DynamicParameters();
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryFirstAsync<int>(query, entity);
                return res;
            }
        }

        public async Task<bool> Update(taskStatusRequest entity)
        { 
            var query = "update [TaskStatus] set TaskStatusName=@TaskStatusName,Active=@Active where CompanyId=@CompanyId and ProjetId = @ProjetId and TaskStatusId=@TaskStatusId;";
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, entity);
                return res > 0;
            }
        }

        public async Task<bool> Delete(int CompanyId, int ProjetId, int TaskStatusId)
        {
            var query = "delete from [TaskStatus] where CompanyId=@CompanyId and ProjetId=@ProjetId and TaskStatusId=@TaskStatusId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("ProjetId", ProjetId, DbType.Int32);
            parameters.Add("TaskStatusId", TaskStatusId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, parameters);
                return res > 0;
            }
        }

        public Task<List<taskStatusResponse>> GetWhere(int id, int id2, List<string> Where)
        {
            throw new NotImplementedException();
        }
    }
}

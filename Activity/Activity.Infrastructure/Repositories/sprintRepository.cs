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
    public class sprintRepository : BaseRepository, IRepository3<sprintRequest, sprintResponse>
    {
        public sprintRepository(IConfiguration configuration)
            : base(configuration)
        { }
        public async Task<List<sprintResponse>> GetAll(int CompanyId, int ProjectId)
        {
            var query = "select * from [Sprint] where CompanyId = @CompanyId and ProjectId=@ProjectId order by SprintId desc;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("ProjectId", ProjectId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryAsync<sprintResponse>(query, parameters);
                return res.ToList();
            }
        }

        public async Task<sprintResponse> GetById(int CompanyId, int ProjetId, int SprintId)
        {
            var query = "select * from [Sprint] where CompanyId=@CompanyId and ProjetId = @ProjetId and SprintId=@SprintId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("ProjetId", ProjetId, DbType.Int32);
            parameters.Add("SprintId", SprintId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryFirstAsync<sprintResponse>(query, parameters);
                return res;
            }
        }

        public async Task<int> Add(sprintRequest entity)
        {
            var query = "declare @Consecutivo int set @Consecutivo = (select isnull(max(SprintId),0) + 1 from [Sprint] where CompanyId = @CompanyId and ProjetId = @ProjetId);";
            query += "insert into [Sprint] OUTPUT Inserted.SprintId values (@CompanyId,@ProjetId,@Consecutivo,@SprintName,@Description,@Active,getdate(),@CreationUserId);";
            var parameters = new DynamicParameters();
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryFirstAsync<int>(query, entity);
                return res;
            }
        }

        public async Task<bool> Update(sprintRequest entity)
        { 
            var query = "update [Sprint] set SprintName=@SprintName,Description=@Description,Active=@Active where CompanyId=@CompanyId and ProjetId = @ProjetId and SprintId=@SprintId;";
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, entity);
                return res > 0;
            }
        }

        public async Task<bool> Delete(int CompanyId, int ProjetId, int SprintId)
        {
            var query = "delete from [Sprint] where CompanyId=@CompanyId and ProjetId=@ProjetId and SprintId=@SprintId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("ProjetId", ProjetId, DbType.Int32);
            parameters.Add("SprintId", SprintId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, parameters);
                return res > 0;
            }
        }

        public Task<List<sprintResponse>> GetWhere(int id, int id2, List<string> Where)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class projectRepository : BaseRepository, IRepository2<projectRequest, projectResponse>
    {
        public projectRepository(IConfiguration configuration)
            : base(configuration)
        { }
        public async Task<List<projectResponse>> GetAll(int CompanyId)
        {
            var query = "select * from [Project] where CompanyId = @CompanyId order by ProjectId desc;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryAsync<projectResponse>(query, parameters);
                foreach (var item in res)
                {
                    parameters = new DynamicParameters();
                    parameters.Add("CompanyId", CompanyId, DbType.Int32);
                    parameters.Add("ProjectId", item.ProjectId, DbType.Int32);
                    query = "select t2.UserId, t2.UserName from [ProjectUser] t1 inner join [User] t2 on (t1.CompanyId = t2.CompanyId and t1.UserId = t2.UserId) where t1.CompanyId = @CompanyId and t1.ProjectId=@ProjectId;";
                    var res_user = await connection.QueryAsync<projectUserResponse>(query, parameters);
                    item.ListProjectUser.AddRange(res_user);
                }
                return res.ToList();
            }
        }

        public async Task<projectResponse> GetById(int CompanyId, int ProjetId)
        {
            var query = "select * from [Project] where CompanyId=@CompanyId and ProjetId = @ProjetId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("ProjetId", ProjetId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryFirstAsync<projectResponse>(query, parameters);
                return res;
            }
        }

        public async Task<int> Add(projectRequest entity)
        {
            var query = "declare @Consecutivo int set @Consecutivo = (select isnull(max(ProjectId),0) + 1 from [Project] where CompanyId = @CompanyId);";
            query += "insert into [Project] OUTPUT Inserted.ProjectId values (@CompanyId,@Consecutivo,@ProjectName,@Description,@Active,getdate(),@CreationUserId);";
            var parameters = new DynamicParameters();
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryFirstAsync<int>(query, entity);
                return res;
            }
        }

        public async Task<bool> Update(projectRequest entity)
        { 
            var query = "update [Project] set ProjectName=@ProjectName,Description=@Description,Active=@Active where CompanyId=@CompanyId and ProjectId=@ProjectId;";
            query += $"delete from [ProjectUser] where CompanyId=@CompanyId and ProjectId=@ProjectId;";
            foreach (var item in entity.ListProjectUser)
            {
                query += $"insert into [ProjectUser] values (@CompanyId,@ProjectId,{item.UserId});";
            }
            
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, entity);
                return res > 0;
            }
        }

        public async Task<bool> Delete(int CompanyId, int ProjetId)
        {
            var query = "delete from [Project] where CompanyId=@CompanyId and ProjectId=@ProjectId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("ProjetId", ProjetId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, parameters);
                return res > 0;
            }
        }

        
    }
}

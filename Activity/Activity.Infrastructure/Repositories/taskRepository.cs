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
    public class taskRepository : BaseRepository, IRepository3<taskRequest, taskResponse>
    {
        public taskRepository(IConfiguration configuration)
            : base(configuration)
        { }

        public async Task<List<taskResponse>> GetWhere(int CompanyId, int ProjectId, List<string> Where)
        {
            Where = Where.Select(x => $"t1.{x}").ToList();
            string strWhere = string.Join("and ", Where);
            strWhere = strWhere != "" ? "and " + strWhere : strWhere;
            var query = "select t1.CompanyId, t1.ProjectId, t1.TaskId, t1.TaskName, t1.Description,t2.TaskStatusId, t1.SprintId, t1.StartDate, t1.EndDate,t1.Duracion,t1.DuracionUnit, t2.TaskStatusName,t1.Active,t1.CreationDate, t1.CreationUserId from Task t1";
            query += " inner join TaskStatus t2 on (t1.CompanyId = t2.CompanyId and t1.ProjectId = t2.ProjectId and t1.TaskStatusId = t2.TaskStatusId)";
            query += $" where t1.CompanyId = @CompanyId and t1.ProjectId=@ProjectId {strWhere} order by TaskId desc;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("ProjectId", ProjectId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryAsync<taskResponse>(query, parameters);
                return res.ToList();
            }
        }
        public async Task<List<taskResponse>> GetAll(int CompanyId, int ProjectId)
        {
            var query = "select * from Task where CompanyId = @CompanyId and ProjectId=@ProjectId order by TaskId desc;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("ProjectId", ProjectId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryAsync<taskResponse>(query, parameters);
                return res.ToList();
            }
        }

        public async Task<taskResponse> GetById(int CompanyId, int ProjetId, int TaskId)
        {
            var query = "select * from Task where CompanyId=@CompanyId and ProjetId = @ProjetId and TaskId=@TaskId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("ProjetId", ProjetId, DbType.Int32);
            parameters.Add("TaskId", TaskId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryFirstAsync<taskResponse>(query, parameters);
                return res;
            }
        }

        public async Task<int> Add(taskRequest entity)
        {
            var query = "declare @Consecutivo int set @Consecutivo = (select isnull(max(TaskId),0) + 1 from Task where CompanyId = @CompanyId and ProjetId = @ProjetId and SprintId=@SprintId);";
            query += "insert into Task OUTPUT Inserted.TaskId values (@CompanyId,@ProjetId,@SprintId,@Consecutivo,@TaskName,@Description,@Active,getdate(),@CreationUserId);";
            var parameters = new DynamicParameters();
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryFirstAsync<int>(query, entity);
                return res;
            }
        }

        public async Task<bool> Update(taskRequest entity)
        { 
            var query = "update Task set TaskName=@TaskName,Description=@Description,Active=@Active where CompanyId=@CompanyId and ProjetId = @ProjetId and SprintId=@SprintId and TaskId=@TaskId;";
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, entity);
                return res > 0;
            }
        }

        public async Task<bool> Delete(int CompanyId, int ProjetId, int TaskId)
        {
            var query = "delete from Task where CompanyId=@CompanyId and ProjetId=@ProjetId and TaskId=@TaskId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("ProjetId", ProjetId, DbType.Int32);
            parameters.Add("TaskId", TaskId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, parameters);
                return res > 0;
            }
        }

        
    }
}

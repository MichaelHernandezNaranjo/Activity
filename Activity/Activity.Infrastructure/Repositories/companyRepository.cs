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
    public class companyRepository : BaseRepository, IRepository<companyRequest, companyResponse>
    {
        public companyRepository(IConfiguration configuration)
            : base(configuration)
        { }
        public async Task<List<companyResponse>> GetAll()
        {
            var query = "select * from [Company];";
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryAsync<companyResponse>(query);
                return res.ToList();
            }
        }

        public async Task<companyResponse> GetById(int id)
        {
            var query = "select * from [Company] where CompanyId=@CompanyId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", id, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryFirstAsync<companyResponse>(query, parameters);
                return res;
            }
        }

        public async Task<int> Add(companyRequest entity)
        {
            var query = "declare @CompanyId int set @CompanyId = select isnull(max(CompanyId),0) + 1 from [Company];";
            query += "insert into [Company] OUTPUT Inserted.CompanyId values (@CompanyId,@CompanyName,@Active,getdate(),@CreationUserId);";
            //
            var parameters = new DynamicParameters();
            parameters.Add("CompanyName", entity.CompanyName, DbType.String);
            parameters.Add("Active", entity.Active, DbType.Boolean);
            parameters.Add("CreationUserId", entity.CreationUserId, DbType.String);
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, parameters);
                return res;
            }
        }

        public async Task<bool> Update(companyRequest entity)
        {
            var query = "update [Company] set CompanyName=@CompanyName,Active=@Active where CompanyId=@CompanyId;";
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, entity);
                return res > 0;
            }
        }

        public async Task<bool> Delete(int CompanyId)
        {
            var query = "delete from [Company] where CompanyId=@CompanyId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, parameters);
                return res > 0;
            }
        }
    }
}

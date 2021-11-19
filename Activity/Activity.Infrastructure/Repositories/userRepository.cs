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
    public class userRepository : BaseRepository, IRepository2<userRequest, userResponse>
    {
        public userRepository(IConfiguration configuration)
            : base(configuration)
        { }
        public async Task<List<userResponse>> GetAll(int CompanyId)
        {
            var query = "select * from [User] where CompanyId = @CompanyId order by UserId desc;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryAsync<userResponse>(query, parameters);
                return res.ToList();
            }
        }

        public async Task<userResponse> GetById(int CompanyId, int UserId)
        {
            var query = "select * from [User] where CompanyId=@CompanyId and UserId = @UserId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("UserId", UserId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryFirstAsync<userResponse>(query, parameters);
                return res;
            }
        }

        public async Task<int> Add(userRequest entity)
        {
            var query = "declare @Consecutivo int set @Consecutivo = (select isnull(max(UserId),0) + 1 from [User] where CompanyId = @CompanyId);";
            query += "insert into [User] OUTPUT Inserted.UserId values (@CompanyId,@Consecutivo,@UserName,'e10adc3949ba59abbe56e057f20f883e',@RoleId,@Active,getdate(),@CreationUserId);";
            var parameters = new DynamicParameters();
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryFirstAsync<int>(query, entity);
                return res;
            }
        }

        public async Task<bool> Update(userRequest entity)
        { 
            var query = "update [User] set UserName=@UserName,RoleId=@RoleId,Active=@Active where CompanyId=@CompanyId and UserId=@UserId;";
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, entity);
                return res > 0;
            }
        }

        public async Task<bool> Delete(int CompanyId, int UserId)
        {
            var query = "delete from [User] where CompanyId=@CompanyId and UserId=@UserId;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", CompanyId, DbType.Int32);
            parameters.Add("UserId", UserId, DbType.Int32);
            using (var connection = CreateConnection())
            {
                var res = await connection.ExecuteAsync(query, parameters);
                return res > 0;
            }
        }

        
    }
}

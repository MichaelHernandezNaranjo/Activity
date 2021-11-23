using Activity.Core.Entities;
using Activity.Core.Exceptions;
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
    public class authRepository : BaseRepository, IAuthRepository
    {
        public authRepository(IConfiguration configuration)
            : base(configuration)
        { }
        public async Task<authenticationResponse> Authentication(authenticationRequest _authenticationRequest)
        {
            var query = "select t1.CompanyId, t1.UserId, t1.UserName, t2.Email, t1.RoleId , t3.RoleName ";
            query += "from User t1 ";
            query += "inner join UserEmail t2 on(t2.CompanyId = t1.CompanyId and t2.UserId = t1.UserId) ";
            query += "inner join Role t3 on(t3.RoleId = t1.RoleId) ";
            query += "where t1.Active = 1 and t2.Active = 1 and t2.Verification = 1 and t1.CompanyId = @CompanyId and t2.Email = @Email and t1.Password = @Password;";
            var parameters = new DynamicParameters();
            parameters.Add("CompanyId", _authenticationRequest.CompanyId, DbType.Int32);
            parameters.Add("Email", _authenticationRequest.Email, DbType.String);
            parameters.Add("Password", _authenticationRequest.Password, DbType.String);
            using (var connection = CreateConnection())
            {
                var res = await connection.QueryFirstOrDefaultAsync<authenticationResponse>(query, parameters);
                return res;
            }
        }


    }

}

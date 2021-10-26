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
            var query = "exec SP_Login @CompanyId, @Email, @Password;";
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

        public async Task<authorizationResponse> Authorization(authorizationRequest _authorizationRequest)
        {
            try
            {
                var query = "SELECT ApplicationId,AuthorizationId,UserName FROM [Authorization] with (nolock) WHERE UserName = @UserName and Password = @Password AND Active = 1;";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", _authorizationRequest.UserName, DbType.String);
                parameters.Add("Password", _authorizationRequest.Password, DbType.String);
                using (var connection = CreateConnection())
                {
                    var res = await connection.QueryFirstOrDefaultAsync<authorizationResponse>(query, parameters);
                    return res;
                }
            }
            catch (Exception ex)
            {
                throw new BusinessException(ex.Message);
            }
        }

    }

}

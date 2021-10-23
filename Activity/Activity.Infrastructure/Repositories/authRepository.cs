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

        public async Task<authorization> Authorization(string userName, string password)
        {
            try
            {
                var query = "SELECT ApplicationId,UserName FROM [BasicAuthentication] WHERE UserName = @UserName and Password = @Password AND Active = 1;";
                var parameters = new DynamicParameters();
                parameters.Add("UserName", userName, DbType.String);
                parameters.Add("Password", password, DbType.String);
                using (var connection = CreateConnection())
                {
                    var res = await connection.QueryFirstOrDefaultAsync<authorization>(query, parameters);
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

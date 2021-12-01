using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Model.UserModels.RequestModels;

namespace FinalTodoProject.Data.UserData
{
    public interface IGetUserNameByTodoIsDoneDataRequest
    {
        Task<List<GetUserNameDataModel>> GetUserNameByTodoIsDone(CancellationToken cancellationToken);
    }
    public class GetUserNameByTodoIsDoneDataRequest : IGetUserNameByTodoIsDoneDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public GetUserNameByTodoIsDoneDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<GetUserNameDataModel>> GetUserNameByTodoIsDone(CancellationToken cancellationToken)
        {
            var query = "SELECT DISTINCT(UserName) FROM [USER] RIGHT JOIN TODO ON [USER].Id = TODO.UserId WHERE TODO.IsDone = 1";

            using var conn = _dbConnection.GetConnection(); 
            
            var response = await conn.QueryAsync<GetUserNameDataModel>(query);

            return response.ToList();
        }
    }
}
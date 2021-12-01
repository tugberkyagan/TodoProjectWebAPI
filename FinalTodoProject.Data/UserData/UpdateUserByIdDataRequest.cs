using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Model.UserModels.RequestModels;

namespace FinalTodoProject.Data.UserData
{
    public interface IUpdateUserByIdDataRequest
    {
        Task<bool> UpdateUserById(InsertUserDataModel model, int id, CancellationToken cancellationToken);
    }
    
    public class UpdateUserByIdDataRequest : IUpdateUserByIdDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public UpdateUserByIdDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> UpdateUserById(InsertUserDataModel model, int id, CancellationToken cancellationToken)
        {
            var query = $"UPDATE [User] SET UserName = @UserName, Password = @Password WHERE Id = {id}";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query, model);

            return response > 0;
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Model.UserModels.RequestModels;

namespace FinalTodoProject.Data.UserData
{
    public interface IInsertUserDataRequest
    {
        Task<bool> InsertUser(InsertUserDataModel model, CancellationToken cancellationToken);
    }
    
    public class InsertUserDataRequest : IInsertUserDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public InsertUserDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertUser(InsertUserDataModel model, CancellationToken cancellationToken)
        {
            var query = $"INSERT INTO [User](UserName,Password) VALUES(@UserName,@Password)";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query, model);

            return response > 0;
        }
    }
}
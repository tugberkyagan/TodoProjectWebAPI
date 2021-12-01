using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;

namespace FinalTodoProject.Data.TodoData
{
    public interface ISwitchTodoUndoneDataRequest
    {
        Task<bool> SwitchTodoUndoneById(int todoId, CancellationToken cancellationToken);
    }
    
    public class SwitchTodoUndoneDataRequest : ISwitchTodoUndoneDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public SwitchTodoUndoneDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> SwitchTodoUndoneById(int todoId, CancellationToken cancellationToken)
        {
            var query = $"UPDATE Todo SET IsDone = 0 WHERE Id = {todoId}";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query);

            return response > 0;
        }
    }
}
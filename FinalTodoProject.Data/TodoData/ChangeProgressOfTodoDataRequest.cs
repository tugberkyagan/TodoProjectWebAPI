using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;

namespace FinalTodoProject.Data.TodoData
{
    public interface IChangeProgressOfTodoDataRequest
    {
        Task<bool> ChangeProgressOfTodo(int todoId, int effectPercentage, CancellationToken cancellationToken);
    }
    public class ChangeProgressOfTodoDataRequest : IChangeProgressOfTodoDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public ChangeProgressOfTodoDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> ChangeProgressOfTodo(int todoId, int effectPercentage, CancellationToken cancellationToken)
        {
            var query = $"UPDATE Todo SET Progress = Progress + {effectPercentage} WHERE Id = {todoId}";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query);

            return response > 0;
        }
    }
}
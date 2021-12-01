using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;

namespace FinalTodoProject.Data.TodoData
{
    public interface ISwitchTodoDoneDataRequest
    {
        Task<bool> SwitchTodoDone(int todoId, int effectPercentage, CancellationToken cancellationToken);
    }
    
    public class SwitchTodoDoneDataRequest: ISwitchTodoDoneDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public SwitchTodoDoneDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> SwitchTodoDone(int todoId, int effectPercentage, CancellationToken cancellationToken)
        {
            var query = $"UPDATE Todo SET IsDone = 1, Progress = Progress + {effectPercentage} WHERE Id = {todoId}";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query);

            return response > 0;
        }
    }
}
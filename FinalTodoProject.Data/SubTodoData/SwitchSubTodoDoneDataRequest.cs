using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;

namespace FinalTodoProject.Data.SubTodoData
{
    public interface ISwitchSubTodoDoneDataRequest
    {
        Task<bool> SwitchSubTodoDone(int id, CancellationToken cancellationToken);
    }
    
    public class SwitchSubTodoDoneDataRequest : ISwitchSubTodoDoneDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public SwitchSubTodoDoneDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> SwitchSubTodoDone(int id, CancellationToken cancellationToken)
        {
            var query = $"UPDATE SubTodo SET IsDone = 1 WHERE Id = {id}";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query);

            return response > 0;
        }
        
    }
}
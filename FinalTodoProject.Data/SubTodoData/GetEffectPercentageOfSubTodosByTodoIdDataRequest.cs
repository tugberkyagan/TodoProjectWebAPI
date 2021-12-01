using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;

namespace FinalTodoProject.Data.SubTodoData
{
    public interface IGetEffectPercentageOfSubTodosByTodoIdDataRequest
    {
        Task<int> GetEffectPercentageOfSubTodosByTodoId(int todoId, CancellationToken cancellationToken);
    }
    
    public class GetEffectPercentageOfSubTodosByTodoIdDataRequest : IGetEffectPercentageOfSubTodosByTodoIdDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public GetEffectPercentageOfSubTodosByTodoIdDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> GetEffectPercentageOfSubTodosByTodoId(int todoId, CancellationToken cancellationToken)
        {
            var query = $"SELECT SUM(EffectPercentage) FROM SubTodo WHERE TodoId = {todoId}";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteScalarAsync<int>(query);

            return response;
        }
    }
}
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;

namespace FinalTodoProject.Data.SubTodoData
{
    public interface IGetEffectPercentageFromSubTodoDataRequest
    {
        Task<int> GetEffectPercentageFromSubTodo(int subTodoId, CancellationToken cancellationToken);
    }
    
    public class GetEffectPercentageFromSubTodoDataRequest : IGetEffectPercentageFromSubTodoDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public GetEffectPercentageFromSubTodoDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> GetEffectPercentageFromSubTodo(int subTodoId, CancellationToken cancellationToken)
        {
            var query = $"SELECT EffectPercentage FROM SubTodo WHERE Id = {subTodoId}";

            using var conn = _dbConnection.GetConnection();

            int response = await conn.ExecuteScalarAsync<int>(query);

            return response;
        }
    }
}
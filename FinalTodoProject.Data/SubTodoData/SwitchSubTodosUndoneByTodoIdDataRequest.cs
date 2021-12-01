using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;

namespace FinalTodoProject.Data.SubTodoData
{
    public interface ISwitchSubTodosUndoneByTodoIdDataRequest
    {
        Task<bool> SwitchSubTodosUndoneByTodoId(int todoId, CancellationToken cancellationToken);
    }

    public class SwitchSubTodosUndoneByTodoIdDataRequest : ISwitchSubTodosUndoneByTodoIdDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public SwitchSubTodosUndoneByTodoIdDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> SwitchSubTodosUndoneByTodoId(int todoId, CancellationToken cancellationToken)
        {
            var query = $"UPDATE SubTodo SET IsDone = 0 WHERE TodoId = {todoId}";

            using var conn = _dbConnection.GetConnection();

            // Burada SubTodo'su olmayan bir todo denk gelirse ne yapacağını düşün... Çünkü yapı muhtemelen false dönecek ???
            
            var response = await conn.ExecuteAsync(query);

            return response > 0;
        }
    }
}
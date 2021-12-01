using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.TodoData;
using FinalTodoProject.Data.Utils;

namespace FinalTodoProject.Data.SubTodoData
{
    public interface IDeleteSubTodoByIdDataRequest
    {
        Task<bool> DeleteSubTodoById(int subTodoId, CancellationToken cancellationToken);
    }
    
    public class DeleteSubTodoByIdDataRequest : IDeleteSubTodoByIdDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public DeleteSubTodoByIdDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> DeleteSubTodoById(int subTodoId, CancellationToken cancellationToken)
        {
            var query = $"DELETE FROM SubTodo WHERE Id = {subTodoId}";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query);

            return response > 0;
        }
    }
}
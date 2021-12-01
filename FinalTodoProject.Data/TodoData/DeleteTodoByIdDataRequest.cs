using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;

namespace FinalTodoProject.Data.TodoData
{
    public interface IDeleteTodoByIdDataRequest
    {
        Task<bool> DeleteTodoById(int id);
    }
    
    public class DeleteTodoByIdDataRequest : IDeleteTodoByIdDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public DeleteTodoByIdDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> DeleteTodoById(int id)
        {
            var query = $"DELETE FROM Todo WHERE Id = {id}";
            
            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query);

            return response > 0;
        }
    }
}
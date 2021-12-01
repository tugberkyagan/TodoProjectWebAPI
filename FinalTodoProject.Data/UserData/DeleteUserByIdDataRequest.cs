using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;

namespace FinalTodoProject.Data.UserData
{
    public interface IDeleteUserByIdDataRequest
    {
        Task<bool> DeleteUserById(int id);
    }
    
    public class DeleteUserByIdDataRequest : IDeleteUserByIdDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public DeleteUserByIdDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> DeleteUserById(int id)
        {
            var query = $"DELETE FROM [User] WHERE Id = {id}";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query);

            return response > 0;
        }
    }
}
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Model.TodoModels.RequestModels;

namespace FinalTodoProject.Data.TodoData
{
    public interface IUpdateTodoByIdDataRequest
    {
        Task<bool> UpdateTodoById(InsertTodoDataModel model, int id);
    }

    public class UpdateTodoByIdDataRequest : IUpdateTodoByIdDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public UpdateTodoByIdDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> UpdateTodoById(InsertTodoDataModel model, int id)
        {
            var query = $"UPDATE Todo SET Title = @Title, Description = @Description, IsDone = @IsDone, UserId = @UserId, Progress = @Progress WHERE Id = {id}";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query, model);

            return response > 0;
        }
    }
}
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Model.TodoModels.RequestModels;

namespace FinalTodoProject.Data.TodoData
{
    public interface IInsertTodoDataRequest
    {
        Task<bool> InsertTodo(InsertTodoDataModel model);
    }
    public class InsertTodoDataRequest : IInsertTodoDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public InsertTodoDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> InsertTodo(InsertTodoDataModel model)
        {
            var query = $"INSERT INTO Todo(Title,Description,IsDone,UserId,Progress) VALUES (@Title,@Description,@IsDone,@UserId,@Progress)";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query,model);

            return response > 0;
        }
    }
}
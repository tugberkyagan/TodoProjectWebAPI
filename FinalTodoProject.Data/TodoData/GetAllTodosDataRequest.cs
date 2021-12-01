using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Model.TodoModels.RequestModels;

namespace FinalTodoProject.Data.TodoData
{
    public interface IGetAllTodosDataRequest
    {
        Task<List<GetTodoDataModel>> GetAllTodos();
    }
    public class GetAllTodosDataRequest : IGetAllTodosDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public GetAllTodosDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<GetTodoDataModel>> GetAllTodos()
        {
            var query = "SELECT Id,Title,Description,IsDone,UserId,Progress FROM Todo";

            using (var conn = _dbConnection.GetConnection())
            {
                var response = await conn.QueryAsync<GetTodoDataModel>(query);

                return response.ToList();
            }
        }
    }
}
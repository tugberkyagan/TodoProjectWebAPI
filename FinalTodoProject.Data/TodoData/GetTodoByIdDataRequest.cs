using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Model.TodoModels.RequestModels;

namespace FinalTodoProject.Data.TodoData
{
    public interface IGetTodoByIdDataRequest
    {
        Task<GetTodoDataModel> GetTodoDataById(int id);
    }
    
    public class GetTodoByIdDataRequest : IGetTodoByIdDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public GetTodoByIdDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<GetTodoDataModel> GetTodoDataById(int id)
        {
            var query = $"SELECT Id,Title,Description,IsDone,UserId FROM Todo WHERE Id = {id}";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.QueryFirstOrDefaultAsync<GetTodoDataModel>(query);

            return response;
        }
    }
    
    
}
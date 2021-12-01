using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Model.TodoModels.RequestModels;

namespace FinalTodoProject.Data.TodoData
{
    public interface IGetProgressAndIdFromTodoBySubTodoIdDataRequest
    {
        Task<IsTodoDoneDataModel> GetProgressAndIdFromTodoBySubTodoId (int subTodoId, CancellationToken cancellationToken);
    }
    
    public class GetProgressAndIdFromTodoBySubTodoIdDataRequest : IGetProgressAndIdFromTodoBySubTodoIdDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public GetProgressAndIdFromTodoBySubTodoIdDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IsTodoDoneDataModel> GetProgressAndIdFromTodoBySubTodoId (int subTodoId, CancellationToken cancellationToken)
        {
            var query = $"SELECT Progress,Id FROM Todo WHERE Id = (SELECT TOP 1 TodoId FROM SubTodo WHERE Id = {subTodoId})";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.QueryFirstOrDefaultAsync<IsTodoDoneDataModel>(query);

            return response;
        }
    }
}
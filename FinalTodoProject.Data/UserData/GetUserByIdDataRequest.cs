using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Model.UserModels.RequestModels;

namespace FinalTodoProject.Data.UserData
{
    public interface IGetUserByIdDataRequest
    {
        Task<GetUserDataModel> GetUserById(int id);
    }
    public class GetUserByIdDataRequest : IGetUserByIdDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public GetUserByIdDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<GetUserDataModel> GetUserById(int id)
        {
            var query = $"SELECT Id, UserName FROM [User] WHERE Id = {id}";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.QueryFirstOrDefaultAsync<GetUserDataModel>(query);

            return response;
        }
    }
}
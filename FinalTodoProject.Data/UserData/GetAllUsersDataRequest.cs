using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Model.TodoModels.RequestModels;
using FinalTodoProject.Model.UserModels.RequestModels;

namespace FinalTodoProject.Data.UserData
{
    public interface IGetAllUsersDataRequest
    {
        Task<List<GetUserDataModel>> GetAllUsers();
    }
    
    public class GetAllUsersDataRequest :IGetAllUsersDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public GetAllUsersDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<List<GetUserDataModel>> GetAllUsers()
        {
            var query = "SELECT Id,UserName FROM [User]";

            using var conn = _dbConnection.GetConnection();

            var response = await conn.QueryAsync<GetUserDataModel>(query);

            return response.ToList();
            {
                
            }
        }
    }
}
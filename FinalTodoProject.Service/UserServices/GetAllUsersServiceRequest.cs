using System.Collections.Generic;
using System.Threading.Tasks;
using FinalTodoProject.Data.TodoData;
using FinalTodoProject.Data.UserData;
using FinalTodoProject.Model.UserModels.RequestModels;

namespace FinalTodoProject.Service.UserServices
{
    public interface IGetAllUsersServiceRequest
    {
        Task<List<GetUserDataModel>> GetAllUsers();
    }
    
    public class GetAllUsersServiceRequest : IGetAllUsersServiceRequest
    {
        private readonly IGetAllUsersDataRequest _getAllUsersDataRequest;

        public GetAllUsersServiceRequest(IGetAllUsersDataRequest getAllUsersDataRequest)
        {
            _getAllUsersDataRequest = getAllUsersDataRequest;
        }

        public async Task<List<GetUserDataModel>> GetAllUsers()
        {
            return await _getAllUsersDataRequest.GetAllUsers();
        }
    }
}
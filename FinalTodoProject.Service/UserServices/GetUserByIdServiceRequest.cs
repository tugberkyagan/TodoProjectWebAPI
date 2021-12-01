using System.Threading.Tasks;
using FinalTodoProject.Data.UserData;
using FinalTodoProject.Model.UserModels.RequestModels;

namespace FinalTodoProject.Service.UserServices
{
    public interface IGetUserByIdServiceRequest
    {
        Task<GetUserDataModel> GetUserById(int id);
    }
    
    public class GetUserByIdServiceRequest : IGetUserByIdServiceRequest
    {
        private readonly IGetUserByIdDataRequest _getUserByIdDataRequest;

        public GetUserByIdServiceRequest(IGetUserByIdDataRequest getUserByIdDataRequest)
        {
            _getUserByIdDataRequest = getUserByIdDataRequest;
        }

        public async Task<GetUserDataModel> GetUserById(int id)
        {
            return await _getUserByIdDataRequest.GetUserById(id);
        }
    }
}
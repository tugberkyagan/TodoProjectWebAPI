using System.Threading.Tasks;
using FinalTodoProject.Data.TodoData;
using FinalTodoProject.Data.UserData;

namespace FinalTodoProject.Service.UserServices
{
    public interface IDeleteUserByIdServiceRequest
    {
        Task<bool> DeleteUserById(int id);
    }
    
    public class DeleteUserByIdServiceRequest : IDeleteUserByIdServiceRequest
    {
        private readonly IDeleteUserByIdDataRequest _deleteUserByIdDataRequest;

        public DeleteUserByIdServiceRequest(IDeleteUserByIdDataRequest deleteUserByIdDataRequest)
        {
            _deleteUserByIdDataRequest = deleteUserByIdDataRequest;
        }

        public async Task<bool> DeleteUserById(int id)
        {
            return await _deleteUserByIdDataRequest.DeleteUserById(id);
        }
    }
}
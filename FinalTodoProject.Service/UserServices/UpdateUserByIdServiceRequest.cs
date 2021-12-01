using System.Threading;
using System.Threading.Tasks;
using FinalTodoProject.Data.UserData;
using FinalTodoProject.Model.UserModels.RequestModels;

namespace FinalTodoProject.Service.UserServices
{
    public interface IUpdateUserByIdServiceRequest
    {
        Task<bool> UpdateUserById(InsertUserDataModel model, int id, CancellationToken cancellationToken);
    }
    public class UpdateUserByIdServiceRequest : IUpdateUserByIdServiceRequest
    {
        private readonly IUpdateUserByIdDataRequest _updateUserByIdDataRequest;

        public UpdateUserByIdServiceRequest(IUpdateUserByIdDataRequest updateUserByIdDataRequest)
        {
            _updateUserByIdDataRequest = updateUserByIdDataRequest;
        }

        public async Task<bool> UpdateUserById(InsertUserDataModel model, int id, CancellationToken cancellationToken)
        {
            return await _updateUserByIdDataRequest.UpdateUserById(model, id, cancellationToken);
        }
    }
}
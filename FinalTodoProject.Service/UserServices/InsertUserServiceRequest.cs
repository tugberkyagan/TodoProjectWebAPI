using System.Threading;
using System.Threading.Tasks;
using FinalTodoProject.Data.UserData;
using FinalTodoProject.Model.UserModels.RequestModels;

namespace FinalTodoProject.Service.UserServices
{
    public interface IInsertUserServiceRequest
    {
        Task<bool> InsertUser(InsertUserDataModel model,CancellationToken cancellationToken);
    }

    public class InsertUserServiceRequest : IInsertUserServiceRequest
    {
        private readonly IInsertUserDataRequest _insertUserDataRequest;

        public InsertUserServiceRequest(IInsertUserDataRequest insertUserDataRequest)
        {
            _insertUserDataRequest = insertUserDataRequest;
        }

        public async Task<bool> InsertUser(InsertUserDataModel model,CancellationToken cancellationToken)
        {
            return await _insertUserDataRequest.InsertUser(model,cancellationToken);
        }
    }
}
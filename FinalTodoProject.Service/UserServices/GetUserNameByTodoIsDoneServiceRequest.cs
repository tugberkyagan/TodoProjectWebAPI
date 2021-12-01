using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FinalTodoProject.Data.UserData;
using FinalTodoProject.Model.UserModels.RequestModels;

namespace FinalTodoProject.Service.UserServices
{
    public interface IGetUserNameByTodoIsDoneServiceRequest
    {
        Task<List<GetUserNameDataModel>> GetUserNameByTodoIsDone(CancellationToken cancellationToken);
    }
    
    public class GetUserNameByTodoIsDoneServiceRequest : IGetUserNameByTodoIsDoneServiceRequest
    {
        private readonly IGetUserNameByTodoIsDoneDataRequest _getUserNameByTodoIsDoneDataRequest;

        public GetUserNameByTodoIsDoneServiceRequest(IGetUserNameByTodoIsDoneDataRequest getUserNameByTodoIsDoneDataRequest)
        {
            _getUserNameByTodoIsDoneDataRequest = getUserNameByTodoIsDoneDataRequest;
        }

        public async Task<List<GetUserNameDataModel>> GetUserNameByTodoIsDone(CancellationToken cancellationToken)
        {
            // var todos = await _getAllTodosDataRequest.GetAllTodos();

            // var doneTodos = todos.Where(x => x.IsDone);

            // var doneTodosUserIds = doneTodos.Select(x => x.UserId).ToList();

            // var doneTodosUsers = await _getUserNameByTodoIsDoneDataRequest.GetUserNameByTodoIsDone(doneTodosUserIds, cancellationToken);

            // var doneTodosUserNames = doneTodosUsers.Select(x => x.UserName).ToList(); 
            
            return await _getUserNameByTodoIsDoneDataRequest.GetUserNameByTodoIsDone(cancellationToken);
        }
    }
}
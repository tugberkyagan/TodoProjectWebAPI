using System.Threading;
using System.Threading.Tasks;
using FinalTodoProject.Data.TodoData;

namespace FinalTodoProject.Service.TodoServices
{
    public interface ISwitchTodoDoneServiceRequest
    {
        Task<bool> SwitchTodoDone(int todoId, int effectPercentage, CancellationToken cancellationToken);
    }
    
    public class SwitchTodoDoneServiceRequest : ISwitchTodoDoneServiceRequest
    {
        private readonly ISwitchTodoDoneDataRequest _switchTodoDoneDataRequest;

        public SwitchTodoDoneServiceRequest(ISwitchTodoDoneDataRequest switchTodoDoneDataRequest)
        {
            _switchTodoDoneDataRequest = switchTodoDoneDataRequest;
        }

        public async Task<bool> SwitchTodoDone(int todoId, int effectPercentage, CancellationToken cancellationToken)
        {
            return await _switchTodoDoneDataRequest.SwitchTodoDone(todoId, effectPercentage, cancellationToken);
        }
    }
}
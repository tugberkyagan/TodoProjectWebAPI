using System.Threading;
using System.Threading.Tasks;
using FinalTodoProject.Data.SubTodoData;
using FinalTodoProject.Data.TodoData;

namespace FinalTodoProject.Service.TodoServices
{
    public interface ISwitchTodoUndoneServiceRequest
    {
        Task<bool> SwitchTodoUndone(int todoId, CancellationToken cancellationToken);
    }
    
    public class SwitchTodoUndoneServiceRequest : ISwitchTodoUndoneServiceRequest
    {
        private readonly ISwitchTodoUndoneDataRequest _switchTodoUndoneDataRequest;
        private readonly ISwitchSubTodosUndoneByTodoIdDataRequest _switchSubTodosUndoneByTodoIdDataRequest;
        private readonly IGetEffectPercentageOfSubTodosByTodoIdDataRequest _getEffectPercentageOfSubTodosByTodoIdDataRequest;
        private readonly IChangeProgressOfTodoDataRequest _changeProgressOfTodoDataRequest;
        
        public SwitchTodoUndoneServiceRequest(ISwitchTodoUndoneDataRequest switchTodoUndoneDataRequest, ISwitchSubTodosUndoneByTodoIdDataRequest switchSubTodosUndoneByTodoIdDataRequest, IGetEffectPercentageOfSubTodosByTodoIdDataRequest getEffectPercentageOfSubTodosByTodoIdDataRequest, IChangeProgressOfTodoDataRequest changeProgressOfTodoDataRequest)
        {
            _switchTodoUndoneDataRequest = switchTodoUndoneDataRequest;
            _switchSubTodosUndoneByTodoIdDataRequest = switchSubTodosUndoneByTodoIdDataRequest;
            _getEffectPercentageOfSubTodosByTodoIdDataRequest = getEffectPercentageOfSubTodosByTodoIdDataRequest;
            _changeProgressOfTodoDataRequest = changeProgressOfTodoDataRequest;
        }

        public async Task<bool> SwitchTodoUndone(int todoId, CancellationToken cancellationToken)
        {

            var isSubTodosUndone = await _switchSubTodosUndoneByTodoIdDataRequest.SwitchSubTodosUndoneByTodoId(todoId, cancellationToken);
            var totalEffectPercentagesOfSubTodos = await _getEffectPercentageOfSubTodosByTodoIdDataRequest.GetEffectPercentageOfSubTodosByTodoId(todoId, cancellationToken);
            if (isSubTodosUndone)
            {
                var isProgressChanged = await _changeProgressOfTodoDataRequest.ChangeProgressOfTodo(todoId,-totalEffectPercentagesOfSubTodos, cancellationToken);
                var isTodoUndone = await _switchTodoUndoneDataRequest.SwitchTodoUndoneById(todoId, cancellationToken);

                if (isProgressChanged && isTodoUndone)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
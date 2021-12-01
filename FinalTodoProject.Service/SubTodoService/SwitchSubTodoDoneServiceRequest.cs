using System.Threading;
using System.Threading.Tasks;
using FinalTodoProject.Data.SubTodoData;
using FinalTodoProject.Data.TodoData;
using FinalTodoProject.Service.TodoServices;

namespace FinalTodoProject.Service
{
    public interface ISwitchSubTodoDoneServiceRequest
    {
        Task<bool> SwitchSubTodoDone(int subTodoId, CancellationToken cancellationToken);
    }

    public class SwitchSubTodoDoneServiceRequest : ISwitchSubTodoDoneServiceRequest
    {
        private readonly ISwitchSubTodoDoneDataRequest _switchSubTodoDoneDataRequest;
        private readonly ISwitchTodoDoneServiceRequest _switchTodoDoneServiceRequest;
        private readonly IGetProgressAndIdFromTodoBySubTodoIdServiceRequest _getProgressAndIdFromTodoBySubTodoIdServiceRequest;
        private readonly IGetEffectPercentageFromSubTodoDataRequest _getEffectPercentageFromSubTodoDataRequest;
        private readonly IChangeProgressOfTodoDataRequest _changeProgressOfTodoDataRequest;

        public SwitchSubTodoDoneServiceRequest(ISwitchSubTodoDoneDataRequest switchSubTodoDoneDataRequest, ISwitchTodoDoneServiceRequest switchTodoDoneServiceRequest, IGetProgressAndIdFromTodoBySubTodoIdServiceRequest getProgressAndIdFromTodoBySubTodoIdServiceRequest, IGetEffectPercentageFromSubTodoDataRequest getEffectPercentageFromSubTodoDataRequest, IChangeProgressOfTodoDataRequest changeProgressOfTodoDataRequest)
        {
            _switchSubTodoDoneDataRequest = switchSubTodoDoneDataRequest;
            _switchTodoDoneServiceRequest = switchTodoDoneServiceRequest;
            _getProgressAndIdFromTodoBySubTodoIdServiceRequest = getProgressAndIdFromTodoBySubTodoIdServiceRequest;
            _getEffectPercentageFromSubTodoDataRequest = getEffectPercentageFromSubTodoDataRequest;
            _changeProgressOfTodoDataRequest = changeProgressOfTodoDataRequest;
        }

        public async Task<bool> SwitchSubTodoDone(int subTodoId, CancellationToken cancellationToken)
        {
            var progressAndIdOfTodo = await _getProgressAndIdFromTodoBySubTodoIdServiceRequest.GetProgressAndIdFromTodoBySubTodoId(subTodoId, cancellationToken);

            var effectPercentageOfSubTodo = await _getEffectPercentageFromSubTodoDataRequest.GetEffectPercentageFromSubTodo(subTodoId, cancellationToken);

            var totalProgressOfTodo = progressAndIdOfTodo.Progress + effectPercentageOfSubTodo;

            if (totalProgressOfTodo >= 100)
            {
                var isTodoDone = await _switchTodoDoneServiceRequest.SwitchTodoDone(progressAndIdOfTodo.Id, effectPercentageOfSubTodo ,cancellationToken);
                var isSubTodoDone = await _switchSubTodoDoneDataRequest.SwitchSubTodoDone(subTodoId, cancellationToken);

                if (isSubTodoDone && isTodoDone)
                {
                    return true;
                }
            }
            else
            {
                var isAddedToProgress = await _changeProgressOfTodoDataRequest.ChangeProgressOfTodo(progressAndIdOfTodo.Id, effectPercentageOfSubTodo, cancellationToken);
                var isSubTodoDone =  await _switchSubTodoDoneDataRequest.SwitchSubTodoDone(subTodoId, cancellationToken);

                if (isAddedToProgress && isSubTodoDone)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
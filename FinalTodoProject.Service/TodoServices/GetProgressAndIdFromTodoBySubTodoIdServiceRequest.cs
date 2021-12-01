using System.Threading;
using System.Threading.Tasks;
using FinalTodoProject.Data.TodoData;
using FinalTodoProject.Model.TodoModels.RequestModels;

namespace FinalTodoProject.Service.TodoServices
{
    public interface IGetProgressAndIdFromTodoBySubTodoIdServiceRequest
    {
        Task<IsTodoDoneDataModel> GetProgressAndIdFromTodoBySubTodoId(int subTodoId, CancellationToken cancellationToken);
    }
    
    public class GetProgressAndIdFromTodoBySubTodoIdServiceRequest : IGetProgressAndIdFromTodoBySubTodoIdServiceRequest
    {
        private readonly IGetProgressAndIdFromTodoBySubTodoIdDataRequest _getProgressAndIdFromTodoBySubTodoIdDataRequest;

        public GetProgressAndIdFromTodoBySubTodoIdServiceRequest(IGetProgressAndIdFromTodoBySubTodoIdDataRequest getProgressAndIdFromTodoBySubTodoIdDataRequest)
        {
            _getProgressAndIdFromTodoBySubTodoIdDataRequest = getProgressAndIdFromTodoBySubTodoIdDataRequest;
        }

        public async Task<IsTodoDoneDataModel> GetProgressAndIdFromTodoBySubTodoId(int subTodoId,CancellationToken cancellationToken)
        {
            return await _getProgressAndIdFromTodoBySubTodoIdDataRequest.GetProgressAndIdFromTodoBySubTodoId(subTodoId, cancellationToken);
        }
    }
}
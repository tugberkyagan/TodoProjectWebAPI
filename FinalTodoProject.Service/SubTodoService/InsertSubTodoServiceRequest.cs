using System.Threading;
using System.Threading.Tasks;
using FinalTodoProject.Data.SubTodoData;
using FinalTodoProject.Model.SubTodoModels.RequestModels;

namespace FinalTodoProject.Service
{
    public interface IInsertSubTodoServiceRequest
    {
        Task<bool> InsertSubTodo(InsertSubTodoDataModel model, CancellationToken cancellationToken);
    }
    
    public class InsertSubTodoServiceRequest : IInsertSubTodoServiceRequest
    {
        private readonly IInsertSubTodoDataRequest _insertSubTodoDataRequest;

        public InsertSubTodoServiceRequest(IInsertSubTodoDataRequest insertSubTodoDataRequest)
        {
            _insertSubTodoDataRequest = insertSubTodoDataRequest;
        }

        public async Task<bool> InsertSubTodo(InsertSubTodoDataModel model, CancellationToken cancellationToken)
        {
            return await _insertSubTodoDataRequest.InsertSubTodo(model, cancellationToken);
        }
    }
}
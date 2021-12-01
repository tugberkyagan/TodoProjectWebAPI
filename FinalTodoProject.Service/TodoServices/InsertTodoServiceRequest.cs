using System.Threading.Tasks;
using FinalTodoProject.Data.TodoData;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Model.TodoModels.RequestModels;

namespace FinalTodoProject.Service.TodoServices
{
    public interface IInsertTodoServiceRequest
    {
        Task<bool> InsertTodo(InsertTodoDataModel model);
    }
    
    public class InsertTodoServiceRequest : IInsertTodoServiceRequest
    {
        private readonly IInsertTodoDataRequest _insertTodoDataRequest;

        public InsertTodoServiceRequest(IInsertTodoDataRequest insertTodoDataRequest)
        {
            _insertTodoDataRequest = insertTodoDataRequest;
        }

        public async Task<bool> InsertTodo(InsertTodoDataModel model)
        {
            return await _insertTodoDataRequest.InsertTodo(model);
        }
    }
}
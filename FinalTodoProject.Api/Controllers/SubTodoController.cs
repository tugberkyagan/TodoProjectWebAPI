using System.Threading;
using System.Threading.Tasks;
using FinalTodoProject.Data.SubTodoData;
using FinalTodoProject.Data.TodoData;
using FinalTodoProject.Model.SubTodoModels.RequestModels;
using FinalTodoProject.Model.TodoModels.RequestModels;
using FinalTodoProject.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalTodoProject.Api.Controllers
{
    [Route("api/[controller]")]
    public class SubTodoController : Controller
    {
        private readonly IInsertSubTodoServiceRequest _insertSubTodoServiceRequest;
        private readonly ISwitchSubTodoDoneServiceRequest _switchSubTodoDoneServiceRequest;
        private readonly IDeleteSubTodoByIdServiceRequest _deleteSubTodoByIdServiceRequest;
        

        public SubTodoController(IInsertSubTodoServiceRequest insertSubTodoServiceRequest, ISwitchSubTodoDoneServiceRequest switchSubTodoDoneServiceRequest, IDeleteSubTodoByIdServiceRequest deleteSubTodoByIdServiceRequest)
        {
            _insertSubTodoServiceRequest = insertSubTodoServiceRequest;
            _switchSubTodoDoneServiceRequest = switchSubTodoDoneServiceRequest;
            _deleteSubTodoByIdServiceRequest = deleteSubTodoByIdServiceRequest;
        }
        [HttpPost]
        [Route("insert-sub-todo")]
        public async Task<bool> InsertSubTodo(InsertSubTodoDataModel model, CancellationToken cancellationToken)
        {
            return await _insertSubTodoServiceRequest.InsertSubTodo(model, cancellationToken);
        }

        [HttpPost]
        [Route("switch-subtodo-done")]
        public async Task<bool> SwitchSubTodoDone(int subTodoId,CancellationToken cancellationToken)
        {
            return await _switchSubTodoDoneServiceRequest.SwitchSubTodoDone(subTodoId,cancellationToken);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<bool> DeleteSubTodoById(int subTodoId, CancellationToken cancellationToken)
        {
            return await _deleteSubTodoByIdServiceRequest.DeleteSubTodoById(subTodoId, cancellationToken);
        }

        

    }
}
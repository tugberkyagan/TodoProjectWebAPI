using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FinalTodoProject.Data.TodoData;
using FinalTodoProject.Model.TodoModels.RequestModels;
using FinalTodoProject.Service.TodoServices;
using Microsoft.AspNetCore.Mvc;

namespace FinalTodoProject.Api.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly IGetTodoByIdServiceRequest _getTodoByIdServiceRequest;
        private readonly IGetAllTodosServiceRequest _getAllTodosServiceRequest;
        private readonly IInsertTodoServiceRequest _insertTodoServiceRequest;
        private readonly IDeleteTodoByIdServiceRequest _deleteTodoByIdServiceRequest;
        private readonly IGetAllTodoTitlesServiceRequest _getAllTodoTitlesServiceRequest;
        private readonly IUpdateTodoByIdServiceRequest _updateTodoByIdServiceRequest;
        private readonly ISwitchTodoUndoneServiceRequest _switchTodoUndoneServiceRequest;


        
        public TodoController(IGetTodoByIdServiceRequest getTodoByIdServiceRequest, IGetAllTodosServiceRequest getAllTodosServiceRequest, IInsertTodoServiceRequest insertTodoServiceRequest, IDeleteTodoByIdServiceRequest deleteTodoByIdServiceRequest, IGetAllTodoTitlesServiceRequest getAllTodoTitlesServiceRequest, IUpdateTodoByIdServiceRequest updateTodoByIdServiceRequest, ISwitchTodoUndoneServiceRequest switchTodoUndoneServiceRequest)
        {
            _getTodoByIdServiceRequest = getTodoByIdServiceRequest;
            _getAllTodosServiceRequest = getAllTodosServiceRequest;
            _insertTodoServiceRequest = insertTodoServiceRequest;
            _deleteTodoByIdServiceRequest = deleteTodoByIdServiceRequest;
            _getAllTodoTitlesServiceRequest = getAllTodoTitlesServiceRequest;
            _updateTodoByIdServiceRequest = updateTodoByIdServiceRequest;
            _switchTodoUndoneServiceRequest = switchTodoUndoneServiceRequest;
        }

        [HttpGet("{id}")]
        public async Task<GetTodoDataModel> GetTodoDataById(int id)
        {
            var response = await _getTodoByIdServiceRequest.GetTodoDataById(id);

            return response;
        }

        [HttpGet("todos")]
        public async Task<List<GetTodoDataModel>> GetAllTodos()
        {
            return await _getAllTodosServiceRequest.GetAllTodos();
        }

        [HttpPost("insert")]
        public async Task<bool> InsertTodo([FromBody]InsertTodoDataModel model)
        {
            return await _insertTodoServiceRequest.InsertTodo(model);
        }

        [HttpGet("titles")]
        public async Task<List<string>> GetAllTodoTitles()
        {
            return await _getAllTodoTitlesServiceRequest.GetAllTodoTitles();
        }
        
        [HttpDelete]
        public async Task<bool> DeleteTodoById(int id)
        {
            return await _deleteTodoByIdServiceRequest.DeleteTodoById(id);
        }

        [HttpPut("update")]
        public async Task<bool> UpdateTodoById([FromBody] InsertTodoDataModel model, int id)
        {
            return await _updateTodoByIdServiceRequest.UpdateTodoById(model, id);
        }

        [HttpPut("undone-todo")]
        public async Task<bool> SwitchTodoUndone(int todoId, CancellationToken cancellationToken)
        {
            return await _switchTodoUndoneServiceRequest.SwitchTodoUndone(todoId, cancellationToken);
        }

    }
}
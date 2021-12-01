using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalTodoProject.Data.TodoData;

namespace FinalTodoProject.Service.TodoServices
{
    public interface IGetAllTodoTitlesServiceRequest
    {
        Task<List<string>> GetAllTodoTitles();
    }
    
    public class GetAllTodoTitlesServiceRequest : IGetAllTodoTitlesServiceRequest
    {
        private readonly IGetAllTodosDataRequest _getAllTodosDataRequest;

        public GetAllTodoTitlesServiceRequest(IGetAllTodosDataRequest getAllTodosDataRequest)
        {
            _getAllTodosDataRequest = getAllTodosDataRequest;
        }

        public async Task<List<string>> GetAllTodoTitles()
        {
            var todos = await _getAllTodosDataRequest.GetAllTodos();

            var titles = todos.Select(x => x.Title).ToList();

            return titles;
        }
    }
}
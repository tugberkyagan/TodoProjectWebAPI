using System.Collections.Generic;
using System.Threading.Tasks;
using FinalTodoProject.Data.TodoData;
using FinalTodoProject.Model.TodoModels.RequestModels;

namespace FinalTodoProject.Service.TodoServices
{
    public interface IGetAllTodosServiceRequest
    {
        Task<List<GetTodoDataModel>> GetAllTodos();
    }
    
    public class GetAllTodosServiceRequest : IGetAllTodosServiceRequest
    {
        private readonly IGetAllTodosDataRequest _getAllTodosDataRequest;

        public GetAllTodosServiceRequest(IGetAllTodosDataRequest getAllTodosDataRequest)
        {
            _getAllTodosDataRequest = getAllTodosDataRequest;
        }

        public async Task<List<GetTodoDataModel>> GetAllTodos()
        {
            return await _getAllTodosDataRequest.GetAllTodos();
        }
    }
    
}
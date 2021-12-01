using System.Threading.Tasks;
using FinalTodoProject.Data.TodoData;
using FinalTodoProject.Model.TodoModels.RequestModels;

namespace FinalTodoProject.Service.TodoServices
{
    public interface IGetTodoByIdServiceRequest
    {
        Task<GetTodoDataModel> GetTodoDataById(int id);
    }
    public class GetTodoByIdServiceRequest :IGetTodoByIdServiceRequest
    {
        private readonly IGetTodoByIdDataRequest _getTodoByIdDataRequest;

        public GetTodoByIdServiceRequest(IGetTodoByIdDataRequest getTodoByIdDataRequest)
        {
            _getTodoByIdDataRequest = getTodoByIdDataRequest;
        }

        public async Task<GetTodoDataModel> GetTodoDataById(int id)
        {
            return await _getTodoByIdDataRequest.GetTodoDataById(id);
        }
    }
}
using System.Threading.Tasks;
using FinalTodoProject.Data.TodoData;
using FinalTodoProject.Model.TodoModels.RequestModels;

namespace FinalTodoProject.Service.TodoServices
{
    public interface IUpdateTodoByIdServiceRequest
    {
        Task<bool> UpdateTodoById(InsertTodoDataModel model, int id);
    }
    
    public class UpdateTodoByIdServiceRequest : IUpdateTodoByIdServiceRequest
    {
        private readonly IUpdateTodoByIdDataRequest _updateTodoByIdDataRequest;

        public UpdateTodoByIdServiceRequest(IUpdateTodoByIdDataRequest updateTodoByIdDataRequest)
        {
            _updateTodoByIdDataRequest = updateTodoByIdDataRequest;
        }

        public async Task<bool> UpdateTodoById(InsertTodoDataModel model, int id)
        {
            var response = await _updateTodoByIdDataRequest.UpdateTodoById(model, id);

            return response;
        }
    }
}
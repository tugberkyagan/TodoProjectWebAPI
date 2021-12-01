using System.Threading;
using System.Threading.Tasks;
using FinalTodoProject.Data.SubTodoData;
using FinalTodoProject.Data.TodoData;

namespace FinalTodoProject.Service
{
    public interface IDeleteSubTodoByIdServiceRequest
    {
        Task<bool> DeleteSubTodoById(int subTodoId, CancellationToken cancellationToken);
    }
    
    public class DeleteSubTodoByIdServiceRequest : IDeleteSubTodoByIdServiceRequest
    {
        private readonly IDeleteSubTodoByIdDataRequest _deleteSubTodoByIdDataRequest;

        public DeleteSubTodoByIdServiceRequest(IDeleteSubTodoByIdDataRequest deleteSubTodoByIdDataRequest)
        {
            _deleteSubTodoByIdDataRequest = deleteSubTodoByIdDataRequest;
        }

        public async Task<bool> DeleteSubTodoById(int subTodoId, CancellationToken cancellationToken)
        {
            return await _deleteSubTodoByIdDataRequest.DeleteSubTodoById(subTodoId, cancellationToken);
        }
    }
}
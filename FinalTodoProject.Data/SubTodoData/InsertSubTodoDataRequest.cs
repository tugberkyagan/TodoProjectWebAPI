using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using FinalTodoProject.Data.Utils;
using FinalTodoProject.Model.SubTodoModels.RequestModels;

namespace FinalTodoProject.Data.SubTodoData
{
    public interface IInsertSubTodoDataRequest
    {
        Task<bool> InsertSubTodo(InsertSubTodoDataModel model, CancellationToken cancellationToken);
    }
    
    public class InsertSubTodoDataRequest : IInsertSubTodoDataRequest
    {
        private readonly ITodoProjectDbConnection _dbConnection;

        public InsertSubTodoDataRequest(ITodoProjectDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        
        public async Task<bool> InsertSubTodo(InsertSubTodoDataModel model, CancellationToken cancellationToken)
        {
            var query = $"INSERT INTO SubTodo(Title,EffectPercentage,TodoId,IsDone) VALUES(@Title,@EffectPercentage,@TodoId,@IsDone)";
            
            using var conn = _dbConnection.GetConnection();

            var response = await conn.ExecuteAsync(query,model);

            return response > 0;
        }
    }
}
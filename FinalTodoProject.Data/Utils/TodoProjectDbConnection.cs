using System.Data;
using System.Data.SqlClient;

namespace FinalTodoProject.Data.Utils
{
    public interface ITodoProjectDbConnection
    {
        IDbConnection GetConnection();
    }
    
    public class TodoProjectDbConnection : ITodoProjectDbConnection
    {
        private readonly string _connectionString;
        
        public TodoProjectDbConnection(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public IDbConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
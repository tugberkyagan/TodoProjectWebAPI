using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using FinalTodoProject.Model.UserModels.RequestModels;
using FinalTodoProject.Service.UserServices;
using Microsoft.AspNetCore.Mvc;

namespace FinalTodoProject.Api.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IGetAllUsersServiceRequest _getAllUsersServiceRequest;
        private readonly IGetUserByIdServiceRequest _getUserByIdServiceRequest;
        private readonly IDeleteUserByIdServiceRequest _deleteUserByIdServiceRequest;
        private readonly IInsertUserServiceRequest _insertUserServiceRequest;
        private readonly IGetUserNameByTodoIsDoneServiceRequest _getUserNameByTodoIsDoneServiceRequest;
        private readonly IUpdateUserByIdServiceRequest _updateUserByIdServiceRequest;

        public UserController(IGetUserNameByTodoIsDoneServiceRequest getUserNameByTodoIsDoneServiceRequest, IGetAllUsersServiceRequest getAllUsersServiceRequest, IGetUserByIdServiceRequest getUserByIdServiceRequest, IDeleteUserByIdServiceRequest deleteUserByIdServiceRequest, IInsertUserServiceRequest insertUserServiceRequest, IUpdateUserByIdServiceRequest updateUserByIdServiceRequest)
        {
            _getAllUsersServiceRequest = getAllUsersServiceRequest;
            _getUserByIdServiceRequest = getUserByIdServiceRequest;
            _deleteUserByIdServiceRequest = deleteUserByIdServiceRequest;
            _insertUserServiceRequest = insertUserServiceRequest;
            _updateUserByIdServiceRequest = updateUserByIdServiceRequest;
            _getUserNameByTodoIsDoneServiceRequest = getUserNameByTodoIsDoneServiceRequest;
        }

        [HttpGet("users")]
        public async Task<List<GetUserDataModel>> GetAllUsers()
        {
            return await _getAllUsersServiceRequest.GetAllUsers();
        }

        [HttpGet("{id}")]
        public async Task<GetUserDataModel> GetUserById(int id)
        {
            return await _getUserByIdServiceRequest.GetUserById(id);
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteUserById(int id)
        {
            return await _deleteUserByIdServiceRequest.DeleteUserById(id);
        }

        [HttpPost("insert")]
        public async Task<bool> InsertUser(InsertUserDataModel model,CancellationToken cancellationToken)
        {
            return await _insertUserServiceRequest.InsertUser(model, cancellationToken);
        }

        [HttpPut("update")]
        public async Task<bool> UpdateUserById(InsertUserDataModel model, int id, CancellationToken cancellationToken)
        {
            return await _updateUserByIdServiceRequest.UpdateUserById(model, id, cancellationToken);
        }

        [HttpGet("getUserNamesByTodoIsDone")]
        public async Task<List<GetUserNameDataModel>> GetUserNamesByTodoIsDone(CancellationToken cancellationToken)
        {
            return await _getUserNameByTodoIsDoneServiceRequest.GetUserNameByTodoIsDone(cancellationToken);
        }
    }
}
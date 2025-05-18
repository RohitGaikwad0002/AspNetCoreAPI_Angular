using aspNetCoreWebAPI.Models.MasterModels;
using aspNetCoreWebAPI.Models.Request_DTOs;

namespace aspNetCoreWebAPI.ServiceInterface
{
    public interface IUserService
    {
        List<UserRequest> GetAllUsers();
        UserRequest GetUserById(int id);
        void AddUser(UserRequest userRequest);
        void UpdateUser(int id, UserRequest userRequest);
        void DeleteUser(int id);
        bool CheckRolesById(int id);
    }
}

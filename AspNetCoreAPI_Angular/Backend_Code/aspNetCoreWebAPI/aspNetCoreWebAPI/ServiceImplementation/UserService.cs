using aspNetCoreWebAPI.Models.MasterModels;
using aspNetCoreWebAPI.Models.Request_DTOs;
using aspNetCoreWebAPI.RepositoryInterface;
using aspNetCoreWebAPI.ServiceInterface;

namespace aspNetCoreWebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserRequest> GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return users.Select(u => new UserRequest
            {
                UserId = u.UserId,
                UserName = u.Username,
                Email = u.Email,
                RoleId = u.RoleId,
                RoleName = u.Role.RoleName
            }).ToList();
        }

        public UserRequest GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null) return null;

            return new UserRequest
            {
                UserId = user.UserId,
                UserName = user.Username,
                Email = user.Email,
                //RoleId = user.RoleId,
                //RoleName = user.Role.RoleName
            };
        }

        public void AddUser(UserRequest userRequest)
        {
            var user = new User
            {
                Username = userRequest.UserName,
                Email = userRequest.Email,
                RoleId = userRequest.RoleId,
                CreatedBy = "system",
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };

            _userRepository.AddUser(user);
        }

        public void UpdateUser(int id, UserRequest userRequest)
        {
            var user = _userRepository.GetUserById(id);
            if (user != null)
            {
                user.Username = userRequest.UserName;
                user.Email = userRequest.Email;
                user.RoleId = userRequest.RoleId;
                user.ModifiedBy = "system";
                user.ModifiedOn = DateTime.Now;

                _userRepository.UpdateUser(user);
            }
        }

        public void DeleteUser(int id)
        {
            _userRepository.DeleteUser(id);
        }

        public bool CheckRolesById(int id)
        {
            var isRoleInUse = _userRepository.CheckRolesById(id);
            return isRoleInUse;
        }
    }
}

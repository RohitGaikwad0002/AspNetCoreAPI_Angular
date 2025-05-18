using aspNetCoreWebAPI.Models.MasterModels;
using aspNetCoreWebAPI.Models.Request_DTOs;

namespace aspNetCoreWebAPI.ServiceInterface
{
    public interface IRoleService
    {
        List<RoleRequest> GetAllRoles();
        void AddRole(RoleRequest roleRequest);
        void UpdateRole(int id, RoleRequest roleRequest);
        void DeleteRole(int id);
        RoleRequest GetRoleById(int id);
    }
}

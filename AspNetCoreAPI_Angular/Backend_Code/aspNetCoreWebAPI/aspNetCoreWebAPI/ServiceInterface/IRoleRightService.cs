using aspNetCoreWebAPI.Models.MasterModels;
using aspNetCoreWebAPI.Models.Request_DTOs;

namespace aspNetCoreWebAPI.ServiceInterface
{
    public interface IRoleRightService
    {
        List<RoleRightRequest> GetAllRoleRights();
        RoleRightRequest GetRoleRightById(int id);
        void AddRoleRight(RoleRightSavingRequest roleRightRequest);
        void UpdateRoleRight(List<RoleRightSavingRequest> roleRightRequests);
        void DeleteRoleRight(int id);
    }
}

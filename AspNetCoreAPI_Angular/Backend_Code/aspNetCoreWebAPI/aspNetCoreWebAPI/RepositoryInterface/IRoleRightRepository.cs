using aspNetCoreWebAPI.Models.MasterModels;

namespace aspNetCoreWebAPI.RepositoryInterface
{
    public interface IRoleRightRepository
    {
        IEnumerable<RoleRight> GetAllRoleRights();
        RoleRight GetRoleRightById(int id);
        void AddRoleRight(RoleRight user);
        void UpdateRoleRight(RoleRight user);
        void DeleteRoleRight(int id);
    }
}

using aspNetCoreWebAPI.Models.MasterModels;

namespace aspNetCoreWebAPI.RepositoryInterface
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAllRoles();
        void AddRole(Role role);
        Role GetRoleById(int id);
        void UpdateRole(Role role);
    }
}

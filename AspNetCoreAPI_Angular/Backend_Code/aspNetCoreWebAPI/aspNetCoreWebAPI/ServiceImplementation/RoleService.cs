using aspNetCoreWebAPI.Models.MasterModels;
using aspNetCoreWebAPI.Models.Response_DTOs;
using aspNetCoreWebAPI.Models.Request_DTOs;
using aspNetCoreWebAPI.RepositoryInterface;
using aspNetCoreWebAPI.ServiceInterface;

namespace aspNetCoreWebAPI.ServiceImplementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public List<RoleRequest> GetAllRoles()
        {
            var roles = _roleRepository.GetAllRoles();
            return roles.Select(role => new RoleRequest
            {
                RoleId = role.RoleId,
                RoleName = role.RoleName
            }).ToList();
        }

        public void AddRole(RoleRequest roleRequest)
        {
            Role role = new Role
            {
                RoleName = roleRequest.RoleName,
                CreatedBy = "system",
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };

            _roleRepository.AddRole(role);
        }

        public void UpdateRole(int id, RoleRequest roleRequest)
        {
            var existingRole = _roleRepository.GetRoleById(id);

            if (existingRole != null)
            {
                existingRole.RoleName = roleRequest.RoleName;
                existingRole.ModifiedBy = "system";
                existingRole.ModifiedOn = DateTime.Now;

                _roleRepository.UpdateRole(existingRole);
            }
        }

        public void DeleteRole(int id)
        {
            var role = _roleRepository.GetRoleById(id);

            if (role != null)
            {
                role.IsActive = false;
                role.IsDeleted = true;
                _roleRepository.UpdateRole(role);
            }
        }

        public RoleRequest GetRoleById(int id)
        {
            var role = _roleRepository.GetRoleById(id);
            return role != null
                ? new RoleRequest
                {
                    RoleId = role.RoleId,
                    RoleName = role.RoleName
                }
                : null;
        }
    }
}

using aspNetCoreWebAPI.Models.MasterModels;
using aspNetCoreWebAPI.Models.Request_DTOs;
using aspNetCoreWebAPI.RepositoryInterface;
using aspNetCoreWebAPI.ServiceInterface;
using Microsoft.AspNetCore.Http.HttpResults;
using System.IO;

namespace aspNetCoreWebAPI.Services
{
    public class RoleRightService : IRoleRightService
    {
        private readonly IRoleRightRepository _roleRightRepository;

        public RoleRightService(IRoleRightRepository roleRightRepository)
        {
            _roleRightRepository = roleRightRepository;
        }

        public List<RoleRightRequest> GetAllRoleRights()
        {
            var roleRights = _roleRightRepository.GetAllRoleRights();
            return roleRights.Select(rr => new RoleRightRequest
            {
                RoleRightId = rr.RoleRightId,
                RoleId = rr.RoleId,
                RoleName = rr.Role.RoleName,
                fullAccess = rr.fullAccess,
                canView = rr.canView,
                canAdd = rr.canAdd,
                canEdit = rr.canEdit,
                canDelete = rr.canDelete,
                canImport = rr.canImport,
                canExport = rr.canExport
            }).ToList();
        }

        public RoleRightRequest GetRoleRightById(int id)
        {
            var roleRight = _roleRightRepository.GetRoleRightById(id);
            if (roleRight == null) return null;

            return new RoleRightRequest
            {
                RoleRightId = roleRight.RoleRightId,
                RoleId = roleRight.RoleId,
                //RoleRightName = roleRight.RightName,
                //AllAccess = roleRight.AllAccess,
                //AddAccess = roleRight.AddAccess,
                //EditAccess = roleRight.EditAccess,
                //DeleteAccess = roleRight.DeleteAccess,
                //ViewAccess = roleRight.ViewAccess,
                //RoleName = roleRight.Role.RoleName
            };
        }

        public void AddRoleRight(RoleRightSavingRequest roleRightRequest)
        {
            var roleRight = new RoleRight
            {
                RoleId = roleRightRequest.RoleId,
                fullAccess = roleRightRequest.fullAccess,
                canView = roleRightRequest.canView,
                canAdd = roleRightRequest.canAdd,
                canEdit = roleRightRequest.canEdit,
                canDelete = roleRightRequest.canDelete,
                canImport = roleRightRequest.canImport,
                canExport = roleRightRequest.canExport,
                CreatedBy = "system",
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsDeleted = false
            };

            _roleRightRepository.AddRoleRight(roleRight);
        }

        public void UpdateRoleRight(List<RoleRightSavingRequest> roleRightRequests)
        {
            foreach (var roleRightRequest in roleRightRequests)
            {
                var roleRight = _roleRightRepository.GetRoleRightById(roleRightRequest.RoleRightId);

                if (roleRight != null)
                {
                    roleRight.RoleId = roleRightRequest.RoleId;
                    roleRight.fullAccess = roleRightRequest.fullAccess;
                    roleRight.canView = roleRightRequest.canView;
                    roleRight.canAdd = roleRightRequest.canAdd;
                    roleRight.canEdit = roleRightRequest.canEdit;
                    roleRight.canDelete = roleRightRequest.canDelete;
                    roleRight.canImport = roleRightRequest.canImport;
                    roleRight.canExport = roleRightRequest.canExport;
                    roleRight.ModifiedBy = "system";
                    roleRight.ModifiedOn = DateTime.Now; 

                    _roleRightRepository.UpdateRoleRight(roleRight);
                }
            }
        }

        public void DeleteRoleRight(int id)
        {
            _roleRightRepository.DeleteRoleRight(id);
        }
    }
}

using aspNetCoreWebAPI.Models.MasterModels;
using aspNetCoreWebAPI.Models.Response_DTOs;
using aspNetCoreWebAPI.Models.Request_DTOs;
using aspNetCoreWebAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IUserService _userService;

        public RoleController(IRoleService roleService, IUserService userService)
        {
            _roleService = roleService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            try
            {
                var roles = _roleService.GetAllRoles();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddRole(RoleRequest roleRequest)
        {
            try
            {
                _roleService.AddRole(roleRequest);
                return Content("Role Added Successfully...!");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetRoleById(int id)
        {
            try
            {
                var role = _roleService.GetRoleById(id);
                if (role == null) return NotFound("Role not found");
                return Ok(role);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateRole(int id, RoleRequest roleRequest)
        {
            try
            {
                _roleService.UpdateRole(id, roleRequest);
                return Content("Role Updated Successfully...!");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            try
            {
                if (_userService.CheckRolesById(id))
                {
                    return Content("Role is in use, You can not delete it...!");
                }
                else
                {
                    _roleService.DeleteRole(id);
                    return Content("Role Deleted Successfully...!");
                }
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}

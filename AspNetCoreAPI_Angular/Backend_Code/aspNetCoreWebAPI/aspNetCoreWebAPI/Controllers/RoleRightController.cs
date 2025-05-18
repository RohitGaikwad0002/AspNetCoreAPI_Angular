using aspNetCoreWebAPI.Models.MasterModels;
using aspNetCoreWebAPI.Models.Request_DTOs;
using aspNetCoreWebAPI.Models.Response_DTOs;
using aspNetCoreWebAPI.ServiceInterface;
using aspNetCoreWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoleRightController : ControllerBase
    {
        private readonly IRoleRightService _roleRightService;

        public RoleRightController(IRoleRightService roleRightService)
        {
            _roleRightService = roleRightService;
        }

        [HttpGet]
        public IActionResult GetAllRoleRights()
        {
            var roleRights = _roleRightService.GetAllRoleRights();
            return Ok(roleRights);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetRoleRightById(int id)
        //{
        //    var roleRight = _roleRightService.GetRoleRightById(id);
        //    if (roleRight == null) return NotFound("Role Right not found");
        //    return Ok(roleRight);
        //}

        [HttpPost]
        public IActionResult AddRoleRight(RoleRightSavingRequest roleRightRequest)
        {
            _roleRightService.AddRoleRight(roleRightRequest);
            return Content("Role Right Added Successfully...!");
        }

        [HttpPut]
        public IActionResult UpdateRoleRight(List<RoleRightSavingRequest> roleRightRequests)
        {
            _roleRightService.UpdateRoleRight(roleRightRequests);
            return Content("Role Right Updated Successfully...!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRoleRight(int id)
        {
            _roleRightService.DeleteRoleRight(id);
            return Content("Role Right Deleted Successfully...!");
        }
    }
}

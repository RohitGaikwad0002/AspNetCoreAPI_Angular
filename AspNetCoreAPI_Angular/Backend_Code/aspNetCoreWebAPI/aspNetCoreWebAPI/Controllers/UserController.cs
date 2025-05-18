using aspNetCoreWebAPI.Models.MasterModels;
using aspNetCoreWebAPI.Models.Request_DTOs;
using aspNetCoreWebAPI.Models.Response_DTOs;
using aspNetCoreWebAPI.ServiceInterface;
using Microsoft.AspNetCore.Mvc;

namespace aspNetCoreWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                var roles = _userService.GetAllUsers();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddUser(UserRequest userRequest)
        {
            try
            {
                _userService.AddUser(userRequest);
                return Content("User Added Successfully...!");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            try
            {
                var role = _userService.GetUserById(id);
                if (role == null) return NotFound("User not found");
                return Ok(role);
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, UserRequest userRequest)
        {
            try
            {
                _userService.UpdateUser(id, userRequest);
                return Content("User Updated Successfully...!");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _userService.DeleteUser(id);
                return Content("User Deleted Successfully...!");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}

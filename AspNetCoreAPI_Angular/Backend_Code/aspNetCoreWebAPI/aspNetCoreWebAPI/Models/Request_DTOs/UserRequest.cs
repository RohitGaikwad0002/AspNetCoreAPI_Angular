namespace aspNetCoreWebAPI.Models.Request_DTOs
{
    public class UserRequest
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }

}

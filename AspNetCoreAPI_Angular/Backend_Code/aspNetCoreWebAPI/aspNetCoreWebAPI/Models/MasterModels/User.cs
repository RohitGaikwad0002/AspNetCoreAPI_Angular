namespace aspNetCoreWebAPI.Models.MasterModels
{
    public class User : AuditableEntity
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        // Foreign Key
        public int RoleId { get; set; }

        // Navigation property
        public Role Role { get; set; }
    }

}

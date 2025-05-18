namespace aspNetCoreWebAPI.Models.MasterModels
{
    public class Role : AuditableEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        // Navigation property
        public ICollection<User> Users { get; set; }
        public ICollection<RoleRight> RoleRights { get; set; }
    }

}

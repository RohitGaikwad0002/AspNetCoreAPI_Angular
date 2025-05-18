namespace aspNetCoreWebAPI.Models.MasterModels
{
    public class RoleRight : AuditableEntity
    {
        public int RoleRightId { get; set; }
        public int RoleId { get; set; }
        public bool fullAccess { get; set; }
        public bool canView { get; set; }
        public bool canAdd { get; set; }
        public bool canEdit { get; set; }
        public bool canDelete { get; set; }
        public bool canImport { get; set; }
        public bool canExport { get; set; }

        // Navigation property
        public Role Role { get; set; }
    }

}

namespace aspNetCoreWebAPI.Models.Request_DTOs
{
    public class RoleRightRequest
    {
        public int RoleRightId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool fullAccess { get; set; }
        public bool canView { get; set; }
        public bool canAdd { get; set; }
        public bool canEdit { get; set; }
        public bool canDelete { get; set; }
        public bool canImport { get; set; }
        public bool canExport { get; set; }
    }

    public class RoleRightSavingRequest
    {
        public int RoleRightId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool fullAccess { get; set; }
        public bool canView { get; set; }
        public bool canAdd { get; set; }
        public bool canEdit { get; set; }
        public bool canDelete { get; set; }
        public bool canImport { get; set; }
        public bool canExport { get; set; }
    }

}

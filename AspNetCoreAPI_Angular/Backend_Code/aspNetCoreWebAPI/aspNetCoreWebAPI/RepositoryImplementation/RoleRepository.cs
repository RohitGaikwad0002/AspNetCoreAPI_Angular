using aspNetCoreWebAPI.Models.MasterModels;
using aspNetCoreWebAPI.RepositoryInterface;

namespace aspNetCoreWebAPI.RepositoryImplementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAllRoles()
        {
            return _context.Roles.Where(a => a.IsActive == true && a.IsDeleted == false).ToList();
        }

        public void AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public Role GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleId == id && !r.IsDeleted);
        }

        public void UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
        }
    }
}

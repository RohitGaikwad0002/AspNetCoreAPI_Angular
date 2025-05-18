using aspNetCoreWebAPI.Models.MasterModels;
using aspNetCoreWebAPI.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace aspNetCoreWebAPI.RepositoryImplementation
{
    public class RoleRightRepository : IRoleRightRepository
    {
        private readonly AppDbContext _context;

        public RoleRightRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<RoleRight> GetAllRoleRights()
        {
            return _context.RoleRights.Include(rr => rr.Role).Where(rr => !rr.IsDeleted).ToList();
        }

        public RoleRight GetRoleRightById(int id)
        {
            return _context.RoleRights.Include(rr => rr.Role).FirstOrDefault(rr => rr.RoleRightId == id && !rr.IsDeleted);
        }

        public void AddRoleRight(RoleRight roleRight)
        {
            _context.RoleRights.Add(roleRight);
            _context.SaveChanges();
        }

        public void UpdateRoleRight(RoleRight roleRight)
        {
            _context.RoleRights.Update(roleRight);
            _context.SaveChanges();
        }

        public void DeleteRoleRight(int id)
        {
            var roleRight = _context.RoleRights.FirstOrDefault(rr => rr.RoleRightId == id && !rr.IsDeleted);
            if (roleRight != null)
            {
                roleRight.IsActive = false; 
                roleRight.IsDeleted = true; 
                _context.RoleRights.Update(roleRight);
                _context.SaveChanges();
            }
        }
    }
}

using aspNetCoreWebAPI.Models.MasterModels;
using aspNetCoreWebAPI.RepositoryInterface;
using Microsoft.EntityFrameworkCore;

namespace aspNetCoreWebAPI.RepositoryImplementation
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.Include(u => u.Role).Where(u => !u.IsDeleted).ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.Include(u => u.Role).FirstOrDefault(u => u.UserId == id && !u.IsDeleted);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id && !u.IsDeleted);
            if (user != null)
            {
                user.IsActive = false; 
                user.IsDeleted = true; 
                _context.Users.Update(user);
                _context.SaveChanges();
            }
        }

        public bool CheckRolesById(int id)
        {
            var roles = _context.Users.Where(r => r.RoleId == id).ToList();
            bool isRoleInUse = roles.Count > 0 ? true : false;
            return isRoleInUse;
        }
    }
}

using System.Linq;
using ConquerSite.Data;
using ConquerSite.Models;

namespace ConquerSite.Repository
{
    public class UserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public PlayerModels GetUser(string username, string password)
        {
            return _context.accounts.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
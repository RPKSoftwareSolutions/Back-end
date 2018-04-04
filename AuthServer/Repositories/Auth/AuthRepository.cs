using AuthServer.Auth;
using AuthServer.Generic;
using AuthServer.RepoInterfaces;
using CryptoHelper;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.Repositories
{
    public class AuthRepository: Repository<User>, IAuthRepository
    {
        public AuthRepository(AppDbContext _context) : base(_context) { }

        public bool ValidatePassword(string username, string plainPassword)
        {
            var user = AppContext.Users.FirstOrDefault(u => u.Username == username);
            if (user == null) return false;
            if (Crypto.VerifyHashedPassword(user.Password, plainPassword)) return true;
            return false;
        }

        public IEnumerable<UserClaim> GetUserClaims(int userId)
        {
            return AppContext.UserClaims.Where(c => c.UserId == userId).ToList();
        }

        public AppDbContext AppContext
        {
            get
            {
                return Context as AppDbContext;
            }
        }
    }
}

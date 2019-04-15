using System;
using System.Collections.Generic;
using System.Linq;
using TKD.DomainModel.AuthenticateModels;
using TKD.Infrastructure.RepoInterfaces.Auth;

namespace TKD.Infrastructure.Repositories.Auth
{
    public class AccountRepository: Repository<User>, IAccountRepository
    {
        public AccountRepository(AppDbContext _context) : base(_context) { }

        public PasswordResetToken RequestPasswordReset(int userId)
        {
            // if user has a previous token, delete it first
            var token = AppContext.PasswordResetTokens.FirstOrDefault(p => p.UserId == userId);
            if (token != null)
                AppContext.PasswordResetTokens.Remove(token);

            // generate a new token
            var newToken = Guid.NewGuid().ToString();
            var Token = new PasswordResetToken()
            {
                UserId = userId,
                CreateTime = DateTime.Now,
                ExpiryTime = DateTime.Now.AddHours(3),
                Token = newToken,
                Used = false
            };
            AppContext.PasswordResetTokens.Add(Token);
            return Token;
        }

        public bool UpdatePassword(int userId, string oldPassword, string newPassword)
        {
            var user = AppContext.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null) return false;

            if (CryptoHelper.Crypto.VerifyHashedPassword(user.Password, oldPassword))
            {
                user.Password = CryptoHelper.Crypto.HashPassword(newPassword);
                return true;
            }
            return false;
        }

        public bool ResetPassword(int userId, string passwordResetToken, string newPassword)
        {
            var user = AppContext.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null) return false;

            var token = AppContext.PasswordResetTokens.SingleOrDefault(t => t.UserId == user.Id);
            if (token == null) return false;

            if (String.Equals(passwordResetToken, token.Token))
            {
                user.Password = CryptoHelper.Crypto.HashPassword(newPassword);
                AppContext.PasswordResetTokens.Remove(token);
                return true;
            }
            return false;
        }

        public EmailVerificationToken InitiateEmailVerification(int userId)
        {
            // if there is a previous token for the user, delete it
            var token = AppContext.EmailVerificationTokens.Where(t => t.UserId == userId).FirstOrDefault();
            if (token != null)
                AppContext.EmailVerificationTokens.Remove(token);

            // generate a new token
            var newToken = Guid.NewGuid().ToString();
            var Token = new EmailVerificationToken()
            {
                UserId = userId,
                CreateTime = DateTime.Now,
                ExpiryTime = DateTime.Now.AddDays(1),
                Token = newToken,
                Used = false
            };
            AppContext.EmailVerificationTokens.Add(Token);
            return Token;
        }

        public bool VerifyEmail(int userId, string verificationToken)
        {
            var user = AppContext.Users.SingleOrDefault(u => u.Id == userId);
            if (user == null) return false;

            var token = AppContext.EmailVerificationTokens.SingleOrDefault(t => t.UserId == user.Id);
            if (token == null) return false;

            if (String.Equals(verificationToken, token.Token))
            {
                user.EmailVerified = true;
                return true;
            }

            return false;
        }

        public User FindByPasswordResetToken(string token)
        {
            var Token = this.AppContext.PasswordResetTokens.SingleOrDefault(t => t.Token == token);
            if (Token == null) return null;
            var user = AppContext.Users.SingleOrDefault(u => u.Id == Token.UserId);
            return user;
        }

        public User FindByEmailVerificationToken(string token)
        {
            var Token = this.AppContext.EmailVerificationTokens.SingleOrDefault(t => t.Token == token);
            if (Token == null) return null;
            var user = AppContext.Users.SingleOrDefault(u => u.Id == Token.UserId);
            return user;
        }

        public IList<User> GetTop20()
        {
            return AppContext.UserActivityStats
                .Where(a => a.Variable == "Score")
                .OrderBy(a => a.Value).Select(a => a.User)
                .Take(20)
                .ToList();
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

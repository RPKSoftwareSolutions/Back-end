using AuthServer.Generic;
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthServer.RepoInterfaces
{
    public interface IAccountRepository: IRepository<User>
    {
        // user password management
        PasswordResetToken RequestPasswordReset(int userId);
        bool UpdatePassword(int userId, string oldPassword, string newPassword);
        bool ResetPassword(int userId, string passwordResetToken, string newPassword);

        // user email verification
        EmailVerificationToken InitiateEmailVerification(int userId);
        bool VerifyEmail(int userId, string verificationToken);

        User FindByPasswordResetToken(string token);
        User FindByEmailVerificationToken(string token);

    }
}

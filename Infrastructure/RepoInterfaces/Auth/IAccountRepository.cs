using System.Collections.Generic;
using Framework.Core;
using TKD.DomainModel.AuthenticateModels;

namespace TKD.Infrastructure.RepoInterfaces.Auth
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
        IList<User> GetTop20();

    }
}

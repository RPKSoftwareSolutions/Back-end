﻿using API.Helpers;
using AuthServer.Generic;
using CryptoHelper;
using DomainModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        //private readonly IConfiguration _configuration;
        public AccountsController(IUnitOfWork unitOfWork/*, IConfiguration config*/)
        {
            this._unitOfWork = unitOfWork;
            //this._configuration = config;
        }


        /// <summary>
        /// Obtaining current user's info
        /// GET: api/accounts/userInfo
        /// </summary>  
        [HttpGet("userInfo")]
        [Authorize]
        public ActionResult UserInfo()
        {
            //var userId = int.Parse(User.Identities.FirstOrDefault().Claims.FirstOrDefault(c => c.Type == "sub").Value);
            var userId = GetCurrentUserId(User);
            var user = this._unitOfWork.Users.Get(userId);
            user.Password = "****";
            return Ok(user);
        }


        /// <summary>
        /// Registering new user by email and password
        /// POST: api/accounts/post
        /// </summary>
        /// <param name="user">object of type USER (look at the class USER in the DomainModel project</param>
        [HttpPost("post")]
        public ActionResult Post([FromBody] User user)
        {
            var takenEmailCheck = _unitOfWork.Users.Find(u => u.Email == user.Email).FirstOrDefault();
            if (takenEmailCheck != null)
                //throw new ArgumentException("This email is already taken.");
                return BadRequest("Email address is already taken.");

            user.Password = Crypto.HashPassword(user.Password);
            user.EmailVerified = false;
            user.PhoneNumberVerified = false;
            user.Username = user.Email;
            user.Active = true;
            
            _unitOfWork.Users.Add(user);
            _unitOfWork.Complete();

            // initiating email verification process.
            if (!user.EmailVerified)
            {
                try
                {
                    this.InitiateEmailVerification(user.Id);
                }
                catch (System.Net.Mail.SmtpException ex)
                {
                    _unitOfWork.Users.Remove(user);
                    _unitOfWork.Complete();
                    return StatusCode(512);
                }
            }

            return Ok();
        }


        /// <summary>
        /// Updating user's information. Keep in mind that user cannot update password, phone number and image here. Only the ordinary information can be updated. 
        /// For updating image and password their separate APIs need to be used.
        /// PUT: api/account/put/id
        /// </summary>
        /// <param name="id">Id of the user to be updated</param>
        /// <param name="updatedUser">A new USER object containing new values</param>
        /// <returns></returns>
        [HttpPut("put")]
        [Authorize]
        public ActionResult Put([FromBody] User updatedUser)
        {
            var id = GetCurrentUserId(User);

            var user = _unitOfWork.Users.Get(id);
            if (user == null)
                return NotFound();

            user.DateOfBirth = updatedUser.DateOfBirth;
            user.FirstName = updatedUser.FirstName;
            user.LastName = updatedUser.LastName;
            user.PhoneNumber = updatedUser.PhoneNumber;
            _unitOfWork.Complete();
            return Ok(user);
        }


        /// <summary>
        /// Requesting a password reset. This will result in generating a new passwordResetToken and storing it in the database,
        /// as well as emailing it to the user. The user will then need to use that token with the next API to actually reset their password
        /// POST: api/accounts/requestPasswordReset
        /// </summary>
        [HttpPost("requestPasswordReset/{emailAddress}")]
        public ActionResult RequestPasswordReset(string emailAddress)
        {
            var user = _unitOfWork.Users.Find(u => u.Email == emailAddress).FirstOrDefault();
            if (user == null)
                return NotFound();

            // generate new password reset token in database
            var token = _unitOfWork.Users.RequestPasswordReset(user.Id);
            _unitOfWork.Complete();

            // prepare email msg and send it
            var targetEmail = _unitOfWork.Users.Get(token.UserId).Email;

            // send the email
            // TODO: the third argument is the token, you can replace it with a URL that ends with this token,
            // for example: www.yoursite.com/user/1/passwordReset/the_token_here
         
            try
            {
                EmailSender es = new EmailSender(this._unitOfWork);
                es.SendEmail(targetEmail, "Password Reset", token.Token);
            }
            catch (SmtpException ex)
            {
                return StatusCode(512);
            }
            return Ok();
        }


        /// <summary>
        /// Resets the user's password, given that user provides a valid passwordResetToken.
        /// PUT: api/accounts/resetPassword
        /// </summary>
        /// <param name="vm">an object of type ResetPasswordVM which is defined at the bottom of this page.</param>
        /// <returns>return true if password is successfully updated and false otherwise.</returns>
        [HttpPut("resetPassword")]
        public ActionResult ResetPassword([FromBody] ResetPasswordVM vm)
        {
            var user = _unitOfWork.Users.FindByPasswordResetToken(vm.passwordResetToken);
            if (user == null)
                return NotFound();
            bool wasPasswordUpdated = _unitOfWork.Users.ResetPassword(user.Id, vm.passwordResetToken, vm.newPassword);
            _unitOfWork.Complete();
            //return Ok(wasPasswordUpdated);
            if (wasPasswordUpdated) return Ok();
            else return BadRequest();
        }


        /// <summary>
        /// Updates user's password given the user provides the correct old (current) password.
        /// PUT: api/accounts/updatePassword
        /// </summary>
        /// <param name="vm">an object of type UpdatePasswordVM which is defined at the bottom of this page.</param>
        /// <returns>return true if password is successfully updated and false otherwise.</returns>
        [HttpPut("updatePassword")]
        [Authorize]
        public ActionResult UpdatePassword([FromBody] UpdatePasswordVM vm)
        {
            bool wasPasswordUpdated = _unitOfWork.Users.UpdatePassword(GetCurrentUserId(User), vm.oldPassword, vm.newPassword);
            _unitOfWork.Complete();
            if (wasPasswordUpdated) return Ok();
            else return BadRequest();
        }


        /// <summary>
        /// verify's the user's email address based on the token that is submitted. 
        /// PUT: api/accounts/verifyEmail
        /// </summary>
        /// <param name="emailVerificationToken">the email verification token</param>
        /// <returns>returns true if the email is verified properly and false otherwise</returns>
        [HttpPut("verifyEmail/{emailVerificationToken}")]
        public ActionResult VerifyEmail(string emailVerificationToken)
        {
            var user = _unitOfWork.Users.FindByEmailVerificationToken(emailVerificationToken);
            if (user == null)
                return NotFound();
            bool emailVerified = _unitOfWork.Users.VerifyEmail(user.Id, emailVerificationToken);
            _unitOfWork.Complete();
            if (emailVerified) return Ok();
            else return BadRequest();
        }


        [HttpPost("initiateEmailVerification")]
        public void InitiateEmailVerification(int userId)
        {
            // generating token
            var token = _unitOfWork.Users.InitiateEmailVerification(userId);
            _unitOfWork.Complete();

            // sending email containing token
            var targetEmail = _unitOfWork.Users.Get(token.UserId).Email;
            var es = new EmailSender(this._unitOfWork);
            es.SendEmail(targetEmail, "Email Verification Token", token.Token);
        }

        private int GetCurrentUserId(ClaimsPrincipal User)
        {
            return int.Parse(User.Identities.FirstOrDefault().Claims.FirstOrDefault(c => c.Type == "sub").Value);
        }

    }

    // ViewModels
    public class ResetPasswordVM
    {
        public string passwordResetToken { get; set; }
        public string newPassword { get; set; }
    }


    public class UpdatePasswordVM
    {
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
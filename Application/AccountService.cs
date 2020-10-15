///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using Expoware.Youbiquitous.Core.Extensions;
using Expoware.Youbiquitous.Core.Services;
using Expoware.Youbiquitous.Core.Services.Email;
using Ybq31.Ispiro.Server.Models.Account;
using $safeprojectname$.Common.Settings;
using $safeprojectname$.Common.Shared;
using $safeprojectname$.Infrastructure.Persistence.Repositories;
using $safeprojectname$.Infrastructure.Services;
using $safeprojectname$.Resources;

namespace $safeprojectname$.Application
{
    public class AccountService : ApplicationServiceBase
    {
        private readonly MemberRepository _memberRepository;
        private readonly IPasswordService _passwordService;
        private readonly IFileService _fileService;

        public AccountService(AppSettings settings) : base(settings)
        {
            _memberRepository = new MemberRepository();
            _passwordService = new DefaultPasswordService();
            _fileService = new DefaultFileService(Settings.General.TemplateRoot);
        }

        /// <summary>
        /// Try to locate a matching regular account (whether member or admin) 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public CommandResponse TryAuthenticate(LoginInput input)
        {
            //var candidate = _memberRepository.FindByEmail(input.UserName);
            //if (candidate == null || !_passwordService.Validate(input.Password, candidate.Password))
            //    return CommandResponse.Fail();
            if (input.UserName.EqualsAny(input.Password))
                return CommandResponse.Ok();
            return CommandResponse.Fail();
        }

        /// <summary>
        /// Reset the password for the user corresponding to the given email
        /// </summary>
        /// <param name="email">Email of the user</param>
        /// <returns></returns>
        public CommandResponse TryResetPassword(string email)
        {
            if (email.IsNullOrWhitespace())
                return CommandResponse.Fail();

            // Reset password
            var response = _memberRepository.ResetPassword(email);
            if (response.Success)
            {
                // Send email
                var resetPassword = response.ExtraData;

                // Send email 
                var emailTemplate = _fileService.Load("email_password_reset.txt");
                var message = String.Format(emailTemplate, email, resetPassword);

                new EmailBuilder()
                    .Subject($"MINIMO :: {AppStrings.Label_PasswordReset}")
                    .Message(message)
                    .SendTo(email)
                    .Send();
            }

            return response;
        }

    }
}

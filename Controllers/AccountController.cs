///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Threading.Tasks;
using Expoware.Youbiquitous.Core.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Ybq31.Ispiro.Server.Models.Account;
using $safeprojectname$.Application;
using $safeprojectname$.Common.Extensions;
using $safeprojectname$.Common.Settings;
using $safeprojectname$.Common.Shared;

namespace $safeprojectname$.Controllers
{
    /// <summary>
    /// Provides endpoints for the whole sign-in/sign-out process
    /// </summary>
    public class AccountController : MinimoController
    {
        private readonly AccountService _service;

        public AccountController(AppSettings settings) : base(settings)
        {
            _service = new AccountService(Settings);
        }

        /// <summary>
        /// Displays the login page shared by all users of the system
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("login")]
        public IActionResult ShowSignInPage(LoginInput input)
        {
            var model = new LoginViewModel {Settings = Settings};
            model.FormData.ReturnUrl = input?.ReturnUrl;
            return View(model);
        }

        /// <summary>
        /// Validate provided credentials and logs the user in
        /// </summary>
        /// <param name="input">Values of the login input form</param>
        /// <returns>JSON command response</returns>
        [HttpPost]
        [ActionName("login")]
        public async Task<JsonResult> TrySignIn(LoginInput input)
        {
            var response = _service.TryAuthenticate(input);
            if (response.Success)
            {
                var redirectUrl = input.ReturnUrl.IsNullOrWhitespace() ? "/" : input.ReturnUrl;
                await HttpContext.AuthenticateUser(input.UserName, "guest", input.RememberMe);
                return Json(CommandResponse.Ok().AddRedirectUrl(redirectUrl));
            }

            return Json(CommandResponse.Fail().AddMessage(response.Message));
        }

        /// <summary>
        /// Sign users out of the application
        /// </summary>
        /// <returns></returns>
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("~/");
        }
    }
}

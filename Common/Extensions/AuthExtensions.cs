///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using $safeprojectname$.Common.Settings;
using $safeprojectname$.Infrastructure.Persistence.Model;

namespace $safeprojectname$.Common.Extensions
{
    public static class AuthExtensions
    {
        public static Member Logged(this ClaimsPrincipal user)
        {
            var userName = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var role = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;

            //var repo = new MemberRepository();
            //var member = repo.FindByEmail(userId);
            var member = new Member {UserName = userName, RoleId = "role"};
            return member;
        }

        /// <summary>
        /// Creates the auth cookie for a regular user of the application
        /// </summary>
        /// <param name="context"></param>
        /// <param name="username"></param>
        /// <param name="role"></param>
        /// <param name="rememberMe"></param>
        /// <returns></returns>
        public static async Task AuthenticateUser(this HttpContext context, string username, string role, bool rememberMe)
        {
            await CreateIspiroCookieInternal(context, 
                username, role, rememberMe);
        }


        /// <summary>
        /// Actual code to create the INCAMPO cookie
        /// </summary>
        /// <param name="context"></param>
        /// <param name="email"></param>
        /// <param name="role"></param>
        /// <param name="rememberMe"></param>
        /// <returns></returns>
        private static async Task CreateIspiroCookieInternal(HttpContext context, string email, string role, bool rememberMe)
        {
            // Create the authentication cookie
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, role),    
                new Claim(MinimoAppClaims.ControllerClaim, Role.ControllerFor(role)),
            };
            var identity = new ClaimsIdentity(claims,
                CookieAuthenticationDefaults.AuthenticationScheme);

            await context.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    IsPersistent = rememberMe
                });
        }
    }
}
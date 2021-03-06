﻿///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace $safeprojectname$.Common.Extensions
{
    /// <summary>
    /// Handler of cookie auth events
    /// </summary>
    public class MinimoCookieAuthenticationEvent : CookieAuthenticationEvents
    {
        /// <summary>
        /// Applies any app-specific logic to check if the current auth cookie is valid.
        /// 
        /// EX: the user might have been locked out for some business reason since last
        /// time she logged in and therefore the cookie might be valid any more. 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task ValidatePrincipal(CookieValidatePrincipalContext context)
        {
            // Grab cookie primary information (user name and role)
            var user = context.Principal;
            var userId = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
            var role = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            
            // USE AVAILABLE INFO TO CHECK IF A USER HAS BEEN REVOKED ACCESS MEANWHILE
            //if (revoked-access)
            //{
            //    context.RejectPrincipal();
            //    await context.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            //}
        }
    }
}
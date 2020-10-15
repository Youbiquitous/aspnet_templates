///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using $safeprojectname$.Common.Settings;
using $safeprojectname$.Models;

namespace $safeprojectname$.Controllers
{
    public class AppController : MinimoController
    {
        public AppController(AppSettings settings) : base(settings)
        {
        }

        /// <summary>
        /// Switch the current UI culture
        /// </summary>
        /// <param name="id"></param>
        /// <param name="returnUrl"></param>
        public void Lang(string id, string returnUrl)
        {
            // Set culture to use next
            //CultureAttribute.SavePreferredCulture(HttpContext.Response, id);

            // Return to the calling URL (or go to the site's home page)
            HttpContext.Response.Redirect(returnUrl);
        }


        /// <summary>
        /// Generic error page to show in case of unhandled exceptions
        /// </summary>
        /// <returns>HTML</returns>
        public IActionResult Error([Bind(Prefix = "id")] int statusCode = 0)
        {
            var model = new ErrorViewModel
            {
                Settings = Settings,
                Title = Settings.General.ApplicationName
            };

            // Retrieve error information
            var error = HttpContext.Features.Get<IExceptionHandlerFeature>();
            if (error == null)
                return View(model);

            // Retrieve error information
            var path = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            if (path == null)
                return View(model);

            // NOTE: The view file MUST be shared

            // Store error details
            model.Path = path.Path;
            model.SetError(error.Error);

            // Log the error
            //Logger.LogInformation(error.Error.Message);

            return View(model);
        }
    }
}
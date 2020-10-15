///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Microsoft.AspNetCore.Mvc;
using $safeprojectname$.Common.Exceptions;
using $safeprojectname$.Common.Settings;
using $safeprojectname$.Models;

namespace $safeprojectname$.Controllers
{
    public class DemoController : MinimoController
    {
        public DemoController(AppSettings settings) : base(settings)
        {
        }

        /// <summary>
        /// Throw an exception to show how custom error handling works
        /// </summary>
        /// <returns></returns>
        public IActionResult Throw()
        {
            //throw new NullReferenceException();
            throw new MinimoException("Deliberate exception")
                .AddRecoveryLink("Search on Google", "http://www.google.com")
                .AddRecoveryLink("Search on SO", "http://www.stackoverflow.com");
        }

        /// <summary>
        /// Serves a page with info about the template
        /// </summary>
        /// <returns></returns>
        public IActionResult Info()
        {
            var model = MainViewModelBase.Default(Settings);
            return View(model);
        }
    }
}
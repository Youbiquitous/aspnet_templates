///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Microsoft.AspNetCore.Mvc;
using $safeprojectname$.Application;
using $safeprojectname$.Common.Settings;
using $safeprojectname$.Models;

namespace $safeprojectname$.Controllers
{
    public class HomeController : MinimoController
    {
        private readonly HomeService _homeService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="settings"></param>
        public HomeController(AppSettings settings) : base(settings)
        {
            _homeService = new HomeService(settings);
        }

        /// <summary>
        /// Serves a DEFAULT login-less home page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var model = _homeService.GetHomeViewModel();
            return View(model);
        }

        /// <summary>
        /// Serves a landing page with a WELCOME button only
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Landing()
        {
            var model = LandingViewModelBase.Default(Settings);
            return View(model);
        }
    }
}
///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using $safeprojectname$.Common.Settings;
using $safeprojectname$.Models;

namespace $safeprojectname$.Controllers
{
    [Authorize]
    public class AdminController : MinimoController
    {
        public AdminController(AppSettings settings) : base(settings)
        {
        }

        public IActionResult Index()
        {
            var model = MainViewModelBase.Default(Settings);
            return View(model);
        }
    }
}
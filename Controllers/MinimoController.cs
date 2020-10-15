///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Microsoft.AspNetCore.Mvc;
using $safeprojectname$.Common.Settings;

namespace $safeprojectname$.Controllers
{
    public class MinimoController : Controller
    {
        public MinimoController()
        {
        }

        /// <summary>
        /// Gets and shares application settings
        /// </summary>
        /// <param name="settings"></param>
        public MinimoController(AppSettings settings)
        {
            Settings = settings;
        }

        /// <summary>
        /// Gain access to application settings
        /// </summary>
        protected AppSettings Settings { get; }

    }
}
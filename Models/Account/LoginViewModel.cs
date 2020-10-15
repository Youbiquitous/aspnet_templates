///////////////////////////////////////////////////////////////////
//
// ISPIRO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using $safeprojectname$.Models;

namespace Ybq31.Ispiro.Server.Models.Account
{
    /// <summary>
    /// The input model type used to collect login data
    /// </summary>
    public class LoginViewModel : LandingViewModelBase
    {
        public LoginViewModel()
        {
            FormData = new LoginInput();
        }

        /// <summary>
        /// Login form data
        /// </summary>
        public LoginInput FormData { get; set; }
    }
}
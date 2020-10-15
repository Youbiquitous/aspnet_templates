///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using $safeprojectname$.Common.Settings;
using $safeprojectname$.Models.Home;

namespace $safeprojectname$.Application
{
    public class HomeService : ApplicationServiceBase
    {
        public HomeService(AppSettings settings) : base(settings)
        {
        }

        public HomeViewModel GetHomeViewModel()
        {
            var model = new HomeViewModel(Settings.General.ApplicationName)
            {
                Settings = Settings
            };
            //model.Today = model.Current.ToString("dddd, <b>d MMM</b> yyyy");
            return model;
        }
    }
}
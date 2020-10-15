///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using $safeprojectname$.Common.Settings;

namespace $safeprojectname$.Application
{
    public class ApplicationServiceBase  
    {
        public ApplicationServiceBase(AppSettings settings)
        {
            Settings = settings;
        }

        public AppSettings Settings { get; }
    }
}
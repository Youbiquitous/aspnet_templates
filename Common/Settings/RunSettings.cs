///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//


namespace $safeprojectname$.Common.Settings
{
    public class RunSettings
    {
        public RunSettings()
        {
            DevMode = true;
            EnableLogging = true;
        }

        public bool DevMode { get; set; }
        public bool EnableLogging { get; set; }
    }
}
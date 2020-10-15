///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//


namespace $safeprojectname$.Common.Settings
{
    public class CopyrightSettings
    {
        public string Name { get; set; }
        public string Year { get; set; }

        public override string ToString()
        {
            return $"Copyright {Name} (c) {Year}"; 
        }
    }
}
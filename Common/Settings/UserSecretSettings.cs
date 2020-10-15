///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//


namespace $safeprojectname$.Common.Settings
{
    public class UserSecretsSettings
    {
        public UserSecretsSettings()
        {
            SendgridConfiguration = new SendgridSettings();
        }

        /// <summary>
        /// Connection string to PST DB
        /// </summary>
        public string MinimoConnectionString { get; set; }

        /// <summary>
        ///  Sendgrid configuration
        /// </summary>
        public SendgridSettings SendgridConfiguration { get; set; }
    }
}
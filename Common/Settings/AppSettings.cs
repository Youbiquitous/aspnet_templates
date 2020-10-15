///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System.Collections.Generic;
using System.Globalization;
using Expoware.Youbiquitous.Core.Extensions;
using Expoware.Youbiquitous.Core.Services.Email;

namespace $safeprojectname$.Common.Settings
{
    public class AppSettings
    {
        public const string CultureCookieName = "MINIMO.Culture";
        public const string AuthCookieName = "MINIMO.Auth";


        public AppSettings()
        {
            Languages = new List<string>();
            General = new GeneralSettings();
            Run = new RunSettings();
            Secrets = new UserSecretsSettings();
        }

        public GeneralSettings General { get; set; }
        public List<string> Languages { get; set; }
        public RunSettings Run { get; set; }
        public UserSecretsSettings Secrets { get; set; }


        /// <summary>
        /// Returns the list of cultures supported by the application
        /// </summary>
        /// <returns></returns>
        public IList<CultureInfo> SupportedCultures()
        {
            var list = new List<CultureInfo>();
            foreach (var language in Languages)
            {
                if (language.IsNullOrWhitespace())
                    continue;
                list.Add(new CultureInfo(language));
            }
            return list;
        }

        /// <summary>
        /// For the list of languages (ie, en-us), returns the list of  CultureInfo objects
        /// </summary>
        /// <param name="languages"></param>
        /// <returns></returns>
        public static IList<CultureInfo> GetSupportedCultures(string[] languages)
        {
            if (languages == null)
                return new List<CultureInfo>();

            var list = new List<CultureInfo>();
            foreach (var language in languages)
            {
                if (language.IsNullOrWhitespace())
                    continue;
                list.Add(new CultureInfo(language));
            }

            return list;
        }

        /// <summary>
        /// Configures the system email sender to use the app settings
        /// </summary>
        public void ImportEmailSettings()
        {
            var devAccount = Run.DevMode ? Secrets.SendgridConfiguration.TestEmailWhenInDevMode : "";
            EmailSender.Initialize(
                Secrets.SendgridConfiguration.Username,
                Secrets.SendgridConfiguration.Password,
                Secrets.SendgridConfiguration.SenderEmail,
                Secrets.SendgridConfiguration.SenderDisplayName,
                Secrets.SendgridConfiguration.DefaultCcEmails,
                devAccount);
        }
    }
}
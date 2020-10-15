///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//


using System.Collections.Generic;

namespace $safeprojectname$.Common.Settings
{
    public class SendgridSettings
    {
        public SendgridSettings()
        {
            Username = "";
            Password = "";
            SenderEmail = "";
            SenderDisplayName = "";
            DefaultCcEmails = new List<string>();
            TestEmailWhenInDevMode = "";
        }

        /// <summary>
        /// Sendgrid account name to use
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password for the given Sendgrid account
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Email address appearing as FROM
        /// </summary>
        public string SenderEmail { get; set; }

        /// <summary>
        /// Display name for the actual sender 
        /// </summary>
        public string SenderDisplayName { get; set; }

        /// <summary>
        /// List of email address to put in CC in any sent emails
        /// </summary>
        public List<string> DefaultCcEmails { get; set; }

        /// <summary>
        /// Email address to send emails to (override) when running in DEV mode 
        /// </summary>
        public string TestEmailWhenInDevMode { get; set; }
    }
}
///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using System.Collections.Generic;
using $safeprojectname$.Resources;

namespace $safeprojectname$.Common.Exceptions
{
    /// <summary>
    /// Base exception class to use within the application
    /// </summary>
    public class MinimoException : Exception
    {
        public MinimoException() : base(DefaultMessage())
        {
           
            RecoveryLinks = new List<RecoveryLink>();
        }
        public MinimoException(string message) : base(message)
        {
            RecoveryLinks = new List<RecoveryLink>();
        }
        public MinimoException(Exception exception) : this(exception.Message)
        {
        }

        /// <summary>
        /// Collection of recovery links to show in the UI
        /// </summary>
        public List<RecoveryLink> RecoveryLinks { get; }

        /// <summary>
        /// Default message for the exception
        /// </summary>
        public static string DefaultMessage()
        {
            var msg = AppErrors.ResourceManager.GetString("Err_SomethingWentWrong");
            return msg ?? "Unknown error";
        }

        /// <summary>
        /// Add a new recovery link through its list of pieces of information
        /// </summary>
        /// <param name="text"></param>
        /// <param name="url"></param>
        /// <param name="blank"></param>
        /// <returns></returns>
        public MinimoException AddRecoveryLink(string text, string url, bool blank = false)
        {
            RecoveryLinks.Add(new RecoveryLink(text, url, blank));
            return this;
        }

        /// <summary>
        /// Add a new recovery link as an object
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public MinimoException AddRecoveryLink(RecoveryLink link)
        {
            RecoveryLinks.Add(link);
            return this;
        }
    }

    /// <summary>
    /// Wrapper class for links to show in the recovery UI
    /// </summary>
    public class RecoveryLink
    {
        public RecoveryLink(string text, string url, bool blank = false)
        {
            Text = text;
            Url = url;
            Blank = blank;
        }

        public string Text { get; }
        public string Url { get; }
        public bool Blank { get; }
    }

}
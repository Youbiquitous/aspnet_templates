///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Expoware.Youbiquitous.Core.Extensions;
using $safeprojectname$.Common.Settings;

namespace $safeprojectname$.Models
{
    public class LandingViewModelBase
    {
        protected LandingViewModelBase(string title = "")
        {
            Title = title;
        }

        #region PUBLIC FACTORIES
        public static LandingViewModelBase Default(string title = "")
        {
            var model = new LandingViewModelBase(title);
            return model;
        }

        public static LandingViewModelBase Default(AppSettings settings, string title = "")
        {
            var model = new LandingViewModelBase(title) {Settings = settings, Title= title};
            if (title.IsNullOrWhitespace())
                model.Title = settings?.General.ApplicationName;
            return model;
        }
        #endregion


        /// <summary>
        /// Gets/sets the title of the view 
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets/sets the settings of the application
        /// </summary>
        public AppSettings Settings { get; set; }

        /// <summary>
        /// Indicates whether the model is in a valid state
        /// </summary>
        /// <returns></returns>
        public virtual bool IsValid()
        {
            return true;
        }
    }
}

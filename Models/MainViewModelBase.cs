///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Collections.Generic;
using Expoware.Youbiquitous.Core.Extensions;
using $safeprojectname$.Common.Settings;

namespace $safeprojectname$.Models
{
    public class MainViewModelBase
    {
        protected MainViewModelBase(string title = "")
        {
            Title = title;
            SidebarMenu = new List<SidebarMenuItem>
            {
                new SidebarMenuItem("Landing", "/home/landing"),
                new SidebarMenuItem(),
                new SidebarMenuItem("Login", "/account/login"),
                new SidebarMenuItem(),
                new SidebarMenuItem("Throw", "/demo/throw"),
                new SidebarMenuItem("Private", "/admin/index"),
                new SidebarMenuItem(),
                new SidebarMenuItem("API", "/api/countries", "fas fa-globe", "_blank")
            };
        }

        #region PUBLIC FACTORIES
        public static MainViewModelBase Default(string title = "")
        {
            var model = new MainViewModelBase(title);
            return model;
        }

        public static MainViewModelBase Default(AppSettings settings, string title = "")
        {
            var model = new MainViewModelBase(title) {Settings = settings, Title= title};
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
        /// Menu items
        /// </summary>
        public IList<SidebarMenuItem> SidebarMenu { get; set; }

        /// <summary>
        /// Gets/sets the settings of the application
        /// </summary>
        public AppSettings Settings { get; set; }
    }

    /// <summary>
    /// Class for menu items
    /// </summary>
    public class SidebarMenuItem
    {
        public SidebarMenuItem()
        {
            IsDivider = true;
        }

        public SidebarMenuItem(string text, string url="#", string icon = "", string target = "")
        {
            Text = text;
            Url = url;
            Icon = icon;
            Target = target;
            IsDivider = text.IsNullOrWhitespace();
        }

        public string Text { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public bool IsDivider { get; }
        public string Target { get; set; }
    }
}

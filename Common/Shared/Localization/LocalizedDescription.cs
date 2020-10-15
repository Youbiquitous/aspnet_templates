///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using System.Collections.Generic;
using System.Resources;

namespace $safeprojectname$.Common.Shared.Localization
{
    public class LocalizedDescriptionAttribute : Attribute
    {
        public LocalizedDescriptionAttribute(string resource, string key)
        {
            if (Map != null && Map.ContainsKey(resource))
            {
                var rm = Map[resource];
                Description = rm.GetString(key);
            }
            else
            {
                Description = key;
            }
        }

        /// <summary>
        /// Localized text
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Initializes the dependencies on localized resources
        /// </summary>
        public static void Initialize()
        {
            Map = new Dictionary<string, ResourceManager>(StringComparer.InvariantCultureIgnoreCase);
        }

        /// <summary>
        /// Dictionary of resource managers
        /// </summary>
        public static Dictionary<string, ResourceManager> Map { get; set; }
    }
}

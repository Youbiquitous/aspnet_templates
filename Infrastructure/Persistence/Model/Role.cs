///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using $safeprojectname$.Resources;

namespace $safeprojectname$.Infrastructure.Persistence.Model
{
    /// <summary>
    /// Define the role supported by the application (global setting)
    /// </summary>
    public partial class Role
    {
        public Role()
        {
        }
        public Role(string id)
        {
            Id = id;
            Name = AppBiz.ResourceManager.GetString("Role_" + Id);
        }

        public static Role NewAdmin()
        {
            return new Role(Role.Admin);
        }

        #region Primary key
        public string Id { get; set; }
        #endregion

        /// <summary>
        /// Display name of the role (localized)
        /// </summary>
        public string Name { get; }


        #region Methods

        /// <summary>
        /// Controller to use for each role
        /// </summary>
        /// <param name="roleId"></param>
        /// <returns></returns>
        public static string ControllerFor(string roleId)
        {
            switch (roleId)
            {
                case Role.System:
                    return "system";
                case Role.Admin:
                    return "admin";
                case Role.Guest:
                    return "guest";
                default:
                    return "home";
            }
        }

        #endregion
    }
}

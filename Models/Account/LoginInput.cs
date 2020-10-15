///////////////////////////////////////////////////////////////////
//
// ISPIRO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

namespace Ybq31.Ispiro.Server.Models.Account
{
    /// <summary>
    /// The input model type used to collect login data
    /// </summary>
    public class LoginInput 
    {   
        /// <summary>
        /// The name of the user
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The password (clear text) as the user typed it 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Whether the user intends to stay connected
        /// </summary>
        public bool RememberMe { get; set; }

        /// <summary>
        /// URL to return to in case of direct access to a locked page
        /// </summary>
        public string ReturnUrl { get; set; }
    }
}
///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//


namespace $safeprojectname$.Common.Settings
{
    /// <summary>
    /// Facade for the names of custom claims to be saved in the app cookie
    /// </summary>
    public class MinimoAppClaims
    {
        /// <summary>
        /// Claim name to store the app name in the auth cookie
        /// </summary>
        public static string Name => "Minimo";

        /// <summary>
        /// Claim name to store the controller name in the auth cookie (IF NECESSARY)
        /// </summary>
        public static string ControllerClaim => "controller";

        /// <summary>
        /// Claim name to store the user first name in the auth cookie
        /// </summary>
        public static string FirstNameClaim => "firstname";
        
        /// <summary>
        /// Claim name to store the user last name in the auth cookie
        /// </summary>
        public static string LastNameClaim => "lastname";
    }
}
///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using $safeprojectname$.Common.Shared.Localization;

namespace $safeprojectname$.Infrastructure.Persistence.Model
{
    public enum Gender
    {
        [LocalizedDescription("strings", "Label_PleaseChoose")]
        NotSet = 0,
        Male = 1,
        Female = 2,
        [LocalizedDescription("strings", "Label_PreferNotToSay")]
        PreferNotToSay = 1024,
    }
}
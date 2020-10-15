///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using $safeprojectname$.Common.Shared;
using $safeprojectname$.Infrastructure.Persistence.Model;

namespace $safeprojectname$.Infrastructure.Persistence.Repositories
{
    public partial class MemberRepository : MinimoRepository<Member>
    {
        public CommandResponse ResetPassword(string email)
        {
            return CommandResponse.Ok();
        }
    }
}
///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System.Collections.Generic;
using System.Linq;
using Expoware.Youbiquitous.Core.Extensions;
using Expoware.Youbiquitous.Core.Services;
using $safeprojectname$.Infrastructure.Persistence.Model;

namespace $safeprojectname$.Infrastructure.Persistence.Repositories
{
    public partial class MemberRepository : MinimoRepository<Member>
    {
        private static readonly IPasswordService PasswordService = new DefaultPasswordService();

        /// <summary>
        /// Retrieve the member record (if any) related to the specified email/name/mobile
        /// </summary>
        /// <param name="email"></param>
        /// <returns>Member</returns>
        public Member FindByEmail(string email)
        {
            var member = (from m in All()
                where m.Email.EqualsAny(email)  
                select m).SingleOrDefault();
            return member;
        }

        public Member FindById(long id)
        {
            // Try just for currently detected tenant
            var member = (from m in All()
                where m.Id == id
                select m).SingleOrDefault();
            return member;
        }


        /// <summary>
        /// Physical loader of records from the table to be held in memory
        /// </summary>
        /// <returns></returns>
        protected override IList<Member> LoadFromDatabase()
        {
            //using var db = new MinimoDatabase();
            //var records = (from m in db.Members
            //    where !m.Deleted
            //    select m).ToList();
            var records = new List<Member>();
            return records;
        }
    }
}
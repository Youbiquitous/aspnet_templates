///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace $safeprojectname$.Infrastructure.Persistence.Model
{
    public class Member : MinimoEntity
    {
        public Member()
        {
            TimeStamp.Init();
            Gender = Gender.NotSet;
            RoleId = Role.Guest;
        }

        public Member(string email)
        {
            TimeStamp.Init();
            Gender = Gender.NotSet;
            RoleId = Role.Guest;
            UserName = email;
            Email = email;
        }

        #region Primary-key properties
        public long Id { get; set; }

        [NotMapped]
        public string Guid { get; set; }
        #endregion

        #region Account properties
        /// <summary>
        /// String identifier to log in (user name)
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// String identifier to log in (email address)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Password as clear or hashed text (clear when adding, hashed otherwise)
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Role of the profile 
        /// </summary>
        public string RoleId { get; set; } 

        /// <summary>
        /// If the member is currently locked out of the system
        /// </summary>
        public bool Locked { get; set; }
    
        /// <summary>
        /// Reason she's been locked out
        /// </summary>
        public string LockedMessage { get; set; }
        #endregion


        #region Signup properties

        /// <summary>
        /// GUID to use to confirm this record 
        /// </summary>
        public string ConfirmGuid { get; set; }

        /// <summary>
        /// Time when the GUID for the confirmation email is (re)issued
        /// </summary>
        public DateTime? ConfirmationGuidCreatedOn { get; set; }

        /// <summary>
        /// When the signup email was confirmed
        /// </summary>
        public DateTime? EmailConfirmedOn { get; set; }

       #endregion




        #region Other properties

        #region Identity

        /// <summary>
        /// First name details of the applicant
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name details of the applicant
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gender of the applicant
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Headshot of the applicant
        /// </summary>
        public byte[] Photo { get; set; }
        
        /// <summary>
        /// Birth date
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Your way to present to others
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        ///  Reminder to be shown every time
        /// </summary>
        public string NoteToSelf { get; set; }
        #endregion

      

        #endregion


       

        /// <summary>
        /// Whether the confirm email has been clicked
        /// </summary>
        /// <returns></returns>
        public bool IsConfirmed()
        {
            return EmailConfirmedOn.HasValue;
        }

        /// <summary>
        /// Calculates the percentage of completeness of the user profile
        /// </summary>
        /// <returns></returns>
        public int Completed()
        {
            return GetProfileCompleteness();   
        }
        
        /// <summary>
        /// Whether it is a system user
        /// </summary>
        /// <returns></returns>
        public bool IsSystem()
        {
            return RoleId == Role.System;
        }

        /// <summary>
        /// Whether it is a club ADMIN user
        /// </summary>
        /// <returns></returns>
        public bool IsAdmin()
        {
            return RoleId == Role.Admin;
        }

        public bool IsLocked()
        {
            return Locked;
        }

        /// <summary>
        /// Return the name of the controller for the role of the user
        /// </summary>
        /// <returns></returns>
        public string Controller()
        {
            return Role.ControllerFor(RoleId);
        }

        /// <summary>
        /// Display name
        /// </summary>
        /// <returns></returns>
        public string DisplayName()
        {
            return $"{FirstName} {LastName}".Trim();
        }

        /// <summary>
        /// Returns the URL to get the user picture
        /// </summary>
        /// <returns></returns>
        public string DisplayPicture()
        {
            return PhotoUrl(IsSystem() ?Guid :Id.ToString());
        }

        /// <summary>
        /// Serves the photo of the member
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static string PhotoUrl(string id)
        {
            return $"/app/userphoto/{id}";
        }

        /// <summary>
        /// Export a Role object
        /// </summary>
        /// <returns></returns>
        public Role ToRole()
        {
            return new Role(RoleId);
        }

        #region INTERNALS

        /// <summary>
        /// Calculates the completeness of the user profile
        /// </summary>
        /// <returns></returns>
        private int GetProfileCompleteness()
        {
            return new Random(DateTime.Now.Millisecond).Next(1, 98);
        }
        #endregion
    }
}

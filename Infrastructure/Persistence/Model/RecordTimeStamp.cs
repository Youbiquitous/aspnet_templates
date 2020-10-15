///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using System;
using Expoware.Youbiquitous.Core.Extensions;
using $safeprojectname$.Resources;

namespace $safeprojectname$.Infrastructure.Persistence.Model
{
    /// <summary>
    /// Groups a few timestamp properties for all records in the PST system
    /// </summary>
    //[Owned]
    public class RecordTimeStamp
    {
        /// <summary>
        /// Indicates UTC time of creation of the record
        /// </summary>
        public DateTime? Created { get; set; }

        /// <summary>
        /// Indicates UTC time of last update on the record
        /// </summary>
        public DateTime? Modified { get; set; }

        /// <summary>
        /// Identifier of the user who created (and owns) the record
        /// </summary>
        public string CreatedBy { get; set; }

        /// <summary>
        /// Identifier of the user who last modified the record
        /// </summary>
        public string ModifiedBy { get; set; }

        public void Init()
        {
            Created = DateTime.UtcNow;
            Modified = DateTime.UtcNow;
        }
        public void Init(string author)
        {
            Created = DateTime.UtcNow;
            Modified = DateTime.UtcNow;
            if (!author.IsNullOrWhitespace())
            {
                CreatedBy = author;
                ModifiedBy = author;
            }
        }

        public void Mark()
        {
            Modified = DateTime.UtcNow;
        }
        public void Mark(string author)
        {
            Modified = DateTime.UtcNow;
            if (!author.IsNullOrWhitespace())
                ModifiedBy = author;
        }

        /// <summary>
        /// Returns the date of latest update on the entity
        /// </summary>
        /// <returns></returns>
        public string LatestChangeForDisplay()
        {
            switch (Modified)
            {
                case null when !Created.HasValue:
                    return AppMessages.System_InfoNotAvailable;
                case null:
                    return Created.Value.ToStringOrEmpty("d MMM yyyy", AppMessages.System_InfoNotAvailable);
                default:
                    return Modified.Value.ToStringOrEmpty("d MMM yyyy", AppMessages.System_InfoNotAvailable);
            }
        }
    }
}
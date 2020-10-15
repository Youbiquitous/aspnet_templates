///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//


namespace $safeprojectname$.Infrastructure.Persistence.Model
{
    public class MinimoEntity
    {
        public static string CERTIFIED_NOT = "$N";

        public MinimoEntity()
        {
            TimeStamp = new RecordTimeStamp();
            Deleted = false;
            Enabled = true;
            Order = 1;
        }

        /// <summary>
        /// Indicates whether the entity was previously deleted
        /// </summary>
        public bool Deleted { get; private set; }

        /// <summary>
        /// To set a custom order for display purposes 
        /// </summary>
        public int Order { get; set; }

        /// <summary>
        /// Indicates whether the entity is active or not (if applicable
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// Wraps up the timestamp of the record 
        /// </summary>
        public RecordTimeStamp TimeStamp { get; set; }

        /// <summary>
        /// Indicates whether the state of the entity is valid
        /// </summary>
        /// <returns>True or False</returns>
        public virtual bool IsValidState()
        {
            return true;
        }

        /// <summary>
        /// Whether the record is deleted or not
        /// </summary>
        /// <returns></returns>
        public bool IsDeleted()
        {
            return Deleted;
        }

        /// <summary>
        /// Marks for deletion
        /// </summary>
        public void SoftDelete()
        {
            Deleted = true;
        }
    }
}
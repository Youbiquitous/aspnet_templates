///////////////////////////////////////////////////////////////////
//
// MINIMO: app starter template ASP.NET CORE 3.1
// Copyright (c) Youbiquitous srl 2020
//
// Author: Dino Esposito (http://youbiquitous.net)
//

using Expoware.Youbiquitous.Core.Services;
using Ybq31.Ispiro.Infrastructure.Persistence.Repositories;
using $safeprojectname$.Infrastructure.Persistence.Model;
using Role = $safeprojectname$.Infrastructure.Persistence.Model.Role;


namespace $safeprojectname$.Infrastructure.Persistence
{
    /// <summary>
    /// Database console
    /// </summary>
    public class MinimoDatabase : DbContext
    {
        public static string ConnectionString = "";

        /// <summary>
        /// Overridable method
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        /// <summary>
        /// Overridable model builder
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Index on Member 
            modelBuilder.Entity<Member>()
                .Property(m => m.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Member>()
                .HasIndex(m => new { m.Id });
        }

        /// <summary>
        /// Tables
        /// </summary>
        public DbSet<Member> Members { get; set; }
        public DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Clear all local cache(s)
        /// </summary>
        public static void InvalidateCache()
        {
            MemberRepository.InvalidateCache();
        }

        /// <summary>
        /// Pre-populate the database upon system startup
        /// </summary>
        /// <param name="context"></param>
        public static void Seed(MinimoDatabase context)
        {
            // Set column count for identity auto-generated values
            context.Database.ExecuteSqlRaw("DBCC CHECKIDENT ('Members', RESEED, 10001)");

            // System user
            if (!context.Members.Any())
            {
                var user1 = new Member("systemz@crionet.com")
                {
                    Password = new DefaultPasswordService().Store("1qazxsw2"),
                    Guid = "f969ac8d-252b-44b7-a1cc-2f3dc495ecf8"
                };
                context.Members.Add(user1);
            }

            // Roles
            if (!context.Roles.Any())
            {
                var r0 = new Role(Role.System);
                var r1 = new Role(Role.Admin);
                var r2 = new Role(Role.Guest);
                context.Roles.AddRange(r0, r1, r2);
            }
            
            context.SaveChanges();
        }
    }
}

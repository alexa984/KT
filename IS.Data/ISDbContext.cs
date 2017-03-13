
namespace IS.Data
{
    using System.Data.Entity;
    using System;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Contracts;
    using IS.Models;
    using Migrations.ISDbContext;

    public class ISDbContext : IdentityDbContext<ISUser>
    {
        public ISDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ISDbContext, Configuration>());
        }
        public virtual IDbSet<Business> Businesses { get; set; }
            
        public virtual IDbSet<Service> Services { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<ForumPost> ForumPosts { get; set; }

        public virtual IDbSet<Branch> Branches { get; set; }
        public static ISDbContext Create()
        {
            return new ISDbContext();
        }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
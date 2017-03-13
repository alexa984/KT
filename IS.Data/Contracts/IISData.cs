
namespace IS.Data.Contracts
{
    using System.Data.Entity;
    using Models;
    using IS.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IISData
    {
        DbContext Context { get; }

        IRepository<IdentityUser> Users { get; }

        IRepository<ISUser> ISUsers { get; }

        IRepository<Business> Firms { get; }

        IRepository<Service> Services { get; }

        IRepository<Comment> Comments { get; }

        IRepository<ForumPost> ForumPosts { get; }
        void Dispose();

        int SaveChanges();
    }
}

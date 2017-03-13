using IS.Data.Models;
using IS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IS.Data.Contracts
{
    public class ISData : IISData
    {
        private readonly DbContext context;

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public ISData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<IdentityUser> Users
        {
            get { return this.GetRepository<IdentityUser>();  }
        }

        public IRepository<ISUser> ISUsers
        {
            get { return this.GetRepository<ISUser>(); }
        }

        public IRepository<Business> Firms
        {
            get
            {
                return this.GetRepository<Business>();
            }
        }

        public IRepository<Service> Services
        {
            get
            {
                return this.GetRepository<Service>();
            }
        }

        public IRepository<Comment> Comments
        {
            get
            {
                return this.GetRepository<Comment>();
            }
        }

        public IRepository<ForumPost> ForumPosts
        {
            get
            {
                return this.GetRepository<ForumPost>();
            }
        }

        public IRepository<Branch> Branches
        {
            get
            {
                return this.GetRepository<Branch>();
            }
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Saves all changes made in this context to the underlying database.
        /// </summary>
        /// <returns>
        /// The number of objects written to the underlying database.
        /// </returns>
        /// <exception cref="T:System.InvalidOperationException">Thrown if the context has been disposed.</exception>
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.context != null)
                {
                    this.context.Dispose();
                }
            }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }
    }
}
